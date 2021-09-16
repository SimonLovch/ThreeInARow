using System.Windows;
using System.Windows.Input;

namespace ThreeInARow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnStartBtnClick(object sender, RoutedEventArgs e)
        {
            GameView gv = new GameView();
            gv.Show();
            this.Close();
        }
    }
}