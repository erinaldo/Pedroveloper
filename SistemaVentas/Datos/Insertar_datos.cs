﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SistemaVentas.CONEXION;
using System.Windows.Forms;
using SistemaVentas.Logica;
using System.Text.RegularExpressions;

namespace SistemaVentas.Datos
{
    public class Insertar_datos
    {
       
        int idcaja;
        int idusuario;
        public static bool ValidTextIsNotNullOrEmpty(TextBox[] textBox)
        {
            for(int i = 0; i < textBox.Length; ++i)
            {
                if (string.IsNullOrEmpty(textBox[i].Text))
                {
                    MessageBox.Show("RELLENE TODOS LOS CAMPOS CORRECTAMENTE", "Verificacion de datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            return true;
        }
        public static bool ValidTextIsNotNullOrEmpty2(TextBox[] textBox)
        {
            for (int i = 0; i < textBox.Length; ++i)
            {
                if (string.IsNullOrEmpty(textBox[i].Text))
                {
                    return false;
                }
            }
            return true;
        }
        public static bool insertar_Conceptos(string descripcion)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertar_Conceptos", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                cmd.ExecuteNonQuery();
                CONEXIONMAESTRA.cerrar();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public bool insertarDescuento(LDescuento parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarDescuento", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Descuento", parametros.descuento);
                cmd.Parameters.AddWithValue("@TipoDescuento", parametros.TipoDescuento);
                cmd.ExecuteNonQuery();
                CONEXIONMAESTRA.cerrar();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }


        public bool insertarMayoreo(Mayoreo mayoreo)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarMayoreo", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@unidades_1", mayoreo.mayoreo1);
                cmd.Parameters.AddWithValue("@unidades_2", mayoreo.mayoreo2);
                cmd.Parameters.AddWithValue("@unidades_3", mayoreo.mayoreo3);
                cmd.Parameters.AddWithValue("@unidades_4", mayoreo.mayoreo4);
                cmd.ExecuteNonQuery();
                CONEXIONMAESTRA.cerrar();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
<<<<<<< HEAD
        
        public bool insertarDatosFiscales(LDatosFiscales d)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("Ingresardatosfiscales", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombreFiscal", d.NombreFiscal);
                cmd.Parameters.AddWithValue("@infoAdicional", d.infoAdicional);
                cmd.Parameters.AddWithValue("@RegimenFiscal", d.RegimenFiscal);
                cmd.Parameters.AddWithValue("@RNC", d.RNC);
                cmd.Parameters.AddWithValue("@NoFiscal", d.NoFiscal);
                cmd.Parameters.AddWithValue("@CodPostal", d.CodPostal);
                cmd.Parameters.AddWithValue("@Localidad", d.Localidad);
                cmd.Parameters.AddWithValue("@Domicilio", d.Domicilio);
                cmd.Parameters.AddWithValue("@NoInt", d.NoInt);
                cmd.Parameters.AddWithValue("@NoExt", d.NoExt);
                cmd.Parameters.AddWithValue("@CDL", d.CDL);
                cmd.Parameters.AddWithValue("@Provincia", d.Provincia);
                cmd.Parameters.AddWithValue("@Ciudad", d.Ciudad);
                cmd.ExecuteNonQuery();
                CONEXIONMAESTRA.cerrar();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

=======
>>>>>>> 070e0db6f7cb668b558c2edfe87731c1cff6d7d7
        public bool editarMayoreo(Mayoreo mayoreo)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("editarMayoreo", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idMayoreo", mayoreo.idMayoreo);
                cmd.Parameters.AddWithValue("@unidades_1", mayoreo.mayoreo1);
                cmd.Parameters.AddWithValue("@unidades_2", mayoreo.mayoreo2);
                cmd.Parameters.AddWithValue("@unidades_3", mayoreo.mayoreo3);
                cmd.Parameters.AddWithValue("@unidades_4", mayoreo.mayoreo4);
                cmd.ExecuteNonQuery();
                CONEXIONMAESTRA.cerrar();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public bool insertarPrecios(Precios precios)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarListaPrecio", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idMayoreo", precios.idMayoreo);
                cmd.Parameters.AddWithValue("@Precio_1", precios.precio1);
                cmd.Parameters.AddWithValue("@Precio_2", precios.precio2);
                cmd.Parameters.AddWithValue("@Precio_3", precios.precio3);
                cmd.Parameters.AddWithValue("@Precio_4", precios.precio4);
                cmd.ExecuteNonQuery();
                CONEXIONMAESTRA.cerrar();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public bool editarPrecios(Precios precios)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("editarListaPrecio", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPrecios", precios.idPrecio);
                cmd.Parameters.AddWithValue("@idMayoreo", precios.idMayoreo);
                cmd.Parameters.AddWithValue("@Precio_1", precios.precio1);
                cmd.Parameters.AddWithValue("@Precio_2", precios.precio2);
                cmd.Parameters.AddWithValue("@Precio_3", precios.precio3);
                cmd.Parameters.AddWithValue("@Precio_4", precios.precio4);
                cmd.ExecuteNonQuery();
                CONEXIONMAESTRA.cerrar();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public bool insertarUnidad(LUnidadProductos parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarUnidad", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Descripcion", parametros.descripcion);
                cmd.Parameters.AddWithValue("@idClaveSat", parametros.idClaveSat);
                cmd.ExecuteNonQuery();
                CONEXIONMAESTRA.cerrar();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public bool insertarCategoria(LCategoria parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarCategoria", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcion", parametros.Descripcion);
                cmd.Parameters.AddWithValue("@idItbis", parametros.idImpuesto);
                cmd.Parameters.AddWithValue("@idDescuento", parametros.idDescuento);
                cmd.Parameters.AddWithValue("@Departamento", parametros.Departamento);
                cmd.Parameters.AddWithValue("@Estado", "ACTIVO");

                cmd.ExecuteNonQuery();
                CONEXIONMAESTRA.cerrar();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool insertarPersona(LPersona parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarPersona", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", parametros.nombre);
                cmd.Parameters.AddWithValue("@apellido", parametros.apellido);
                cmd.Parameters.AddWithValue("@Correo", parametros.correo);
                cmd.Parameters.AddWithValue("@fechaNacimiento", parametros.fechaNacimiento);
                cmd.Parameters.AddWithValue("@idDireccion", parametros.idDireccion);
                cmd.Parameters.AddWithValue("@idDocumento", parametros.idDocumento);
                cmd.Parameters.AddWithValue("@idTelefono", parametros.idTelefono);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                return true;
            }
        }

        public bool insertarImpuesto(LImpuesto parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarImpuestos", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", parametros.nombre);
                cmd.Parameters.AddWithValue("@Impuesto", parametros.impuesto);
                cmd.Parameters.AddWithValue("@Tipo", parametros.Tipo);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                return true;
            }
        }
        public bool insertarAlmacen(LAlmacen parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarAlmacen", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@almacen", parametros.almacen);
                cmd.Parameters.AddWithValue("@idlocalizacion", parametros.idLocalizacion);
                cmd.Parameters.AddWithValue("@stockminimo", parametros.stockminimo); 
                cmd.Parameters.AddWithValue("@idDireccion", parametros.idDireccion);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                return true;
            }
        }
        public bool editarAlmacen(LAlmacen parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("editarAlmacen", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idAlmacen", parametros.idAlmacen);
                cmd.Parameters.AddWithValue("@almacen", parametros.almacen);
                cmd.Parameters.AddWithValue("@idlocalizacion", parametros.idLocalizacion);
                cmd.Parameters.AddWithValue("@stockminimo", parametros.stockminimo);
                cmd.Parameters.AddWithValue("@idDireccion", parametros.idDireccion);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                return true;
            }
        }
        public bool insertarLozalizacion(LAlmacen parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarLocalizacion", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@localizacion", parametros.localizaicon);
                cmd.Parameters.AddWithValue("@Anaquel", parametros.Anaquel);
                cmd.Parameters.AddWithValue("@Zona", parametros.Zona);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                return true;
            }
        }

        public bool editarLocalizacion(LAlmacen parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("editarLocalizacion", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idLocalizacion", parametros.idLocalizacion);
                cmd.Parameters.AddWithValue("@localizacion", parametros.localizaicon);
                cmd.Parameters.AddWithValue("@Anaquel", parametros.Anaquel);
                cmd.Parameters.AddWithValue("@Zona", parametros.Zona);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                return true;
            }
        }
        public bool insertarTipoTelefono(LTelefono parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarTipoTelefono", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TipoTelefono", parametros.TipoTelefono);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                return true;
            }

        }
        public bool insertarHorario(LHorario parametros, int idTipoHorario)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarHorario", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@HoraEntrada", parametros.horaEntrada);
                cmd.Parameters.AddWithValue("@HoraSalida", parametros.horaSalida);
                cmd.Parameters.AddWithValue("@TipoHorario", idTipoHorario);
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                return true;

            }
        }
        public bool InsertarDocumento(LDocumentos parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarDocumento", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TipoDocumento", parametros.tipo);
                cmd.Parameters.AddWithValue("@numeracion", parametros.numeracion);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                return true;

            }
        }
        public static bool insertarTipoHorario(string TipoHorario)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarTipoHorario", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TipoHorario", TipoHorario);
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception EX)
            {

                MessageBox.Show(EX.Message);
                return true;

            }
        }

        public bool insertarDireccion(LDireccion parametros, int idRegion, int idMunicipio, int idSector, int idCalle, int idProvincia)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
