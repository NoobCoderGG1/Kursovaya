using Kursovaya.SelectedMenu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya
{
    public partial class MainMenu : Form
    {
        Control[] controls = new Control[] {new PersonellManagement(), new CarsInfo(), new ForceView()};
        
        public MainMenu()
        {
            InitializeComponent();
            panel1.Controls.Clear();
            panel1.Controls.Add(controls[2]);
        }

        private void PersonManageBtn_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(controls[0]);
        }

        private void CarViewInfoBtn_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(controls[1]);
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ForceViewBtn_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(controls[2]);
        }
    }
}
