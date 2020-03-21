using GarbageCardGame.View;
using GarbageCardGame.Controller;

namespace GarbageCardGame
{
    class MainApp
    {
        static void Main(string[] args)
        {
            ViewGarbage View = new ViewGarbage();
            GameController Game = new GameController();

            View.Print("Welcome to the game.\nThe cards are already dealt.\nIt is Player1 turn...");
            System.Threading.Thread.Sleep(3000);
            while (!Game.AnyPlayerHasWon())
            {
                Game.PlayRound(Game.Player1, Game.Player2);
            }
            Game.EndGameScenario();
        }
    }
}
