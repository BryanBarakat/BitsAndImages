namespace MyHogsmeadeCity
{
    public class Quidditch : Building
    {
        public Quidditch(int cost,int money,int beans,int population,int happiness)
        {
            this.cost = cost;
            this.money = money;
            this.beans = beans;
            this.population = population;
            this.happiness = happiness;
        }

        public override string[] toString()
        {
            string[] x4 =
            {
                "|>      |>       <|      <|",
                "| \\    |--|      |--|    /|",
                "| \\_ __|__|______|__|___ /|",
                "|------|--|------|--|-----|",
                "|------|--|------|--|-----|",
                "|------|--|------|--|-----|",
                "|______|__|______|__|_____|",
            };
            return x4;
        }
    }
}