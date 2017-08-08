using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainingSQL.Models
{
    public class CountryLanguage
    {
        public string CountryCode { get; set; }
        
        public string Language { get; set; }

        public int isOfficial { get; set; }

        public int Percentage { get; set; }
    }
}