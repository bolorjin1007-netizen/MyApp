
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyApp
{
    public partial class Form1 : Form
    {
        TextBox nameBox;
        CheckBox agreeBox;
        ComboBox cityBox;
        DateTimePicker datePicker;
        Label resultLabel;
        ListBox listBox;
        CheckedListBox checkedList;
        RadioButton studentRadio;
        RadioButton teacherRadio;
        NumericUpDown numberBox;
        TrackBar slider;
        ProgressBar progress;
        RichTextBox noteBox;
        MaskedTextBox phoneBox;
        TreeView tree;
        ListView listView;
        PictureBox picture;
        ToolTip tip;
        NotifyIcon trayIcon;

        public Form1()
        {
            // Designer-ийн хуучин контролуудыг ачаалахгүй.
            Text = "Лаб-04: Common Controls";
            Width = 850;
            Height = 850;
            StartPosition = FormStartPosition.CenterScreen;

            var scroll = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };
            Controls.Add(scroll);

            var layout = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Padding = new Padding(15)
            };
            scroll.Controls.Add(layout);

            tip = new ToolTip();

            // 1. TextBox
            layout.Controls.Add(new Label
            {
                Text = "Нэр:",
                AutoSize = true
            });

            nameBox = new TextBox
            {
                Width = 250,
                PlaceholderText = "Нэрээ бичнэ үү"
            };
            layout.Controls.Add(nameBox);
            tip.SetToolTip(nameBox, "Өөрийн нэрийг бичнэ үү");

            // 2. MaskedTextBox
            layout.Controls.Add(new Label
            {
                Text = "Утас (8 орон):",
                AutoSize = true
            });

            phoneBox = new MaskedTextBox("00000000")
            {
                Width = 250
            };
            layout.Controls.Add(phoneBox);

            // 3. CheckBox
            agreeBox = new CheckBox
            {
                Text = "Мэдээлэл зөвшөөрч байна",
                AutoSize = true
            };
            layout.Controls.Add(agreeBox);

            // 4. RadioButton
            layout.Controls.Add(new Label
            {
                Text = "Төрөл сонгох:",
                AutoSize = true
            });

            studentRadio = new RadioButton
            {
                Text = "Оюутан",
                Checked = true,
                AutoSize = true
            };
            teacherRadio = new RadioButton
            {
                Text = "Багш",
                AutoSize = true
            };
            layout.Controls.Add(studentRadio);
            layout.Controls.Add(teacherRadio);

            // 5. ComboBox
            layout.Controls.Add(new Label
            {
                Text = "Хот сонгох:",
                AutoSize = true
            });

            cityBox = new ComboBox
            {
                Width = 250,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cityBox.Items.AddRange(new object[]
            {
                "Улаанбаатар", "Дархан", "Эрдэнэт"
            });
            cityBox.SelectedIndex = 0;
            layout.Controls.Add(cityBox);

            // 6. DateTimePicker
            layout.Controls.Add(new Label
            {
                Text = "Огноо сонгох:",
                AutoSize = true
            });

            datePicker = new DateTimePicker
            {
                Width = 250,
                Format = DateTimePickerFormat.Short
            };
            layout.Controls.Add(datePicker);

            // 7. NumericUpDown
            layout.Controls.Add(new Label
            {
                Text = "Тоо сонгох:",
                AutoSize = true
            });

            numberBox = new NumericUpDown
            {
                Minimum = 1,
                Maximum = 100,
                Value = 1,
                Width = 100
            };
            layout.Controls.Add(numberBox);

            // 8. Slider + ProgressBar
            layout.Controls.Add(new Label
            {
                Text = "Slider / ProgressBar:",
                AutoSize = true
            });

            slider = new TrackBar
            {
                Minimum = 0,
                Maximum = 100,
                Value = 30,
                Width = 300
            };
            progress = new ProgressBar
            {
                Minimum = 0,
                Maximum = 100,
                Value = 30,
                Width = 300
            };

            slider.Scroll += (s, e) =>
            {
                progress.Value = slider.Value;
            };

            layout.Controls.Add(slider);
            layout.Controls.Add(progress);

            // 9. CheckedListBox
            layout.Controls.Add(new Label
            {
                Text = "Сонирхол сонгох:",
                AutoSize = true
            });

            checkedList = new CheckedListBox
            {
                Width = 250,
                Height = 70
            };
            checkedList.Items.AddRange(new object[]
            {
                "Программчлал", "Дизайн", "Сүлжээ"
            });
            layout.Controls.Add(checkedList);

            // 10. ListBox
            layout.Controls.Add(new Label
            {
                Text = "Хичээл сонгох:",
                AutoSize = true
            });

            listBox = new ListBox
            {
                Width = 250,
                Height = 60
            };
            listBox.Items.AddRange(new object[]
            {
                "C#", "Мэдээллийн сан", "Компьютерын сүлжээ"
            });
            layout.Controls.Add(listBox);

            // 11. RichTextBox
            layout.Controls.Add(new Label
            {
                Text = "Тэмдэглэл:",
                AutoSize = true
            });

            noteBox = new RichTextBox
            {
                Width = 300,
                Height = 70,
                Text = "Энд тэмдэглэл бичнэ үү."
            };
            layout.Controls.Add(noteBox);

            // 12. TreeView
            layout.Controls.Add(new Label
            {
                Text = "Мод хэлбэрийн жагсаалт:",
                AutoSize = true
            });

            tree = new TreeView
            {
                Width = 250,
                Height = 80
            };
            TreeNode root = tree.Nodes.Add("Хичээлүүд");
            root.Nodes.Add("C#");
            root.Nodes.Add("Мэдээллийн сан");
            root.Nodes.Add("Сүлжээ");
            root.ExpandAll();
            layout.Controls.Add(tree);

            // 13. ListView
            layout.Controls.Add(new Label
            {
                Text = "Олон баганатай жагсаалт:",
                AutoSize = true
            });

            listView = new ListView
            {
                Width = 350,
                Height = 80,
                View = View.Details,
                FullRowSelect = true
            };
            listView.Columns.Add("Нэр", 150);
            listView.Columns.Add("Төрөл", 150);
            listView.Items.Add(new ListViewItem(
                new[] { "C#", "Программчлал" }));
            listView.Items.Add(new ListViewItem(
                new[] { "SQL", "Өгөгдлийн сан" }));
            layout.Controls.Add(listView);

            // 14. PictureBox
            layout.Controls.Add(new Label
            {
                Text = "PictureBox:",
                AutoSize = true
            });

            picture = new PictureBox
            {
                Width = 70,
                Height = 50,
                Image = SystemIcons.Information.ToBitmap(),
                SizeMode = PictureBoxSizeMode.CenterImage,
                BorderStyle = BorderStyle.FixedSingle
            };
            layout.Controls.Add(picture);

            // 15. MonthCalendar
            layout.Controls.Add(new Label
            {
                Text = "Сарын хуанли:",
                AutoSize = true
            });

            var calendar = new MonthCalendar
            {
                MaxSelectionCount = 1
            };
            layout.Controls.Add(calendar);

            // 16. Үр дүнгийн Label
            resultLabel = new Label
            {
                Text = "Үр дүн энд харагдана",
                AutoSize = true,
                ForeColor = Color.Blue,
                Font = new Font("Arial", 11, FontStyle.Bold)
            };
            layout.Controls.Add(resultLabel);

            // 17. Button
            var showButton = new Button
            {
                Text = "Мэдээлэл харуулах",
                Width = 180,
                Height = 35
            };

            showButton.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(nameBox.Text))
                {
                    MessageBox.Show("Нэрээ оруулна уу!");
                    return;
                }

                if (!agreeBox.Checked)
                {
                    MessageBox.Show("Зөвшөөрлийн нүдийг тэмдэглэнэ үү!");
                    return;
                }

                string type = studentRadio.Checked
                    ? "Оюутан" : "Багш";

                resultLabel.Text =
                    "Нэр: " + nameBox.Text +
                    " | Хот: " + cityBox.Text +
                    " | Төрөл: " + type +
                    " | Огноо: " + datePicker.Value.ToShortDateString() +
                    " | Тоо: " + numberBox.Value;
            };

            layout.Controls.Add(showButton);

            // 18. ListBox-ийн сонголтын үйл явдал
            listBox.SelectedIndexChanged += (s, e) =>
            {
                if (listBox.SelectedItem != null)
                {
                    resultLabel.Text =
                        "Сонгосон хичээл: " + listBox.SelectedItem;
                }
            };

            // 19. NotifyIcon — системийн мэдэгдлийн дүрс
            trayIcon = new NotifyIcon
            {
                Icon = SystemIcons.Information,
                Text = "Common Controls апп",
                Visible = true
            };

            trayIcon.DoubleClick += (s, e) =>
            {
                Show();
                WindowState = FormWindowState.Normal;
                Activate();
            };

            FormClosing += (s, e) =>
            {
                trayIcon.Visible = false;
                trayIcon.Dispose();
                tip.Dispose();
                picture.Image?.Dispose();
            };
        }
    }
}
