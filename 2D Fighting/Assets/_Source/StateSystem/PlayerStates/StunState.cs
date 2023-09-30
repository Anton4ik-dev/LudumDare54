using Core;
using UnityEngine;
using Zenject;

namespace StateSystem
{
    public class StunState : AState
    {
        private Animator _playerAnimator;
        private float _currentTime;

        [Inject]
        public StunState([Inject(Id = BindId.PLAYER)] Animator playerAnimator)
        {
            _playerAnimator = playerAnimator;
        }

        public override void Enter(float value = 0)
        {
            _playerAnimator.SetInteger("State", BindId.STUN_STATE);
            _currentTime = value;
        }

        public override void Update()
        {
            if (_currentTime <= 0)
            {
                Owner.ChangeState(typeof(AttackState));
            }
            _currentTime -= Time.deltaTime;
        }
    }
}