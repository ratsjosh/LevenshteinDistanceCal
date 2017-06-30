using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LevenshteinDistanceCal.Models
{
    public class LevenshteinDistanceModel
    {
        [Required, MinLength(1)]
        public string Source { get; set; }

        [Required, MinLength(1)]
        public string Target { get; set; }
    }
}
