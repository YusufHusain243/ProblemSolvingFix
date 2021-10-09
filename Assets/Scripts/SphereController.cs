using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    public float speed = 0.5f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Vector2 force = new Vector2(Random.Range(0, 360), Random.Range(0,360));

        rb.AddForce(force * speed * Time.deltaTime, ForceMode2D.Impulse);
    }

}
