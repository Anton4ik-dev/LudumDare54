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
        private AudioSource _fireballEnemyAudioSource;
        private AudioSource _fireballAudioSource;
        public SoundSO SoundSo;

        public static SoundSingleton Instance { get; private set; }

        [Inject]
        public SoundSingleton([Inject(Id = BindId.PLAYER)] AudioSource playerAudioSource,
            [Inject(Id = BindId.ENEMY)] AudioSource enemyAudioSource,
            [Inject(Id = BindId.ENEMY_ATTACK_STATE)] AudioSource fireballEnemyAudioSource,
            [Inject(Id = BindId.ATTACK_STATE)] AudioSource fireballAudioSource,
            SoundSO soundSo)
        {
            _playerAudioSource = playerAudioSource;
            _enemyAudioSource = enemyAudioSource;
            _fireballEnemyAudioSource = fireballEnemyAudioSource;
            _fireballAudioSource = fireballAudioSource;
            SoundSo = soundSo;
            Instance = this;
        }

        public void PlayOneShotPlayer(AudioClip clip) => _playerAudioSource.PlayOneShot(clip);
        public void PlayOneShotEnemy(AudioClip clip) => _enemyAudioSource.PlayOneShot(clip);
        public void PlayOneShotFireballEnemy(AudioClip clip) => _fireballEnemyAudioSource.PlayOneShot(clip);
        public void PlayOneShotFireballPlayer(AudioClip clip) => _fireballAudioSource.PlayOneShot(clip);
    }
}
