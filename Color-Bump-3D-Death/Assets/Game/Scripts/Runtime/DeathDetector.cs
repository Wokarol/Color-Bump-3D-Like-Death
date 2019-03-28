using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
    public class DeathDetector : MonoBehaviour
    {
        [SerializeField] FracturedSphere brokenBall;

        Rigidbody _rigidbody;

        private void Start() {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision collision) {
            if (collision.collider.CompareTag("Obstacle")) {
                var ball = Instantiate(brokenBall, transform.position, Quaternion.identity).Init(_rigidbody.velocity);
                MessageSystem.Messenger.Default.SendMessage(new PlayerDied());
                gameObject.SetActive(false);
            }
        }
    }
}
