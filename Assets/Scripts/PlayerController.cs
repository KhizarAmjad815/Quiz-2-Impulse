using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody playerRB;
    public GameObject rightWave;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(new Vector3(90.0f, 0.0f, 0.0f), Space.Self);

        if (!GameManager.isGameOver)
        {
            // Allowing the player to move (physical-based movement)
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
                //playerRB.AddForce(Vector3.left * speed);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                //playerRB.AddForce(Vector3.right * speed);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
                //playerRB.AddForce(Vector3.forward * speed);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
                //playerRB.AddForce(Vector3.back * speed);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                Vector3 pos = new Vector3(transform.position.x + 2.0f, 2.5f, 14.29f);
                Instantiate(rightWave, pos, rightWave.transform.rotation);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject otherObject = collision.gameObject;
        if (otherObject.CompareTag("Wall") || otherObject.CompareTag("InnerWall"))
        {
            Debug.Log("Player hit with wall");
            GameObject.Destroy(gameObject);
            GameManager.isGameOver = true;
            GameManager.gameManager.UpdateScore();
            /*
            Rigidbody enemyRB = otherObject.GetComponent<Rigidbody>();
            enemyRB.AddForce(Vector3.forward * speed);*/
        }
    }
}
