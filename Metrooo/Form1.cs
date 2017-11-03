using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Metrooo
{
    public partial class frmPrueba : MetroFramework.Forms.MetroForm
    {
        public frmPrueba()
        {
            Thread thread = new Thread(new ThreadStart(Metodo));
            thread.Start();
            InitializeComponent();
            string tiempo = string.Empty;
            for (int i = 0; i < 1000000; i++)
            {
                tiempo += i.ToString();
            }
            thread.Abort();
        }
        Mutex mutex = new Mutex();
        void Metodo()
        {
            mutex.WaitOne();
            SplashScreen.SplashForm frm = new SplashScreen.SplashForm();
            frm.Name = "Dashboard";
            Application.Run(frm);
            mutex.ReleaseMutex();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            MetroFramework.MetroMessageBox.Show(this,"Hola bienvenido a Skype","Skype",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
