using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace ESOLanguageLauncher
{
    public class Save
    {

        public String PathUserSettings = "";
        public String PathEso_exe = "";
        public String lang = "";

        [XmlIgnore]
        String ConfFileName = "conf.xml";

        
        public Save()
        {
        }

        public bool IsComplete()
        {
            return PathUserSettings.Trim() != "" && File.Exists(PathUserSettings) && PathEso_exe.Trim() != "" && File.Exists(PathEso_exe) && lang.Trim() != "";
        }

        public bool LoadFromFile()
        {
            if (File.Exists(ConfFileName))
            {
                XmlSerializer s = new XmlSerializer(this.GetType());
                StreamReader r = new StreamReader(ConfFileName);
                this.SetSave((Save)s.Deserialize(r));
                r.Close();
                return true;
            }
            else 
                return false;
        }
        public void WriteToFile()
        {
           XmlSerializer s = new XmlSerializer(this.GetType());
           StreamWriter w = new StreamWriter(ConfFileName);
           s.Serialize(w, this);
           w.Close();
        }

        public void SetSave(Save o)
        {
            this.PathUserSettings = o.PathUserSettings;
            this.PathEso_exe = o.PathEso_exe;
            this.lang = o.lang;
        }

      
    }
}
