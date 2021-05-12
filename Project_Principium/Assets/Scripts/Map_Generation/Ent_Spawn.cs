using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ent_Spawn : MonoBehaviour
{
    public int entSpawnChance;
    public GameObject entToSpawm;

    void Start()
    {
        int randomNumber = Random.Range(0, 100);

        if (randomNumber <= entSpawnChance)
        {
            Instantiate(entToSpawm, gameObject.transform);
        }
    }
}
