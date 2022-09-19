using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRB;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        enemyRB = this.GetComponent<Rigidbody>();
        if (!GameManager.isGameOver)
            player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(new Vector3(90.0f, 0.0f, 0.0f), Space.Self);

        if (!GameManager.isGameOver)
        {
            Vector3 lookDirection = (player.transform.position - this.transform.position).normalized;
            enemyRB.AddForce(lookDirection * speed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject otherObject = collision.gameObject;

        if (otherObject.CompareTag("Wall"))
        {
            Debug.Log("Enemy Destroyed");
            //DestroyObject(gameObject);
            GameManager.score += 25;
            GameManager.gameManager.UpdateScore();
            GameObject.Destroy(gameObject);
        }
        /*if (otherObject.CompareTag("Enemy") || otherObject.CompareTag("Player"))
        {
            Debug.Log("Collided Enemy with Enemy");

            if (otherObject.transform.position.z < -11 || otherObject.transform.position.z > 11
                || otherObject.transform.position.x < -9
                || otherObject.transform.position.x > 9)
            {
                otherObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
                //GameManager.kills++;
                //GameManager.gameManager.UpdateKills();
                this.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
                float speed = 20.0f;
                Rigidbody enemyRB = collision.gameObject.GetComponent<Rigidbody>();
                enemyRB.AddForce(Vector3.forward * speed);
            }
        }*/
    }
}
