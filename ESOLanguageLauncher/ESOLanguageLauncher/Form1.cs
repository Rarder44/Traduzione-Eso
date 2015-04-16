using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESOLanguageLauncher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Save SalvataggioDati = new Save();
        private void Form1_Load(object sender, EventArgs e)
        {
            if(SalvataggioDati.LoadFromFile())
                if( SalvataggioDati.IsComplete())
                    Play();
                else
                {
                    textBox1.Text = SalvataggioDati.PathUserSettings;
                    textBox2.Text = SalvataggioDati.PathEso_exe;
                    textBox3.Text = SalvataggioDati.lang;
                }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "UserSettings*";
            String Doc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if(Directory.Exists(Doc+"\\Elder Scrolls Online\\liveeu"))
                openFileDialog1.InitialDirectory=Doc+"\\Elder Scrolls Online\\liveeu";
            else if (Directory.Exists(Doc + "\\Elder Scrolls Online\\live"))
                openFileDialog1.InitialDirectory = Doc + "\\Elder Scrolls Online\\live";
            else
                openFileDialog1.InitialDirectory = Doc;
            if(openFileDialog1.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                SalvataggioDati.PathUserSettings = openFileDialog1.FileName;
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SalvataggioDati.lang = textBox3.Text.Trim();
            SalvataggioDati.WriteToFile();
            if(SalvataggioDati.IsComplete())
            {
                Play();
            }
            else
                MessageBox.Show("Alcuni dati non sono stati impostati! ( o non sono stati rilevati dei file )");
            
        }


        private void Play()
        {
            
            if(!File.Exists(Path.GetDirectoryName(SalvataggioDati.PathUserSettings) + "\\UserSettings_backup.txt"))
                File.Copy(SalvataggioDati.PathUserSettings,Path.GetDirectoryName(SalvataggioDati.PathUserSettings) + "\\UserSettings_backup.txt");
            
            StreamReader r = new StreamReader(SalvataggioDati.PathUserSettings);
            String tt = "";
            while(!r.EndOfStream)
            {
                String t = r.ReadLine();
                if (t.StartsWith("SET Language.2"))
                    tt += "SET Language.2 \"" + SalvataggioDati.lang + "\"\r\n";
                else
                    tt += t+"\r\n";
            }
            r.Close();
            StreamWriter w = new StreamWriter(SalvataggioDati.PathUserSettings);
            w.Write(tt);
            w.Flush();
            w.Close();


            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = true;
            startInfo.FileName = "eso.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.WorkingDirectory = Path.GetDirectoryName(SalvataggioDati.PathEso_exe);
            Process p=Process.Start(startInfo);
           
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog2.FileName = "eso.exe*";
            String Doc = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            if (Directory.Exists(Doc))
                openFileDialog2.InitialDirectory = Doc;
            
            if (openFileDialog2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox2.Text = openFileDialog2.FileName;
                SalvataggioDati.PathEso_exe = openFileDialog2.FileName;
            }
        }
    }
}
