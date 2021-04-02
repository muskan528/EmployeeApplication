using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using EmployeeHub.Models;

namespace EmployeeHub.Controllers
{
    public class EmployeesController : ApiController
    {
        static readonly IEmployeeRepository repository = new EmployeeRepository();

        public IEnumerable<Employee> GetAllEmployees()
        {
            Thread.Sleep(5000);
            return repository.GetAll();
        }

        public Employee GetEmployee(int id)
        {
            Employee item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public IEnumerable<Employee> GetEmployeesByDepartment(string category)
        {
            return repository.GetAll().Where(
                p => string.Equals(p.Department, category, StringComparison.OrdinalIgnoreCase));
        }

        public HttpResponseMessage PostEmployee(Employee item)
        {
            item = repository.Add(item);
            var response = Request.CreateResponse<Employee>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutEmployee(int id, Employee product)
        {
            product.Id = id;
            if (!repository.Update(product))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteEmployee(int id)
        {
            throw new Exception();
            repository.Remove(id);
        }
    }
}
