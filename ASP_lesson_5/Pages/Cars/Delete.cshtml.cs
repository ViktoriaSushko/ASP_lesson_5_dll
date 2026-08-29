using Microsoft.AspNetCore.Mvc;
using CarLibrary.Models;
using CarLibrary.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CarLibrary.Services.Abstract;

namespace ASP_lesson_5.Pages.Cars
{
    public class DeleteModel : PageModel
    {
        private readonly IRepository<Car> repository;
        public Car? Car { get; set; }
        public DeleteModel(IRepository<Car> repository)
        {
            this.repository = repository;
        }
        public IActionResult OnGet(int? id)
        {
            if (id is null)
                return NotFound();
            Car = repository.Get(id.Value);
            if (Car == null)
                return NotFound();
            return Page();
        }
        [IgnoreAntiforgeryToken]
        public IActionResult OnPost(int? id)
        {
            if (id is null)
                return NotFound();
            Car? delCar = repository.Get(id.Value);
            if (delCar == null)
            {
                return NotFound();
            }               
            repository.Delete(delCar);
            return RedirectToPage("Index");
        }
    }
}
