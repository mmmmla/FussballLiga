using FussballVerein;
using FussballVerein.Fussball;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

namespace FussballLiga
{
    public partial class About : Page
    {

        protected void Table_Load()
        {
                LigaTabelle.DataSource = Controller.Tabelleneintraege();
                LigaTabelle.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Controller.Initialize();
            Table_Load();
        }

        protected void MannschaftHinzufuegen_Click(object sender, EventArgs e)
        {
            if (!Dupli.IsValid) return;
            if (MannschaftName.Text == "") return;

            Controller.FuegeMannschaftHinzu(new FussballVerein.Fussball.Mannschaft(MannschaftName.Text));
            Table_Load();
        }
        protected void Dupli_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                args.IsValid = !Controller.MannschaftNameBereitsVorhanden(MannschaftName.Text);
            }
            catch (Exception ex)
            {

                args.IsValid = false;

            }
        }

        protected void Speichern_Click(object sender, EventArgs e)
        {
            
            using(MemoryStream ms = new MemoryStream())
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Liga));
                using (StreamWriter sw = new StreamWriter(ms))
                {
                    serializer.Serialize(sw, Controller.KriegeLiga());
                    Response.Clear();
                    Response.ContentType = "application/xml";
                    Response.AddHeader("Content-Disposition", "attachment; filename=liga.xml");
                    Response.BinaryWrite(ms.ToArray());
                    Response.Flush();
                    Response.Close();
                    Response.End();
                }
            }               
        }
    }
}