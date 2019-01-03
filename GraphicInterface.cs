using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class GraphicInterface : Form
    {
        public GraphicInterface()
        {
            InitializeComponent();
        }

        private void GraphicInterface_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0); //sobra si tienes la posición en el diseño
            this.Size = new Size(this.Width, Screen.PrimaryScreen.WorkingArea.Size.Height);
        }

        private void lbAlt_Click(object sender, EventArgs e)
        {

        }

        private void btnData_Click(object sender, EventArgs e)
        {
            pnlFlightData.Visible = true;
            pnlRecordedData.Visible = false;
        }

        private void btnRecorded_Click(object sender, EventArgs e)
        {
            pnlFlightData.Visible = false;
            pnlRecordedData.Visible = true;
        }

        private void btnRec_Click(object sender, EventArgs e)
        {
            pbRec.Visible = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            pbRec.Visible = false;
        }
    }
}
