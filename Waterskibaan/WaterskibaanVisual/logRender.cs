using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using Waterskibaan;

namespace WaterskibaanVisual
{
    class logRender
    {
        private Logger _logger;
        private MainWindow _mainWindow;
        public logRender(Logger logger, MainWindow mainWindow)
        {
            _logger = logger;
            _mainWindow = mainWindow;
        }

        private Label CreateColorLabel(Color color)
        {
            return new Label()
            {
                Content = color,
                Background = new SolidColorBrush(color)
            };
        }

        private Label CreateMoveLabel(string move)
        {
            return new Label()
            {
                Content = move,
                Background = new SolidColorBrush(Colors.White)
            };
        }

        public void Render()
        {
            _mainWindow.sp_colors.Children.Clear();

            _mainWindow.lb_amountOfVisitors.Content = $"Totaal bezoekers: {_logger.GetTotalBezoekers()}";
            _mainWindow.lb_highestScore.Content = $"Highscore: {_logger.GetHighScore()}";
            _mainWindow.lb_amountOfVisitorsWithRedClothes.Content = $"Aantal bezoekers met rode kleding: {_logger.GetAmountOfRedSporters()}";
            _logger
                .GetListWithLightestClothes()
                .ForEach(color => _mainWindow.sp_colors.Children.Add(CreateColorLabel(Color.FromArgb(color.A, color.R, color.G, color.B))));
            _mainWindow.lb_amountOfLabs.Content = $"Aantal rondes: {_logger.GetAmountOfLaps()}";
            _mainWindow.sp_moves.Children.Clear();
            _logger
                .GetUniqueMoves()
                .ForEach(move => _mainWindow.sp_moves.Children.Add(CreateMoveLabel(move)));
        }
    }
}
