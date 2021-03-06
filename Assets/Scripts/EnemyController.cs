using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        GameObject sphere = GameObject.Find("Sphere");
        Problem_9 problem_9 = sphere.GetComponent<Problem_9>();

        if(problem_9.dead = true)
        {
            if (Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene("Problem_9");
            }
        }
        else
        {
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Pedang")
        {
            GameObject sphere = GameObject.Find("Sphere");
            Problem_9 problem_9 = sphere.GetComponent<Problem_9>();
            problem_9.score += 5;
            Destroy(this.gameObject);
        }
    }
}
