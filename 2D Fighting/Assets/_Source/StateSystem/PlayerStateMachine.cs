using Core;
using System;
using System.Collections.Generic;
using Zenject;

namespace StateSystem
{
    public class PlayerStateMachine : IStateMachine
    {
        private readonly Dictionary<Type, AState> _states;
        private AState _currentState;

        public AState CurrentState => _currentState;

        [Inject]
        public PlayerStateMachine([Inject(Id = BindId.ATTACK_STATE)] AState attackState,
          [Inject(Id = BindId.Q_STATE)] AState qState,
          [Inject(Id = BindId.W_STATE)] AState wState,
          [Inject(Id = BindId.E_STATE)] AState eState,
          [Inject(Id = BindId.R_STATE)] AState rState,
          [Inject(Id = BindId.STUN_STATE)] AState stunState)
        {
            _states = new Dictionary<Type, AState>()
            { 
                { typeof(AttackState), attackState },
                { typeof(QState), qState },
                { typeof(WState), wState },
                { typeof(EState), eState },
                { typeof(RState), rState },
                { typeof(StunState), stunState }
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
