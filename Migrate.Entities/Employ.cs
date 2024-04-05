using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrate.Entities
{
    public class Employ
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Job> Jobs { get; set; }
    }
}
