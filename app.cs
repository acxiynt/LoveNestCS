using System.Drawing.Text;
using System.Runtime.InteropServices;

internal static class Program
    {
        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            #if DEBUG
            AllocConsole();
            Console.OutputEncoding = System.Text.Encoding.Unicode;  
            Console.WriteLine("测试文本0");
            #endif
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    }
        partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            a=new TextBox();b=new Button();c=new Button();d=new TextBox();
            a.Location = new Point(322, 382);
            a.Name = "输入框1";
            a.Size = new Size(100, 23);
            a.TabIndex = 0;
            a.Text="输入...";
            a.Enter+=new EventHandler(a_Enter);

            b.Location = new Point(58, 382);
            b.Name = "按钮1";
            b.Size = new Size(75, 23);
            b.TabIndex = 1;
            b.Text = "是个按钮";
            b.UseVisualStyleBackColor = true;
            b.Click += new EventHandler(b_Click);

            c.Location = new Point(620, 382);
            c.Name = "按钮2";
            c.Size = new Size(75, 23);
            c.TabIndex = 2;
            c.Text = "是个按钮";
            c.UseVisualStyleBackColor = true;
            
            d.Location = new Point(0, 0);
            d.Name = "输入框1";
            d.Size = new Size(600, 400);
            d.TabIndex = 3;
            d.Text="测试显示文本";
            d.ReadOnly=true;

            components = new System.ComponentModel.Container();
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            a.Hide();c.Hide();
            Controls.Add(a);Controls.Add(b);Controls.Add(c);Controls.Add(d);
            Text = "LoveNest";
            Icon=new Icon(Directory.GetCurrentDirectory()+"\\icon.ico");
            [DllImport("kernel32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            static extern bool AllocConsole();
        }
        private void b_Click(object sender, EventArgs e)
        {
            Console.WriteLine("测试文本1");
            a.Show();
        }
        private void a_Enter(object sender, EventArgs e)
        {
        }
        private TextBox a;private Button b;private Button c;private TextBox d;
    }