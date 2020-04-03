using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource soundtrack;
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        soundtrack = GetComponent<AudioSource>();

        //soundtrack.Play();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] game = GameObject.FindGameObjectsWithTag("Music");
        if (game.Length > 1)
            Destroy(game[1]);
    }
}
