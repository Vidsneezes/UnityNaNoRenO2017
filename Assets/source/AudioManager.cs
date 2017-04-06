using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SwiperEngine
{
    public class AudioManager : MonoBehaviour
    {
        public AudioListener _audioListen;
        public AudioSource musicPlayer;

        private void Start()
        {
            GameState.instance.audioManager = this;
        }

        public void PlayClip(AudioClip clip)
        {
            musicPlayer.clip = clip;
            musicPlayer.Play();
        }
    }
}