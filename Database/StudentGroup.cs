using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentGroupDatabase.Database
{
    public class StudentGroup
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        public int GroupID { get; set; }
        public Student Student { get; set; }
        public Group Group { get; set; }
    }
}
