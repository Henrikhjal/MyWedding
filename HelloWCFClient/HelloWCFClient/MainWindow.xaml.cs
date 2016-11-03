using System.Windows;
using System.Windows.Documents;
using HelloWCFClient.ServiceReference1;
using MyWedding.Models;
using System.Collections.Generic;

namespace HelloWCFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference1.Service1Client proxClient = new Service1Client();
            // var msg = proxClient.GetData(55);
            List<Message> messages = new List<Message>();
            messages = proxClient.
            var msg = proxClient.GetData(55);
            MessageBox.Show(msg);

        }
    }
}
