using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] GameObject[] MyObjectToRespawn;  // Array de objetos para respawn
    [SerializeField] Vector3 pos;  // Posição onde o objeto será spawnado

    private void Start()
    {
        SpawnObjects();
    }

    private void SpawnObjects()
    {
        if (MyObjectToRespawn.Length > 0)
        {
            int randomIndex = Random.Range(0, MyObjectToRespawn.Length);  // Seleciona um índice aleatório
            GameObject obj = Instantiate(MyObjectToRespawn[randomIndex], pos, Quaternion.identity);
            obj.transform.parent = transform;
        }
        else
        {
            Debug.LogWarning("MyObjectToRespawn array is empty. No objects to spawn.");
        }
    }
}

