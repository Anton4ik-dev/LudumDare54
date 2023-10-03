using Core;
using UnityEngine;
using Zenject;

namespace StateSystem
{
    public class EnemyStunState : AState
    {
        private Animator _enemyAnimator;
        private float _currentTime;

        [Inject]
        public EnemyStunState([Inject(Id = BindId.ENEMY)] Animator playerAnimator)
        {
            _enemyAnimator = playerAnimator;
        }

        public override void Enter(float value = 0)
        {
            _enemyAnimator.SetInteger("State", BindId.ENEMY_STUN_STATE);
            SoundSystem
                .SoundSingleton
                .Instance
                .PlayOneShotEnemy(SoundSystem.SoundSingleton.Instance.SoundSo.EnemyStun);
            _currentTime = value;
        }

        public override void Update()
        {
            if (_currentTime <= 0)
            {
                Owner.ChangeState(typeof(EnemyAttackState));
            }
            _currentTime -= Time.deltaTime;
        }

        public override void Exit()
        {
            _currentTime = 0;
        }
    }
}