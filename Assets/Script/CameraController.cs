using System;
using Manager;
using Unity.VisualScripting;
using UnityEngine;

namespace Script
{
    public class CameraController : MonoBehaviour
    {
        public Transform car;
        public Camera camera1;
        public Camera camera2;


        private void Start()
        {
            camera1.enabled = false;
            camera2.enabled = true;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.C)) {
                camera1.enabled = !camera1.enabled;
                camera2.enabled = !camera2.enabled;
            }
        }

        private void FixedUpdate()
        {
            if (camera1.enabled)
            {
                //transform.LookAt(car);
                transform.position = car.position + new Vector3(0, 8, -20);
            }

            if (camera2.enabled)
            {
                transform.position = car.position + new Vector3(0.6f, 2, -20);
            }

        }

        public void GoTo(Vector3 position)
        {
            transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime);
        }
    }
}
