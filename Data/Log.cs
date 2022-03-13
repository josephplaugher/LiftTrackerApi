using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftTrackerApi.Data
{
    public class Log
    {
        public int id { get; set; }
        public string date { get; set; }
        public string lift { get; set; }
        public Nullable<int> weight { get; set; }
        public Nullable<int> set1 { get; set; }
        public Nullable<int> set2 { get; set; }
        public Nullable<int> set3 { get; set; }
        public Nullable<int> set4 { get; set; }
        public Nullable<int> set5 { get; set; }
        public Nullable<int> fatigueindex { get; set; }
    }
}
