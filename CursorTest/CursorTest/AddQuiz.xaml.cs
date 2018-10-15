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
using System.Windows.Shapes;

namespace CursorTest
{
    /// <summary>
    /// Interaction logic for AddQuiz.xaml
    /// </summary>
    public partial class AddQuiz : Window
    {
        Random rand = new Random();
        int FirstAddent;
        int SecondAddent;

        public AddQuiz()
        {
            InitializeComponent();
            CreateProblem();
        }

        private void Opt1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var sum = int.Parse(((Button)sender).Content.ToString());
                if (sum == (FirstAddent + SecondAddent))
                {
                    lblSum.Content = sum;
                    lblSum.Background = Brushes.Green;
                    //System.Threading.Thread.Sleep(5000);
                    //CreateProblem();
                }
                else
                {
                    lblSum.Content = sum;
                    lblSum.Background = Brushes.Red;
                }
                //MessageBox.Show(((Button)sender).Content.ToString());
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void CreateProblem()
        {
            FirstAddent = GetRandomNumber(10);
            SecondAddent = GetRandomNumber(10);

            lblFirstAddent.Content = FirstAddent;
            lblSecondAddent.Content = SecondAddent;
            List<int> options = new List<int>();
            while (options.Count < 4)
            {
                var option = GetRandomNumber(20);
                if (options.Contains(option) || option == (FirstAddent + SecondAddent))
                {
                    continue;
                }
                options.Add(option);
            }

            Opt1.Content = options[0];
            Opt2.Content = options[1];
            Opt3.Content = options[2];
            Opt4.Content = options[3];

            var CorrectChoice = GetRandomNumber(3);
            
            switch (CorrectChoice)
            {
                case 0:
                    Opt1.Content = (FirstAddent + SecondAddent);
                    break;
                case 1:
                    Opt2.Content = (FirstAddent + SecondAddent);
                    break;
                case 2:
                    Opt3.Content = (FirstAddent + SecondAddent);
                    break;
                case 3:
                    Opt4.Content = (FirstAddent + SecondAddent);
                    break;
                default:
                    break;
            }
        }

        private int GetRandomNumber(int maxim)
        {
           
            var randomNumber = rand.Next(maxim);
            return randomNumber;

        }
    }
}
