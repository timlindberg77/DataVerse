using System;
using System.Collections.Generic;
using System.Text;

namespace DataVerse_Manager.Classes
{
    public class Occupation : BaseEntity
    {

        // Attrubuter
        public string Name { get; set; }
        public string Industry { get; set; }
        public WorkType WorkType { get; set; }
        public bool RequiresEducation { get; set; }
        public decimal AverageSalary { get; set; }
        public double Growth2030 { get; set; }

        // En metod som returnerar true om tillväxten är större än 0, annars false.
        public bool IsGrowing()
        {
            return Growth2030 > 0;
        }
    }
}
