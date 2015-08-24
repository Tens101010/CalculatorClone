//Please note: This application is purely for my own education, to run through coding 
//examples by following tutorials, and to just tinker around with coding.  
//I know it’s bad practice to heavily comment code (code smell), but comments in all of my 
//exercises will largely be left intact as this serves me 2 purposes:
//    I want to retain what my original thought process was at the time
//    I want to be able to look back in 1..5..10 years to see how far I’ve come
//    And I enjoy commenting on things, however redundant this may be . . . 


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsCalculator
{
    public partial class Form1 : Form
    {
        //declaring some variables. Double for decimals.  String for storing text
        double value = 0;
        string operation = "";
        bool operationPressed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            // Once a button is clicked, if the screen displays "0" or an operator was pressed, will reset string (new line)
            if ((result.Text == "0") || (operationPressed))
            {
                result.Clear();
            }
            operationPressed = false;
            Button b = (Button)sender;
            // Handles the decimal. Limits only one decimal in numerical string.
            if (b.Text == ".")
            {
                if (!result.Text.Contains("."))
                    result.Text = result.Text + b.Text;
            }
            else
                result.Text = result.Text + b.Text;

            label1.Focus();
        }

        private void clearEntry_Click(object sender, EventArgs e)
        {
            result.Text = "0";
            label1.Focus();
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (value != 0)
            {
                if (b.Text == "Sqrt")
                    result.Text = Math.Sqrt(Double.Parse(result.Text)).ToString();
                equals.PerformClick();
                operationPressed = true;
                operation = b.Text;
                equation.Text = value + " " + operation;
            }
            else if (b.Text == "Sqrt")
            {
                result.Text = Math.Sqrt(Double.Parse(result.Text)).ToString();
                value = Math.Sqrt(Double.Parse(result.Text));
            }
            else
            {
                operation = b.Text;
                value = Double.Parse(result.Text);
                operationPressed = true;
                equation.Text = value + " " + operation;
            }
            label1.Focus();
        }

        private void equals_Click(object sender, EventArgs e)
        {
            equation.Text = "";
            switch (operation)
            {
                case "+":
                    // result will equal (variable now stored in "value") +-/* (whatever is currently stored onscreen)
                    result.Text = (value + Double.Parse(result.Text)).ToString();
                    break;
                case "-":
                    result.Text = (value - Double.Parse(result.Text)).ToString();
                    break;
                case "*":
                    result.Text = (value * Double.Parse(result.Text)).ToString();
                    break;
                case "/":
                    result.Text = (value / Double.Parse(result.Text)).ToString();
                    break;
                default:
                    break;
            } // End switch

            value = Int32.Parse(result.Text);
            operation = "";
            label1.Focus();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            result.Text = "0";
            value = 0;
            equation.Text = "";
            label1.Focus();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar.ToString())
            {
                case "0":
                    zero.PerformClick();
                    break;
                case "1":
                    one.PerformClick();
                    break;
                case "2":
                    two.PerformClick();
                    break;
                case "3":
                    three.PerformClick();
                    break;
                case "4":
                    four.PerformClick();
                    break;
                case "5":
                    five.PerformClick();
                    break;
                case "6":
                    six.PerformClick();
                    break;
                case "7":
                    seven.PerformClick();
                    break;
                case "8":
                    eight.PerformClick();
                    break;
                case "9":
                    nine.PerformClick();
                    break;
                case "+":
                    plus.PerformClick();
                    break;
                case "-":
                    minus.PerformClick();
                    break;
                case "*":
                    multiply.PerformClick();
                    break;
                case "/":
                    division.PerformClick();
                    break;
                case "=":
                    equals.PerformClick();
                    break;
                case " ":
                    equals.PerformClick();
                    break;
                case "\r":
                    equals.PerformClick();
                    break;
                default:
                    break;
            } // End switch
        }
    }
}
