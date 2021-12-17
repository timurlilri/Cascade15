using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.SceneManagement;

public class HeroMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 moveVector;
    public float speed = 2f;
    public SpriteRenderer sr;
    public Animator anim;

    public static HeroMove Instance { get; set; } //pattern singleton

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        WallCheckRadius = WallCheck.GetComponent<CircleCollider2D>().radius;
        gravityDef = rb.gravityScale;

    }
    void Update()
    {
        walk();
        Reflect();
        CheckingGround();
        CheckingLadder();
        LaddersMechanics();
        LadderUpDown();
        //if (isDead) { return; }
        CheckingWall();
        MoveOnWall();
        WallJump();
    }
    void FixedUpdate()
    {
        Jump();
    }



    public bool faceRight = true;
    void Reflect() //turn of the hero's movement
    {
        if ((moveVector.x > 0 && !faceRight) || (moveVector.x < 0 && faceRight))
        {
            transform.localScale *= new Vector2(-1, 1);
            faceRight = !faceRight;
        }
    }


    void walk() //hero movement
    {
        if (!blockMoveX)
        { 
            moveVector.x = Input.GetAxis("Horizontal");
            anim.SetFloat("moveX", Mathf.Abs(moveVector.x));
            rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
        }
    }


    public float jumpForce = 7f;
    public int jumpCount = 0;
    public int maxJumpValue = 2;
    public bool jumpControl;
    public float jumpTime = 0;
    public float jumpControlTime = 0.7f;
    public float doubleJumpVelocity = 10f;

    void Jump() //Controllable hero jump with the possibility of a double jump
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (onGround)
            {
                anim.StopPlayback();
                anim.Play("monkey_jump");
                jumpControl = true;
            }
        }
        else { jumpControl = false; }
        //-------------------------------------------
        if (Input.GetKeyDown(KeyCode.Space) && !onGround && (++jumpCount < maxJumpValue))
        {
            anim.StopPlayback();
            anim.Play("monkey_doublejump");
            rb.velocity = new Vector2(0, doubleJumpVelocity);
        }
        //-------------------------------------------
        if (onGround) { jumpCount = 0; }
        //-------------------------------------------
        if (jumpControl)
        {
            if ((jumpTime += Time.deltaTime) < jumpControlTime)
            {
                rb.AddForce(Vector2.up * jumpForce / (jumpTime * 10));
            }
        }
        else { jumpTime = 0; }
        //--------------------------------------------
    }

    //------------------------------------------
    public bool onGround;
    public Transform GroundCheck;
    public float checkRadius = 0.2f;
    public LayerMask Ground;
    void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);
        anim.SetBool("onGround", onGround);
    }
    //------------------------------------------


    //Checking and moving up/down the "ladder" by a hero

    public float check_RADIUS = 0.2f;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(LadderCheck.position, check_RADIUS);
    }

    public Transform LadderCheck;
    public bool checkedLadder;
    public LayerMask LadderMask;

    void CheckingLadder()
    {
        checkedLadder = Physics2D.OverlapPoint(LadderCheck.position, LadderMask);
    }

    public float ladderSpead = 1.5f;
    void LaddersMechanics()
    {
        if (checkedLadder)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.velocity = new Vector2(rb.velocity.x, moveVector.y * ladderSpead);
            anim.SetBool("onLadder", true);

        }
        else { rb.bodyType = RigidbodyType2D.Dynamic; anim.SetBool("onLadder", false); }
    }
    void LadderUpDown()
    {
        moveVector.y = Input.GetAxisRaw("Vertical");
    }
    //--------------------------------------------------

    public bool isDead = false;

    public void Die()
    {
        isDead = true;
        //FindObjectOfType<LevelManager>().RestartScene();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Platform"))
        {
            this.transform.parent = collision.transform;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Platform"))
        {
            this.transform.parent = null;
        }
    }



    public bool onWall;
    public LayerMask Wall;
    public Transform WallCheck;
    private float WallCheckRadius;
    void CheckingWall()
    {
        onWall = Physics2D.OverlapCircle(WallCheck.position, WallCheckRadius, Wall);
        anim.SetBool("onWall", onWall);
    }



    public float upDownSpeed = 4f;
    public float slideSpeed = 0;
    private float gravityDef;
    void MoveOnWall()
    {
        if (onWall && !onGround)
        {
            if (!blockMoveX)
            {
                moveVector.y = Input.GetAxisRaw("Vertical");
                if (moveVector.y == 0)
                {
                    rb.gravityScale = 0;
                    rb.velocity = new Vector2(0, slideSpeed);
                }
            }
                

        }
        else if (!onGround && !onWall) { rb.gravityScale = gravityDef; }
    }



    private bool blockMoveX;
    public float jumpWallTime = 0.2f;
    private float timerJumpWall;
    public Vector2 jumpAngle = new Vector2( 0.002f, 0.003f);
    void WallJump()
    {
        if (onWall && !onGround && Input.GetKeyDown(KeyCode.Space))
        {
            blockMoveX = true;

            moveVector.x = 0;
            transform.localScale *= new Vector2(-1, 1);

            faceRight = !faceRight;

            rb.gravityScale = gravityDef;
            rb.velocity = new Vector2(0, 0);
            rb.velocity = new Vector2(transform.localScale.x * jumpAngle.x, jumpAngle.y);
        }
        if (blockMoveX && (timerJumpWall += Time.deltaTime) >= jumpWallTime)
        {
            if (onWall || onGround || Input.GetAxisRaw("Horizontal") != 0)
            {
                blockMoveX = false;
                timerJumpWall = 0;
            }
        }
    }
}
