using System;
using System.Windows;

namespace ThreeInARow
{
    
    public partial class GameView
    {
        private Field game;
        private Timer timer;

        public GameView()
        {
            InitializeComponent();
            StartGame();
        }
        
        private void StartGame()
        {
            int maxTime = 60;
            game = new Field(GameCanvas, ScoreLabel);
            timer = new Timer(game, TimeBar, TimeLabel, maxTime);
        }
    }
}
