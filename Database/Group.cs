using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentGroupDatabase.Database
{
    public class Group
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int StudentCount { get; set; }
        public List<StudentGroup> StudentGroups { get; set; }
    }
}
