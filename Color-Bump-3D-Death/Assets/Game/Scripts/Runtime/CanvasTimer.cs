using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Wokarol
{
    public class CanvasTimer : MonoBehaviour
    {
        [SerializeField] TMPro.TMP_Text _timerText;
        [SerializeField] Image _image;
        [Space]
        [SerializeField] UnityEvent _onTimerFinished;

        float _countdown;
        bool _isActive;
        private float _maxTime;

        internal void StartTimer(int v) {
            _isActive = true;
            _countdown = v;
            _maxTime = v;
        }

        private void Update() {
            if (_isActive) {
                _countdown -= Time.unscaledDeltaTime;
                _timerText.text = _countdown.ToString("00");
                _image.fillAmount = _countdown / _maxTime;
                if(_countdown < 0) {
                    _onTimerFinished.Invoke();
                }
            }
        }
    }
}