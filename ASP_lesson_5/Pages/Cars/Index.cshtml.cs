using CarLibrary.Models;
using CarLibrary.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP_lesson_5.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly IRepository<Car> repository;

        public IEnumerable<Car>? Cars { get; set; }
        public IEnumerable<string>? Manufacturers { get; set; } = new List<string>();
        public string? SelectedManufacturer { get; set; }
        public int? SelectedYear { get; set; }

        public IndexModel(IRepository<Car> repository)
        {
            this.repository = repository;

        }
        public async Task OnGet(string? manufacturer, int? year)
        {
            var cars = await repository.GetAll();
            Manufacturers = cars.Select(c => c.Manufacturer).Distinct().ToList();
            this.Cars = cars;
            if(manufacturer is not null && manufacturer != "All")
            {
                this.Cars = Cars.Where(c => c.Manufacturer == manufacturer).ToList();
                this.SelectedManufacturer = manufacturer;
            }
            if(year is not null)
            {
                this.Cars = Cars.Where(c => c.Year == year).ToList();
                this.SelectedYear = year;
            }
        }

    }
}
