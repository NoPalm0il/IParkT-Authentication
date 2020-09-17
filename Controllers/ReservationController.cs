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

        /// <summary>
        /// Construtor da classe, recebe como parametro o objeto da BD
        /// </summary>
        /// <param name="context"></param>
        public ReservationController(IParkTDB context)
        {
            db = context;
        }

        /// <summary>
        /// GET: Index
        /// Faz uma subconsulta para pesquisar os que estão ocupados, estes seram 
        /// removidos da lista de parques disponiveis e apresentados na lista
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> IndexAsync()
        {
            // retorna as reservas que estão a decorrer, juntamente com o objeto park
            var ongoingRes = await db.Reservation
                .Include(r => r.park)
                .Where(r => DateTime.Compare(r.CheckOut, DateTime.Now) > 0 && DateTime.Compare(r.CheckIn, DateTime.Now) < 0)
                .ToListAsync();

            // lista dos parques
            var parkList = await db.Park.ToListAsync();

            // para cada parque das reservas a decorrer vai ser retirada da lista dos parques
            foreach (var item in ongoingRes)
            {
                parkList.Remove(item.park);
            }

            // inserido no viewbag os parques disponiveis
            ViewBag.FreeParks = parkList;

            return View();
        }

        /// <summary>
        /// GET: Create
        /// Faz uma subconsulta para devolver a matricula do utilizador atual, para ter apenas 
        /// a escolha no formulario das suas matriculas
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public IActionResult Create()
        {
            // devolve a lista dos carros do utilizador atual
            var user_cars = db.Car.Where(m => m.username == User.Identity.Name);

            // insere na view bag a lista
            ViewBag.User_cars = user_cars;

            // Apresenta a pagina Create
            return View();
        }

        /// <summary>
        /// GET: List
        /// Devolve as reservas do utilizador atual
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public async Task<IActionResult> List()
        {
            // realiza uma subconsulta para devolver a reserva onde o dono do carro seja o do utilizador atual
            // e a data do checkout seja superior a data atual
            var reslist = await db.Reservation
                .Where(r => r.car.username == User.Identity.Name && DateTime.Compare(r.CheckOut, DateTime.Now) > 0)
                .ToListAsync();

            return View(reslist);
        }

        /// <summary>
        /// POST: Create
        /// Cria uma reserva para o utilizador atual
        /// </summary>
        /// <param name="res"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Reservation res)
        {
            if (ModelState.IsValid)
            {
                // Caso a data do check in seja depois do check out retorna para a pagina Create
                if (DateTime.Compare(res.CheckIn, res.CheckOut) > 0)
                    return RedirectToAction("Create");


                // retorna uma lista com reservas que compara a data de checkout desse parque com a data de checkin inserida
                var ongoingRes = await db.Reservation
                .Include(r => r.park)
                .Where(r => DateTime.Compare(r.CheckOut, res.CheckIn) > 0 && r.ParkId == res.ParkId)
                .ToListAsync();

                // caso haja uma reserva nesse parque retorna para a pagina Create
                if(ongoingRes.Count() > 0)
                    return RedirectToAction("Create");

                // checks if car has allready a reserve on that time
                var isCarUsed = await db.Reservation
                    .Include(r => r.car)
                    .Where(r => DateTime.Compare(r.CheckOut, res.CheckIn) > 0 && r.car.username == User.Identity.Name)
                    .ToListAsync();

                //verifica se o carro está a ser utilizado noutra reserva
                if(isCarUsed.Count() > 0)
                    return RedirectToAction("Create");

                // encontra o carro com essa matricula
                Car car = await db.Car.FirstAsync(c => c.LicensePlate == res.LicensePlate);
                // encontra o parque com esse parque id
                Park park = await db.Park.FirstAsync(p => p.ParkId == res.ParkId);

                res.car = car;
                res.park = park;

                var createReservation = db.Add(res);
                // guarda a reserva
                await db.SaveChangesAsync();
                
                return RedirectToAction("Index");
            }

            // alguma coisa correu mal.
            // devolve-se o controlo da aplicação à View
            return RedirectToAction("Create");
        }

        /// <summary>
        /// GET: Delete
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            // Encontra a reserva com esse id
            Reservation reservation = await db.Reservation.FirstAsync(r => r.ReservationId == id);

            if(reservation == null)
                return NotFound();

            return View(reservation);
        }

        /// <summary>
        /// POST: Delete
        /// Confirma o delete e apaga na db
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // encontra a reserva com esse id
            Reservation reservation = await db.Reservation.FirstAsync(r => r.ReservationId == id);

            // remove a reserva
            db.Reservation.Remove(reservation);
            // guarda as alterações
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
