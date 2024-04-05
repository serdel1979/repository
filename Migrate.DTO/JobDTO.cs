using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrate.DTO
{
    public class JobDTO
    {
        public int? Id { get; set; }
        public string Description { get; set; }

        public int EmployeId { get; set; }
        public EmployeDTO Employe { get; set; }
    }
}
