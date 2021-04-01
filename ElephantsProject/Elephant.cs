using System;
using System.ComponentModel.DataAnnotations;

namespace ElephantsProject
{
    public class Elephant
    {
        public string id { get; set; }

        [StringLength(25, MinimumLength = 1)]
        public string name { get; set; }

        [Required]
        public string species { get; set; }

        [Required]
        public string sex { get; set; }

        [Range(1950, 2021)]
        public int dob { get; set; }

        public int dod { get; set; }

        public string wikilink { get; set; }

        public string note { get; set; }
    }
}
