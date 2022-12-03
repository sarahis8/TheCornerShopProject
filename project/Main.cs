using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace project
{
    public partial class Main : Form
    {
        SQLiteConnection bookshopconnection;
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bookshopconnection = new SQLiteConnection("Data Source=shop.sqlite;Version=3");
            bookshopconnection.Open();
            load_Data();
            label15.Text = "Enter Your Phone Number\n Choose the operation \n based on it";
        }




        public class Counter
        {
            public int count;

            public void NumOfInserts()
            {
                count++;
            }
        }

        private void CreateAccountButton_Click_1(object sender, EventArgs e)
        {
          
            string sql;
            if (phoneNumberTxtBox.Text.Length != 10)
                MessageBox.Show("Invalid phone Number, must be 10 digits! ");

            else
            {
                try
                {
                    string chosen = comboBox1.SelectedItem.ToString();
                    int number = (int)numericUpDown2.Value;
                    sql = " INSERT INTO Customers (FirstName, LastName,Days,Phone_Number,ChosenBook) VALUES ('" + firstNameTxtBox.Text + "' , '" + lastNameTxtBox.Text + "','" + number + "' , '" + phoneNumberTxtBox.Text + "' , '" + chosen + "' ) ";

                    SQLiteCommand command = new SQLiteCommand(sql, bookshopconnection);

                    // To show  how many members was added 
                    command.ExecuteNonQuery();

                    load_Data();


                    Counter num = new Counter();
                    num.NumOfInserts();
                    int c = num.count;
                    MessageBox.Show(c + " member/s was added succesfully!", "Added!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch
                {
                    MessageBox.Show("Error!");
                }
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void load_Data()
        {

            try
            {
                // this function loads the data directly in the data base
                string sql = "SELECT * FROM Customers";
                SQLiteDataAdapter da = new SQLiteDataAdapter(sql, bookshopconnection);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch
            {
                MessageBox.Show("Error!");
            }

        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (comboBox2.SelectedIndex.ToString() == "0")
            {
                textBox5.Clear();
                textBox2.Text = "Jojo Moyes";
                textBox3.Text = "Contemporary";
                textBox4.Text = "2012";
                string desc;
                

                StreamReader file = new StreamReader("Me Before you.txt");
                while ((desc = file.ReadLine()) != null)
                {
                    textBox5.Text = desc;
                        

                }
            }
            if (comboBox2.SelectedIndex.ToString() == "1")
            {
                textBox5.Clear();
                textBox2.Text = "Madelline Miller";
                textBox3.Text = "Historical Fiction";
                textBox4.Text = "2011";
                string desc2;
                System.IO.StreamReader file1 = new System.IO.StreamReader("Song of Achilles.txt");
                while ((desc2 = file1.ReadLine()) != null)
                {

                    textBox5.Text = desc2;
                }

            }

            if (comboBox2.SelectedIndex.ToString() == "2")
            {
                textBox2.Text = " V.e Shwaab";
                textBox3.Text = "Fantasy";
                textBox4.Text = "2013";
                string desc3;
                System.IO.StreamReader file3 = new System.IO.StreamReader("vicous.txt");
                while ((desc3 = file3.ReadLine()) != null)
                {

                    textBox5.Text = desc3;
                }

            }
            //Vicous
            if (comboBox2.SelectedIndex.ToString() == "3")
            {
                textBox2.Text = " Madelline Miller";
                textBox3.Text = "Historical Fiction";
                textBox4.Text = "2021";
                string desc;
                System.IO.StreamReader file = new System.IO.StreamReader("circe.txt");
                while ((desc = file.ReadLine()) != null)
                {

                    textBox5.Text = desc;
                }

            }

            if (comboBox2.SelectedIndex.ToString() == "4")
            {
                textBox2.Text = " Jennifer Lynn Barnes";
                textBox3.Text = "Mystery";
                textBox4.Text = "2020";
                string desc;
                System.IO.StreamReader file = new System.IO.StreamReader("The inheritance games.txt");
                while ((desc = file.ReadLine()) != null)
                {

                    textBox5.Text = desc;
                }
            }

            if (comboBox2.SelectedIndex.ToString() == "5")
            {
                textBox2.Text = " V.e Shwaab";
                textBox3.Text = "Fantasy";
                textBox4.Text = "2018";
                string desc;
                System.IO.StreamReader file = new System.IO.StreamReader("vengeful.txt");
                while ((desc = file.ReadLine()) != null)
                {

                    textBox5.Text = desc;
                }
            }

            if (comboBox2.SelectedIndex.ToString() == "6")
            {
                textBox2.Text = " Colleen Hoover";
                textBox3.Text = "Contemporary";
                textBox4.Text = "2016";
                string desc;
                System.IO.StreamReader file = new System.IO.StreamReader("it ends with us.txt");
                while ((desc = file.ReadLine()) != null)
                {
                    textBox5.Text = desc;
                }
            }

            if (comboBox2.SelectedIndex.ToString() == "7")
            {
                textBox2.Text = "Colleen Hoover";
                textBox3.Text = "Contemporary";
                textBox4.Text = "2016";
                string desc;
                System.IO.StreamReader file = new System.IO.StreamReader("november 9th.txt");
                while ((desc = file.ReadLine()) != null)
                {

                    textBox5.Text = desc;
                }
            }

            if (comboBox2.SelectedIndex.ToString() == "8")
            {
                textBox2.Text = "Louisa May Alcott";
                textBox3.Text = "Classic";
                textBox4.Text = "1868";
                string desc;
                System.IO.StreamReader file = new System.IO.StreamReader("little women.txt");
                while ((desc = file.ReadLine()) != null)
                {

                    textBox5.Text = desc;
                }
            }
            if (comboBox2.SelectedIndex.ToString() == "9")
            {
                textBox2.Text = "Jane Austen";
                textBox3.Text = "Classic";
                textBox4.Text = "1813";
                string desc;
                System.IO.StreamReader file = new System.IO.StreamReader("pride and prejudice.txt");
                while ((desc = file.ReadLine()) != null)
                {

                    textBox5.Text = desc;
                }
            }


        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateTime = dateTimePicker2.Value;

            Date.Text = dateTime.AddDays((double)numericUpDown2.Value).ToShortDateString();

        }
        private void Update_Click_1(object sender, EventArgs e)
        {
            try
            {
                string book = comboBox3.Items[comboBox3.SelectedIndex].ToString();
                /*            MessageBox.Show(book);*/
                string phone = this.phone.Text;
                string sql = "Update Customers SET ChosenBook= '" + book + "' WHERE Phone_Number = " + phone;
                SQLiteCommand command = new SQLiteCommand(sql, bookshopconnection);
                int affectedRecords = command.ExecuteNonQuery();
                MessageBox.Show(affectedRecords + " members has been UPDATED. ", "Updated!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load_Data();
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                string phone = this.phone.Text;
                string sql = "DELETE FROM Customers WHERE " + phone + " == Phone_Number";
                SQLiteCommand command = new SQLiteCommand(sql, bookshopconnection);
                int affectedRecords = command.ExecuteNonQuery();
                MessageBox.Show(affectedRecords + " member was/were deleted succesfully BY PHONE NUMBER, !", "Deleted!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load_Data();
            }
            catch
            {
                MessageBox.Show("Error!");
            }
;
        }

        private void DurationUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }



        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void INSERT_Click(object sender, EventArgs e)
        {

        }

        private void phoneNumberTxtBox_TextChanged(object sender, EventArgs e)
        {

        }








        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBoxx_TextChanged(object sender, EventArgs e)
        {

        }
        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void accountToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }



        private void firstNameTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void lastNameTxtBox_TextChanged(object sender, EventArgs e)
        {

        }


        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)

        {

        }

        private void firstNameTxtBox_TextChanged_2(object sender, EventArgs e)
        {

        }
        private void genreToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    



        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        private void firstNameTxtBox_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void CreateAccountButton_Click(object sender, EventArgs e)
        {

        }

        private void Date_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }



        private void button1_Click_2(object sender, EventArgs e)
        {

        }



        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }

}


