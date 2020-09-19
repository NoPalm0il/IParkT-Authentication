using IParkT_Authentication.Data;
using IParkT_Authentication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IParkT_Authentication.Areas.Identity.Pages.Account.Manage
{
    public class LicensePlateModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IParkTDB _context;

        public LicensePlateModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IParkTDB context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public string Username { get; set; }
        public List<Car> Cars { get; set; }

        public string LicensePlate { get; set; }
        public string Color { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Car License Plate")]
            public string NewLicensePlate { get; set; }
            [Required]
            [Display(Name = "Car color")]
            public string NewColor { get; set; }
            [Required]
            [Display(Name = "Car Manufacter")]
            public string NewManufacturer { get; set; }
            [Required]
            [Display(Name = "Car Model")]
            public string NewModel { get; set; }
            [Required]
            [Display(Name = "Car Year")]
            public string NewYear { get; set; }
        }

        private async Task LoadAsync(IdentityUser user)
        {
            var cars = await _context.Car.Where(c => c.username == User.Identity.Name).ToListAsync();

            Cars = cars;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAddCarAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var cars = await _context.Car.Where(c => c.username == User.Identity.Name).ToListAsync();

            foreach (Car car in cars)
            {
                if (car.LicensePlate == Input.NewLicensePlate)
                {
                    StatusMessage = "Error, plate allready registered.";
                    return RedirectToPage();
                }
            }

            int year;

            if (!Int32.TryParse(Input.NewYear, out year))
            {
                StatusMessage = "Error, wrong year.";
                return RedirectToPage();
            }

            Utilizador curuser = await _context.User.FirstAsync(u => u.username == User.Identity.Name);

            Car newcar = new Car
            {
                LicensePlate = Input.NewLicensePlate,
                Color = Input.NewColor,
                Manufacturer = Input.NewManufacturer,
                Model = Input.NewModel,
                Year = year,
                username = curuser.username,
                utilizador = curuser
            };

            try
            {
                _context.Car.Add(newcar);
                await _context.SaveChangesAsync();

                StatusMessage = "New car added.";
                return RedirectToPage();
            } catch (Exception)
            {
                StatusMessage = "Error adding new car.";
                return RedirectToPage();
            }
        }
    }
}
