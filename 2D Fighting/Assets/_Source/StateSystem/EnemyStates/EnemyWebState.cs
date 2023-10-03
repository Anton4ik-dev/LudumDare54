using Core;
using UISystem;
using UnityEngine;
using Zenject;

namespace StateSystem
{
    public class EnemyWebState : AState
    {
        private Animator _playerAnimator;
        private float _attackTime;
        private float _currentTime;
        private float _stunDuration;
        private Game _game;
        private PlayerStateMachine _playerStateMachine;
        private EnemyIconsView _enemyIconsView;

        [Inject]
        public EnemyWebState([Inject(Id = BindId.ENEMY)] Animator playerAnimator,
            [Inject(Id = BindId.ENEMY_WEB_STATE)] float attackTime,
            [Inject(Id = BindId.ENEMY_WEB_STATE)] int stunDuration,
            Game game,
            EnemyIconsView enemyIconsView)
        {
            _playerAnimator = playerAnimator;
            _attackTime = attackTime;
            _stunDuration = stunDuration;
            _game = game;
            _enemyIconsView = enemyIconsView;
        }

        public override void Enter(float value = 0)
        {
            if(_playerStateMachine == null)
            {
                _playerStateMachine = _game.PlayerStateMachine;
            }
            _playerAnimator.SetInteger("State", BindId.ENEMY_WEB_STATE);
            _currentTime = _attackTime;
            if (value != 0)
            {
                _enemyIconsView.SetTrigger(value);
            }
        }

        public override void Update()
        {
            if (_currentTime <= 0)
            {
                _playerStateMachine.ChangeState(typeof(StunState), _stunDuration);
                SoundSystem
                    .SoundSingleton
                    .Instance
                    .PlayOneShotEnemy(SoundSystem.SoundSingleton.Instance.SoundSo.EnemyWeb);
                _enemyIconsView.SetTrigger();
                Owner.ChangeState(typeof(EnemyAttackState));
            }
            _currentTime -= Time.deltaTime;
        }

        public override void Exit()
        {
            _enemyIconsView.SetTrigger();
            _currentTime = _attackTime;
        }
    }
}