using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rigidbody2D;
    public int jumps = 2;
    int k = 0;
    public int m = 0;
    public GameObject rigidbody2Darmleft;
    public GameObject rigidbody2Darmright;
    public GameObject rigidbody2Dtorso;
    public GameObject rigidbody2Dleftupleg;
    public GameObject rigidbody2Drightupleg;
    public GameObject rigidbody2Dleftdownleg;
    public GameObject rigidbody2Drightdownleg;
    public GameObject rigidbody2Dleftuplegempty;
    public GameObject rigidbody2Drightuplegempty;
    public GameObject rigidbody2Dleftdownlegempty;
    public GameObject rigidbody2Drightdownlegempty;
    public GameObject rigidbody2Darmleftempty;
    public GameObject rigidbody2Darmrightempty;
    public float jumpDistanceUp=5f;
    public float jumpDistanceRight = 2f;
    public float jumpDistanceLeft;
    public static PlayerController instance;
    public GameObject background;
    public Material material1;
    public bool jump = false;
    public bool isDead = false;
    AudioSource hit;
    public bool isExpertLevel;

    bool isEndless = true;

    public ParticleSystem[] particle;
    int numOfParticle;
    //Collision collision;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        hit = GetComponent<AudioSource>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        jumpDistanceLeft = -jumpDistanceRight;

        numOfParticle = PlayerPrefs.GetInt("particle");
        for (int i = 0; i < particle.Length; i++)
        {
            particle[i].Stop();
            particle[i].maxParticles = 1000;
        }
        //numOfParticle = 10;
        if (numOfParticle < 11 && numOfParticle > 0)
            particle[numOfParticle - 1].Play();
        if (PlayerPrefs.GetInt("effects") == 1)
            this.GetComponent<AudioSource>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
            activity.Call<bool>("moveTaskToBack", true);
        }
        if (jump==true && jumps>1)
        {
            jumps = 1;
        }

        //PlayerPrefs.DeleteAll();
        if(rigidbody2D.velocity.y<-15f)
        {
            dieNow();
        }
        jump = false;
        if (jumps == 0)
        {
            gameObject.GetComponent<Renderer>().material.color=Color.green;
            rigidbody2Darmleft.GetComponent<Renderer>().material.color = Color.green;
            rigidbody2Darmright.GetComponent<Renderer>().material.color = Color.green;
            rigidbody2Dtorso.GetComponent<Renderer>().material.color = Color.green;
            rigidbody2Dleftupleg.GetComponent<Renderer>().material.color = Color.green;
            rigidbody2Drightupleg.GetComponent<Renderer>().material.color = Color.green;
            rigidbody2Dleftdownleg.GetComponent<Renderer>().material.color = Color.green;
            rigidbody2Drightdownleg.GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.white;
            rigidbody2Darmleft.GetComponent<Renderer>().material.color = Color.white;
            rigidbody2Darmright.GetComponent<Renderer>().material.color = Color.white;
            rigidbody2Dtorso.GetComponent<Renderer>().material.color = Color.white;
            rigidbody2Dleftupleg.GetComponent<Renderer>().material.color = Color.white;
            rigidbody2Drightupleg.GetComponent<Renderer>().material.color = Color.white;
            rigidbody2Dleftdownleg.GetComponent<Renderer>().material.color = Color.white;
            rigidbody2Drightdownleg.GetComponent<Renderer>().material.color = Color.white;
        }
        if (Input.GetMouseButtonDown(0) && jumps>0)
        {
            jump = true;

            if (jumps == 1 || jumps==2)
            {
                setToNormalwithoutjump();
            }
            if (Input.mousePosition.x < Screen.width * 0.5f)
            {
                rigidbody2D.velocity = Vector2.zero;
                rigidbody2Darmleft.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                rigidbody2Darmright.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                rigidbody2Dtorso.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                rigidbody2Dleftupleg.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                rigidbody2Drightupleg.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                rigidbody2Dleftdownleg.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                rigidbody2Drightdownleg.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                //rigidbody2D.AddForce(new Vector2(jumpDistanceLeft, jumpDistanceUp));
                rigidbody2Dleftuplegempty.transform.eulerAngles = new Vector3(rigidbody2Dleftuplegempty.transform.eulerAngles.x, rigidbody2Dleftuplegempty.transform.eulerAngles.y, 270);
                rigidbody2Drightdownlegempty.transform.eulerAngles = new Vector3(rigidbody2Drightdownlegempty.transform.eulerAngles.x, rigidbody2Drightdownlegempty.transform.eulerAngles.y, 30);
                rigidbody2Darmrightempty.transform.eulerAngles = new Vector3(rigidbody2Darmrightempty.transform.eulerAngles.x, rigidbody2Darmrightempty.transform.eulerAngles.y, 30);
                rigidbody2Darmleftempty.transform.eulerAngles = new Vector3(rigidbody2Darmleftempty.transform.eulerAngles.x, rigidbody2Darmleftempty.transform.eulerAngles.y, 30);
            }
            else
            {
                rigidbody2D.velocity = Vector2.zero;
                rigidbody2Darmleft.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                rigidbody2Darmright.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                rigidbody2Dtorso.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                rigidbody2Dleftupleg.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                rigidbody2Drightupleg.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                rigidbody2Dleftdownleg.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                rigidbody2Drightdownleg.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                //rigidbody2D.AddForce(new Vector2(jumpDistanceRight, jumpDistanceUp));
                rigidbody2Drightuplegempty.transform.eulerAngles = new Vector3(rigidbody2Drightuplegempty.transform.eulerAngles.x, rigidbody2Drightuplegempty.transform.eulerAngles.y, -270);
                rigidbody2Dleftdownlegempty.transform.eulerAngles = new Vector3(rigidbody2Dleftdownlegempty.transform.eulerAngles.x, rigidbody2Dleftdownlegempty.transform.eulerAngles.y, -30);
                rigidbody2Darmrightempty.transform.eulerAngles = new Vector3(rigidbody2Darmrightempty.transform.eulerAngles.x, rigidbody2Darmrightempty.transform.eulerAngles.y, -30);
                rigidbody2Darmleftempty.transform.eulerAngles = new Vector3(rigidbody2Darmleftempty.transform.eulerAngles.x, rigidbody2Darmleftempty.transform.eulerAngles.y, -30);

            }
            jumps--;

        }
    }
    public void setEndless()
    {
        isEndless = true;
    }
    public void setTime()
    {
        isEndless = false;
    }
    public void setToNormal()
    {
        rigidbody2D.velocity = Vector2.zero;
        rigidbody2Darmleft.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        rigidbody2Darmright.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        rigidbody2Dtorso.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        rigidbody2Dleftupleg.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        rigidbody2Drightupleg.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        rigidbody2Dleftdownleg.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        rigidbody2Drightdownleg.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        if (m == 0)
        {
            rigidbody2Dleftuplegempty.transform.eulerAngles = new Vector3(rigidbody2Dleftuplegempty.transform.eulerAngles.x, rigidbody2Dleftuplegempty.transform.eulerAngles.y, 0);
            rigidbody2Drightdownlegempty.transform.eulerAngles = new Vector3(rigidbody2Drightdownlegempty.transform.eulerAngles.x, rigidbody2Drightdownlegempty.transform.eulerAngles.y, 0);
            rigidbody2Darmrightempty.transform.eulerAngles = new Vector3(rigidbody2Darmrightempty.transform.eulerAngles.x, rigidbody2Darmrightempty.transform.eulerAngles.y, 0);
            rigidbody2Darmleftempty.transform.eulerAngles = new Vector3(rigidbody2Darmleftempty.transform.eulerAngles.x, rigidbody2Darmleftempty.transform.eulerAngles.y, 0);
            rigidbody2Drightuplegempty.transform.eulerAngles = new Vector3(rigidbody2Drightuplegempty.transform.eulerAngles.x, rigidbody2Drightuplegempty.transform.eulerAngles.y, 0);
            rigidbody2Dleftdownlegempty.transform.eulerAngles = new Vector3(rigidbody2Dleftdownlegempty.transform.eulerAngles.x, rigidbody2Dleftdownlegempty.transform.eulerAngles.y, 0);
            jumps = 2;
            hit.Play();
            m++;
        }
    }
    public void setToNormalwithoutjump()
    {
        rigidbody2Dleftuplegempty.transform.eulerAngles = new Vector3(rigidbody2Dleftuplegempty.transform.eulerAngles.x, rigidbody2Dleftuplegempty.transform.eulerAngles.y, 0);
        rigidbody2Drightdownlegempty.transform.eulerAngles = new Vector3(rigidbody2Drightdownlegempty.transform.eulerAngles.x, rigidbody2Drightdownlegempty.transform.eulerAngles.y, 0);
        rigidbody2Darmrightempty.transform.eulerAngles = new Vector3(rigidbody2Darmrightempty.transform.eulerAngles.x, rigidbody2Darmrightempty.transform.eulerAngles.y, 0);
        rigidbody2Darmleftempty.transform.eulerAngles = new Vector3(rigidbody2Darmleftempty.transform.eulerAngles.x, rigidbody2Darmleftempty.transform.eulerAngles.y, 0);
        rigidbody2Drightuplegempty.transform.eulerAngles = new Vector3(rigidbody2Drightuplegempty.transform.eulerAngles.x, rigidbody2Drightuplegempty.transform.eulerAngles.y, 0);
        rigidbody2Dleftdownlegempty.transform.eulerAngles = new Vector3(rigidbody2Dleftdownlegempty.transform.eulerAngles.x, rigidbody2Dleftdownlegempty.transform.eulerAngles.y, 0);
    }
    public void dieNow()
    {
        if (k == 0)
        {
            background.GetComponent<SpriteRenderer>().color = Color.black;
            k++;
        }
        isDead = true;
        background.GetComponent<SpriteRenderer>().material = material1;
        if (isExpertLevel == true)
            SceneManager.LoadScene(3);
        else if (isEndless == true && isExpertLevel == false)
            SceneManager.LoadScene(13);
        else
            SceneManager.LoadScene(14);
    }
}
