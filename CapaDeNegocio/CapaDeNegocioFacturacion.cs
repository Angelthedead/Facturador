using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeEntidades;
using CapaDeDatos;

namespace CapaDeNegocio
{
    public class CapaDeNegocioFacturacion
    {
        private readonly CapaDeDatosFacturacion capaDeDatos_Facturacion = new CapaDeDatosFacturacion();

        public void InsertarCliente(CapaDeEntidadesCliente entidad_Cliente)
        {
            capaDeDatos_Facturacion.InsertarCliente(entidad_Cliente);
        }

        public void InsertarFactura(CapaDeEntidadesFactura entidad_Factura)
        {
            capaDeDatos_Facturacion.InsertarFactura(entidad_Factura);
        }

        public void InsertarDetalle(CapaDeEntidadesDetalle entidad_Detalle)
        {
            capaDeDatos_Facturacion.InsertarDetalle(entidad_Detalle);
        }

        public int ObtenerIdFactura()
        {
            return capaDeDatos_Facturacion.ObtenerIdFactura();
        }
    }
}
