using Unidad2_Act1.Models.MyEntities;

namespace Unidad2_Act1.Models.ViewModels
{
    public class IndexEspeciesViewModel
    {
        public IEnumerable<Animal> Animales { get; set; } = null!;
        public string Especie { get; set; } = null!;
        public int IdClase { get; set; }
    }
}
