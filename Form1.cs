
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Text = "Миний Calculator";
            Width = 350;
            Height = 350;
            StartPosition = FormStartPosition.CenterScreen;

            Label label1 = new Label();
            label1.Text = "Эхний тоо:";
            label1.SetBounds(20, 25, 100, 25);

            TextBox number1 = new TextBox();
            number1.SetBounds(130, 20, 150, 25);

            Label label2 = new Label();
            label2.Text = "Хоёр дахь тоо:";
            label2.SetBounds(20, 65, 100, 25);

            TextBox number2 = new TextBox();
            number2.SetBounds(130, 60, 150, 25);

            Label result = new Label();
            result.Text = "Үр дүн:";
            result.SetBounds(20, 250, 300, 30);
            result.Font = new Font("Arial", 12, FontStyle.Bold);

            Button add = new Button();
            add.Text = "+ Нэмэх";
            add.SetBounds(20, 110, 135, 40);

            Button subtract = new Button();
            subtract.Text = "- Хасах";
            subtract.SetBounds(165, 110, 135, 40);

            Button multiply = new Button();
            multiply.Text = "× Үржүүлэх";
            multiply.SetBounds(20, 160, 135, 40);

            Button divide = new Button();
            divide.Text = "÷ Хуваах";
            divide.SetBounds(165, 160, 135, 40);

            void Calculate(char operation)
            {
                if (!double.TryParse(number1.Text, out double a) ||
                    !double.TryParse(number2.Text, out double b))
                {
                    MessageBox.Show("Хоёр тоогоо зөв оруулна уу!");
                    return;
                }

                double answer;

                switch (operation)
                {
                    case '+':
                        answer = a + b;
                        break;
                    case '-':
                        answer = a - b;
                        break;
                    case '*':
                        answer = a * b;
                        break;
                    case '/':
                        if (b == 0)
                        {
                            MessageBox.Show("Тэгээр хувааж болохгүй!");
                            return;
                        }
                        answer = a / b;
                        break;
                    default:
                        return;
                }

                result.Text = "Үр дүн: " + answer;
            }

            add.Click += (s, e) => Calculate('+');
            subtract.Click += (s, e) => Calculate('-');
            multiply.Click += (s, e) => Calculate('*');
            divide.Click += (s, e) => Calculate('/');

            Controls.AddRange(new Control[]
            {
                label1, number1,
                label2, number2,
                add, subtract, multiply, divide,
                result
            });
        }
    }
}
