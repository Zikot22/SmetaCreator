using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SmetaCreator.Models;

namespace SmetaCreator.Utils
{
    public partial class Form2 : Form
    {
        private List<Executor> executors;
        public Form2(List<Executor> executors)
        {
            this.executors = executors;
            InitializeComponent();
            RefreshExecutors();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshWorks();
        }

        private void RefreshExecutors()
        {
            listBox1.Items.Clear();
            foreach(var executor in executors)
            {
                listBox1.Items.Add(executor.Name!);
            }
            textBox1.Clear();
        }

        private void RefreshWorks()
        {
            try
            {
                listBox2.Items.Clear();
                foreach (var work in executors[listBox1.SelectedIndex].Works)
                {
                    listBox2.Items.Add(work.Name + " " + work.Price.ToString() + " руб за ед");
                }
                textBox2.Clear();
                textBox3.Clear();
            }
            catch
            {
                if (executors.Count >= 1)
                {
                    listBox1.SelectedIndex = 0;
                    RefreshWorks();
                }
            }
        }

        //добавление исполнителя
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox1.Text.ToCharArray()[0] != ' ')
            {
                executors.Add(new Executor(textBox1.Text));
                RefreshExecutors();
            }
            else
            {
                MessageBox.Show("Введите корректное имя исполнителя");
            }
        }

        //изменение исполнителя
        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                if (textBox1.Text != "" && textBox1.Text.ToCharArray()[0] != ' ')
                {
                    executors[listBox1.SelectedIndex].Name = textBox1.Text;
                    RefreshExecutors();
                }
                else
                {
                    MessageBox.Show("Введите корректное имя исполнителя");
                }
            }
            else
            {
                MessageBox.Show("Выберите исполнителя");
            }
        }

        //удаление исполнителя
        private void button3_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex >= 0)
            {
                executors.RemoveAt(listBox1.SelectedIndex);
                RefreshExecutors();
                listBox2.Items.Clear();
                RefreshWorks();
            }
            else
            {
                MessageBox.Show("Выберите исполнителя");
            }
        }

        //добавление работы
        private void button6_Click(object sender, EventArgs e)
        {
            double price;
            try
            {
                if (listBox1.SelectedIndex >= 0)
                {
                    double.TryParse(textBox3.Text, out price);
                    if(textBox2.Text != "" && textBox2.Text.ToCharArray()[0] != ' ')
                    {
                        Work work = new(textBox2.Text, price);
                        executors[listBox1.SelectedIndex].Works.Add(work);
                    }
                    else
                    {
                        MessageBox.Show("Введите корректное название работы");
                    }
                }
                else
                {
                    MessageBox.Show("Выберите исполнителя");
                }
            }
            catch
            {
                MessageBox.Show("Введите ценну в формате рубли,копейки");
            }
            RefreshWorks();
        }

        //изменение работы
        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex >= 0)
            {
                double price;
                try
                {
                    if (textBox3.Text != "")
                    {
                        double.TryParse(textBox3.Text, out price);
                        executors[listBox1.SelectedIndex].Works[listBox2.SelectedIndex].Price = price;
                    }
                }
                catch
                {
                    MessageBox.Show("Введите ценну в формате рубли,копейки");
                }
                if(textBox2.Text != "" && textBox2.Text.ToCharArray()[0] != ' ')
                {
                    executors[listBox1.SelectedIndex].Works[listBox2.SelectedIndex].Name = textBox2.Text;
                }
                RefreshWorks();
            }
            else
            {
                MessageBox.Show("Выберите работу");
            }
        }
        
        //удаление работы
        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex >= 0)
            {
                executors[listBox1.SelectedIndex].Works.RemoveAt(listBox2.SelectedIndex);
                RefreshWorks();
            }
            else
            {
                MessageBox.Show("Выберите работу");
            }
        }
    }
}
