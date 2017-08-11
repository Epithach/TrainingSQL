using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingSQL.Models
{
    public class LanguagePercent
    {
        public string Country { get; set; }

        public string Language { get; set; }

        public decimal Percentile { get; set; }
    }
}