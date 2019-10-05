using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MCC;
using System.Diagnostics;
using System.Threading;
using System.Xml;

namespace Head
{
    public partial class Form1 : Form
    {
        private delegate void MsgTextList(string str, int num);
        private delegate void MsgRTextList(string str, int num);
        bool CAN_flag = false;
        bool Card_flag = false;
        HZC_Head08Card headcard;
        CANCard cancard;
        bool Test_flag = false;
        bool RTest_flag = false;
        public int num
        {
            get;
            set;
        }
        public int num1
        {
            get;
            set;
        }
        //int num;
        int flag = 0;   
        public Form1()
        {
            
            InitializeComponent();
            Btn_CanInit.Click += new EventHandler(Btn_CanInit_Click);
            Btn_CardInit.Click += new EventHandler(Btn_CardInit_Click);
            Btn_Home.Click +=new EventHandler(Btn_Home_Click);
            Btn_ServoOn.Click +=new EventHandler(Btn_ServoOn_Click);
            Btn_ServoOff.Click += new EventHandler(Btn_ServoOff_Click);
            //CreatXml();

            XmlDocument doc = new XmlDocument();
            doc.Load("HeadParameter");

            XmlNode Zparameter = doc.SelectSingleNode("/运行参数/头[@Head='1']/运动次数");
            XmlNode Rparameter = doc.SelectSingleNode("/运行参数/R轴[@R='1']/旋转圈数");
            num = int.Parse(Zparameter.InnerText);
            num1 = int.Parse(Rparameter.InnerText);
            //XmlElement root = doc.DocumentElement;
            //XmlNodeList parameter = root.GetElementsByTagName("头");
            //foreach(XmlNode node in parameter)
            //{
            //    string number = ((XmlElement)node).GetElementsByTagName("旋转圈数")[0].InnerText;
            //    num = int.Parse(number);
            //}
            
           
        }
        private void CreatXml()
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "UTF-8", "yes");
            doc.AppendChild(dec);
            XmlElement root = doc.CreateElement("运行参数");
            doc.AppendChild(root);

            XmlElement head = doc.CreateElement("头");
            head.SetAttribute("Head", "1");

            XmlElement number = doc.CreateElement("旋转圈数");
            XmlText numbertext = doc.CreateTextNode(num.ToString());
            number.AppendChild(numbertext);

