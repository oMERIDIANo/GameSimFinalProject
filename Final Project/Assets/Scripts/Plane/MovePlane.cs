using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlane : MonoBehaviour
{
    public GameObject fire1;
    public GameObject fire2;
    public GameObject fire3;
    public GameObject regen;

    public Transform[] gridPositions;

    float elapsedFire1;
    float elapsedFire2;
    float elapsedFire3;
    float elapsedRegen;

    bool moved1;
    bool moved2;
    bool moved3;
    bool isRegen = true;

    RegenerateHealth regenerateHealth;

    // Start is called before the first frame update
    void Start()
    {
        regenerateHealth = regen.GetComponent<RegenerateHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedFire1 += Time.deltaTime;
        elapsedFire2 += Time.deltaTime;
        elapsedFire3 += Time.deltaTime;
        elapsedRegen += Time.deltaTime;

        if (elapsedFire1 >= 5 && moved1 == false)
        {
            Move1();

            elapsedFire1 = 0;
        }

        if (elapsedFire2 >= 10 && moved2 == false)
        {
            Move2();

            elapsedFire2 = 0;
        }

        if (elapsedFire3 >= 15 && moved3 == false)
        {
            Move3();

            elapsedFire3 = 0;
        }

        moved1 = false;
        moved2 = false;
        moved3 = false;

        if(isRegen == false && elapsedRegen >= 45)
        {
            Debug.Log("Spawn Regen");
            SpawnRegenGrid();
        }

        if(regenerateHealth.amount == 0)
        {
            Destroy(regenerateHealth.gameObject);
            isRegen = false;
        }
    }

    void Move1()
    {
        moved1 = true;

        int random = Random.Range(0, 3);

        fire1.transform.position = gridPositions[random].position;
    }

    void Move2()
    {
        moved2 = true;

        int random = Random.Range(4, 8);

        fire2.transform.position = gridPositions[random].position;
    }

    void Move3()
    {
        moved2 = true;

        int random = Random.Range(9, 15);

        fire3.transform.position = gridPositions[random].position;
    }

    void SpawnRegenGrid()
    {
        elapsedRegen = 0;

        int random = Random.Range(11, 14);

        regen.transform.position = gridPositions[random].position;
    }
}
