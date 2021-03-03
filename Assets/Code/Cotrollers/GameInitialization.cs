namespace Lab
{
    internal class GameInitialization
    {
        public GameInitialization(
            Controllers controllers, GameData gameData)
        {
            IPlayerInput playerInput = new PlayerPcInput();
            controllers.Add(playerInput);

            Player player = new Player(gameData.Player, playerInput);
            controllers.Add(player);


        }
    }
}