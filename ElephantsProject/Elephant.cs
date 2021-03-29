using System;
using System.ComponentModel.DataAnnotations;

namespace ElephantsProject
{
    public class Elephant
    {
        public string id { get; set; }

        [StringLength(25, MinimumLength = 3)]
        public string name { get; set; }

        [Required(ErrorMessage = "You must define the Elephants species")]
        public string species { get; set; }

        [Required(ErrorMessage = "You must define the Elephants sex")]
        public string sex { get; set; }

        [Range(1800, 2021, ErrorMessage = "The Elephants age must be between 1800 - 2021")]
        public int dob { get; set; }

        public int dod { get; set; }

        public string wikilink { get; set; }

        public string note { get; set; }
    }
}
