using CarLibrary.Models;
using CarLibrary.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP_lesson_5.Pages.Cars
{
    public class CreateModel : PageModel
    {
        private readonly IRepository<Car> repository;
        public CreateModel(IRepository<Car> repository)
        {
            this.repository = repository;
        }
        public void OnGet()
        {
        }
       
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> OnPost(Car car,IFormFile? image)
        {
            if (image != null)
            {
                using var memoryStream = new MemoryStream();
                await image.CopyToAsync(memoryStream);
                car.Image = memoryStream.ToArray();
            }
            await repository.Add(car);

            return RedirectToPage("Index");
        }
    }
}
