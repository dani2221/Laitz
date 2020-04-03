using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;
using System;

public class DieController : MonoBehaviour
{
    public StaticController statik;
    bool restart = false;
    public float adTime;
    private float timeStart = 6;
    public Text continueText;
    public Text child;
    public bool isEndless;
    public string adCode;
    float maxScore;
    public Button watchAD;
    int currentLevel;
    public Text crrnt;
    public Text crrnt1;
    float pointz;
    float pointzadded;
    public Image progress;
    public Text plusCoins;
    int plcoins = 0;
    private void Start()
    {
        maxScore = PlayerPrefs.GetFloat("maxScore");
        currentLevel = PlayerPrefs.GetInt("currentlevel");
        pointz = PlayerPrefs.GetFloat("pointz");
        int jas = currentLevel + 1;
        crrnt.text = jas.ToString();
        crrnt1.text = (jas + 1).ToString();
        pointzadded = maxScore / (7 * (currentLevel + 1));
        progress.transform.localScale = new Vector2(pointz, 1);
        PlayerPrefs.SetFloat("points", PlayerPrefs.GetFloat("points") + pointzadded * 2.2f);

        PlayerPrefs.SetInt("revive", 0);



        Debug.Log(currentLevel.ToString());
    }

    public void UserChoseToWatchAd()
    {
        DontDestroyAD.instance.showAD();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if(DontDestroyAD.instance.restart)
        {
            if (isEndless)
                SceneManager.LoadScene(2);
            else
                SceneManager.LoadScene(15);
            PlayerPrefs.SetInt("revive", 1);
            DontDestroyAD.instance.restart = false;
        }
        if (adTime>0 && PlayerPrefs.GetInt("usedRevive")==0)
        {
            try
            {
                statik.transform.localScale = new Vector2((adTime) / 6, (adTime) / 6);
            }
            catch { }
            adTime -= Time.deltaTime;
        }
        else
        {
            statik.transform.position = new Vector2(-20, -20);
            statik.transform.localScale = new Vector2(0.001f, 0.001f);
            Destroy(continueText);
            Destroy(child);
            Destroy(watchAD);
            PlayerPrefs.SetInt("usedRevive", 0);
        }
        if(pointz<=pointzadded)
        {
            progress.transform.localScale  =new Vector2(progress.transform.localScale.x+0.05f,1);
            pointz += 0.05f;
            if (progress.transform.localScale.x>1)
            {
                progress.transform.localScale = new Vector2(0, 1);
                pointz = 0;
                pointzadded -= 1;
                currentLevel++;
                plcoins += 5;
                plusCoins.text = "+" + plcoins + "$";
                updateLevels();
                
            }
        }

    }
    public void playagain()
    {
        PlayerPrefs.SetInt("currentlevel", currentLevel);
        PlayerPrefs.SetFloat("pointz", pointz);
        if (isEndless == true)
            SceneManager.LoadScene(2);
        else
            SceneManager.LoadScene(15);
    }
    public void menu()
    {
        SceneManager.LoadScene(1);
    }
    private void OnDisable()
    {
        PlayerPrefs.SetInt("currentlevel", currentLevel);
        PlayerPrefs.SetFloat("pointz", pointz);
        PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + plcoins);
    }
    private void updateLevels()
    {
        crrnt.text = (currentLevel+1).ToString();
        int jas = currentLevel + 2;
        crrnt1.text = jas.ToString();
    }


}
