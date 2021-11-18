using System;
using System.Collections.Generic;
using System.Text;

namespace calculator
{
    class Calc_add : Calculate
    {
        public override double calculate(double f_num, double s_num)
        {
            return f_num + s_num;
        }
    }
}
