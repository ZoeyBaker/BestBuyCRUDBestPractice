using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyCRUDBestPractices
{
    class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Department(int id, string name)
        {
            ID = id;
            Name = name;
        }

    }
}
