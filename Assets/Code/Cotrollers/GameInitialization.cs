using UnityEngine;

namespace Lab
{
    internal class GameInitialization
    {
        public GameInitialization(
            InteractiveStorage controllers, GameData gameData)
        {
            GameObjectFabric fabric = new GameObjectFabric();

            IPlayerInput playerInput = new PlayerPcInput();
            controllers.Add(playerInput);

            var playerObject = fabric.GetPlayer();
            PlayerView playerView = playerObject.GetComponent<PlayerView>();

            playerView.SetModelAndInput(gameData.Player, playerInput);
            controllers.Add(playerView);

            var supplyBox = fabric.GetSupplyBox();
            
            
        }
    }
}