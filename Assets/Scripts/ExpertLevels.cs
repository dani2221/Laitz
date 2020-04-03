using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExpertLevels : MonoBehaviour
{
    // Start is called before the first frame update
    public int lvlcomplete1;
    public int lvlcomplete2;
    public int lvlcomplete3;
    public int lvlcomplete4;
    public int lvlcomplete5;
    public int lvlcomplete6;

    public Button lvl1;
    public Button lvl2;
    public Button lvl3;
    public Button lvl4;
    public Button lvl5;
    public Button lvl6;

    float highscore;
    int p;

    public static ExpertLevels instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        lvl1.enabled = false;
        lvl2.enabled = false;
        lvl3.enabled = false;
        lvl4.enabled = false;
        lvl5.enabled = false;
        lvl6.enabled = false;
        lvl1.GetComponent<Image>().color = Color.grey;
        lvl2.GetComponent<Image>().color = Color.grey;
        lvl3.GetComponent<Image>().color = Color.grey;
        lvl4.GetComponent<Image>().color = Color.grey;
        lvl5.GetComponent<Image>().color = Color.grey;
        lvl6.GetComponent<Image>().color = Color.grey;
        lvlcomplete1 = PlayerPrefs.GetInt("lvl1");
        lvlcomplete2 = PlayerPrefs.GetInt("lvl2");
        lvlcomplete3 = PlayerPrefs.GetInt("lvl3");
        lvlcomplete4 = PlayerPrefs.GetInt("lvl4");
        lvlcomplete5 = PlayerPrefs.GetInt("lvl5");
        lvlcomplete6 = PlayerPrefs.GetInt("lvl6");
        highscore = PlayerPrefs.GetFloat("highscore");
        p = Mathf.RoundToInt(highscore);
        for (int i = p ; i>0 ; i--)
        {
            if (i == 500)
            {
                lvl6.enabled = true;
                lvl6.GetComponent<Image>().color = Color.magenta;
            }
            if (i == 250)
            {
                lvl5.enabled = true;
                lvl5.GetComponent<Image>().color = Color.cyan;
            }
            if (i == 150)
            {
                lvl4.enabled = true;
                lvl4.GetComponent<Image>().color = Color.cyan;
            }
            if (i == 90)
            {
                lvl3.enabled = true;
                lvl3.GetComponent<Image>().color = Color.magenta;
            }
            if (i == 50)
            {
                lvl2.enabled = true;
                lvl2.GetComponent<Image>().color = Color.magenta;
            }
            if (i == 20)
            {
                lvl1.enabled = true;
                lvl1.GetComponent<Image>().color = Color.cyan;
            }
;        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("lvl1" + lvlcomplete1.ToString());
        Debug.Log("lvl2" + lvlcomplete2.ToString());
        Debug.Log("lvl3" + lvlcomplete3.ToString());
        Debug.Log("lvl4" + lvlcomplete4.ToString());
        Debug.Log("lvl5" + lvlcomplete5.ToString());
        Debug.Log("lvl6" + lvlcomplete6.ToString());
        if (lvlcomplete1 == 1)
            lvl1.GetComponent<Image>().color = Color.green;
        if (lvlcomplete2 == 1)
            lvl2.GetComponent<Image>().color = Color.green;
        if (lvlcomplete3 == 1)
            lvl3.GetComponent<Image>().color = Color.green;
        if (lvlcomplete4 == 1)
            lvl4.GetComponent<Image>().color = Color.green;
        if (lvlcomplete5 == 1)
            lvl5.GetComponent<Image>().color = Color.green;
        if (lvlcomplete6 == 1)
            lvl6.GetComponent<Image>().color = Color.green;
        /*lvlcomplete1=0;
        lvlcomplete2=0;
        lvlcomplete3=0;
        lvlcomplete4=0;
        lvlcomplete5=0;
        lvlcomplete6 = 0;*/
    }
    private void OnDisable()
    {
        PlayerPrefs.SetInt("lvl1", lvlcomplete1);
        PlayerPrefs.SetInt("lvl2", lvlcomplete2);
        PlayerPrefs.SetInt("lvl3", lvlcomplete3);
        PlayerPrefs.SetInt("lvl4", lvlcomplete4);
        PlayerPrefs.SetInt("lvl5", lvlcomplete5);
        PlayerPrefs.SetInt("lvl6", lvlcomplete6);
    }
    public void mainmenu()
    {
        SceneManager.LoadScene(12);
    }
    public void lvl11()
    {
        SceneManager.LoadScene(4);
    }
    public void lvl22()
    {
        SceneManager.LoadScene(5);
    }
    public void lvl33()
    {
        SceneManager.LoadScene(6);
    }
    public void lvl44()
    {
        SceneManager.LoadScene(7);
    }
    public void lvl55()
    {
        SceneManager.LoadScene(8);
    }
    public void lvl66()
    {
        SceneManager.LoadScene(9);
    }
}
