using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    GameObject enemy;
    EnemyHealth enemyHealth;

    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {

        if(other.gameObject.tag == "Enemy")
        {
            enemy = other.gameObject;
            enemyHealth = enemy.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage();
        }
    }
}
