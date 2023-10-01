using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Unidad2_Act1.Models.Entities;
using Unidad2_Act1.Models.MyEntities;
using Unidad2_Act1.Models.ViewModels;

namespace Unidad2_Act1.Controllers
{
    public class EspeciesController : Controller
    {
        private readonly ZooplanetContext _context;
        public EspeciesController(ZooplanetContext context)
        {
            _context = context;
        }
        public IActionResult Index(string Especie)
        {
            IEnumerable<Animal> animales = _context.Especies
            .Where(x=>(x.ClaseNavigation!=null ? x.ClaseNavigation.Nombre : " ") == Especie)
            .Select(x=> new Animal
            {
                Nombre= x.Especie,
                IdFoto = (int)(x.Clase != null ? x.Clase : 0), //IDFOTO
                IdClase=x.ClaseNavigation != null ? (int)x.ClaseNavigation.Idclase : 0
            });
            IndexEspeciesViewModel vm = new IndexEspeciesViewModel
            {
                Animales = animales,
                Especie = Especie,
                IdClase = animales.Select(x=>x.IdClase).FirstOrDefault()
            };

            return View(vm);
        }
    }
}
