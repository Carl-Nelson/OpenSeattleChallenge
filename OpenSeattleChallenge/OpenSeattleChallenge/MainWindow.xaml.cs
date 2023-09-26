using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OpenSeattleChallenge
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DonationsContext _context = new DonationsContext();

        private CollectionViewSource donorViewSource;


        public MainWindow()
        {
            InitializeComponent();

            donorViewSource =
                (CollectionViewSource)FindResource(nameof(donorViewSource));

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // this is just to make it easier
            // to get up and running.
            // wouldn't use in a production app

            _context.Database.EnsureCreated();

            // load the entities into EF Core
            // this is the synchronous version, only for local db
            // easy enough to change to async for prod code
            _context.Donors.Load();

            // bind to the source
            donorViewSource.Source = _context.Donors.Local.ToObservableCollection();
            // now changes are automatically tracked
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // saves any changes made in the app to the db
            // this is another sync method to switch out when using remote server
            _context.SaveChanges();

            // forces the grid to refresh to latest values
            donorDataGrid.Items.Refresh();
            donationsDataGrid.Items.Refresh();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            // clean up database connections
            _context.Dispose();
            base.OnClosing(e);
        }
    }
}
