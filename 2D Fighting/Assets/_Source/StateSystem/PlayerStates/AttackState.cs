using Core;
using UISystem;
using UnityEngine;
using Zenject;

namespace StateSystem
{
    public class AttackState : AState
    {
        private Animator _playerAnimator;
        private float _attackTime;
        private float _currentTime;
        private int _damage;
        private EnemyHealth _enemyHealth;

        [Inject]
        public AttackState([Inject(Id = BindId.PLAYER)] Animator playerAnimator,
            [Inject(Id = BindId.ATTACK_STATE)] float attackTime,
            [Inject(Id = BindId.ATTACK_STATE)] int damage,
            EnemyHealth enemyHealth)
        {
            _playerAnimator = playerAnimator;
            _attackTime = attackTime;
            _damage = damage;
            _enemyHealth = enemyHealth;
        }

        public override void Enter(float value = 0)
        {
            _playerAnimator.SetInteger("State", BindId.ATTACK_STATE);
            _currentTime = _attackTime;
        }

        public override void Update()
        {
            if(_currentTime <= 0)
            {
                _enemyHealth.DealDamage(_damage);
                SoundSystem
                    .SoundSingleton
                    .Instance
                    .PlayOneShot(SoundSystem.SoundSingleton.Instance.SoundSo.PlayerAttack);
                _currentTime = _attackTime;
            }
            _currentTime -= Time.deltaTime;
        }
    }
}