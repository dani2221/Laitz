using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject[] player;
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < player.Length; i++)
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, player[i].transform.position.y, Camera.main.transform.position.z);
        }
        if(Camera.main.transform.position.y<0 && PlayerController.instance.isDead==false)
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 0.2f, Camera.main.transform.position.z);

    }
}
