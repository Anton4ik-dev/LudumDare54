using Core;
using UnityEngine;
using Zenject;

namespace StateSystem
{
    public class EnemyFinishState : AState
    {
        private Animator _enemyAnimator;

        [Inject]
        public EnemyFinishState([Inject(Id = BindId.ENEMY)] Animator playerAnimator)
        {
            _enemyAnimator = playerAnimator;
        }

        public override void Enter(float value = 0)
        {
            _enemyAnimator.SetInteger("State", BindId.ENEMY_FINISH_STATE);
        }
    }
}