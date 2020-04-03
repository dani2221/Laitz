using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class StaticController : MonoBehaviour
{
    GameObject[] leftleg;
    GameObject[] rightleg;
    public ParticleSystem particle;
    public FixedJoint2D joint;
    public  FixedJoint2D joint1;
    public bool ishit = false;
    float timer = 0;
    public bool isLit = false;
    UnityEngine.Experimental.Rendering.Universal.Light2D light;
    int k = 0;
    void Start()
    {
        joint = gameObject.AddComponent<FixedJoint2D>();
        joint1 = gameObject.AddComponent<FixedJoint2D>();
        joint.enabled = false;
        joint1.enabled = false;
        rightleg = GameObject.FindGameObjectsWithTag("Attach");
        leftleg = GameObject.FindGameObjectsWithTag("AttachLeft");
        light = GetComponentInChildren <UnityEngine.Experimental.Rendering.Universal.Light2D>();
        particle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
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
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
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
        catch { }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        try
        {
            PlayerController.instance.setToNormal();
        
            for (int i = 0; i < leftleg.Length; i++)
            {
                joint.connectedBody = leftleg[i].GetComponent<Rigidbody2D>();
                //joint1.connectedBody = rightleg[i].GetComponent<Rigidbody2D>();
            }
            isLit = true;
            joint.enabled = true;
            //joint1.enabled = true;
            ishit = true;
            timer = 0.5f;
        }
        catch { }
    }
    public void jumpRelease()
    {
        PlayerController.instance.m = 0;
        joint.enabled = false;
        //joint1.enabled = false;
        ishit = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
}
