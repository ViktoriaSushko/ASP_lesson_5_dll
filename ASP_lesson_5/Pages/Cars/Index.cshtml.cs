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

        public IndexModel(IRepository<Car> repository)
        {
            this.repository = repository;

        }
        public void OnGet()
        {
            Cars = repository.GetAll();
        }

    }
}
