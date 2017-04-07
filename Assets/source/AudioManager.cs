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

        public void FadeMusicOut()
        {
            StartCoroutine(FadeMusicOutRoutine());
        }

        private IEnumerator FadeMusicOutRoutine()
        {
            float timer = 1;
            float originalVolume = musicPlayer.volume;
            while (timer > 0)
            {
                timer -= Time.deltaTime;
                musicPlayer.volume = Mathf.Lerp(originalVolume, 0, timer);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}