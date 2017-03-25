using labMpp.Domain;
using labMpp.Service;
using labMpp.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace labMpp.GUI
{
    public partial class MeniuView : Form, Utils.IObserver<Spectacol>
    {
        private CommandService service;

        public MeniuView()
        {
            InitializeComponent();
        }

        public void setService(CommandService serv)
        {
            service = serv;
        }

        public void update(Utils.IObservable<Spectacol> observable)
        {
            throw new NotImplementedException();
        }

        private void MeniuView_Load(object sender, EventArgs e)
        {

        }
    }
}
