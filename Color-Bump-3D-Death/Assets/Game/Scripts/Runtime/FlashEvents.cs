using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlashEvents : MonoBehaviour
{
    [SerializeField] UnityEvent _flashRaised;

    public void FlashRaised() {
        _flashRaised.Invoke();
    }
}