<<<<<<< HEAD
                SqlCommand cmd = new SqlCommand("insertarDireccion", CONEXIONMAESTRA.conectar);
=======
                SqlCommand cmd = new SqlCommand("insertar_Direccion", CONEXIONMAESTRA.conectar);
>>>>>>> 070e0db6f7cb668b558c2edfe87731c1cff6d7d7
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcion", parametros.desDireccion);
                cmd.Parameters.AddWithValue("@idRegion", idRegion);
                cmd.Parameters.AddWithValue("@idMunicipio", idMunicipio);
                cmd.Parameters.AddWithValue("@idSector", idSector);
                cmd.Parameters.AddWithValue("@idProvincia", idProvincia);
                cmd.Parameters.AddWithValue("@idCalle",idCalle);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                return false;
            }
        }
        public bool InsertarCategoria(LCategoria parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarCategoria", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idDescuento", parametros.idDescuento);
                cmd.Parameters.AddWithValue("@idItbis", parametros.idImpuesto);
                cmd.Parameters.AddWithValue("@descripcion", parametros.Descripcion);
                cmd.Parameters.AddWithValue("@departamento", parametros.Departamento);
                cmd.Parameters.AddWithValue("@estado", parametros.Estado);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                return true;

            }
        }

        public bool editarCategoria(LCategoria parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("editarCategoria", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCategoria", parametros.idCategoria);
                cmd.Parameters.AddWithValue("@idImpuesto", parametros.idImpuesto);
                cmd.Parameters.AddWithValue("@idDescuento", parametros.idDescuento);
                cmd.Parameters.AddWithValue("@descripcion", parametros.Descripcion);
                cmd.Parameters.AddWithValue("@departamento", parametros.Departamento);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                return true;

            }
        }

        public bool insertarClavesSat(LUnidadesMedida parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("InsertarClavesSat", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@clave", parametros.Clave);
                cmd.Parameters.AddWithValue("@nombre", parametros.nombre);
                cmd.Parameters.AddWithValue("@descripcion", parametros.descripcion);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                return false;
            }
        }

        public bool insertarCalle(LDireccion parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertar_calle", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcion", parametros.Calle);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                return false;
            }
        }
        public bool insertarProvincia(LDireccion parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertar_provincia", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcion", parametros.Provincia);
                MessageBox.Show(parametros.Provincia);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                return false;

            }
        }

        public bool insertarProducto(Lproductos productos, LKardex kardex, UnidadesProductos unidadesProductos)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarProducto", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                //Productos
                cmd.Parameters.AddWithValue("@idCategoria", productos.idCategoria);
                cmd.Parameters.AddWithValue("@Codigo", productos.Codigo);
                cmd.Parameters.AddWithValue("@Descripcion", productos.Descripcion);
                cmd.Parameters.AddWithValue("@PrecioCompra", productos.Preciodecompra);
                cmd.Parameters.AddWithValue("@Stock", productos.Stock);
                cmd.Parameters.AddWithValue("@idImpuesto", productos.idImpuesto);
                cmd.Parameters.AddWithValue("@idPrecios", productos.idPrecios);
                cmd.Parameters.AddWithValue("@idDescuento", productos.idDescuento);

                //Kardex
                cmd.Parameters.AddWithValue("@Fecha", kardex.Fecha);
                cmd.Parameters.AddWithValue("@Motivo", kardex.Motivo);
                cmd.Parameters.AddWithValue("@Cantidad", kardex.Cantidad);
                cmd.Parameters.AddWithValue("@Id_usuario", kardex.Id_usuario);
                cmd.Parameters.AddWithValue("@Tipo", kardex.Tipo);
                cmd.Parameters.AddWithValue("@Estado", kardex.Estado);
                cmd.Parameters.AddWithValue("@Id_caja", kardex.Id_caja);

                //UnidadesProductos
                cmd.Parameters.AddWithValue("@idUnidadCompra", unidadesProductos.idUnidadCompra);
                cmd.Parameters.AddWithValue("@idUnidadVenta", unidadesProductos.idUnidadVenta);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                return false;

            }
        }
        public bool editarProductos(Lproductos productos, LKardex kardex, UnidadesProductos unidadesProductos)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("Editarproducto", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                //Productos
                cmd.Parameters.AddWithValue("@idProducto", productos.idProducto);
                cmd.Parameters.AddWithValue("@idCategoria", productos.idCategoria);
                cmd.Parameters.AddWithValue("@Codigo", productos.Codigo);
                cmd.Parameters.AddWithValue("@Descripcion", productos.Descripcion);
                cmd.Parameters.AddWithValue("@PrecioCompra", productos.Preciodecompra);
                cmd.Parameters.AddWithValue("@Stock", productos.Stock);
                cmd.Parameters.AddWithValue("@idImpuesto", productos.idImpuesto);
                cmd.Parameters.AddWithValue("@idPrecios", productos.idPrecios);
                cmd.Parameters.AddWithValue("@idDescuento", productos.idDescuento);

                //UnidadesProductos
                cmd.Parameters.AddWithValue("@idUnidadCompra", unidadesProductos.idUnidadCompra);
                cmd.Parameters.AddWithValue("@idUnidadVenta", unidadesProductos.idUnidadVenta);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                return false;

            }
        }
        public bool insertarDetalleProducto(Lproductos productos)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarDetalleProducto", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                //Productos
                cmd.Parameters.AddWithValue("@idProducto", productos.idProducto);
                cmd.Parameters.AddWithValue("@idProveedor", productos.idProveedor);
                cmd.Parameters.AddWithValue("@Localizacion", productos.Localizacion);
                cmd.Parameters.AddWithValue("@StockMinimo", productos.StockMinimo);
                cmd.Parameters.AddWithValue("@UsoInterno", productos.usointerno);
                cmd.Parameters.AddWithValue("@Granel", productos.granel);
                cmd.Parameters.AddWithValue("@Peso", productos.Peso);
                cmd.Parameters.AddWithValue("@FechaVencimiento", productos.FechaVencimiento);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                return false;

            }
        }
        public bool editarDetalleProductos(Lproductos productos)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("editarDetalleProducto", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                //Productos

                cmd.Parameters.AddWithValue("@idDetalleProducto", productos.idDetalleProductos);
                cmd.Parameters.AddWithValue("@idProducto", productos.idProducto);
                cmd.Parameters.AddWithValue("@idProveedor", productos.idProveedor);
                cmd.Parameters.AddWithValue("@Localizacion", productos.Localizacion);
                cmd.Parameters.AddWithValue("@StockMinimo", productos.StockMinimo);
                cmd.Parameters.AddWithValue("@UsoInterno", productos.usointerno);
                cmd.Parameters.AddWithValue("@Granel", productos.granel);
                cmd.Parameters.AddWithValue("@Peso", productos.Peso);
                cmd.Parameters.AddWithValue("@FechaVencimiento", productos.FechaVencimiento);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                return false;

            }
        }
        public bool insertarMunicipio(LDireccion parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertar_municipio", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcion", parametros.Municipio);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                return false;

            }
        }
        public bool insertarSector(LDireccion parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertar_sector", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcion", parametros.Sector);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                return false;

            }
        }

        public bool insertarRegion(LDireccion parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertar_region", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcion", parametros.Region);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                return false;

            }
        }



        public bool insertarTelefono(LTelefono parametros, int idTipoTelefono)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarTelefono", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Telefono", parametros.Telefono);
                cmd.Parameters.AddWithValue("@idTipoTelefono", idTipoTelefono);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                return true;
            }
        }

        public static bool ProcesarPedido(int idPedido)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("ProcesarPedido", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPedido", idPedido);
                cmd.ExecuteNonQuery();
                CONEXIONMAESTRA.cerrar();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return true;
            }
        }

        public static bool ActualizarDatosEmpleado(int idEmpleado)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("ActualizarDatosEmpleado", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                cmd.ExecuteNonQuery();
                CONEXIONMAESTRA.cerrar();
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
        public static bool ActualizarDatosVehiculo(int idVehiculo)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("ActualizarDatosVehiculo", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idVehiculo", idVehiculo);
                cmd.ExecuteNonQuery();
                CONEXIONMAESTRA.cerrar();
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
        public static bool insertar_Gastos_varios(DateTime fecha,string Nro_documento,
          string  Tipo_comprobante, double Importe,string Descripcion,int Id_caja,int Id_concepto)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertar_Gastos_varios", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Fecha", fecha);
                cmd.Parameters.AddWithValue("@Nro_documento", Nro_documento);
                cmd.Parameters.AddWithValue("@Tipo_comprobante", Tipo_comprobante);
                cmd.Parameters.AddWithValue("@Importe", Importe);
                cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
                cmd.Parameters.AddWithValue("@Id_caja", Id_caja);
                cmd.Parameters.AddWithValue("@Id_concepto", Id_concepto);
                cmd.ExecuteNonQuery();
                CONEXIONMAESTRA.cerrar();
                return true;        
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                return false;
            }
        }
        public static bool insertar_Ingresos_varios(DateTime fecha, string Nro_documento,
         string Tipo_comprobante, double Importe, string Descripcion, int Id_caja)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertar_Ingresos_varios", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Fecha", fecha);
                cmd.Parameters.AddWithValue("@Nro_comprobante", Nro_documento);
                cmd.Parameters.AddWithValue("@Tipo_comprobante", Tipo_comprobante);
                cmd.Parameters.AddWithValue("@Importe", Importe);
                cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
                cmd.Parameters.AddWithValue("@Id_caja", Id_caja);
             
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }

        public  bool insertar_CreditoPorPagar(LcreditosPorPagar parametros)
        {
            try
            {
                Obtener_datos.Obtener_id_caja_PorSerial(ref idcaja);
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertar_CreditoPorPagar", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Descripcion", parametros.Descripcion);
                cmd.Parameters.AddWithValue("@Fecha_registro", parametros.Fecha_registro);
                cmd.Parameters.AddWithValue("@Fecha_vencimiento", parametros.Fecha_vencimiento);
                cmd.Parameters.AddWithValue("@Total", parametros.Total);
                cmd.Parameters.AddWithValue("@Saldo", parametros.Saldo);
                cmd.Parameters.AddWithValue("@Estado", "DEBE");
                cmd.Parameters.AddWithValue("@Id_caja", idcaja);
                cmd.Parameters.AddWithValue("@Id_Proveedor", parametros.Id_proveedor );
                cmd.ExecuteNonQuery() ;
                return true;                       
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                return false;
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }

        }
        public bool insertar_Proveedores(Lproveedores parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertar_Proveedores", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPersona", parametros.idPersona);
                cmd.Parameters.AddWithValue("@IdentificadorFiscal", parametros.IdentificadorFiscal);
                cmd.Parameters.AddWithValue("@Estado","ACTIVO");
                cmd.Parameters.AddWithValue("@Saldo", 0);
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }

        public bool InsertarVehiculos(LVehiculos parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("InsertarVehiculo", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idTipoVehiculo", parametros.idTipoVehiculo);
                cmd.Parameters.AddWithValue("@NPlaca", parametros.NPlaca);
                cmd.Parameters.AddWithValue("@Transmision", parametros.Transmision);
                cmd.Parameters.AddWithValue("@Color", parametros.Color);
                cmd.Parameters.AddWithValue("@Marca", parametros.Marca);
                cmd.Parameters.AddWithValue("@Modelo", parametros.Modelo);
                cmd.Parameters.AddWithValue("@Ano", parametros.Ano);
                cmd.Parameters.AddWithValue("@Capacidad", parametros.Carga);
                cmd.Parameters.AddWithValue("@Icono", parametros.icono);
                cmd.Parameters.AddWithValue("@Estado", "ACTIVO");
                cmd.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                return true;
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }

        }
        public bool insertar_clientes(Lclientes parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertar_clientes", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPersona", parametros.idPersona);
                cmd.Parameters.AddWithValue("@IdentificadorFiscal", parametros.IdentificadorFiscal);
                cmd.Parameters.AddWithValue("@Estado", "ACTIVO");
                cmd.Parameters.AddWithValue("@Saldo", 0);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }
        public bool insertar_CreditoPorCobrar(LcreditoPorCobrar  parametros)
        {
            try
            {
                Obtener_datos.Obtener_id_caja_PorSerial(ref idcaja);
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertar_CreditoPorCobrar", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Descripcion", parametros.Descripcion);
                cmd.Parameters.AddWithValue("@Fecha_registro", parametros.Fecha_registro);
                cmd.Parameters.AddWithValue("@Fecha_vencimiento", parametros.Fecha_vencimiento);
                cmd.Parameters.AddWithValue("@Total", parametros.Total);
                cmd.Parameters.AddWithValue("@Saldo", parametros.Saldo);
                cmd.Parameters.AddWithValue("@Estado", "DEBE");
                cmd.Parameters.AddWithValue("@Id_caja", idcaja);
                cmd.Parameters.AddWithValue("@Id_cliente", parametros.Id_cliente);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                return false;
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }

        }
        public bool Insertar_ControlCobros(Lcontrolcobros parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("Insertar_controlcobros", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Monto", parametros.Monto);
                cmd.Parameters.AddWithValue("@Fecha", parametros.Fecha);
                cmd.Parameters.AddWithValue("@Detalle", parametros.Detalle);
                cmd.Parameters.AddWithValue("@IdCliente", parametros.IdCliente);
                cmd.Parameters.AddWithValue("@IdUsuario", parametros.IdUsuario);
                cmd.Parameters.AddWithValue("@IdCaja", parametros.IdCaja);
                cmd.Parameters.AddWithValue("@Comprobante", parametros.Comprobante);
                cmd.Parameters.AddWithValue("@efectivo", parametros.efectivo);
                cmd.Parameters.AddWithValue("@tarjeta", parametros.tarjeta);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return true;
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }
        public bool insertar_ControlPago(Lcontrolpagos parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarControlPago", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Monto", parametros.Monto);
                cmd.Parameters.AddWithValue("@Fecha", DateTime.Now);
                cmd.Parameters.AddWithValue("@Detalle", parametros.Detalle);
                cmd.Parameters.AddWithValue("@idProveedor", parametros.idProveedor);
                cmd.Parameters.AddWithValue("@IdUsuario", parametros.IdUsuario);
                cmd.Parameters.AddWithValue("@IdCaja", parametros.IdCaja);
                cmd.Parameters.AddWithValue("@Comprobante", parametros.Comprobante);
                cmd.Parameters.AddWithValue("@efectivo", parametros.efectivo);
                cmd.Parameters.AddWithValue("@tarjeta", parametros.tarjeta);
                cmd.Parameters.AddWithValue("@TransferenciaBancaria", parametros.Transferencia);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return true;
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }
        public bool insertar_ControlPagoFacturaExterna(Lcontrolpagos parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarFacturaExterna", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NumFact", parametros.numFact);
                cmd.Parameters.AddWithValue("@Monto", parametros.Monto);
                cmd.Parameters.AddWithValue("@Detalle", parametros.Detalle);
                cmd.Parameters.AddWithValue("@Fecha", DateTime.Now);
                cmd.Parameters.AddWithValue("@idProveedor", parametros.idProveedor);
                cmd.Parameters.AddWithValue("@IdUsuario", parametros.IdUsuario);
                cmd.Parameters.AddWithValue("@IdCaja", parametros.IdCaja);
                cmd.Parameters.AddWithValue("@Comprobante", parametros.Comprobante);
                cmd.Parameters.AddWithValue("@efectivo", parametros.efectivo);
                cmd.Parameters.AddWithValue("@tarjeta", parametros.tarjeta);
                cmd.Parameters.AddWithValue("@TransferenciaBancaria", parametros.Transferencia);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return true;
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }
        //Kardex

        public bool insertar_KARDEX_Entrada(LKardex parametros)
        {
            try
            {
                Obtener_datos.mostrar_inicio_De_sesion(ref idusuario);
                Obtener_datos.Obtener_id_caja_PorSerial(ref idcaja);
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertar_KARDEX_Entrada", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Fecha",parametros.Fecha);
                cmd.Parameters.AddWithValue("@Motivo", parametros.Motivo );
                cmd.Parameters.AddWithValue("@Cantidad", parametros.Cantidad);
                cmd.Parameters.AddWithValue("@Id_producto", parametros.Id_producto);
                cmd.Parameters.AddWithValue("@Id_usuario", idusuario);
                cmd.Parameters.AddWithValue("@Tipo", "ENTRADA");
                cmd.Parameters.AddWithValue("@Estado", "DESPACHO CONFIRMADO");
                cmd.Parameters.AddWithValue("@Id_caja", idcaja);
                cmd.ExecuteNonQuery();
                return true;
           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return true;
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }
        public bool insertar_KARDEX_SALIDA(LKardex parametros)
        {
            try
            {
                Obtener_datos.mostrar_inicio_De_sesion(ref idusuario);
                Obtener_datos.Obtener_id_caja_PorSerial(ref idcaja);
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertar_KARDEX_SALIDA", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Fecha", parametros.Fecha);
                cmd.Parameters.AddWithValue("@Motivo", parametros.Motivo);
                cmd.Parameters.AddWithValue("@Cantidad", parametros.Cantidad);
                cmd.Parameters.AddWithValue("@Id_producto", parametros.Id_producto);
                cmd.Parameters.AddWithValue("@Id_usuario", idusuario);
                cmd.Parameters.AddWithValue("@Tipo", "SALIDA");
                cmd.Parameters.AddWithValue("@Estado", "DESPACHO CONFIRMADO");
                cmd.Parameters.AddWithValue("@Id_caja", idcaja);
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return true;
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }

        public bool insertarEmpleado(LEmpleados parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarEmpleados", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPersona", parametros.idPersona);
                cmd.Parameters.AddWithValue("@idHorario", parametros.idHorario);
                cmd.Parameters.AddWithValue("@cuentaBanco", parametros.cuentaBanco);
                cmd.Parameters.AddWithValue("@departamento", parametros.departamento);
                cmd.Parameters.AddWithValue("@banco", parametros.banco);
                cmd.Parameters.AddWithValue("@icono", parametros.icono);
                cmd.Parameters.AddWithValue("@estado", "ACTIVO");
                cmd.Parameters.AddWithValue("@idEmpresa", 1);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return true;
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }

        public bool insertarPedido(Pedidos parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertar_pedido", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCliente", parametros.idCliente);
                cmd.Parameters.AddWithValue("@idfactura", parametros.idfactura);
                cmd.Parameters.AddWithValue("@idEmpleado", parametros.idEmpleado);
                cmd.Parameters.AddWithValue("@idVehiculo", parametros.idVehiculo);
                cmd.Parameters.AddWithValue("@FechaEnvio", parametros.FechaEnvio);
                cmd.Parameters.AddWithValue("@Destinatario", parametros.Destinatario);
                cmd.Parameters.AddWithValue("@DireccionDestinatario", parametros.DireccionDestinatario);
                cmd.Parameters.AddWithValue("@Estado", parametros.Estado);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return true;
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }

    }
}
