using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
    /// <summary>
    /// Handles Player Movement without input
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] float _speed = default;

        Rigidbody _rigidbody;

        /// <summary>
        /// Player Movement will try to go to that position
        /// </summary>
        public Vector3 TargetPosition { get; set; }

        private void Awake() {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate() {
            var direction = (TargetPosition - _rigidbody.position).normalized;

            _rigidbody.AddForce(direction * _speed);
        }
    } 
}
