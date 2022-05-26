using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.Json;
using System.Xml.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmetaCreator.Models;
using SmetaCreator.Utils;
using System.IO;

namespace SmetaCreator
{
    public partial class Form1 : Form
    {
        public List<Executor> executors;
        public int selectedExecutorIndex;
        private int selectedWorkIndex;
        public List<Work> worksInSmeta;

        public Form1()
        {
            worksInSmeta = new List<Work>();
            InitializeComponent();
            try
            {
                string json = File.ReadAllText($"{AppDomain.CurrentDomain.BaseDirectory}/../../../Utils/profiles.json");
                executors = JsonSerializer.Deserialize<List<Executor>>(json)!;
                RefreshExecutors();
            }
            catch
            {
                executors = new List<Executor>();
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            selectedExecutorIndex = -1;
            selectedWorkIndex = -1;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string json = JsonSerializer.Serialize(executors);
            File.WriteAllText($"{AppDomain.CurrentDomain.BaseDirectory}/../../../Utils/profiles.json", json);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                worksInSmeta.Add(executors[selectedExecutorIndex].Works[selectedWorkIndex].Clone(int.Parse(textBox3.Text)));
                listBox1.Items.Add(worksInSmeta.Last().ListBoxView());
                textBox3.Clear();
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так! Проверьте введённые данные");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.SelectedIndex == 0)
            {
                selectedExecutorIndex = -1;
                EditProfiles();
                RefreshWorks();
            }
            else if(comboBox2.SelectedIndex > 0)
            {
                selectedExecutorIndex = comboBox2.SelectedIndex - 1;
                listBox1.Items.Clear();
                worksInSmeta.Clear();
                RefreshWorks();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                selectedWorkIndex = -1;
                EditProfiles();
            }
            else if(comboBox1.SelectedIndex > 0)
            {
                selectedWorkIndex = comboBox1.SelectedIndex - 1;
            }

        }

        private void EditProfiles()
        {
            comboBox2.SelectedIndex = -1;
            comboBox1.SelectedIndex = -1;
            Form form2 = new Form2(executors);
            form2.Show();
            form2.FormClosed += Form2_Closed;
        }

        private void Form2_Closed(object? sender, EventArgs e)
        {
            RefreshExecutors();
        }

        public void RefreshExecutors()
        {
            comboBox2.Items.Clear();
            comboBox2.Items.Add("Добавить");
            foreach (Executor executor in executors)
            {
                comboBox2.Items.Add(executor.Name);
            }
        }

        private void RefreshWorks()
        {
            comboBox1.SelectedIndex = -1;
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Добавить");
            if(selectedExecutorIndex >= 0 && executors[selectedExecutorIndex] != null)
            {
                foreach (Work work in executors[selectedExecutorIndex].Works)
                {
                    comboBox1.Items.Add(work.Name);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Smeta> smetas = new List<Smeta>();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Smeta>));
            Smeta smeta = new(executors[selectedExecutorIndex], textBox1.Text, textBox2.Text, worksInSmeta);
            smetas.Add(smeta);

            using (FileStream fs = new FileStream($"{AppDomain.CurrentDomain.BaseDirectory}/../../../Utils/smeta.xml", FileMode.Create))
            {
                xmlSerializer.Serialize(fs, smetas);
            }
            Class1.Method1();
        }
    }
}
