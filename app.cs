using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
public partial class G : Form
{
    public G()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(G));
        b = new Button();
        d = new RichTextBox();
        c = new Button();
        a = new TextBox();
        e = new RichTextBox();
        debug = new RichTextBox();
        f = new System.Windows.Forms.Timer(components);
        SuspendLayout();
        // 
        // b
        // 
        b.Location = new Point(220, 382);
        b.Name = "b";
        b.Size = new Size(75, 23);
        b.TabIndex = 1;
        b.Text = "是个按钮";
        b.UseVisualStyleBackColor = true;
        b.Click += b_Click;
        // 
        // d
        // 
        d.Location = new Point(0, 0);
        d.Name = "d";
        d.ReadOnly = true;
        d.Size = new Size(800, 248);
        d.TabIndex = 3;
        d.Text = "";
        // 
        // c
        // 
        c.Location = new Point(488, 382);
        c.Name = "c";
        c.Size = new Size(75, 23);
        c.TabIndex = 2;
        c.Text = "是个按钮";
        c.UseVisualStyleBackColor = true;
        c.Visible = false;
        // 
        // a
        // 
        a.Location = new Point(332, 382);
        a.Name = "a";
        a.Size = new Size(100, 23);
        a.TabIndex = 0;
        a.Text = "输入...";
        a.Visible = false;
        a.KeyDown += a_Enter;
        // 
        // e
        // 
        e.Location = new Point(0, 254);
        e.Name = "e";
        e.ReadOnly = true;
        e.Size = new Size(192, 196);
        e.TabIndex = 5;
        e.Text = "";
        // 
        // debug
        // 
        debug.Location = new Point(625, 254);
        debug.Name = "debug";
        debug.ReadOnly = true;
        debug.Size = new Size(175, 196);
        debug.TabIndex = 4;
        debug.Text = "";
        // 
        // f
        // 
        f.Interval = 10;
        f.Enabled = true;
        f.Tick += tick;
        // 
        // G
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(debug);
        Controls.Add(e);
        Controls.Add(b);
        Controls.Add(a);
        Controls.Add(c);
        Controls.Add(d);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Name = "G";
        Text = "LoveNest";
        ResumeLayout(false);
        PerformLayout();
    }

    private Button b;
    private Button c;
    private TextBox a;
    private RichTextBox e;
    private RichTextBox debug;
    private System.Windows.Forms.Timer f;
    private System.ComponentModel.IContainer components;
    private RichTextBox d;
}
partial class G
{
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }
    private void b_Click(object sender, EventArgs e)
    {
        a.Show();
        b.Hide();
        start();

    }
    private static async Task start()
    {
        _ = Task.Run(E.Start);
    }
    private static async Task sub1(string action)
    {
       _=Task.Run(() => E.GetAction(action));
    }
    private void a_Enter(object sender, KeyEventArgs e)
    {
        if (e.KeyData == Keys.Enter && a.Text != "")
        {
            sub1(a.Text);
            a.Text = ("请输入...");
        }
    }
    private void tick(object sender, EventArgs f)
    {
        d.Text = A.text1;
        e.Text = A.text2;
#if DEBUG
        debug.Text = A.textdebug;
#endif
    }
}
internal class Program
{
#if DEBUG
    [DllImport("kernel32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool AllocConsole();
#endif
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
        Application.Run(new G());
    }
}