using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace calculator
{
    class Calc_multiply : Calculate
    {
        public override double calculate(double f_num, double s_num)
        {
            double tmp_res = 0;
            try
            {
                tmp_res = f_num * s_num;
            }
            catch
            {
                MessageBox.Show("big data");
            }
            return tmp_res;
        }
    }
}
