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
        [SerializeField] Camera _mainCamera;
        [SerializeField] float _planeHeight;
        private Vector3 _mousePosition;
        private Vector3 _mouseOffset;

        private void OnValidate() {
            _playerMovement = GetComponent<PlayerMovement>();
        }

        private void Start() {
            _mousePosition = _mainCamera.WorldToScreenPoint(transform.position + Vector3.forward * 0.5f);
            _mouseOffset = Vector3.zero;
        }

        private void Update() {
            CheckMousePos();

            // Calculates distance to Y alighned plane
            Ray mouseRay = _mainCamera.ScreenPointToRay(_mousePosition + _mouseOffset);
            float planeHeight = _planeHeight;
            float dst = (_planeHeight - mouseRay.origin.y) / mouseRay.direction.y;

            // Sets TargetPosition in PlayerMovement based on distance along mouseRay
            var target = mouseRay.GetPoint(dst);
            _playerMovement.TargetPosition = target;
        }

        /// <summary>
        /// Updates mousePosition based on some if statements
        /// </summary>
        private void CheckMousePos() {
            Vector3 newMousePosition = Input.mousePosition;
            // Checks if mouse is inside the screen
            if (newMousePosition.x > 0 && newMousePosition.x < Screen.width &&
                newMousePosition.y > 0 && newMousePosition.y < Screen.height) {
                // Ckecks if mouse is held down
                if (Input.GetMouseButton(0)) {
                    _mousePosition = newMousePosition;
                }

                // Check if mouse was pressed in this frame and sets offset if so
                if (Input.GetMouseButtonDown(0)) {
                    var ballPos = _mainCamera.WorldToScreenPoint(transform.position + Vector3.forward * 0.5f);
                    _mouseOffset = ballPos - Input.mousePosition;
                }
            }
        }

        private void OnDrawGizmosSelected() {
            // Draws plane height
            Gizmos.color = new Color(.8f, .8f, .8f, 0.5f);
            Gizmos.DrawCube(new Vector3(transform.position.x, _planeHeight, transform.position.z), new Vector3(5, .1f, 5));
        }
    }
}
