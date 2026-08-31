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
        public async Task<IActionResult> OnGet(int? id)
        {
            if (id is null)
                return NotFound();
            this.Car = await repository.Get(id.Value);
            return Page();
        }
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> OnPost(Car? car, IFormFile? image)
        {
            var oldCar = await repository.Get(car.Id);
            if (oldCar == null)
            {
                return NotFound();
            }
            if (image!= null)
            {
                using var memoryStream = new MemoryStream();
                await image.CopyToAsync(memoryStream);
                car.Image = memoryStream.ToArray();
            }
            else
            {
                car.Image = oldCar.Image;
            }
            await repository.Update(car);
            return RedirectToPage("Index");
        }
    }
}
