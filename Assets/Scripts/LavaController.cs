using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LavaController : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 1.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(speed<30f)
            speed = speed + (transform.position.y +10f)/ 100000;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
        if (PlayerController.instance.GetComponent<Rigidbody2D>().velocity.y < -20f)
        {
            transform.position= Camera.main.transform.position;
        }
        if (PlayerController.instance.transform.position.y - this.transform.position.y > 20f)
        {
            this.transform.position = new Vector2(0, PlayerController.instance.transform.position.y - 20f);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController.instance.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -30f);
    }
}
