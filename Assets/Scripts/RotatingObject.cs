using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class RotatingObject : MonoBehaviour
{
    GameObject[] leftleg;
    GameObject[] rightleg;
    public ParticleSystem particle;
    public DistanceJoint2D joint;
    public DistanceJoint2D joint1;
    public bool ishit = false;
    GameObject[] back;
    GameObject[] backy;
    float timer = 0;
    UnityEngine.Experimental.Rendering.Universal.Light2D light;
    public bool isLit = false;
    int k = 0;
    void Start()
    {
        light = GetComponentInChildren<UnityEngine.Experimental.Rendering.Universal.Light2D>();
        joint = gameObject.AddComponent<DistanceJoint2D>();
        joint1 = gameObject.AddComponent<DistanceJoint2D>();
        joint.enabled = false;
        joint1.enabled = false;
        rightleg = GameObject.FindGameObjectsWithTag("Attach");
        leftleg = GameObject.FindGameObjectsWithTag("AttachLeft");
        joint.autoConfigureDistance = false;
        joint1.autoConfigureDistance = false;
        joint.distance = 1f;
        joint1.distance = 1f;
        joint.maxDistanceOnly = true;
        joint1.maxDistanceOnly = true;
        back = GameObject.FindGameObjectsWithTag("Back");
        backy = GameObject.FindGameObjectsWithTag("Backy");
        particle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(0, 0, 1f);
        if (PlayerController.instance.jump == true)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            timer = 0.3f;
            jumpRelease();
            if (Input.mousePosition.x > Screen.width * 0.5f)
                PlayerController.instance.rigidbody2D.velocity = new Vector2(-PlayerController.instance.jumpDistanceLeft, PlayerController.instance.jumpDistanceUp);
            if (Input.mousePosition.x <= Screen.width * 0.5f)
                PlayerController.instance.rigidbody2D.velocity = new Vector2(-PlayerController.instance.jumpDistanceRight, PlayerController.instance.jumpDistanceUp);
        }
        else if (timer < 0)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        if (isLit == false)
        {
            light.intensity = 0.35f;
        }
        else
        {
            light.intensity = 1.3f;
            if (k == 0)
            {
                particle.Play();
                k++;
            }
        }

        timer -= Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController.instance.setToNormal();
        isLit = true;
        for (int i = 0; i < leftleg.Length; i++)
        {
            joint.connectedBody = leftleg[i].GetComponent<Rigidbody2D>();
            //joint1.connectedBody = rightleg[i].GetComponent<Rigidbody2D>();
        }
        joint.enabled = true;
        //joint1.enabled = true;
        ishit = true;
        timer = 0.5f;
        for (int i = 0; i < backy.Length; i++)
        {
           // backy[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }
    }
    public void jumpRelease()
    {
        joint.enabled = false;
        //joint1.enabled = false;
        ishit = false;
        PlayerController.instance.m = 0;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        for (int i = 0; i < backy.Length; i++)
        {
            //backy[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
           // backy[i].transform.eulerAngles = new Vector3(backy[i].transform.eulerAngles.x, backy[i].transform.eulerAngles.y, 90);
        }
        for (int i = 0; i < back.Length; i++)
        {
          //  back[i].transform.eulerAngles = new Vector3(back[i].transform.eulerAngles.x, back[i].transform.eulerAngles.y, 90);
        }
    }
}
