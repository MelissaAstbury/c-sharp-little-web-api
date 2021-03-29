using System;
using System.ComponentModel.DataAnnotations;

namespace ElephantsProject
{
    public class Elephant
    {
        public string id { get; set; }

        [StringLength(25, MinimumLength = 3)]
        public string name { get; set; }

        [Required]
        public string species { get; set; }

        [Required]
        public string sex { get; set; }

        [Range(1800, 2021)]
        public int dob { get; set; }

        public int dod { get; set; }

        [StringLength(150, MinimumLength = 3)]
        public string wikilink { get; set; }

        [StringLength(250, MinimumLength = 2)]
        public string note { get; set; }
    }
}
