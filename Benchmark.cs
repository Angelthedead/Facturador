using System;
using System.Collections.Generic;
using System.Diagnostics;
using CapaDeDatos;
using CapaDeEntidades;

class Benchmark
{
    static void Main()
    {
        Console.WriteLine("Creating benchmark data...");
        int count = 1000;
        List<CapaDeEntidadesDetalle> detalles = new List<CapaDeEntidadesDetalle>();
        for (int i = 0; i < count; i++)
        {
            detalles.Add(new CapaDeEntidadesDetalle
            {
                IdFactura = 1,
                DescripcionProducto = "Producto " + i,
                Cantidad = 1,
                PrecioUnitario = 10.0m,
                IVAProducto = 12,
                TotalProducto = 11.2m
            });
        }

        Console.WriteLine($"Benchmark prepared with {count} items.");
        Console.WriteLine("Note: Since we are running in an environment without the database connection configured (SQL Server),");
        Console.WriteLine("we will demonstrate the logical improvement. Executing the DB benchmark would fail at runtime");
        Console.WriteLine("because the connection string is invalid or DB server is inaccessible in the sandbox.");

        // Logically, InsertarDetalles replaces N Open/Close + Execute queries with 1 Open + Transaction + Execute
        Console.WriteLine("N+1 queries vs 1 transaction with reused SqlCommand (batch logic implemented).");
    }
}
