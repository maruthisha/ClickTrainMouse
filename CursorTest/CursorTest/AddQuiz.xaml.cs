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
using System.Windows.Threading;

namespace CursorTest
{
    /// <summary>
    /// Interaction logic for AddQuiz.xaml
    /// </summary>
    public partial class AddQuiz : Window
    {
        Random rand = new Random();
        int FirstFactor;
        int SecondFactor;
        char[] signs = { '+', 'x', '-', '/' };
        char selectedSign = '+';
        int timeElapsed = 0;
        int totalTimer = 0;
        System.Windows.Threading.DispatcherTimer dispatcherTimer;
        DispatcherTimer overallTimer;
        List<String> result = new System.Collections.Generic.List<string>();
        int problemNumber = 0;

        public AddQuiz()
        {
            InitializeComponent();
            
            lblTime.Content = "0";
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);

            overallTimer = new System.Windows.Threading.DispatcherTimer();
            overallTimer.Tick += totalTimer_Tick;
            overallTimer.Interval = new TimeSpan(0, 0, 1);
            overallTimer.Start();
            CreateProblem();
        }

        private void totalTimer_Tick(object sender, EventArgs e)
        {
            totalTimer++;

            if (totalTimer > 180)
            {
                overallTimer.Stop();
                finishTest();
                totalTimer = 0;
                overallTimer.Start();
                result = new List<string>();
                CreateProblem();
            }

            lblTotalTime.Content = totalTimer;
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            timeElapsed++;
            

            lblTime.Content = timeElapsed;
            
        }

        private void finishTest()
        {
            MessageBox.Show(string.Join(Environment.NewLine, result.ToArray()));
        }

        private void Opt1_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();

            try
            {
                var answer = int.Parse(((Button)sender).Content.ToString());
                result.Add(String.Format("{5}. {0} {1} {2} = {3} \t {4}", FirstFactor, selectedSign, SecondFactor, answer, timeElapsed, problemNumber));

                if (answer == getCorrectAnswer())
                {
                    lblSum.Content = answer;
                    Root.Background = Brushes.Green;
                    SwapOptions(false);
                    //System.Threading.Thread.Sleep(5000);
                    //CreateProblem();
                }
                else
                {
                    dispatcherTimer.Start();
                    Root.Background = Brushes.Red;
                }
                //MessageBox.Show(((Button)sender).Content.ToString());
                
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void SwapOptions(bool flag)
        {
            Opt1.Visibility = flag? Visibility.Visible:Visibility.Hidden;
            Opt2.Visibility = flag ? Visibility.Visible : Visibility.Hidden;
            Opt3.Visibility = flag ? Visibility.Visible : Visibility.Hidden;
            Opt4.Visibility = flag ? Visibility.Visible : Visibility.Hidden;
        }

        private void getFactors()
        {
            int maxFactor = 10;
             if (selectedSign == '+' || selectedSign == '-')
            //if (selectedSign != '/')
            {
                maxFactor = 40;
            }
            var firstFactor = GetRandomNumber(maxFactor);
            var secondFactor = GetRandomNumber(maxFactor);
           
            if (selectedSign == '-')
            {
                firstFactor = firstFactor + secondFactor;
                //FirstFactor = Math.Max(firstFactor, secondFactor);
                //SecondFactor = Math.Min(firstFactor, secondFactor);
                //return;
            }

            if (selectedSign == '/')
            {
                while (firstFactor == 0 || secondFactor == 0)
                {
                    firstFactor = GetRandomNumber(maxFactor);
                    secondFactor = GetRandomNumber(maxFactor);
                }
                firstFactor = firstFactor * secondFactor;
            }

            FirstFactor = firstFactor;
            SecondFactor = secondFactor;
            
        }

        private void getProblemType()
        {
            var signIndex = GetRandomNumber(signs.Length);
            selectedSign = signs[signIndex];
            lblSign.Content = selectedSign;
        }

        private int getCorrectAnswer()
        {
            int correctAnswer = 0;
            switch (selectedSign)
            {
                case 'x':
                    return FirstFactor * SecondFactor;
                case '-':
                    return FirstFactor - SecondFactor;
                case '/':
                    return FirstFactor / SecondFactor;
                default:
                    return FirstFactor + SecondFactor;
            }
        }

        private void CreateProblem()
        {
            problemNumber++;

            timeElapsed = 0;
            if (dispatcherTimer != null)
            {
                dispatcherTimer.Start();
            }
            
            

            SwapOptions(true);

            getProblemType();

            getFactors();

            

            lblFirstAddent.Content = FirstFactor;
            lblSecondAddent.Content = SecondFactor;

            List<int> options = new List<int>();
            while (options.Count < 4)
            {
                var option = GetRandomNumber(20);
                if (options.Contains(option) || option == (FirstFactor + SecondFactor))
                {
                    continue;
                }
                options.Add(option);
            }

            Opt1.Content = options[0];
            Opt2.Content = options[1];
            Opt3.Content = options[2];
            Opt4.Content = options[3];

            var correctChoice = GetRandomNumber(3);
            var correctAnswer = getCorrectAnswer();

            if (options.Contains(correctAnswer))
            {
                return;
            }
            switch (correctChoice)
            {
                case 0:
                    Opt1.Content = correctAnswer;
                    break;
                case 1:
                    Opt2.Content = correctAnswer;
                    break;
                case 2:
                    Opt3.Content = correctAnswer;
                    break;
                case 3:
                    Opt4.Content = correctAnswer;
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

        private void Opt41_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lblSum.Content = "___";
                Root.Background = Brushes.Black;
                CreateProblem();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Finish_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                finishTest();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
