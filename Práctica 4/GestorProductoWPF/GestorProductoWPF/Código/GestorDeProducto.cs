

public class GestorDeProducto
{
    // Lista
    private List<Producto> listaProductos = new List<Producto>();

    // Diccionario para búsqueda rápida por Código de Barras
    private Dictionary<string, Producto> diccionarioPorCodigo = new Dictionary<string, Producto>();

    public List<Producto> ObtenerProductos()
    {
        return new List<Producto>(listaProductos);
    }

    // Operaciones de la lista

    public void AgregarProducto(Producto p)
    {
        if (diccionarioPorCodigo.ContainsKey(p.CodigoBarras))
        {
            throw new Exception("El producto con ese código de barras ya existe.");
        }
        listaProductos.Add(p);

        diccionarioPorCodigo[p.CodigoBarras] = p;
    }

    public bool EliminarProducto(String codigoDeBarras)
    {
        if (diccionarioPorCodigo.TryGetValue(codigoDeBarras, out var producto))
        {
            listaProductos.Remove(producto);
            diccionarioPorCodigo.Remove(codigoDeBarras);
            return true;
        }
        return false;
    }

    public void MostrarInventario()
    {
        Console.WriteLine("Inventario de Productos:");
        foreach (var producto in listaProductos)
        {
            Console.WriteLine(producto.ToString());
        }
    }

    // Operaciones del diccionario
    public Producto BuscarPorCodigoDeBarras(string codigoBarras)
    {
        return diccionarioPorCodigo.TryGetValue(codigoBarras, out var producto) ? producto : null;
    }

    public bool ExisteProducto(string codigoBarras)
    {
        return diccionarioPorCodigo.ContainsKey(codigoBarras);
    }

    public void MostrarProductosPorCategoria(string categoria)
    {
        // Usamos lista para recorridos secuenciales
        Console.WriteLine($"Productos en la categoría '{categoria}':");
        foreach (var p in listaProductos)
        {
            if (p.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(p.ToString());
            }
        }
    }


}

