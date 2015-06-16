using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RatingClient
{
    /// <summary>
    /// Interaktionslogik für RatingWindow.xaml
    /// </summary>
    public partial class RatingWindow : Window
    {
        public RatingWindow(String ratingImg)
        {
            InitializeComponent();
            //var bitmap = Properties.Resources.ResourceManager.GetObject("rating_" + ratingImg, Properties.Resources.Culture);
            img.Source = new BitmapImage(new Uri("pack://siteoforigin:,,,/Resources/rating_"+ratingImg+".png"));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ThreadPool.QueueUserWorkItem(Waiting);
        }

        private void Waiting(object state)
        {
            var start = DateTime.Now;
            while ((DateTime.Now - start).TotalSeconds < 5)
            {
                Thread.Sleep(100);
            }
            Dispatcher.Invoke(() => this.Close());
        }
    }
}
