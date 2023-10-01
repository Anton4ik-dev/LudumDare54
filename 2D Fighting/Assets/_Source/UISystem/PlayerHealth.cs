using Core;
using System.Collections;
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

        private bool _isDecreasingDamage = false;
        private float _decreaseDamagePercent;

        private void Update()
        {
            if (_upperSlider.value < _lowerSlider.value)
            {
                _lowerSlider.value -= 0.05f;
            }
            else
            {
                _lowerSlider.value = _upperSlider.value;
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
            if (_upperSlider.value <= 0)
            {
                // replica
                _game.PauseGame();
                _loseView.SetActive(true);
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
                DealDamage(damage);
                yield return new WaitForSeconds(1f);
            }
        }
    }
}