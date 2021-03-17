using System;
using UnityEngine;
using DangerouseItems;
namespace Lab
{
    internal class GameInitialization
    {
        public GameInitialization(
            InteractiveStorage interactiveStorage, GameModel gameModel, 
            IPlayerInput playerInput)
        {
            
            interactiveStorage.Add(playerInput);

            InitializeGameSaver(
                interactiveStorage, gameModel, playerInput);

            GameObjectFabric fabric = new GameObjectFabric();
            InitializePlayer(
                interactiveStorage, gameModel, fabric, playerInput);
            InitializeBoxSupply(interactiveStorage, gameModel, fabric);
            InitializeBoxAmmo(interactiveStorage, gameModel, fabric);
            InitializeBoxAidKid(interactiveStorage, gameModel, fabric);
            InitializeProximityCard(interactiveStorage, gameModel, fabric);
            InitializeMine(interactiveStorage, gameModel, fabric);
        }

        private void InitializeGameSaver(InteractiveStorage interactiveStorage, 
             GameModel gameModel, IPlayerInput playerInput)
        {
            GameSaver gameSaver = new GameSaver(playerInput, gameModel);
            interactiveStorage.Add(gameSaver);
        }

        private void InitializeProximityCard(
            InteractiveStorage interactiveStorage, 
            GameModel gameModel, GameObjectFabric fabric)
        {
            LinkCopmponents<ProximityCard, SupplyModel>(
                fabric.GetProximityCard(), 
                gameModel.ProximityCardModel, interactiveStorage);
        }

        private void InitializeMine(InteractiveStorage interactiveStorage, 
            GameModel gameModel, GameObjectFabric fabric)
        {
            LinkCopmponents<MineView, BombModel>(
                fabric.GetMine(), gameModel.Bomb, interactiveStorage);
        }

        private void InitializeBoxSupply(InteractiveStorage interactiveStorage, 
            GameModel gameModel, GameObjectFabric fabric)
        {
            LinkCopmponents<SupplyKidView, SupplyModel>(
                fabric.GetSupplyBox(), gameModel.SupplyBox, interactiveStorage);
        }

        private void InitializeBoxAmmo(InteractiveStorage interactiveStorage,
           GameModel gameModel, GameObjectFabric fabric)
        {
            LinkCopmponents<AmmoBoxView, SupplyModel>(
                fabric.GetAmmoBox(), gameModel.AmmoBox, interactiveStorage);
        }

        private void InitializeBoxAidKid(InteractiveStorage interactiveStorage,
           GameModel gameModel, GameObjectFabric fabric)
        {
            LinkCopmponents<FirstAidKidView, SupplyModel>(
                fabric.GetAidKidBox(), gameModel.AidBoxModel, interactiveStorage);
        }

        private void LinkCopmponents<V, M>(
            GameObject go, M model, IInteractionStorage storage)
            where V: ViewHandle<M> 
        {
            V viewHandle = go.GetComponent<V>();
            viewHandle.SetSettings(model, storage);
            storage.Add(viewHandle);
        }

        void InitializePlayer(InteractiveStorage interactiveStorage, 
            GameModel gameModel, GameObjectFabric fabric, IPlayerInput playerInput)
        {
            var playerObject = fabric.GetPlayer();
            PlayerView playerView = playerObject.GetComponent<PlayerView>();

            playerView.SetModelAndInput(gameModel.Player, playerInput);
            interactiveStorage.Add(playerView);
        }
    }
}