using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    private Rigidbody wRB;
    public float speed;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        wRB = GetComponent<Rigidbody>();
        if (!GameManager.isGameOver)
            player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.isGameOver)
        {
            Debug.Log("Applying force");
            wRB.AddForce(Vector3.right * speed, ForceMode.Impulse);

            if (this.transform.position.x - player.transform.position.x > 10.0f)
            {
                Debug.Log("Destroying Wave");
                GameObject.Destroy(this.gameObject);
            }
        }
    }
}
