﻿using PiStoreManagement.Managements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PiStoreManagement
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ShopDBEntities shopDBEntities = ShopDB.GetShopDBEntities();
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            

            if(username.Equals(String.Empty))
            {
                MessageBox.Show("Username can't be empty!");
            }
            else if(password.Equals(String.Empty))
            {
                MessageBox.Show("Password can't be empty!");
            }
            else
            {
                string hashed = ComputeSHA256(password);
                var account = shopDBEntities.ManagerAccounts.Where(
                    a => a.Username == username 
                    && a.Password == hashed
                    ).FirstOrDefault();
                if(account != null)
                {
                    //MessageBox.Show("TODO: Login success");
                    //this.Close();
                    //new frmEmployees().Show();
                    //Application.Run(new frmEmployees());
                    this.Hide();
                    //this.Dispose();
                }
                else
                {
                    MessageBox.Show("Incorrect username or password!");
                }
            }
        }

        static string ComputeSHA256(string s)
        {
            string hash = String.Empty;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashValue = sha256.ComputeHash(Encoding.UTF8.GetBytes(s));

                // Expecting hashed in string format
                foreach (byte b in hashValue)
                {
                    hash += $"{b:X2}";
                }
            }

            return hash;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUsername.Text = String.Empty;
            txtPassword.Text = String.Empty;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
