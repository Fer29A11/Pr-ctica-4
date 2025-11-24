public class BuscadorSimplificado
{
    // Busqueda Binaria por Id
   public static (Producto, int) BusquedaBinariaPorId(List<Producto> productos, int idBuscado)
    {
        //1. Calcular el punto medio
        int inicio = 0;
        int fin = productos.Count - 1;
        int iteraciones = 0;

        while (inicio <= fin)
        {
            iteraciones++;
            // La mitad de la lista
            int medio = (inicio + fin) / 2;

            // Comprobar si el elemento del medio es el buscado
            if (productos[medio] .Id == idBuscado)
            {
                return (productos[medio], iteraciones);
            }

            // Ajustar los límites de búsqueda
            if (productos[medio].Id < idBuscado)
            {
                inicio = medio + 1; // Buscar en la mitad derecha
            }
            else
            {
                fin = medio - 1; // Buscar en la mitad izquierda
            }


        }
        return (null, iteraciones); // No encontrado
    }


    public static (Producto, int) BusquedaSecuencialNombre(List<Producto> productos, string nombreBuscado)
    {
        int iteraciones = 0;
        foreach (var producto in productos)
        {
            iteraciones++;
            if (producto.Nombre.Equals(nombreBuscado, StringComparison.OrdinalIgnoreCase))
            {
                return (producto, iteraciones);
            }
        }
        return (null, iteraciones); // No encontrado
    }
}