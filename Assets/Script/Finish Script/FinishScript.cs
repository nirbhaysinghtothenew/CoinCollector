using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


enum FinishAnimationTrigger
{
   Ideal,
   Collide
}
public class FinishScript : MonoBehaviour
{
   [SerializeField] private Animator _animator;

   private void Start()
   {
      _animator.SetTrigger(FinishAnimationTrigger.Ideal.ToString());
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag(Tags.Car.ToString()))
      {
         _animator.SetTrigger(FinishAnimationTrigger.Collide.ToString());
      }
   }
}
