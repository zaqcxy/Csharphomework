using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


    public class Program : Form
    {
        TextBox txt1 = new TextBox();
        TextBox txt2 = new TextBox();
        Button btn = new Button();
        Label lbl = new Label();
        public void init()
        {
            this.Controls.Add(txt1);
            this.Controls.Add(txt2);
            this.Controls.Add(btn);
            this.Controls.Add(lbl);
            txt1.Dock = System.Windows.Forms.DockStyle.Left;
            txt2.Dock = System.Windows.Forms.DockStyle.Right;
            btn.Dock = System.Windows.Forms.DockStyle.Fill;
            lbl.Dock = System.Windows.Forms.DockStyle.Bottom;
            btn.Text = "求两个数的积";
            lbl.Text = "用于显示结果的标签";
            this.Size = new Size(300, 120);
            btn.Click += new System.EventHandler(this.button1_Click);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string x = txt1.Text;
            string y = txt2.Text;
            int now_x = int.Parse(x);
            int now_y = int.Parse(y);
            int ans = now_x * now_y;
            lbl.Text = x + "*" + y + "=" + ans;
        }
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Program f = new Program();
            f.Text = "Program";
            f.init();
            Application.Run(f);
        }
    }

