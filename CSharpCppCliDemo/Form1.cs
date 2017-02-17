using GLWrapper;
using System;
using System.Windows.Forms;

namespace CSharpCppCliDemo
{
    public partial class Form1 : Form
    {
        Renderer renderer;
        public Form1()
        {
            InitializeComponent();

            // use the panel as rendering surface
            renderer = new Renderer(panel1.Handle);
            panel1.Paint += Panel1_Paint;

            // synchronize settings
            trkLong_Scroll(null, null);
            trkLat_Scroll(null, null);
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            renderer.Draw();
        }

        private void trkLong_Scroll(object sender, EventArgs e)
        {
            renderer.Longitude = trkLong.Value * 2.0 * Math.PI / 359.0;
            renderer.Draw();
        }

        private void trkLat_Scroll(object sender, EventArgs e)
        {
            renderer.Latitude = (trkLat.Value / 179.0 - 0.5)*Math.PI*0.9;
            renderer.Draw();
        }
    }
}
