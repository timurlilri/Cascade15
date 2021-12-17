using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform shotpos;
    public GameObject Bullet;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (FrCounter.Fruit > 0)
            {
                FrCounter.Fruit -= 1;
                Instantiate(Bullet, shotpos.transform.position, transform.rotation);
            }
        }
    }
}