using Core;
using UnityEngine;
using Zenject;

namespace StateSystem
{
    public class EnemyIdleState : AState
    {
        private Animator _enemyAnimator;

        [Inject]
        public EnemyIdleState([Inject(Id = BindId.ENEMY)] Animator playerAnimator)
        {
            _enemyAnimator = playerAnimator;
        }

        public override void Enter(float value = 0)
        {
            _enemyAnimator.SetInteger("State", BindId.ENEMY);
        }
    }
}