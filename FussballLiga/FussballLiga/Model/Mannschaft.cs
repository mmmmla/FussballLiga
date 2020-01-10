using System.Collections.Generic;
namespace FussballVerein.Fussball
{
    public class Mannschaft
    {
        #region Eigenschaften
        private string _name;
        #endregion Eigenschaften

        #region Accessoren
        public string Name
        {
            get {  return _name; }
            set{  _name = value; }
        }
        #endregion Accessoren

        #region Konstruktoren
        public Mannschaft() { }

        public Mannschaft(string name) {
            Name = name;
        }

        public Mannschaft(Mannschaft mannschaft) {
            Name = mannschaft.Name+"";
        }
        #endregion Konstruktoren

        #region Worker


        public override string ToString()
        {
            return Name;
        }

        #endregion Worker


    }
}
