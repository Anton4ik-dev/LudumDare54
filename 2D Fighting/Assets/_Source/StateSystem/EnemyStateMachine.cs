using Core;
using System;
using System.Collections.Generic;
using Zenject;

namespace StateSystem
{
    public class EnemyStateMachine : IStateMachine
    {
        private readonly Dictionary<Type, AState> _states;
        private AState _currentState;

        public AState CurrentState => _currentState;

        [Inject]
        public EnemyStateMachine([Inject(Id = BindId.ENEMY_ATTACK_STATE)] AState attackState,
          [Inject(Id = BindId.ENEMY_STUN_STATE)] AState stunState,
          [Inject(Id = BindId.ENEMY_SPECIAL_STATE)] AState specialState,
          [Inject(Id = BindId.ENEMY_WEB_STATE)] AState webState)
        {
            _states = new Dictionary<Type, AState>()
            {
                { typeof(EnemyAttackState), attackState },
                { typeof(EnemyStunState), stunState },
                { typeof(EnemySpecialState), specialState },
                { typeof(EnemyWebState), webState }
            };

            foreach (var state in _states)
                state.Value.SetOwner(this);
        }

        public void ChangeState(Type type, float value = 0)
        {
            _currentState?.Exit();
            _currentState = _states[type];
            _currentState.Enter(value);
        }

        public void Update()
        {
            _currentState?.Update();
        }
    }
}
