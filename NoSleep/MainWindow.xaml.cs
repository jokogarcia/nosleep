using System;
using System.Collections.Generic;
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

namespace NoSleep
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _status;
        private bool Status { get => _status;
            set
            {
                _status = value;
                if (_status)
                {
                    textStatus.Text = "Sleep is disabled";
                    textStatus.Foreground = Brushes.Red;
                    NoSleepCore.PreventSleep();
                }
                else
                {
                    textStatus.Text = "Sleep is enabled";
                    textStatus.Foreground = Brushes.Green;
                    NoSleepCore.UndoPreventSleep();
                }
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            Status = false;
        }
        public void HandleCheck(object sender, RoutedEventArgs e)
        {
            Status = true;
        }
        public void HandleUncheck(object sender, RoutedEventArgs e)
        {
            Status = false;
        }
    }
}
