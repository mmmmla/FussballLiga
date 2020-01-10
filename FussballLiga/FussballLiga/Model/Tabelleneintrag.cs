using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FussballVerein.Fussball
{
    public class Tabelleneintrag
    {
        #region Eigenschaften
        private Mannschaft _mannschaft;
        private int _punkte;
        private int _siege;
        private int _unentschieden;
        private int _niederlagen;
        private int _htore;
        private int _atore;
        private int _differenz;       

        #endregion Eigenschaften

        #region Accessoren

        public Mannschaft Mannschaft
        {
            set { _mannschaft = value; }
            get { return _mannschaft; }
        }
        
        public string Name
        {
            get { return _mannschaft.Name; }
        }

        public int Siege
        {
            set { _siege = value; }
            get { return _siege; }
        }

        public int Unentschieden
        {
            set { _unentschieden = value; }
            get { return _unentschieden; }
        }

        public int Niederlagen
        {
            set { _niederlagen = value; }
            get { return _niederlagen; }
        }

        public int HTore {
            set { _htore = value; }
            get { return _htore; }
        }

        public int ATore
        {
            set { _atore = value; }
            get { return _atore; }
        }

        public int Differenz
        {
            set { _differenz = value; }
            get { return _differenz; }
        }
        
        
        public int Punkte
        {
            set { _punkte = value; }
            get { return _punkte; }
        }

        
        #endregion Accessoren

        #region Konstruktoren

        public Tabelleneintrag()
        {

        }

        public Tabelleneintrag(Mannschaft mannschaft) {
            Mannschaft = mannschaft;
            Punkte = 0;
            Siege = 0;
            Unentschieden = 0;
            Niederlagen = 0;
            HTore = 0;
            ATore = 0;
            Differenz = 0;
        }

        public Tabelleneintrag(Mannschaft mannschaft,int punkte, int siege, int unentschieden, int niederlagen, int htore, int atore,
            int differenz) {
            Mannschaft = mannschaft;
            Punkte = punkte;
            Siege = siege;
            Unentschieden = unentschieden;
            Niederlagen = niederlagen;
            HTore = htore;
            ATore = atore;
            Differenz = differenz;
        }

        public Tabelleneintrag(Tabelleneintrag tabelleneintrag) {
            Mannschaft = tabelleneintrag.Mannschaft;
            Punkte = tabelleneintrag.Punkte;
            Siege = tabelleneintrag.Siege;
            Unentschieden = tabelleneintrag.Unentschieden;
            Niederlagen = tabelleneintrag.Niederlagen;
            HTore = tabelleneintrag.HTore;
            ATore = tabelleneintrag.ATore;
            Differenz = tabelleneintrag.Differenz;
        }

      

        #endregion Konstruktoren

        #region Worker

        #endregion Worker
    }
}
