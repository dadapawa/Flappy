using System;
using Script.Events;
using UnityEngine;

namespace Game
{
    public class ScoreUpSound : MonoBehaviour
    {
        [SerializeField] private AudioClip audioClip;

        private ScoreEventChannel scoreEventChannel;
        private AudioSource audioSource;

        private void Awake()
        {
            scoreEventChannel = Finder.ScoreEventChannel;
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        private void OnEnable() 
        {
            scoreEventChannel.OnScoreEvent += PlayScoreSound;
        }
        private void OnDisable()
        {
            scoreEventChannel.OnScoreEvent -= PlayScoreSound;
        }

        private void PlayScoreSound()
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
}