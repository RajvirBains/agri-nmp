﻿using System.Collections.Generic;
using System.Linq;
using Agri.Models.Farm;

namespace SERVERAPI.ViewModels
{
    public class ManureStorageViewModel
    {
        public List<GeneratedManure> GeneratedManures { get; set; }
        public List<ImportedManure> ImportedManures { get; set; }
        public List<ManureStorageSystem> ManureStorageSystems { get; set; }
        public string ExplainMaterialsNeedingStorageMessage { get; set; }
        public bool AnyUnallocatedManures =>
            GeneratedManures.Any(gm => !gm.AssignedToStoredSystem) ||
            ImportedManures.Any(im => !im.IsLandAppliedBeforeStorage && !im.AssignedToStoredSystem);
        public bool DisableAddStorageSystemButton
        {
            get { return !AnyUnallocatedManures; }
        }

        public List<ManagedManure> ManagedManures
        {
            get
            {
                var manures = new List<ManagedManure>();
                if (GeneratedManures.Any())
                {
                    manures.AddRange(GeneratedManures);
                }

                if (ImportedManures.Any())
                {
                    manures.AddRange(ImportedManures.Where(im => !im.IsLandAppliedBeforeStorage));
                }

                return manures;
            }
        }
        public List<string> UnallocatedManureNames => ManagedManures.Where(mm => !mm.AssignedToStoredSystem).Select(mm => mm.ManagedManureName).ToList();
    }
}
