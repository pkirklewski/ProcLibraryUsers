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
            button1.Enabled = false;
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
            int userExistsCount;
            var userExsists = from u in mfu.Users where u.FirstName == textBox1.Text || u.LastName == textBox2.Text select u;
            userExistsCount = userExsists.Count();



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



            if (userExistsCount < 1)
            {



                if (emptyText != 1) {

                    try
                    {
                         mfu.Users.Add(usr);

                          if (mfu.SaveChanges() > 0)
                          {

                            userExsists = from u in mfu.Users where u.FirstName == textBox1.Text || u.LastName == textBox2.Text select u;
                            userExistsCount = userExsists.Count();
                            List<User> myUser001 = userExsists.ToList();

                            var mUser = from x in mfu.Users where x.FirstName == textBox1.Text || x.LastName == textBox1.Text select x.UserId;
                            
                            //int y = myUserID.First();//Convert.ToInt32(myUserID.ToString());

                            FacilitiesManagerEntities fme = new FacilitiesManagerEntities();
                            int myUserID = mUser.First();//Convert.ToInt32(myUserID.ToString());

                            FacilitiesManager fm = new FacilitiesManager();
                            fm.FacitlitiesManagerId = myUserID;
                            fm.OtherSystemRef = textBox10.Text;
                            fm.Telephone = textBox8.Text;
                            fm.FMCode = textBox11.Text;                   
                            fme.FacilitiesManagers.Add(fm);
                            fme.SaveChanges();

                            var myNewFM = from f in fme.FacilitiesManagers where f.FacitlitiesManagerId == myUserID select f;

                            List<User> myUserX = userExsists.ToList();
                            dataGridView1.DataSource = myUserX;

                            List < FacilitiesManager >  brandNewFM = myNewFM.ToList();
                            dataGridView2.DataSource = brandNewFM;


                              MessageBox.Show(displayText, "USER SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                          }
                    }
                    catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
                    {
                        MessageBox.Show(ex.InnerException.ToString(), "ERROR !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }



            } // testing if user exsists
            else
            {

                List < User > myUser = userExsists.ToList();
                dataGridView1.DataSource = myUser;
                MessageBox.Show("User already exsists", "ERROR !", MessageBoxButtons.OK, MessageBoxIcon.Error);

            } //if user exsists i.e the userExsistsCount is 1 or more then display a message


            if (emptyText == 1)
            {
                MessageBox.Show("TextBoxes should not be empty","Empty TextBoxes detected !",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }



        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked == true)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }

        }
    }
}
