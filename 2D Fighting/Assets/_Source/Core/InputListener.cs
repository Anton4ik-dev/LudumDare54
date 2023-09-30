using Core;
using StateSystem;
using UISystem;
using UnityEngine;
using Zenject;

public class InputListener : MonoBehaviour
{
    [SerializeField] private PlayerIconsView _playerIconsView;
    [SerializeField] private EnemyIconsView _enemyIconsView;

    private PlayerStateMachine _playerStateMachine;

    [Inject]
    public void Construct([Inject(Id = BindId.PLAYER)] IStateMachine playerStateMachine)
    {
        _playerStateMachine = (PlayerStateMachine)playerStateMachine;
    }

    void Update()
    {
        if (_playerStateMachine.CurrentState.GetType() != typeof(StunState)
            && _playerStateMachine.CurrentState.GetType() != typeof(RState))
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    if(_enemyIconsView.IsQTrigger)
                    {
                        _playerIconsView.AddCharge();
                        _enemyIconsView.SetTrigger();
                    }
                    _playerIconsView.SetStrongQOnCooldawn();
                    _playerStateMachine.ChangeState(typeof(QState), 2);
                }

                if (Input.GetKeyDown(KeyCode.W))
                {
                    if (_enemyIconsView.IsWTrigger)
                    {
                        _playerIconsView.AddCharge();
                        _enemyIconsView.SetTrigger();
                    }
                    _playerIconsView.SetStrongWOnCooldawn();
                    _playerStateMachine.ChangeState(typeof(WState), 2);
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (_enemyIconsView.IsETrigger)
                    {
                        _playerIconsView.AddCharge();
                        _enemyIconsView.SetTrigger();
                    }
                    _playerIconsView.SetStrongEOnCooldawn();
                    _playerStateMachine.ChangeState(typeof(EState), 2);
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    _playerIconsView.SetQOnCooldawn();
                    _playerStateMachine.ChangeState(typeof(QState));
                }

                if (Input.GetKeyDown(KeyCode.W))
                {
                    _playerIconsView.SetWOnCooldawn();
                    _playerStateMachine.ChangeState(typeof(WState));
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    _playerIconsView.SetEOnCooldawn();
                    _playerStateMachine.ChangeState(typeof(EState));
                }

                if (Input.GetKeyDown(KeyCode.R) && _playerIconsView.RCharges == 3)
                {
                    _playerIconsView.SetROnCooldawn();
                    _playerStateMachine.ChangeState(typeof(RState));
                }
            }
        }
    }
}
