using System;

namespace FinTracker.Models
{
    public class Tag
    {
        public int Id { get; set; } // Unique identifier for the tag
        public string Name { get; set; } // Name of the tag
        public string Description { get; set; } // Description of the tag
    }
}