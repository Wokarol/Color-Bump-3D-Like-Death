using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
    [RequireComponent(typeof(Cinemachine.CinemachineDollyCart))]
    public class CameraDollyController : MonoBehaviour
    {
        Cinemachine.CinemachineDollyCart _cart;

        private void Start() {
            _cart = GetComponent<Cinemachine.CinemachineDollyCart>();
            MessageSystem.Messenger.Default.RegisterSubscriberTo<PlayerDied>(OnPlayerDied);
        }

        private void OnPlayerDied(PlayerDied e) {
            _cart.m_Speed = 0;
        }
    } 
}
