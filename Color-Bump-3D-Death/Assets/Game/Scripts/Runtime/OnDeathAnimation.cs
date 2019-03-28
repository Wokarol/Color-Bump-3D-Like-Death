using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
    [RequireComponent(typeof(Animator))]
    public class OnDeathAnimation : MonoBehaviour
    {
        [SerializeField] string _trigger;

        Animator _animator;

        private void Start() {
            MessageSystem.Messenger.Default.RegisterSubscriberTo<PlayerDied>(OnPlayerDeath);
            _animator = GetComponent<Animator>();
        }

        private void OnDestroy() {
            MessageSystem.Messenger.Default.UnRegisterAllSubscribersForObjects(this);
        }

        private void OnPlayerDeath(PlayerDied e) {
            _animator.SetTrigger(_trigger);
        }
    } 
}
