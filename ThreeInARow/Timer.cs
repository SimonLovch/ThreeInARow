using System;
using System.Windows;
using System.Windows.Controls;

namespace ThreeInARow
{
    public class Timer
    {
        System.Windows.Threading.DispatcherTimer dispatcherTimer;
        ProgressBar timeBar;
        Field gf;
        Label timeLabel;
        public bool end;
        public int maxTime;
        public int startTime;

        public Timer (Field game, ProgressBar timeBar, Label timeLabel, int maxTime = 60)
        {
            gf = game;
            startTime = 0;
            end = false;
            this.maxTime = maxTime;
            this.timeBar = timeBar;
            this.timeLabel = timeLabel;
            timeBar.Maximum = maxTime;
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            gf.MoveImages();
            startTime += 1;
            timeLabel.Content = startTime;
            timeBar.Value = startTime;
            System.Windows.Input.CommandManager.InvalidateRequerySuggested();
            if (startTime >= maxTime)
            {
                dispatcherTimer.Stop();
                end = true;
                var res = MessageBox.Show("GAME OVER", "GAME OVER", MessageBoxButton.OK, MessageBoxImage.None);
                if (res == MessageBoxResult.OK)
                {
                    MainWindow mv = new MainWindow();
                    var current = App.Current.Windows[0];
                    mv.Show();
                    current.Close();
                }
            }
        }
    }
}