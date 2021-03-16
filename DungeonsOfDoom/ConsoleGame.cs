using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class ConsoleGame
    {
        Player player;
        Room[,] world;
        Random random = new Random();

        public void Play()
        {
            CreatePlayer();
            CreateWorld();

            do
            {
                Console.Clear();
                DisplayWorld();
                DisplayStats();
                AskForMovement();
            } while (player.IsAlive);

            GameOver();
        }

        private void CreatePlayer()
        {
            player = new Player(30, 0, 0);
        }

        private void CreateWorld()
        {
            world = new Room[20, 5];
            for (int y = 0; y < world.GetLength(1); y++)
            {
                for (int x = 0; x < world.GetLength(0); x++)
                {
                    world[x, y] = new Room();

                    int percentage = random.Next(0, 100);
                    if (percentage < 5)
                    {
                        world[x, y].Monster = new Ogre();
                    }
                    else if (percentage < 10)
                    {
                        world[x, y].Monster = new Skeleton();
                    }
                    else if (percentage < 15)
                    {
                        world[x, y].Item = new Health();
                    }
                    else if (percentage < 20)
                    {
                        world[x, y].Item = new Sword();
                    }
                }
            }
        }

        private void DisplayWorld()
        {
            GameName();
            for (int y = 0; y < world.GetLength(1); y++)
            {
                for (int x = 0; x < world.GetLength(0); x++)
                {
                    Room room = world[x, y];
                    if (player.X == x && player.Y == y)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write("☼"); //put player here
                    }

                    else if (room.Monster != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("[Θ]"); //put monster here
                    }
                    else if (room.Item != null)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("[♥]"); // put item here
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("[]"); //display empty room
                    }
                }
                Console.WriteLine();
            }
        }

       

        private void DisplayStats()
        {
            Console.WriteLine($"Health: {player.Health}");

            //backpack info
            foreach (Item item in player.Backpack)
            {
                Console.WriteLine(item.Name);
            }
        }

        private void AskForMovement()
        {
            int newX = player.X;
            int newY = player.Y;
            bool isValidKey = true;

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.RightArrow: newX++; break;
                case ConsoleKey.LeftArrow: newX--; break;
                case ConsoleKey.UpArrow: newY--; break;
                case ConsoleKey.DownArrow: newY++; break;
                default: isValidKey = false; break;
            }

            if (isValidKey &&
                newX >= 0 && newX < world.GetLength(0) &&
                newY >= 0 && newY < world.GetLength(1))
            {
                player.X = newX;
                player.Y = newY;

                //discover what is inside room
                EnterRoom();
            }
        }

        private void EnterRoom()
        {
            //get current room
            Room currentRoom = world[player.X, player.Y];

            /*
             * If there's a monster, the monster attacks first, if the
               players survive, the player gets to attack.
             */
            Monster monster = currentRoom.Monster;
            if (monster != null)
            {
                AttackResult result = monster.Attack(player);
                Console.WriteLine($"Player was damaged by monster:  {result.DamageDealt}");
                Console.ReadKey(true);

                if (player.IsAlive)
                {
                    result = player.Attack(monster);
                    Console.WriteLine($"Player damage monster by:  {result.DamageDealt}");
                    Console.ReadKey(true);
                }

                if (!monster.IsAlive)
                {
                    /* as monster is a local variable so monster = null will be no impact on the game
                     so use currentRoom.Monster = null instead of monster = null*/
                    currentRoom.Monster = null;
                }
            }

            if (player.IsAlive && currentRoom.Item != null)
            {
                //add item un player's backpack
                player.Backpack.Add(currentRoom.Item);

                // if item is sword then player will have +1 heath and if item is Medkit then +10 health
                currentRoom.Item.Use(player);

                //remove that item from room
                currentRoom.Item = null;
            }
        }

        private void GameOver()
        {
            Console.Clear();
            Console.WriteLine("Game over...");
            Console.ReadKey();
            Play();
        }


        private void GameName()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(@"
 

                ██████╗░░█████╗░██████╗░░█████╗░██╗
                ██╔══██╗██╔══██╗██╔══██╗██╔══██╗██║
                ██████╦╝███████║██████╦╝███████║██║
                ██╔══██╗██╔══██║██╔══██╗██╔══██║██║
                ██████╦╝██║░░██║██████╦╝██║░░██║██║
                ╚═════╝░╚═╝░░╚═╝╚═════╝░╚═╝░░╚═╝╚═╝
");
            Console.WriteLine();
        }
    }
}
