using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    public static MusicPlayer instance = null;

    public AudioClip startClip, gameClip, endClip;

    private AudioSource music;

    // Use this for initialization
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            print("Duplicate music player destroyed");
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
            music = GetComponent<AudioSource>();
            music.clip = startClip;
            music.loop = true;
            music.Play();
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        Debug.Log("MusicPlayer.OnLevelWasLoaded:    " + level);
        music.Stop();
        switch (level)
        {
            case 0: music.clip = startClip; break;
            case 1: music.clip = gameClip; break;
            case 2: music.clip = endClip; break;
            case 3: music.clip = endClip; break;
        }
        music.loop = true;
        music.Play();
    }

}
