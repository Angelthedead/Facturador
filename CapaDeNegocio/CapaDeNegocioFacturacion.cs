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
        private readonly CapaDeDatosFacturacion _capaDeDatosFacturacion;

        public CapaDeNegocioFacturacion()
        {
            _capaDeDatosFacturacion = new CapaDeDatosFacturacion();
        }

        public CapaDeNegocioFacturacion(CapaDeDatosFacturacion capaDeDatosFacturacion)
        {
            _capaDeDatosFacturacion = capaDeDatosFacturacion;
        }

        public void InsertarCliente(CapaDeEntidadesCliente entidad_Cliente)
        {
            _capaDeDatosFacturacion.InsertarCliente(entidad_Cliente);
        }

        public void InsertarFactura(CapaDeEntidadesFactura entidad_Factura)
        {
            _capaDeDatosFacturacion.InsertarFactura(entidad_Factura);
        }

        public void InsertarDetalle(CapaDeEntidadesDetalle entidad_Detalle)
        {
            _capaDeDatosFacturacion.InsertarDetalle(entidad_Detalle);
        }
        public int ObtenerIdFactura()
        {
            return _capaDeDatosFacturacion.ObtenerIdFactura();
        }
    }
}
