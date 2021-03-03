namespace Lab
{
    internal class GameInitialization
    {
        public GameInitialization(
            Controllers controllers, GameData gameData)
        {
            Player player = new Player(gameData.Player);
            controllers.Add(player);


        }
    }
}