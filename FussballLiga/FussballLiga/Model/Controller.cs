using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FussballVerein.Fussball;

namespace FussballVerein
{
    class Controller
    {
        #region Eigenschaften
        static private Liga _liga;
        static private Boolean _initialized=false;
        #endregion Eigenschaften

        #region Accessoren
        
        #endregion Accessoren

        #region Konstruktoren
        public static void Initialize() {
            if(!_initialized)
            {
                LadeLigaUndMannschaften();
                ErstelleSpiele();
                _initialized = true;
            }
            
        }

        #endregion Konstruktoren

        #region Worker

        public static bool MannschaftNameBereitsVorhanden(string name)
        {
            foreach(Mannschaft m in _liga.Mannschaften)
            {
                if (name.Equals(m.Name)) return true;
            }
            return false;
        }

        public static Liga KriegeLiga()
        {
            return _liga;
        }

        public static void FuegeMannschaftHinzu(Mannschaft m)
        {
            _liga.FuegeMannschaftHinzu(m);
        }

        public static List<Tabelleneintrag> Tabelleneintraege()
        {
            return _liga.Tabelle.Tabelleneintraege;
        }

        private static void LadeLigaUndMannschaften()
        {
            List<Mannschaft> mannschaften = new List<Mannschaft>();
            mannschaften.Add(new Mannschaft("FC Augsburg"));
            mannschaften.Add(new Mannschaft("1. FC Union Berlin 1966"));
            mannschaften.Add(new Mannschaft("Hertha BSC"));
            mannschaften.Add(new Mannschaft("SV Werder Bremen"));
            mannschaften.Add(new Mannschaft("Borussia Dortmund"));
            mannschaften.Add(new Mannschaft("Fortuna Düsseldorf"));
            mannschaften.Add(new Mannschaft("Eintracht Frankfurt"));
            mannschaften.Add(new Mannschaft("SC Freiburg"));
            mannschaften.Add(new Mannschaft("TSG Hoffenheim"));
            mannschaften.Add(new Mannschaft("1.FC Köln"));
            mannschaften.Add(new Mannschaft("RB Leipzig"));
            mannschaften.Add(new Mannschaft("Bayer Leverkusen"));
            mannschaften.Add(new Mannschaft("FSV Mainz 05"));
            mannschaften.Add(new Mannschaft("Borussia Mönchengladbach"));
            mannschaften.Add(new Mannschaft("FC Bayern München"));
            mannschaften.Add(new Mannschaft("SC Paderborn 07"));
            mannschaften.Add(new Mannschaft("FC Schalke 04"));
            mannschaften.Add(new Mannschaft("VfL Wolfsburg"));
            _liga = new Liga("Bundesliga", mannschaften);
        }

        private static void ErstelleSpiele()
        {
            Random rnd = new Random();
            List<Spiel> gespielteSpiele = new List<Spiel>();
            for (int i = 0; i < 9; i++)
            {
                gespielteSpiele.Add(new Spiel(_liga.Mannschaften[i], _liga.Mannschaften[_liga.Mannschaften.Count - i - 1], rnd.Next(0, 5), rnd.Next(0, 5)));
            }
            _liga.HinterlegeSpiele(gespielteSpiele);
        }


        #endregion Worker
    }
}
