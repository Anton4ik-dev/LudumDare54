using StateSystem;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private int _timeBetweenAttacksMin;
        [SerializeField] private int _timeBetweenAttacksMax;
        [SerializeField] private int _qTrigger;
        [SerializeField] private int _wTrigger;
        [SerializeField] private int _eTrigger;

        private List<Type> _spiderActions = new List<Type>
        {
            typeof(EnemySpecialState),
            typeof(EnemyWebState),
            typeof(EnemySpecialState),
            typeof(EnemyWebState),
            typeof(EnemySpecialState),
            typeof(EnemyWebState),
            typeof(EnemySpecialState),
            typeof(EnemyWebState),
            typeof(EnemySpecialState),
            typeof(EnemyWebState),
            typeof(EnemySpecialState),
            typeof(EnemyWebState),
            typeof(EnemySpecialState),
            typeof(EnemyWebState),
            typeof(EnemySpecialState),
            typeof(EnemyWebState),
            typeof(EnemySpecialState),
            typeof(EnemyWebState),
            typeof(EnemySpecialState),
            typeof(EnemyWebState),
            typeof(EnemySpecialState),
            typeof(EnemyWebState),
            typeof(EnemySpecialState),
            typeof(EnemyWebState),
            typeof(EnemySpecialState),
            typeof(EnemyWebState),
            typeof(EnemySpecialState),
            typeof(EnemyWebState),
            typeof(EnemySpecialState),
            typeof(EnemyWebState),
            typeof(EnemySpecialState),
            typeof(EnemyWebState),
            typeof(EnemySpecialState),
            typeof(EnemyWebState),
            typeof(EnemySpecialState),
            typeof(EnemyWebState),
        };

        private PlayerStateMachine _playerStateMachine;
        private EnemyStateMachine _enemyStateMachine;

        private float _currentTime;
        private int _enemyIndex = 0;
        private int _triggerIndex = 0;

        public PlayerStateMachine PlayerStateMachine => _playerStateMachine;

        [Inject]
        public void Construct([Inject(Id = BindId.PLAYER)] IStateMachine playerStateMachine, [Inject(Id = BindId.ENEMY)] IStateMachine enemyStateMachine)
        {
            _playerStateMachine = (PlayerStateMachine)playerStateMachine;
            _enemyStateMachine = (EnemyStateMachine)enemyStateMachine;
        }

        private void Awake()
        {
            _playerStateMachine.ChangeState(typeof(AttackState));
            _enemyStateMachine.ChangeState(typeof(EnemyAttackState));
            _currentTime = Random.Range(_timeBetweenAttacksMin, _timeBetweenAttacksMax);
        }

        private void Update()
        {
            if(_currentTime <= 0)
            {
                if(_enemyStateMachine.CurrentState.GetType() != typeof(EnemyStunState))
                {
                    _enemyIndex++;
                    if (_enemyIndex == _qTrigger
                        || _enemyIndex == _wTrigger
                        || _enemyIndex == _eTrigger)
                    {
                        _triggerIndex++;
                        _enemyStateMachine.ChangeState(_spiderActions[_enemyIndex], _triggerIndex);
                    }
                    else
                    {
                        _enemyStateMachine.ChangeState(_spiderActions[_enemyIndex]);
                    }
                }
                _currentTime = Random.Range(_timeBetweenAttacksMin, _timeBetweenAttacksMax);
            }

            _currentTime -= Time.deltaTime;

            _playerStateMachine.Update();
            _enemyStateMachine.Update();
        }
    }
}