using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "SoundSO", menuName = "SO/SoundSO", order = 0)]
    public class SoundSO : ScriptableObject
    {
        [Header("PLAYER")]
        public AudioClip PlayerAttack;
        public AudioClip PlayerQ;
        public AudioClip PlayerW;
        public AudioClip PlayerE;
        public AudioClip PlayerR;
        public AudioClip PlayerFinale;
        [Space]
        [Header("ENEMY")]
        public AudioClip EnemyHello;
        public AudioClip EnemyAttack;
        public AudioClip EnemySpicial;
        public AudioClip EnemyWeb;
        public AudioClip EnemyStun;
        public AudioClip EnemyUlt;
    }
}