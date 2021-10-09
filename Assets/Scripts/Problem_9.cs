using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Problem_9 : MonoBehaviour
{
    public float speed = 2.0f;
    public float minX, maxX, minY, maxY;
    public Text scoreText;
    public int score;
    public GameObject pedang;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    private void Update()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vertic = Input.GetAxis("Vertical");

        if (horiz != 0 || vertic != 0)
        {
            Vector2 direction = new Vector2(horiz, vertic);
            transform.position += transform.up * speed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        }
        else if (horiz == 0 || vertic == 0)
        {
            InputMouse();
        }

        if (speed > 5)
        {
            speed = 5;
        }

        scoreText.text = "Score : " + score.ToString();
    }

    void InputMouse()
    {
        Vector3 pos = Input.mousePosition;
        pos = Camera.main.ScreenToWorldPoint(pos);

        if (pos.x > minX && pos.x < maxX && pos.y > minY && pos.y < maxY)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, pos - transform.position);
            transform.position = Vector2.MoveTowards(transform.position, pos, speed * Time.deltaTime);
            pos.z = 1.0f;
        }
        else
        {
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Object" || collision.gameObject.tag == "Speed")
        {
            score += 1;
        }

        if (collision.gameObject.tag == "Speed")
        {
            float timeSpeed = 5.0f;
            speed += 3;
            timeSpeed += 5.0f;
            Invoke("normalSpeed", timeSpeed);
        }

        if(collision.gameObject.tag == "Pedang")
        {
            float timePedang = 5.0f;
            pedang.SetActive(true);
            timePedang += 5.0f;
            Invoke("UnActivatedPedang", timePedang);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }

    void normalSpeed()
    {
        speed = 2.0f;
    }

    void UnActivatedPedang()
    {
        pedang.SetActive(false);
    }
}
