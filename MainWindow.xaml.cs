using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace iks_oks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private Members
        private Xiliox[] rezultat;
        private bool igrac1;
        private bool igragotova;
        #endregion
        
        #region
        public MainWindow()
        {
            InitializeComponent();
            newGame();
            
        }
        #endregion
        private void newGame() 
        {
            rezultat = new Xiliox[9];
            for (var i=0; i<rezultat.Length; i++) 
            
                rezultat[i] = Xiliox.slobodan;
                igrac1 = true;
            Mreza.Children.Cast<Button>().ToList().ForEach(button=> 
            {
                button.Content = string.Empty;
                button.Background = Brushes.DarkGray;
                button.Foreground = Brushes.Blue;
            });
            igragotova = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (igragotova) 
            {
                newGame();
                return;
            }
            var button = (Button)sender;
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);
            var index = column +( row * 3);
            if (rezultat[index] != Xiliox.slobodan) 
            {
                return;
            }
            rezultat[index] = igrac1 ? Xiliox.slobodan : Xiliox.ox;
            button.Content = igrac1 ? "X" : "O";
            if (!igrac1) 
            {
                button.Foreground = Brushes.Green;
            }
            igrac1 ^= true;
            
            pobjednik();
        }
           private void pobjednik() 
           {
            
            if (rezultat[0] != Xiliox.slobodan && (rezultat[0] & rezultat[1] & rezultat[2]) == rezultat[0]) 
            {
                Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.BlueViolet;
                igragotova = true;
                 
            }
        }

    }
}
