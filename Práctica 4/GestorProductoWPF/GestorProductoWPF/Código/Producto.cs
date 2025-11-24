// Actividad 1
public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string CodigoBarras { get; set; }  // Campo único
    public string Categoria {  get; set; }  
    public decimal Precio { get; set; }
    public int Stock { get; set; }

    public override string ToString()
    {
        return $"[{Id}] {CodigoBarras} - {Nombre} | ${Precio} | Stock: {Stock}|{Categoria}";
    }
}

