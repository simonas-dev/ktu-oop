using System;

namespace SpaceInvaders.Business.Contracts
{
    public static class Contracts
    {
        public const string AddProfileCommand = "AddProfile";
        public const string SelectProfileCommand = "SelectProfile";

        public const string GameView = "GameView";
        public const string HomeView = "HomeView";
        public const string MenuView = "MenuView";

        public const string HomeController = "HomeController";
        public const string GameController = "GameController";

        public const string InitializeGame = "InitGame";
        public const string RefreshGameView = "RefreshGame";

        public const int WindowSizeWidth = 160;
        public const int WindowSizeHeight = 40;

        public const int GameSizeWidth = 120;
        public const int GameSizeHeight = 30;
    }
}
