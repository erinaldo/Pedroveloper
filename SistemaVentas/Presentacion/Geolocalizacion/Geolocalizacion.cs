using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using SistemaVentas.Logica;

namespace SistemaVentas.Presentacion.Geolocalizacion
{
    public partial class Geolocalizacion : Form
    {
        GMarkerGoogle marker;
        GMapOverlay markerOverlay;
        DataTable dt;

        bool trazarRuta = false;
        int ContadorIndicadoresRuta = 0;
        PointLatLng inicio;
        PointLatLng final;

        int filaSeleccionada = 0;
        double LatInicial = 19.5663208725355;
        double LngInicial = -70.876225233078;

        public Geolocalizacion()
        {
            InitializeComponent();
        }

        private void Geolocalizacion_Load(object sender, EventArgs e)
        {
            GMapProviders.GoogleMap.ApiKey = @"AIzaSyAv4Lhhah38GEMDVCunk-sadsadsad";
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            Mapa.CacheLocation = @"cache";
            Mapa.DragButton = MouseButtons.Left;
            Mapa.MapProvider = GMapProviders.GoogleMap;
            Mapa.ShowCenter = false;
            //
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("Descripcion",typeof(string)));
            dt.Columns.Add(new DataColumn("Lat",typeof(double)));
            dt.Columns.Add(new DataColumn("Long",typeof(double)));

            dt.Rows.Add("Ubicacion 1", LatInicial, LngInicial);
            datalistadoLocalizacion.DataSource = dt;
            Bases.Multilinea(ref datalistadoLocalizacion);
            datalistadoLocalizacion.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            datalistadoLocalizacion.AutoResizeColumns();

            datalistadoLocalizacion.Columns[1].Visible = false;
            datalistadoLocalizacion.Columns[2].Visible = false;

            Mapa.DragButton = MouseButtons.Left;
            Mapa.CanDragMap = true;
            Mapa.MapProvider = GMapProviders.GoogleMap;
            Mapa.Position = new PointLatLng(LatInicial, LngInicial);
            Mapa.MinZoom = 0;
            Mapa.MaxZoom = 24;
            Mapa.Zoom = 9;
            Mapa.AutoScroll = true;

            // Marcador
            markerOverlay = new GMapOverlay("Marcador");
            marker = new GMarkerGoogle(new PointLatLng(LatInicial, LngInicial), GMarkerGoogleType.green);
            markerOverlay.Markers.Add(marker);

            // tooltip
            marker.ToolTipMode = MarkerTooltipMode.Always;
            marker.ToolTipText = string.Format("Ubicacion: \n Latitud:{0} \n Longitud: {1}", LatInicial, LngInicial);

            // agregar overlay en el mapa control
            Mapa.Overlays.Add(markerOverlay);
        }

        private void datalistadoLocalizacion_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            filaSeleccionada = e.RowIndex; // No. fila
            // Recuperar los datos del grid y los asignamos a los textbox

            txtDescripcion.Text = datalistadoLocalizacion.Rows[filaSeleccionada].Cells[0].Value.ToString();
            txtLatitud.Text = datalistadoLocalizacion.Rows[filaSeleccionada].Cells[1].Value.ToString();
            txtLongitud.Text = datalistadoLocalizacion.Rows[filaSeleccionada].Cells[2].Value.ToString();

            marker.Position = new PointLatLng(Convert.ToDouble(txtLatitud.Text), Convert.ToDouble(txtLongitud.Text));

