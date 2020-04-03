using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingController : MonoBehaviour
{
    public Button Graphics_GOOD;
    public Button Graphics_BEST;
    public Button Audio_MUSIC;
    public Button Audio_Effects;
    int graphics;
    int music;
    int effects;
    void Start()
    {
        graphics = PlayerPrefs.GetInt("graphics");   
        music = PlayerPrefs.GetInt("music");   
        effects = PlayerPrefs.GetInt("effects");
        if(graphics==1)
        {
            Graphics_BEST.GetComponent<Image>().color = Color.yellow;
            Graphics_GOOD.GetComponent<Image>().color = new Color(103f / 255, 103f / 255, 79f / 255);
        }
        else
        {
            Graphics_GOOD.GetComponent<Image>().color = Color.yellow;
            Graphics_BEST.GetComponent<Image>().color = new Color(103f / 255, 103f / 255, 79f / 255);
        }
        if(music==1)
        {
            Audio_MUSIC.GetComponent<Image>().color = new Color(103f / 255, 103f / 255, 79f / 255);
        }
        else
        {
            Audio_MUSIC.GetComponent<Image>().color = Color.yellow;
        }
        if (effects == 1)
        {
            Audio_Effects.GetComponent<Image>().color = new Color(103f / 255, 103f / 255, 79f / 255);
        }
        else
        {
            Audio_Effects.GetComponent<Image>().color = Color.yellow;
        }
    }
    public void good_CLICKED()
    {
        Graphics_GOOD.GetComponent<Image>().color = Color.yellow;
        Graphics_BEST.GetComponent<Image>().color = new Color(103f/255, 103f/255, 79f/255);
        PlayerPrefs.SetInt("graphics", 0);
    } 
    public void best_CLICKED()
    {
        Graphics_BEST.GetComponent<Image>().color = Color.yellow;
        Graphics_GOOD.GetComponent<Image>().color = new Color(103f/255, 103f/255, 79f/255);
        PlayerPrefs.SetInt("graphics", 1);
    }
    public void effects_CLICKED()
    {
        if(Audio_Effects.GetComponent<Image>().color==Color.yellow)
        {
            Audio_Effects.GetComponent<Image>().color = new Color(103f / 255, 103f / 255, 79f / 255);
            PlayerPrefs.SetInt("effects", 1);
            effects = 1;
        }
        else
        {
            Audio_Effects.GetComponent<Image>().color = Color.yellow;
            PlayerPrefs.SetInt("effects", 0);
            effects = 0;
        }
    }
    public void music_CLICKED()
    {
        if(Audio_MUSIC.GetComponent<Image>().color == Color.yellow)
        {
            Audio_MUSIC.GetComponent<Image>().color = new Color(103f / 255, 103f / 255, 79f / 255);
            PlayerPrefs.SetInt("music", 1);
            music =1;
        }
        else
        {
            Audio_MUSIC.GetComponent<Image>().color = Color.yellow;
            PlayerPrefs.SetInt("music", 0);
            music = 0;
        }
    }
    public void BackButton()
    {
        SceneManager.LoadScene(1);
    }
}
