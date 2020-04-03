using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class GameControll : MonoBehaviour
{
    public GameObject normalObjectPrefab;
    public GameObject rotateObjectPrefab;
    public GameObject movingObjectPrefab;
    public GameObject timeObjectPrefab;
    public GameObject Background;
    public Text score;
    public Text HS;
    float meters;
    float highscore;
    int whatPrefab;
    float poz;
    int numOfInstance;
    int k = 1;
    int m = 0;
    public Text Dollar;
    float HStime;
    int money;
    float maxScore=0;
    public bool isEndless;

    void Start()
    {
        DontDestroyAD.instance.loadAD();
        highscore = PlayerPrefs.GetFloat("highscore");
        HStime = PlayerPrefs.GetFloat("highscoretime");
        money = PlayerPrefs.GetInt("money");
        if (isEndless)
            PlayerController.instance.setEndless();
        else
            PlayerController.instance.setTime();


        if (PlayerPrefs.GetInt("graphics") == 0)
            Camera.main.GetComponent<PostProcessLayer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        int isRevive = PlayerPrefs.GetInt("revive");
        float postion = PlayerPrefs.GetFloat("maxScore");
        //Debug.Log(PlayerController.instance.transform.position.y.ToString());
        if(isRevive==1)
        {
            GameObject[] lista = GameObject.FindGameObjectsWithTag("Back");
            GameObject[] lista1 = GameObject.FindGameObjectsWithTag("Attach");
            GameObject[] lista2 = GameObject.FindGameObjectsWithTag("AttachLeft");
            if (PlayerController.instance.transform.position.y < postion+5f)
            {
                PlayerController.instance.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 10f);
                PlayerController.instance.GetComponent<CircleCollider2D>().enabled = false;
                foreach (GameObject jas in lista)
                {
                    jas.GetComponent<CapsuleCollider2D>().enabled = false;
                }
                foreach (GameObject jas in lista1)
                {
                    jas.GetComponent<CapsuleCollider2D>().enabled = false;
                }
                foreach (GameObject jas in lista2)
                {
                    jas.GetComponent<CapsuleCollider2D>().enabled = false;
                }
            }
            else
            {
                PlayerPrefs.SetInt("revive", 0);
                PlayerPrefs.SetInt("usedRevive", 1);
                PlayerController.instance.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0f);
                foreach (GameObject jas in lista)
                {
                    jas.GetComponent<CapsuleCollider2D>().enabled = true;
                }
                foreach (GameObject jas in lista1)
                {
                    jas.GetComponent<CapsuleCollider2D>().enabled = true;
                }
                foreach (GameObject jas in lista2)
                {
                    jas.GetComponent<CapsuleCollider2D>().enabled = true;
                }
            }
        }
        Dollar.text = "$" + money.ToString();
        meters = PlayerController.instance.transform.position.y + 3.1f;
        score.text = meters.ToString("F2")+"m";
        if (meters > maxScore)
            maxScore = meters;
        if (isEndless)
        {
            if (meters >= highscore)
                highscore = meters;
            HS.text = "HS:" + highscore.ToString("F2") + "m";
        }
        else
        {
            if (meters >= HStime)
                HStime = meters;
            HS.text = "HS:" + HStime.ToString("F2") + "m";
        }

        if (roundup(meters) % 10 == 0 && Mathf.Round(meters)>5)
        {
            score.rectTransform.localScale = new Vector2(2, 2);
            score.color = Color.red;
        }
        if (score.rectTransform.localScale.x > 1)
        {
            score.rectTransform.localScale = new Vector2(score.rectTransform.localScale.x - 0.05f, score.rectTransform.localScale.y - 0.05f);
            score.color = Color.red;
        }
        else
        {
            score.color = Color.white;
        }


        if (Camera.main.transform.position.y>9*k)
        {
            loadNext();
            k++;
            money += 10;
        }
        destroy();
    }
    void loadNext()
    {
        for (int i = 2; i < 5; i++)
        {
            whatPrefab = Random.Range(1, 9);
            if(whatPrefab==1 || whatPrefab == 2 || whatPrefab == 3)
            {
                poz = Camera.main.transform.position.y + i * 3;
                Vector2 objectPosition = new Vector2(Random.Range(-2.25f, 2.25f), poz);
                Instantiate(normalObjectPrefab, objectPosition, Quaternion.identity);
            }
            if (whatPrefab == 4 || whatPrefab == 5)
            {
                poz = Camera.main.transform.position.y + i * 3;
                Vector2 objectPosition = new Vector2(Random.Range(-2.25f, 2.25f), poz);
                Instantiate(rotateObjectPrefab, objectPosition, Quaternion.identity);
            }
            if (whatPrefab == 6 || whatPrefab == 7)
            {
                poz = Camera.main.transform.position.y + i * 3;
                Vector2 objectPosition = new Vector2(Random.Range(-2.25f, 2.25f), poz);
                Instantiate(timeObjectPrefab, objectPosition, Quaternion.identity);
            }
            if (whatPrefab == 8)
            {
                poz = Camera.main.transform.position.y + i * 3;
                Vector2 objectPosition = new Vector2(Random.Range(-2.25f, 2.25f), poz);
                Instantiate(movingObjectPrefab, objectPosition, Quaternion.identity);
            }
        }
    }
    public void destroy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject e in enemies)
        {
            if(PlayerController.instance.transform.position.y-e.transform.position.y>20)
            {
                Destroy(e);
            }
            if(e.transform.position.x<-2.6f || e.transform.position.x > 2.6f)
            {
                Instantiate(movingObjectPrefab, new Vector2(0, e.transform.position.y), Quaternion.identity);
                Destroy(e);
            }
        }
    }
    private void OnDisable()
    {
        PlayerPrefs.SetFloat("highscore", highscore);
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.SetFloat("highscoretime",HStime);
        PlayerPrefs.SetFloat("maxScore", maxScore);
    }
    private float roundup(float num)
    {
        if (Mathf.Round(num) - num < 0)
            return Mathf.Round(num);
        else
            return num;
    }
}
