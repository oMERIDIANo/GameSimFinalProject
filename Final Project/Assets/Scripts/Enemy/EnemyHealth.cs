using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update

    public int health = 100;
    Spawner spawner;

    void Start()
    {
        spawner = FindObjectOfType<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
            spawner.enemyCount -= 1;
            GameManager.instance.score += 10;
            Debug.Log("Score: " + GameManager.instance.score);
        }

        if (GameManager.instance.score >= 1000f)
        {
            SceneManager.LoadScene("YouWon");
        }
    }

    public void TakeDamage()
    {
        health -= 20;
    }
}
