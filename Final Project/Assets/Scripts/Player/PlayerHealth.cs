using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100;

    [SerializeField]
    Image healthImage;

    // Start is called before the first frame update
    void Start()
    {
        UpdateHUD();
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHUD();

        if(health <= 0)
        {
            SceneManager.LoadScene("Return");
        }

        Debug.Log("Health: " + health);
        GameManager.instance.health = health;
    }

    void UpdateHUD()
    {
        healthImage.fillAmount = health / 100.0f;
    }
}
