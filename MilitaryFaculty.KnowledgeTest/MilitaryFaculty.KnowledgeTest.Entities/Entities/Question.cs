﻿using System.Collections.Generic;

namespace MilitaryFaculty.KnowledgeTest.Entities.Entities
{
    public class Question : Entity<int>
    {
        public Question()
        {
            this.Tests = new List<Test>();
        }

        public string Description { get; set; }
        public virtual List<Variant> Variants { get; set; }
        public virtual List<Test> Tests { get; set; }
    }
}
