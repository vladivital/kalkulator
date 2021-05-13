using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace kalkulator
{
    public partial class Calculator : Form
    {
        double result = 0;
        string temp = "";
        double memory = 0;
        List<Tuple<double, string>> uravnenie = new List<Tuple<double, string>>();

        public Calculator()
        {
            InitializeComponent();
        }

        private void b1_Click(object sender, EventArgs e)
        {
            if (tb1.Text == "0" && tb1.Text != null)
            {
                tb1.Text = "1";
            }
            else
            {
                tb1.Text = tb1.Text + "1";
            }
            temp = temp + "1";
        }

        private void b2_Click(object sender, EventArgs e)
        {
            if (tb1.Text == "0" && tb1.Text != null)
            {
                tb1.Text = "2";
            }
            else
            {
                tb1.Text = tb1.Text + "2";
            }
            temp = temp + "2";


        }

        private void b3_Click(object sender, EventArgs e)
        {
            if (tb1.Text == "0" && tb1.Text != null)
            {
                tb1.Text = "3";
            }
            else
            {
                tb1.Text = tb1.Text + "3";
            }
            temp = temp + "3";


        }

        private void b4_Click(object sender, EventArgs e)
        {
            if (tb1.Text == "0" && tb1.Text != null)
            {
                tb1.Text = "4";
            }
            else
            {
                tb1.Text = tb1.Text + "4";
            }
            temp = temp + "4";


        }

        private void b5_Click(object sender, EventArgs e)
        {
            if (tb1.Text == "0" && tb1.Text != null)
            {
                tb1.Text = "5";
            }
            else
            {
                tb1.Text = tb1.Text + "5";
            }
            temp = temp + "5";


        }

        private void b6_Click(object sender, EventArgs e)
        {
            if (tb1.Text == "0" && tb1.Text != null)
            {
                tb1.Text = "6";
            }
            else
            {
                tb1.Text = tb1.Text + "6";
            }
            temp = temp + "6";


        }

        private void b7_Click(object sender, EventArgs e)
        {
            if (tb1.Text == "0" && tb1.Text != null)
            {
                tb1.Text = "7";
            }
            else
            {
                tb1.Text = tb1.Text + "7";
            }
            temp = temp + "7";

        }

        private void b8_Click(object sender, EventArgs e)
        {
            if (tb1.Text == "0" && tb1.Text != null)
            {
                tb1.Text = "8";
            }
            else
            {
                tb1.Text = tb1.Text + "8";
            }
            temp = temp + "8";
        }

        private void b9_Click(object sender, EventArgs e)
        {
            if (tb1.Text == "0" && tb1.Text != null)
            {
                tb1.Text = "9";
            }
            else
            {
                tb1.Text = tb1.Text + "9";
            }
            temp = temp + "9";
        }

        private void b0_Click(object sender, EventArgs e)
        {
            tb1.Text = tb1.Text + "0";
            temp = temp + "0";
        }

        private void sum_Click(object sender, EventArgs e)
        {
            uravnenie.Add(new Tuple<double, string>(Convert.ToDouble(temp), "+"));
            temp = "";
            tb1.Text += " + ";
        }

        private void sub_Click(object sender, EventArgs e)
        {
            uravnenie.Add(new Tuple<double, string>(Convert.ToDouble(temp), "-"));
            temp = "";
            tb1.Text += " - ";
        }

        private void mult_Click(object sender, EventArgs e)
        {
            uravnenie.Add(new Tuple<double, string>(Convert.ToDouble(temp), "*"));
            temp = "";
            tb1.Text += " * ";
        }

        private void div_Click(object sender, EventArgs e)
        {
            uravnenie.Add(new Tuple<double, string>(Convert.ToDouble(temp), "/"));
            temp = "";
            tb1.Text += " / ";
        }

        private void clear_Click(object sender, EventArgs e)
        {
            tb1.Clear();
            result = 0;
            temp = "";
            uravnenie = new List<Tuple<double, string>>();
        }

        private void sqrt_Click(object sender, EventArgs e)
        {
            uravnenie.Add(new Tuple<double, string>(Convert.ToDouble(temp), "√"));
            SmetniUravnenie();
            temp = "";
            tb1.Text = result.ToString();
        }

        private void b11_Click(object sender, EventArgs e)
        {
            if (temp.Contains("."))
            {

            }
            else
            {
                tb1.Text = tb1.Text + ".";
                temp = temp + ".";
            }
        }

        private void ravno_Click(object sender, EventArgs e)
        {
            uravnenie.Add(new Tuple<double, string>(Convert.ToDouble(temp), "="));
            SmetniUravnenie();
            tb1.Text = result.ToString();
            result = 0;
        }

        private void SmetniUravnenie()
        {
            var lastOperator = "";
            for (int i = 0; i < uravnenie.Count; i++)
            {
                var item = uravnenie.ElementAt(i);
                var chislo1 = item.Item1;
                var operator1 = item.Item2;

                if (i == 0)
                {
                    result = chislo1;
                    lastOperator = operator1;
                    if (operator1 == "√")
                    {
                        result = Calculate(result, chislo1, operator1);
                    }
                    continue;
                }
                if (operator1 == "=")
                {
                    result = Calculate(result, chislo1, lastOperator);
                }
                else
                {
                    result = Calculate(result, chislo1, lastOperator);
                }
                if (operator1 == "√")
                {
                    result = Calculate(result, chislo1, operator1);
                }

                lastOperator = operator1;
            }
        }

        private double Calculate(double rezultat, double chislo2, string operator1)
        {
            if (operator1 == "+")
            {
                return rezultat + chislo2;
            }
            if (operator1 == "-")
            {
                return rezultat - chislo2;
            }
            if (operator1 == "/")
            {
                return rezultat / chislo2;
            }
            if (operator1 == "*")
            {
                return rezultat * chislo2;
            }
            if (operator1 == "√")
            {
                return Math.Sqrt(rezultat);
            }

            return rezultat;
        }

        private void mc_Click(object sender, EventArgs e)
        {
            memory = 0;
        }

        private void mp_Click(object sender, EventArgs e)
        {
            uravnenie.Add(new Tuple<double, string>(Convert.ToDouble(temp), "="));
            SmetniUravnenie();
            memory += result;
        }

        private void md_Click(object sender, EventArgs e)
        {
            uravnenie.Add(new Tuple<double, string>(Convert.ToDouble(temp), "="));
            SmetniUravnenie();
            memory -= result;
        }

        private void mr_Click(object sender, EventArgs e)
        {
            tb1.Text = memory.ToString();
            uravnenie = new List<Tuple<double, string>>();
            temp = tb1.Text;
        }
    }
}
