using System;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZeroHunger.Data;
using ZeroHunger.Models;
using ZeroHunger.Models.DTO;

namespace ZeroHunger.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public RestaurantController(AppDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        private List<CollectRequest> GetCollectRequestsByRestUsername(string restUserName)
        {
            return _dbContext.CollectRequest
                .Where(request => request.restUserName == restUserName &&
                             request.reqStarus == "Pending" || request.reqStarus == "Assigned")
                .ToList();
        }

        [HttpGet]
        public IActionResult RestDashboard()
        {
            string restaurant = HttpContext.Request.Cookies["restUserName"];
            List<CollectRequest> collectRequest = GetCollectRequestsByRestUsername(restaurant);
            ViewBag.name = restaurant;
            return View(collectRequest);           
        }

        [HttpGet]
        public IActionResult AddRequest()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRequest(AddRequestDto addRequestDto)
        {
            if (ModelState.IsValid)
            {
                //Mapping DTO to User entity
                var addRequest = new CollectRequest
                {
                    foodType = addRequestDto.foodType,
                    quantity = addRequestDto.quantity,
                    reqPosted = addRequestDto.reqPosted,
                    maxPreservationTime = addRequestDto.maxPreservationTime,
                    empUsername = "N/A",
                    restUserName = HttpContext.Request.Cookies["restUserName"],
                    reqStarus = "Pending",
                };
                //insert the new restaurant to the database
                _dbContext.CollectRequest.Add(addRequest);
                _dbContext.SaveChanges();
                return RedirectToAction("RestDashboard");
            }
            else
            {
                Console.WriteLine("not found");
            }
            return View(addRequestDto);
        }
    }
}

