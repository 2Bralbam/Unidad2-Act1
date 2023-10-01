using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Unidad2_Act1.Models.Entities;
using Unidad2_Act1.Models.MyEntities;
using Unidad2_Act1.Models.ViewModels;

namespace Unidad2_Act1.Controllers
{
    public class EspecieController : Controller
    {
        private readonly ZooplanetContext _context;
        public EspecieController(ZooplanetContext context)
        {
            _context = context;
        }
        public IActionResult Index(string Animal)
        {
            string nombreFormateado = Animal.Replace("-", " ");
            FullAnimalDescription InfoAnimal = _context.Especies
                .Include(x => x.ClaseNavigation)
                .Where(x => x.Especie == nombreFormateado)
                .Select(x => new FullAnimalDescription 
                {
                    Nombre=x.Especie,
                    NombreClase=x.ClaseNavigation != null ? x.ClaseNavigation.Nombre ?? " " : " ",
                    IdClase = x.ClaseNavigation != null ? x.ClaseNavigation.Idclase : 0,
                    Peso = x.Peso.ToString() ?? " ",
                    Habitat = x.Habitat ?? " ",
                    IdFoto = 0,
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
