using Core;
using UISystem;
using UnityEngine;
using Zenject;

namespace StateSystem
{
    public class EnemySpecialState : AState
    {
        private Animator _enemyAnimator;
        private float _attackTime;
        private float _currentTime;
        private int _damage;
        private PlayerHealth _playerHealth;
        private EnemyIconsView _enemyIconsView;

        [Inject]
        public EnemySpecialState([Inject(Id = BindId.ENEMY)] Animator enemyAnimator,
            [Inject(Id = BindId.ENEMY_SPECIAL_STATE)] float attackTime,
            [Inject(Id = BindId.ENEMY_SPECIAL_STATE)] int damage,
            PlayerHealth playerHealth,
            EnemyIconsView enemyIconsView)
        {
            _enemyAnimator = enemyAnimator;
            _attackTime = attackTime;
            _damage = damage;
            _playerHealth = playerHealth;
            _enemyIconsView = enemyIconsView;
        }

        public override void Enter(float value = 0)
        {
            _enemyAnimator.SetInteger("State", BindId.ENEMY_SPECIAL_STATE);
            _currentTime = _attackTime;
            if (value != 0)
            {
                _enemyIconsView.SetTrigger(value);
            }
        }

        public override void Update()
        {
            if (_currentTime <= 0)
            {
                _playerHealth.StartCoroutine(_playerHealth.DealTickDamage(_damage));
                _enemyIconsView.SetTrigger();
                Owner.ChangeState(typeof(EnemyAttackState));
            }
            _currentTime -= Time.deltaTime;
        }
    }
}