using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;

namespace wella
{
    public partial class frmGmap : Form
    {

        double longi = 47.47495D;
        double lati = 19.06222D;
        public frmGmap(double longitude, double latitude, string label)
        {
            longi = longitude;
            lati=latitude;
            InitializeComponent();
            loadMapProviders();
            displayMap("OpenStreetMap");
            gmapWindow.Position = new GMap.NET.PointLatLng(longi, lati);
            GMap.NET.WindowsForms.GMapOverlay markers = new GMap.NET.WindowsForms.GMapOverlay("markers");
            GMap.NET.WindowsForms.GMapMarker marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(new GMap.NET.PointLatLng(longi, lati), GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red_small);
            marker.ToolTipText = label;
            markers.Markers.Add(marker);
            gmapWindow.Overlays.Add(markers);
        }

        void loadMapProviders()
        {
            cmbMapProviders.Items.Add("OpenStreetMap");
            cmbMapProviders.Items.Add("GoogleMaps");
            cmbMapProviders.Items.Add("GoogleSatellite");
            cmbMapProviders.SelectedIndex = 0;
        }

        void displayMap(string mapprov)
        {
            switch (mapprov)
            {
                case ("OpenStreetMap"):
                    gmapWindow.MapProvider = GMap.NET.MapProviders.OpenStreetMapProvider.Instance;
                    break;
                case ("GoogleMaps"):
                    gmapWindow.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
                    break;
                case ("GoogleSatellite"):
                    gmapWindow.MapProvider = GMap.NET.MapProviders.GoogleSatelliteMapProvider.Instance;
                    break;
            }
            
            gmapWindow.ShowCenter = false;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gmapWindow.DragButton = MouseButtons.Left;
            gmapWindow.MinZoom = 2;
            gmapWindow.MaxZoom = 20;
            gmapWindow.Zoom = 14;
        }

        private void cmbMapProviders_SelectedIndexChanged(object sender, EventArgs e)
        {
            displayMap(cmbMapProviders.SelectedItem.ToString());
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            gmapWindow.Zoom += 1;
            gmapWindow.Refresh();
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            gmapWindow.Zoom -= 1;
            gmapWindow.Refresh();
        }

        private void gmapWindow_MouseMove(object sender, MouseEventArgs e)
        {
            double lat = gmapWindow.FromLocalToLatLng(e.X, e.Y).Lat;
            double lng = gmapWindow.FromLocalToLatLng(e.X, e.Y).Lng;
            this.Text= "Lat: " + lat + ",  Long: " + lng;
        }
    }
}
