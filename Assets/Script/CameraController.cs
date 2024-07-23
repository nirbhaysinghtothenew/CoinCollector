using Manager;
using UnityEngine;

namespace Script
{
    public class CameraController : MonoBehaviour
    {
        public Transform car;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                transform.position = car.position + new Vector3(10, 8, -20);
            }
        }

        private void FixedUpdate()
        {
            //transform.LookAt(car);
            transform.position = car.position + new Vector3(0, 8, -20);

        }

        public void GoTo(Vector3 position)
        {
            transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime);
        }
    
    
    }
}
