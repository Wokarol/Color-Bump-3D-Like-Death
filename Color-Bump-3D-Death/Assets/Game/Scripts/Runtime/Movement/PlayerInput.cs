using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
    /// <summary>
    /// Handles only Player Input 
    /// </summary>
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] PlayerMovement _playerMovement = null;

        private void OnValidate() {
            _playerMovement = GetComponent<PlayerMovement>();
        }

        private void Update() {
            var target = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            _playerMovement.TargetPosition = transform.position + target;
        }
    } 
}
