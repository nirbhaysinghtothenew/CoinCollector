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
        [SerializeField] private Animator animator;

        private void Start()
        {
            animator.SetTrigger(PiramidScriptTrigger.Ideal.ToString());
        }
        
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Car.ToString()))
            {
                animator.SetTrigger(PiramidScriptTrigger.Collide.ToString());
            }
        }
    }
}