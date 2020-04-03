using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagerr : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource au;
    void Start()
    {
        
        int p = PlayerPrefs.GetInt("tutorial");
        if(p==1)
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        else
            UnityEngine.SceneManagement.SceneManager.LoadScene(11);
        if (PlayerPrefs.GetInt("music") == 1)
            au.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
