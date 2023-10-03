using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UISystem
{
    public class PlayerIconsView : MonoBehaviour
    {
        [SerializeField] private Color _grey;
        [SerializeField] private Color _red;
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
        [SerializeField] private List<Image> _rChargesIcons;

        private bool _isQOnCooldawn = false;
        private bool _isWOnCooldawn = false;
        private bool _isEOnCooldawn = false;

        private bool _isStrongQOnCooldawn = false;
        private bool _isStrongWOnCooldawn = false;
        private bool _isStrongEOnCooldawn = false;

        private float _qCurrentTime;
        private float _wCurrentTime;
        private float _eCurrentTime;

        private int _rCharges;

        public int RCharges => _rCharges;

        public bool IsQOnCooldawn => _isQOnCooldawn;
        public bool IsWOnCooldawn => _isWOnCooldawn;
        public bool IsEOnCooldawn => _isEOnCooldawn;
        public bool IsStrongQOnCooldawn => _isStrongQOnCooldawn;
        public bool IsStrongWOnCooldawn => _isStrongWOnCooldawn;
        public bool IsStrongEOnCooldawn => _isStrongEOnCooldawn;

        private void Update()
        {
            if(_isQOnCooldawn)
            {
                _qCurrentTime -= Time.deltaTime;
                if(_qCurrentTime <= 0)
                {
                    _isQOnCooldawn = false;
                    _qIcon.color = _default;
                }
            }

            if (_isWOnCooldawn)
            {
                _wCurrentTime -= Time.deltaTime;
                if (_wCurrentTime <= 0)
                {
                    _isWOnCooldawn = false;
                    _wIcon.color = _default;
                }
            }

            if (_isEOnCooldawn)
            {
                _eCurrentTime -= Time.deltaTime;
                if (_eCurrentTime <= 0)
                {
                    _isEOnCooldawn = false;
                    _eIcon.color = _default;
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
            }
        }

        public void SetWOnCooldawn()
        {
            if (!_isWOnCooldawn)
            {
                _isWOnCooldawn = true;
                _wCurrentTime = _wCooldawn;
                _wIcon.color = _grey;
            }
        }

        public void SetEOnCooldawn()
        {
            if (!_isEOnCooldawn)
            {
                _isEOnCooldawn = true;
                _eCurrentTime = _eCooldawn;
                _eIcon.color = _grey;
            }
        }

        public void SetStrongQOnCooldawn()
        {
            if(!_isStrongQOnCooldawn)
            {
                _isQOnCooldawn = true;
                _qCurrentTime = _qCooldawn;
                _qIcon.color = _grey;
                _shiftQIcon.gameObject.SetActive(false);
                _isStrongQOnCooldawn = true;
            }
        }

        public void SetStrongWOnCooldawn()
        {
            if (!_isStrongWOnCooldawn)
            {
                _isWOnCooldawn = true;
                _wCurrentTime = _wCooldawn;
                _wIcon.color = _grey;
                _shiftWIcon.gameObject.SetActive(false);
                _isStrongWOnCooldawn = true;
            }
        }

        public void SetStrongEOnCooldawn()
        {
            if (!_isStrongEOnCooldawn)
            {
                _isEOnCooldawn = true;
                _eCurrentTime = _eCooldawn;
                _eIcon.color = _grey;
                _shiftEIcon.gameObject.SetActive(false);
                _isStrongEOnCooldawn = true;
            }
        }

        public void SetROnCooldawn()
        {
            _rIcon.color = _grey;
            _rCharges = 0;
            for (int i = 0; i < _rChargesIcons.Count; i++)
            {
                _rChargesIcons[i].color = _default;
            }
        }

        public void AddCharge()
        {
            if(_rCharges < _rChargesIcons.Count)
                _rChargesIcons[_rCharges].color = _red;

            _rCharges++;

            if(_rCharges == 3)
            {
                _rIcon.color = _default;
            }
        }

        public void ResetAllVariables()
        {
            _isQOnCooldawn = false;
            _qIcon.color = _default;
            _isWOnCooldawn = false;
            _wIcon.color = _default;
            _isEOnCooldawn = false;
            _eIcon.color = _default;
            _shiftQIcon.gameObject.SetActive(true);
            _isStrongQOnCooldawn = false;
            _shiftWIcon.gameObject.SetActive(true);
            _isStrongWOnCooldawn = false;
            _shiftEIcon.gameObject.SetActive(true);
            _isStrongEOnCooldawn = false;
            SetROnCooldawn();
        }
    }
}