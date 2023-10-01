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
        private Dictionary<string, string> EspeciesDescripción = new Dictionary<string, string>()
            {
                { "Aves", "Las aves son animales vertebrados que tienen plumas, pico y alas. Son ovíparos y su cuerpo está cubierto de plumas. Tienen un esqueleto ligero y hueco que les permite volar." },
                { "Mamíferos", "Los mamíferos son animales vertebrados que tienen pelo o piel, glándulas mamarias y dientes diferenciados. Son vivíparos y se alimentan de leche materna durante la primera etapa de su vida." },
                { "Peces", "Los peces son animales vertebrados acuáticos que tienen branquias para respirar. Su cuerpo está cubierto de escamas y tienen aletas para nadar. La mayoría de los peces son ovíparos." },
                { "Anfibios", "Los anfibios son animales vertebrados que pasan por una metamorfosis desde su nacimiento hasta la edad adulta. Tienen una piel desnuda y húmeda, y respiran a través de branquias en su etapa larvaria y pulmones en su etapa adulta." },
                { "Reptiles", "Los reptiles son animales vertebrados que tienen escamas en su cuerpo. Son ovíparos y respiran a través de pulmones. La mayoría de los reptiles son terrestres, aunque algunos pueden vivir en el agua." }
            };
        public HomeController(ZooplanetContext context)
        {
            _context = context;
        }
        public IActionResult Index(IndexViewModel vm)
        {
            IEnumerable<ClaseAnimal> ClasesAnimales = _context.Clase.Select(x => new ClaseAnimal{
                Nombre=x.Nombre != null ? x.Nombre : "Sin Nombre",
                Id=x.Idclase,
                Observaciones = EspeciesDescripción.Keys.Contains(x.Nombre) ? EspeciesDescripción[x.Nombre ?? " "] : "Sin Observaciones"
            }).ToList();
            vm.ClasesAnimales = ClasesAnimales;
            return View(vm);
        }
    }
}
