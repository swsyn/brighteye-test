using BrighteyeTest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace BrighteyeTest
{
    /// <summary>
    /// Logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ApplicationContext db;
        private int setSize;
        public MainWindow()
        {
            InitializeComponent();
            
            db = new ApplicationContext();
            setSize = 10; // Size of each table
            
            db.FirstNumbersTable.RemoveRange(db.FirstNumbersTable);
            db.SecondNumbersTable.RemoveRange(db.SecondNumbersTable);
            db.SaveChanges();
            
            // Binding
            firstNumberList.ItemsSource = db.FirstNumbersTable.Local.ToBindingList();
            secondNumberList.ItemsSource = db.SecondNumbersTable.Local.ToBindingList();
            
            // Handlers
            this.Closing += MainWindow_Closing;
            PopulateFirstTableBtn.Click += PopulateFirstTableBtn_Click;
            PopulateSecondTableBtn.Click += PopulateSecondTableBtn_Click;
        }
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void PopulateFirstTableBtn_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            int[] rawSet = new int[setSize];
            int bufForSwap;

            db.FirstNumbersTable.RemoveRange(db.FirstNumbersTable);

            // Initializing array
            for (int i = 0; i < setSize; i++)
            {
                rawSet[i] = i + 1;
            }
            
            // Shaking the array up
            for (int i = setSize - 1; i >= 0; i--)
            {
                int j = rnd.Next(0, i);
                bufForSwap = rawSet[i];
                rawSet[i] = rawSet[j];
                rawSet[j] = bufForSwap;
            }

            for (int i = 0; i < setSize; i++)
            {
                db.FirstNumbersTable.Add(new FirstNumber { Value = rawSet[i] });
            }
            db.SaveChanges();
        }

        private void PopulateSecondTableBtn_Click(object sender, RoutedEventArgs e)
        {
            db.SecondNumbersTable.RemoveRange(db.SecondNumbersTable);
            var sortedSet = db.FirstNumbersTable.OrderBy(n => n.Value);
            foreach (FirstNumber number in sortedSet)
            {
                db.SecondNumbersTable.Add(new SecondNumber { Value = number.Value });
            }
            db.SaveChanges();
        }
    }
}
