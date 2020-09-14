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
using Microsoft.AspNetCore.Authorization;

namespace IParkT_Authentication.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IParkTDB db;

        public ReservationController(IParkTDB context)
        {
            db = context;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var ongoingRes = await db.Reservation
                .Include(r => r.park)
                .Where(r => DateTime.Compare(r.CheckOut, DateTime.Now) > 0 && DateTime.Compare(r.CheckIn, DateTime.Now) < 0)
                .ToListAsync();

            var parkList = await db.Park.ToListAsync();

            foreach (var item in ongoingRes)
            {
                parkList.Remove(item.park);
            }

            ViewBag.FreeParks = parkList;

            return View();
        }

        public IActionResult Create()
        {
            var user_cars = db.Car.Where(m => m.username == User.Identity.Name);

            ViewBag.User_cars = user_cars;

            return View();
        }

        public async Task<IActionResult> List()
        {
            var reslist = await db.Reservation
                .Where(r => r.car.username == User.Identity.Name && DateTime.Compare(r.CheckOut, DateTime.Now) > 0)
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
                if (DateTime.Compare(res.CheckIn, res.CheckOut) > 0)
                    return RedirectToAction("Create");


                //returns a list if checkout date > checkin date on the same parkId
                var ongoingRes = await db.Reservation
                .Include(r => r.park)
                .Where(r => DateTime.Compare(r.CheckOut, res.CheckIn) > 0 && r.ParkId == res.ParkId)
                .ToListAsync();

                if(ongoingRes.Count() > 0)
                    return RedirectToAction("Create");

                //checks if car has allready a reserve on that time
                var isCarUsed = await db.Reservation
                    .Include(r => r.car)
                    .Where(r => DateTime.Compare(r.CheckOut, res.CheckIn) > 0 && r.car.username == User.Identity.Name)
                    .ToListAsync();

                if(isCarUsed.Count() > 0)
                    return RedirectToAction("Create");

                Car car = await db.Car.FirstAsync(c => c.LicensePlate == res.LicensePlate);
                Park park = await db.Park.FirstAsync(p => p.ParkId == res.ParkId);

                res.car = car;
                res.park = park;

                var createReservation = db.Add(res);
                await db.SaveChangesAsync(); // commit
                
                return RedirectToAction("Index");
            }

            // alguma coisa correu mal.
            // devolve-se o controlo da aplicação à View
            return RedirectToAction("Create");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            Reservation reservation = await db.Reservation.FirstAsync(r => r.ReservationId == id);

            if(reservation == null)
                return NotFound();

            return View(reservation);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Reservation reservation = await db.Reservation.FirstAsync(r => r.ReservationId == id);

            db.Reservation.Remove(reservation);
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
