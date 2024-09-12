using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;
using System.Linq;
using System.Media;
using System.Net.Http.Headers;
using System.Windows.Forms;
using System.Net.Mail;
using System.Drawing.Drawing2D;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Microsoft.VisualBasic.Logging;
    public class A
    {
    public static string[] scene = { "start", "menu" }; public static Dictionary<string, string> setting = new Dictionary<string, string>();public static string text1, text2 = "";
#if DEBUG
    public static string textdebug = "";
#endif
}
    public class B
    {
    public static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }
        public static void FileCreate(string path, string text)
        {
            if (!File.Exists(path))
                using (FileStream fs = File.Create(path))
                {
                    AddText(fs, text);
                }
            else
            {
                File.Delete(path);
                FileCreate(path, text);
            }
        }
        public static void FileCreatePoly(string path, string[] text)
        {
            if (!File.Exists(path))
                using (FileStream fs = File.Create(path))
                {
                    for (int a = 0; a < text.Length; a++)
                    {
                        string b = text[a] + "\n";
                        AddText(fs, b);
                    }
                }
            else
            {
                File.Delete(path);
                FileCreatePoly(path, text);
            }
        }
        public static void ExtendFile(string path, string a)
        {
            try
            {
                using (FileStream b = File.Open(path, FileMode.Append))
                {
                    AddText(b, a);
                }
            }
            catch (Exception)
            {
                Application.Exit();
#if DEBUG
                Environment.Exit(1);
#endif
            }
        }
        public static void playSound(string path)
        {
            SoundPlayer a = new SoundPlayer(@path);
            a.Play();
        }
    }
    public class C
    {
        public static void GetFile()
        {
            string path;
            if (Directory.Exists(Directory.GetCurrentDirectory() + "\\晴小姐"))
            {
                path = Directory.GetCurrentDirectory() + "\\晴小姐\\民数记";
            }
            else
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\晴小姐");
                path = Directory.GetCurrentDirectory() + "\\晴小姐\\民数记";
            }
            string[] text = { "你渴望异常，你渴望力量，", "你痛恨这副与灵魂不符的躯体...", "你渴望成为神……", "你渴望成为神的对立面。", "============================================================", "这一项扭曲的欲望将会造就你的动机、你的因果，你前世今生的一切。", "============================================================", "", "", "", "……如果这份欲望能够【【【转移】】】的话，一切会有挽回的余地吗………………", "此文件由爱之巢模拟器v0.0.2生成", "看到这里，你还好吗？ " };
            Console.OutputEncoding = Encoding.Unicode;
            text[12] = text[12] + Environment.UserName;
            B.FileCreatePoly(path, text);
            Console.WriteLine("我为你生成了一份文件，想看的话就检查一下主文件夹吧('ω') - 晴小姐");
            Thread.Sleep(30000);
            Console.WriteLine("还没找到？服了你了，那就检查一下这个目录吧{0} - 晴小姐", path);
            Thread.Sleep(10000);
            File.Open(path, FileMode.Open);
        }
            public static void ReadFile(string path)
            {
            int dialogSpeed = 300; float dialogDelay = 1; string soundPath = null; string vocalPath = null; bool issounded = false, isvocaled = false, soundedonce = false; string e = null;
            /*if(A.setting!=null)
            {
            try
            {
                dialogSpeed = Int32.Parse(A.setting["dialogspeed"]);
                dialogDelay = Int32.Parse(A.setting["dialogdelay"]);
            }
            catch (Exception){};
            }*/
            StreamReader a = new StreamReader(path);
            try
            {
                string line = a.ReadLine();
                while (line != null)
                {
                    if (!line.Contains("dialog") && !line.Contains("case") && !line.Contains("clear")&&!line.Contains("sound"))
                    {
                        if (isvocaled == true)
                        {
                            PlaySound(vocalPath);
                        }
                        for (int i = 0; i < line.Length; i++)
                        {
                            Thread.Sleep(dialogSpeed);
                        if (issounded == true)
                            PlaySound(soundPath);
                        if (soundedonce == true)
                        {
                            PlaySound(soundPath);
                            soundedonce = false;
                        }
                        A.text1 = A.text1+line[i];
#if DEBUG
                        Console.Write(line[i]);
#endif
                    }
                        A.text1 += "\n";
#if DEBUG
                    Console.WriteLine("");
#endif
                    Thread.Sleep(dialogSpeed);
                        Thread.Sleep((int)(dialogDelay * 1000));
                        line = a.ReadLine();
                    }
                    else if (line.Contains("dialogdelay"))
                    {
                        line = a.ReadLine();
                        dialogDelay = Int32.Parse(line);
                        line = a.ReadLine();
                    }
                    else if (line.Contains("dialogspeed"))
                    {
                        line = a.ReadLine();
                        dialogSpeed = Int32.Parse(line);
                        line = a.ReadLine();
                    }
                    else if (line.Contains("dialogsounded"))
                    {
                        line = a.ReadLine();
                        issounded = true;
                        soundPath = D.Sound() + line;
                        line = a.ReadLine();
                    }
                    else if (line.Contains("dialogdisablesound"))
                    {
                        issounded = false;
                        soundPath = null;
                        line = a.ReadLine();
                    }
                    else if (line.Contains("dialogvocaled"))
                    {
                        line = a.ReadLine();
                        if (e != null)
                        {
                            line = e + line;
                        }
                        else
                        {
                            line += "\\";
                        }
                        isvocaled = true;
                        vocalPath = D.Vocal() + line;
#if DEBUG
                        Console.WriteLine(vocalPath);
#endif
                        line = a.ReadLine();
                    }
                    else if (line.Contains("dialogdisablevocal"))
                    {
                        isvocaled = false;
                        vocalPath = null;
                        line = a.ReadLine();
                    }
                    else if (line.Contains("dialogvocalpath"))
                    {
                        e = "\\"; line = a.ReadLine();
                        while (!line.Contains("end"))
                        {
                            e += line + "\\";
                            line = a.ReadLine();
                        }
                        line = a.ReadLine();
#if DEBUG
                        Console.WriteLine(e);
#endif
                    }
                    else if (line.Contains("clear"))
                    {
#if DEBUG
                    Console.Clear();
#endif
                    A.text1 = "";
                    line = a.ReadLine();
                    }
                    else if (line.Contains("soundedonce"))
                    {
                    soundedonce = true;
                    a.ReadLine();
                    soundPath = a.ReadLine();
                    a.ReadLine();
                    }
                    else
                    {
                        line = a.ReadLine();
                    }

                }
                a.Close();
            }
            catch (Exception)
            {
                return;
            }
        }
        public static void ReadArray(string[] c)
        {
            int dialogSpeed = 300; int dialogDelay = 1; string soundPath = null; string vocalPath = null; bool issounded = false,isvocaled = false,issoundedonce = false; string e = null;
            for (int x = 0; x < c.Length; x++)
            {
                string d = c[x];

                if (!d.Contains("dialog") && !d.Contains("case") && !d.Contains("clear"))
                {
                    if (isvocaled == true)
                    {
                        PlaySound(vocalPath);
                    }
                    for (int i = 0; i < d.Length; i++)
                    {
                        Thread.Sleep(dialogSpeed);
                        if (issounded == true)
                        {
                            PlaySound(soundPath);
                        }
                        if (issoundedonce==true)
                    {
                        {
                            PlaySound(soundPath);
                            issoundedonce = false;
                        }
                    }
                        Console.Write(d[i]);
                    }
                    Thread.Sleep(dialogSpeed);
                    Console.WriteLine("");
                    Thread.Sleep(dialogDelay * 1000);
                    continue;
                }
                else if (d.Contains("dialogdelay"))
                {
                    x++; d = c[x];
                    dialogDelay = Int32.Parse(d);
                    continue;
                }
                else if (d.Contains("dialogspeed"))
                {
                    x++; d = c[x];
                    dialogSpeed = Int32.Parse(d);
                    continue;
                }
                else if (d.Contains("dialogsounded"))
                {
                    x++; d = c[x]; d = d + ".mp3";
                    issounded = true;
                    soundPath = D.Sound() + d;
                    continue;
                }
                else if (d.Contains("dialogdisablesound"))
                {
                    issounded = false;
                    soundPath = null;
                    continue;
                }
                else if (d.Contains("dialogvocaled"))
                {
                    x++; d = c[x];
                    if (e != null)
                    {
                        d = e + d;
                    }
                    else { d += "\\"; }
                    isvocaled = true;
                    vocalPath = D.Vocal() + d;
                    continue;
                }
                else if (d.Contains("dialogdisablevocal"))
                {
                    isvocaled = false;
                    vocalPath = null;
                    continue;
                }
                else if (d.Contains("clear"))
                {
                    Console.Clear();
                    continue;
                }
                else if (d.Contains("dialogvocalpath"))
                {
                    e = "\\"; x++; d = c[x];
                    while (!d.Contains("end"))
                    {
                        e += d + "\\";
                        x++; d = c[x];
                    }
#if DEBUG
                    Console.WriteLine(e);
#endif
                    continue;
                }
            }
            return;
        }
        [DllImport("winmm.dll")]
        public static extern uint mciSendString(string command, StringBuilder ReturnValue, int uReturnLength, IntPtr hWndCallback);
        public static void PlaySound(string path, bool reset = false)
        {
            string c = "sound";
            if (reset == true)
                mciSendString(@"close sound", null, 0, IntPtr.Zero);
            else
            if (File.Exists(path + ".mp3"))
                mciSendString(sub(path, ".mp3",c), null, 0, IntPtr.Zero);
            else if (File.Exists(path + ".ogg"))
                mciSendString(sub(path, ".ogg",c), null, 0, IntPtr.Zero);
            else if (File.Exists(path + ".wav"))
                mciSendString(sub(path, ".wav",c), null, 0, IntPtr.Zero);
            else {
#if DEBUG
                Console.WriteLine("文件不存在");
#endif
                return;
            }
            mciSendString("play sound", null, 0, IntPtr.Zero);
            return;
        }

        public static void PlayMusic(string path, bool reset = false)
        {
            string c = "music";
            if (reset == true)
                mciSendString(@"close music", null, 0, IntPtr.Zero);
            else
            if (File.Exists(path + ".mp3"))
                mciSendString(sub(path, ".mp3",c), null, 0, IntPtr.Zero);
            else if (File.Exists(path + ".ogg"))
                mciSendString(sub(path, ".ogg",c), null, 0, IntPtr.Zero);
            else if (File.Exists(path + ".wav"))
                mciSendString(sub(path, ".wav",c), null, 0, IntPtr.Zero);
            else {
#if DEBUG
                Console.WriteLine("文件不存在");
#endif
                return;
            }
            mciSendString("play music repeat", null, 0, IntPtr.Zero);
            return;
        }
        public static string sub(string a, string b,string alias="a")
        {
            a = string.Format(@"play ""{0}"" alias {1}", a + b,alias);
            return a;
        }
    }
    public class D
    {
        public static string Dialog()
        {
            return Directory.GetCurrentDirectory() + "\\assets\\Dialog";
        }
        public static string Sound()
        {
            return Directory.GetCurrentDirectory() + "\\assets\\Sound\\";
        }
        public static string Vocal()
        {
            return Directory.GetCurrentDirectory() + "\\assets\\Sound\\Vocal";
        }
        public static string Action()
        {
            return Directory.GetCurrentDirectory() + "\\assets\\Action";
        }
    }
    public class E
    {
        public static void GetAction(string action)
        {
            Thread.Sleep(3000);
            if (A.scene[0] == "Start")
            {
                Random c = new Random();
                    if (action == "退出")
                    {
                        C.ReadFile(D.Dialog() + "Quit");
                        Environment.Exit(1);
                    }
                    else if (action == "开始")
                    {
                        string[] a = { "mainroom", "Start" };A.scene = a;
                    }
                    else if (action == "戳一下")
                    {
                        int d = c.Next(1, 7);
                        if (d >= 5)
                        {
                            A.text1+=("兔子急了也是会咬人的！");
                            C.PlaySound(D.Sound() + "兔子急了.wav");
                        }
                        else if (d >= 3)
                        {
                            A.text1+=("好痛！");
                            C.PlaySound(D.Sound() + "好痛.wav");
                        }
                        else
                        {
                            A.text1+=("不...不要再戳了！");
                            C.PlaySound(D.Sound() + "不要再戳了.wav");
                        }
                    }
                    else
                    {
                        A.text1+=("请再次输入\n");
                    }
                }
            if (A.scene[0] == "mainroom")
            {
                if (A.scene[1] == "Start")
                {
                    Dictionary<string, string[]> a = ReadAction(D.Action() + "Pat");
#if DEBUG
                        Console.WriteLine(D.Action() + "Pat");
#endif
                        if (a.ContainsKey(action))
                        {
                            string[] b = a[action];
#if DEBUG
                            string[] c = { "这是个测试对话", "DEBUG特有" };
                            C.ReadArray(c);
#endif
                            C.ReadArray(b);
                            if (action == "头")
                            {
                            string[] d = { "mainroom", "room1" }; A.scene = d;
                            }
                        }
                        else
                        {
                            Console.WriteLine("请再次输入");
                        }
                    }
                }
            if (A.scene[1]=="room1")
            {
                return;
            }
            if (A.scene[1] == "Menu")
            {
                return;
            }
        }
        public static void Start()
        {
        A.scene= new string[]{ "Start", "null" };
#if DEBUG
            C.ReadFile(D.Dialog() + "StartDebug");
#else
            C.ReadFile(D.Dialog()+"Start");
#endif
            C.ReadFile(D.Dialog() + "Actions");

        }
        public static Dictionary<string, string[]> ReadAction(string path)
        {
#if DEBUG
            Console.WriteLine(path);
#endif
            StreamReader a = new StreamReader(path);
            string[] c = { };
            string b = null;
            string line = "";
            Dictionary<string, string[]> d = new Dictionary<string, string[]>();
            try
            {
                while (line != null)
                {
                    if (line == "case")
                    {
                        line = a.ReadLine();
                        b = line;
                    }
                    else if (line == "stop")
                    {
                        d.Add(b, c);
#if DEBUG
                        DEBUG.ReadArrayDebug(c);
                        Console.WriteLine(b);
                        d.Select(i => $"{i.Key}: {i.Value}").ToList().ForEach(Console.WriteLine);
#endif
                        b = ""; c = [];
                    }
                    else
                    {
                        Array.Resize(ref c, c.Length + 1);
                        c[c.Length - 1] = line;
                    }
                    line = a.ReadLine();
                }
                a.Close();
                return d;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
#if DEBUG
    public class DEBUG
    {
        public static void ReadArrayDebug(string[] a)
        {
            for (int x = 0; x < a.Length; x++)
            {
                Console.WriteLine(a[x]);
                Thread.Sleep(1000);
            }
        }
        public static void Log(string a,int c=10000)
        {
            string path = Directory.GetCurrentDirectory() + "\\log";
            if (File.Exists(path))
                if(File.ReadLines(@"C:\file.txt").Count()>=c)
                using (FileStream b = File.Open(path, FileMode.OpenOrCreate))
                {
                    B.AddText(b, a);
                }
            else
                B.FileCreate(path, a);
        }
    }
#endif