using System;
using System.Collections.Generic;
using System.Linq;

namespace FussballVerein.Fussball
{
    public class Liga
    {
        #region Eigenschaften

        private string _name;
        private List<Mannschaft> _mannschaften;
        private List<Spiel> _gespielteSpiele;
        private Tabelle _tabelle;
        #endregion Eigenschaften

        #region Accessoren
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public List<Mannschaft> Mannschaften {
            get { return _mannschaften; }
            set { _mannschaften = value; }
        }

        public List<Spiel> GespielteSpiele
        {
            get { return _gespielteSpiele; }
            set { _gespielteSpiele = value; }
        }

        public Tabelle Tabelle
        {
            get { return _tabelle; }
            set { _tabelle = value; }
        }
        #endregion Accessoren

        #region Konstruktoren

        public Liga()
        {
            Name = "";
            Mannschaften = new List<Mannschaft>();
            GespielteSpiele = new List<Spiel>();
            Tabelle = new Tabelle(Mannschaften, GespielteSpiele);
        }
        public Liga(string name)
        {
            Name = name;
            Mannschaften = new List<Mannschaft>();
            GespielteSpiele = new List<Spiel>();
            Tabelle = new Tabelle(Mannschaften, GespielteSpiele);
        }

        public Liga(string name,List<Mannschaft> mannschaften) {
            Name = name;
            Mannschaften = mannschaften;
            GespielteSpiele = new List<Spiel>();
            Tabelle = new Tabelle(Mannschaften, GespielteSpiele);
        }

        public Liga(Liga liga) {
            Name = liga.Name;
            Mannschaften = new List<Mannschaft>();
            foreach (Mannschaft m in liga.Mannschaften)
            {
                Mannschaften.Add(m);
            }
            GespielteSpiele = new List<Spiel>();
            foreach (Spiel s in liga.GespielteSpiele)
            {
                GespielteSpiele.Add(s);
            }
            Tabelle = new Tabelle(liga.Tabelle);
        }

        #endregion Konstruktoren

        #region Worker
        public void HinterlegeSpiel(Spiel spiel) {
            _gespielteSpiele.Add(spiel);
            _tabelle.Aktualisieren(_gespielteSpiele);
        }

        public void HinterlegeSpiele(List<Spiel> spiele) {
            foreach (Spiel spiel in spiele) {
                GespielteSpiele.Add(spiel);
            }
            _tabelle.Aktualisieren(_gespielteSpiele);
        }
        
        public void FuegeMannschaftHinzu(Mannschaft m)
        {
            Mannschaften.Add(m);
            Tabelle.FuegeMannschafthinzu(m);
        }
        
        public void LoescheMannschaft(Mannschaft m) {
            Mannschaften.Remove(m);
            Tabelle.EntferneMannschaft(m);
        }

        #endregion Worker



    }
}
