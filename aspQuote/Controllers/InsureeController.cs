using System;
using System.Linq;
using System.Web.Mvc;
using aspQuote;
using aspQuote.Models;

public class InsureeController : Controller
{
    Model1 db = new Model1();

    // GET: Insuree/Create
    public ActionResult Create()
    {
        LoginViewModel vm = new LoginViewModel();
        return View();
    }

    // POST: Insuree/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "Id,FirstName,LastName,EmailAddress,Age,CarYear,CarMake,CarModel,SpeedingTickets,HasDUI,IsFullCoverage")] Insuree insuree)
    {
        if (ModelState.IsValid)
        {
            insuree.Quote = CalculateQuote(insuree);
            db.Insurees.Add(insuree);
            db.SaveChanges();
            return RedirectToAction("Create");
        }

        return View(insuree);
    }

    // GET: Insuree/Admin
    public ActionResult Admin()
    {
        return View(db.Insurees.ToList());
    }

    private decimal CalculateQuote(Insuree insuree)
    {
        decimal baseRate = 50;
        decimal total = baseRate;

        // Age-based additions
        if (insuree.Age <= 18)
        {
            total += 100;
        }
        else if (insuree.Age >= 19 && insuree.Age <= 25)
        {
            total += 50;
        }
        else if (insuree.Age >= 26)
        {
            total += 25;
        }

        // Car year-based additions
        if (insuree.CarYear < 2000)
        {
            total += 25;
        }
        else if (insuree.CarYear > 2015)
        {
            total += 25;
        }

        // Car make and model-based additions
        if (insuree.CarMake == "Porsche")
        {
            total += 25;
            if (insuree.CarModel == "911 Carrera")
            {
                total += 25;
            }
        }

        // Speeding tickets
        total += insuree.SpeedingTickets * 10;

        // DUI check
        if (insuree.HasDUI)
        {
            total *= 1.25m;
        }

        // Full coverage check
        if (insuree.IsFullCoverage)
        {
            total *= 1.50m;
        }

        return total;
    }

    // Dispose method to free resources
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            db.Dispose();
        }
        base.Dispose(disposing);
    }
}
