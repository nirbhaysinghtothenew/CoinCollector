using System;
using UnityEngine;

namespace Script.Piramid
{
    enum PiramidScriptTrigger
    {
        Ideal,
        Collide
    }
    
    public class PiramidScript: MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private void Start()
        {
            _animator.SetTrigger(PiramidScriptTrigger.Ideal.ToString());
        }
        
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Car.ToString()))
            {
                _animator.SetTrigger(PiramidScriptTrigger.Collide.ToString());
            }
        }
    }
}