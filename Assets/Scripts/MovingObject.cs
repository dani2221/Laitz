using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class MovingObject : MonoBehaviour
{
    GameObject[] leftleg;
    GameObject[] rightleg;
    bool normal = false;
    public ParticleSystem particle;
    public DistanceJoint2D joint;
    public DistanceJoint2D joint1;
    public bool ishit = false;
    float timer = 0;
    public bool isLit = false;
    UnityEngine.Experimental.Rendering.Universal.Light2D light;
    public float speed = 1f;
    public GameObject line2;
    LineRenderer line;
    Vector3 positions;
    Vector3 positionss;
    int k = 0;
    bool stop = false;
    void Start()
    {
        line = line2.GetComponent<LineRenderer>();
        joint = gameObject.AddComponent<DistanceJoint2D>();
        joint1 = gameObject.AddComponent<DistanceJoint2D>();
        joint.enabled = false;
        joint1.enabled = false;
        joint.autoConfigureDistance = true;
        joint1.autoConfigureDistance = true;
        joint.distance = 1f;
        joint1.distance = 1f;
        joint.maxDistanceOnly = true;
        joint1.maxDistanceOnly = true;
        rightleg = GameObject.FindGameObjectsWithTag("Attach");
        leftleg = GameObject.FindGameObjectsWithTag("AttachLeft");
        light = GetComponentInChildren<UnityEngine.Experimental.Rendering.Universal.Light2D>();
        line.enabled = false;
        positions = new Vector3(transform.position.x, transform.position.y, 0);
        positionss = new Vector3(PlayerController.instance.transform.position.x, PlayerController.instance.transform.position.y, 0);
        line.startWidth = 0.1f;
        particle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (normal == true)
        {
         //   PlayerController.instance.setToNormal();
            joint.distance = 1f;
            joint1.distance = 1f;
            Physics2D.gravity = new Vector2(0, 0);
            PlayerController.instance.transform.position = new Vector2(PlayerController.instance.transform.position.x + speed, PlayerController.instance.transform.position.y);
            PlayerController.instance.rigidbody2D.velocity= Vector2.zero;
        }

        positions = new Vector3(transform.position.x, transform.position.y, 0);
        positionss = new Vector3(PlayerController.instance.transform.position.x, PlayerController.instance.transform.position.y, 0);
        if (transform.position.x < -2.5f)
            speed *= -1;
        if (transform.position.x > 2.5f)
            speed *= -1;
        if (transform.position.x > 3f || transform.position.x<-3f)
            transform.position = new Vector2(0, transform.position.y);
        speed = Walls.instance.speed;
        if(stop==false)
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
        if (PlayerController.instance.jump == true)
        {
            Physics2D.gravity= new Vector2(0,-9.81f);
            normal = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            timer = 0.3f;
            jumpRelease();
            line.enabled = false;
            if (Input.mousePosition.x > Screen.width * 0.5f)
                PlayerController.instance.rigidbody2D.velocity = new Vector2(-PlayerController.instance.jumpDistanceLeft, PlayerController.instance.jumpDistanceUp);
            if (Input.mousePosition.x <= Screen.width * 0.5f)
                PlayerController.instance.rigidbody2D.velocity = new Vector2(-PlayerController.instance.jumpDistanceRight, PlayerController.instance.jumpDistanceUp);
        }
        else
        {
            if (timer < 0)
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                line.SetPosition(0, positions);
                line.SetPosition(1, positionss);
            }
        }

        
        if (isLit == false)
        {
            light.intensity = 0.35f;
        }
        else
        {
            light.intensity = 1.4f;
            if (k == 0)
            {
                particle.Play();
                k++;
            }
        }

        timer -= Time.deltaTime;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
            //line.enabled = true;
            PlayerController.instance.setToNormal();
            for (int i = 0; i < leftleg.Length; i++)
            {
                joint.connectedBody = leftleg[i].GetComponent<Rigidbody2D>();
                joint1.connectedBody = rightleg[i].GetComponent<Rigidbody2D>();
            }
            isLit = true;
           // joint.enabled = true;
            //joint1.enabled = true;
            ishit = true;
            timer = 0.5f;
        normal = true;
    }
    public void jumpRelease()
    {
        PlayerController.instance.m = 0;
        joint.enabled = false;
        joint1.enabled = false;
        ishit = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        normal = false;
    }
    private void OnBecameInvisible()
    {
        stop = true;
    }
    private void OnBecameVisible()
    {
        stop = false;
    }
}
