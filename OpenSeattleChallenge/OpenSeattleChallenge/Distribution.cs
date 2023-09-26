using System;

namespace OpenSeattleChallenge
{
    // this class defines a table and associated columns. Entity Framework will use this file and the others like it to generate a SQLite database
    public class Distribution //not sure about this name, but I don't want to spend too much time thinking about it
    {
        public int DistributionId { get; set; }
        public string Type { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }

    }
}
