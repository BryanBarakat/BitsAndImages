using System;
using System.Collections.Generic;
using System.Transactions;

namespace MyHogsmeadeCity
{
    class Game
    {
        private List<Building> buildingList;

        private int TotalBeans;
        private int TotalMoney;
        private int TotalPopulation;
        private int TotalHappiness;

        private int IncreaseBeans;
        private int IncreaseMoney;

        public Game(int money, int beans)
        {
            this.TotalMoney = money;
            this.TotalBeans = beans;
            this.TotalPopulation = 0;
            this.TotalHappiness = 0;
            this.IncreaseBeans = 0;
            this.IncreaseMoney = 0;
            buildingList = new List<Building>();
        }

        public void AddTotal(Building building)
        {
            TotalBeans += building.GetBeans();
            TotalMoney += building.GetMoney();
            TotalPopulation += building.GetPopulation();
            TotalHappiness += building.GetHappiness();
        }

        public void AddBuilding(Building building)
        {
            buildingList.Add(building);
            TotalMoney -= building.GetCost();
            AddTotal(building);
        }

        public void RemoveBuilding(int index)
        {
            IncreaseBeans -= buildingList[index].GetBeans();
            IncreaseMoney -= buildingList[index].GetMoney();
            TotalHappiness -= buildingList[index].GetHappiness();
            TotalPopulation -= buildingList[index].GetPopulation();
            buildingList.RemoveAt(index);
        }

        public void PrintInfo()
        {
            int Galleon = TotalMoney / (27 * 21);
            int Sickle = (TotalMoney - (Galleon * (27 * 21))) / 27;
            int Knut = (TotalMoney - (Galleon * 27 * 21) - (Sickle * 27));
            int Galleon2 = IncreaseMoney / (27 * 21);
            int Sickle2 = (IncreaseMoney - (Galleon2 * (27 * 21))) / 27;
            int Knut2 = (IncreaseMoney - (Galleon2 * 27 * 21) - (Sickle2 * 27));
            Console.Clear();
            Console.WriteLine("You have {0} Galleons, {1} Sickles {2} Knuts ", Galleon, Sickle, Knut);
            Console.WriteLine("You gain {0} Galleons, {1} Sickles and {2} Knuts per round", Galleon2, Sickle2, Knut2);
            Console.WriteLine("You have {0} beans", TotalBeans);
            Console.WriteLine("You gain {0} beans per round", IncreaseBeans);
            Console.WriteLine("The rate of happiness is : {0}", TotalHappiness);
            Console.WriteLine("There are {0} people in your town", TotalPopulation);
        }

        public void PrintCity()
        {
            int z = 0;
            int x = 0;
            int y = 8;
            int linen = 0;
            foreach (Building building in this.buildingList)
            {
                linen = (z / 5) * 16;
                y = 8 + linen;
                x = 30 * (z % 5);

                foreach (string lines in building.toString())
                {
                    y += 1;
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(lines);
                }

                z += 1;
            }
        }

        public Action GetNextAction()
        {
            Console.WriteLine("What do you want to do ? ...");
            Console.WriteLine("Add | Remove | Print | Nothing | Quit");
            string wish = Console.ReadLine();

            if (wish == "Add")
            {
                return Action.ADD;
            }

            if (wish == "Remove")
            {
                return Action.REMOVE;
            }

            if (wish == "Print")
            {
                return Action.PRINT;
            }

            if (wish == "Quit")
            {
                return Action.QUIT;
            }

            if (wish == "Nothing")
            {
                return Action.NOTHING;
            }

            else
            {
                return Action.FAIL;
            }
        }

        public Building Construct()
        {
            Console.Write("Which building do you want to construct ?");
            Console.WriteLine("quidditch | house | prison | shop");
            string wish = Console.ReadLine();
            Building building = null;
            if (wish == "quidditch")
            {
                building = new Quidditch(20, 2, 3, 25, 40);
            }
            else if (wish == "house")
            {
                building = new House(30, 5, 3, 30, 50);
            }
            else if (wish == "prison")
            {
                building = new Prison(60, 3, 6, 45, 32);
            }

            else if (wish == "shop")
            {
                building = new Shop(70, 3, 6, 7, 3);
            }
            
            return building;
        }

        public void Destroy()
        {
            Console.Write("Which building do you want to destroy ?");
            Console.WriteLine("Write a number from 0 to 3");
            int wish = Int32.Parse(Console.ReadLine());
            RemoveBuilding(wish);
        }

        public void DestroyRandomBuilding()
        {
            int wish = Int32.Parse(Console.ReadLine());
            Random r = new Random();
            r.Next(0, wish);
            int a = r.Next(0, buildingList.Count);
            RemoveBuilding(a);
        }

        public bool Update()
        {
            bool up = true;
            while (up)
            {
                TotalMoney += IncreaseMoney;
                TotalBeans += IncreaseBeans;
                Action a = GetNextAction();
                if ((int)a == 0)
                {
                    Building bldg = Construct();
                    if (bldg != null)
                    {
                        buildingList.Add(bldg);
                    }
                }

                if ((int) a == 1)
                {
                    Destroy();
                }

                if ((int) a == 2)
                {
                    Console.Clear();
                    PrintInfo();
                    PrintCity();
                }

                if ((int) a == 3)
                {
                    Console.WriteLine("already passed");
                }

                if ((int) a == 4)
                {
                    break;
                }

                if (TotalMoney < 0 || TotalBeans < 0)
                {
                    up = false;
                }
            }

            return up;
        }

        public enum Action
        {
            ADD,
            REMOVE,
            PRINT,
            QUIT,
            NOTHING,
            FAIL
        }
    }
}