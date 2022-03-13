using System;
using System.Collections.Generic;

#nullable disable

namespace LiftTrackerApi
{
    public partial class Log
    {
        public int? Id { get; set; }
        public string Date { get; set; }
        public DateTime? Time { get; set; }
        public string Lift { get; set; }
        public int? Set1 { get; set; }
        public int? Set2 { get; set; }
        public int? Set3 { get; set; }
        public int? Set4 { get; set; }
        public int? Set5 { get; set; }
        public int? Set6 { get; set; }
        public int? Set7 { get; set; }
        public int? Set8 { get; set; }
        public int? Weight { get; set; }
        public int? Fatigueindex { get; set; }
    }
}