            Mapa.Position = marker.Position;
        }

        private void Mapa_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            double lat = Mapa.FromLocalToLatLng(e.X, e.Y).Lat;
            double lng = Mapa.FromLocalToLatLng(e.X, e.Y).Lng;

            txtLatitud.Text = lat.ToString();
            txtLongitud.Text = lng.ToString();

            //Bitmap bmpMarker = Image.FromFile("img/")

            marker.Position = new PointLatLng(lat, lng);
            marker.ToolTipText = string.Format("Ubicación: \n Latitud: {0} \n Longitud:{1}", lat, lng);
            CrearDireccionTrazarRuta( lat, lng);


        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            dt.Rows.Add(txtDescripcion.Text, txtLatitud.Text, txtLongitud.Text);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            datalistadoLocalizacion.Rows.RemoveAt(filaSeleccionada);

        }

        private void btnPoligono_Click(object sender, EventArgs e)
        {
            GMapOverlay Poligono = new GMapOverlay("Poligono");
            List<PointLatLng> puntos = new List<PointLatLng>();
            double lng, lat;

            for(int filas = 0;  filas < datalistadoLocalizacion.Rows.Count; filas++)
            {
                lat = Convert.ToDouble(datalistadoLocalizacion.Rows[filas].Cells[1].Value);
                lng = Convert.ToDouble(datalistadoLocalizacion.Rows[filas].Cells[2].Value);
                puntos.Add(new PointLatLng(lat, lng));
            }

            GMapPolygon poligonoPuntos = new GMapPolygon(puntos, "Plogino");
            Poligono.Polygons.Add(poligonoPuntos);
            Mapa.Overlays.Add(Poligono);
            Mapa.Zoom = Mapa.Zoom + 1;
            Mapa.Zoom = Mapa.Zoom - 1;
        }

        private void btnRuta_Click(object sender, EventArgs e)
        {
            GMapOverlay Ruta = new GMapOverlay("Poligono");
            List<PointLatLng> puntos = new List<PointLatLng>();
            double lng, lat;

            for (int filas = 0; filas < datalistadoLocalizacion.Rows.Count; filas++)
            {
                lat = Convert.ToDouble(datalistadoLocalizacion.Rows[filas].Cells[1].Value);
                lng = Convert.ToDouble(datalistadoLocalizacion.Rows[filas].Cells[2].Value);
                puntos.Add(new PointLatLng(lat, lng));
            }

            GMapRoute poligonoRutas = new GMapRoute(puntos, "Ruta");
            Ruta.Routes.Add(poligonoRutas);
            Mapa.Overlays.Add(Ruta);
            Mapa.Zoom = Mapa.Zoom + 1;
            Mapa.Zoom = Mapa.Zoom - 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            trazarRuta = true;
            button1.Enabled = false;
        }

        public void CrearDireccionTrazarRuta(double lat, double lng)
        {
          
            if (trazarRuta)
            {
                switch (ContadorIndicadoresRuta)
                {
                    case 0: // inicio
                        ContadorIndicadoresRuta++;
                        inicio = new PointLatLng(lat, lng);
                        break;
                    case 1: // final
                        ContadorIndicadoresRuta++;
                        final = new PointLatLng(lat, lng);
                        GDirections direccion1;

                        var RutasDireccion = GMapProviders.GoogleMap.GetDirections(out direccion1, inicio, final, false,false, false, false, false);
                        GMapRoute RutaObtenida = new GMapRoute(direccion1.Route, "Ruta");
                        GMapOverlay CapaRutas = new GMapOverlay("Ruta");
                        CapaRutas.Routes.Add(RutaObtenida);
                        Mapa.Overlays.Add(CapaRutas);
                        Mapa.Zoom = Mapa.Zoom + 1;
                        Mapa.Zoom = Mapa.Zoom - 1;
                        ContadorIndicadoresRuta = 0;
                        trazarRuta = false;
                        button1.Enabled = true;
                        break;
                }
            }
        }

        private void Mapa_Load(object sender, EventArgs e)
        {

        }

        public const double EarthRadius = 6371;
        public static double GetDistance()
        {
            double distance = 0;
            double Lat = (19.5235528916917 - 19.5663208725355) * (Math.PI / 180);
            double Lon = ( (-71.0842895507813) - (-70.876225233078) ) * (Math.PI / 180);
            double a = Math.Sin(Lat / 2) * Math.Sin(Lat / 2) + Math.Cos(19.5663208725355 * (Math.PI / 180)) * Math.Cos(19.5235528916917 * (Math.PI / 180)) * Math.Sin(Lon / 2) * Math.Sin(Lon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            distance = EarthRadius * c;
            return distance;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Double result = GetDistance() / 1000;
            MessageBox.Show(result.ToString());
        }

        private void panelDataListadoLocalizacion_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void txtLongitud_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtLatitud_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
