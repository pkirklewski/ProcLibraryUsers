using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Users
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = textBox1.Text.ToLower() + "." + textBox2.Text.ToLower() + "@engie.com";
            textBox4.Text = @"BUSINESS\" + textBox1.Text + "." + textBox2.Text;
            textBox5.Text = textBox1.Text + "." + textBox2.Text;
            textBox6.Text = DateTime.Today.ToString().Substring(0, 10);
            textBox7.Text = "5";
            textBox8.Text = "07890544300";
            textBox9.Text = textBox1.Text.ToUpper() + "." + textBox2.Text.ToUpper();
            textBox11.Text = textBox2.Text.ToUpper() + textBox1.Text.ToUpper().Substring(0, 1) + "001";
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            MobileFormsEntities mfu = new MobileFormsEntities();

            var userExsists = from u in mfu.Users where u.FirstName == textBox1.Text || u.LastName == textBox2.Text select u;

            User usr = new User();

            usr.FirstName = textBox1.Text;
            usr.LastName = textBox2.Text;
            usr.EmailAddress = textBox3.Text;
            usr.Username = textBox4.Text;
            usr.BSLUsername = textBox5.Text;
            usr.BSLActivationDate = Convert.ToDateTime(textBox6.Text);
            usr.RegionID = Convert.ToInt32(textBox7.Text);

            string displayText = "User " + textBox1.Text + " " + textBox3.Text + " saved.";
            int emptyText;
            emptyText = 0;

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "" || textBox10.Text == "" || textBox11.Text == "")
            {
                emptyText = 1;
            }

        if (emptyText != 1) {

            try
            {
                 mfu.Users.Add(usr);

                  if (mfu.SaveChanges() > 0)
                  {
                      MessageBox.Show(displayText, "USER SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                MessageBox.Show(ex.InnerException.ToString(), "ERROR !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


            if (emptyText == 1)
            {
                MessageBox.Show("TextBoxes should not be empty","Empty TextBoxes detected !",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }



        }
    }
}
