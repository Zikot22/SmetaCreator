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
using SmetaCreator;

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
            executors.Add(new Executor(textBox1.Text));
            RefreshExecutors();
        }

        //изменение исполнителя
        private void button2_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex >= 0)
            {
                executors[listBox1.SelectedIndex].Name = textBox1.Text;
            }
            RefreshExecutors();
        }

        //удаление исполнителя
        private void button3_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex >= 0)
            {
                executors.RemoveAt(listBox1.SelectedIndex);
            }
            RefreshExecutors();
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
                    Work work = new(textBox2.Text, price);
                    executors[listBox1.SelectedIndex].Works.Add(work);
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
                    double.TryParse(textBox3.Text, out price);
                    executors[listBox1.SelectedIndex].Works[listBox2.SelectedIndex].Price = price;
                    executors[listBox1.SelectedIndex].Works[listBox2.SelectedIndex].Name = textBox2.Text;
                }
                catch
                {
                    MessageBox.Show("Введите ценну в формате рубли,копейки");
                }
                RefreshWorks();
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
        }
    }
}
