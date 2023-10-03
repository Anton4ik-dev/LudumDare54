using Core;
using DG.Tweening;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UISystem
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private Slider _upperSlider;
        [SerializeField] private Slider _lowerSlider;
        [SerializeField] private Game _game;
        [SerializeField] private GameObject _winView;

        [SerializeField] private TextMeshProUGUI _roundsText;
        [SerializeField] private GameObject _roundWonText;
        [SerializeField] private Color _marked;
        [SerializeField] private List<Image> _wonRounds;
        [SerializeField] private float _pauseBetweenRounds;
        [SerializeField] private float _pauseAfterWin;

        [SerializeField] private Slider _playerUpperSlider;
        [SerializeField] private Slider _playerLowerSlider;
        [SerializeField] private SpriteRenderer _enemy;
        [SerializeField] private Color _onDamage;
        [SerializeField] private PlayerIconsView _playerIconsView;

        private float _currentTime;
        private int _wonRoundCounter;
        private bool _isPausedGame;
        private bool _isFinished;

        private void Update()
        {
            if(_upperSlider.value < _lowerSlider.value)
            {
                _lowerSlider.value -= 0.5f;
            } 
            else
            {
                _lowerSlider.value = _upperSlider.value;
            }

            if(_isPausedGame && !_isFinished)
            {
                if (_currentTime <= 0)
                {
                    _roundWonText.SetActive(false);
                    char round = _roundsText.text[_roundsText.text.Length - 1];
                    int number = round - '0';
                    number++;
                    _roundsText.text = $"round {number}";
                    _game.StartGame();
                    _isPausedGame = false;
                }
                _currentTime -= Time.deltaTime;
            } else if(_isFinished)
            {
                if (_currentTime <= 0)
                {
                    _winView.SetActive(true);
                    _game.UnlockMouse();
                }
                _currentTime -= Time.deltaTime;
            }
        }

        public bool DealDamage(int damage)
        {
            _upperSlider.value -= damage;
            Tween tween = _enemy.DOColor(_onDamage, 0.25f);
            tween.OnComplete(() => _enemy.DOColor(Color.white, 0.25f));
            if (_upperSlider.value <= 0)
            {
                // replica
                _roundWonText.SetActive(true);
                _currentTime = _pauseBetweenRounds;
                _game.PauseGame();
                _isPausedGame = true;
                _wonRounds[_wonRoundCounter].color = _marked;
                _wonRoundCounter++;
                _upperSlider.value = _upperSlider.maxValue;
                _lowerSlider.value = _lowerSlider.maxValue;
                _playerUpperSlider.value = _playerUpperSlider.maxValue;
                _playerLowerSlider.value = _playerLowerSlider.maxValue;
                _playerIconsView.ResetAllVariables();

                if (_wonRoundCounter == 2)
                {
                    _roundWonText.SetActive(false);
                    _isFinished = true;
                    _game.EndGame();
                    _currentTime = _pauseAfterWin;
                }

                return false;
            }
            return true;
        }
    }
}