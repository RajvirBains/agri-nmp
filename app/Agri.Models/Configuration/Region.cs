﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Agri.Models.Configuration
{
    public class Region : Versionable
    {
        public Region()
        {
            SubRegions = new List<SubRegion>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int SoilTestPhosphorousRegionCd { get; set; }
        public int SoilTestPotassiumRegionCd { get; set; }
        public int LocationId { get; set; }
        public int SortNumber { get; set; }

        public Location Location { get; set; }
        public List<SubRegion> SubRegions { get; set; }

    }
}