using Core;
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

        private void Update()
        {
            if(_upperSlider.value < _lowerSlider.value)
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
            _upperSlider.value -= damage;
            if (_upperSlider.value <= 0)
            {
                // replica
                _game.PauseGame();
                _winView.SetActive(true);
            }
        }
    }
}