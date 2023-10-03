using Core;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UISystem
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private Slider _upperSlider;
        [SerializeField] private Slider _lowerSlider;
        [SerializeField] private Game _game;
        [SerializeField] private GameObject _loseView;

        [SerializeField] private TextMeshProUGUI _roundsText;
        [SerializeField] private GameObject _roundLoseText;
        [SerializeField] private Color _marked;
        [SerializeField] private List<Image> _wonRounds;
        [SerializeField] private float _pauseBetweenRounds;

        [SerializeField] private Slider _enemyUpperSlider;
        [SerializeField] private Slider _enemyLowerSlider;
        [SerializeField] private SpriteRenderer _player;
        [SerializeField] private Color _onDamage;
        [SerializeField] private Color _onPoison;
        [SerializeField] private PlayerIconsView _playerIconsView;

        private float _currentTime;
        private int _wonRoundCounter;
        private bool _isPausedGame;
        private bool _isFinished = false;

        private bool _isDecreasingDamage = false;
        private float _decreaseDamagePercent;

        private void Update()
        {
            if (_upperSlider.value < _lowerSlider.value)
            {
                _lowerSlider.value -= 0.5f;
            }
            else
            {
                _lowerSlider.value = _upperSlider.value;
            }

            if (_isPausedGame && !_isFinished)
            {
                if (_currentTime <= 0)
                {
                    _roundLoseText.SetActive(false);
                    char round = _roundsText.text[_roundsText.text.Length - 1];
                    int number = round - '0';
                    number++;
                    _roundsText.text = $"round {number}";
                    _game.StartGame();
                    _isPausedGame = false;
                }
                _currentTime -= Time.deltaTime;
            }
        }

        public void DealDamage(int damage)
        {
            if(_isDecreasingDamage)
            {
                float decreasedDamage = damage / 100f * _decreaseDamagePercent;
                damage -= (int)decreasedDamage;
            }
            _upperSlider.value -= damage;

            Tween tween = _player.DOColor(_onDamage, 0.25f);
            tween.OnComplete(() => _player.DOColor(Color.white, 0.25f));

            if (_upperSlider.value <= 0)
            {
                _roundLoseText.SetActive(true);
                _currentTime = _pauseBetweenRounds;
                _game.PauseGame();
                _isPausedGame = true;
                _wonRounds[_wonRoundCounter].color = _marked;
                _wonRoundCounter++;
                _upperSlider.value = _upperSlider.maxValue;
                _lowerSlider.value = _lowerSlider.maxValue;
                _enemyUpperSlider.value = _enemyUpperSlider.maxValue;
                _enemyLowerSlider.value = _enemyLowerSlider.maxValue;
                _playerIconsView.ResetAllVariables();

                if(_wonRoundCounter == 2)
                {
                    _isFinished = true;
                    _game.PauseGame();
                    _loseView.SetActive(true);
                }
            }
        }

        public void DecreaseDamage(bool isDecrease, float decreaseDamagePercentage)
        {
            _isDecreasingDamage = isDecrease;
            _decreaseDamagePercent = decreaseDamagePercentage;
        }

        public IEnumerator DealTickDamage(int damage)
        {
            for (int i = 0; i < 3; i++)
            {
                if (_isDecreasingDamage)
                {
                    float decreasedDamage = damage / 100f * _decreaseDamagePercent;
                    damage -= (int)decreasedDamage;
                }
                _upperSlider.value -= damage;

                Tween tween = _player.DOColor(_onPoison, 0.25f);
                tween.OnComplete(() => _player.DOColor(Color.white, 0.25f));

                if (_upperSlider.value <= 0)
                {
                    _roundLoseText.SetActive(true);
                    _currentTime = _pauseBetweenRounds;
                    _game.PauseGame();
                    _isPausedGame = true;
                    _wonRounds[_wonRoundCounter].color = _marked;
                    _wonRoundCounter++;
                    _upperSlider.value = _upperSlider.maxValue;
                    _lowerSlider.value = _lowerSlider.maxValue;
                    _enemyUpperSlider.value = _enemyUpperSlider.maxValue;
                    _enemyLowerSlider.value = _enemyLowerSlider.maxValue;
                    _playerIconsView.ResetAllVariables();
                    if (_wonRoundCounter == 2)
                    {
                        _isFinished = true;
                        _game.PauseGame();
                        _loseView.SetActive(true);
                    }
                }
                yield return new WaitForSeconds(1f);
            }
        }
    }
}