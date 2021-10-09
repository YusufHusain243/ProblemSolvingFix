using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 poss = GameObject.Find("Sphere").transform.position;
        transform.position = Vector2.MoveTowards(transform.position, poss, speed * Time.deltaTime);
    }
}
