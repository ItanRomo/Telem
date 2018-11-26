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
    public partial class GroundStation : Form
    {
        public GroundStation()
        {
            InitializeComponent();
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            /*
            This event will create a file with all airplane data
            //Maybe we shall create a Thread to write on the document
            Or maybe it could be in the same Thread than SerialPort
            | Time | Latitude | Longitude | Altitude | Speed | Direction |

            */
        }


    }
}
