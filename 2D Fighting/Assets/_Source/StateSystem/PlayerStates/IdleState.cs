using Core;
using UnityEngine;
using Zenject;

namespace StateSystem
{
    public class IdleState : AState
    {
        private Animator _enemyAnimator;

        [Inject]
        public IdleState([Inject(Id = BindId.PLAYER)] Animator playerAnimator)
        {
            _enemyAnimator = playerAnimator;
        }

        public override void Enter(float value = 0)
        {
            _enemyAnimator.SetInteger("State", BindId.PLAYER);
        }
    }
}