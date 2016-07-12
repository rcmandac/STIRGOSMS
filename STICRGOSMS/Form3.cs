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
    public partial class Form3 : Form
    {

        private MySqlConnection connection = new MySqlConnection();
        Form2 f2;

        public Form3(Form2 fr2)
        {
            InitializeComponent();
            connection.ConnectionString = "server=localhost;uid=root;" + "pwd=rowellmandac;database=students;";
            f2 = fr2;
        }

        private void NextButt_Form3_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(fathername_txtbox.Text) || string.IsNullOrEmpty(fatherage_txtbox.Text) || string.IsNullOrEmpty(fthrnationality_txtbox.Text) || string.IsNullOrEmpty(fthreducatt_cmbbox.Text) || string.IsNullOrEmpty(fthroccupation_txtbox.Text) || string.IsNullOrEmpty(fthrcompany_txtbox.Text))
            {
                MessageBox.Show("Please fill up all required fields.");
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

                if (f2.status_combobox.Text.Equals("Married"))
                {
                    if (string.IsNullOrEmpty(spouseName_txtbox.Text) || string.IsNullOrEmpty(spouseage_txtbox.Text) || string.IsNullOrEmpty(spouse_contactNo.Text))
                    {
                        label43.Visible = true;
                        label44.Visible = true;
                        label45.Visible = true;
                    }
                    if (workingYes.Checked)
                    {
                        spouse_occupation.Enabled = true;

                        if (!string.IsNullOrEmpty(spouse_occupation.Text))
                        {
                            label46.Visible = true;
                        }
                    }
                }
                if (!fathername_txtbox.Text.Equals(""))
                {
                    label29.Visible = false;
                }
                if (!fatherage_txtbox.Text.Equals(""))
                {
                    label30.Visible = false;
                }
                if (!fthrnationality_txtbox.Text.Equals(""))
                {
                    label31.Visible = false;
                }
                if (!fthreducatt_cmbbox.Text.Equals(""))
                {
                    label32.Visible = false;
                }
                if (!fthroccupation_txtbox.Text.Equals(""))
                {
                    label33.Visible = false;
                }
                if (!mothername_txtbox.Text.Equals(""))
                {
                    label34.Visible = false;
                }
                if (!motherage_txtbox.Text.Equals(""))
                {
                    label35.Visible = false;
                }
                if (!mthrnationality_txtbox.Text.Equals(""))
                {
                    label36.Visible = false;
                }
                if (!mthreducatt_cmbbox.Text.Equals(""))
                {
                    label37.Visible = false;
                }
                if (!mthroccupation_txtbox.Text.Equals(""))
                {
                    label38.Visible = false;
                }
                if (!parentStatus_cmbbox.Text.Equals(""))
                {
                    label39.Visible = false;
                }
                if (!guardianname_txtbox.Text.Equals(""))
                {
                    label40.Visible = false;
                }
                if (!guardianaddress_txtbox.Text.Equals(""))
                {
                    label41.Visible = false;
                }
                if (!guardiancontact_txtbox.Text.Equals(""))
                {
                    label42.Visible = false;
                }
                if (!spouseName_txtbox.Text.Equals(""))
                {
                    label43.Visible = false;
                }
                if (!spouseage_txtbox.Text.Equals(""))
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
                        MySqlCommand command = new MySqlCommand();
                        command.Connection = connection;

                        command.CommandText = "insert into studFamilyBG (StudentNo, Father_Name, Father_Age, Father_Nationality, Father_EducAtt, Father_Occupation, Father_Company, Mother_Name, Mother_Age, Mother_Nationality, Mother_EducAtt, Mother_Occupation, Mother_Company, Parent_Status, Spouse_Name, Spouse_Age, Spouse_Contact, Spouse_Occupation, Guardian_Name, Guardian_Address, Guardian_Contact) values((select StudentNo from studInfo where StudentNo = '" + f2.studentno_txtbox.Text + "'), '" + fathername_txtbox.Text + "', '" + fatherage_txtbox.Text + "', '" + fthrnationality_txtbox.Text + "', '" + fthreducatt_cmbbox.Text + "', '" + fthroccupation_txtbox.Text + "', '" + fthrcompany_txtbox.Text + "', '" + mothername_txtbox.Text + "', '" + motherage_txtbox.Text + "', '" + mthrnationality_txtbox.Text + "', '" + mthreducatt_cmbbox.Text + "', '" + mthroccupation_txtbox.Text + "', '" + mthrcompany_txtbox.Text + "', '" + parentStatus_cmbbox.Text + "', '" + spouseName_txtbox.Text + "', '" + spouseage_txtbox.Text + "', '" + spouse_occupation.Text + "', '" + spouse_contactNo.Text + "', '" + guardianname_txtbox.Text + "', '" + guardianaddress_txtbox.Text + "', '" + guardiancontact_txtbox.Text + "')";
                        command.ExecuteNonQuery();

                        if (!sibling1.Text.Equals(""))
                        {
                            command.CommandText = "insert into studsibling (StudentNo, SiblingName, SiblingAge, SiblingGender, SiblingCourseOccu, SiblingSchoolCom) values ('" + sibling1.Text + "', '" + siblingAge1.Text + "', '" + siblingGender1.Text + "', '" + siblingCO1.Text + "', '" + siblingSC1.Text + "')";
                            command.ExecuteNonQuery();
                        }
                        if (!sibling2.Text.Equals(""))
                        {
                            command.CommandText = "insert into studsibling (StudentNo, SiblingName, SiblingAge, SiblingGender, SiblingCourseOccu, SiblingSchoolCom) values ('" + sibling2.Text + "', '" + siblingAge2.Text + "', '" + siblingGender2.Text + "', '" + siblingCO2.Text + "', '" + siblingSC2.Text + "')";
                            command.ExecuteNonQuery();
                        }
                        if (!sibling3.Text.Equals(""))
                        {
                            command.CommandText = "insert into studsibling (StudentNo, SiblingName, SiblingAge, SiblingGender, SiblingCourseOccu, SiblingSchoolCom) values ('" + sibling3.Text + "', '" + siblingAge3.Text + "', '" + siblingGender3.Text + "', '" + siblingCO3.Text + "', '" + siblingSC3.Text + "')";
                            command.ExecuteNonQuery();
                        }
                        if (!sibling4.Text.Equals(""))
                        {
                            command.CommandText = "insert into studsibling (StudentNo, SiblingName, SiblingAge, SiblingGender, SiblingCourseOccu, SiblingSchoolCom) values ('" + sibling4.Text + "', '" + siblingAge4.Text + "', '" + siblingGender4.Text + "', '" + siblingCO4.Text + "', '" + siblingSC4.Text + "')";
                            command.ExecuteNonQuery();
                        }
                    
                    }
                    catch (Exception q)
                    {
                        MessageBox.Show(q.Message);
                    }
                    finally
                    {
                        connection.Close();

                        this.Close();
                        Form4 f4 = new Form4(f2);
                        f4.Show();
                    }
                }
            }
        }

        private void spouseage_txtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void workingYes_CheckedChanged(object sender, EventArgs e)
        {
            spouse_occupation.Enabled = true;
        }

        private void workingNo_CheckedChanged(object sender, EventArgs e)
        {
            spouse_occupation.Enabled = false;
        }

        private void fathername_txtbox_TextChanged(object sender, EventArgs e)
        {
            label29.Visible = false;
        }

        private void fatherage_txtbox_TextChanged(object sender, EventArgs e)
        {
            label30.Visible = false;
        }

        private void fthrnationality_txtbox_TextChanged(object sender, EventArgs e)
        {
            label31.Visible = false;
        }

        private void fthreducatt_cmbbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            label32.Visible = false;
        }

        private void fthroccupation_txtbox_TextChanged(object sender, EventArgs e)
        {
            label33.Visible = false;
        }

        private void mothername_txtbox_TextChanged(object sender, EventArgs e)
        {
            label34.Visible = false;
        }

        private void motherage_txtbox_TextChanged(object sender, EventArgs e)
        {
            label35.Visible = false;
        }

        private void mthrnationality_txtbox_TextChanged(object sender, EventArgs e)
        {
            label36.Visible = false;
        }

        private void mthreducatt_cmbbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            label37.Visible = false;
        }

        private void mthroccupation_txtbox_TextChanged(object sender, EventArgs e)
        {
            label38.Visible = false;
        }

        private void guardianname_txtbox_TextChanged(object sender, EventArgs e)
        {
            label40.Visible = false;
        }

        private void guardianaddress_txtbox_TextChanged(object sender, EventArgs e)
        {
            label41.Visible = false;
        }

        private void guardiancontact_txtbox_TextChanged(object sender, EventArgs e)
        {
            label42.Visible = false;
        }

    }
}
