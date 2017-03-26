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
        private BindingSource source;
        private BindingSource cautaSource;

        public MeniuView()
        {
            InitializeComponent();
        }

        private void Initialize()
        {
            List<Spectacol> speclist = service.getSpecacol();
            var bindingList = new BindingList<Spectacol>(speclist);
            source = new BindingSource(bindingList,null);
            spectacolTable.DataSource = source;
            spectacolTable.Columns[0].Visible = false;

            spectacolTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            spectacolTable.EditMode = DataGridViewEditMode.EditProgrammatically;
            spectacolTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            cautaTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            cautaTable.EditMode = DataGridViewEditMode.EditProgrammatically;
            cautaTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            cautaTable.DataSource = cautaSource;
            setColor();

        }

        public void setService(CommandService serv)
        {
            service = serv;
            Initialize();

        }

        private void setColor()
        {
            foreach (DataGridViewRow row in spectacolTable.Rows)
            {
                if (row.Cells[2].Value.Equals(0))
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }


        public void update(Utils.IObservable<Spectacol> observable)
        {
            var serv = (CommandService)observable;
            List<Spectacol> specList = serv.getSpecacol();
            source = new BindingSource(new BindingList<Spectacol>(specList), null);
            spectacolTable.DataSource = source;
            cautaText.Text = "";
            cautaTable.DataSource = null;
            setColor();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void cautaBtn_Click(object sender, EventArgs e)
        {
            List<Spectacol> cautaList = service.cautare(cautaText.Text);
            cautaSource = new BindingSource(new BindingList<Spectacol>(cautaList), null);
            cautaTable.DataSource = cautaSource;
        }

        private void vanzareBtn_Click(object sender, EventArgs e)
        {
            int id = (int)cautaTable.SelectedRows[0].Cells[0].Value;
            Console.Out.WriteLine("id = " + id.ToString());
            Spectacol spec = service.findSpectacol(id);
            Console.Out.WriteLine("spec id = " + spec.Id.ToString());

            service.cumparare(spec, numeText.Text, int.Parse(bileteText.Text));
        }
    }
}
