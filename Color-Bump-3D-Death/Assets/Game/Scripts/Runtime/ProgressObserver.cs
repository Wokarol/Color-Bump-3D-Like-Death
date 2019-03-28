using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
    public class ProgressObserver : MonoBehaviour
    {
        [SerializeField] Transform _player = null;
        [SerializeField] float _startPos = -80;
        [SerializeField] float _endPos = 0;

        GameData _gameData;

        private void Start() {
            _gameData = GameData.Default;
        }

        private void Update() {
            float newProgress = Mathf.InverseLerp(_startPos, _endPos, _player.position.z);
            if(_gameData.Progress < newProgress) {
                _gameData.Progress = newProgress;
            }
            //Debug.Log(_gameData.Progress);
        }

        private void OnDrawGizmos() {
            Gizmos.color = new Color(0, 1, 0, .5f);
            Gizmos.DrawCube(new Vector3(0, transform.position.y, _startPos), new Vector3(5, 1, .5f));

            Gizmos.color = new Color(1, 0, 0, .5f);
            Gizmos.DrawCube(new Vector3(0, transform.position.y, _endPos), new Vector3(5, 1, .5f));
        }
    } 
}
