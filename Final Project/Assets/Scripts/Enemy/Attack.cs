using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    GameObject player;
    Rigidbody rb;
    PlayerHealth playerHealth;

    bool isPlayer;

    float elapsed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rb = player.GetComponent<Rigidbody>();
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        elapsed += Time.deltaTime;

        if(isPlayer == true && elapsed >= 1)
        {
            DamagePlayer();
            rb.AddForce(-player.transform.forward * 10000f);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            isPlayer = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            isPlayer = false;
        }
    }

    void DamagePlayer()
    {
        playerHealth.health -= 10f;
        elapsed = 0;
        rb.AddForce(player.transform.forward * 100f);
    }
}
