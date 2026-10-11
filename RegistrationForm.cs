
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyApp
{
    public class Student
    {
        public string FullName = "";
        public string Phone = "";
        public string Department = "";
        public string Gender = "";
        public DateTime BirthDate;
        public int Age;
    }

    public class RegistrationForm : Form
    {
        private TextBox textBox1;
        private MaskedTextBox maskedTextBox1;
        private ComboBox comboBox1;
        private DateTimePicker dateTimePicker1;
        private NumericUpDown numericUpDown1;
        private CheckBox checkBox1;
        private CheckedListBox checkedListBox1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private ProgressBar progressBar1;
        private PictureBox pictureBox1;
        private RichTextBox richTextBox1;
        private ListView listView1;
        private TreeView treeView1;
        private Label resultLabel;
        private ToolTip toolTip1;
        private NotifyIcon notifyIcon1;

        public RegistrationForm()
        {
            Text = "Лаборатори №05 — Оюутны бүртгэл";
            Width = 850;
            Height = 850;
            StartPosition = FormStartPosition.CenterScreen;
            AutoScroll = true;

            toolTip1 = new ToolTip();

            var panel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Padding = new Padding(15)
            };
            Controls.Add(panel);

            // 1. Овог нэр
            panel.Controls.Add(new Label
            {
                Text = "Овог, нэр:",
                AutoSize = true
            });

            textBox1 = new TextBox
            {
                Name = "textBox1",
                Width = 280,
                MaxLength = 80,
                PlaceholderText = "Овог нэрээ бичнэ үү"
            };
            textBox1.TextChanged += Input_Changed;
            panel.Controls.Add(textBox1);

            // 2. Утас
            panel.Controls.Add(new Label
            {
                Text = "Утасны дугаар:",
                AutoSize = true
            });

            maskedTextBox1 = new MaskedTextBox
            {
                Name = "maskedTextBox1",
                Mask = "0000-0000",
                Width = 280
            };
            maskedTextBox1.TextChanged += Input_Changed;
            maskedTextBox1.MaskInputRejected +=
                maskedTextBox1_MaskInputRejected;
            panel.Controls.Add(maskedTextBox1);

            // 3. Тэнхим
            panel.Controls.Add(new Label
            {
                Text = "Тэнхим:",
                AutoSize = true
            });

            comboBox1 = new ComboBox
            {
                Name = "comboBox1",
                Width = 280,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            comboBox1.Items.AddRange(new object[]
            {
                "-- Тэнхим сонгох --",
                "Компьютерын ухаан",
                "Мэдээлэл зүй",
                "Математик",
                "Боловсрол судлал"
            });
            comboBox1.SelectedIndex = 0;
            comboBox1.SelectedIndexChanged += Input_Changed;
            panel.Controls.Add(comboBox1);

            // 4. Төрсөн огноо
            panel.Controls.Add(new Label
            {
                Text = "Төрсөн огноо:",
                AutoSize = true
            });

            dateTimePicker1 = new DateTimePicker
            {
                Name = "dateTimePicker1",
                Width = 280,
                Format = DateTimePickerFormat.Short,
                MaxDate = DateTime.Today,
                Value = new DateTime(2005, 1, 1)
            };
            dateTimePicker1.ValueChanged +=
                dateTimePicker1_ValueChanged;
            panel.Controls.Add(dateTimePicker1);

            // 5. Нас
            panel.Controls.Add(new Label
            {
                Text = "Нас:",
                AutoSize = true
            });

            numericUpDown1 = new NumericUpDown
            {
                Name = "numericUpDown1",
                Minimum = 0,
                Maximum = 120,
                Width = 100
            };
            panel.Controls.Add(numericUpDown1);

            // 6. Хүйс
            panel.Controls.Add(new Label
            {
                Text = "Хүйс:",
                AutoSize = true
            });

            radioButton1 = new RadioButton
            {
                Text = "Эмэгтэй",
                AutoSize = true,
                Checked = true
            };
            radioButton2 = new RadioButton
            {
                Text = "Эрэгтэй",
                AutoSize = true
            };
            panel.Controls.Add(radioButton1);
            panel.Controls.Add(radioButton2);

            // 7. Сонирхол
            panel.Controls.Add(new Label
            {
                Text = "Сонирхол:",
                AutoSize = true
            });

            checkedListBox1 = new CheckedListBox
            {
                Name = "checkedListBox1",
                Width = 280,
                Height = 75
            };
            checkedListBox1.Items.AddRange(new object[]
            {
                "Программчлал",
                "Компьютерын сүлжээ",
                "Өгөгдлийн сан",
                "Вэб хөгжүүлэлт"
            });
            checkedListBox1.ItemCheck +=
                checkedListBox1_ItemCheck;
            panel.Controls.Add(checkedListBox1);

            // 8. Зураг
            panel.Controls.Add(new Label
            {
                Text = "Оюутны зураг (зураг дээр дарж сонгоно):",
                AutoSize = true
            });

            pictureBox1 = new PictureBox
            {
                Name = "pictureBox1",
                Width = 120,
                Height = 100,
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = SystemIcons.Information.ToBitmap(),
                Cursor = Cursors.Hand
            };
            pictureBox1.Click += pictureBox1_Click;
            panel.Controls.Add(pictureBox1);

            // 9. Мэдээлэл бүртгэх товч
            var button1 = new Button
            {
                Name = "button1",
                Text = "Бүртгэх",
                Width = 160,
                Height = 35
            };
            button1.Click += button1_Click;
            panel.Controls.Add(button1);

            // 10. Мэдээлэл цэвэрлэх холбоос
            var linkLabel1 = new LinkLabel
            {
                Name = "linkLabel1",
                Text = "Талбаруудыг цэвэрлэх",
                AutoSize = true
            };
            linkLabel1.LinkClicked +=
                linkLabel1_LinkClicked;
            panel.Controls.Add(linkLabel1);

            // 11. Бүртгэлийн явц
            panel.Controls.Add(new Label
            {
                Text = "Мэдээлэл бөглөлт:",
                AutoSize = true
            });

            progressBar1 = new ProgressBar
            {
                Width = 280,
                Minimum = 0,
                Maximum = 100
            };
            panel.Controls.Add(progressBar1);

            // 12. Үр дүн
            resultLabel = new Label
            {
                Text = "Үр дүн энд харагдана",
                AutoSize = true,
                ForeColor = Color.Blue
            };
            panel.Controls.Add(resultLabel);

            // 13. Бүртгэсэн оюутнууд
            panel.Controls.Add(new Label
            {
                Text = "Бүртгэсэн оюутнууд:",
                AutoSize = true
            });

            listView1 = new ListView
            {
                Name = "listView1",
                Width = 720,
                Height = 100,
                View = View.Details,
                FullRowSelect = true,
                GridLines = true
            };
            listView1.Columns.Add("Овог нэр", 160);
            listView1.Columns.Add("Утас", 100);
            listView1.Columns.Add("Тэнхим", 170);
            listView1.Columns.Add("Нас", 60);
            listView1.Columns.Add("Хүйс", 100);
            listView1.SelectedIndexChanged +=
                listView1_SelectedIndexChanged;
            panel.Controls.Add(listView1);

            // 14. Сонгосон оюутны дэлгэрэнгүй
            richTextBox1 = new RichTextBox
            {
                Name = "richTextBox1",
                Width = 500,
                Height = 100,
                ReadOnly = true
            };
            panel.Controls.Add(richTextBox1);

            // 15. Тэнхимийн мод хэлбэрийн жагсаалт
            panel.Controls.Add(new Label
            {
                Text = "Тэнхим сонгох мод:",
                AutoSize = true
            });

            treeView1 = new TreeView
            {
                Name = "treeView1",
                Width = 280,
                Height = 100
            };

            TreeNode root = treeView1.Nodes.Add("МУБИС");
            root.Nodes.Add("Компьютерын ухаан");
            root.Nodes.Add("Мэдээлэл зүй");
            root.Nodes.Add("Математик");
            root.Nodes.Add("Боловсрол судлал");
            root.ExpandAll();

            treeView1.AfterSelect += treeView1_AfterSelect;
            panel.Controls.Add(treeView1);

            // 16. Системийн мэдэгдэл
            notifyIcon1 = new NotifyIcon
            {
                Icon = SystemIcons.Information,
                Text = "Оюутны бүртгэлийн программ",
                Visible = true
            };

            Load += Form1_Load;
            FormClosing += Form1_FormClosing;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void Form1_FormClosing(
            object sender, FormClosingEventArgs e)
        {
            notifyIcon1.Visible = false;
            notifyIcon1.Dispose();
            toolTip1.Dispose();
            pictureBox1.Image?.Dispose();
        }

        private void Input_Changed(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void checkedListBox1_ItemCheck(
            object sender, ItemCheckEventArgs e)
        {
            BeginInvoke(new Action(UpdateProgress));
        }

        private void dateTimePicker1_ValueChanged(
            object sender, EventArgs e)
        {
            int age = DateTime.Today.Year -
                      dateTimePicker1.Value.Year;

            if (dateTimePicker1.Value.Date >
                DateTime.Today.AddYears(-age))
            {
                age--;
            }

            numericUpDown1.Value = Math.Max(0, Math.Min(120, age));
            UpdateProgress();
        }

        private void maskedTextBox1_MaskInputRejected(
            object sender, MaskInputRejectedEventArgs e)
        {
            toolTip1.Show(
                "Утасны дугаарыг 8 оронтой оруулна уу.",
                maskedTextBox1,
                0,
                maskedTextBox1.Height,
                2000);
        }

        private void treeView1_AfterSelect(
            object sender, TreeViewEventArgs e)
        {
            int index = comboBox1.Items.IndexOf(e.Node.Text);

            if (index > 0)
            {
                comboBox1.SelectedIndex = index;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter =
                    "Зургийн файл|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    using (Image source = Image.FromFile(dialog.FileName))
                    {
                        pictureBox1.Image?.Dispose();
                        pictureBox1.Image = new Bitmap(source);
                    }

                    UpdateProgress();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                Warn("Овог нэрээ оруулна уу.");
                textBox1.Focus();
                return;
            }

            if (maskedTextBox1.MaskCompleted == false)
            {
                Warn("Утасны дугаараа бүрэн оруулна уу.");
                maskedTextBox1.Focus();
                return;
            }

            if (comboBox1.SelectedIndex <= 0)
            {
                Warn("Тэнхимээ сонгоно уу.");
                comboBox1.Focus();
                return;
            }

            var student = new Student
            {
                FullName = textBox1.Text.Trim(),
                Phone = maskedTextBox1.Text,
                Department = comboBox1.Text,
                Gender = radioButton1.Checked
                    ? "Эмэгтэй" : "Эрэгтэй",
                BirthDate = dateTimePicker1.Value,
                Age = (int)numericUpDown1.Value
            };

            var item = new ListViewItem(student.FullName);
            item.SubItems.Add(student.Phone);
            item.SubItems.Add(student.Department);
            item.SubItems.Add(student.Age.ToString());
            item.SubItems.Add(student.Gender);
            item.Tag = student;

            listView1.Items.Add(item);
            ShowInRichText(student);

            resultLabel.Text = "Бүртгэл амжилттай!";
            notifyIcon1.BalloonTipTitle = "Бүртгэл";
            notifyIcon1.BalloonTipText =
                student.FullName + " амжилттай бүртгэгдлээ.";
            notifyIcon1.ShowBalloonTip(2000);

            MessageBox.Show(
                "Оюутны мэдээлэл амжилттай бүртгэгдлээ!",
                "Амжилт",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void listView1_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1 &&
                listView1.SelectedItems[0].Tag is Student student)
            {
                ShowInRichText(student);
            }
        }

        private void linkLabel1_LinkClicked(
            object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBox1.Clear();
            maskedTextBox1.Clear();
            comboBox1.SelectedIndex = 0;
            dateTimePicker1.Value = new DateTime(2005, 1, 1);
            radioButton1.Checked = true;

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }

            resultLabel.Text = "Талбаруудыг цэвэрлэлээ.";
            UpdateProgress();
        }

        private void ShowInRichText(Student student)
        {
            richTextBox1.Text =
                "Овог нэр: " + student.FullName + Environment.NewLine +
                "Утас: " + student.Phone + Environment.NewLine +
                "Тэнхим: " + student.Department + Environment.NewLine +
                "Төрсөн огноо: " +
                    student.BirthDate.ToShortDateString() + Environment.NewLine +
                "Нас: " + student.Age + Environment.NewLine +
                "Хүйс: " + student.Gender;
        }

        private void UpdateProgress()
        {
            int total = 5;
            int completed = 0;

            if (!string.IsNullOrWhiteSpace(textBox1.Text))
                completed++;

            if (maskedTextBox1.MaskCompleted)
                completed++;

            if (comboBox1.SelectedIndex > 0)
                completed++;

            if (checkedListBox1.CheckedItems.Count > 0)
                completed++;

            if (pictureBox1.Image != null)
                completed++;

            progressBar1.Value = completed * 100 / total;
        }

        private void Warn(string message)
        {
            MessageBox.Show(
                message,
                "Мэдээлэл дутуу",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
    }
}
