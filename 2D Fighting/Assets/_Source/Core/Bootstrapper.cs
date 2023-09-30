using StateSystem;
using UnityEngine;
using Zenject;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        private PlayerStateMachine _playerStateMachine;
        private EnemyStateMachine _enemyStateMachine;

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
        }

        private void Update()
        {
            _playerStateMachine.Update();
            _enemyStateMachine.Update();
        }
    }
}