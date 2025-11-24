/* GestorDeProducto gestor = new GestorDeProducto();
Console.WriteLine("Bienvenido al sistema de gestión de productos.");
Console.WriteLine("Actividad 1 Estructuras de Datos - Búsqueda Secuencial y Binaria");

// Agregar productos de ejemplo
gestor.AgregarProducto(new Producto
{
    Id = 1,
    Nombre = "Laptop",
    Categoria = "Electrónica",
    CodigoBarras = "123456",
    Precio = 300,
    Stock = 10
});

gestor.AgregarProducto(new Producto
{
    Id = 2,
    Nombre = "Mouse",
    Categoria = "Electrónica",
    CodigoBarras = "789012",
    Precio = 100,
    Stock = 8
});

gestor.AgregarProducto(new Producto
{
    Id = 3,
    Nombre = "Chicles",
    Categoria = "Dulces",
    CodigoBarras = "159263",
    Precio = 2,
    Stock = 50
});

gestor.AgregarProducto(new Producto
{
    Id = 4,
    Nombre = "Manzanas",
    Categoria = "Frutas",
    CodigoBarras = "456789",
    Precio = 10,
    Stock = 20
});

gestor.MostrarInventario();

gestor.MostrarProductosPorCategoria("Electrónica");

Producto productoEncontrado = gestor.BuscarPorCodigoDeBarras("159263");
Console.WriteLine(productoEncontrado != null
    ? productoEncontrado.ToString() : "No enontrado");

List<Producto> productos = gestor.ObtenerProductos();

// Buscar por Codigo de Barras (Usando Diccionario)
string codigoABuscar = "789012";
Producto productoPorCodigo = gestor.BuscarPorCodigoDeBarras(codigoABuscar);
Console.WriteLine(productoPorCodigo != null
    ? $"Producto encontrado por código de barras {codigoABuscar}: {productoPorCodigo}"
    : $"Producto con código de barras {codigoABuscar} no encontrado.");

// Existe Producto (Usando Diccionario)
Console.WriteLine(gestor.ExisteProducto("123456")
    ? "El producto con código de barras 123456 existe."
    : "El producto con código de barras 123456 no existe.");

// Eliminar Producto (Usando Diccionario)
Console.WriteLine(gestor.EliminarProducto("456789")
    ? "Producto con código de barras 456789 eliminado."
    : "Producto con código de barras 456789 no encontrado para eliminar.");

// Mostrar inventario después de eliminación
gestor.MostrarInventario();


// Actividad 2 Algotitmos de ordenamiento
Console.WriteLine("\nActividad 2 Algoritmos de Ordenamiento");

List<Producto> productosParaOrdenar = gestor.ObtenerProductos();
Console.WriteLine("Ordenando por precio (Quicksort)");
OrdenadorSimplificado.QuickSortPorPrecio(productosParaOrdenar);
MostrarProductos(productosParaOrdenar);

// Ordenar por nombre (Mergesort)
Console.WriteLine("\nOrdenando por nombre (Mergesort)");
List<Producto> productosOrdenadosPorNombre = OrdenadorSimplificado.MergeSortPorNombre(new List<Producto>(gestor.ObtenerProductos()));
MostrarProductos(productosOrdenadosPorNombre);


// Actividad 3 Algoritmos de búsqueda
Console.WriteLine("\nActividad 3 Algoritmos de Búsqueda");
// Ordenar ID para búsqueda binaria
List<Producto> productosParaBusqueda = new List<Producto>(gestor.ObtenerProductos());
OrdenadorSimplificado.QuickSortPorId(productosParaBusqueda);
Console.WriteLine("Búsqueda Binaria por ID (ID = 2)");
var (productoBuscado, iteracionesBinaria) = BuscadorSimplificado.BusquedaBinariaPorId(productosParaBusqueda, 2);
Console.WriteLine($"Reultado: {(productoBuscado != null ? productoBuscado.ToString() : "No encontrado")} en {iteracionesBinaria} iteraciones.");

// Búsqueda Secuencial por Nombre
Console.WriteLine("\nBúsqueda Secuencial por Nombre (Nombre = 'Chicles')");
var (productoSecuencial, iteracionesSecuencial) = BuscadorSimplificado.BusquedaSecuencialNombre(productos, "Chicles");
Console.WriteLine($"Reultado: {(productoSecuencial != null ? productoSecuencial.ToString() : "No encontrado")} en {iteracionesSecuencial} iteraciones.");

// Comparación de eficiencia
Console.WriteLine("\nComparación de Eficiencia:");
Console.WriteLine($"Búsqueda Binaria: {iteracionesBinaria} iteraciones.");
Console.WriteLine($"Búsqueda Secuencial: {iteracionesSecuencial} iteraciones.");

// Método auxiliar para mostrar la lista de productos
void MostrarProductos(List<Producto> lista)
{
    foreach (var p in lista)
    {
        Console.WriteLine(p.ToString());
    }
}
*/