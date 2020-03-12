using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public List<Athlete> athletes = new List<Athlete>();
        public List<Form> forms = new List<Form>();
        public Form1()
        {
            InitializeComponent();
        }
        [Serializable]
        public class Athlete
        {
            public string id;
            public string Sur;
            public string Sport;
            public Athlete(string id, string sur, string sport)
            {
                this.id = id;
                this.Sur = sur;
                this.Sport = sport;
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form form = new Form1();
            Show(form);
            forms.Add(form);
        }
        public void Save()
        {
            foreach(Form f in forms)
            {
                Athlete ath = new Athlete(textBox1.Text,textBox2.Text,textBox3.Text);
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
            for (int i = 0; i < forms.Count; i++)
            {
                Athlete ath;
                ath = athletes[i];
                foreach (Form f in forms)
                {
                    TextBox textBox1 = new TextBox();
                    TextBox textBox2 = new TextBox();
                    TextBox textBox3 = new TextBox();
                    textBox1.Text = ath.id;
                    textBox2.Text = ath.Sur;
                    textBox3.Text = ath.Sport;
                }
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
    }
}
