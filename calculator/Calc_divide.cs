using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace calculator
{
    class Calc_divide : Calculate
    {
        public override double calculate(double f_num, double s_num)
        {
            try
            {
                if (s_num == 0)
                {
                    throw new Exception("err");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 0;
            }
            return f_num/s_num;
        }
    }
}
