using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bt4windowform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<monhoc> list = new List<monhoc>();
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát  ??", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text=="Tin học đại cương")
            {
                textBox1.Text = "2";
            }
            if (comboBox1.Text == "Giải tích F1")
            {
                textBox1.Text = "3";
            }
            if (comboBox1.Text == "Tiếng anh A0")
            {
                textBox1.Text = "3";
            }
            if (comboBox1.Text == "Triết học Mac-Lenin")
            {
                textBox1.Text = "2";
            }
            if (comboBox1.Text == "Vật lý F1")
            {
                textBox1.Text = "3";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "")
            {
                MessageBox.Show("Hãy chọn một môn học ","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Error);
            }
            else if(textBox2.Text==""){
                MessageBox.Show("Hãy nhập điểm", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            }
            else {
                listBox1.Items.Add(comboBox1.Text+"  , Số tín: "+textBox1.Text +"  , Điểm: "+textBox2.Text);
                    list.Add(new monhoc() { tenmonhoc = comboBox1.Text, sotin = int.Parse(textBox1.Text), diem = double.Parse(textBox2.Text) });
               }
        }
         class monhoc
        {
            public string tenmonhoc { get; set; }
            public int sotin { get; set; }
            public double diem { get; set; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int tongsotin = 0;
            double tongmonhoc = 0;
            foreach(monhoc item in list)
            {
                tongsotin += item.sotin;
                tongmonhoc += item.diem*item.sotin;
            }
            double diemtrungbinh = (tongmonhoc / list.Count);
            textBox3.Text = tongsotin.ToString();
            textBox4.Text = tongmonhoc.ToString();
            textBox5.Text = diemtrungbinh.ToString();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Alt && e.KeyCode == Keys.H)
            {
                button3.PerformClick();
            }
            if (e.Alt && e.KeyCode == Keys.D)
            {
                button1.PerformClick();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) ||e.KeyChar=='.')
            {
                e.Handled = false;
            }else
            {
                e.Handled = true;
            }
        }
    }
}
