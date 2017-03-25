using labMpp.Domain;
using labMpp.Repository;
using labMpp.Service;
using Project.Repository;
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

namespace labMpp
{
    public partial class Login : Form
    {
        private LoginService serv;

        public Login()
        {
            InitializeComponent();
            InitializeDB();
        }

        private void InitializeDB()
        {
            serv = new LoginService(new PersonalDBRepository());
        }

        public string CalculateMD5Hash(string input)

        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            Console.WriteLine("parola = " + sb.ToString());
            return sb.ToString();

        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            Personal pers = serv.Login(userText.Text, CalculateMD5Hash(passText.Text));
            if (pers == null)
            {
                MessageBox.Show("Username sau parola incorecte");
            }
            else
            {
                MessageBox.Show("Totul e ok");


            }
        }
    }
}
