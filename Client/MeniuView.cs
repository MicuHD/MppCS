using model;
using services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class MeniuView : Form
    {
        enum Tabel{
              SpectacolTabel,
              CautareTabel 
        }

        private ClientCtrl ctrl;
        private BindingSource source;
        private BindingSource cautaSource;

        public MeniuView(ClientCtrl ctrl)
        {
            this.ctrl = ctrl;
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            List<Spectacol> speclist = ctrl.getSpectacol();
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
            setColor(Tabel.SpectacolTabel);

        }

      

        private void setColor(Tabel tab)
        {
            if(tab.Equals(Tabel.SpectacolTabel))
            {
                foreach (DataGridViewRow row in spectacolTable.Rows)
                {
                    if (row.Cells[2].Value.Equals(0))
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in cautaTable.Rows)
                {
                    if (row.Cells[2].Value.Equals(0))
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                    }
                }
            }
            
        }


        //public void update(Utils.IObservable<Spectacol> observable)
        //{
        //    var serv = (CommandService)observable;
        //    List<Spectacol> specList = serv.getSpecacol();
        //    source = new BindingSource(new BindingList<Spectacol>(specList), null);
        //    spectacolTable.DataSource = source;
        //    cautaText.Text = "";
        //    cautaTable.DataSource = null;
        //    setColor(Tabel.CautareTabel);
        //    setColor(Tabel.SpectacolTabel);
        //}

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            ctrl.logout();
            System.Environment.Exit(0);
        }

        private void MeniuView_Load(object sender, EventArgs e)
        {
            setColor(Tabel.SpectacolTabel);
        }

        private void MeniuView_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine("ChatWindow closing " + e.CloseReason);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                ctrl.logout();
                Application.Exit();
            }

        }

        private void cautaBtn_Click(object sender, EventArgs e)
        {
            string data = cautaText.Text;
            string[] items = data.Split('-');

            if (items.Count().Equals(3) && items[0].Count().Equals(2) && items[1].Count().Equals(2) && items[2].Count().Equals(4))
            {
                List<Spectacol> cautaList = ctrl.cautare(cautaText.Text);
                cautaSource = new BindingSource(new BindingList<Spectacol>(cautaList), null);
                cautaTable.DataSource = cautaSource;
                setColor(Tabel.CautareTabel);
            }
            else
            {
                MessageBox.Show("Introduceti o data valida!");
            }
        }

        private void vanzareBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = cautaTable.SelectedRows[0];

                Spectacol spec = (Spectacol)row.DataBoundItem;
                
                //Spectacol spec = service.findSpectacol(id);
                Console.Out.WriteLine("spec id = " + spec.Id.ToString());
                string nume = numeText.Text;
                char[] cifre = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };

                int tickets;
                bool ok = int.TryParse(bileteText.Text, out tickets);

                if (!cifre.Any(s => nume.Contains(s)))
                {
                    if (ok && tickets > 0)
                    {
                        if (tickets <= spec.Disponibile)
                        {
                            ctrl.cumparare(spec, numeText.Text, int.Parse(bileteText.Text));
                        }
                        else
                        {
                            MessageBox.Show("Numarul de bilete cerut nu este disponibil");

                        }
                    }
                    else
                    {
                        MessageBox.Show("Numarul de bilete trebuie sa fie un numar intreg pozitiv");
                    }
                }
                else
                {
                    MessageBox.Show("Numele nu poate contine cifre");
                }

            }
            catch (System.ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("Alegeti un spectacol din lista de cautare");
            }
            catch(SpectacolException ex)
            {
                MessageBox.Show("Numarul de bilete este indisponibil!");

            }
        }

        public void userUpdate(object sender, UserEventArgs e)
        {
            Console.Out.WriteLine("yeeep This is called");

            if (e.UserEventType == UserEvent.SoldTicket)
            {
                Spectacol spec = (Spectacol)e.Data;
                for(int i = 0; i < source.Count; i++)
                {
                    if (((Spectacol)source[i]).Id.Equals(spec.Id))
                    {
                        source[i] = spec;
                    }
                }
                Console.WriteLine("SoldTicket ");
                spectacolTable.BeginInvoke(new UpdateDataGridViewCallBack(this.updateListBox), new Object[] { spectacolTable, (IList<Spectacol>)source });
            }

        }

        //1. define a method for updating the ListBox
        private void updateListBox(DataGridView gridView, IList<Spectacol> newData)
        {
            gridView.DataSource = null;
            gridView.DataSource = newData;
            Console.Out.WriteLine("This is called");
        }

        //2. define a delegate to be called back by the GUI Thread
        public delegate void UpdateDataGridViewCallBack(DataGridView list, IList<Spectacol> data);



        //3. in the other thread call like this:
        /*
         * list.Invoke(new UpdateListBoxCallback(this.updateListBox), new Object[]{list, data});
         * 
         * */

    }
}
