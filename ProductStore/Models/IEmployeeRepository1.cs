using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EmployeeHub.Models
{
        public interface IEmployeeRepository
        {
            IEnumerable<Employee> GetAll();
            Employee Get(int id);
            Employee Add(Employee item);
            void Remove(int id);
            bool Update(Employee item);
        }
  }
