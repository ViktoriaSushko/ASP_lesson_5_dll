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
        public async Task <IActionResult> OnGet(int? id)
        {
            if (id is null)
                return NotFound();
            Car = await repository.Get(id.Value);
            if (Car == null)
                return NotFound();
            return Page();
        }
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> OnPost(int? id)
        {
            if (id is null)
                return NotFound();
            Car? delCar = await repository.Get(id.Value);
            if (delCar == null)
            {
                return NotFound();
            }
            await repository.Delete(delCar);
            return RedirectToPage("Index");
        }
    }
}
