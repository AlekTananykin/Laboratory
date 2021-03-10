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
            GameObjectFabric fabric = new GameObjectFabric();

            InitializePlayer(interactiveStorage, gameData, fabric);
            InitializeBoxSupply(interactiveStorage, gameData, fabric);
            InitializeBoxAmmo(interactiveStorage, gameData, fabric);
            InitializeBoxAidKid(interactiveStorage, gameData, fabric);
            InitializeMine(interactiveStorage, gameData, fabric);
        }

        private void InitializeMine(InteractiveStorage interactiveStorage, 
            GameData gameData, GameObjectFabric fabric)
        {
            GameObject mine = fabric.GetMine();
            MineView mineView = mine.GetComponent<MineView>();
            mineView.SetModel(gameData.BombData);
            interactiveStorage.Add(mineView);
        }

        private void InitializeBoxSupply(InteractiveStorage interactiveStorage, 
            GameData gameData, GameObjectFabric fabric)
        {
            GameObject supply = fabric.GetSupplyBox();
            SupplyKidView supplyView = supply.GetComponent<SupplyKidView>();
            supplyView.SetModel(gameData.SupplyBox);
            interactiveStorage.Add(supplyView);
        }

        private void InitializeBoxAmmo(InteractiveStorage interactiveStorage,
           GameData gameData, GameObjectFabric fabric)
        {
            GameObject ammo = fabric.GetAmmoBox();
            AmmoBoxView ammoView = ammo.GetComponent<AmmoBoxView>();
            ammoView.SetModel(gameData.AmmoBox);
            interactiveStorage.Add(ammoView);
        }

        private void InitializeBoxAidKid(InteractiveStorage interactiveStorage,
           GameData gameData, GameObjectFabric fabric)
        {
            GameObject aidKid = fabric.GetAidKidBox();
            FirstAidKidView aidKidView = aidKid.GetComponent<FirstAidKidView>();
            aidKidView.SetModel(gameData.AidBoxModel);
            interactiveStorage.Add(aidKidView);
        }

        void InitializePlayer(InteractiveStorage interactiveStorage, 
            GameData gameData, GameObjectFabric fabric)
        {
            IPlayerInput playerInput = new PlayerPcInput();
            interactiveStorage.Add(playerInput);

            var playerObject = fabric.GetPlayer();
            PlayerView playerView = playerObject.GetComponent<PlayerView>();

            playerView.SetModelAndInput(gameData.Player, playerInput);
            interactiveStorage.Add(playerView);
        }

    }
}