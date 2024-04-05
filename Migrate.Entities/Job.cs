using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrate.Entities
{
    public class Job
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int EmployId { get; set; }
        public Employ Employ { get; set; }
    }
}
