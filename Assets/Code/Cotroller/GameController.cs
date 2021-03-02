using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lab
{
    public sealed class GameController : MonoBehaviour
    {
        [SerializeField] private Data _data;
        private Controllers _controllers;

        GameController()
        {
            _controllers = new Controllers();
        }

        private void Awake()
        {
            new GameInitialization(_controllers, _data);
        }

        void Start()
        {
            _controllers.Initialization();
        }

        void Update()
        {
            _controllers.Execute(Time.deltaTime);
        }

        void LateUpdate()
        {
            _controllers.LateExecute(Time.deltaTime);
        }

        private void OnDestroy()
        {
            _controllers.Cleanup();
        }
    }
}
