using System;
using CapaDeEntidades;

namespace CapaDeDatos
{
    public interface ICapaDeDatosFacturacion
    {
        void InsertarCliente(CapaDeEntidadesCliente _Cliente);
        void InsertarFactura(CapaDeEntidadesFactura _Facturacion);
        void InsertarDetalle(CapaDeEntidadesDetalle _Detalle);
        int ObtenerIdFactura();
    }
}
