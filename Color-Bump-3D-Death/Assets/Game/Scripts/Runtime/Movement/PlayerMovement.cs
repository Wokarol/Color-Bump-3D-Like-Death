using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] float _speed;
        //[SerializeField] float _constantForce = 0.5f;

        Rigidbody _rigidbody;

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
