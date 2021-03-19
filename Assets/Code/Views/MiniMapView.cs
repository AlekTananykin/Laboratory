using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lab
{
    public class MiniMapView : MonoBehaviour, IInitialization, ILateExecute
    {
        private Transform _player;
        SupplyModel _model;
        public void Initialization(GameModel model)
        {
            _model = model.MiniMapCameraModel;

            _player = GameObject.FindGameObjectWithTag(
               "PlayerCamera").GetComponent<Camera>().transform;

            transform.parent = null;
            transform.rotation = Quaternion.Euler(90.0f, 0, 0);
            transform.position = _player.position + new Vector3(0, 5.0f, 0);
            _model._position = transform.position;

            //var rt = Resources.Load<RenderTexture>("MiniMap/MiniMapTexture");

            //GetComponent<Camera>().targetTexture = rt;
        }

        public void LateExecute(float deltaTime)
        {
            transform.position = _player.position + new Vector3(0, 5.0f, 0);
            transform.rotation = Quaternion.Euler(90, _player.eulerAngles.y, 0);
            _model._position = transform.position;
        }
    }
}