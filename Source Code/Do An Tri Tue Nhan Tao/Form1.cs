using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Do_An_Tri_Tue_Nhan_Tao
{
    public partial class Form1 : Form
    {
        String Problem = "Tam giác ABC có : ";
        String Request = "Tính ";
        Process pc;
        public Form1()
        {
            InitializeComponent();           
        }
        String src="";
        String dest="";
        public String setSource(String s)
        {
            String des;
            if (s == "ha")
                des = "x";
            else if (s == "hb")
                des = "y";
            else if (s == "hc")
                des = "z";
            else
                des = s;
            return des;
        }
        public void Processing()
        {
            pc = new Process(src, dest);
            pc.Computing(txt_a.Text, txt_b.Text, txt_c.Text, txtA.Text, txtB.Text, txtC.Text, txtha.Text, txthb.Text, txthc.Text);
            String kq = pc.getResult();
            if (kq != "")
            {
                lbKL.Text = "Giải được!";
                lbLG.Text += kq + "\n -----------------------\n";
            }
            else
            {
                lbKL.Text = "Không giải được!";
                lbLG.Text += "Không thể giải" + "\n-----------------------\n";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bool k = false;
            if (canh_a.Checked == true)
            {
                src = src + "a";
                txt_a.Enabled = true;
                if (txt_a.Text == "")
                    k = true;
            }
            if (canh_b.Checked == true)
            {
                src = src + "b";
                txt_b.Enabled = true;
                if (txt_b.Text == "")
                    k = true;
            }
            if (canh_c.Checked == true)
            {
                src = src + "c";
                txt_c.Enabled = true;
                if (txt_c.Text == "")
                    k = true;
            }
            if (goc_A.Checked == true)
            {
                src = src + "A";
                txtA.Enabled = true;
                if (txtA.Text == "")
                    k = true;
            }
            if (goc_B.Checked == true)
            {
                src = src + "B";
                txtB.Enabled = true;
                if (txtB.Text == "")
                    k = true;
            }
            if (goc_C.Checked == true)
            {
                src = src + "C";
                txtC.Enabled = true;
                if (txtC.Text == "")
                    k = true;
            }
            if (dc_a.Checked == true)
            {
                src = src + "x";
                txtha.Enabled = true;
                if (txtha.Text == "")
                    k = true;
            }
            if (dc_b.Checked == true)
            {
                src = src + "y";
                txthb.Enabled = true;
                if (txthb.Text == "")
                    k = true;
            }
            if (dc_c.Checked == true)
            {
                src = src + "z";
                txthc.Enabled = true;
                if (txthc.Text == "")
                    k = true;
            }
            dest = setSource(txtKL.Text);
            if (dest == "" || src == "" || k==true)
                MessageBox.Show("Chưa nhập đủ dữ kiện");
            else
                if (txtKL.Text != "a" && txtKL.Text != "b" && txtKL.Text != "c" && txtKL.Text != "A" && txtKL.Text != "B" && txtKL.Text != "C" && txtKL.Text != "ha" && txtKL.Text != "hb" && txtKL.Text != "hc" && txtKL.Text != "p" && txtKL.Text != "S" && txtKL.Text != "R" && txtKL.Text != "r")
                    MessageBox.Show("Nhập không đúng cú pháp");
                else
                {
                    if (canh_a.Checked == true)
                        Problem += "a=" + txt_a.Text +",";
                    if (canh_b.Checked == true)
                        Problem += "b=" + txt_b.Text + ",";
                    if (canh_c.Checked == true)
                        Problem += "c=" + txt_c.Text + ",";
                    if (goc_A.Checked == true)
                        Problem += "A=" + txtA.Text + ",";
                    if (goc_B.Checked == true)
                        Problem += "B=" + txtB.Text + ",";
                    if (goc_C.Checked == true)
                        Problem += "C=" + txtC.Text + ",";
                    if (dc_a.Checked == true)
                        Problem += "ha=" + txtha.Text + ",";
                    if (dc_b.Checked == true)
                        Problem += "hb=" + txthb.Text + ",";
                    if (dc_c.Checked == true)
                        Problem += "hc=" + txthc.Text + ",";
                    Problem.Remove(Problem.Length-2);
                    Request += txtKL.Text + "?";
                    lbDB.Text = Problem + "\n" + Request;

                    Processing();            
                }          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            canh_a.Checked = false;
            canh_b.Checked = false;
            canh_c.Checked = false;
            goc_A.Checked = false;
            goc_B.Checked = false;
            goc_C.Checked = false;
            dc_a.Checked = false;
            dc_b.Checked = false;
            dc_c.Checked = false;
            lbKL.Text = "";
            lbLG.Text = "";
            txtKL.Text = "";
            src = "";
            dest = "";
            txt_a.Text = "";
            txt_b.Text = "";           
            txt_c.Text = "";
            txtA.Text = "";
            txtB.Text = "";
            txtC.Text = "";
            txtha.Text = "";
            txthb.Text = "";
            txthc.Text = "";
            lbDB.Text = "";
            Problem = "";
            Request = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
        }

        private void goc_A_CheckedChanged(object sender, EventArgs e)
        {
            if (goc_A.Checked == true)
            {
                txtA.Enabled = true;
                txtA.Focus();
            }
            else
                txtA.Enabled = false;
        }
        private void goc_B_CheckedChanged(object sender, EventArgs e)
        {
            if (goc_B.Checked == true)
            {
                txtB.Enabled = true;
                txtB.Focus();
            }
            else
                txtB.Enabled = false;
        }
        private void goc_C_CheckedChanged(object sender, EventArgs e)
        {
            if (goc_C.Checked == true)
            {
                txtC.Enabled = true;
                txtC.Focus();
            }
            else
                txtC.Enabled = false;
        }

        private void canh_a_CheckedChanged(object sender, EventArgs e)
        {
            if (canh_a.Checked == true)
            {
                txt_a.Enabled = true;
                txt_a.Focus();
            }
            else
                txt_a.Enabled = false;
        }
        private void canh_b_CheckedChanged(object sender, EventArgs e)
        {
            if (canh_b.Checked == true)
            {
                txt_b.Enabled = true;
                txt_b.Focus();
            }
            else
                txt_b.Enabled = false;
        }
        private void canh_c_CheckedChanged(object sender, EventArgs e)
        {
            if (canh_c.Checked == true)
            {
                txt_c.Enabled = true;
                txt_c.Focus();
            }
            else
                txt_c.Enabled = false;
        }

        private void dc_c_CheckedChanged(object sender, EventArgs e)
        {
            if (dc_c.Checked == true)
            {
                txthc.Enabled = true;
                txthc.Focus();
            }
            else
                txthc.Enabled = false;
        }
        private void dc_b_CheckedChanged(object sender, EventArgs e)
        {
            if (dc_b.Checked == true)
            {
                txthb.Enabled = true;
                txthb.Focus();
            }
            else
                txthb.Enabled = false;
        }
        private void dc_a_CheckedChanged(object sender, EventArgs e)
        {
            if (dc_a.Checked == true)
            {
                txtha.Enabled = true;
                txtha.Focus();
            }
            else
                txtha.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String text = "";
            text += "CHƯƠNG TRÌNH GIẢI BÀI TOÁN TAM GIÁC \n";
            text += "-------------------------------------------\n";
            text += "Giảng viên hướng dẫn: \n";
            text += "\tTS. Lê Quyết Thắng \n";
            text += "Thực hiện: \n";
            text = text + "\tTrần Linh Nga Phương" + "\t" + "B1411347" + "\n";
            text = text + "\tLớp: CT311" + "\n\n";
            text = text + "Trường Đại học Cần Thơ";
            MessageBox.Show(text, "Thông tin chương trình");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            src = "";
            dest = "";
            txtKL.Text = "";
        }
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(this.button1, "Giải bài toán");
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(this.button3, "Xóa lời giải hiện tại");
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(this.button2, "Bài toán tiếp theo");
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(this.button5, "Thông tin chương trình");
        }

        private void txtKL_MouseEnter(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(this.txtKL, "Yếu tố cần tìm của tam giác");
        }   
        private void panel1_MouseHover(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(this.panel1, "Khu vực hiện Lời giải bài toán");
        }

        private void panel2_MouseHover(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(this.panel2, "Khu vực nhập giả thiết bài toán");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true)
            {
                goc_A.Checked = true;
                txtA.Enabled = true;
                txtA.Text = "90";
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
            }
            else
            {
                goc_A.Checked = false;
                txtA.Enabled = false;
                txtA.Text = "";
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                goc_B.Checked = true;
                txtB.Enabled = true;
                txtB.Text = "90";
                checkBox1.Enabled = false;
                checkBox3.Enabled = false;
            }
            else
            {
                goc_B.Checked = false;
                txtB.Enabled = false;
                txtB.Text = "";
                checkBox1.Enabled = true;
                checkBox3.Enabled = true;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                goc_C.Checked = true;
                txtC.Enabled = true;
                txtC.Text = "90";
                checkBox2.Enabled = false;
                checkBox1.Enabled = false;
            }
            else
            {
                goc_C.Checked = false;
                txtC.Enabled = false;
                txtC.Text = "";
                checkBox2.Enabled = true;
                checkBox1.Enabled = true;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox4.Checked==true)
            {
                goc_A.Checked = true;
                goc_B.Checked = true;
                goc_C.Checked = true;
                txtA.Enabled = true;
                txtB.Enabled = true;
                txtC.Enabled = true;
                txtA.Text = "60";
                txtB.Text = "60";
                txtC.Text = "60";
            }
            else
            {
                goc_A.Checked = false;
                goc_B.Checked = false;
                goc_C.Checked = false;
                txtA.Enabled = false;
                txtB.Enabled = false;
                txtC.Enabled = false;
                txtA.Text = "";
                txtB.Text = "";
                txtC.Text = "";
            }
        }

        
    }
}
