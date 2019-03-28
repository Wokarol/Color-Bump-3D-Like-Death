using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Wokarol
{
    /// <summary>
    /// Handles Game Over menu
    /// </summary>
    public class DeathPanelController : MonoBehaviour
    {
        [SerializeField] CanvasTimer _timer = default;
        [SerializeField] GameObject _skipButton = default;
        [Space]
        [SerializeField] float _showTime = default;
        [SerializeField] CanvasGroup _group = default;

        float _countdowm;
        float _startedTimer;

        bool _timerStarted = false;

        private void OnEnable() {
            _startedTimer = Time.unscaledTime;
        }

        private void Update() {
            _countdowm -= Time.unscaledDeltaTime;

            // Enabling "Not Now" button
            if(_countdowm < 0 && _timerStarted) {
                _skipButton.SetActive(true);
            }

            // Fade in effect
            _group.alpha = (Time.unscaledTime - _startedTimer) / _showTime;

            // Starting End Game Menu logic when fade in is finished
            if(_group.alpha >= 1 && !_timerStarted) {
                _timer.StartTimer(10);
                _countdowm = 2;
                _timerStarted = true;
            }
        }

        /// <summary>
        /// Restarts scene
        /// </summary>
        public void Restart() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    } 
}
