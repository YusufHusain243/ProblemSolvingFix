using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObject : MonoBehaviour
{
    public GameObject gameObject;
    public float minX, maxX, minY, maxY;

    // Start is called before the first frame update
    void Start()
    {
        int gameObjectAmount = Random.Range(5, 10);
        for (int i = 0; i < gameObjectAmount; i++)
        {
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            Instantiate(gameObject, new Vector2(randomX, randomY), Quaternion.identity);
        }
    }

}
