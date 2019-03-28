using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Wokarol
{
    /// <summary>
    /// Handles (Text + Filled Image) Timer on canvas
    /// </summary>
    public class CanvasTimer : MonoBehaviour
    {
        [SerializeField] TMPro.TMP_Text _timerText = null;
        [SerializeField] Image _image = null;
        [Space]
        [SerializeField] UnityEvent _onTimerFinished = default;

        float _countdown;
        bool _isActive;
        private float _maxTime;

        /// <summary>
        /// Starts countdown with specified time
        /// </summary>
        /// <param name="time"></param>
        internal void StartTimer(int time) {
            _isActive = true;
            _countdown = time;
            _maxTime = time;
        }

        private void Update() {
            if (_isActive) {
                _countdown -= Time.unscaledDeltaTime;

                // Display
                _timerText.text = _countdown.ToString("00");
                _image.fillAmount = _countdown / _maxTime;

                // Raises event if countdown is reached
                if(_countdown < 0) {
                    _onTimerFinished.Invoke();
                    _isActive = false;
                }
            }
        }
    }
}