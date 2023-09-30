using Core;
using UISystem;
using UnityEngine;
using Zenject;

namespace StateSystem
{
    public class QState : AState
    {
        private Animator _playerAnimator;
        private float _attackTime;
        private float _currentTime;
        private int _damage;
        private EnemyHealth _enemyHealth;
        private float _multiplier = 1;

        [Inject]
        public QState([Inject(Id = BindId.PLAYER)] Animator playerAnimator,
            [Inject(Id = BindId.Q_STATE)] float attackTime,
            [Inject(Id = BindId.Q_STATE)] int damage,
            EnemyHealth enemyHealth)
        {
            _playerAnimator = playerAnimator;
            _attackTime = attackTime;
            _damage = damage;
            _enemyHealth = enemyHealth;
        }

        public override void Enter(float value = 0)
        {
            _playerAnimator.SetInteger("State", BindId.Q_STATE);
            _currentTime = _attackTime;
            if(value != 0)
            {
                _multiplier = value;
            }
        }

        public override void Update()
        {
            if (_currentTime <= 0)
            {
                _enemyHealth.DealDamage(_damage * (int)_multiplier);
                _multiplier = 1;
                Owner.ChangeState(typeof(AttackState));
            }
            _currentTime -= Time.deltaTime;
        }
    }
}