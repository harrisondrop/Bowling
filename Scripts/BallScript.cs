using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class BallScript : MonoBehaviour
{

    Rigidbody rb;
    float x;
    float z;
    float speed = 20;
    int playersTurn = 1;
    float timer = 10;

    // Start is called before the first frame update
    void Start()
    {
        //getting pins similar to getting rigidbody
        rb = GetComponent<Rigidbody>();
        GameObject pin = (GameObject)Resources.Load("prefabs/prefab1", typeof(GameObject));
        CreatePins(pin);
    }

    bool allPinsDown()
    {
        
        return true;
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer - Time.deltaTime;
        if (transform.position.z < 10)
        {
            z = Input.GetAxis("Vertical");

            rb.AddForce(x * speed, 0, z * speed, 0);

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.Translate(1, 0, 0);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.Translate(-1, 0, 0);
            }
        }

        if ((transform.position.z > 70 || transform.position.y < 0) && timer <= 0)
        {
            if (allPinsDown() && playersTurn == 2)
            {
                SceneManager.LoadScene("startingScene");
                playersTurn = 1;
                timer = 10;
            }
            else
            {
                gameObject.transform.position = new Vector3(0, 0.5f, 0);
                rb.AddForce(0, 0, 0, 0);
                rb.Sleep();
                gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
                playersTurn += 1;
                timer = 10;
            }
        }

    }
    void CreatePins(GameObject pin)
    {
        float x = 0;
        float y = 5/3;
        float z = 60;
        Quaternion c = new Quaternion();
        
        Instantiate((GameObject)Resources.Load("prefabs/prefab1", typeof(GameObject)), new Vector3(x, y, z), c);
        Instantiate((GameObject)Resources.Load("prefabs/prefab1", typeof(GameObject)), new Vector3(x + 1.05f, y, z + 1.05f), c);
        Instantiate((GameObject)Resources.Load("prefabs/prefab1", typeof(GameObject)), new Vector3(x - 1.05f, y, z + 1.05f), c);
    }
}
