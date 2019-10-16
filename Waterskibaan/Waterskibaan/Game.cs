
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Threading;

namespace Waterskibaan
{
    public class Game
    {
        public int _counter;
        private static Random _random = new Random();

        public readonly Waterskibaan waterskibaan = new Waterskibaan();
        public readonly InstructieGroep _instructieGroep = new InstructieGroep();
        public readonly WachtrijInstructie _wachtrijInstructie = new WachtrijInstructie();
        public readonly WachtrijStarten _wachtrijStarten = new WachtrijStarten();

        public Logger _logger;

        public delegate void NieuweBezoekerHandler(NieuweBezoekerArgs args);
        public event NieuweBezoekerHandler NieuweBezoeker;

        public delegate void InstructieAfgelopenHandler(InstructieAfgelopenArgs args);
        public event InstructieAfgelopenHandler InstructieAfgelopen;

        public delegate void LijnenVerplaatstHandler(LijnenVerplaatsArgs args);
        public event LijnenVerplaatstHandler LijnenVerplaatst;

        public void Initialize(DispatcherTimer timer)
        {
            _logger = new Logger(waterskibaan._kabel);
            NieuweBezoeker += _wachtrijInstructie.NieuweBezoeker;
            InstructieAfgelopen += _instructieGroep.InstructieAfgelopen;
            InstructieAfgelopen += _wachtrijStarten.InstructieAfgelopen;

            timer.Tick += OnTimerEvent;
            timer.Tick += OnNieuweBezoeker;
            timer.Tick += OnInstructieAfgelopen;
            timer.Tick += OnLijnenVerplaatst;

        }


        private int getRandomTime()
        {
            return _random.Next(500, 1501);
        }

        private void OnTimerEvent(object source, EventArgs e)
        {
            _counter++;

            Console.WriteLine(waterskibaan);
            Console.WriteLine(_wachtrijInstructie);
            Console.WriteLine(_instructieGroep);
            Console.WriteLine(_wachtrijStarten);
        }

        private void OnNieuweBezoeker(object source, EventArgs e)
        {
            if (_counter % 3 != 0) return;

            var bezoeker = new Sporter(MoveCollection.GetWillekeurigeMoves());
            var args = new NieuweBezoekerArgs
            {
                Sporter = bezoeker
            };

            _logger.Bezoeker.Add(bezoeker);

            NieuweBezoeker?.Invoke(args);
        }

        private void OnInstructieAfgelopen(object source, EventArgs e)
        {
            if (_counter % 20 != 0) return;

            var args = new InstructieAfgelopenArgs
            {
                SportersKlaar = _instructieGroep.SportersVerlatenRij(5),
                SportersNieuw = _wachtrijInstructie.SportersVerlatenRij(5)
            };
            InstructieAfgelopen?.Invoke(args);
        }

        private void OnLijnenVerplaatst(object source, EventArgs e)
        {
            if (_counter % 3 != 0) return;

            waterskibaan.VerplaatsKabel();

            if (waterskibaan._kabel.IsStartPositieLeeg())
            {
                List<Sporter> sporters = _wachtrijStarten.SportersVerlatenRij(1);
                if (sporters.Count > 0)
                {
                    Sporter sporter = sporters[0];
                    sporter.Zwemvest = new Zwemvest();
                    sporter.Skies = new Skies();

                    waterskibaan.SporterStart(sporter);

                    var random = new Random();

                    foreach (var line in waterskibaan._kabel.Lijnen)
                    {
                        line.Sporter.HuidigeMove = random.Next(0, 100) <= 25 ? line.Sporter.Moves[random.Next(0, line.Sporter.Moves.Count)] : null;
                        line.Sporter.Score += line.Sporter.HuidigeMove?.Move() ?? 0;
                    }

                    var args = new LijnenVerplaatsArgs
                    {
                        Sporter = sporter,
                        Lijnen = waterskibaan._kabel.Lijnen
                    };

                    LijnenVerplaatst?.Invoke(args);
                }
            }
        }

        //public override string ToString()
        //{
        //    var data = "Waterskibaan\n\n";

        //    data += $"{waterskibaan}\n";
        //    data += $"{_wachtrijInstructie}\n";
        //    data += $"{_instructieGroep}\n";
        //    data += $"{_wachtrijStarten}\n\n";

        //    data += $"Totaal aantal bezoekers: {_logger.Bezoeker.Count}\n";
        //    if (_logger.Bezoeker.Count > 0)
        //    {
        //        var laps = 0;
        //        var uniqueMoves = new List<string>();

        //        _logger.Bezoeker.ForEach(x => laps += Math.Abs(x.AantalRondenNogTeGaan));
        //        waterskibaan._kabel.Lijnen.ToList().ForEach(line => line.Sporter.Moves.ForEach(move => uniqueMoves.Add(move.ToString())));
        //        uniqueMoves = uniqueMoves.Distinct().ToList();

        //        data += $"Hoogste score: {_logger.Bezoeker.Max(x => x.Score)}\n";
        //        data += $"Totaal aantal rondjes: {laps}\n";
        //        data += $"Unieke moves: ";
        //        uniqueMoves.ForEach(move => data += $"\n - {move}");
        //    }
        //    else
        //    {
        //        data += "Hoogste score: 0";
        //        data += "Totaal aantal rondjes: 0";
        //        data += "Unieke moves: []";
        //    }

        //    return data;
        //}
    }
}
