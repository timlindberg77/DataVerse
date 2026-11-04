using System;
using System.Collections.Generic;
using System.Text;

namespace DataVerse_Manager.Classes
{
    public class JobStatistic : BaseEntity
    {
        // Definition av egenskaper för JobStatistic-klassen
        public int OccupationId { get; set; }
        public int Year { get; set; }
        public int OpenJobs { get; set; }

        // Procentuell förändring från OpenJobs till "to"
        public double Growth(int to)
        {
            if (OpenJobs == 0)
            {
                return 0; // undviker division med noll
            }

            return (to - OpenJobs) / (double)OpenJobs * 100;
        }

    }
}
