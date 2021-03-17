using System;
using UnityEngine;
using DangerouseItems;
namespace Lab
{
    internal class GameInitialization
    {
        public GameInitialization(
            InteractiveStorage interactiveStorage, GameData gameData)
        {
            IPlayerInput playerInput = new PlayerPcInput();
            interactiveStorage.Add(playerInput);

            InitializeGameSaver(
                interactiveStorage, gameData, playerInput);

            GameObjectFabric fabric = new GameObjectFabric();
            InitializePlayer(
                interactiveStorage, gameData, fabric, playerInput);
            InitializeBoxSupply(interactiveStorage, gameData, fabric);
            InitializeBoxAmmo(interactiveStorage, gameData, fabric);
            InitializeBoxAidKid(interactiveStorage, gameData, fabric);
            InitializeProximityCard(interactiveStorage, gameData, fabric);
            InitializeMine(interactiveStorage, gameData, fabric);
        }

        private void InitializeGameSaver(InteractiveStorage interactiveStorage, 
            GameData gameData, IPlayerInput playerInput)
        {
            GameSaver gameSaver = new GameSaver(playerInput, gameData);
            interactiveStorage.Add(gameSaver);
        }

        private void InitializeProximityCard(
            InteractiveStorage interactiveStorage, 
            GameData gameData, GameObjectFabric fabric)
        {
            LinkCopmponents<ProximityCard, SupplyModel>(
                fabric.GetProximityCard(), 
                gameData.ProximityCartModel, interactiveStorage);
        }

        private void InitializeMine(InteractiveStorage interactiveStorage, 
            GameData gameData, GameObjectFabric fabric)
        {
            LinkCopmponents<MineView, BombData>(
                fabric.GetMine(), gameData.BombData, interactiveStorage);
        }

        private void InitializeBoxSupply(InteractiveStorage interactiveStorage, 
            GameData gameData, GameObjectFabric fabric)
        {
            LinkCopmponents<SupplyKidView, SupplyModel>(
                fabric.GetSupplyBox(), gameData.SupplyBox, interactiveStorage);
        }

        private void InitializeBoxAmmo(InteractiveStorage interactiveStorage,
           GameData gameData, GameObjectFabric fabric)
        {
            LinkCopmponents<AmmoBoxView, SupplyModel>(
                fabric.GetAmmoBox(), gameData.AmmoBox, interactiveStorage);
        }

        private void InitializeBoxAidKid(InteractiveStorage interactiveStorage,
           GameData gameData, GameObjectFabric fabric)
        {
            LinkCopmponents<FirstAidKidView, SupplyModel>(
                fabric.GetAidKidBox(), gameData.AidBoxModel, interactiveStorage);
        }

        private void LinkCopmponents<V, M>(
            GameObject go, M model, IInteractionStorage storage)
            where V: ViewHandle<M> 
            where M: ScriptableObject
        {
            V viewHandle = go.GetComponent<V>();
            viewHandle.SetSettings(model, storage);
            storage.Add(viewHandle);
        }

        void InitializePlayer(InteractiveStorage interactiveStorage, 
            GameData gameData, GameObjectFabric fabric, IPlayerInput playerInput)
        {
            var playerObject = fabric.GetPlayer();
            PlayerView playerView = playerObject.GetComponent<PlayerView>();

            playerView.SetModelAndInput(gameData.Player, playerInput);
            interactiveStorage.Add(playerView);
        }
    }
}