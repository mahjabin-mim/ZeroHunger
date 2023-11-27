using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZeroHunger.Data;
using ZeroHunger.Models;
using ZeroHunger.Models.DTO;

namespace ZeroHunger.Controllers
{
	public class EmployeeController : Controller
	{
        private readonly AppDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public EmployeeController(AppDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        private List<CollectRequest> GetCollectRequestsByEmpUsername(string empUserName)
        {
            return _dbContext.CollectRequest
                .Where(request => request.empUsername == empUserName &&
                                              request.reqStarus == "Assigned" || request.reqStarus == "Collected")
                .ToList();
        }

        [HttpGet]
        public IActionResult EmpDashboard()
        {
            string employee = HttpContext.Request.Cookies["empUserName"];
            List<CollectRequest> collectRequest = GetCollectRequestsByEmpUsername(employee);
            ViewBag.name = employee;
            return View(collectRequest);
        }

        [HttpPost]
        public IActionResult AssignToCollect(int reqId)
        {
            var assignUpdate = _dbContext.CollectRequest.SingleOrDefault(a => a.reqId == reqId);
            if (assignUpdate != null)
            {
                assignUpdate.reqStarus = "Collected";
                _dbContext.CollectRequest.Update(assignUpdate);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("EmpDashboard");
        }

        [HttpPost]
        public IActionResult CollectToDone(int reqId)
        {
            var assignUpdate = _dbContext.CollectRequest.SingleOrDefault(a => a.reqId == reqId);
            if (assignUpdate != null)
            {
                assignUpdate.reqStarus = "Done";
                _dbContext.CollectRequest.Update(assignUpdate);
                _dbContext.SaveChanges();

                var empUserName = assignUpdate.empUsername;
                var completedReq = _dbContext.Employee.SingleOrDefault(a => a.empUserName == empUserName);
                if (completedReq != null)
                {
                    completedReq.completedReq++;
                    _dbContext.Employee.Update(completedReq);
                    _dbContext.SaveChanges();
                }
            }
            return RedirectToAction("EmpDashboard");
        }

        private List<Employee> GetEmployee(string empUserName)
        {
            return _dbContext.Employee
                .Where(request => request.empUserName == empUserName)                                          
                .ToList();
        }

        [HttpGet]
        public IActionResult ViewProfile()
        {
            string employee = HttpContext.Request.Cookies["empUserName"];
            List<Employee> profile = GetEmployee(employee);
            ViewBag.name = employee;
            return View(profile);
        }

        [HttpGet]
        public IActionResult EditProfile()
        {
            Console.WriteLine("hellllllllllllllllllllllllllllllo");
            string employee = HttpContext.Request.Cookies["empUserName"];
            List<Employee> profile = GetEmployee(employee);
            if (employee == null)
            {
                Console.WriteLine("Not found");
                return NotFound(); 
            }
            return View(profile);
        }

        [HttpPost]
        public IActionResult EditProfile(string empUserName)
        {
            Console.WriteLine("hellllllllllllllllllllllllllllllo");
            var updateProfile = _dbContext.Employee.SingleOrDefault(a => a.empUserName == empUserName);
            if (updateProfile != null)
            {
                _dbContext.Employee.Update(updateProfile);
                _dbContext.SaveChanges();
                return RedirectToAction("ViewProfile");
            }
            else
            {
                Console.WriteLine("Not found");
            }
            return View(updateProfile);
        }
    }
}

