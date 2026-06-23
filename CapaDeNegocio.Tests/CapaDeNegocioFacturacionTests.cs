using System;
using NUnit.Framework;
using Moq;
using CapaDeNegocio;
using CapaDeDatos;
using CapaDeEntidades;

namespace CapaDeNegocio.Tests
{
    [TestFixture]
    public class CapaDeNegocioFacturacionTests
    {
        [Test]
        public void InsertarFactura_ShouldDelegateToCapaDeDatos()
        {
            // Arrange
            var mockCapaDeDatos = new Mock<ICapaDeDatosFacturacion>();
            var capaDeNegocio = new CapaDeNegocioFacturacion(mockCapaDeDatos.Object);
            var factura = new CapaDeEntidadesFactura
            {
                IdCliente = 1,
                BaseImponibleCero = 10.0m,
                BaseImponibleDoce = 20.0m,
                Subtotal = 30.0m,
                IVA = 2.4m,
                Total = 32.4m
            };

            // Act
            capaDeNegocio.InsertarFactura(factura);

            // Assert
            mockCapaDeDatos.Verify(x => x.InsertarFactura(factura), Times.Once);
        }
    }
}
