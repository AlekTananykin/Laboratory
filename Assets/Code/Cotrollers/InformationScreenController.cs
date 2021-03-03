using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lab
{
    public sealed class InformationScreenController : ILateExecute
    {
        private GameObject _screenView;
        private InformationScreenView _viewHandler;


        public InformationScreenController(GameData data)
        {
            _screenView = GameObject.Instantiate(data._informationScreen);
            _viewHandler = _screenView.GetComponent<InformationScreenView>();
        }

        public void Cleanup()
        {
            throw new System.NotImplementedException();
        }

        public void LateExecute(float deltaTime)
        {
            Debug.Log("LateExecute");
        }
    }
}