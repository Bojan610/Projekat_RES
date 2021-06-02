using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Server.Model;
using Common;

namespace Server.ViewModel
{
    public class ImportViewModel : BindableBase
    {
        private Import import = new Import();
        public MyICommand ButtonPotrosnja { get; set; }
        public MyICommand ButtonVreme { get; set; }
        public MyICommand ButtonImport { get; set; }
        private IOperacije operacije;

        public ImportViewModel()
        {
            ButtonPotrosnja = new MyICommand(OnPotrosnja);
            ButtonVreme = new MyICommand(OnVreme);
            ButtonImport = new MyICommand(OnImport);
            Import.PocetniDatum = DateTime.Now;
            Import.KrajnjiDatum = DateTime.Now;
        }

        
        public Import Import
        {
            get { return import; }
            set
            {
                import = value;
                OnPropertyChanged("Import");
            }
        }

          
        private void OnPotrosnja()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a file";
            op.Filter = "All files (*.*)|*.*";

            if (op.ShowDialog() == true)
            {
                string fileName = op.FileName;
                string path = System.IO.Path.GetFullPath(op.FileName);
                Import.FajlPotrosnja = op.FileName;
            }
        }

        private void OnVreme()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a file";
            op.Filter = "All files (*.*)|*.*";

            if (op.ShowDialog() == true)
            {
                string fileName = op.FileName;
                string path = System.IO.Path.GetFullPath(op.FileName);
                Import.FajlVreme = op.FileName;
            }
        }

        private void OnImport()
        {
            //Import.Validate();
            OperacijeServer operacijeServer = new OperacijeServer();
            operacijeServer.Import();
            //operacije.Import();
            /*if (Import.IsValid)
            {
                operacije.Import();
            }
            else
            {
                MessageBox.Show("Polja nisu dobro popunjena!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }*/
        }
    }
}
