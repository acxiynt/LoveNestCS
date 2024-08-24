using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using System.Media;
using System.Net.Http.Headers;
using System.Windows.Forms;
using System.Net.Mail;
using System.Drawing.Drawing2D;
internal class B
{
    private static void AddText(FileStream fs, string value)
    {
        byte[] info = new UTF8Encoding(true).GetBytes(value);
        fs.Write(info, 0, info.Length);
    }
    public static void FileCreate(string path,string text)
    {
        if(!File.Exists(path))
        using (FileStream fs = File.Create(path))
        {
            AddText(fs, text);
        }
        else
        {
        File.Delete(path);
        FileCreate(path,text);
        }
    }
    public static void FileCreatePoly(string path,string[] text)
    {
        if(!File.Exists(path))
        using (FileStream fs = File.Create(path))
        {
        for(int a = 0;a<text.Length;a++)
        {
        string b=text[a]+"\n";
        AddText(fs, b);
        }
        }
        else
        {
        File.Delete(path);
        FileCreatePoly(path,text);
        }
    }
    public static void playSound(string path)
    {
        SoundPlayer a = new SoundPlayer(@path);
        a.Play();
    }
}
internal class C
{
    public static void GetFile()
    {
        string path;
        if(Directory.Exists(Directory.GetCurrentDirectory()+"\\晴小姐"))
        {
        path =Directory.GetCurrentDirectory()+"\\晴小姐\\民数记";
        }
        else
        {
            Directory.CreateDirectory(Directory.GetCurrentDirectory()+"\\晴小姐");
            path =Directory.GetCurrentDirectory()+"\\晴小姐\\民数记";
        }
        string[] text ={"你渴望异常，你渴望力量，","你痛恨这副与灵魂不符的躯体...","你渴望成为神……","你渴望成为神的对立面。","============================================================","这一项扭曲的欲望将会造就你的动机、你的因果，你前世今生的一切。","============================================================","","","","……如果这份欲望能够【【【转移】】】的话，一切会有挽回的余地吗………………","此文件由爱之巢模拟器v0.0.2生成","看到这里，你还好吗？ "};
        Console.OutputEncoding = Encoding.Unicode;
        text[12]=text[12]+Environment.UserName;
        B.FileCreatePoly(path,text);
        Console.WriteLine("我为你生成了一份文件，想看的话就检查一下主文件夹吧('ω') - 晴小姐");
        Thread.Sleep(30000);
        Console.WriteLine("还没找到？服了你了，那就检查一下这个目录吧{0} - 晴小姐",path);
        Thread.Sleep(10000);
        File.Open(path,FileMode.Open);
    }
    public static void ReadFile(string path,string[]scene=null)
    {
    int dialogSpeed = 300;float dialogDelay = 1;string soundPath = null;string vocalPath = null;bool issounded=false;bool isvocaled=false;string e=null;
    StreamReader a=new StreamReader(path);
    try
    {
    string line= a.ReadLine();
    while (line!=null)
    {
        if(!line.Contains("dialog")&&!line.Contains("case"))
        {
        if(isvocaled==true)
        {
        PlaySound(vocalPath);
        }
        for(int i=0;i<line.Length;i++)
        {
        Thread.Sleep(dialogSpeed);
        if(issounded==true)
        {
        PlaySound(soundPath);
        }
        Console.Write(line[i]);
        }
        Thread.Sleep(dialogSpeed);
        Console.WriteLine("");
        Thread.Sleep((int)(dialogDelay*1000));
        line=a.ReadLine();
        }
        else if(line.Contains("dialogdelay"))
        {
            line=a.ReadLine();
            dialogDelay=Int32.Parse(line);
            line=a.ReadLine();
        }
        else if(line.Contains("dialogspeed"))
        {
            line=a.ReadLine();
            dialogSpeed=Int32.Parse(line);
            line=a.ReadLine();
        }
        else if(line.Contains("dialogsounded"))
        {
            line=a.ReadLine()+".wav";
            issounded=true;
            soundPath=D.Sound()+line;
            line=a.ReadLine();
        }
        else if(line.Contains("dialogdisablesound"))
        {
            issounded=false;
            soundPath=null;
            line=a.ReadLine();
        }
        else if(line.Contains("dialogvocaled"))
        {
            line=a.ReadLine();
            if(e!=null)
            {
            line=e+line+".wav";
            #if DEBUG
            Console.WriteLine(line);
            #endif
            }
            else
            {
            line+="\\";
            }
            isvocaled=true;
            vocalPath=D.Vocal()+line;
            #if DEBUG
            Console.WriteLine(vocalPath);
            #endif
            line=a.ReadLine();
        }
        else if(line.Contains("dialogdisablevocal"))
        {
            isvocaled=false;
            vocalPath=null;
            line=a.ReadLine();
        }
        else if(line.Contains("dialogvocalpath"))
        {
            e="\\";line=a.ReadLine();
            while(!line.Contains("end"))
            {
                e+=line+"\\";
                line=a.ReadLine();
            }
            line=a.ReadLine();
            #if DEBUG
            Console.WriteLine(e);
            #endif
        }
        else
        {
            line=a.ReadLine();
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
    int dialogSpeed = 300;int dialogDelay = 1;string soundPath = null;string vocalPath = null;bool issounded=false;bool isvocaled=false;
    for(int x=0;x<c.Length;x++)
    {
    string d=c[x];
    
        if(!d.Contains("dialog")&&!d.Contains("case"))
        {
        if(isvocaled==true)
        {
        PlaySound(vocalPath);
        }
        for(int i=0;i<d.Length;i++)
        {
        Thread.Sleep(dialogSpeed);
        if(issounded==true)
        {
        PlaySound(soundPath);
        }
        Console.Write(d[i]);
        }
        Thread.Sleep(dialogSpeed);
        Console.WriteLine("");
        Thread.Sleep(dialogDelay*1000);
        continue;
        }
        else if(d.Contains("dialogdelay"))
        {
            x++;d=c[x];
            dialogDelay=Int32.Parse(d);
            continue;
        }
        else if(d.Contains("dialogspeed"))
        {
            x++;d=c[x];
            dialogSpeed=Int32.Parse(d);
            continue;
        }
        else if(d.Contains("dialogsounded"))
        {
            x++;d=c[x];d=d+".wav";
            issounded=true;
            soundPath=D.Sound()+d;
            continue;
        }
        else if(d.Contains("dialogdisablesound"))
        {
            issounded=false;
            soundPath=null;
            continue;
        }
        else if(d.Contains("dialogvocaled"))
        {
            x++;d=c[x];d=d+".wav";
            isvocaled=true;
            vocalPath=D.Vocal()+d;
            continue;
        }
        else if(d.Contains("dialogdisablevocal"))
        {
            isvocaled=false;
            vocalPath=null;
            continue;
        }
    }
    return;
    }
    public static void PlaySound(string path)
    {
        SoundPlayer a = new SoundPlayer(@path);
        a.Play();
    }
}
internal class D
{
        public static string Dialog()
        {
        return Directory.GetCurrentDirectory()+"\\assets\\Dialog";
        }
        public static string Sound()
        {
        return Directory.GetCurrentDirectory()+"\\assets\\Sound\\";
        }
        public static string Vocal()
        {
        return Directory.GetCurrentDirectory()+"\\assets\\Sound\\Vocal";
        }
        public static string Action()
        {
        return Directory.GetCurrentDirectory()+"\\assets\\Action";
        }
}
internal class E
{
    public static string[] GetAction(string scene = "Start",string subscene=null)
    {
        string action=null;
        Thread.Sleep(3000);
        if(scene=="Start")
        {
        Random c=new Random();
        while(true)
        {
        action=Console.ReadLine();
        if(action=="退出")
        {
        C.ReadFile(D.Dialog()+"Quit");
        Environment.Exit(1);
        }
        else if(action=="开始")
        {
        string[]a={"mainroom","Start"};
        return a;
        }
        else if(action=="戳一下")
        {
        int d=c.Next(1,7);
        if(d>=5)
        {
        Console.WriteLine("兔子急了也是会咬人的！");
        C.PlaySound(D.Sound()+"兔子急了.wav");
        }
        else if(d>=3)
        {
        Console.WriteLine("好痛！");
        C.PlaySound(D.Sound()+"好痛.wav");
        }
        else
        {
        Console.WriteLine("不...不要再戳了！");
        C.PlaySound(D.Sound()+"不要再戳了.wav");
        }
        }
        else
        {
            Console.WriteLine("请再次输入");
            continue;
        }
        }
        }
        if(scene=="mainroom")
        {
            if(subscene=="Start")
            {
                Dictionary<string,string[]> a=ReadAction(D.Action()+"Pat");
                while(true)
                {
                action=Console.ReadLine();
                #if DEBUG
                Console.WriteLine(D.Action()+"Pat");
                #endif
                if (a.ContainsKey(action))
                {
                string[]b=a[action];
                #if DEBUG
                string[] c={"这是个测试对话","DEBUG特有"};
                C.ReadArray(c);
                #endif
                DEBUG.ReadArrayDebug(b);
                if (action=="头")
                {
                break;
                }
                }
                else
                {
                Console.WriteLine("请再次输入");
                continue;
                }
                }
            }
        }
        if(scene=="Menu")
        {
        }
        return null;
    }
    public static string[] Start()
    {
    Console.OutputEncoding = Encoding.Unicode;
    C.ReadFile(D.Dialog()+"Start");
    C.ReadFile(D.Dialog()+"Actions");
    string[] scene=GetAction();
    StartMainRoom(scene);
    return scene;
    }
    public static string[] StartMainRoom(string[] a)
    {
        C.ReadFile(D.Dialog()+a[0]+a[1]);
        GetAction(a[0],a[1]);
        return a;
    }
    public static Dictionary<string,string[]> ReadAction(string path)
    {
    #if DEBUG
    Console.WriteLine(path);
    #endif
    StreamReader a=new StreamReader(path);
    string[]c={};
    string b=null;
    string line=" ";
    Dictionary<string,string[]> d=new Dictionary<string,string[]>();
    try
    {
    while (line!=null)
    {
        if(line=="case")
        {
            line=a.ReadLine();
            b=line;
        }
        else if(line=="stop")
        {
            d.Add(b,c);
            #if DEBUG
            DEBUG.ReadArrayDebug(c);
            Console.WriteLine(b);
            #endif
            b="";c=[];
            d.Select(i => $"{i.Key}: {i.Value}").ToList().ForEach(Console.WriteLine);
        }
        else
        {
            Array.Resize(ref c, c.Length + 1);
            c[c.Length-1] = line;
        }
        line=a.ReadLine();
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
public class DEBUG
{
    public static void ReadArrayDebug(string[] a)
    {
        for(int x=0;x<a.Length;x++)
        {
            Console.WriteLine(a[x]);
            Thread.Sleep(1000);
        }
    }
}