using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
    /// <summary>
    /// Handles Bullet Time on Player Death
    /// </summary>
    public class TimeController : MonoBehaviour
    {
        [SerializeField] float _minTime = 0.1f;
        [SerializeField] float _timeSlowTime = 1;
        private float _timeStamp;
        private bool _isActive;

        private void Start() {
            MessageSystem.Messenger.Default.RegisterSubscriberTo<PlayerDied>(OnPlayerDied);
            Time.timeScale = 1;
            Time.fixedDeltaTime = 0.02f;
        }

        private void OnPlayerDied(PlayerDied e) {
            _timeStamp = Time.unscaledTime;
            _isActive = true;
        }

        private void Update() {
            if (_isActive) {
                // Lerps form normal to bullet time with given speed
                Time.timeScale = Mathf.Lerp(1, _minTime, (Time.unscaledTime - _timeStamp) / _timeSlowTime);
                Time.fixedDeltaTime = 0.02f * Time.timeScale;
            }
        }
    }
}
