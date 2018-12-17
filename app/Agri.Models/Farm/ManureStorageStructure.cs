﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agri.Models.Farm
{
    public class ManureStorageStructure
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsStructureCovered => !UncoveredAreaSquareFeet.HasValue;
        public int? UncoveredAreaSquareFeet { get; set; }
    }
}