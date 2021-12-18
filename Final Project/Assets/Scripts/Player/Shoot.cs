using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;

    [SerializeField]
    float bulletSpeed;

    public Transform gun1;
    public Transform gun2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Vector3 bulletDirection = transform.forward * bulletSpeed;
            GameObject a = Instantiate(bullet, gun1.position, transform.rotation);
            GameObject b = Instantiate(bullet, gun2.position, transform.rotation);
            a.GetComponent<Rigidbody>().velocity = bulletDirection;
            b.GetComponent<Rigidbody>().velocity = bulletDirection;           
        }
    }
}
