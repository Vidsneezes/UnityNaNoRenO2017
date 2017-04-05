using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioListener _audioListen;
    public AudioSource musicPlayer;

    public void PlayClip(AudioClip clip)
    {
        musicPlayer.clip = clip;
        musicPlayer.Play();
    }
}
