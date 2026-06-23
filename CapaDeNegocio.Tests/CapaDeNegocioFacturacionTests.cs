using System;
using NUnit.Framework;
using Moq;
using CapaDeNegocio;
using CapaDeEntidades;
using CapaDeDatos;

namespace CapaDeNegocio.Tests
{
    [TestFixture]
    public class CapaDeNegocioFacturacionTests
    {
        private Mock<CapaDeDatosFacturacion> _mockCapaDeDatos;
        private CapaDeNegocioFacturacion _capaDeNegocio;

        [SetUp]
        public void Setup()
        {
            _mockCapaDeDatos = new Mock<CapaDeDatosFacturacion>();
            _capaDeNegocio = new CapaDeNegocioFacturacion(_mockCapaDeDatos.Object);
        }

        [Test]
        public void InsertarCliente_ShouldCallInsertarClienteOnCapaDeDatos()
        {
            // Arrange
            var cliente = new CapaDeEntidadesCliente();

            // Act
            _capaDeNegocio.InsertarCliente(cliente);

            // Assert
            _mockCapaDeDatos.Verify(d => d.InsertarCliente(cliente), Times.Once);
        }

        [Test]
        public void InsertarFactura_ShouldCallInsertarFacturaOnCapaDeDatos()
        {
            // Arrange
            var factura = new CapaDeEntidadesFactura();

            // Act
            _capaDeNegocio.InsertarFactura(factura);

            // Assert
            _mockCapaDeDatos.Verify(d => d.InsertarFactura(factura), Times.Once);
        }

        [Test]
        public void InsertarDetalle_ShouldCallInsertarDetalleOnCapaDeDatos()
        {
            // Arrange
            var detalle = new CapaDeEntidadesDetalle();

            // Act
            _capaDeNegocio.InsertarDetalle(detalle);

            // Assert
            _mockCapaDeDatos.Verify(d => d.InsertarDetalle(detalle), Times.Once);
        }

        [Test]
        public void ObtenerIdFactura_ShouldReturnExpectedId()
        {
            // Arrange
            int expectedId = 123;
            _mockCapaDeDatos.Setup(d => d.ObtenerIdFactura()).Returns(expectedId);

            // Act
            var actualId = _capaDeNegocio.ObtenerIdFactura();

            // Assert
            Assert.AreEqual(expectedId, actualId);
            _mockCapaDeDatos.Verify(d => d.ObtenerIdFactura(), Times.Once);
        }
    }
}
