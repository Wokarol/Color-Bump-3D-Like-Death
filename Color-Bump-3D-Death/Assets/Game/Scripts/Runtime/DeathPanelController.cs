using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Wokarol
{
    public class DeathPanelController : MonoBehaviour
    {
        [SerializeField] CanvasTimer _timer;
        [SerializeField] GameObject _skipButton;
        [Space]
        [SerializeField] float _showTime;
        [SerializeField] CanvasGroup _group;

        float _countdowm;
        float _startedTimer;

        bool _timerStarted = false;

        private void OnEnable() {
            _startedTimer = Time.unscaledTime;
        }

        private void Update() {
            _countdowm -= Time.unscaledDeltaTime;
            if(_countdowm < 0 && _timerStarted) {
                _skipButton.SetActive(true);
            }
            _group.alpha = (Time.unscaledTime - _startedTimer) / _showTime;
            if(_group.alpha >= 1 && !_timerStarted) {
                _timer.StartTimer(10);
                _countdowm = 2;
                _timerStarted = true;
            }
        }

        public void Restart() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    } 
}
