using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;



namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public List<Athlete> athletes = new List<Athlete>();
        public List<UserControl1> UCs = new List<UserControl1>();
        public Form1()
        {
            InitializeComponent();
        }
        [Serializable]
        public class Athlete
        {
            public string Name;
            public string Sur;
            public string Sport;
            public Athlete()
            {
                Name = "default";
                Sur = "default";
                Sport = "default";
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
           LoadData();
        }

        public void Save()
        {
            foreach(UserControl1 uc in UCs)
            {
                Athlete ath = new Athlete();
                ath.Name = uc.textBox1.Text;
                ath.Sur = uc.textBox2.Text;
                ath.Sport = uc.comboBox1.Text;
                athletes.Add(ath);
            }
            XmlSerializer ser = new XmlSerializer(typeof(List<Athlete>));
            using (FileStream fs = new FileStream("../data.xml", FileMode.OpenOrCreate))
                ser.Serialize(fs, athletes);
        }
        public void LoadData()
        {
            List<Athlete> list;
            XmlSerializer ser = new XmlSerializer(typeof(List<Athlete>));
            using (FileStream fs = new FileStream("../data.xml", FileMode.Open))
              list = (List<Athlete>)ser.Deserialize(fs);
            int i = 0;
            while(i < list.Count)
            {
                UserControl1 uc = new UserControl1();
                UCs.Add(uc);
                Athlete ath;
                ath = athletes[i];
                uc.textBox1.Text = ath.Name;
                uc.textBox2.Text = ath.Sur;
                uc.comboBox1.Text = ath.Sport;
                i++;
            }
        }

        private static TextBox NewMethod()
        {
            return new TextBox();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Save();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            UserControl1 uc = new UserControl1();
            UCs.Add(uc);
            Show(uc);
        }
    }
}
