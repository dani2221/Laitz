using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public ParticleSystem[] particle;
    public Text money;
    public Button unlockButton;
    int kesh;
    public int numOfParticle;
    public Text unlocktext;
    int lvlcomplete1;
    int lvlcomplete2;
    int lvlcomplete3;
    int lvlcomplete4;
    int lvlcomplete5;
    int lvlcomplete6;
    int isunlocked1;
    int isunlocked2;
    int isunlocked3;
    int isunlocked4;
    private BannerView bannerView;
    public string BannerID;
    // Start is called before the first frame update
    void Start()
    {

        this.RequestBanner();

        kesh = PlayerPrefs.GetInt("money");
        isunlocked1 = PlayerPrefs.GetInt("1");
        isunlocked2 = PlayerPrefs.GetInt("2");
        isunlocked3 = PlayerPrefs.GetInt("3");
        isunlocked4 = PlayerPrefs.GetInt("4");
        lvlcomplete1 = PlayerPrefs.GetInt("lvl1");
        lvlcomplete2 = PlayerPrefs.GetInt("lvl2");
        lvlcomplete3 = PlayerPrefs.GetInt("lvl3");
        lvlcomplete4 = PlayerPrefs.GetInt("lvl4");
        lvlcomplete5 = PlayerPrefs.GetInt("lvl5");
        lvlcomplete6 = PlayerPrefs.GetInt("lvl6");
        numOfParticle = PlayerPrefs.GetInt("particle");
        money.text = "$" + kesh.ToString();
        for (int i = 0; i < particle.Length; i++)
        {
            particle[i].Stop();
            particle[i].maxParticles = 1000;
        }
        if(numOfParticle<11 && numOfParticle>0)
            particle[numOfParticle - 1].Play();     
    }

    private void RequestBanner()
    {
        this.bannerView = new BannerView(BannerID, AdSize.SmartBanner, AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder().Build();
        this.bannerView.LoadAd(request);
        this.bannerView.Show();
    }
   

    // Update is called once per frame
    void Update()
    {
            
        if (numOfParticle == 0)
            unlocktext.text = "No particle";
        if (numOfParticle == 1 && isunlocked1 == 1)
            unlocktext.text = "Unlocked";
        else if (numOfParticle == 1)
            unlocktext.text = "50$ to unlock";
        if (numOfParticle == 2 && isunlocked2 == 1)
            unlocktext.text = "Unlocked";
        else if (numOfParticle == 2)
            unlocktext.text = "300$ to unlock";
        if (numOfParticle == 3 && isunlocked3 == 1)
            unlocktext.text = "Unlocked";
        else if (numOfParticle == 3)
            unlocktext.text = "1000$ to unlock";
        if (numOfParticle == 4 && isunlocked4 == 1)
            unlocktext.text = "Unlocked";
        else if (numOfParticle == 4)
            unlocktext.text = "5000$ to unlock";

        if (numOfParticle == 5 && lvlcomplete1 == 1)
            unlocktext.text = "Unlocked";
        else if (numOfParticle == 5)
            unlocktext.text = "Finish expert level 1 \n to Unlock";
        if (numOfParticle == 6 && lvlcomplete2 == 1)
            unlocktext.text = "Unlocked";
        else if (numOfParticle == 6)
            unlocktext.text = "Finish expert level 2 \n to Unlock";
        if (numOfParticle == 7 && lvlcomplete3 == 1)
            unlocktext.text = "Unlocked";
        else if (numOfParticle == 7)
            unlocktext.text = "Finish expert level 3 \n to Unlock";
        if (numOfParticle == 8 && lvlcomplete4 == 1)
            unlocktext.text = "Unlocked";
        else if (numOfParticle == 8)
            unlocktext.text = "Finish expert level 4 \n to Unlock";
        if (numOfParticle == 9 && lvlcomplete5 == 1)
            unlocktext.text = "Unlocked";
        else if (numOfParticle == 9)
            unlocktext.text = "Finish expert level 5 \n to Unlock";
        if (numOfParticle == 10 && lvlcomplete6 == 1)
            unlocktext.text = "Unlocked";
        else if(numOfParticle == 10)
            unlocktext.text = "Finish expert level 6 \n to Unlock";
    }
    public void clickright()
    {
        if (numOfParticle < 10)
        {
            for (int i = 0; i < particle.Length; i++)
            {
                particle[i].Stop();
                particle[i].maxParticles = 1000;
            }
            numOfParticle++;
            if(numOfParticle<11 && numOfParticle > 0)
                particle[numOfParticle - 1].Play();
        }
    }
    public void clickleft()
    {
        if (numOfParticle > 0)
        {
            for (int i = 0; i < particle.Length; i++)
            {
                particle[i].Stop();
                particle[i].maxParticles = 1000;
            }
            numOfParticle--;
            if(numOfParticle<11 && numOfParticle > 0)
                particle[numOfParticle - 1].Play();
        }
    }
    public void gotomenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
    private void OnDisable()
    {
        this.bannerView.Hide();

        if (numOfParticle == 10 && lvlcomplete6 == 0)
            numOfParticle--;
        else if(lvlcomplete6==1)
                PlayerPrefs.SetInt("particle", numOfParticle);
        if (numOfParticle == 9 && lvlcomplete5 == 0)
            numOfParticle--;
        else if (lvlcomplete5 == 1)
                PlayerPrefs.SetInt("particle", numOfParticle);
        if (numOfParticle == 8 && lvlcomplete4 == 0)
            numOfParticle--;
        else if (lvlcomplete4 == 1)
                PlayerPrefs.SetInt("particle", numOfParticle);
        if (numOfParticle == 7 && lvlcomplete3 == 0)
            numOfParticle--;
        else if (lvlcomplete3 == 1)
                PlayerPrefs.SetInt("particle", numOfParticle);
        if (numOfParticle == 6 && lvlcomplete2 == 0)
            numOfParticle--;
        else if (lvlcomplete2 == 1)
                PlayerPrefs.SetInt("particle", numOfParticle);
        if (numOfParticle == 5 && lvlcomplete1 == 0)
            numOfParticle--;
        else if(lvlcomplete1 == 1)
                PlayerPrefs.SetInt("particle", numOfParticle);
        if (numOfParticle == 4 && isunlocked4 == 0)
            numOfParticle--;
        else if (isunlocked4 == 1)
            PlayerPrefs.SetInt("particle", numOfParticle);
        if (numOfParticle == 3 && isunlocked3 == 0)
            numOfParticle--;
        else if (isunlocked3 == 1)
            PlayerPrefs.SetInt("particle", numOfParticle);
        if (numOfParticle == 2 && isunlocked2 == 0)
            numOfParticle--;
        else if (isunlocked2 == 1)
            PlayerPrefs.SetInt("particle", numOfParticle);
        if (numOfParticle == 1 && isunlocked1 == 0)
            numOfParticle--;
        else if (isunlocked1 == 1)
            PlayerPrefs.SetInt("particle", numOfParticle);
        PlayerPrefs.SetInt("1", isunlocked1);
        PlayerPrefs.SetInt("2", isunlocked2);
        PlayerPrefs.SetInt("3", isunlocked3);
        PlayerPrefs.SetInt("4", isunlocked4);
        PlayerPrefs.SetInt("money", kesh);
    }
    public void pressUnlock()
    {
        if (numOfParticle == 1 && kesh >= 50 && isunlocked1 == 0)
        {
            isunlocked1 = 1;
            kesh -= 50;
        }
        if (numOfParticle == 2 && kesh >= 300 && isunlocked2 == 0)
        {
            isunlocked2 = 1;
            kesh -= 300;
        }
        if (numOfParticle == 3 && kesh >= 1000 && isunlocked3 == 0)
        {
            isunlocked3 = 1;
            kesh -= 1000;
        }
        if (numOfParticle == 4 && kesh >= 5000 && isunlocked4 == 0)
        {
            isunlocked4 = 1;
            kesh -= 5000;
        }
        money.text = "$" + kesh.ToString();
    }
}
