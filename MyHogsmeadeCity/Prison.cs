namespace MyHogsmeadeCity
{
    public class Prison : Building
    {
        public Prison(int cost, int money, int beans, int population, int happiness)
        {
            this.cost = cost;
            this.money = money;
            this.beans = beans;
            this.population = population;
            this.happiness = happiness;
        }

        public int LoseMoney()
        {
            return 200;
        }

        public override string[] toString()
        {
            string[] x2 =
            {        "    | |_| |    | |_| |",
                     "    |__|__|____|__|__|",
                    "    \\_|__|__|__|__|__/",
                      "     |__|__|[]|__|__|",
                      "     ||__|__|__|__|_|",
                      "     |__|__|[]|__|__|",
                      "     ||__|__|__|__|_|",
                      "     |__|__|==|__|__|",
                    " ,;.;||__|_|  ||__|_|,;.", 
                ",;.;.,|==|==|__|==|==|;,.,."

            };
            return x2;
        }
    }
}