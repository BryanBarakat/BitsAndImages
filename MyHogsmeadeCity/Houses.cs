namespace MyHogsmeadeCity
    {
        public class House : Building, ITaxable
        {
            public House(int cost, int money, int beans, int population, int happiness)
            {
                this.cost = cost;
                this.money = money;
                this.beans = beans;
                this.population = population;
                this.happiness = happiness;
            }

            public override string[] toString()
            {
                string[] x =
                {
                    "  _______________________   ",
                    " / , , , , , , , , , , , \\ ",
                    "/_________________________\\",
                    "|| _____ ____            ||",
                    "|| | | | ||||            ||",
                    "|| | | | ||||            ||",
                    "|| ----- ||||            ||",
                    "||       ----            ||",
                };
                return x;
            }

            public int LoseMoney()
            {
                return 200;
            }
        }
    }