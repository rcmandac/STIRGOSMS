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
    public partial class Form4 : Form
    {

        private MySqlConnection connection = new MySqlConnection();
        Form2 f2;

        public Form4(Form2 fr2)
        {
            InitializeComponent();
            connection.ConnectionString = "server=localhost;uid=root;" + "pwd=rowellmandac;database=students;";
            f2 = fr2;
        }

        private void nextButt_form4_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Continue?", "Continue", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;

                    cmd.CommandText = "insert into studeducbackground (StudentNo, GradeSchool, GS_YearAttended, HighSchool, HS_YearAttended, College, Coll_YearAttended, Vocational, Voc_YearAttended, OtherSchool, Other_YearAttended) values ((select StudentNo from studInfo where StudentNo = '" + f2.studentno_txtbox.Text + "'), '" + gradeschool_txtbox.Text + "', ('" + grdschlyear1_txtbox.Text + " - " + grdschlyear2_txtbox.Text + "'), '" + highschool_txtbox.Text + "', ('" + hghschlyear1_txtbox.Text + " - " + hghschlyear2_txtbox.Text + "'), '" + college_txtbox.Text + "', ('" + cllgyear1_txtbox.Text + " - " + cllgyear2_txtbox.Text + "'), '" + vocational_txtbox.Text + "', ('" + vctnlyear1_txtbox.Text + " - " + vctnlyear2_txtbox.Text + "'), '" + otherschool_txtbox.Text + "', '" + othrsyear1_txtbox.Text + " - " + othrsyear2_txtbox.Text + "')";
                    cmd.ExecuteNonQuery();

                    if (!string.IsNullOrEmpty(company1_txtbox.Text) && !string.IsNullOrEmpty(company2_txtbox.Text) && !string.IsNullOrEmpty(company3_txtbox.Text) && !string.IsNullOrEmpty(company4_txtbox.Text))
                    {
                        cmd.CommandText = "insert into studworkexperience values((select StudentNo from studinfo where StudentNo = '" + f2.studentno_txtbox.Text + "'), '" + company1_txtbox.Text + "', '" + position1_txtbox.Text + "', '" + duration1_txtbox.Text + "', '" + description1_txtbox.Text + "')";
                        cmd.CommandText = "insert into studworkexperience values((select StudentNo from studinfo where StudentNo = '" + f2.studentno_txtbox.Text + "'), '" + company2_txtbox.Text + "', '" + position2_txtbox.Text + "', '" + duration2_txtbox.Text + "', '" + description2_txtbox.Text + "')";
                        cmd.CommandText = "insert into studworkexperience values((select StudentNo from studinfo where StudentNo = '" + f2.studentno_txtbox.Text + "'), '" + company3_txtbox.Text + "', '" + position3_txtbox.Text + "', '" + duration3_txtbox.Text + "', '" + description3_txtbox.Text + "')";
                        cmd.CommandText = "insert into studworkexperience values((select StudentNo from studinfo where StudentNo = '" + f2.studentno_txtbox.Text + "'), '" + company4_txtbox.Text + "', '" + position4_txtbox.Text + "', '" + duration4_txtbox.Text + "', '" + description4_txtbox.Text + "')";
                        cmd.ExecuteNonQuery();
                    }
                    if (!string.IsNullOrEmpty(company1_txtbox.Text) && !string.IsNullOrEmpty(company2_txtbox.Text) && !string.IsNullOrEmpty(company3_txtbox.Text))
                    {
                        cmd.CommandText = "insert into studworkexperience values((select StudentNo from studinfo where StudentNo = '" + f2.studentno_txtbox.Text + "'), '" + company1_txtbox.Text + "', '" + position1_txtbox.Text + "', '" + duration1_txtbox.Text + "', '" + description1_txtbox.Text + "')";
                        cmd.CommandText = "insert into studworkexperience values((select StudentNo from studinfo where StudentNo = '" + f2.studentno_txtbox.Text + "'), '" + company2_txtbox.Text + "', '" + position2_txtbox.Text + "', '" + duration2_txtbox.Text + "', '" + description2_txtbox.Text + "')";
                        cmd.CommandText = "insert into studworkexperience values((select StudentNo from studinfo where StudentNo = '" + f2.studentno_txtbox.Text + "'), '" + company3_txtbox.Text + "', '" + position3_txtbox.Text + "', '" + duration3_txtbox.Text + "', '" + description3_txtbox.Text + "')";
                        cmd.ExecuteNonQuery();
                    }
                    if (!string.IsNullOrEmpty(company1_txtbox.Text) && !string.IsNullOrEmpty(company2_txtbox.Text))
                    {
                        cmd.CommandText = "insert into studworkexperience values((select StudentNo from studinfo where StudentNo = '" + f2.studentno_txtbox.Text + "'), '" + company1_txtbox.Text + "', '" + position1_txtbox.Text + "', '" + duration1_txtbox.Text + "', '" + description1_txtbox.Text + "')";
                        cmd.CommandText = "insert into studworkexperience values((select StudentNo from studinfo where StudentNo = '" + f2.studentno_txtbox.Text + "'), '" + company2_txtbox.Text + "', '" + position2_txtbox.Text + "', '" + duration2_txtbox.Text + "', '" + description2_txtbox.Text + "')";
                        cmd.ExecuteNonQuery();
                    }
                    if (!string.IsNullOrEmpty(company1_txtbox.Text))
                    {
                        cmd.CommandText = "insert into studworkexperience values((select StudentNo from studinfo where StudentNo = '" + f2.studentno_txtbox.Text + "'), '" + company1_txtbox.Text + "', '" + position1_txtbox.Text + "', '" + duration1_txtbox.Text + "', '" + description1_txtbox.Text + "')";
                        cmd.ExecuteNonQuery();
                    }


                    if (!string.IsNullOrEmpty(sports1_txtbox.Text) || !string.IsNullOrEmpty(sports2_txtbox.Text) || !string.IsNullOrEmpty(sports3_txtbox.Text) || !string.IsNullOrEmpty(othersports_txtbox.Text))
                    {
                        if (!string.IsNullOrEmpty(sports1_txtbox.Text) && !string.IsNullOrEmpty(sports2_txtbox.Text) && !string.IsNullOrEmpty(sports3_txtbox.Text) && !string.IsNullOrEmpty(othersports_txtbox.Text))
                        {
                            cmd.CommandText = "insert into studIRA (StudentNo, Sports) values ((select StudentNo from studInfo where StudentNo = '" + f2.studentno_txtbox.Text + "'), '" + sports1_txtbox.Text + ", " + sports2_txtbox.Text + ", " + sports3_txtbox.Text + ", " + othersports_txtbox.Text + "')";
                        }
                        else if (!string.IsNullOrEmpty(sports1_txtbox.Text) && !string.IsNullOrEmpty(sports2_txtbox.Text) && !string.IsNullOrEmpty(sports3_txtbox.Text))
                        {
                            cmd.CommandText = "insert into studIRA (StudentNo, Sports) values ((select StudentNo from studInfo where StudentNo = '" + f2.studentno_txtbox.Text + "'), '" + sports1_txtbox.Text + ", " + sports2_txtbox.Text + ", " + sports3_txtbox.Text + "')";
                        }
                        else if (!string.IsNullOrEmpty(sports1_txtbox.Text) && !string.IsNullOrEmpty(sports2_txtbox.Text))
                        {
                            cmd.CommandText = "insert into studIRA (StudentNo, Sports) values ((select StudentNo from studInfo where StudentNo = '" + f2.studentno_txtbox.Text + "'), '" + sports1_txtbox.Text + ", " + sports2_txtbox.Text + "')";
                        }
                        else
                        {
                            cmd.CommandText = "insert into studIRA (StudentNo, Sports) values ((select StudentNo from studInfo where StudentNo = '" + f2.studentno_txtbox.Text + "'), '" + sports1_txtbox.Text + "')";
                        }
                    }
                    cmd.ExecuteNonQuery();

                    if (!string.IsNullOrEmpty(hobbies1_txtbox.Text) || !string.IsNullOrEmpty(hobbies2_txtbox.Text) || !string.IsNullOrEmpty(hobbies3_txtbox.Text) || !string.IsNullOrEmpty(otherhobbies_txtbox.Text))
                    {
                        if (!string.IsNullOrEmpty(hobbies1_txtbox.Text) && !string.IsNullOrEmpty(hobbies2_txtbox.Text) && !string.IsNullOrEmpty(hobbies3_txtbox.Text) && !string.IsNullOrEmpty(otherhobbies_txtbox.Text))
                        {
                            cmd.CommandText = "update studIRA set Hobbies = ('" + hobbies1_txtbox.Text + ", " + hobbies2_txtbox.Text + ", " + hobbies3_txtbox.Text + ", " + otherhobbies_txtbox.Text + "') where StudentNo = '" + f2.studentno_txtbox.Text + "'";
                        }
                        else if (!string.IsNullOrEmpty(hobbies1_txtbox.Text) && !string.IsNullOrEmpty(hobbies2_txtbox.Text) && !string.IsNullOrEmpty(hobbies3_txtbox.Text))
                        {
                            cmd.CommandText = "update studIRA set Hobbies = ('" + hobbies1_txtbox.Text + ", " + hobbies2_txtbox.Text + ", " + hobbies3_txtbox.Text + "') where StudentNo = '" + f2.studentno_txtbox.Text + "'";
                        }
                        else if (!string.IsNullOrEmpty(hobbies1_txtbox.Text) && !string.IsNullOrEmpty(hobbies2_txtbox.Text))
                        {
                            cmd.CommandText = "update studIRA set Hobbies = ('" + hobbies1_txtbox.Text + ", " + hobbies2_txtbox.Text + "') where StudentNo = '" + f2.studentno_txtbox.Text + "'";
                        }
                        else
                        {
                            cmd.CommandText = "update studIRA set Hobbies = ('" + hobbies1_txtbox.Text + "') where StudentNo = '" + f2.studentno_txtbox.Text + "'";
                        }
                    }
                    cmd.ExecuteNonQuery();

                    if (!string.IsNullOrEmpty(talent1_txtbox.Text) || !string.IsNullOrEmpty(talent2_txtbox.Text) || !string.IsNullOrEmpty(talent3_txtbox.Text) || !string.IsNullOrEmpty(othertalent_txtbox.Text))
                    {
                        if (!string.IsNullOrEmpty(talent1_txtbox.Text) && !string.IsNullOrEmpty(talent2_txtbox.Text) && !string.IsNullOrEmpty(talent3_txtbox.Text) && !string.IsNullOrEmpty(othertalent_txtbox.Text))
                        {
                            cmd.CommandText = "update studIRA set Talents = ('" + talent1_txtbox.Text + ", " + talent2_txtbox.Text + ", " + talent3_txtbox.Text + ", " + othertalent_txtbox.Text + "') where StudentNo = '" + f2.studentno_txtbox.Text + "'";
                        }
                        else if (!string.IsNullOrEmpty(talent1_txtbox.Text) && !string.IsNullOrEmpty(talent2_txtbox.Text) && !string.IsNullOrEmpty(talent3_txtbox.Text))
                        {
                            cmd.CommandText = "update studIRA set Talents = ('" + talent1_txtbox.Text + ", " + talent2_txtbox.Text + ", " + talent3_txtbox.Text + "') where StudentNo = '" + f2.studentno_txtbox.Text + "'";
                        }
                        else if (!string.IsNullOrEmpty(talent1_txtbox.Text) && !string.IsNullOrEmpty(talent2_txtbox.Text))
                        {
                            cmd.CommandText = "update studIRA set Talents = ('" + talent1_txtbox.Text + ", " + talent2_txtbox.Text + "') where StudentNo = '" + f2.studentno_txtbox.Text + "'";
                        }
                        else
                        {
                            cmd.CommandText = "update studIRA set Hobbies = ('" + talent1_txtbox.Text + "') where StudentNo = '" + f2.studentno_txtbox.Text + "'";
                        }
                    }
                    cmd.ExecuteNonQuery();

                    if (!string.IsNullOrEmpty(church_txtbox.Text))
                    {
                        cmd.CommandText = "update studIRA set Church = '" + church_txtbox.Text + "' where StudentNo = '" + f2.studentno_txtbox.Text + "'";
                        cmd.ExecuteNonQuery();
                    }

                    if (!string.IsNullOrEmpty(schoolorg_txtbox.Text))
                    {
                        cmd.CommandText = "update studIRA set SchoolOrganization = '" + schoolorg_txtbox.Text + "' where StudentNo = '" + f2.studentno_txtbox.Text + "'";
                        cmd.ExecuteNonQuery();
                    }

                    if (!string.IsNullOrEmpty(sociocivic_txtbox.Text))
                    {
                        cmd.CommandText = "update studIRA set SocioCivicGrps = '" + sociocivic_txtbox.Text + "' where StudentNo = '" + f2.studentno_txtbox.Text + "'";
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception q)
                {
                    MessageBox.Show(q.ToString());
                }
                finally
                {
                    connection.Close();

                    Form5 f5 = new Form5(f2);
                    this.Close();
                    f5.Show();
                }
            }
        }

        private void grdschlyear1_txtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
