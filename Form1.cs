
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

            Text = "Хоёр тооны нийлбэр";
            Width = 350;
            Height = 300;

            Label label1 = new Label();
            label1.Text = "Эхний тоо:";
            label1.Left = 20;
            label1.Top = 25;
            label1.Width = 100;

            TextBox number1 = new TextBox();
            number1.Left = 130;
            number1.Top = 20;
            number1.Width = 150;

            Label label2 = new Label();
            label2.Text = "Хоёр дахь тоо:";
            label2.Left = 20;
            label2.Top = 70;
            label2.Width = 100;

            TextBox number2 = new TextBox();
            number2.Left = 130;
            number2.Top = 65;
            number2.Width = 150;

            Button button = new Button();
            button.Text = "Нэмэх";
            button.Left = 130;
            button.Top = 110;
            button.Width = 100;

            Label result = new Label();
            result.Text = "Үр дүн:";
            result.Left = 20;
            result.Top = 170;
            result.Width = 280;
            result.Height = 30;

            button.Click += (sender, e) =>
            {
                if (int.TryParse(number1.Text, out int a) &&
                    int.TryParse(number2.Text, out int b))
                {
                    result.Text = "Нийлбэр: " + (a + b);
                }
                else
                {
                    MessageBox.Show("Хоёр тоогоо зөв оруулна уу!");
                }
            };

            Controls.Add(label1);
            Controls.Add(number1);
            Controls.Add(label2);
            Controls.Add(number2);
            Controls.Add(button);
            Controls.Add(result);
        }
    }
}
