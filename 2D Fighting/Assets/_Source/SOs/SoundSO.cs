using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "SoundSO", menuName = "SO/SoundSO", order = 0)]
    public class SoundSO : ScriptableObject
    {
        [SerializeField] private AudioClip _playerAttack;

        public AudioClip PlayerAttack { get => _playerAttack; private set { } }
    }
}