using Core;
using UISystem;
using UnityEngine;
using Zenject;

namespace StateSystem
{
    public class RState : AState
    {
        private Animator _playerAnimator;
        private float _attackTime;
        private float _currentTime;
        private EnemyHealth _enemyHealth;
        private float _stunDuration;
        private EnemyStateMachine _enemyStateMachine;

        [Inject]
        public RState([Inject(Id = BindId.PLAYER)] Animator playerAnimator,
            [Inject(Id = BindId.R_STATE)] float attackTime,
            EnemyHealth enemyHealth,
            [Inject(Id = BindId.R_STATE)] int stunDuration,
            [Inject(Id = BindId.ENEMY)] IStateMachine enemyStateMachine)
        {
            _playerAnimator = playerAnimator;
            _attackTime = attackTime;
            _enemyHealth = enemyHealth;
            _stunDuration = stunDuration;
            _enemyStateMachine = (EnemyStateMachine)enemyStateMachine;
        }

        public override void Enter(float value = 0)
        {
            _playerAnimator.SetInteger("State", BindId.R_STATE);
            SoundSystem
                .SoundSingleton
                .Instance
                .PlayOneShotPlayer(SoundSystem.SoundSingleton.Instance.SoundSo.PlayerR);
            _enemyStateMachine.ChangeState(typeof(EnemyStunState), _stunDuration);
            _currentTime = _attackTime;
        }

        public override void Update()
        {
            if (_currentTime <= 0)
            {
                _enemyHealth.DealDamage(10000);
            }
            _currentTime -= Time.deltaTime;
        }
    }
}