using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Game : MonoBehaviour
{
    public GameObject prefab;
    GameObject[] PinList;
    int playerTurn = 1;
    float timeLeft = 10;
    // Start is called before the first frame update
    void Start()
    {
        PinList = createPins();
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft = timeLeft - Time.deltaTime;
        if (playerTurn <= 2)
        {
            for (int i = 0; i < 10; i++)
            {
                if ((Math.Abs(PinList[i].transform.localRotation.eulerAngles.x) >= 90 || Math.Abs(PinList[i].transform.localRotation.eulerAngles.z) >= 90) && timeLeft <= 0)
                {
                    Destroy(PinList[i]);
                }
            }
        }
    }

    GameObject[] createPins()
    {
        GameObject p1 = Instantiate(prefab, new Vector3(0, 1.5f, 60), new Quaternion(0, 0, 0, 0));
        GameObject p2 = Instantiate(prefab, new Vector3(-1, 1.5f, 61), new Quaternion(0, 0, 0, 0));
        GameObject p3 = Instantiate(prefab, new Vector3(1, 1.5f, 61), new Quaternion(0, 0, 0, 0));
        GameObject p4 = Instantiate(prefab, new Vector3(-2, 1.5f, 62), new Quaternion(0, 0, 0, 0));
        GameObject p5 = Instantiate(prefab, new Vector3(0, 1.5f, 62), new Quaternion(0, 0, 0, 0));
        GameObject p6 = Instantiate(prefab, new Vector3(2, 1.5f, 62), new Quaternion(0, 0, 0, 0));
        GameObject p7 = Instantiate(prefab, new Vector3(-3, 1.5f, 63), new Quaternion(0, 0, 0, 0));
        GameObject p8 = Instantiate(prefab, new Vector3(-1, 1.5f, 63), new Quaternion(0, 0, 0, 0));
        GameObject p9 = Instantiate(prefab, new Vector3(1, 1.5f, 63), new Quaternion(0, 0, 0, 0));
        GameObject p10 = Instantiate(prefab, new Vector3(3, 1.5f, 63), new Quaternion(0, 0, 0, 0));
        GameObject[] listOfPins = new GameObject[] { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10};
        return listOfPins;
    }
}
