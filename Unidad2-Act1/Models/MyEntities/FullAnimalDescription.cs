namespace Unidad2_Act1.Models.MyEntities
{
    public class FullAnimalDescription
    {
        public string Nombre { get; set; } = null!;
        public string NombreClase { get; set; } = null!;
        public int IdClase { get; set; }
        public string Peso { get; set; } = null!;
        public string Habitat { get; set; } = null!;
        public int IdFoto { get; set;}
        public int Tamaño { get; set; }
        public string Descripcion { get; set; } = null!;
    }
}
