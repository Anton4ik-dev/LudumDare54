using Core;
using UnityEngine;
using Zenject;

namespace StateSystem
{
    public class FinishState : AState
    {
        private Animator _enemyAnimator;

        [Inject]
        public FinishState([Inject(Id = BindId.PLAYER)] Animator playerAnimator)
        {
            _enemyAnimator = playerAnimator;
        }

        public override void Enter(float value = 0)
        {
            _enemyAnimator.SetInteger("State", BindId.FINISH_STATE);
            SoundSystem
                .SoundSingleton
                .Instance
                .PlayOneShotPlayer(SoundSystem.SoundSingleton.Instance.SoundSo.PlayerFinale);
        }
    }
}