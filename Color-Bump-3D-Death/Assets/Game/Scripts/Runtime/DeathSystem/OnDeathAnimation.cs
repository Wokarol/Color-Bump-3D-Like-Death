using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
    /// <summary>
    /// Sets trigger when "Player Died" is raised
    /// </summary>
    [RequireComponent(typeof(Animator))]
    public class OnDeathAnimation : MonoBehaviour
    {
        [SerializeField] string _trigger = default;

        Animator _animator;
        int _hash;

        private void Start() {
            MessageSystem.Messenger.Default.RegisterSubscriberTo<PlayerDied>(OnPlayerDeath);
            _animator = GetComponent<Animator>();
            _hash = Animator.StringToHash(_trigger);
        }

        private void OnDestroy() {
            MessageSystem.Messenger.Default.UnRegisterAllSubscribersForObjects(this);
        }

        private void OnPlayerDeath(PlayerDied e) {
            _animator.SetTrigger(_trigger);
        }
    } 
}
