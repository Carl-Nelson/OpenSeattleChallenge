using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSeattleChallenge
{
    // this class defines a table and associated columns. Entity Framework will use this file and the others like it to generate a SQLite database
    public class Donor
    {
        public int DonorId { get; set; }
        public string FirstName { get; set; } //keeping it simple and just assuming individual donors, no organizations
        public string LastName { get; set; }

        public virtual ICollection<Donation> Donations { get; private set; } //another EF thing for linking Donors to Donations
            = new ObservableCollection<Donation>();

    }
}
