using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Unidad2_Act1.Models.Entities;
using Unidad2_Act1.Models.MyEntities;
using Unidad2_Act1.Models.ViewModels;

namespace Unidad2_Act1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ZooplanetContext _context;
        public HomeController(ZooplanetContext context)
        {
            _context = context;
        }
        public IActionResult Index(IndexViewModel vm)
        {
            IEnumerable<ClaseAnimal> ClasesAnimales = _context.Clase.Select(x => new ClaseAnimal{
                Nombre=x.Nombre != null ? x.Nombre : "Sin Nombre",
                Id=x.Id,
                Observaciones = x.Descripcion != null ? x.Descripcion : "Sin Descripción",
            }).ToList();
            vm.ClasesAnimales = ClasesAnimales;
            return View(vm);
        }
        public IActionResult Especies(string Id)
        {
            IEnumerable<Animal> animales = _context.Especies.Where(x => x.IdClaseNavigation.Nombre == Id)
                .Select(x=> new Animal 
                {
                    IdClase = x.IdClaseNavigation != null ? x.IdClaseNavigation.Id : 0,
                    IdFoto = (int)(x.Id != 0 ? x.Id : 0), //IDFOTO
                    Nombre = x.Especie
                }).ToList();

            IndexEspeciesViewModel vm = new IndexEspeciesViewModel
            {
                Animales = animales,
                Especie = Id,
                IdClase = animales.Select(x => x.IdClase).FirstOrDefault()
            };

            return View(vm);
        }
        public IActionResult Especie(string Id)
        {
            string nombreFormateado = Id.Replace("-", " ");
            FullAnimalDescription InfoAnimal = _context.Especies
                .Include(x => x.IdClaseNavigation)
                .Where(x => x.Especie == nombreFormateado)
                .Select(x => new FullAnimalDescription
                {
                    Nombre = x.Especie,
                    NombreClase = x.IdClaseNavigation != null ? x.IdClaseNavigation.Nombre ?? " " : " ",
                    IdClase = x.IdClaseNavigation != null ? x.IdClaseNavigation.Id : 0,
                    Peso = x.Peso.ToString() ?? " ",
                    Habitat = x.Habitat ?? " ",
                    IdFoto = x.Id,
                    Tamaño = x.Tamaño ?? 0,
                    Descripcion = x.Observaciones ?? " ",

                }).First();
            IndexEspecieViewModel vm = new()
            {
                FullAnimalDesc = InfoAnimal
            };
            return View(vm);
        }
    }
}
