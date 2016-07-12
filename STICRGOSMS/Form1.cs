using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace STICRGOSMS
{
    public partial class Form1 : Form
    {

        private MySqlConnection connection = new MySqlConnection();

        public Form1()
        {
            InitializeComponent();
        }

        private void login_butt_Click(object sender, EventArgs e)
        {

        }
    }
}
