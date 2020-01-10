using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FussballVerein.Fussball
{
    public class Spiel
    {

        #region Eigenschaften
        private Mannschaft _heimMannschaft;
        private Mannschaft _auswaertsMannschaft;
        private int _heimTore;
        private int _auswaertsTore;
        #endregion Eigenschaften

        #region Accessoren
        public Mannschaft HeimMannschaft {
            get { return _heimMannschaft; }
            set { _heimMannschaft = value; }
        }

        public Mannschaft AuswaertsMannschaft {
            get { return _auswaertsMannschaft; }
            set { _auswaertsMannschaft = value; }
        }

        public int HeimTore {
            get { return _heimTore; }
            set { _heimTore = value; }
        }

        public int AuswaertsTore
        {
            get { return _auswaertsTore; }
            set { _auswaertsTore = value; }
        }
        #endregion Accessoren

        #region Konstruktoren

        public Spiel()
        {

        }

        public Spiel(Mannschaft heimMannschaft,Mannschaft auswaertsMannschaft,int heimTore,int auswaertsTore) {
            HeimMannschaft = heimMannschaft;
            AuswaertsMannschaft = auswaertsMannschaft;
            AuswaertsTore = auswaertsTore;
            HeimTore = heimTore;
        }

        public Spiel(Spiel spiel) {
            HeimMannschaft = spiel.HeimMannschaft;
            AuswaertsMannschaft = spiel.AuswaertsMannschaft;
            AuswaertsTore = spiel.AuswaertsTore;
            HeimTore = spiel.HeimTore;
        }

        #endregion Konstruktoren

        #region Worker
        

        #endregion Worker
    }
}
