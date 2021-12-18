using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenerateHealth : MonoBehaviour
{
    GameObject player;
    PlayerHealth playerHealth;
    bool isPlayer;
    float elapsed;
    public int amount = 50;
    MovePlane movePlane;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        movePlane = FindObjectOfType<MovePlane>();
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;

        if(playerHealth.health >= 100)
        {
            return;
        }

        if(isPlayer == true && elapsed >= 2.5 && amount > 0)
        {
            Debug.Log("Regenerating");
            GivePlayerHealth();
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

    void GivePlayerHealth()
    {
        int random = Random.Range(5, 15);

        amount -= random;
        playerHealth.health += random;
    }
}
