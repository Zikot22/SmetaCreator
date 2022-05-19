using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmetaCreator.Models;

namespace SmetaCreator
{
    public partial class Form1 : Form
    {
        private List<Executor> executors;
        private Executor? selectedExecutor;
        public Form1()
        {
            executors = new List<Executor>();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.SelectedIndex == 0)
            {
                AddNewExecutor();
            }
            else if(comboBox2.SelectedIndex > 0)
            {
                selectedExecutor = executors[comboBox2.SelectedIndex-1];
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == comboBox1.Items.Count - 1)
            {
                AddNewWork();
            }
            else
            {

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
                price = double.Parse(stringPrice);
                Work work = new(name, price);
                //реализовать добавление в список работ текущего исполнителя
            }
            catch
            {
                MessageBox.Show("Введите ценну в формате рубли.копейки");
            }
            form.Close();
        }

        private void RefreshExecutors()
        {
            comboBox2.Items.Clear();
            comboBox2.Items.Add("Добавить");
            foreach(Executor executor in executors)
            {
                comboBox2.Items.Add(executor.Name);
            }
        }
    }
}
