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
        private bool rec = false;

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
            if (pnlRecordedData.Visible)
            {
                pnlFlightData.Visible = true;
                pnlRecordedData.Visible = false;
            }
        }

        private void btnRecorded_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnDisconnect.Enabled)
                {
                    throw new ApplicationException("The program is recieving data, please disconnect before open 'Recorded Data'");
                }
                else if (pnlFlightData.Visible)
                     {
                        pnlFlightData.Visible = false;
                        pnlRecordedData.Visible = true;
                     }
            }
            catch(ApplicationException error)
            {
                MessageBox.Show(error.Message);
            }
            
        }

        private void btnRec_Click(object sender, EventArgs e)
        {
            //Crear otro hilo en donde se almacenen todos los datos en una tabla
            pbRec.Visible = true;
            btnRec.Enabled = false;
            btnStop.Enabled = true;
            rec = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            pbRec.Visible = false;
            btnRec.Enabled = true;
            btnStop.Enabled = false;
            rec = false;
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            try
            {
                if((cmbSpeed.SelectedItem == null)) //Falta agregar que cmbPorts no esté vacía igual
                {
                    throw new ApplicationException();
                }
                else
                {
                    //Agregar todas las asignaciones correspondientes a la comunicación serial con puerto y baud rate

                    btnConnect.Enabled = true;
                    btnVerify.Enabled = false;
                }
            }
            catch(ApplicationException)
            {
                MessageBox.Show("Baud Rate and/or Serial Ports not selected correctly");
            }
        }

        private void cmbSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnConnect.Enabled = false;
            btnVerify.Enabled = true;
        }

        private void cmbPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnConnect.Enabled = false;
            btnVerify.Enabled = true;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                //Código para comenzar la comunicación con el puerto serial incluyendo la condicional

                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;
                cmbSpeed.Enabled = false;
                cmbPorts.Enabled = false;
                btnRec.Enabled = true;
                btnRecorded.Enabled = false;
                MessageBox.Show("Successfuly connected");
            }
            catch (ApplicationException)
            {
                btnConnect.Enabled = true;
                btnDisconnect.Enabled = false;
                cmbSpeed.Enabled = true;
                cmbPorts.Enabled = true;
                btnRec.Enabled = false;
                btnStop.Enabled = false;
                btnRecorded.Enabled = true;
                MessageBox.Show("Can not establish the required connection");
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (pbRec.Visible)
                {
                    throw new ApplicationException("The program is recording flight data, please stop recording before disconnect");
                }
                else
                {
                    //Código de desconección del puerto serial


                    btnConnect.Enabled = true;
                    btnDisconnect.Enabled = false;
                    cmbSpeed.Enabled = true;
                    cmbPorts.Enabled = true;
                    btnRec.Enabled = false;
                    btnStop.Enabled = false;
                    btnRecorded.Enabled = true;
                    MessageBox.Show("Successfuly disconnected");
                }
            }
            catch (ApplicationException error)
            {
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;
                cmbSpeed.Enabled = false;
                cmbPorts.Enabled = false;
                btnStop.Enabled = true;
                btnRecorded.Enabled = false;
                MessageBox.Show(error.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Se guardará la información que se tenga almacenada
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            //Poner para que actualice el mapa con las coordenadas de acuerdo al trackBar.SelectedIndex o algo parecido
            //Para buscar en el dataGridView con ese índice los elementos y actualizar el mapa con esas coordenadas, etc.
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            //Cuando se presione éste boton se realizará algo como trackBar.Maximum = dataGridView.TotalFiles o algo así
            //Para que se añadan exactamente todos los datos que tenemos en la tabla
        }
    }
}
