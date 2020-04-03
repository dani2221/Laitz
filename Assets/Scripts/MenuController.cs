using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public Button endless;
    public Text HS;
    public Text HSLAVA;
    public Text coinss;
    float highscore = 0f;
    float hstime;
    int coins = 0;
    void Start()
    {
        try
        {
            coins = PlayerPrefs.GetInt("money");
            coinss.text = coins.ToString() + "$";
            highscore = PlayerPrefs.GetFloat("highscore");
            hstime = PlayerPrefs.GetFloat("highscoretime");
            HS.text = "Highscore:" + highscore.ToString("F2") + "m";
            HSLAVA.text = "Highscore: " + hstime.ToString("F2") + "m";
        }
        catch { }

        MobileAds.Initialize(InitializationStatus => { });
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.instance.transform.position.y < -20f)
        {
            PlayerController.instance.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            PlayerController.instance.transform.position = new Vector2(-0.12f, 7);
        }
    }
    public void gotoEndless()
    {
        SceneManager.LoadScene(2);
    }
    public void expert()
    {
        SceneManager.LoadScene(3);
    }
    public void shopp()
    {
        SceneManager.LoadScene(10);
    }
    public void back()
    {
        SceneManager.LoadScene(1);
    }
    public void play()
    {
        SceneManager.LoadScene(12);
    }
    public void playtime()
    {
        SceneManager.LoadScene(15);
    }
    public void rewards()
    {
        SceneManager.LoadScene(16);
    }
    public void options()
    {
        SceneManager.LoadScene(16);
    }
}
