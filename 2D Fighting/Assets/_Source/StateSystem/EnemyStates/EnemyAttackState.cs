using Core;
using UISystem;
using UnityEngine;
using Zenject;

namespace StateSystem
{
    public class EnemyAttackState : AState
    {
        private Animator _enemyAnimator;
        private float _attackTime;
        private float _currentTime;
        private int _damage;
        private PlayerHealth _playerHealth;

        [Inject]
        public EnemyAttackState([Inject(Id = BindId.ENEMY)] Animator enemyAnimator,
            [Inject(Id = BindId.ENEMY_ATTACK_STATE)] float attackTime,
            [Inject(Id = BindId.ENEMY_ATTACK_STATE)] int damage,
            PlayerHealth playerHealth)
        {
            _enemyAnimator = enemyAnimator;
            _attackTime = attackTime;
            _damage = damage;
            _playerHealth = playerHealth;
        }

        public override void Enter(float value = 0)
        {
            _enemyAnimator.SetInteger("State", BindId.ENEMY_ATTACK_STATE);
            _currentTime = _attackTime;
        }

        public override void Update()
        {
            if (_currentTime <= 0)
            {
                _playerHealth.DealDamage(_damage);
                _currentTime = _attackTime;
            }
            _currentTime -= Time.deltaTime;
        }
    }
}