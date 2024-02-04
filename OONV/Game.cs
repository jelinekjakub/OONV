using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;

namespace OONV
{
    class Game
    {
        static void Main()
        {
            UserInterface.ShowMenu();
            int choice = UserInterface.GetMenuChoice();
            if (choice == 1 )
            {
                Player? player = null;
                do
                {
                    Arena arena1 = ArenaFactory.CreateArena1();
                    arena1.Player = player;
                    player = arena1.StartGame();
                } while (player != null && !player.GetAlive());
                do
                {
                    Arena arena2 = ArenaFactory.CreateArena2();
                    arena2.Player = player;
                    player = arena2.StartGame();
                } while (player != null && !player.GetAlive());
                do
                {
                    Arena arena3 = ArenaFactory.CreateArena3();
                    arena3.Player = player;
                    player = arena3.StartGame();
                } while (player != null && !player.GetAlive());
            } 
            else if (choice == 2 )
            {
                UserInterface.ShowAuthor();
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
