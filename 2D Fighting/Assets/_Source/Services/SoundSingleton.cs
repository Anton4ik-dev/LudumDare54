using Core;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace SoundSystem
{
    public class SoundSingleton
    {
        private AudioSource _playerAudioSource;
        private AudioSource _enemyAudioSource;
        public SoundSO SoundSo;

        public static SoundSingleton Instance { get; private set; }

        [Inject]
        public SoundSingleton([Inject(Id = BindId.PLAYER)] AudioSource playerAudioSource, [Inject(Id = BindId.ENEMY)] AudioSource enemyAudioSource, SoundSO soundSo)
        {
            _playerAudioSource = playerAudioSource;
            _enemyAudioSource = enemyAudioSource;
            SoundSo = soundSo;
            Instance = this;
        }

        public void PlayOneShotPlayer(AudioClip clip) => _playerAudioSource.PlayOneShot(clip);
        public void PlayOneShotEnemy(AudioClip clip) => _enemyAudioSource.PlayOneShot(clip);
    }
}
