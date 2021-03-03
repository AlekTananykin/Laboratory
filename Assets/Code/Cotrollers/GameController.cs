using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lab
{
    public sealed class GameController : MonoBehaviour
    {
        [SerializeField] private GameData _gameData;


        Controllers _controllers;

        GameController()
        {
            _controllers = new Controllers();
        }

        private void Awake()
        {
           
        }

        void Start()
        {
            new GameInitialization(_controllers, _gameData);

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
