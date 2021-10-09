using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObject_9 : MonoBehaviour
{
    public GameObject[] gameObject;
    public float minX, maxX, minY, maxY;

    // Start is called before the first frame update
    void Start()
    {
        int gameObjectAmount = 5;
        for (int i = 0; i < gameObjectAmount; i++)
        {
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            int randomObject = Random.Range(0, gameObject.Length);
            GameObject Object =  Instantiate(gameObject[randomObject], new Vector2(randomX, randomY), Quaternion.identity) as GameObject;
            Object.transform.SetParent(GameObject.FindGameObjectWithTag("Spawner").transform, false);
        }
        StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject()
    {
        if (transform.childCount < 5)
        {
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            int randomObject = Random.Range(0, gameObject.Length);
            GameObject Object = Instantiate(gameObject[randomObject], new Vector2(randomX, randomY), Quaternion.identity) as GameObject;
            Object.transform.SetParent(GameObject.FindGameObjectWithTag("Spawner").transform, false);
        }
        yield return new WaitForSeconds(3);
        StartCoroutine(SpawnObject());
    }

}
