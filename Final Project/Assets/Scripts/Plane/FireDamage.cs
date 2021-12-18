using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamage : MonoBehaviour
{
    GameObject player;
    PlayerHealth playerhealth;

    bool isPlayer = false;

    float elaspedPlayer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerhealth = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        elaspedPlayer += Time.deltaTime;

        if (isPlayer == true && elaspedPlayer >= .5)
        {
            Debug.Log("Burning Player");
            DamagePlayer();
        }
    }

    private void OnCollisionEnter(Collision other)
    {   
        if(other.gameObject.tag == "Player")
        {
            isPlayer = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayer = false;
            
        }
    }

    void DamagePlayer()
    {
        playerhealth.health -= 1;
        elaspedPlayer = 0;
    }
}
