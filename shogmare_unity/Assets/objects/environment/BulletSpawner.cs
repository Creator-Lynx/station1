using System.Numerics;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bullet;

    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            Instantiate(bullet, transform.position, bullet.transform.rotation);
        }
    }
}
