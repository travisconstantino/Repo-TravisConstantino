using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToDoListFinal
{
    public partial class Form1 : Form
    {
        int listSize;
        int editPhase = 0;

        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (editPhase == 0)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
                if (listSize > 0)//Prevent the user from lowering the item size too low.
                {
                    listSize -= 1;
                }
            }
            else MessageBox.Show("Sorry, you cannot do this while editing an item");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                listSize += 1;
                listBox1.Items.Add("-- " + textBox1.Text);
                textBox1.Clear();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if(listBox1.SelectedIndex >= 0) //As long as something is selected.
            {

                editPhase += 1; //Lets us change editing states .
               
                if (editPhase == 1) //Edit the string.
                {
                    textBox2.Visible = true;
                    textBox1.ReadOnly = true;
                    textBox1.Clear();
                    textBox2.Text = listBox1.SelectedItem.ToString();  //Put out selection into the editing box.
                    button3.Text = "Done Editing";
                }

                if (editPhase == 2) //Put the item back in the list
                {
                    if (textBox2.Text.Contains("--")) //Adding a check to help make sure that my formatting looks pretty. 
                    {
                        listBox1.Items.Insert(listBox1.SelectedIndex, textBox2.Text);
                        listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                    }
                    else
                    {
                        listBox1.Items.Insert(listBox1.SelectedIndex, "-- " + textBox2.Text);
                        listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                    }

                    button3.Text = "Edit Selection";
                    textBox2.Visible = false;
                    textBox1.ReadOnly = false;
                    textBox2.Clear();
                    editPhase = 0;
                }
            }
            else MessageBox.Show("Sorry, but you do not have an item selected.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

    }
}
