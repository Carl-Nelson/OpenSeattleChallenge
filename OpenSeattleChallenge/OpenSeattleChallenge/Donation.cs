using System;

namespace OpenSeattleChallenge
{
    // this class defines a table and associated columns. Entity Framework will use this file and the others like it to generate a SQLite database
    public class Donation
    {
        public int DonationId { get; set; }
        public int DonorId { get; set;} //foreign key from the Donor table
        public string Type { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public virtual Donor Donor { get; set; }// EF thing for linking tables, this won't show up in the generated SQL
    }
}
