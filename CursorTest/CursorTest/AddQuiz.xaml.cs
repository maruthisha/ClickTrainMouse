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

        public AddQuiz()
        {
            InitializeComponent();
            CreateProblem();
        }

        private void Opt1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                //MessageBox.Show(((Button)sender).Content.ToString());
                CreateProblem();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void CreateProblem()
        {
            var FirstAddent = GetRandomNumber(10);
            var SecondAddent = GetRandomNumber(10);
            lblFirstAddent.Content = FirstAddent;
            lblSecondAddent.Content = SecondAddent;

            Opt1.Content = GetRandomNumber(20);
            Opt2.Content = GetRandomNumber(20);
            Opt3.Content = GetRandomNumber(20);
            Opt4.Content = GetRandomNumber(20);

            var CorrectChoice = GetRandomNumber(3);
            MessageBox.Show(CorrectChoice.ToString());
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
