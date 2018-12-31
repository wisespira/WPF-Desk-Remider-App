using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>    this.DragMove();
    public partial class MainWindow : Window
    {
        private string words = "New Year’s Resolution is to work on a skill every day for one hour LET IT BE DONE";
        private int seconds;
        private string secString;
        private int min;
        private string minString;
        private Random rnd = new Random();
        Boolean go = true;


        public MainWindow()
        {
            InitializeComponent();
            Left = System.Windows.SystemParameters.WorkArea.Width - Width;
            Top = System.Windows.SystemParameters.WorkArea.Height - Height;
            textRotation();
        }

        public async void textRotation()
        {
            await Task.Delay(1000);
            FormattedText TextFormat = new FormattedText(
                words, CultureInfo.CurrentCulture, System.Windows.FlowDirection.LeftToRight,
                new Typeface(this.Text.FontFamily, this.Text.FontStyle, this.Text.FontWeight, this.Text.FontStretch),
                this.Text.FontSize, System.Windows.Media.Brushes.Black,
                new NumberSubstitution());

            float TextPart = (float)TextFormat.Width / words.Length;
            for (int a = 0; a < words.Length; a++)
            {
                Text.Text = words.Substring(0, a + 1);
                await Task.Delay(200);
                Text.ScrollToHorizontalOffset(TextPart * a);
            }
            await Task.Delay(500);
            textRotation();
        }

        private void Text_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e) {}

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Stop");
            go = false;
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Start");
            go = true;
            while (go)
            {
                seconds = seconds + 1;
                if (seconds == 60) {
                    min = min + 1;
                    seconds = 0;
                }
                secString = seconds.ToString();
                if (seconds < 10)
                {
                    secString = "0" + secString;
                }
                minString = min.ToString();
                if(min < 10)
                {
                    minString = "0" + minString;
                }

                Text2.Text = " " + minString + " : " + secString + " ";
                if(min >= 60)
                {
                 byte r = (byte)rnd.Next(256);
                 byte g = (byte)rnd.Next(256);
                 byte b = (byte)rnd.Next(256);
                 Text2.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(r, g, b, 100));
                 Text.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(r, g, b, 100));
                }
                await Task.Delay(1000);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }


}
