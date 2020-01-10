using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FussballVerein.Fussball
{
    public class Tabelle {
        #region Eigenschaften
        private List<Tabelleneintrag> _tabelleneintraege;
        #endregion Eigenschaften

        #region Accessoren
        public List<Tabelleneintrag> Tabelleneintraege {
            get { return _tabelleneintraege;  }
            set { _tabelleneintraege = value; }
        }
        #endregion Accessoren

        #region Konstruktoren
        public Tabelle() {
            _tabelleneintraege = new List<Tabelleneintrag>();
            FuelleTabelle(null);
        }

        public Tabelle(List<Mannschaft> mannschaften,List<Spiel> gespielteSpiele) {
            _tabelleneintraege = new List<Tabelleneintrag>();
            FuelleTabelle(mannschaften);
            Aktualisieren(gespielteSpiele);
        }

        public Tabelle(Tabelle tabelle) {
            Tabelleneintraege = new List<Tabelleneintrag>();
            foreach (Tabelleneintrag te in tabelle.Tabelleneintraege) {
                Tabelleneintraege.Add(te);
            }
        }
        #endregion Konstruktoren

        #region Worker
        private void FuelleTabelle(List<Mannschaft> mannschaften) {
            foreach (Mannschaft m in mannschaften) {
                _tabelleneintraege.Add(new Tabelleneintrag(m));
            }
        }
        

        private void AktualisiereRaenge() {
            int t;
            for (int i = 0; i < _tabelleneintraege.Count; i++) {
                t = i;
                for (int j = i + 1; j < _tabelleneintraege.Count; j++) {
                    if (_tabelleneintraege[t].Punkte < _tabelleneintraege[j].Punkte) {
                        t = j;
                    } else if (_tabelleneintraege[t].Punkte == _tabelleneintraege[j].Punkte) {
                        if (_tabelleneintraege[t].Differenz < _tabelleneintraege[j].Differenz) {
                            t = j;
                        } else if (_tabelleneintraege[t].Differenz == _tabelleneintraege[j].Differenz)
                        {
                            if (_tabelleneintraege[t].HTore+ _tabelleneintraege[t].ATore <
                                _tabelleneintraege[j].HTore + _tabelleneintraege[j].ATore)
                            {
                                t = j;
                            }  else if (_tabelleneintraege[t].HTore + _tabelleneintraege[t].ATore ==
                                        _tabelleneintraege[j].HTore + _tabelleneintraege[j].ATore) {
                                                                   
                            }
                        }
                    }
                }
                Tabelleneintrag t1 = _tabelleneintraege[i];
                Tabelleneintrag t2 = _tabelleneintraege[t];
                _tabelleneintraege[i] = t2;
                _tabelleneintraege[t] = t1;
            }
        }

        

        public void Aktualisieren(Spiel gespieltesSpiel)
        {
            Aktualisieren(new List<Spiel> {gespieltesSpiel});
        }

        public void Aktualisieren(List<Spiel> gespielteSpiele) {
           foreach (Spiel sp in gespielteSpiele) {
                Tabelleneintrag hT = FindeTabellenEintrag(sp.HeimMannschaft);
                Tabelleneintrag aT = FindeTabellenEintrag(sp.AuswaertsMannschaft);
                hT.HTore += sp.HeimTore;
                hT.Differenz += sp.HeimTore - sp.AuswaertsTore;
                aT.ATore += sp.AuswaertsTore;
                aT.Differenz += sp.AuswaertsTore - sp.HeimTore;
                if (sp.HeimTore > sp.AuswaertsTore) {
                    aT.Niederlagen++;
                    hT.Siege++;
                    hT.Punkte += 3;
                } else if(sp.HeimTore < sp.AuswaertsTore) {
                    hT.Niederlagen++;
                    aT.Siege++;
                    aT.Punkte += 3;
                }   else {
                    hT.Unentschieden++;
                    hT.Punkte += 1;
                    aT.Unentschieden++;
                    aT.Punkte += 1;
                }
            }

            AktualisiereRaenge();
        }

        public void FuegeMannschafthinzu(Mannschaft m)
        {
            Tabelleneintraege.Add(new Tabelleneintrag(m));
        }

        public void EntferneMannschaft(Mannschaft m) {
            foreach (Tabelleneintrag te in Tabelleneintraege) {
                if (te.Mannschaft == m) {
                    Tabelleneintraege.Remove(te);
                    return;
                }
            }
        }

        private Tabelleneintrag FindeTabellenEintrag(Mannschaft m) {
            foreach (Tabelleneintrag t in _tabelleneintraege) {
                if (t.Mannschaft.Equals(m)) {
                    return t;
                }
            }
            return new Tabelleneintrag();
        }
        #endregion Worker

    }
}
