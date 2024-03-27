using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private KeyCode spawnKey;

    void Update()
    {
        if(Input.GetKeyDown(spawnKey))
        {
            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        }
    }
}
