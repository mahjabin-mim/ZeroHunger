using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZeroHunger.Data;
using ZeroHunger.Models;
using ZeroHunger.Models.DTO;

namespace ZeroHunger.Controllers
{
    public class LandingPageController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public LandingPageController(AppDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        //GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(RegistrationDto registrationDto)
        {
            if (ModelState.IsValid)
            {
                //Mapping DTO to User entity
                var restaurant = new Restaurant
                {
                    restUserName = registrationDto.RestUserName,
                    restPassword = HashPassword(registrationDto.RestPassword),
                    restName = registrationDto.RestName,
                    restPhone = registrationDto.RestPhone,
                    restLocation = registrationDto.RestLocation,
                    registratineDate = registrationDto.RegistrationDate 
                };
                //insert the new restaurant to the database
                _dbContext.Restaurant.Add(restaurant);
                _dbContext.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(registrationDto);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                // Retrieve the user from the database based on the provided email
                //single/default returns a single, specific element
                var restaurant = _dbContext.Restaurant.SingleOrDefault(u => u.restUserName == loginDto.username);
                var employee = _dbContext.Employee.SingleOrDefault(u => u.empUserName == loginDto.username);

                if (restaurant != null && BCrypt.Net.BCrypt.Verify(loginDto.password, restaurant.restPassword))
                {
                    Response.Cookies.Append("restUserName", restaurant.restUserName);
                    return RedirectToAction("RestDashboard","Restaurant");
                }
                else if (employee != null && BCrypt.Net.BCrypt.Verify(loginDto.password, employee.empPassword))
                {
                    Response.Cookies.Append("empUserName", employee.empUserName);
                    return RedirectToAction("EmpDashboard", "Employee");
                }
                else if(loginDto.username == "admin" && loginDto.password == "12345")
                {
                    return RedirectToAction("AdminDashboard", "Admin");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid username or password");
                }
            }
            return View(loginDto);
        }

        private string HashPassword(string password)
        {
            // Hash the password using BCrypt
            //sha256
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        [HttpGet]
        public IActionResult Applicants()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Applicants(ApplicantsDto applicantsDto)
        {
            if (ModelState.IsValid)
            {
                var applicants = new Applicants
                {
                    email = applicantsDto.email,
                    appName = applicantsDto.appName,
                    appPhone = applicantsDto.appPhone,
                    appAddress = applicantsDto.appAddress,
                    applyDate = applicantsDto.applyDate,
                    appStatus = false
                };
                //insert the new restaurant to the database
                _dbContext.Applicants.Add(applicants);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicantsDto);
        }
    }
}
