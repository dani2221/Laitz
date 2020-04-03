using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class TImeObject : MonoBehaviour
{
    GameObject[] leftleg;
    GameObject[] rightleg;
    public ParticleSystem particle;
    public FixedJoint2D joint;
    public FixedJoint2D joint1;
    public bool ishit = false;
    float timer = 0;
    public bool isLit = false;
    UnityEngine.Experimental.Rendering.Universal.Light2D light;
    int k = 0;
    int p = 0;
    float timerexplode = 2f;
    void Start()
    {
        joint = gameObject.AddComponent<FixedJoint2D>();
        joint1 = gameObject.AddComponent<FixedJoint2D>();
        joint.enabled = false;
        joint1.enabled = false;
        rightleg = GameObject.FindGameObjectsWithTag("Attach");
        leftleg = GameObject.FindGameObjectsWithTag("AttachLeft");
        light = GetComponentInChildren<UnityEngine.Experimental.Rendering.Universal.Light2D>();
        particle.Stop();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (timerexplode < 1f)
        {
            if(gameObject.transform.localScale.x>0)
                gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x - 0.1f, gameObject.transform.localScale.y - 0.1f, gameObject.transform.localScale.z - 0.1f);
            joint.enabled = false;
            joint1.enabled = false;
        }
        if (timerexplode > 0 && ishit == true)
        {
            timerexplode -= Time.deltaTime;
            light.color = new Color(light.color.r + 0.015f, light.color.g - 0.015f, light.color.b - 0.015f, 255);
            gameObject.GetComponent<SpriteRenderer>().color = new Color(gameObject.GetComponent<SpriteRenderer>().color.r + 0.015f, gameObject.GetComponent<SpriteRenderer>().color.g - 0.015f, gameObject.GetComponent<SpriteRenderer>().color.b - 0.015f, 255);
        }
    }
    void Update()
    {
        if(ishit==false)
        {
            if (gameObject.transform.localScale.x > 0.99f)
            {
                timerexplode = 2f;
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 1, 1, 1);
                light.color = new Color(0, 1, 1, 1);
            }
        }
        if(timerexplode<0)
        {
            Destroy(gameObject);
        }
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        p = 0;
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
    public void jumpRelease()
    {
        PlayerController.instance.m = 0;
        joint.enabled = false;
        //joint1.enabled = false;
        ishit = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
}
