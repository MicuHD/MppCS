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

namespace Client
{
    public partial class Login : Form
    {
        //private LoginService serv;
        private ClientCtrl ctrl;

        public Login(ClientCtrl ctrl)
        {
            this.ctrl = ctrl;
            InitializeComponent();
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
            //Personal pers = serv.Login(userText.Text, CalculateMD5Hash(passText.Text));
            //if (pers == null)
            //{
            //    MessageBox.Show("Username sau parola incorecte");
            //}
            //else
            //{
            //    MeniuView meniu = new MeniuView();
            //    meniu.Show();
            //    var serv = new CommandService(new SpectacolDBRepository(), new CumparatorDBRepository());
            //    serv.addObserver(meniu);
            //    meniu.setService(serv);

            //    this.Hide();

            //}

            String user = userText.Text;
            String pass = CalculateMD5Hash(passText.Text);
            try
            {
                ctrl.login(user, pass);
                //MessageBox.Show("Login succeded");
                MeniuView mvWin = new MeniuView(ctrl);
                mvWin.Text = "Chat window for " + user;
                mvWin.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Login Error " + ex.Message/*+ex.StackTrace*/, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }




        }
    }
}
