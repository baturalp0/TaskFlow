using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Data;
using TaskFlow.Entities.Models;
using DbConnection = TaskFlow.Context.DbConnection;


namespace TaskFlow.Controllers;

public class EmployeeController : Controller
{
    private readonly DbConnection dbConnection = new DbConnection();

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(Employee model)
    {
        string connectionString = "server=localhost; port=5432; Database=taskflow; user Id=postgres; password=antalya";
        using IDbConnection dbConnection = new NpgsqlConnection(connectionString);

        if (ModelState.IsValid)
        {
            if (string.IsNullOrEmpty(model.code) || string.IsNullOrEmpty(model.password))
            {
                TempData["ErrorMessage"] = "Lütfen tüm alanları doldurun";
            }
            else
            {
                // Personel Kodu db'de var mı yok mu kontrol ediyorum.
                var employeeCount = dbConnection.ExecuteScalar<int>("SELECT COUNT(*) FROM employees WHERE code = @Code", new { Code = model.code });

                if (employeeCount > 0)
                {
                    var employee = dbConnection.QueryFirstOrDefault<Employee>("SELECT * FROM employees WHERE code = @Code", new { Code = model.code });

                    if (employee.password == model.password)
                    {
                        TempData["SuccessMessage"] = "Giriş başarılı.";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Giriş başarısız. Lütfen geçerli şifre girin.";
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "Bu personel kodu ile kayıtlı bir kullanıcı bulunamadı.";
                }
            }

            return View(model);
        }
        return View(model);
    }


}
