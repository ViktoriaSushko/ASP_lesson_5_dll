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
        //public IActionResult OnPost(string manufacturer, string model,int year, double price)
        //{
        //    Car car = new Car
        //    {
        //        Manufacturer = manufacturer,
        //        Model=model,
        //        Year=year,
        //        Price=price
        //    };
        //    repository.Add(car);
        //    return RedirectToPage("Index");
        //}
        //2
        [IgnoreAntiforgeryToken]
        public IActionResult OnPost(Car car)
        {
            repository.Add(car);

            return RedirectToPage("Index");
        }
    }
}
