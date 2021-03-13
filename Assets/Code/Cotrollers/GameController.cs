using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lab
{
    public sealed class GameController : MonoBehaviour
    {
        [SerializeField] private GameData _gameData;

        
        InteractiveStorage _interactiveStorage;

        GameController()
        {
            _interactiveStorage = new InteractiveStorage();
        }

        void Start()
        {
            new GameInitialization(_interactiveStorage, _gameData);

            _interactiveStorage.Initialization();
        }

        void Update()
        {
            _interactiveStorage.Execute(Time.deltaTime);
        }

        void LateUpdate()
        {
            _interactiveStorage.LateExecute(Time.deltaTime);
        }

        void OnDestroy()
        {
            _interactiveStorage.Cleanup();
        }
    }
}
