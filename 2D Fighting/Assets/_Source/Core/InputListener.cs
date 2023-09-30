using Core;
using StateSystem;
using UISystem;
using UnityEngine;
using Zenject;

public class InputListener : MonoBehaviour
{
    [SerializeField] private PlayerIconsView _iconsView;

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
                    _iconsView.SetStrongQOnCooldawn();
                    _playerStateMachine.ChangeState(typeof(QState), 2);
                }

                if (Input.GetKeyDown(KeyCode.W))
                {
                    _iconsView.SetStrongWOnCooldawn();
                    _playerStateMachine.ChangeState(typeof(WState), 2);
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    _iconsView.SetStrongEOnCooldawn();
                    _playerStateMachine.ChangeState(typeof(EState), 2);
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    _iconsView.SetQOnCooldawn();
                    _playerStateMachine.ChangeState(typeof(QState));
                }

                if (Input.GetKeyDown(KeyCode.W))
                {
                    _iconsView.SetWOnCooldawn();
                    _playerStateMachine.ChangeState(typeof(WState));
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    _iconsView.SetEOnCooldawn();
                    _playerStateMachine.ChangeState(typeof(EState));
                }

                if (Input.GetKeyDown(KeyCode.R))
                {
                    _iconsView.SetROnCooldawn();
                    _playerStateMachine.ChangeState(typeof(RState));
                }
            }
        }
    }
}
