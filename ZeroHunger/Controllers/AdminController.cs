﻿using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZeroHunger.Data;
using ZeroHunger.Models;
using ZeroHunger.Models.DTO;

namespace ZeroHunger.Controllers
{
	public class AdminController : Controller
	{
        private readonly AppDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public AdminController(AppDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        [HttpGet]
        private List<CollectRequest> GetCollectRequest()
        {
            var filteredRequests = _dbContext.CollectRequest
                   .Where(request => request.reqStarus == "Pending" ||
                                request.reqStarus == "Assigned" ||
                                request.reqStarus == "Collected")
                    .ToList();

            return filteredRequests;
        }

        [HttpGet]
        private List<Employee> GetEmployee()
        {
            return _dbContext.Employee.ToList();
        }

        [HttpGet]
        public IActionResult AdminDashboard()
        {
            List<CollectRequest> allRequests = GetCollectRequest();
            List<Employee> allEmployees = GetEmployee();
            var viewModel = new ViewDashboardModel
            {
                CollectRequest = allRequests,
                Employee = allEmployees
            };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult ApproveApplicants()
        {
            List<Applicants> allApplicants = _dbContext.Applicants.ToList();
            return View(allApplicants);
        }

        [HttpPost]
        public IActionResult ApproveApplicants(string email)
        {
            var applicant = _dbContext.Applicants.SingleOrDefault(a => a.email == email); 
            Console.WriteLine("hi"+email);
            if (applicant != null)
            {
                //Extract username from email
                string[] emailParts = applicant.email.Split('@');
                string username = emailParts[0];
                Console.WriteLine(username);
                var employee = new Employee
                {
                    empUserName = username,
                    empPassword = HashPassword(username),
                    empName = applicant.appName,
                    email = applicant.email,
                    empPhone = applicant.appPhone,
                    empAddress = applicant.appAddress,
                    joinningDate = applicant.applyDate,
                    completedReq = 0,
                };                
                _dbContext.Employee.Add(employee);
                _dbContext.SaveChanges();
                _dbContext.Applicants.Remove(applicant);
                _dbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("not found");
            }
            return RedirectToAction("ApproveApplicants");
        }

        private string HashPassword(string password)
        {
            // Hash the password using BCrypt
            //sha256
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        [HttpGet]
        public IActionResult ViewEmployee()
        {
            List<Employee> allEmployee = _dbContext.Employee.ToList();
            return View(allEmployee);
        }

        [HttpPost]
        public IActionResult Assign(int reqId, string empUserName)
        {
            var assignUpdate = _dbContext.CollectRequest.SingleOrDefault(a => a.reqId == reqId);
            if (assignUpdate != null)
            {
                assignUpdate.empUsername = empUserName;
                assignUpdate.reqStarus = "Assigned";

                _dbContext.CollectRequest.Update(assignUpdate);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("AdminDashboard");
        }
    }
}

