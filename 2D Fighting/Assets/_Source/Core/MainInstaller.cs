using ScriptableObjects;
using SoundSystem;
using StateSystem;
using UISystem;
using UnityEngine;
using Zenject;

namespace Core
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private AudioSource _playerAudioSource;
        [SerializeField] private AudioSource _enemyAudioSource;
        [SerializeField] private SoundSO _soundSo;
        
        [SerializeField] private Animator _playerAnimator;
        [SerializeField] private Animator _enemyAnimator;

        [SerializeField] private Game _game;

        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private EnemyHealth _enemyHealth;

        [SerializeField] private EnemyIconsView _enemyIconsView;

        [Header("Player Float")]
        [SerializeField] private float _playerAttackTime;
        [SerializeField] private float _playerQTime;
        [SerializeField] private float _playerWTime;
        [SerializeField] private float _playerETime;
        [SerializeField] private float _playerRTime;

        [Header("Player Int")]
        [SerializeField] private int _playerAttackDamage;
        [SerializeField] private int _playerQDamage;
        [SerializeField] private int _playerWDecreasePercentage;
        [SerializeField] private int _playerEStunTime;
        [SerializeField] private int _playerRStunDuration;

        [Header("Enemy Float")]
        [SerializeField] private float _enemyAttackTime;
        [SerializeField] private float _enemySpecialTime;
        [SerializeField] private float _enemyWebTime;
        [SerializeField] private float _enemyUltTime;

        [Header("Enemy Int")]
        [SerializeField] private int _enemyAttackDamage;
        [SerializeField] private int _enemySpecialDamage;
        [SerializeField] private int _enemyWebDuration;
        [SerializeField] private int _enemyUltStunDuration;

        public override void InstallBindings()
        {
            #region PlayerVariables
            Container.Bind<Animator>()
                .WithId(BindId.PLAYER)
                .FromInstance(_playerAnimator)
                .NonLazy();

            Container.Bind<PlayerHealth>()
                .FromInstance(_playerHealth)
                .AsSingle()
                .NonLazy();

            Container.Bind<float>()
                .WithId(BindId.ATTACK_STATE)
                .FromInstance(_playerAttackTime)
                .NonLazy();

            Container.Bind<float>()
                .WithId(BindId.Q_STATE)
                .FromInstance(_playerQTime)
                .NonLazy();

            Container.Bind<float>()
                .WithId(BindId.W_STATE)
                .FromInstance(_playerWTime)
                .NonLazy();

            Container.Bind<float>()
                .WithId(BindId.E_STATE)
                .FromInstance(_playerETime)
                .NonLazy();

            Container.Bind<float>()
                .WithId(BindId.R_STATE)
                .FromInstance(_playerRTime)
                .NonLazy();

            Container.Bind<int>()
                .WithId(BindId.ATTACK_STATE)
                .FromInstance(_playerAttackDamage)
                .NonLazy();

            Container.Bind<int>()
                .WithId(BindId.Q_STATE)
                .FromInstance(_playerQDamage)
                .NonLazy();

            Container.Bind<int>()
                .WithId(BindId.W_STATE)
                .FromInstance(_playerWDecreasePercentage)
                .NonLazy();

            Container.Bind<int>()
                .WithId(BindId.E_STATE)
                .FromInstance(_playerEStunTime)
                .NonLazy();

            Container.Bind<int>()
                .WithId(BindId.R_STATE)
                .FromInstance(_playerRStunDuration)
                .NonLazy();
            #endregion
            #region EnemyVariables
            Container.Bind<Animator>()
                .WithId(BindId.ENEMY)
                .FromInstance(_enemyAnimator)
                .NonLazy();
            
            Container.Bind<Game>()
                 .FromInstance(_game)
                 .AsSingle()
                 .NonLazy();

            Container.Bind<EnemyHealth>()
                .FromInstance(_enemyHealth)
                .AsSingle()
                .NonLazy();

            Container.Bind<EnemyIconsView>()
                .FromInstance(_enemyIconsView)
                .AsSingle()
                .NonLazy();

            Container.Bind<float>()
                .WithId(BindId.ENEMY_ATTACK_STATE)
                .FromInstance(_enemyAttackTime)
                .NonLazy();

            Container.Bind<float>()
                .WithId(BindId.ENEMY_SPECIAL_STATE)
                .FromInstance(_enemySpecialTime)
                .NonLazy();

            Container.Bind<float>()
                .WithId(BindId.ENEMY_WEB_STATE)
                .FromInstance(_enemyWebTime)
                .NonLazy();

            Container.Bind<float>()
                .WithId(BindId.ENEMY_ULT_STATE)
                .FromInstance(_enemyUltTime)
                .NonLazy();

            Container.Bind<int>()
                .WithId(BindId.ENEMY_ATTACK_STATE)
                .FromInstance(_enemyAttackDamage)
                .NonLazy();

            Container.Bind<int>()
                .WithId(BindId.ENEMY_SPECIAL_STATE)
                .FromInstance(_enemySpecialDamage)
                .NonLazy();

            Container.Bind<int>()
                .WithId(BindId.ENEMY_WEB_STATE)
                .FromInstance(_enemyWebDuration)
                .NonLazy();

            Container.Bind<int>()
                .WithId(BindId.ENEMY_ULT_STATE)
                .FromInstance(_enemyUltStunDuration)
                .NonLazy();
            #endregion
            #region PlayerStates
            Container.Bind<AState>()
                .WithId(BindId.ATTACK_STATE)
                .To<AttackState>()
                .AsSingle()
                .NonLazy();

            Container.Bind<AState>()
                .WithId(BindId.Q_STATE)
                .To<QState>()
                .AsSingle()
                .NonLazy();

            Container.Bind<AState>()
                .WithId(BindId.W_STATE)
                .To<WState>()
                .AsSingle()
                .NonLazy();

            Container.Bind<AState>()
                .WithId(BindId.E_STATE)
                .To<EState>()
                .AsSingle()
                .NonLazy();

            Container.Bind<AState>()
                .WithId(BindId.R_STATE)
                .To<RState>()
                .AsSingle()
                .NonLazy();

            Container.Bind<AState>()
                .WithId(BindId.STUN_STATE)
                .To<StunState>()
                .AsSingle()
                .NonLazy();
            #endregion
            #region EnemyStates
            Container.Bind<AState>()
                .WithId(BindId.ENEMY_ATTACK_STATE)
                .To<EnemyAttackState>()
                .AsSingle()
                .NonLazy();

            Container.Bind<AState>()
                .WithId(BindId.ENEMY_STUN_STATE)
                .To<EnemyStunState>()
                .AsSingle()
                .NonLazy();

            Container.Bind<AState>()
                .WithId(BindId.ENEMY_SPECIAL_STATE)
                .To<EnemySpecialState>()
                .AsSingle()
                .NonLazy();

            Container.Bind<AState>()
                .WithId(BindId.ENEMY_WEB_STATE)
                .To<EnemyWebState>()
                .AsSingle()
                .NonLazy();

            Container.Bind<AState>()
                .WithId(BindId.ENEMY_ULT_STATE)
                .To<EnemyUltState>()
                .AsSingle()
                .NonLazy();
            #endregion
            #region StateMachines
            Container.Bind<IStateMachine>()
                .WithId(BindId.PLAYER)
                .To<PlayerStateMachine>()
                .AsSingle()
                .NonLazy();

            Container.Bind<IStateMachine>()
                .WithId(BindId.ENEMY)
                .To<EnemyStateMachine>()
                .AsSingle()
                .NonLazy();

            Container.Bind<AudioSource>()
                .WithId(BindId.PLAYER)
                .FromInstance(_playerAudioSource)
                .NonLazy();

            Container.Bind<AudioSource>()
                .WithId(BindId.ENEMY)
                .FromInstance(_enemyAudioSource)
                .NonLazy();

            Container.Bind<SoundSO>()
                .FromInstance(_soundSo)
                .AsSingle()
                .NonLazy();

            Container.Bind<SoundSingleton>()
                .AsSingle()
                .NonLazy();
            #endregion
        }
    }

    public static class BindId
    {
        public const int PLAYER = 0;
        public const int ENEMY = 1;

        public const int ATTACK_STATE = 2;
        public const int Q_STATE = 3;
        public const int W_STATE = 4;
        public const int E_STATE = 5;
        public const int R_STATE = 6;
        public const int STUN_STATE = 7;

        public const int ENEMY_ULT_STATE = 8;
        public const int ENEMY_ATTACK_STATE = 9;
        public const int ENEMY_STUN_STATE = 10;
        public const int ENEMY_SPECIAL_STATE = 11;
        public const int ENEMY_WEB_STATE = 12;
    }
}
