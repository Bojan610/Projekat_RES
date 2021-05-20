using Common;
using Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Server.ViewModel
{
    public class MainViewModel : BindableBase
    {
        private Filter filter = new Filter();
        public MyICommand ButtonImport { get; set; }
        public MyICommand ButtonFilter { get; set; }
        public MyICommand ButtonExit { get; set; }
        private IOperacije operacije;

        public MainViewModel()
        {
            ButtonFilter = new MyICommand(OnFilter);
            ButtonImport = new MyICommand(OnImport);
            ButtonExit = new MyICommand(OnExit);
            Filter.PocetniDatumFilter = DateTime.Now;
            Filter.KrajnjiDatumFilter = DateTime.Now;
        }

        private void OnImport()
        {
            //ImportWindow importWindow = new ImportWindow();
            //importWindow.ShowDialog();
        }

        public Filter Filter
        {
            get { return filter; }
            set
            {
                filter = value;
                OnPropertyChanged("Filter");
            }
        }

        private void OnExit()
        {
            MessageBox.Show("Da li zelite da napustite program?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
            
        }

        private void OnFilter()
        {
            Filter.Validate();
            if (Filter.IsValid)
            {
                operacije.Filter();
            }
            else
            {
                MessageBox.Show("Polja nisu dobro popunjena!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
