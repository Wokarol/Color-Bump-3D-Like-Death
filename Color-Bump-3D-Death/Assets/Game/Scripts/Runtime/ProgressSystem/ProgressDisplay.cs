using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Wokarol
{
    /// <summary>
    /// Displays Game Progress from Game Data to Filled Image
    /// </summary>
    public class ProgressDisplay : MonoBehaviour
    {
        [SerializeField] Image _image = null;

        GameData _gameData;

        private void Start() {
            _gameData = GameData.Default;
        }

        private void Update() {
            _image.fillAmount = _gameData.Progress;
        }
    } 
}
