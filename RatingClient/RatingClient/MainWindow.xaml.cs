using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using WebSocketSharp;

namespace RatingClient
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        WebSocket WebSocket { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WebSocket = new WebSocket("ws://localhost:8080/rating-server/rating");
            WebSocket.OnMessage += ShowRating;

            WebSocket.Connect();
        }

        private void ShowRating(object sender, MessageEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                var rand = new Random();
                var rating = new RatingWindow(e.Data.Substring("rating:".Length));
                rating.Left = rand.Next((int)SystemParameters.PrimaryScreenWidth);
                rating.Top = rand.Next((int)SystemParameters.PrimaryScreenHeight);
                rating.Show();
            });
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            WebSocket.Close();
        }

        private void ButonStopClick(object sender, RoutedEventArgs e)
        {
            WebSocket.Close();
        }

        private void ButonStartClick(object sender, RoutedEventArgs e)
        {
            WebSocket.Connect();
        }
    }
}
