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

namespace CursorTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static int backColorIndex = 0;
        

        public MainWindow()
        {
            InitializeComponent();
            AddButton();
        }

        private int GetRandomNumber(int maxim)
        {
            Random rand = new Random();
            var randomNumber = rand.Next(maxim);
            return randomNumber;
            
        }

        private void AddButton()
        {
            if (Canvs.Children.Count > 0)
                Canvs.Children.RemoveAt(0);

            Button button1 = new Button();
            button1.Height = 80;
            button1.Width = 150;
            SolidColorBrush[] colors =
           {
                Brushes.Black,
              Brushes.Red,
              Brushes.Blue,
              Brushes.Green,
              Brushes.Pink,
              Brushes.Brown
            };

            backColorIndex = backColorIndex < colors.Length - 1 ? backColorIndex + 1 : 0;
            button1.Background = colors[backColorIndex];
            button1.Click += Button1_Click1;

            Canvas.SetLeft(button1, GetRandomNumber((int)(this.Width - button1.Width - 10)));
            Canvas.SetTop(button1, GetRandomNumber((int)(this.Height - button1.Height)));
            Canvs.Children.Add(button1);
        }

        private void Button1_Click1(object sender, RoutedEventArgs e)
        {
            AddButton();
        }
    }
}
