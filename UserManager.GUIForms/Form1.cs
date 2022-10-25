using System;
using UserManager.BL;
using UserManager.Models;

namespace UserManager.GUIForms {
    public partial class Form1 : Form {
    private UserAdministration userAdministration = new();
    
        public Form1() {
            InitializeComponent();
            dataGridView1.DataSource = userAdministration.Users;
        }

        private void button1_Click(object sender, EventArgs e) {
            userAdministration.Users.Add(new User() {
                UserName = textBox1.Text,
                FirstName = textBox2.Text,
                LastName = textBox3.Text,
                Email = textBox4.Text,
                // Birthdate = dateTimePicker1.Value
            });
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = userAdministration.Users;
            dataGridView1.Refresh();
        }
    }
}