using UnityEngine;
using UnityEngine.UI;

namespace UISystem
{
    public class EnemyIconsView : MonoBehaviour
    {
        [SerializeField] private Color _red;
        [SerializeField] private Color _blue;
        [SerializeField] private Color _green;

        [SerializeField] private Image _triggerIcon;

        private bool _isQTrigger = false;
        private bool _isWTrigger = false;
        private bool _isETrigger = false;

        public bool IsQTrigger => _isQTrigger;
        public bool IsWTrigger => _isWTrigger;
        public bool IsETrigger => _isETrigger;

        public void SetTrigger(float value = 0)
        {
            if (value == 1 && !_isQTrigger)
            {
                _isQTrigger = true;
                _triggerIcon.color = _red;
                _triggerIcon.gameObject.SetActive(true);
            }
            else if ((value == 1 || value == 0) && _isQTrigger)
            {
                _isQTrigger = false;
                _triggerIcon.gameObject.SetActive(false);
            }

            if (value == 2 && !_isWTrigger)
            {
                _isWTrigger = true;
                _triggerIcon.color = _blue;
                _triggerIcon.gameObject.SetActive(true);
            }
            else if ((value == 2 || value == 0) && _isWTrigger)
            {
                _isWTrigger = false;
                _triggerIcon.gameObject.SetActive(false);
            }

            if (value == 3 && !_isETrigger)
            {
                _isETrigger = true;
                _triggerIcon.color = _green;
                _triggerIcon.gameObject.SetActive(true);
            }
            else if ((value == 3 || value == 0) && _isETrigger)
            {
                _isETrigger = false;
                _triggerIcon.gameObject.SetActive(false);
            }
        }
    }
}