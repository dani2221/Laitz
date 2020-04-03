using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelController : MonoBehaviour
{
    public Image progress;
    List<Text> inst;
    public Text Level;
    public Text levelReward;
    public RectTransform parentCanvas;
    float step = 2.2f;
    Text[] levels = new Text[100];
    Text[] levelRewards = new Text[100];
    public Image small;
    float points;
    int unclaimed;
    int currentI;
    int currentlevel;
    void Start()
    {
        inst = new List<Text>();
        points = PlayerPrefs.GetFloat("points");
        unclaimed = PlayerPrefs.GetInt("unclaimed");
        currentlevel = PlayerPrefs.GetInt("currentlevel");
        float pointz = PlayerPrefs.GetFloat("pointz");
        
        small.rectTransform.sizeDelta = new Vector2(100,1+currentlevel*2.2f+2.2f*pointz);
        parentCanvas.sizeDelta = new Vector2(800, Screen.height * 100 / 3);
        parentCanvas.localPosition = new Vector2(0, Screen.height * 100 / 6);
        for (int i = 0; i < levels.Length; i++)
        { 
            levels[i] = Level;
            levelRewards[i] = levelReward;
            levels[i].text = "Level " + (i + 1).ToString();
            levelRewards[i].text = "+"+(i*2+1)+"$";
            if ((i+1)%5==0)
                levelRewards[i].text = "+1 Boost";
            if ((i + 1) % 10 == 0)
                levelRewards[i].text = "+1 Jump distance";


            if (i * step + 1 > small.rectTransform.rect.height && i != 0)
            {
                levels[i].color = Color.gray;
                levelRewards[i].color = Color.gray;
            }
            else
            {
                levels[i].color = Color.white;
                levelRewards[i].color = Color.cyan;
            }
            setUnclaimed(i);
            Text mi =Instantiate(levels[i], new Vector2(Screen.width/2,(i+2)*Screen.height/3), Quaternion.identity,parentCanvas);
            inst.Add(mi);
            Instantiate(levelRewards[i], Vector2.zero, Quaternion.identity, mi.transform);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void claimRewards()
    {
        for (int i = 0; i < inst.Count; i++)
        {
            if (inst[i].color == Color.yellow)
            {
                inst[i].color = Color.white;
                if((i + 1) % 10 == 0)
                    PlayerPrefs.SetInt("distance", PlayerPrefs.GetInt("distance") + 1);
                else if ((i + 1) % 5 == 0)
                    PlayerPrefs.SetInt("boost", PlayerPrefs.GetInt("boost") + 1);
                else
                    PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + (i * 2 + 1));
            }
        }
        unclaimed = currentlevel;
        PlayerPrefs.SetInt("unclaimed", unclaimed);


    }
    public bool checkUnclaimed(int i)
    {
        bool p;
        if (levels[i].color == Color.white && unclaimed < i)
        {
            p = true;
            currentI = i;
        }
        else
            p = false;
        return p;
    }
    public void setUnclaimed(int i)
    {
        bool p = checkUnclaimed(i);
        if(p)
            levels[i].color = Color.yellow;
    }
    public void gotoMenu()
    {
        SceneManager.LoadScene(1);
    }
}
