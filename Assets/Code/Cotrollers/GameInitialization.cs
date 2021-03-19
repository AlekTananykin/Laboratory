using System;
using UnityEngine;
using DangerouseItems;
namespace Lab
{
    internal class GameInitialization
    {
        public GameInitialization(
            InteractiveStorage interactiveStorage, 
            IPlayerInput playerInput)
        {            
            interactiveStorage.Add(playerInput);

            GameObjectFabric fabric = new GameObjectFabric();
            InitializePlayer(
                interactiveStorage, fabric, playerInput);
            InitializeBoxSupply(interactiveStorage, fabric);
            InitializeBoxAmmo(interactiveStorage, fabric);
            InitializeBoxAidKid(interactiveStorage, fabric);
            InitializeProximityCard(interactiveStorage, fabric);
            InitializeMine(interactiveStorage, fabric);
            InitializeMiniMap(interactiveStorage, fabric);
        }

        private void InitializeMiniMap(
            InteractiveStorage interactiveStorage, GameObjectFabric fabric)
        {
            var minimapObject = fabric.GetMiniMapCamera();
            MiniMapView mimiMapView = minimapObject.GetComponent<MiniMapView>();
            interactiveStorage.Add(mimiMapView);
        }

        private void InitializeProximityCard(
            InteractiveStorage interactiveStorage, 
            GameObjectFabric fabric)
        {
                LinkCopmponents<ProximityCard, SupplyModel>(
                fabric.GetProximityCard(), interactiveStorage);
        }

        private void InitializeMine(InteractiveStorage interactiveStorage, 
            GameObjectFabric fabric)
        {
                LinkCopmponents<MineView, BombModel>(
                    fabric.GetMine(), interactiveStorage);
        }

        private void InitializeBoxSupply(InteractiveStorage interactiveStorage, 
            GameObjectFabric fabric)
        {
                LinkCopmponents<SupplyKidView, SupplyModel>(
                fabric.GetSupplyBox(), interactiveStorage);
        }

        private void InitializeBoxAmmo(InteractiveStorage interactiveStorage,
           GameObjectFabric fabric)
        {
                LinkCopmponents<AmmoBoxView, SupplyModel>(
                fabric.GetAmmoBox(), interactiveStorage);
        }

        private void InitializeBoxAidKid(InteractiveStorage interactiveStorage,
           GameObjectFabric fabric)
        {
                LinkCopmponents<FirstAidKidView, SupplyModel>(
                fabric.GetAidKidBox(), interactiveStorage);
        }

        private void LinkCopmponents<V, M>(
            GameObject go, IInteractionStorage storage)
            where V: ViewHandle<M> 
        {
            V viewHandle = go.GetComponent<V>();
            storage.Add(viewHandle);
        }

        void InitializePlayer(InteractiveStorage interactiveStorage, 
            GameObjectFabric fabric, IPlayerInput playerInput)
        {
            var playerObject = fabric.GetPlayer();
            PlayerView playerView = playerObject.GetComponent<PlayerView>();
            playerView.SetInput(playerInput);
            interactiveStorage.Add(playerView);
        }
    }
}