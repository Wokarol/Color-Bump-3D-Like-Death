using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
    public class FracturedSphere : MonoBehaviour
    {
        [SerializeField] Rigidbody[] _fractures;
        [SerializeField] float _force = 1.2f;

        public FracturedSphere Init(Vector3 dir) {
            dir = dir.normalized;
            for (int i = 0; i < _fractures.Length; i++) {
                _fractures[i].velocity = dir * _force;
            }

            return this;
        }
    } 
}
