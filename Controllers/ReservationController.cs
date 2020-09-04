using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IParkT_Authentication.Data;
using IParkT_Authentication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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

        public IActionResult List()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Reservation res)
        {
            if (ModelState.IsValid)
            {
                DateTime dt = DateTime.Now;
                if (dt.Subtract(res.CheckIn).TotalDays > 1 || dt.Subtract(res.CheckOut).TotalDays > 1)
                    return View(res);
                if (res.CheckIn.Subtract(res.CheckOut).TotalDays > 0)
                    return View(res);
                db.Add(res);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // alguma coisa correu mal.
            // devolve-se o controlo da aplicação à View
            return View(res);
        }
    }
}
