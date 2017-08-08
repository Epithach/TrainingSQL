using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainingSQL.Models
{
    public class Country
    {
        [Key]
        public int ID { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Continent { get; set; }

        public string Region { get; set; }

        public int SurfaceArea { get; set; }

        public int IndepYear { get; set; }

        public int Population { get; set; }

        public int LifeExpectancy { get; set; }

        public int GNP { get; set; }

        public int GNPOld { get; set; }

        public string LocalName { get; set; }

        public string GovernmentForm { get; set; }

        public string HeadOfStage { get; set; }

        public int Capital { get; set; }

        public string Code2 { get; set; }
    }
}