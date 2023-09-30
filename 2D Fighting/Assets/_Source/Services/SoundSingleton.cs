using ScriptableObjects;
using UnityEngine;

namespace SoundSystem
{
    public class SoundSingleton : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        public SoundSO SoundSo;

        public static SoundSingleton Instance { get; private set; } = null;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);
        }

        public void PlayOneShot(AudioClip clip) => _audioSource.PlayOneShot(clip);
    }
}
