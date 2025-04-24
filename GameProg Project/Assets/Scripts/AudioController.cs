using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource backGroundMusic;
    public AudioSource deathSFX;

    public bool levelSong = false;
    public bool deathMusic = false;

    public void LevelMusic()
    {
        levelSong = false;
        deathMusic = false;
        backGroundMusic.Play();
    }

    public void DeathSound()
    {
        if(backGroundMusic.isPlaying)  
        {
            levelSong = false;
            backGroundMusic.Stop();
        }
        if(!deathSFX.isPlaying && deathMusic == false)
        {
            deathSFX.Play();
            deathMusic = true;
        }
    }
}
