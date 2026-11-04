using System;
using System.Collections.Generic;
using System.Text;

namespace DataVerse_Manager.Classes
{
    public class JobInterest : BaseEntity
    {
        // Attributer
        public int OccupationId { get; set; }

        public string Title { get; set; }

        public DateTime DateAdded { get; set; }

        public string Note { get; set; }

        // En metod som returnerar en strängrepresentation av objektet
        public override string ToString()
        {
            return $"OccupationId: {OccupationId}, Title: {Title}, DateAdded: {DateAdded}, Note: {Note}";
        }
    }
}
