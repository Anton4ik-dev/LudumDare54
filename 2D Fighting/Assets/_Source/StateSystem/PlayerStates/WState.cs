using Core;
using UISystem;
using UnityEngine;
using Zenject;

namespace StateSystem
{
    public class WState : AState
    {
        private Animator _playerAnimator;
        private float _attackTime;
        private float _currentTime;
        private int _decreaseDamagePercentage;
        private PlayerHealth _playerHealth;
        private float _multiplier = 1;

        [Inject]
        public WState([Inject(Id = BindId.PLAYER)] Animator playerAnimator,
            [Inject(Id = BindId.W_STATE)] float attackTime,
            [Inject(Id = BindId.W_STATE)] int decreaseDamagePercentage,
            PlayerHealth playerHealth)
        {
            _playerAnimator = playerAnimator;
            _attackTime = attackTime;
            _decreaseDamagePercentage = decreaseDamagePercentage;
            _playerHealth = playerHealth;
        }

        public override void Enter(float value = 0)
        {
            if (value != 0)
            {
                _multiplier = value;
            }
            _playerAnimator.SetInteger("State", BindId.W_STATE);
            _playerHealth.DecreaseDamage(true, _decreaseDamagePercentage * (int)_multiplier);
            SoundSystem
                .SoundSingleton
                .Instance
                .PlayOneShotPlayer(SoundSystem.SoundSingleton.Instance.SoundSo.PlayerW);
            _currentTime = _attackTime;
        }

        public override void Update()
        {
            if (_currentTime <= 0)
            {
                Owner.ChangeState(typeof(AttackState));
            }
            _currentTime -= Time.deltaTime;
        }

        public override void Exit()
        {
            _playerHealth.DecreaseDamage(false, 0);
            _multiplier = 1;
        }
    }
}