            head.AppendChild(number);
            root.AppendChild(head);
            doc.Save("HeadParameter");
        }

        void Btn_ServoOff_Click(object sender, EventArgs e)
        {
            if (Card_flag)
            {
                for (int i = 0; i < 8; i++)
                {
                    headcard.ServerOff(i);
                }
            }
            else
            {
                SetText("请初始化板卡！", -1);
            }
      
        }

        void Btn_ServoOn_Click(object sender, EventArgs e)
        {
            if (Card_flag)
            {
                for (int i = 0; i < 8; i++)
                {
                    headcard.ServerOn(i);
                }
            }
            else
            {
                SetText("请初始化板卡！", -1);
            }
        }
        void Btn_Home_Click(object sender, EventArgs e)
        {
            if (Card_flag)
            {
                AxisMotion a = AxisMotion.axis_motion;
                a.StartHome();
                //AxisMotion.StartHome();
                while (!AxisMotion.HomeFinish) ;
                //AxisMotion.StopHome();
                a.StopHome();
            }
            else
            {
                SetText("请初始化板卡！", -1);
            }
        }
        void Btn_CardInit_Click(object sender, EventArgs e)
        {
            int status = -1;
            headcard = new HZC_Head08Card(1, 7);
            try
            {
                if (CAN_flag)
                {
                    status = headcard.Initial(1,0);
                    if (status == 0)
                    {
                        SetText("初始化成功！", -1);
                        for (int i = 0; i < 8;i++ )
                        {
                            headcard.SetPfParam(i, 35, 0.03, 0);
                            headcard.SetPfParam(i, 70, 0.026, 1);
                            headcard.SetPfParam(i, 100, 0.024, 2);
                            headcard.SetPfParam(i, 130, 0.024, 3);
                            headcard.SetPfParam(i, 170, 0.020, 4);
                            headcard.SetPfParam(i, 200, 0.015, 5);
                        }

 
                        Card_flag = true;
                    }
                    else
                    {
                        SetText("初始化失败！", -1);
                        Card_flag = false;
                    }
                }
                else
                {
                    SetText("请打开CAN卡！", -1);
                }

            }
            catch { }
           

            
        }

        void Btn_CanInit_Click(object sender, EventArgs e)
        {
            int status = -1;
            cancard = new CANCard();
            try
            {
                status = cancard.Initial(int.Parse(Txt_CanNum.Text));
                if (status == 0)
                {
                    SetText("CAN卡初始化成功！", -1);
                    CAN_flag = true;
                }
                else
                {
                    SetText("CAN卡初始化失败！", -1);
                    CAN_flag = false;
                }

            }
            catch
            { }
            

           
        }
        private void WriteText(string str, int num)
        {
            if (num == -1)
            {
                this.Lst_Msg.Items.Insert(0, str);
                this.Lst_Msg.SelectedIndex = 0;
                return;
            }
            this.Lab_Total.Text = num.ToString();
        }
        private void WriteRText(string str, int num)
        {
            if (num == -1)
            {
                this.Lst_Msg.Items.Insert(0, str);
                this.Lst_Msg.SelectedIndex = 0;
                return;
            }
            this.Lab_RTotal.Text = num.ToString();
        }
        private void SetRText(string str,int num)
        {
            this.BeginInvoke(new MsgRTextList(WriteRText), new object[] { str, num });
        }
        private void SetText(string str, int num)
        {
            this.BeginInvoke(new MsgTextList(WriteText), new object[] { str, num });
        }
        //AxisHome axihome = new AxisHome(1, 13, -4000, 100, 1, 0);
        private void Btn_Test_Click(object sender, EventArgs e)
        {
            if (Card_flag)
            {
                if(Btn_Test.Text=="Test")
                {
                    Btn_Test.Text = "Stop";
                    for (int i = 0; i < 8; i++)
                    {
                        headcard.SetPos(i, 0);
                    }

                    StartTest();
                    StartRTest();

                }
                else
                {
                    Btn_Test.Text = "Test";
                    StopTest();
                    StopRTest();
                }
         
            }
            else
            {
                SetText("请初始化板卡！", -1);
            }
        }
        private Thread thread_test;
        private Thread thread_RTest;
        private void DoRTest()
        {
            MyStopWatch sw = new MyStopWatch();
            while (RTest_flag)
            {           
                int pos1 = 6400 * 20 / 16;   
                int time = int.Parse(Txt_RDelay.Text);
                switch (flag)
                {
                    case 0:              
                        headcard.PfMove(6, -(int)(pos1), int.Parse(Txt_RPf.Text), Chk_R1.Checked);
                        headcard.PfMove(7, -(int)(pos1), int.Parse(Txt_RPf.Text), Chk_R2.Checked);
                        if (Chk_R1.Checked||Chk_R2.Checked )
                        {
                            num1++;
                        }

                        sw.StartStopWatch(time);
                        flag = 1;
                        break;
                    case 1:
                        if (sw.TimeUp())
                        {
                            SetRText("", num1);
                            headcard.PfMove(6, 0, int.Parse(Txt_RPf.Text), Chk_R1.Checked);
                            headcard.PfMove(7, 0, int.Parse(Txt_RPf.Text), Chk_R2.Checked);
                            if (Chk_R1.Checked || Chk_R2.Checked)
                            {
                                num1++;
                            }
                            sw.StartStopWatch(time);
                            flag = 3;
                        }
                        break;
                    case 3:
                        if (sw.TimeUp())
                        {
                            SetRText("", num1);
                            Thread.Sleep(15);
                            flag = 0;
                        }
                        break;

                }
            }

        }
        public void StartRTest()
        {
            if (thread_RTest == null || !thread_RTest.IsAlive)
            {
                RTest_flag = true;
                thread_RTest = new Thread(DoRTest);
                thread_RTest.Start();
            }
        }
        public void StopRTest()
        {

            if (thread_RTest != null && thread_RTest.IsAlive)
            {
                RTest_flag = false;
                thread_RTest.Abort();
                thread_RTest.Join();
            }
        }
        public  void StartTest()
        {
            if(thread_test==null||!thread_test.IsAlive)
            {
                Test_flag = true;
                thread_test = new Thread(DoTest);
                thread_test.Start();
            }
        }
        public void StopTest()
        {
            
            if(thread_test!=null&&thread_test.IsAlive)
            {
                Test_flag = false;
                thread_test.Abort();
                thread_test.Join();
            }
        }
        private void DoTest()
        {
            MyStopWatch sw = new MyStopWatch();
            while (Test_flag)
            {
                double pos = ZData.ZPulse * int.Parse(Txt_TestDis.Text) / ZData.Z_Thread;
                //int pos1 = 6400*20/16;
                int pf = int.Parse(Txt_TestPf.Text);
                int time = int.Parse(Txt_DelayTime.Text);
                switch (flag)
                {
                  case 0:
                        headcard.PfMove(0, -(int)pos, pf,Chk_Box1.Checked);
                        headcard.PfMove(1, -(int)pos, pf, Chk_Box2.Checked);
                        headcard.PfMove(2, -(int)pos, pf, Chk_Box3.Checked);
                        headcard.PfMove(3, -(int)pos, pf, Chk_Box4.Checked);
                        headcard.PfMove(4, -(int)pos, pf, Chk_Box5.Checked);
                        headcard.PfMove(5, -(int)pos, pf, Chk_Box6.Checked);
                        //headcard.PfMove(6, -(int)(pos1), pf, Chk_R1.Checked);
                        //headcard.PfMove(7, -(int)(pos1), pf, Chk_R2.Checked);
                        if (Chk_Box1.Checked || Chk_Box2.Checked || Chk_Box3.Checked || Chk_Box4.Checked || Chk_Box5.Checked || Chk_Box6.Checked)
                        {
                            num++;
                        }
                        
                        sw.StartStopWatch(time);
                          flag = 1;
                         break;
                     case 1:
                         if (sw.TimeUp())
                         {
                             SetText("", num);
                             headcard.PfMove(0, 0, pf, Chk_Box1.Checked);
                             headcard.PfMove(1, 0, pf, Chk_Box2.Checked);
                             headcard.PfMove(2, 0, pf, Chk_Box3.Checked);
                             headcard.PfMove(3, 0, pf, Chk_Box4.Checked);
                             headcard.PfMove(4, 0, pf, Chk_Box5.Checked);
                             headcard.PfMove(5, 0, pf, Chk_Box6.Checked);
                             //headcard.PfMove(6, 0, pf, Chk_R1.Checked);
                             //headcard.PfMove(7, 0, pf, Chk_R2.Checked);
                             if (Chk_Box1.Checked || Chk_Box2.Checked || Chk_Box3.Checked || Chk_Box4.Checked || Chk_Box5.Checked || Chk_Box6.Checked)
                             {
                                 num++;
                             }
                             sw.StartStopWatch(time);
                             flag = 3;
                         }
                        break;
                    case 3:
                        if (sw.TimeUp())
                        {
                            SetText("", num);
                            Thread.Sleep(15);
                            flag = 0;
                        }
                        break;

                }
            }

        }
        private void  SaveCircleToXml()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("HeadParameter");
            XmlNode Zparameter = doc.SelectSingleNode("/运行参数/头[@Head='1']/运动次数");
            XmlNode Rparameter = doc.SelectSingleNode("/运行参数/R轴[@R='1']/旋转圈数");
            Zparameter.InnerText = num.ToString();
            Rparameter.InnerText = num1.ToString();

            //XmlElement root = doc.DocumentElement;
            //XmlElement selecEle = (XmlElement)root.SelectSingleNode("/运行参数/头[@Head='1']");
            //XmlElement circle = (XmlElement)selecEle.GetElementsByTagName("旋转圈数")[0];
            //circle.InnerText = num.ToString();

            doc.Save("HeadParameter");
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(Card_flag)
            {
                for (int i = 0; i < 8; i++)
                {
                    headcard.ServerOff(i);
                }

            }
            SaveCircleToXml();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetText("", num);
            SetRText("", num1);
        }


 

    }

}
public class MyStopWatch
{
    private Stopwatch sw = null;
    private long stoptime = 0;
    public MyStopWatch()
    {
        sw = new Stopwatch();
    }
    public void StartStopWatch(int ms)
    {
        if (sw.IsRunning)
        {
            sw.Stop();
        }
        stoptime = ms;
        sw.Reset();
        sw.Start();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ms"></param>
    public void StopStopWatch()
    {
        sw.Stop();
        sw.Reset();
        sw.Start();
    }


    public bool TimeUp()
    {
        if (sw.ElapsedMilliseconds >= stoptime)
        {
            sw.Stop();
            stoptime = 0;
            return true;
        }
        return false;
    }


}
public class AxisHome
{
    private int axis;//轴号
    private int homesensorid;//零点感应ID号
    private int pulse;//脉冲每圈
    private int movepos;//规避home感应的方向与距离
    private int speed1;//速度（K个脉冲）
    private int sensorstate;//回到零点位置home感应器状态
    private int home_flag=0;
    private bool do_home = true;
    private Thread thread_home;
    private MyStopWatch sw = new MyStopWatch();
    //HZC_Head08Card headcard=null;
    public bool homeFinish
    {
        get
        {
            if (thread_home == null)
                return true;
            return thread_home.IsAlive;
        }
    }
    public  AxisHome(int axis,int homesensorid,int pulse,int movepos,int speed,int sensorstate)
    {

        this.axis = axis;
        this.homesensorid = homesensorid;
        this.pulse = pulse;
        this.movepos = movepos;
        this.speed1 = speed;
        this.sensorstate = sensorstate;

    }
    private int home()
    {
        HZC_Head08Card headcard = new HZC_Head08Card(1,7);
        int status = 0;
        switch (home_flag)
        {
            case 0:
                headcard.SetPos(axis, 0);
                headcard.SetEncPos(axis, 0);
                if (headcard.GetAxisSensor(homesensorid)==sensorstate)
                {
                    home_flag = 1;
                }
                else
                {
                    home_flag = 20;
                }
                break;
            case 1://处于感应状态
                //headcard.PfMove(axis, pulse, 0);
                headcard.CnstMove(axis, speed1, -10000);
                home_flag = 2;
                break;
            case 2:
                int s = -1;
                s=headcard.GetAxisSensor(homesensorid);
                if ( s!= sensorstate)
                {
                    headcard.AbortMoving(axis);
                    sw.StartStopWatch(150);
                    while (!sw.TimeUp()) ;
                    home_flag = 3;
                }
                break;
            case 3:
                headcard.SearchForhomepos(axis, 0, 450, 300);
               
                sw.StartStopWatch(300);

                home_flag = 4;
                break;
            case 4:
                //if (headcard.GetStatus(axis) != 0) break;
                
                while (!sw.TimeUp()) ;
                if (headcard.GetAxisSensor(homesensorid) == 0)
                {
                    headcard.SetPos(axis, 0);

                }
                else
                {
                    home_flag = 3;
                    break;
                }
                home_flag = 0;
                status = 1;
                break;
            case 20://未感应状态
                headcard.CnstMove(axis, speed1, 10000);
                home_flag = 21;

                break;
            case 21:
                //headcard.CnstMove(axis, 100, 1000);
                if (headcard.GetAxisSensor(homesensorid) == sensorstate)
                {
                    headcard.AbortMoving(axis);
                    sw.StartStopWatch(150);
                    while (!sw.TimeUp()) ;
                    home_flag = 1;
                }
                break;
        }
        return status;
    }
    private void DoHome() 
    {
        home_flag = 0;
        do_home = true;
        while (do_home)
        {
            if (home() == 1)
            {
                do_home = false;
            }
        }
    }
    public void StartHome()
    {
        if(thread_home==null||!thread_home.IsAlive)
        {
            thread_home = new Thread(DoHome);
            thread_home.Start();
        }
    }
    public void StopHome()
    {
        if(thread_home!=null &&thread_home.IsAlive)
        {
            do_home = false;
            thread_home.Abort();
            thread_home.Join();
        }
    }

}
public class AxisMotion
{
    static AxisHome Z1Home = null;
    static AxisHome Z2Home = null;
    static AxisHome Z3Home = null;
    static AxisHome Z4Home = null;
    static AxisHome Z5Home = null;
    static AxisHome Z6Home = null;
    private static Thread FHome;
    private static int homeflag = 0;
    private static HZC_Head08Card headcard = new HZC_Head08Card(1, 7);
    private static AxisMotion axismotion;
 
