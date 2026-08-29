using CarLibrary.Models;
using CarLibrary.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP_lesson_5.Pages.Cars
{
    public class EditModel : PageModel
    {
        private readonly IRepository<Car> repository;
        public Car? Car { get; set; }
        public EditModel(IRepository<Car> repository)
        {
            this.repository = repository;
        }
        public IActionResult OnGet(int? id)
        {
            if (id is null)
                return NotFound();
            this.Car = repository.Get(id.Value);
            return Page();
        }
        [IgnoreAntiforgeryToken]
        public IActionResult OnPost(Car? editCar)
        {
            if (editCar == null)
            {
                return NotFound();
            }
            repository.Update(editCar);
            return RedirectToPage("Index");
        }
    }
}
