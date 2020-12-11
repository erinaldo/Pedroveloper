﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using SistemaVentas.Logica;
using System.IO;
using System.Xml;
using SistemaVentas.CONEXION;
using System.Security.Cryptography;
using SistemaVentas.Datos;
namespace SistemaVentas.Presentacion.LICENCIAS_MENBRESIAS
{
    public partial class MembresiasNuevo : Form
    {
        public MembresiasNuevo()
        {
            InitializeComponent();
        }
        string serialPc;
        string ruta;
        string dbcnString;
        string LicenciaDescifrada;
        private AES aes = new AES();
        string SerialPcLicencia;
        string FechaFinLicencia;
        string EstadoLicencia;
        string NombreSoftwareLicencia;
#pragma warning disable CS0169 // El campo 'MembresiasNuevo.Resultado' nunca se usa
        string Resultado;
#pragma warning restore CS0169 // El campo 'MembresiasNuevo.Resultado' nunca se usa
        private void btncomprar_Click(object sender, EventArgs e)
        {
            Process.Start("https://twitter.com/pedroveloper");
        }

        private void MembresiasNuevo_Load(object sender, EventArgs e)
        {
            obtenerSerialPc();
          

        }
        private void obtenerSerialPc()
        {
            Bases.Obtener_serialPC(ref serialPc);     
            txtSerial.Text = serialPc;

        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtSerial.Text);
        }

        private void btnActivacioManual_Click(object sender, EventArgs e)
        {
            dlg.Filter = "Licencias|*.xml";
            dlg.Title = "Cargador de Licencias";
            if (dlg.ShowDialog()==DialogResult.OK)
            {
                ruta = Path.GetFullPath(dlg.FileName);
                DescifrarLicencia();
                string cadena = LicenciaDescifrada;
                string[] separadas = cadena.Split('|');
                SerialPcLicencia = separadas[1];
                FechaFinLicencia = separadas[2];
                EstadoLicencia = separadas[3];
                NombreSoftwareLicencia = separadas[4];
                if (NombreSoftwareLicencia =="Ada_369")
                {
                    if (EstadoLicencia=="PENDIENTE")
                    {
                        if(SerialPcLicencia == serialPc)
                        {
                            activarLicenciaManual();
                        }
                    }
                }

            }
        }
        private void activarLicenciaManual()
        {
            Bases.Obtener_serialPC(ref serialPc);
            string fechaFin = Bases.Encriptar(FechaFinLicencia);
            string estado = Bases.Encriptar("?ACTIVADO PRO?");
            string  fechaActivacion = Bases.Encriptar(FechaInicio.Text);
            LMarcan parametros = new LMarcan();
            Editar_datos funcion = new Editar_datos();
            parametros.E = estado;
            parametros.FA = fechaActivacion;
            parametros.F = fechaFin;
            parametros.S = txtSerial.Text ;
            MessageBox.Show(txtSerial.Text);

            if (funcion.editarMarcan(parametros)==true)
            {
                MessageBox.Show("Licencia activada, se cerrara el sistema para un nuevo Inicio");
                Application.Exit();
            }
        }
        private void DescifrarLicencia()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(ruta);
                XmlElement root = doc.DocumentElement;
                dbcnString = root.Attributes.Item(0).Value;
                LicenciaDescifrada = (aes.Decrypt(dbcnString, Desencryptacion.appPwdUnique, int.Parse("256")));
            }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            catch (CryptographicException ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            {

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Process.Start("https://twitter.com/pedroveloper");
        }
    }
}
