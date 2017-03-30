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
using MahApps.Metro.Controls;
using Microsoft.Win32;
using MahApps.Metro;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Animation;

namespace Lab6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            mediaElement.Volume = 100;
            muteSlider.Minimum = 0;
            muteSlider.Maximum = 10;
            muteSlider.Value = 3;

            positionSlider.Minimum = 0;
            positionSlider.Value = 1;
            
        }
        private TimeSpan TotalTime;
        private void Button_Click(object sender, RoutedEventArgs e)
        {          
            mediaElement.Play();

            if (mediaElement.HasVideo == false && mediaElement.HasAudio == false)
            {
                MessageBox.Show("Можливо, ви не вибрали файл");

                //mediaElement.NaturalDuration.TimeSpan.TotalSeconds = 0;
            }
            else
            {
                positionSlider.Maximum = mediaElement.NaturalDuration.TimeSpan.TotalSeconds;


                TotalTime = mediaElement.NaturalDuration.TimeSpan;
              

                System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
                dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
                dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                dispatcherTimer.Start();

            }
           
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
          
                    positionSlider.Value = (mediaElement.Position.TotalSeconds);
                    time.Content = ((int)(mediaElement.Position.TotalSeconds)).ToString()+"/"+ ((int)(mediaElement.NaturalDuration.TimeSpan.TotalSeconds)).ToString();
              
        }

        double tempMute;
        private void Mute_Click(object sender, RoutedEventArgs e)
        {
            if (mediaElement.Volume > 0)
            {
                tempMute = muteSlider.Value;
                mediaElement.Volume = 0;
                muteSlider.Value = 0;
            }
            else
            {
                mediaElement.Volume = tempMute;
                muteSlider.Value = tempMute;
            }
        }

        private void StopButt_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Pause();
        }
        
        private void FileButt_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "c:\\";
            //   dlg.Filter = "Media files (*.wmv ,*.mp3)|*.wmv,*.mp3|All Files (*.*)|*.*";
            dlg.Filter = "File(*.wmv;*.mp4;*.mp3;*.WMVA;)|*.wmv;*.mp4;*.mp3;*.WMVA" + "|all (*.*)|*.* ";
            dlg.RestoreDirectory = true;

            if (dlg.ShowDialog() == true)
            {
                string selectedFileName = dlg.FileName;
                mediaElement.Source = new Uri(selectedFileName);
                mediaElement.Position = TimeSpan.FromSeconds(0);
            }
            mediaElement.Pause();
            mediaElement.Position = TimeSpan.FromSeconds(0);
        }

        private void ForwardButt_Click(object sender, RoutedEventArgs e)
        {
            
            if (positionSlider.Value < mediaElement.NaturalDuration.TimeSpan.TotalSeconds-15)
            {
                positionSlider.Value += mediaElement.NaturalDuration.TimeSpan.TotalSeconds / 10;
            }
            else { positionSlider.Value += 5; }
        }

        private void muteSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mediaElement.Volume = muteSlider.Value/10;
           // lol.OpacityMask.ReadLocalValue
        }

        private void positionSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
         //   mediaElement.Pause();
            mediaElement.Position = TimeSpan.FromSeconds(positionSlider.Value);
         //   mediaElement.Play();
        }


        private void positionSlider_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            mediaElement.Pause();
            mediaElement.Position = TimeSpan.FromSeconds(positionSlider.Value);
            mediaElement.Play();  
        }

        private void RewindButt_Click(object sender, RoutedEventArgs e)
        {
            //mediaElement.Position = mediaElement.Position - TimeSpan.FromSeconds(10);
            if (positionSlider.Value > 16)
            {
                positionSlider.Value -= mediaElement.NaturalDuration.TimeSpan.TotalSeconds/10;
            }
            else {positionSlider.Value -= 5;}
        }

        public void ChangeAppStyle()
        {           
            ThemeManager.ChangeAppStyle(this,
                                        ThemeManager.GetAccent("Red"),
                                        ThemeManager.GetAppTheme("BaseDark"));
        }

        public void ChangeAppStyleLight()
        {
            ThemeManager.ChangeAppStyle(this,
                                        ThemeManager.GetAccent("Blue"),
                                        ThemeManager.GetAppTheme("BaseLight"));
        }

        public void ChangeAppStyleDark()
        {
            ThemeManager.ChangeAppStyle(this,
                                        ThemeManager.GetAccent("Red"),
                                        ThemeManager.GetAppTheme("BaseDark"));
        }
        

        private void DarkThem_Click(object sender, RoutedEventArgs e)
         {
            ChangeAppStyle();

            DoubleAnimation FadingAnim1= new DoubleAnimation();
            FadingAnim1.From = DarkThem.Opacity;
            FadingAnim1.To = 0.2;
            FadingAnim1.Duration = TimeSpan.FromMilliseconds(1500);
            FadingAnim1.AutoReverse = true;
            FadingAnim1.RepeatBehavior = new RepeatBehavior(1500);
            DarkThem.BeginAnimation(Button.OpacityProperty, FadingAnim1);
            FadingAnim1.RepeatBehavior = new RepeatBehavior(TimeSpan.FromSeconds(3));

            FadingAnim1 = new DoubleAnimation();
            FadingAnim1.Duration = TimeSpan.FromMilliseconds(500);
            LightThem.BeginAnimation(Button.OpacityProperty, FadingAnim1);
        }

        private void LightThem_Click(object sender, RoutedEventArgs e)
        {
            ChangeAppStyleLight();

            DoubleAnimation FadingAnim = new DoubleAnimation();
            FadingAnim.From = LightThem.Opacity;
            FadingAnim.To = 0.2;
            FadingAnim.Duration = TimeSpan.FromMilliseconds(1500);
            FadingAnim.AutoReverse = true;
            FadingAnim.RepeatBehavior = new RepeatBehavior(1500);
            LightThem.BeginAnimation(Button.OpacityProperty, FadingAnim);
            FadingAnim.RepeatBehavior = new RepeatBehavior(TimeSpan.FromSeconds(3));

            FadingAnim = new DoubleAnimation();
            FadingAnim.Duration = TimeSpan.FromMilliseconds(500);
            DarkThem.BeginAnimation(Button.OpacityProperty, FadingAnim);
        }

        private void NoButt_Click(object sender, RoutedEventArgs e)
        {
             mediaElement.Position = TimeSpan.FromSeconds(0);
            //mediaElement.Stop();
        }
    }
    }

