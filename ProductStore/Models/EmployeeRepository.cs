using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeHub.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<Employee> Employees = new List<Employee>();
        private int _nextId = 1;

        public EmployeeRepository()
        {
            Add(new Employee { Name = "Pulkit Gupta", Department = "IT", Salary = 25000.0M });
            Add(new Employee { Name = "Rohan Arora", Department = "Technical", Salary = 1750.15M });
            Add(new Employee { Name = "Raman Surya", Department = "HR", Salary = 250.25M });
        }

        public IEnumerable<Employee> GetAll()
        {
            return Employees;
        }

        public Employee Get(int id)
        {
            return Employees.Find(p => p.Id == id);
        }

        public Employee Add(Employee item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            item.Id = _nextId++;
            Employees.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            Employees.RemoveAll(p => p.Id == id);
        }

        public bool Update(Employee item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = Employees.FindIndex(p => p.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            Employees.RemoveAt(index);
            Employees.Add(item);
            return true;
        }

        /*IEnumerable<Employee> IEmployeeRepository.GetAll()
        {
            throw new NotImplementedException();
        }

        Employee IEmployeeRepository.Get(int id)
        {
            throw new NotImplementedException();
        }

        Employee IEmployeeRepository.Add(Employee item)
        {
            throw new NotImplementedException();
        }

        bool IEmployeeRepository.Update(Employee item)
        {
            throw new NotImplementedException();
        }*/
    }
}