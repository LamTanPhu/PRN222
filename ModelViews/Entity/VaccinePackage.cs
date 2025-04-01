﻿using System.ComponentModel.DataAnnotations;

namespace ModelViews.Entity
{
    public class VaccinePackage
    {
        [Key]
        public int VaccinePackageId { get; set; }
        public string PackageName { get; set; }
        public string PackageDescription { get; set; }
        public int PackageStatus { get; set; }

       
    }
}
