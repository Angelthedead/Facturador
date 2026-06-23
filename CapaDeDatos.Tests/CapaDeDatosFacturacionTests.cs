using NUnit.Framework;
using CapaDeDatos;
using CapaDeEntidades;
using System.Configuration;
using System;
using System.Reflection;

namespace CapaDeDatos.Tests
{
    [TestFixture]
    public class CapaDeDatosFacturacionTests
    {
        [Test]
        public void InsertarFactura_InvalidConnectionString_ShouldHandleException()
        {
            // Arrange
            var dataLayer = new CapaDeDatosFacturacion();

            // We intentionally set the connection string to something invalid to force an exception
            var field = typeof(CapaDeDatosFacturacion).GetField("conexion", BindingFlags.NonPublic | BindingFlags.Instance);
            field.SetValue(dataLayer, "Data Source=invalid_server;Initial Catalog=invalid_db;Integrated Security=True;Connection Timeout=1");

            var facturacion = new CapaDeEntidadesFactura();

            // Act & Assert
            // When an exception is thrown in the try block, the catch block is executed.
            // The catch block calls `MessageBox.Show()`, which attempts to initialize WinForms components.
            // Since we are running in a headless test environment, this throws a `TypeInitializationException`.
            // By catching this specific exception, we successfully prove that the execution entered the catch block.
            var ex = Assert.Throws<TypeInitializationException>(() => dataLayer.InsertarFactura(facturacion));

            // This further verifies that it failed where we expected it to fail in our headless test.
            Assert.That(ex.InnerException, Is.Not.Null);
        }
    }
}
