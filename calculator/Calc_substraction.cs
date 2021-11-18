using System;
using System.Collections.Generic;
using System.Text;

namespace calculator
{
    class Calc_substraction : Calculate
    {
        public override double calculate(double f_num, double s_num)
        {
            return f_num - s_num;
        }
    }
}
