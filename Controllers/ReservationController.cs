using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IParkT_Authentication.Data;
using IParkT_Authentication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace IParkT_Authentication.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IParkTDB db;

        public ReservationController(IParkTDB context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var user_cars = db.Car.Where(m => m.username == User.Identity.Name);

            ViewBag.User_cars = user_cars;
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

        public async Task<IActionResult> List()
        {
            var reslist = await db.Reservation
                .Where(r => r.car.username == User.Identity.Name)
                .ToListAsync();
            return View(reslist);
            //return View(await db.Reservation.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Reservation res)
        {
            if (ModelState.IsValid)
            {
                //var alltres = await db.Reservation.ToListAsync();

                //if (alltres.Count == 0)
                //    res.ReservationId = 1;
                //else
                //    res.ReservationId = alltres.Last().ReservationId + 1;

                Car car = await db.Car.FirstAsync(c => c.username == User.Identity.Name && c.LicensePlate == res.LicensePlate);

                res.car = car;

                var createres = db.Add(res);
                await db.SaveChangesAsync(); // commit

                return RedirectToAction(nameof(Index));
            }

            // alguma coisa correu mal.
            // devolve-se o controlo da aplicação à View
            return View(res);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string plate)
        {
            if(plate == null)
                return RedirectToAction("List");

            var res = await db.Reservation.FirstOrDefaultAsync(m => m.LicensePlate == plate);
            if (res == null)
                return RedirectToAction("List");

            var resplate = await db.Reservation.FindAsync(res.ReservationId);
            db.Reservation.Remove(resplate);

            await db.SaveChangesAsync();
            return RedirectToAction("List");
        }
    }
}
