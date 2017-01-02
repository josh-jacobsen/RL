using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RLTutorial
{
    class RLTutorialProgram
    {
        private static bool quit = false;
        private const int screenWidth = 80;
        private const int screenHeight = 24;
        private static int playerX;
        private static int playerY;

        static void Main(string[] args)
        {
            // Register Ctrl+C Event Handler
            Console.CancelKeyPress += ConsoleOnCancelKeyPress;
            Console.CursorVisible = false;

            // Initialize game variables
            InitilizeGame();

            // Enter game loop
            GameLoop();
        }

        private static void GameLoop()
        {
            while (!quit)
            {
                // Sleep for a short period at the end of each loop
                Thread.Sleep(100);

                //Render section
                // Clear the console
                Console.Clear();
                //Draw the player in the current position in white
                Console.SetCursorPosition(playerX, playerY);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write('@');

                // Update section
                // Wait for a key press and don't display key in the console
                ConsoleKeyInfo character = Console.ReadKey(true);
                // Handle the player input
                switch (character.KeyChar)
                {
                    case 'i':
                        playerY -= 1;
                        break;
                    case 'j':
                        playerX -= 1;
                        break;
                    case 'k':
                        playerX += 1;
                        break;
                    case 'm':
                        playerY += 1;
                        break;
                    case 'q':
                        quit = true;
                        break;
                }
                // Ensure player is still on screen
                // Ensure player is still on the screen
                
                if (playerX < 0)
                  playerX = 0;
                if (playerX > screenWidth - 1)
                  playerX = screenWidth - 1;
                if (playerY < 0)
                  playerY = 0;
                if (playerY > screenHeight - 1)
                  playerY = screenHeight - 1;
            }
        }

        private static void InitilizeGame()
        {
            // Set window size
            Console.SetWindowSize(screenWidth, screenHeight);
            Console.SetBufferSize(screenWidth, screenHeight);

            // Set initial player position to centre of screeen
            playerX = screenWidth / 2;
            playerY = screenHeight / 2;

        }

        private static void ConsoleOnCancelKeyPress(object sender, ConsoleCancelEventArgs consoleCancelEventArgs)
        {
            quit = true;
            consoleCancelEventArgs.Cancel = true;
        }
    }
}
