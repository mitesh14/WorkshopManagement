using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkshopManagement.Models;

namespace WorkshopManagement.Controllers
{
    public class WorkshopController : Controller
    {
        private readonly WorkshopDbContext _dbContext;

        #region database conection
        public WorkshopController(WorkshopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region all customer list
        public IActionResult AllCustomers(string searchString)
        {
            
            var customers = string.IsNullOrEmpty(searchString) ? _dbContext.Customers.ToList() : _dbContext.Customers.Where(c =>
               c.FirstName.Contains(searchString) || c.LastName.Contains(searchString)).ToList();

            // Pass the list and search string to the view
            ViewBag.SearchString = searchString;
            return View(customers);
        }
        #endregion

        #region customer vehicle
        public IActionResult VehiclesForCustomer(int customerId)
        {
            var vehiclesForCustomer = _dbContext.Vehicles.Where(v => v.CustomerID == customerId).ToList();

            
            var customer = _dbContext.Customers.Find(customerId);
            ViewBag.CustomerName = $"{customer.FirstName} {customer.LastName}";
            return View(vehiclesForCustomer);
        }
        #endregion

        #region due service
        public IActionResult UpcomingServiceDue()
        {
            var upcomingServiceDue = _dbContext.Vehicles
           .Where(v => EF.Functions.DateDiffDay(DateTime.Now, v.LastServiceDate) >= 0 &&
                       EF.Functions.DateDiffDay(DateTime.Now, v.LastServiceDate) <= 7)
           .OrderBy(v => v.LastServiceDate)
           .ToList();

            return View(upcomingServiceDue);
        }
        #endregion

        #region book slot four day
        public IActionResult BookWorkshopSlot(int vehicleId)
        {
            var bookedSlotsCount = _dbContext.WorkshopSlots.Count(ws => EF.Functions.DateDiffDay(DateTime.Now, ws.SlotDateTime) == 0);

            if (bookedSlotsCount >= 4)
            {
                return RedirectToAction("AllSlotsBooked", "Workshop");
            }

            var newSlot = new WorkshopSlot
            {
                VehicleID = vehicleId,
                SlotDateTime = DateTime.Now
            };

            _dbContext.WorkshopSlots.Add(newSlot);
            _dbContext.SaveChanges();

            return RedirectToAction("UpcomingServiceDue");
        }
        #endregion

        #region slots booked 
        public IActionResult AllSlotsBooked()
        {
            return View();
        }
        #endregion
    }
}
