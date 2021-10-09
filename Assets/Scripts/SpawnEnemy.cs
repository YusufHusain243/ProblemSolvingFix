using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject gameObject;
    public float minX, maxX, minY, maxY;

    // Start is called before the first frame update
    void Start()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        GameObject Object =  Instantiate(gameObject, new Vector2(randomX, randomY), Quaternion.identity) as GameObject;
        Object.transform.SetParent(GameObject.FindGameObjectWithTag("SpawnerEnemy").transform, false);
    }

    private void Update()
    {
        if (transform.childCount < 1)
        {
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            GameObject Object = Instantiate(gameObject, new Vector2(randomX, randomY), Quaternion.identity) as GameObject;
            Object.transform.SetParent(GameObject.FindGameObjectWithTag("SpawnerEnemy").transform, false);
        }
    }
}
