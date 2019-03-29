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
        [SerializeField] float _maxSpeedAtDistance = default;

        Rigidbody _rigidbody;

        /// <summary>
        /// Player Movement will try to go to that position
        /// </summary>
        public Vector3 TargetPosition { get; set; }
        public float Speed => _speed;

        private void Awake() {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate() {
            var difference = TargetPosition - _rigidbody.position;
            _rigidbody.AddForce(difference.normalized * Mathf.Clamp01(difference.magnitude / _maxSpeedAtDistance) * _speed);

            //_rigidbody.AddForce(direction * _speed);
        }

        private void OnDrawGizmos() {
            Gizmos.DrawWireSphere(TargetPosition, 0.4f);
        }
    } 
}
