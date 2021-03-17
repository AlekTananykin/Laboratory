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
            try
            {
                new GameInitialization(_interactiveStorage, _gameData);

                _interactiveStorage.Initialization();
            }
            catch (GameException ge)
            {
                Debug.Log(ge.Data);
            }
        }

        void Update()
        {
            try
            {
                _interactiveStorage.Execute(Time.deltaTime);
            }
            catch (GameException ge)
            {
                Debug.LogError(ge.Data);
            }
        }

        void LateUpdate()
        {
            try
            {
                _interactiveStorage.LateExecute(Time.deltaTime);
            }
            catch (GameException ge)
            {
                Debug.LogError(ge.Data);
            }
        }

        void OnDestroy()
        {
            _interactiveStorage.Cleanup();
        }
    }
}
