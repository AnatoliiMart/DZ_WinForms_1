using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DZ_WinForms_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Ex1();
            //Ex2();
            Ex3();
        }
        static void Ex1()
        {
            string AllText = null;
            string text = "My name is Anatolii";
            AllText += text;
            MessageBox.Show(text, "Bio_1");
            text = "I'm 25 years old";
            AllText += text;
            MessageBox.Show(text, "Bio_2");
            text = "And i'm from\n Odesa, Ukraine";
            AllText += text;
            MessageBox.Show(text, "Bio_3");
            MessageBox.Show($"Amount of symbols in biography: {AllText.Count()}", "Smb amount");
        }

        static void Ex2()
        {
            int a = 1;
            int b = 2000;
            int number;
            int count = 0;
            do
            {
                number = (a + b) / 2;

                DialogResult result = MessageBox.Show($"Number more then {number}?\n If number is guessed press \'Cancel\'", "Guess number", MessageBoxButtons.YesNoCancel);
                switch (result)
                {

                    case DialogResult.Cancel:
                        MessageBox.Show($"{count} attempts were made");
                        count = 0;
                        break;
                    case DialogResult.Yes:
                        a = number;
                        count++;
                        break;
                    case DialogResult.No:
                        b = number;
                        count++;
                        break;
                }

            } while (count > 0);
        }

        private void Ex3()
        {
            MouseClick += SelfMouseClick;
            MouseMove += SelfMouseMove;
        }


        private void SelfMouseClick(object sender, MouseEventArgs e)
        {
            string text;
            if (e.Button == MouseButtons.Left)
            {
                if (ModifierKeys == Keys.Control)
                    Close();

                if ((e.X < 10 || e.X > ClientSize.Width - 10) || (e.Y < 10 || e.Y > ClientSize.Height - 10))
                    text = "Click outside the rectangle!";
                else if ((e.X == 10 || e.X == ClientSize.Width - 10) || (e.Y == 10 || e.Y == ClientSize.Height - 10))
                    text = "Click on the border of the rectangle!";
                else
                    text = "Click inside the rectangle!";

                MessageBox.Show(text, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (e.Button == MouseButtons.Right)
            {
                Text = $"Window client area dimensions! Width = {ClientSize.Width}, Heigh = {ClientSize.Height}";
                Thread.Sleep(3000);
            }
        }

        private void SelfMouseMove(object sender, MouseEventArgs e) => Text = $"X {e.X} - Y {e.Y}";
    }
}
