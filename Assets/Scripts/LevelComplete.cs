using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public int lvl;
    public int lvlcomplete1;
    public int lvlcomplete2;
    public int lvlcomplete3;
    public int lvlcomplete4;
    public int lvlcomplete5;
    public int lvlcomplete6;
    // Start is called before the first frame update
    void Start()
    {
        lvlcomplete1 = PlayerPrefs.GetInt("lvl1");
        lvlcomplete2 = PlayerPrefs.GetInt("lvl2");
        lvlcomplete3 = PlayerPrefs.GetInt("lvl3");
        lvlcomplete4 = PlayerPrefs.GetInt("lvl4");
        lvlcomplete5 = PlayerPrefs.GetInt("lvl5");
        lvlcomplete6 = PlayerPrefs.GetInt("lvl6");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (lvl == 1)
            lvlcomplete1 = 1;
        if (lvl == 2)
            lvlcomplete2 = 1;
        if (lvl == 3)
            lvlcomplete3 = 1;
        if (lvl == 4)
            lvlcomplete4 = 1;
        if (lvl == 5)
            lvlcomplete5 = 1;
        if (lvl == 6)
            lvlcomplete6 = 1;
        PlayerPrefs.SetInt("lvl1", lvlcomplete1);
        PlayerPrefs.SetInt("lvl2", lvlcomplete2);
        PlayerPrefs.SetInt("lvl3", lvlcomplete3);
        PlayerPrefs.SetInt("lvl4", lvlcomplete4);
        PlayerPrefs.SetInt("lvl5", lvlcomplete5);
        PlayerPrefs.SetInt("lvl6", lvlcomplete6);
        SceneManager.LoadScene(3);
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
}
