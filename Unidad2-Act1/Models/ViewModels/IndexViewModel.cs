using Unidad2_Act1.Models.MyEntities;

namespace Unidad2_Act1.Models.ViewModels
{
    public class IndexViewModel
    {
       public IEnumerable<ClaseAnimal> ClasesAnimales { get; set; } = null!;
    }
}
