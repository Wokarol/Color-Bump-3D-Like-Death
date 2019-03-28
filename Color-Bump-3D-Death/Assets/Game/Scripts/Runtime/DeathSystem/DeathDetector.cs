using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
    /// <summary>
    /// Detects if object touched Obstacle and if, spawns fractured version, raises "Player Died" message and disables itself
    /// </summary>
    public class DeathDetector : MonoBehaviour
    {
        [SerializeField] FracturedObject fracturedPrefab = default;
        [SerializeField] Cinemachine.CinemachineImpulseSource _impulse = default;

        Rigidbody _rigidbody;

        private void Start() {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision collision) {
            if (collision.collider.CompareTag("Obstacle")) {
                // Can be optimised using Object Pooling
                var ball = Instantiate(fracturedPrefab, transform.position, Quaternion.identity).Init(_rigidbody.velocity);

                _impulse.GenerateImpulse();
                MessageSystem.Messenger.Default.SendMessage(new PlayerDied());
                gameObject.SetActive(false);
            }
        }
    }
}
