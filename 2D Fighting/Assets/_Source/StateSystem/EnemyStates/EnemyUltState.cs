using Core;
using UISystem;
using UnityEngine;
using Zenject;

namespace StateSystem
{
    public class EnemyUltState : AState
    {
        private Animator _playerAnimator;
        private float _attackTime;
        private float _currentTime;
        private float _stunDuration;
        private Game _game;
        private PlayerStateMachine _playerStateMachine;
        private PlayerHealth _playerHealth;

        [Inject]
        public EnemyUltState([Inject(Id = BindId.ENEMY)] Animator playerAnimator,
            [Inject(Id = BindId.ENEMY_ULT_STATE)] float attackTime,
            [Inject(Id = BindId.ENEMY_ULT_STATE)] int stunDuration,
            Game game, 
            PlayerHealth playerHealth)
        {
            _playerAnimator = playerAnimator;
            _attackTime = attackTime;
            _stunDuration = stunDuration;
            _game = game;
            _playerHealth = playerHealth;
        }

        public override void Enter(float value = 0)
        {
            if (_playerStateMachine == null)
            {
                _playerStateMachine = _game.PlayerStateMachine;
            }
            _playerAnimator.SetInteger("State", BindId.ENEMY_ULT_STATE);
            _playerStateMachine.ChangeState(typeof(StunState), _stunDuration);
            SoundSystem
                .SoundSingleton
                .Instance
                .PlayOneShotEnemy(SoundSystem.SoundSingleton.Instance.SoundSo.EnemyUlt);
            _currentTime = _attackTime;
        }

        public override void Update()
        {
            if (_currentTime <= 0)
            {
                _playerHealth.DealDamage(10000);
            }
            _currentTime -= Time.deltaTime;
        }
    }
}