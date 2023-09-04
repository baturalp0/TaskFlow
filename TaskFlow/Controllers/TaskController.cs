using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Npgsql;
using System.Data;
using TaskFlow.Context;
using TaskFlow.Entities.Models;

namespace TaskFlow.Controllers
{
    public class TaskController : Controller
    {

        DbConnection _connection = new DbConnection();

        int testid = 7;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List() 
        {
            return View();
        }

       
        public IActionResult Add()
        {
            if (ModelState.IsValid)
            {

            
                var priorities = GetPriorities(); // GetPriorities fonksiyonunu burada çağırın
                SelectList priorityList = new SelectList(priorities, "id", "name");
                ViewBag.PriorityList = priorityList; // SelectList'i ViewBag içine taşıyın

                var departmens = GetDepartments(); // GetPriorities fonksiyonunu burada çağırın
                SelectList departmenList = new SelectList(departmens, "id", "name");
                ViewBag.DepartmentList = departmenList; // SelectList'i ViewBag içine taşıyın


                return View();
            }


            return View();
        }

        [HttpPost]
        public IActionResult Add(Entities.Models.Task modal)
        {
            if (ModelState.IsValid)
            {
                //var priorities = GetPriorities(); // GetPriorities fonksiyonunu burada çağırın
                //SelectList priorityList = new SelectList(priorities, "Id", "Name");
                //ViewBag.PriorityList = priorityList; // SelectList'i ViewBag içine taşıyın
                //return View();
            }


            return View();
        }

        public IEnumerable<Priority> GetPriorities()
        {
            string connectionString = "server=localhost; port=5432; Database=taskflow; user Id=postgres; password=antalya";

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT id, name FROM priorities";
                var priorities = connection.Query<Priority>(query);

                return priorities;
            }
        }

        public IEnumerable<Department> GetDepartments()
        {
            string connectionString = "server=localhost; port=5432; Database=taskflow; user Id=postgres; password=antalya";

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query1 = "Select * from authorities where employee_id= '"+testid+"' "; //authorities tablosundan giriş yapmış kullanıcının hangi departmanda olduğu bilgisini alıyoruz.
                DataTable dataTable1 = _connection.GetNpgsql(query1);
                int department_id = Convert.ToInt32(dataTable1.Rows[0]["department_id"]);//giriş yapmış kullanıcının department_id'si. (çalışıyor kontrol ettim.)
                int role_id = Convert.ToInt32(dataTable1.Rows[0]["role_id"]);//giriş yapmış kullanıcının role_id'si. (çalışıyor kontrol ettim.)


                string query = "SELECT * FROM departments where topdepartment_id = '" + department_id + "' ";
                var departmens = connection.Query<Department>(query);

                if(departmens.Any()) //alt departmanı var demektir. Departman select kısmı ona göre şekiilenmeli
                {
                    return departmens;
                }
                else//alt departmanı yok demektir. kullanıcı hangi departmandaysa o departmanın ismi select kısmında görünmeli. 
                {
                    //giriş yapmış kullanıcının bulunduğu departman id'si  department_id değişkeni içerisinde.
                    //department_id'yi kullanarak departmanı al ve bu departmanı dön.
                    string query2 = "SELECT * FROM departments where id = '" + department_id + "' ";
                    var departmens2 = connection.Query<Department>(query2);
                    return departmens2;
                }

               
            }
        }
    }
}
