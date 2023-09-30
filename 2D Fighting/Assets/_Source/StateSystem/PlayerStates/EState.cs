using Core;
using UnityEngine;
using Zenject;

namespace StateSystem
{
    public class EState : AState
    {
        private Animator _playerAnimator;
        private float _attackTime;
        private float _currentTime;
        private float _stunDuration;
        private EnemyStateMachine _enemyStateMachine;
        private float _multiplier = 1;

        [Inject]
        public EState([Inject(Id = BindId.PLAYER)] Animator playerAnimator,
            [Inject(Id = BindId.E_STATE)] float attackTime,
            [Inject(Id = BindId.E_STATE)] int stunDuration,
            [Inject(Id = BindId.ENEMY)] IStateMachine enemyStateMachine)
        {
            _playerAnimator = playerAnimator;
            _attackTime = attackTime;
            _stunDuration = stunDuration;
            _enemyStateMachine = (EnemyStateMachine)enemyStateMachine;
        }

        public override void Enter(float value = 0)
        {
            _playerAnimator.SetInteger("State", BindId.E_STATE);
            _currentTime = _attackTime;
            if(value != 0)
            {
                _multiplier = value;
            }
        }

        public override void Update()
        {
            if (_currentTime <= 0)
            {
                _enemyStateMachine.ChangeState(typeof(EnemyStunState), _stunDuration * _multiplier);
                _multiplier = 1;
                Owner.ChangeState(typeof(AttackState));
            }
            _currentTime -= Time.deltaTime;
        }
    }
}