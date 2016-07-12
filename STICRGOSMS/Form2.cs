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
    public partial class Form2 : Form
    {

        private MySqlConnection connection = new MySqlConnection();
        Form3 frm3;
        Form4 frm4;
        Form5 frm5;

        public Form2()
        {
            InitializeComponent();
            connection.ConnectionString = "server=localhost;uid=root;" + "pwd=rowellmandac;database=students;";
            frm3 = new Form3(this);
            frm4 = new Form4(this);
            frm5 = new Form5(this);
        }

        private void NextButt_Form2_Click(object sender, EventArgs e)
        {
            if (academicYear_txtbox.Text.Equals("") || string.IsNullOrEmpty(surname_txtbox.Text) || string.IsNullOrEmpty(firstname_txtbox.Text) || string.IsNullOrEmpty(studentno_txtbox.Text) || string.IsNullOrEmpty(program_combobox.Text) || string.IsNullOrEmpty(year_combobox.Text) || string.IsNullOrEmpty(status_combobox.Text) || string.IsNullOrEmpty(nationality_txtbox.Text) || string.IsNullOrEmpty(religion_combobox.Text) || string.IsNullOrEmpty(gender_combobox.Text) || string.IsNullOrEmpty(cellno_txtbox.Text) || string.IsNullOrEmpty(emailadd_txtbox.Text) || string.IsNullOrEmpty(presentadd_txtbox.Text) || string.IsNullOrEmpty(permaaddress_txtbox.Text) || string.IsNullOrEmpty(provaddress_txtbox.Text) || birthday_dtp.Text.Equals(DateTime.Now.ToShortDateString())) 
            {
                MessageBox.Show("Please fill up all required fields.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                label26.Visible = true;
                label27.Visible = true;
                label29.Visible = true;
                label30.Visible = true;
                label31.Visible = true;
                label32.Visible = true;
                label33.Visible = true;
                label34.Visible = true;
                label35.Visible = true;
                label36.Visible = true;
                label37.Visible = true;
                label38.Visible = true;
                label39.Visible = true;
                label40.Visible = true;
                label41.Visible = true;
                label42.Visible = true;
                label43.Visible = true;
                label44.Visible = true;

                if (!surname_txtbox.Text.Equals(""))
                {
                    label26.Visible = false;
                }
                if (!firstname_txtbox.Text.Equals(""))
                {
                    label27.Visible = false;
                }
                if (!studentno_txtbox.Text.Equals(""))
                {
                    label29.Visible = false;
                }
                if (!program_combobox.Text.Equals(""))
                {
                    label30.Visible = false;
                }
                if (!year_combobox.Text.Equals(""))
                {
                    label31.Visible = false;
                }
                if (!nickname_txtbox.Text.Equals(""))
                {
                    label32.Visible = false;
                }
                if (!nationality_txtbox.Text.Equals(""))
                {
                    label33.Visible = false;
                }
                if (!gender_combobox.Text.Equals(""))
                {
                    label34.Visible = false;
                }
                if (!status_combobox.Text.Equals(""))
                {
                    label35.Visible = false;
                }
                if (!religion_combobox.Text.Equals(""))
                {
                    label36.Visible = false;
                }
                if (DateTime.Now.ToShortDateString() != birthday_dtp.Text)
                {
                    label37.Visible = false;
                }
                if (!cellno_txtbox.Text.Equals(""))
                {
                    label38.Visible = false;
                }
                if (!emailadd_txtbox.Text.Equals(""))
                {
                    label39.Visible = false;
                }
                if (!presentadd_txtbox.Text.Equals(""))
                {
                    label40.Visible = false;
                }
                if (!permaaddress_txtbox.Text.Equals(""))
                {
                    label41.Visible = false;
                }
                if (!provaddress_txtbox.Text.Equals(""))
                {
                    label42.Visible = false;
                }
                if (!academicYear_txtbox.Text.Equals(""))
                {
                    label43.Visible = false;
                }
                if (firstSem_rdbtn.Checked || secondSem_rdbtn.Checked || summer_rdbtn.Checked)
                {
                    label44.Visible = false;
                }
            }
            else
            {
                DialogResult dr = MessageBox.Show("Continue?", "Continue", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        connection.Open();
                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = connection;

                        if (firstSem_rdbtn.Checked)
                        {
                            cmd.CommandText = "insert into studInfo values('" + studentno_txtbox.Text + "', '" + surname_txtbox.Text + "', '" + firstname_txtbox.Text + "', '" + middlename_txtbox.Text + "', '" + nickname_txtbox.Text + "', '" + interviewDate.Text + "', '"+ academicYear_txtbox.Text +"', '" + program_combobox.Text + "', '" + year_combobox.Text + "', '" + firstSem_rdbtn.Text + "', '" + nationality_txtbox.Text + "', '" + gender_combobox.Text + "', '" + status_combobox.Text + "', '" + religion_combobox.Text + "', '" + birthday_dtp.Text + "', '" + cellno_txtbox.Text + "', '" + emailadd_txtbox.Text + "', '" + presentadd_txtbox.Text + "', '" + permaaddress_txtbox.Text + "', '" + provaddress_txtbox.Text + "')";
                        }
                        else if (secondSem_rdbtn.Checked)
                        {
                            cmd.CommandText = "insert into studInfo values('" + studentno_txtbox.Text + "', '" + surname_txtbox.Text + "', '" + firstname_txtbox.Text + "', '" + middlename_txtbox.Text + "', '" + nickname_txtbox.Text + "', '" + interviewDate.Text + "', '" + academicYear_txtbox.Text + "', '" + program_combobox.Text + "', '" + year_combobox.Text + "', '" + secondSem_rdbtn.Text + "', '" + nationality_txtbox.Text + "', '" + gender_combobox.Text + "', '" + status_combobox.Text + "', '" + religion_combobox.Text + "', '" + birthday_dtp.Text + "', '" + cellno_txtbox.Text + "', '" + emailadd_txtbox.Text + "', '" + presentadd_txtbox.Text + "', '" + permaaddress_txtbox.Text + "', '" + provaddress_txtbox.Text + "')";
                        }
                        else
                        {
                            cmd.CommandText = "insert into studInfo values('" + studentno_txtbox.Text + "', '" + surname_txtbox.Text + "', '" + firstname_txtbox.Text + "', '" + middlename_txtbox.Text + "', '" + nickname_txtbox.Text + "', '" + interviewDate.Text + "', '" + academicYear_txtbox.Text + "', '" + program_combobox.Text + "', '" + year_combobox.Text + "', '" + summer_rdbtn.Text + "', '" + nationality_txtbox.Text + "', '" + gender_combobox.Text + "', '" + status_combobox.Text + "', '" + religion_combobox.Text + "', '" + birthday_dtp.Text + "', '" + cellno_txtbox.Text + "', '" + emailadd_txtbox.Text + "', '" + presentadd_txtbox.Text + "', '" + permaaddress_txtbox.Text + "', '" + provaddress_txtbox.Text + "')";
                        }
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception q)
                    {
                        MessageBox.Show(q.Message.ToString());
                    }
                    connection.Close();

                    this.Hide();
                    frm3.Show();
                }       
            }
        }

        private void surname_txtbox_TextChanged(object sender, EventArgs e)
        {
            label26.Visible = false;
        }

        private void firstname_txtbox_TextChanged(object sender, EventArgs e)
        {
            label27.Visible = false;
        }

        private void studentno_txtbox_TextChanged(object sender, EventArgs e)
        {
            label29.Visible = false;
        }

        private void program_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            label30.Visible = false;
        }

        private void year_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            label31.Visible = false;
        }

        private void nickname_txtbox_TextChanged(object sender, EventArgs e)
        {
            label32.Visible = false;
        }

        private void nationality_txtbox_TextChanged(object sender, EventArgs e)
        {
            label33.Visible = false;
        }

        private void gender_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            label34.Visible = false;
        }

        private void status_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            label35.Visible = false;
        }

        private void religion_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            label36.Visible = false;
        }

        private void birthday_dtp_ValueChanged(object sender, EventArgs e)
        {
            label37.Visible = false;
        }

        private void cellno_txtbox_TextChanged(object sender, EventArgs e)
        {
            label38.Visible = false;
        }

        private void emailadd_txtbox_TextChanged(object sender, EventArgs e)
        {
            label39.Visible = false;
        }

        private void presentadd_txtbox_TextChanged(object sender, EventArgs e)
        {
            label40.Visible = false;
        }

        private void permaaddress_txtbox_TextChanged(object sender, EventArgs e)
        {
            label41.Visible = false;
        }

        private void provaddress_txtbox_TextChanged(object sender, EventArgs e)
        {
            label42.Visible = false;
        }

        private void academicYear_txtbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            label43.Visible = false;
        }

        private void firstSem_rdbtn_CheckedChanged(object sender, EventArgs e)
        {
            label44.Visible = false;
        }

        private void cellno_txtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void status_combobox_Validated(object sender, EventArgs e)
        {
            if (status_combobox.Text.Equals("Married"))
            {
                frm3.spouseName_txtbox.Enabled = true;
                frm3.spouseage_txtbox.Enabled = true;
                frm3.spouse_contactNo.Enabled = true;
                frm3.workingYes.Enabled = true;
                frm3.workingNo.Enabled = true;
            }
        }

    }
}
