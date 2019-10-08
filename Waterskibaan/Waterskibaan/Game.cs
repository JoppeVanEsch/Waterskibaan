using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Waterskibaan
{
    class Game
    {
        private Timer _timer;
        private int _elapsed;

        private Waterskibaan _waterskibaan;
        private InstructieGroep _instructieGroep;
        private WachtrijInstructie _wachtrijInstructie;
        private WachtrijStarten _wachtrijStarten;

        public void Initialize()
        {
            _waterskibaan = new Waterskibaan();
            _instructieGroep = new InstructieGroep();
            _wachtrijInstructie = new WachtrijInstructie();
            _wachtrijStarten = new WachtrijStarten();
            try
            {
                SetTimer();
            }
            catch (Exception e)
            {
                throw e;
            }
            Console.ReadLine();
            _timer.Stop();
            _timer.Dispose();
        }

        private void SetTimer()
        {
            // Create a timer with a two second interval.

            _timer = new Timer(1000);
            // Hook up the Elapsed event for the timer. 
            try
            {
                _timer.Elapsed += OnTimerElapsed;
            }
            catch (Exception e)
            {
                throw e;
            }
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }


        private void OnTimerElapsed(object source, ElapsedEventArgs e)
        {
            _elapsed++;
            Sporter sporter = new Sporter(MoveCollection.GetWillekeurigeMoves());
            sporter.Skies = new Skies();
            sporter.Zwemvest = new Zwemvest();

            _waterskibaan.SporterStart(sporter);
            _waterskibaan.VerplaatsKabel();

            Console.WriteLine(_waterskibaan);
            //waterskibaan.SporterStart(new Sporter(MoveCollection.GetWillekeurigeMoves()));
            //waterskibaan.VerplaatsKabel();
            //Console.WriteLine(waterskibaan.ToString());
        }
    }
}
