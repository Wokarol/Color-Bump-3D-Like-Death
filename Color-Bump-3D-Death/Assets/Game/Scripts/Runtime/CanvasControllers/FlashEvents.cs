using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Wokarol
{
    /// <summary>
    /// Handles Animation Events for screen flashing
    /// </summary>
    public class FlashEvents : MonoBehaviour
    {
        [SerializeField] UnityEvent _flashRaised = new UnityEvent();

        public void FlashRaised() {
            _flashRaised.Invoke();
        }
    } 
}
