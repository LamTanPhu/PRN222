﻿using System.ComponentModel.DataAnnotations;

namespace ModelViews.Entity
{
    public class ChildrenProfile
    {
        [Key]
        public Guid ProfileId { get; set; }
        public Guid FKAccountId { get; set; }
        public Account Account { get; set; }
        public string ParentName { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Status { get; set; }
    }
}
