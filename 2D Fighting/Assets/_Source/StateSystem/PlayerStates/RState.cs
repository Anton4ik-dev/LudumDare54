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
        private int _damage;
        private EnemyHealth _enemyHealth;
        private float _stunDuration;
        private EnemyStateMachine _enemyStateMachine;

        [Inject]
        public RState([Inject(Id = BindId.PLAYER)] Animator playerAnimator,
            [Inject(Id = BindId.R_STATE)] float attackTime,
            [Inject(Id = BindId.R_STATE)] int damage,
            EnemyHealth enemyHealth,
            [Inject(Id = BindId.R_STATE)] float stunDuration,
            [Inject(Id = BindId.ENEMY)] IStateMachine enemyStateMachine)
        {
            _playerAnimator = playerAnimator;
            _attackTime = attackTime;
            _damage = damage;
            _enemyHealth = enemyHealth;
            _stunDuration = stunDuration;
            _enemyStateMachine = (EnemyStateMachine)enemyStateMachine;
        }

        public override void Enter(float value = 0)
        {
            _playerAnimator.SetInteger("State", BindId.R_STATE);
            _enemyStateMachine.ChangeState(typeof(StunState), _stunDuration);
            _currentTime = _attackTime;
        }

        public override void Update()
        {
            if (_currentTime <= 0)
            {
                _enemyHealth.DealDamage(_damage);
                Owner.ChangeState(typeof(AttackState));
            }
            _currentTime -= Time.deltaTime;
        }
    }
}