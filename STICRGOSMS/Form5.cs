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
    public partial class Form5 : Form
    {

        private MySqlConnection connection = new MySqlConnection();
        Form2 f2;

        public Form5(Form2 fr2)
        {
            InitializeComponent();
            connection.ConnectionString = "server=localhost;uid=root;" + "pwd=rowellmandac;database=students;";
            f2 = fr2;
        }

        private void finishButt_form5_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Continue?", "Continue", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;

                    if (hospitalizedYes.Checked)
                    {
                        cmd.CommandText = "insert into studhealth (StudentNo, Hospitalized) values ((select StudentNo from studinfo where StudentNo = '" + f2.studentno_txtbox.Text + "'), 'Yes')";
                    }
                    else
                    {
                        cmd.CommandText = "insert into studhealth (StudentNo, Hospitalized) values ((select StudentNo from studinfo where StudentNo = '" + f2.studentno_txtbox.Text + "'), 'No')";
                    }
                    cmd.ExecuteNonQuery();

                    if (operationYes.Checked)
                    {
                        cmd.CommandText = "update studHealth set Operation = 'Yes' where StudentNo = '" + f2.studentno_txtbox.Text + "'";
                    }
                    else
                    {
                        cmd.CommandText = "update studHealth set Operation = 'No' where StudentNo = '" + f2.studentno_txtbox.Text + "'";
                    }
                    cmd.ExecuteNonQuery();

                    if (illnessYes.Checked)
                    {
                        cmd.CommandText = "update studHealth set Illness = 'Yes' where StudentNo = '" + f2.studentno_txtbox.Text + "'";
                    }
                    else
                    {
                        cmd.CommandText = "update studHealth set Illness = 'No' where StudentNo = '" + f2.studentno_txtbox.Text + "'";
                    }
                    cmd.ExecuteNonQuery();

                    if (prescriptionYes.Checked)
                    {
                        cmd.CommandText = "update studHealth set PrescriptionDrugs = 'Yes' where StudentNo = '" + f2.studentno_txtbox.Text + "'";
                    }
                    else
                    {
                        cmd.CommandText = "update studHealth set PrescriptionDrugs = 'No' where StudentNo = '" + f2.studentno_txtbox.Text + "'";
                    }
                    cmd.ExecuteNonQuery();

                    if (!string.IsNullOrEmpty(familyIllness_txtbox.Text))
                    {
                        cmd.CommandText = "update studHealth set FamilyIllness = '" +  familyIllness_txtbox.Text + "' where StudentNo = '" + f2.studentno_txtbox.Text + "'";
                    }
                    cmd.ExecuteNonQuery();

                    if (!string.IsNullOrEmpty(lastvisit_txtbox.Text))
                    {
                        cmd.CommandText = "update studHealth set LastCheckup = '" + lastvisit_txtbox.Text + "' where StudentNo = '" + f2.studentno_txtbox.Text + "'";
                    }
                    cmd.ExecuteNonQuery();

                    if (!string.IsNullOrEmpty(reason_txtbox.Text))
                    {
                        cmd.CommandText = "update studHealth set Reason = '" + reason_txtbox.Text + "' where StudentNo = '" + f2.studentno_txtbox.Text + "'";
                    }
                    cmd.ExecuteNonQuery();

                    StringBuilder sb = new StringBuilder();

                    if (death_chckbox.Checked || separation_chckbox.Checked || brknenggmnt_chckbox.Checked)
                    {
                        sb.Append("Death: ");

                        if (fatherdeath_chb.Checked)
                            sb.Append("Father, ");
                        if (motherdeath_chb.Checked)
                            sb.Append("Mother, ");
                        if (brotherdeath_chb.Checked)
                            sb.Append("Brother, ");
                        if (sisterdeath_chb.Checked)
                            sb.Append("Sister, ");
                        if (gfatherdeath_chb.Checked)
                            sb.Append("Grandfather, ");
                        if (gmotherdeath_chb.Checked)
                            sb.Append("Grandmother, ");
                        if (spousedeath_chb.Checked)
                            sb.Append("Spouse, ");
                        if (childdeath_chb.Checked)
                            sb.Append("Child, ");
                        if (frienddeath_chb.Checked)
                            sb.Append("Close Friend, ");
                        if (separation_chckbox.Checked)
                            sb.Append("Separation, ");
                        if (brknenggmnt_chckbox.Checked)
                            sb.Append("Broken Engagement, ");
                        if (otherlosses_chb.Checked)
                            sb.Append(otherlosses_txtbox.Text + ", ");

                        if (sb.Length > 0)
                        {
                            sb.Length--;
                            sb.Length--;
                        }

                        cmd.CommandText = "insert into studlifecircum (StudentNo, Losses) values ('" + f2.studentno_txtbox.Text + "', '" + sb.ToString() + "')";
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        cmd.CommandText = "update studlifecircum set Losses = '" + sb.ToString() + "' where StudentNo = '" + f2.studentno_txtbox.Text + "'";
                        cmd.ExecuteNonQuery();
                    }

                    sb.Clear();

                    if (fear_chb.Checked || stress_chb.Checked || acadperfrom_chb.Checked || loneliness_chb.Checked || relationship_chb.Checked || communication_chb.Checked || anger_chb.Checked || career_chb.Checked || shyness_chb.Checked || selfconfi_chb.Checked || financial_chb.Checked || father_chb.Checked || mother_chb.Checked || sibling_chb.Checked || teacher_chb.Checked || otherproblems_chb.Checked)
                    {
                        if (fear_chb.Checked)
                            sb.Append("Fear, ");
                        if (stress_chb.Checked)
                            sb.Append("Stress, ");
                        if (acadperfrom_chb.Checked)
                            sb.Append("Academic Performance, ");
                        if (loneliness_chb.Checked)
                            sb.Append("Loneliness, ");
                        if (relationship_chb.Checked)
                            sb.Append("Relationship/s, ");
                        if (communication_chb.Checked)
                            sb.Append("Communication, ");
                        if (anger_chb.Checked)
                            sb.Append("Anger, ");
                        if (career_chb.Checked)
                            sb.Append("Career, ");
                        if (shyness_chb.Checked)
                            sb.Append("Shyness, ");
                        if (selfconfi_chb.Checked)
                            sb.Append("Self - confidence, ");
                        if (financial_chb.Checked)
                            sb.Append("Financial, ");
                        if (father_chb.Checked)
                            sb.Append("Father, ");
                        if (mother_chb.Checked)
                            sb.Append("Mother, ");
                        if (sibling_chb.Checked)
                            sb.Append("Siblings, ");
                        if (teacher_chb.Checked)
                            sb.Append("Teacher, ");
                        if (otherproblems_chb.Checked)
                            sb.Append(otherproblems_txtbox.Text + ", ");

                        if (sb.Length > 0)
                        {
                            sb.Length--;
                            sb.Length--;
                        }

                        cmd.CommandText = "update studlifecircum set Problems = '" + sb.ToString() + "' where StudentNo = '" + f2.studentno_txtbox.Text + "'";
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        cmd.CommandText = "insert into studlifecircum (StudentNo, Problems)  values('" + f2.studentno_txtbox.Text + "', '" + sb.ToString() + "')";
                        cmd.ExecuteNonQuery();
                    }

                    cmd.CommandText = "insert into studclearance values('" + f2.studentno_txtbox.Text + "', 'Not Cleared')";
                    cmd.ExecuteNonQuery();
                }
                catch (Exception q)
                {
                    MessageBox.Show(q.Message.ToString());
                }
                finally
                {
                    MessageBox.Show("Thank you! Please proceed to the Guidance Office for interview.", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    f2.Close();
                    this.Close();
                }                
            }
        }

        private void death_chckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (death_chckbox.Checked)
            {
                fatherdeath_chb.Enabled = true;
                motherdeath_chb.Enabled = true;
                brotherdeath_chb.Enabled = true;
                sisterdeath_chb.Enabled = true;
                gfatherdeath_chb.Enabled = true;
                gmotherdeath_chb.Enabled = true;
                spousedeath_chb.Enabled = true;
                childdeath_chb.Enabled = true;
                frienddeath_chb.Enabled = true;
            }
            else
            {
                fatherdeath_chb.Enabled = false;
                motherdeath_chb.Enabled = false;
                brotherdeath_chb.Enabled = false;
                sisterdeath_chb.Enabled = false;
                gfatherdeath_chb.Enabled = false;
                gmotherdeath_chb.Enabled = false;
                spousedeath_chb.Enabled = false;
                childdeath_chb.Enabled = false;
                frienddeath_chb.Enabled = false;
            }
        }

        private void otherlosses_chb_CheckedChanged(object sender, EventArgs e)
        {
            if (otherlosses_chb.Checked)
                otherlosses_txtbox.Enabled = true;
            else
                otherlosses_txtbox.Enabled = false;
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            f2.Close();
        }

        private void otherproblems_chb_CheckedChanged(object sender, EventArgs e)
        {
            if (otherproblems_chb.Checked)
                otherproblems_txtbox.Enabled = true;
            else
                otherproblems_txtbox.Enabled = false;
        }

    }
}
