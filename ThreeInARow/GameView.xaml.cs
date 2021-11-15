using System;
using System.Windows;

namespace ThreeInARow
{
    
    public partial class GameView
    {
        private Field game;

        public GameView()
        {
            InitializeComponent();
            StartGame();
        }
        
        private void StartGame()
        {
            int maxTime = 60;
            game = new Field(Canvas, ScoreLabel);
            timer = new Timer(game, TimeBar, TimeLabel, maxTime);
        }
    }
}
