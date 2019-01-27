using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_based_game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to game");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Please input your name");
            Console.WriteLine("__________________________________");
            string name = Console.ReadLine();
            Console.Clear();
            //Variables used
            bool battle = false;
            bool quit = false;
            bool Menu = true;
            int playerStr = 10;
            int playerSpd = 10;
            int playerDef = 10;
            int playerHealth = 10;
            int monsterHealth = 10;
            int monsterStr = 10;
            int monsterSpd = 5;
            int monsterDef = 10;
            int playerDefSlot = 0;
            int monsterDefSlot = 0;
            int playerAttackSlot = 0;
            int monsterAttackSlot = 0;
            int gambleChance = 0;

            string battleChoice;
            int monsterChoice;

            Random rnd = new Random();
            //main program
            while (quit == false)
            {
                //For main menu
                while (Menu == true)
                {
                    Console.WriteLine("CAMP MENU");
                    Console.WriteLine("1.Fight");
                    Console.WriteLine("2.Upgrade");
                    Console.WriteLine("3.Quit");
                    Console.WriteLine("__________________________________");
                    string choice = Console.ReadLine();
                    Console.Clear();
                    //For Fight loop
                    if (choice == "1")
                    {
                        battle = true;
                        Menu = false;
                    }
                    //for quit
                    if (choice == "3")
                    {
                        Menu = false;
                        quit = true;
                    }
                    

                }
                while (battle == true)
                {
                    if (quit == true) battle = false;
                    //bool monsterTurn = false;
                    //while (monsterTurn == false)

                    //PLayers turn
                    Console.WriteLine(name + " Turn");
                    Console.WriteLine(name + "'s Health:" + playerHealth + " " + "Monster Health:" + monsterHealth);
                    Console.WriteLine("__________________________________");
                    Console.WriteLine("1.Attack");
                    Console.WriteLine("2.Defend");

                    battleChoice = Console.ReadLine();
                    if (battleChoice == "1")
                    {
                        playerAttackSlot = rnd.Next(1, playerStr);
                        playerAttackSlot = playerAttackSlot - monsterDefSlot;
                        if (playerAttackSlot < 0) playerAttackSlot = 0;
                        monsterHealth = monsterHealth - playerAttackSlot;
                        monsterDefSlot = 0;

                        Console.Clear();
                        Console.WriteLine(name + " Attacks!");
                        Console.ReadLine();
                    }

                    if (battleChoice == "2")
                    {
                        playerDefSlot = 0;
                        playerDefSlot = playerDefSlot + playerDef;
                        Console.Clear();
                        Console.WriteLine(name + " Defends!");
                        Console.ReadLine();
                    }
                    Console.Clear();


                    Console.WriteLine("Monster Turn");
                    ///Console.WriteLine(name + "'s Health:" + playerHealth + " " + "Monster Health:" + monsterHealth);
                    //Console.WriteLine("1.Attack");
                    //Console.WriteLine("2.Defend");

                    monsterChoice = rnd.Next(1, 3);
                    if (monsterChoice == 1)
                    {
                        monsterAttackSlot = rnd.Next(1, monsterStr);
                        monsterAttackSlot = monsterAttackSlot - playerDefSlot;
                        if (monsterAttackSlot < 0) monsterAttackSlot = 0;
                        playerHealth = playerHealth - monsterAttackSlot;
                        playerDefSlot = 0;
                        Console.WriteLine("Monster Attacks!");
                        Console.ReadLine();
                    }

                    if (monsterChoice == 2)
                    {
                        gambleChance = rnd.Next(1, 100);

                        if (gambleChance >= 50)
                        {
                            monsterDefSlot = 0;
                            monsterDefSlot = monsterDefSlot + monsterDef;
                            Console.WriteLine("Monster Defends!");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Monster block failed");
                            Console.ReadLine();
                            gambleChance = 0;


                        }
                    }
                    Console.Clear();
                    ///if player dies
                    if (playerHealth <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("YOU WERE DEFEATED");
                        Console.WriteLine("GAME OVER");
                        Console.ReadLine();
                        battle = false;
                        quit = true;
                        Menu = false;
                    }
                    ///If monster dies
                    else if (monsterHealth <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Monster defooted");
                        monsterHealth = 10;
                        battle = false;
                        Menu = true;
                    }
                }
            }
        }
    }
}
