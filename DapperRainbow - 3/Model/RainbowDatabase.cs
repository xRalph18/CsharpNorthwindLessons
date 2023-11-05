using Dapper;

namespace DapperRainbow___3.Model
{
    class RainbowDatabase : Database<RainbowDatabase>
    {
        public Table<FoodTypes> FoodTypes { get; set; }
        public Table<Foods> Foods { get; set; }
    }
}
