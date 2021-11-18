using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            f_num = 0;
            
        }
        double f_num, s_num;
        bool sec_num = false, last_sign = false, point_s=false;
        char sign;
        int ind_sign = 0, dif_to_point = 0;

        private void sqrt_x_Click(object sender, EventArgs e)
        {
            Calc_multiply cm = new Calc_multiply();
            txt_input.Text = cm.calculate(f_num, f_num).ToString();
            f_num = double.Parse(txt_input.Text);
            this.ActiveControl = txt_input;
            txt_input.SelectionStart = txt_input.Text.Length;
        }

        private void btn1divx_Click(object sender, EventArgs e)
        {
            Calc_divide cd = new Calc_divide();
            txt_input.Text = cd.calculate(1, f_num).ToString();
            f_num = double.Parse(txt_input.Text);
            this.ActiveControl = txt_input;
            txt_input.SelectionStart = txt_input.Text.Length;
        }
        /// //////////////////////////////signs //////////////////////////////////////////////////
        private void btn_plus_Click(object sender, EventArgs e)
        {
            input_symbol(sender, '+');
            point_s = false;
            ind_sign = txt_input.Text.Length-1;
        }

        private void btn_mns_Click(object sender, EventArgs e)
        {
            input_symbol(sender, '-');
            point_s = false;
            ind_sign = txt_input.Text.Length - 1;
        }

        private void btn_mul_Click(object sender, EventArgs e)
        {
            input_symbol(sender, '*');
            point_s = false;
            ind_sign = txt_input.Text.Length - 1;
        }

        private void btn_div_Click(object sender, EventArgs e)
        {
            input_symbol(sender, '/');
            point_s = false;
            ind_sign = txt_input.Text.Length - 1;
        }

        private void btn_equal_Click(object sender, EventArgs e)
        {
            input_symbol(sender, '=');
        }
        private void btn_dot_Click(object sender, EventArgs e)
        {
            input_symbol(sender, '.');
        }
        /// ////////////////////////////////////////   signs END //////////////////////////////////////////////////

        /// /////////////////////////////////////////  INPUT NUM  /////////////////////////////////////////////////////////////////////////

        private void btn_1_Click(object sender, EventArgs e)
        {
            input_symbol(sender, '1');
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            input_symbol(sender, '2');
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            input_symbol(sender, '3');
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            input_symbol(sender, '4');
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            input_symbol(sender, '5');
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            input_symbol(sender, '6');
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            input_symbol(sender, '7');
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            input_symbol(sender, '8');
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            input_symbol(sender, '9');
        }

        private void btn_0_Click(object sender, EventArgs e)
        {
            input_symbol(sender, '0');
        }
        /// ///////////////////////////////////////// END INPUT NUM  /////////////////////////////////////////////////////////////////////////

        private void backsp_Click(object sender, EventArgs e)
        {
            if (txt_input.Text.Length > 1)
            {
                if (!sec_num)
                {
                    txt_input.Text = txt_input.Text.Substring(0, txt_input.Text.Length - 1);
                    f_num = double.Parse(txt_input.Text);
                }
                else
                {
                    s_num = double.Parse(txt_input.Text.Substring(ind_sign + 1, txt_input.Text.Length - 3));
                    txt_input.Text = txt_input.Text.Substring(0, txt_input.Text.Length - 1);

                }
            }
            else
            {
                txt_input.Text = "0";
                f_num = 0;
            }
            this.ActiveControl = txt_input;
            txt_input.SelectionStart = txt_input.Text.Length;
        }

        private void change_sign_Click(object sender, EventArgs e)
        {
            txt_input.Text = (double.Parse(txt_input.Text) * -1).ToString();
            f_num = double.Parse(txt_input.Text);
            this.ActiveControl = txt_input;
            txt_input.SelectionStart = txt_input.Text.Length;
        }
        private void txt_input_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '+' || e.KeyChar == '-' || e.KeyChar == '*' || e.KeyChar == '/')
            {

                if (txt_input.Text.Length == 0)
                {
                    f_num = 0;
                    txt_input.Text = "0";
                }
                if (last_sign)
                {
                    txt_input.Text = txt_input.Text.Substring(0, txt_input.Text.Length - 1);
                }
                sign = e.KeyChar;
                txt_input.Text += sign;
                ind_sign = txt_input.Text.Length - 1;

                sec_num = true;
                last_sign = true;
                point_s = false;
            }
            else if ((char.IsDigit(e.KeyChar) || e.KeyChar == '.'))
            {
                last_sign = false;
                if (e.KeyChar != '.')
                {
                    if (sec_num && !point_s)
                        s_num = s_num * 10 + double.Parse(e.KeyChar.ToString());
                    else if (!sec_num && !point_s)
                        f_num = f_num * 10 + double.Parse(e.KeyChar.ToString());
                    else if (!sec_num && point_s)
                        f_num = f_num + (double.Parse(e.KeyChar.ToString()) / Math.Pow(10, txt_input.Text.Length - dif_to_point) );
                    else
                        s_num = s_num + (double.Parse(e.KeyChar.ToString()) / Math.Pow(10, txt_input.Text.Length - dif_to_point) );
                    if (s_num == 0 && e.KeyChar != '0')
                        txt_input.Text = f_num.ToString();
                    //if (f_num.ToString().Length == 1 && s_num == 0)
                    //    txt_input.Text = e.KeyChar.ToString();
                    else if (s_num.ToString().Length > 0)
                        txt_input.Text += e.KeyChar;


                }
                else
                {
                    txt_input.Text += e.KeyChar;
                    point_s = true;
                    dif_to_point = txt_input.Text.Length - 1;
                }
            }
            else if (e.KeyChar == '=' || e.KeyChar == 13)
            {
                if (sign == '+')
                {
                    Calc_add ca = new Calc_add();
                    txt_input.Text = ca.calculate(f_num, s_num).ToString();
                }
                if (sign == '-')
                {
                    Calc_substraction cs = new Calc_substraction();
                    txt_input.Text = cs.calculate(f_num, s_num).ToString();
                }
                if (sign == '*')
                {
                    Calc_multiply cm = new Calc_multiply();
                    txt_input.Text = cm.calculate(f_num, s_num).ToString();
                }
                if (sign == '/')
                {
                    Calc_divide cd = new Calc_divide();
                    txt_input.Text = cd.calculate(f_num, s_num).ToString();
                }
                f_num = double.Parse(txt_input.Text);
                s_num = 0;
                last_sign = false;
                sec_num = false;
            }
            e.Handled = true;
        }
        private void input_symbol(object sender, char sym)
        {
            KeyPressEventArgs tmp = new KeyPressEventArgs(sym);
            txt_input_KeyPress(sender, tmp);
            this.ActiveControl = txt_input;
            txt_input.SelectionStart = txt_input.Text.Length;
            point_s = false;
        }
    }
}
