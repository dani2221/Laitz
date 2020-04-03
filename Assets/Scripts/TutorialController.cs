using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour
{
    // Start is called before the first frame update
    Text tutorialtext;
    string message= "Welcome \n to \n Laitz";
    float time = 3f;
    int dialognum = 0;
    int k = 0;
    int p = 0;
    int s = 0;
    int v = 0;

    public GameObject normal;
    public GameObject spin;
    public GameObject dissapear;
    public GameObject move;
    public GameObject startblock;
    void Start()
    {
        tutorialtext = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PlayerController.instance.transform.position.y < startblock.transform.position.y)
            PlayerController.instance.transform.position = new Vector2(0, startblock.transform.position.y + 2.5f);
        tutorialtext.text = message;
        time -= Time.deltaTime;
        if(time<0 && dialognum==0)
        {
            time = 3f;
            dialognum++;
            message = "Press on the left side of the screen to jump left";
            tutorialtext.color = Color.green;
        }
        if(Input.GetMouseButtonDown(0))
        {
            if (dialognum == 1 && Input.mousePosition.x < Screen.width * 0.5f)
            {
                message = "Press on the right side of the screen to jump right";
                dialognum++;
                tutorialtext.color = Color.cyan;
            }
            if (dialognum == 2 && Input.mousePosition.x >= Screen.width * 0.5f)
            {
                message = "Try double jumping now!";
                dialognum++;
                tutorialtext.color = Color.white;
            }
        }
        if (dialognum == 3 && PlayerController.instance.jumps == 0 && k==0)
        {
            message = "Good job \n This is a normal sticky block. Try to jump on it!";
            Instantiate(normal, new Vector2(-1, -1), Quaternion.identity);
            dialognum++;
            k++;
            time = 3f;
        }
        if (dialognum == 4 && PlayerController.instance.jumps == 2 && PlayerController.instance.transform.position.y > -1.5f && p==0 && time<0)
        {
            message = "How about this rotating block?";
            Instantiate(spin, new Vector2(1, 1.5f), Quaternion.identity);
            dialognum++;
            p++;
            time = 3f;
        }
        if (dialognum == 5 && PlayerController.instance.jumps == 2 && PlayerController.instance.transform.position.y > 1f && s == 0 && time < 0)
        {
            message = "Don't stay more than 2s on the next block because it is a dissapearing block!";
            Instantiate(dissapear, new Vector2(-1, 4), Quaternion.identity);
            dialognum++;
            s++;
            time = 3f;
        }
        if (dialognum == 6 && PlayerController.instance.jumps == 2 && PlayerController.instance.transform.position.y > 3.5f && v == 0 && time < 0)
        {
            message = "This is a moving block \n It moves left and right but also can be unpredictable..";
            Instantiate(move, new Vector2(1, 6.5f), Quaternion.identity);
            dialognum++;
            v++;
            time = 3f;
        }
        if(dialognum==7 && time<0)
        {
            dialognum++;
            message = "GOODLUCK";
            time = 3f;
        }
        if(dialognum==8 && time<0)
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("tutorial", 1);
            SceneManager.LoadScene(2);
        }

    }
    public void skip_CLICKED()
    {
        SceneManager.LoadScene(2);
    }
}
