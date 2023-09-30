using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UISystem
{
    public class PlayerIconsView : MonoBehaviour
    {
        [SerializeField] private Color _grey;
        [SerializeField] private Color _default;

        [SerializeField] private float _qCooldawn;
        [SerializeField] private float _wCooldawn;
        [SerializeField] private float _eCooldawn;

        [SerializeField] private Image _qIcon;
        [SerializeField] private Image _wIcon;
        [SerializeField] private Image _eIcon;
        [SerializeField] private Image _rIcon;

        [SerializeField] private Image _shiftQIcon;
        [SerializeField] private Image _shiftWIcon;
        [SerializeField] private Image _shiftEIcon;

        [SerializeField] private TextMeshProUGUI _qText;
        [SerializeField] private TextMeshProUGUI _wText;
        [SerializeField] private TextMeshProUGUI _eText;

        private bool _isQOnCooldawn = false;
        private bool _isWOnCooldawn = false;
        private bool _isEOnCooldawn = false;

        private bool _isStrongQOnCooldawn = false;
        private bool _isStrongWOnCooldawn = false;
        private bool _isStrongEOnCooldawn = false;

        private float _qCurrentTime;
        private float _wCurrentTime;
        private float _eCurrentTime;

        private void Update()
        {
            if(_isQOnCooldawn)
            {
                _qCurrentTime -= Time.deltaTime;
                _qText.text = $"{(int)_qCurrentTime}";
                if(_qCurrentTime <= 0)
                {
                    _isQOnCooldawn = false;
                    _qIcon.color = _default;
                    _qText.gameObject.SetActive(false);
                }
            }

            if (_isWOnCooldawn)
            {
                _wCurrentTime -= Time.deltaTime;
                _wText.text = $"{(int)_wCurrentTime}";
                if (_wCurrentTime <= 0)
                {
                    _isWOnCooldawn = false;
                    _wIcon.color = _default;
                    _wText.gameObject.SetActive(false);
                }
            }

            if (_isEOnCooldawn)
            {
                _eCurrentTime -= Time.deltaTime;
                _eText.text = $"{(int)_eCurrentTime}";
                if (_eCurrentTime <= 0)
                {
                    _isEOnCooldawn = false;
                    _eIcon.color = _default;
                    _eText.gameObject.SetActive(false);
                }
            }
        }

        public void SetQOnCooldawn()
        {
            if (!_isQOnCooldawn)
            {
                _isQOnCooldawn = true;
                _qCurrentTime = _qCooldawn;
                _qIcon.color = _grey;
                _qText.gameObject.SetActive(true);
            }
        }

        public void SetWOnCooldawn()
        {
            if (!_isWOnCooldawn)
            {
                _isWOnCooldawn = true;
                _wCurrentTime = _wCooldawn;
                _wIcon.color = _grey;
                _wText.gameObject.SetActive(true);
            }
        }

        public void SetEOnCooldawn()
        {
            if (!_isEOnCooldawn)
            {
                _isEOnCooldawn = true;
                _eCurrentTime = _eCooldawn;
                _eIcon.color = _grey;
                _eText.gameObject.SetActive(true);
            }
        }

        public void SetStrongQOnCooldawn()
        {
            if(!_isStrongQOnCooldawn)
            {
                SetQOnCooldawn();
                _shiftQIcon.color = _grey;
                _isStrongQOnCooldawn = true;
            }
        }

        public void SetStrongWOnCooldawn()
        {
            if (!_isStrongWOnCooldawn)
            {
                SetWOnCooldawn();
                _shiftWIcon.color = _grey;
                _isStrongWOnCooldawn = true;
            }
        }

        public void SetStrongEOnCooldawn()
        {
            if (!_isStrongEOnCooldawn)
            {
                SetEOnCooldawn();
                _shiftEIcon.color = _grey;
                _isStrongEOnCooldawn = true;
            }
        }

        public void SetROnCooldawn()
        {
            _rIcon.color = _grey;
        }
    }
}