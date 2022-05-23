using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmetaCreator.Models;
using System.IO;

namespace SmetaCreator
{
    public partial class Form1 : Form
    {
        private List<Executor>? executors;
        private int selectedExecutorIndex;
        private int selectedWorkIndex;
        private List<Work> worksInSmeta;

        public Form1()
        {
            worksInSmeta = new List<Work>();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            selectedExecutorIndex = -1;
            selectedWorkIndex = -1;
            try
            {
                string? json = File.ReadAllText($"{AppDomain.CurrentDomain.BaseDirectory}/../../../Utils/profiles.json");
                executors = JsonSerializer.Deserialize<List<Executor>>(json);
                RefreshExecutors();
            }
            catch
            {
                executors = new List<Executor>();
            }
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
                executors[selectedExecutorIndex].Works[selectedWorkIndex].Amount = int.Parse(textBox3.Text);
                worksInSmeta.Add(executors[selectedExecutorIndex].Works[selectedWorkIndex]);
                listBox1.Items.Add(executors[selectedExecutorIndex].Works[selectedWorkIndex].ListBoxView());
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
                AddNewExecutor();
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
            if (comboBox1.SelectedIndex == 0 && selectedExecutorIndex >= 0)
            {
                AddNewWork();
            }
            else if(comboBox1.SelectedIndex > 0)
            {
                selectedWorkIndex = comboBox1.SelectedIndex - 1;
            }

        }

        private void AddNewExecutor()
        {
            comboBox2.SelectedIndex = -1;
            Form form2 = new Form() { Width = 226, Height = 130 };
            Label lbl = new Label() { Parent = form2, Location = new Point(5, 5), Text = "Введите имя исполнителя: ", Width = 200 };
            TextBox txt = new TextBox() { Parent = form2, Location = new Point(5, 28), Width = 200, Height = 20 };
            Button button = new Button() { Parent = form2, Location = new Point(105, 60), Width = 100, Height = 23, Text = "Создать" };
            form2.Show();
            button.Click += (sender, EventArgs) => { Button_NewExecutor(sender, EventArgs, txt.Text, form2); };
        }

        private void Button_NewExecutor(object? sender, EventArgs e, string name, Form form)
        {
            Executor executor = new (name);
            executors.Add(executor);
            form.Close();
            RefreshExecutors();
        }

        private void RefreshExecutors()
        {
            comboBox2.Items.Clear();
            comboBox2.Items.Add("Добавить");
            foreach (Executor executor in executors)
            {
                comboBox2.Items.Add(executor.Name);
            }
        }

        private void AddNewWork()
        {
            comboBox1.SelectedIndex = -1;
            Form form2 = new Form() { Width = 226, Height = 180 };
            Label lbl1 = new Label() { Parent = form2, Location = new Point(5, 5), Text = "Введите название работы: ", Width = 200 };
            TextBox txt1 = new TextBox() { Parent = form2, Location = new Point(5, 28), Width = 200, Height = 20 };
            Label lbl2 = new Label() { Parent = form2, Location = new Point(5, 55), Text = "Введите цену за ед работы: ", Width = 200 };
            TextBox txt2 = new TextBox() { Parent = form2, Location = new Point(5, 78), Width = 200, Height = 20 };
            Button button = new Button() { Parent = form2, Location = new Point(105, 110), Width = 100, Height = 23, Text = "Создать" };
            form2.Show();
            button.Click += (sender, EventArgs) => { Button_NewWork(sender, EventArgs, txt1.Text, txt2.Text, form2); };
        }

        private void Button_NewWork(object? sender, EventArgs e, string name, string stringPrice, Form form)
        {
            double price;
            try
            {
                double.TryParse(stringPrice, out price);
                Work work = new(name, price);
                executors[selectedExecutorIndex].Works.Add(work);
            }
            catch
            {
                MessageBox.Show("Введите ценну в формате рубли,копейки");
            }
            form.Close();
            RefreshWorks();
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
            Smeta smeta = new(executors[selectedExecutorIndex], textBox1.Text, textBox2.Text, executors[selectedExecutorIndex].Works);
            string json = JsonSerializer.Serialize(smeta);
            File.WriteAllText($"{AppDomain.CurrentDomain.BaseDirectory}/../../../Utils/smeta.json", json);
        }
    }
}