    private static object locker = new object();
    private static MyStopWatch sw = new MyStopWatch();
    public static AxisMotion axis_motion
    {
        get
        {
            if (axismotion == null)
            {
                lock(locker)
                {
                    if (axismotion ==null)
                    {
                        axismotion = new AxisMotion();
                    }
                }
            }
            return axismotion;
        }
    }

    private AxisMotion ()
    {
        Z1Home = new AxisHome(0, 03, -4000, 100, 1, 0);
        Z2Home = new AxisHome(1, 13, -4000, 100, 1, 0);
        Z3Home = new AxisHome(2, 23, -4000, 100, 1, 0);
        Z4Home = new AxisHome(3, 33, -4000, 100, 1, 0);
        Z5Home = new AxisHome(4, 43, -4000, 100, 1, 0);
        Z6Home = new AxisHome(5, 53, -4000, 100, 1, 0);
     
    }

    public static bool HomeFinish
    {
        get
        {
            return !FHome.IsAlive;
        }
    }
    private static int Home()
    {
        int status = 0;
        switch (homeflag)
        {
            case 0:
             
                Z1Home.StartHome();
                Z2Home.StartHome();
                Z3Home.StartHome();
                Z4Home.StartHome();
                Z5Home.StartHome();
                Z6Home.StartHome();
                sw.StartStopWatch(15000);
                homeflag = 1;
                break;
            case 1:
                //if (!sw.TimeUp()) break;  
                if (Z1Home.homeFinish||Z2Home.homeFinish || Z3Home.homeFinish || Z4Home.homeFinish || Z5Home.homeFinish || Z6Home.homeFinish) break;
                Z1Home.StopHome();
                Z2Home.StopHome();
                Z3Home.StopHome();
                Z4Home.StopHome();
                Z5Home.StopHome();
                Z6Home.StopHome();
                homeflag = 2;
                break;
            case 2:
                for (int i = 0; i < 6; i++)
                {
                    headcard.PfMove(i, 2999, 0, true);
                }

                status = 1;
                homeflag = 0;
                break;
        }
        return status;
    }
    public  void StartHome()
    {
        if (FHome == null || !FHome.IsAlive)
        {
            FHome = new Thread(() =>
            {
                while (Home() == 0) ;
            });
            FHome.Start();
        }
    }
    public  void StopHome()
    {
        if (FHome != null && FHome.IsAlive)
        {
            FHome.Abort();
            FHome.Join();
        }
    }
  

}
public struct ZData
{
    public const double Z_Thread = 13.583 * 3.1415926;
    public static  int ZPulse = 6400;
    public const double R_Thread = 14.23 * 3.1415926;
    public static int RStepPulse = 64 * 100;

}

