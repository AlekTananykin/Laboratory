using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lab
{
    public class PlayerView : MonoBehaviour, IPlayerView
    {
        private CharacterController _charController;
        private Camera _camera;

        void Awake()
        {
            _camera = GameObject.FindGameObjectWithTag(
                "PlayerCamera").GetComponent<Camera>();

            _charController = GetComponent<CharacterController>();
        }

        public bool IsGrounded()
        {
            return _charController.isGrounded;
        }

        public Ray GetCameraRay()
        {
            Vector3 point = new Vector3(
                    _camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);

            return _camera.ScreenPointToRay(point);
        }

        public Vector3 Position
        {
            get
            {
                return transform.position;
            }
            set
            {
                _charController.Move(value);
            }
        }

        public void CameraTilt(float tilt)
        {
            _camera.transform.localEulerAngles = new Vector3(tilt, 0, 0);
        }

        public void AngleOfRotation(float rotationDelta)
        {
            float rotationY = transform.localEulerAngles.y + rotationDelta;
            transform.localEulerAngles = new Vector3(0, rotationY, 0);
        }

    }
}
