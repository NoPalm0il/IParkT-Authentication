using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IParkT_Authentication.Data;
using IParkT_Authentication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Reservation res)
        {
            // public IActionResult Index(string visor, string bt, string primeiroOperando, string operador, string limpaVisor) {  -> na 'Calculadora'

            if (ModelState.IsValid)
            {
                db.Add(res);
                await db.SaveChangesAsync(); // commit
                return RedirectToAction(nameof(Index));
            }

            // alguma coisa correu mal.
            // devolve-se o controlo da aplicação à View
            return View(res);
        }
    }
}
