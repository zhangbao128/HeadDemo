using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;


namespace MCC
{      
    public class CANCard
    {

        /// <summary>
        /// 初始化板卡资源，需首先调用。
        /// </summary>
        /// <param name="canno"></param>
        /// <returns></returns>
        [DllImport("JotCard.dll", EntryPoint = "JOT8_InitMotionSystem", CallingConvention = CallingConvention.Cdecl)]
        private static extern Int32 JOT8_InitMotionSystem();
        /// <summary>
        /// 初始化CAN卡，分配资源等
        /// </summary>
        /// <returns></returns>
        [DllImport("JotCard.dll", EntryPoint = "JOT8_InitCanCard", CallingConvention = CallingConvention.Cdecl)]
        private static extern Int32 Jot8_InitCanCard(int canno);
        /// <summary>
        /// 退出时调用
        /// </summary>
        /// <param name="canno"></param>
        /// <returns></returns>
        [DllImport("JotCard.dll", EntryPoint = "JOT8_ExitMotionSystem", CallingConvention = CallingConvention.Cdecl)]
        private static extern Int32 JOT8_ExitMotionSystem();

        /// <summary>
        /// 关闭CAN卡，释放资源等
        /// </summary>
        /// <param name="canno"></param>
        /// <returns></returns>
        [DllImport("JotCard.dll", EntryPoint = "JOT8_ExitCanCard", CallingConvention = CallingConvention.Cdecl)]
        private static extern Int32 JOT8_ExitCanCard(int canno);

        public int Initial(int id)
        {
            int status = -1;
            status = Jot8_InitCanCard(id);
            return status;
        }

        public int Dispos(int id)
        {
            int status = -1;
            try
            {
                status = JOT8_ExitCanCard(id);

            }
            catch
            {

            }
            return status;
        }

    }
    public class HZC_Head08Card 
    {

        #region  dll
        [DllImport("JotCard.dll", EntryPoint = "HZC6C0008_InitAxis",CallingConvention=CallingConvention.Cdecl)]  //
        extern public static int HZC6C0008_InitAxis(int canno, int cardno, int axis, int s_model,int dir_s);

        /*
            说明：设置速度等级参数
            参数：
                canno,cardno,axis:	CAN号、卡号、轴号
                pf:					速度等级标示
                maxvel:				最大速度(Hz)
                acctime:			加速时间(s)
            返回值:
                0:					执行成功
                !0:					执行失败
            备注:
                maxvel > 1350 / acctime
        */
        [DllImport("JotCard.dll", EntryPoint = "HZC6C0008_SetTPFParam",CallingConvention=CallingConvention.Cdecl)]
        extern public static int HZC6C0008_SetTPFParam(int canno, int cardno, int axis, int pf, int maxvel, double acctime);

        /*
            说明：打开(关闭)伺服使能
            参数：
                canno,cardno,axis:	CAN号、卡号、轴号
            返回值:
                0:					执行成功
                !0:					执行失败
            备注:
        */
        [DllImport("JotCard.dll", EntryPoint = "HZC6C0008_ServerOn" ,CallingConvention=CallingConvention.Cdecl)]
        extern public static int HZC6C0008_ServerOn(int canno, int cardno, int axis);
        [DllImport("JotCard.dll", EntryPoint = "HZC6C0008_ServerOff", CallingConvention = CallingConvention.Cdecl)]
        extern public static int HZC6C0008_ServerOff(int canno, int cardno, int axis);


        /*
            说明：匀速运动
            参数：
                canno,cardno,axis:	CAN号、卡号、轴号
                pos:				匀速运动距离、正负可以切换方向(Pulse)
                spd:				匀速运动速度(Hz)
            返回值:
                0:					执行成功
                !0:					执行失败
            备注:
        */
        [DllImport("JotCard.dll", EntryPoint = "HZC6C0008_ConstMove",CallingConvention=CallingConvention.Cdecl)]
        extern public static int HZC6C0008_ConstMove(int canno, int cardno, int axis, int pos, int spd);
        /*
            说明：速度等级移动
            参数：
                canno,cardno,axis:	CAN号、卡号、轴号
                pf:					速度等级标示
                pos:				目标位置
            返回值:
                0:					执行成功
                !0:					执行失败
            备注:
        */
        [DllImport("JotCard.dll", EntryPoint = "HZC6C0008_PfMove",CallingConvention=CallingConvention.Cdecl)]
        extern public static int HZC6C0008_PfMove(int canno, int cardno, int axis, int pos, int pf);
        /*
            说明：设置(获取)指令位置
            参数：
                canno,cardno,axis:	CAN号、卡号、轴号
                pos:				位置(Pulse)
            返回值:
                0:					执行成功
                !0:					执行失败
            备注:
        */
        [DllImport("JotCard.dll", EntryPoint = "HZC6C0008_SetPos",CallingConvention=CallingConvention.Cdecl)]
        extern public static int HZC6C0008_SetPos(int canno, int cardno, int axis, int pos);
        [DllImport("JotCard.dll", EntryPoint = "HZC6C0008_GetPos",CallingConvention=CallingConvention.Cdecl)]
        extern public static int HZC6C0008_GetPos(int canno, int cardno, int axis, ref int pPos);
        /*
            说明：停止电机运动
            参数：
                canno,cardno,axis:	CAN号、卡号、轴号
            返回值:
                0:					执行成功
                !0:					执行失败
            备注:
        */
        [DllImport("JotCard.dll", EntryPoint = "HZC6C0008_Stop",CallingConvention=CallingConvention.Cdecl)]
        extern public static int HZC6C0008_Stop(int canno, int cardno, int axis);

        /*
            说明：获取轴状态
            参数：
                canno,cardno,axis:	CAN号、卡号、轴号
                * status:			[5..0]	STOP,ISRUNNING,HOME,ALARM,LIMIT1,LIMIT2
            返回值:
                0:					执行成功
                !0:					执行失败
            备注:
        */
        [DllImport("JotCard.dll", EntryPoint = "HZC6C0008_GetStatus",CallingConvention=CallingConvention.Cdecl)]
        extern public static int HZC6C0008_GetStatus(int canno, int cardno, int axis, ref int status);
        /*
            说明：清除轴限位标示
            参数：
                canno,cardno,axis:	CAN号、卡号、轴号
            返回值:
                0:					执行成功
                !0:					执行失败
            备注:					如果轴因为限位感应器而停止运行，下次需要重新运行时需要清除限位标示
        */
        [DllImport("JotCard.dll", EntryPoint = "HZC6C0008_ClearLimitSns",CallingConvention=CallingConvention.Cdecl)]
        extern public static int HZC6C0008_ClearLimitSns(int canno, int cardno, int axis);

        /*
            说明：设置正向(反向)软极限位
            参数：
                canno,cardno,axis:	CAN号、卡号、轴号
            返回值:
                0:					执行成功
                !0:					执行失败
            备注:					
        */
        [DllImport("JotCard.dll", EntryPoint = "HZC6C0008_SetPLimit",CallingConvention=CallingConvention.Cdecl)]
        extern public static int HZC6C0008_SetPLimit(int canno, int cardno, int axis, int pos);
        [DllImport("JotCard.dll", EntryPoint = "HZC6C0008_SetNLimit",CallingConvention=CallingConvention.Cdecl)]
        extern public static int HZC6C0008_SetNLimit(int canno, int cardno, int axis, int pos);

        /*
            说明：获取输入信号状态
            参数：
                canno,cardno,axis:	CAN号、卡号、轴号
                * grpbits1:			[31..0] 0:当前输入信号为低电平、1:当前输入电平为高电平
                * grpbits2:			[63..32] 0:当前输入信号为低电平、1:当前输入电平为高电平
            返回值:
                0:					执行成功
                !0:					执行失败
            备注:					现在用到的8轴卡只有32路输入信号检测,grpbits2不用
        */
        [DllImport("JotCard.dll", EntryPoint = "HZC6C0008_GetOutputBit",CallingConvention=CallingConvention.Cdecl)]
        extern public static int HZC6C0008_GetOutputBit(int canno, int cardno, int axis, ref int bit);
        [DllImport("JotCard.dll", EntryPoint = "HZC6C0008_SetOutputBit",CallingConvention=CallingConvention.Cdecl)]
        extern public static int HZC6C0008_SetOutputBit(int canno, int cardno, int axis);
        [DllImport("JotCard.dll", EntryPoint = "HZC6C0008_ClearOutputBit",CallingConvention=CallingConvention.Cdecl)]
        extern public static int HZC6C0008_ClearOutputBit(int canno, int cardno, int axis);
        [DllImport("JotCard.dll", EntryPoint = "HZC6C0008_GetAdcValue",CallingConvention=CallingConvention.Cdecl)]
        extern public static int HZC6C0008_GetAdcValue(int canno, int cardno, int axis, ref int adcval);
        [DllImport("JotCard.dll", EntryPoint = "HZC6C0008_SetPwmValue",CallingConvention=CallingConvention.Cdecl)]
        extern public static int HZC6C0008_SetPwmValue(int canno, int cardno, int channel, int value);
        [DllImport("JotCard.dll", EntryPoint = "HZC6C0008_SearchSns",CallingConvention=CallingConvention.Cdecl)]
        extern public static int HZC6C0008_SearchSns(int canno, int cardno, int axis, int snrsts, int speed, int dst);
        [DllImport("JotCard.dll", EntryPoint = "HZC6C0008_GetInputBit", CallingConvention = CallingConvention.Cdecl)]
        extern public static int HZC6C0008_GetInputBit(int canid, int id, ref int value);

        #endregion
        private int canid;
        private int id;
        
        public HZC_Head08Card(int canid, int id) 
        {
            this.canid = canid;
            this.id =id;
        }



        public int Initial(int modle, int dir)
        {
            int status = -1;
            for (int i = 0; i < 8; i++)
            {
                if (i < 6)
                {
                    status = HZC6C0008_InitAxis(canid, id, i, modle, dir); // 步进z用型曲线"0",伺服用s型曲线 "1"
                }
                else
                {
                    status = HZC6C0008_InitAxis(canid, id, i, modle, dir); // 步进z用型曲线"0",伺服用s型曲线 "1"

                }
                if (status != 0) return status;
            }

            return status;
        }


        #region    Iposmove

        public int SetPfParam(int axis, int maxsp, double accstep, int pf)
        {
            int status = -1;
            status = HZC6C0008_SetTPFParam(canid, id, axis, pf, (int)(maxsp * 1000), accstep);
            //Exception(DateTime.Now, "HZC6C0008_SetTPFParam", status, 0);
            return status;
        }
        public int PfMove(int axis, int pos, int pf,bool Move)
        {
            int status = -1;
            //if (axis == 6 && id == 6) return 0;
            if(Move) status = HZC6C0008_PfMove(canid, id, axis, pos, pf);
   
           // Exception(DateTime.Now, "HZC6C0008_PfMove", status, 0);
            return status;
        }
        public int PfChangeMove(int axis, int pos, int pf)
        {
            return 0;
        }
        public int CnstMove(int axis, double speed, int pos)
        {
            int status = -1;
            //if (axis == 6 && id == 6) return 0;
            status = HZC6C0008_ConstMove(canid, id, axis, pos, (int)(speed * 1000));
           // Exception(DateTime.Now, "HZC6C0008_ConstMove", status, 0);
            return status;
        }
        public int GetStatus(int axis)
        {
            int status = -1;
            int tem = -1;
            int result = -1;
            status = HZC6C0008_GetStatus(canid, id, axis, ref tem);
    
            if (status != 0) return -1;
            return result=(tem>>2)& 1;
            //return result=(tem >> 4) & 1;
        }
        public int SetPos(int axis, int pos)
        {
            int status = -1;
            status = HZC6C0008_SetPos(canid, id, axis, pos);
            //Exception(DateTime.Now, "HZC6C0008_SetPos", status, 0);
            return status;
        }
        public int GetPos(int axis)
        {
            int status = -1;
            int pos = 0;
            status = HZC6C0008_GetPos(canid, id, axis, ref pos);
            //Exception(DateTime.Now, "HZC6C0008_GetPos", status, 0);
            if (status != 0) return status;
            return pos;
        }
        public int AbortMoving(int axis)
        {
            int status = -1;
            status = HZC6C0008_Stop(canid, id, axis);
           // Exception(DateTime.Now, "HZC6C0008_Stop", status, 0);
            return status;
        }
        public int SetMtrLimit(int axis, int npos, int ppos)
        {
            int status = -1;
            status = HZC6C0008_SetPLimit(canid, id, axis, ppos);
            //Exception(DateTime.Now, "HZC6C0008_SetPLimit", status, 0);
            if (status != 0) return status;
            status = HZC6C0008_SetNLimit(canid, id, axis, npos);
            //Exception(DateTime.Now, "HZC6C0008_SetNLimit", status, 0);
            return status;
        }
        public int GetEncPos(int axis)
        {
            //int status = -1;
            //int pos = 0;
            //status = HZC6C0008_GetEncPos(canid, id, axis, ref pos);
            //Exception(DateTime.Now, "HZC6C0008_GetEncPos", status, 0);
            //if (status != 0) return status;
            //return pos;
            return 0;
        }
        public int SetEncPos(int axis, int pos)
        {
            //int status = -1;
            //status = HZC6C0008_SetEncPos(canid, id, axis, pos);
            //Exception(DateTime.Now, "HZC6C0008_SetEncPos", status, 0);
            //return status;
            return 0;
        }
        public int ServerOn(int axis)
        {
            int status = -1;
            status = HZC6C0008_ServerOn(canid, id, axis);
            //Exception(DateTime.Now, "HZC6C0008_ServerOn", status, 0);
            int stat = 0;
             HZC6C0008_GetStatus(canid, id, axis, ref stat);
             int alarm = (stat >> 2) & 1;
            return status;
        }
        public int ServerOff(int axis)
        {
            int status = -1;
            status = HZC6C0008_ServerOff(canid, id, axis);
           // Exception(DateTime.Now, "HZC6C0008_ServerOff", status, 0);
            return status;
        }

        public int ClearLimitStatus(int axis)
        {
            return -1;
        }
        #endregion

        #region  IPort
        public int GetInputPort(int channelid)
        {
            int status = -1;
            int value = 0;
            //status = HZC6C0008_GetInputBit(canid, id, ref  value);
            //Exception(DateTime.Now, "HZC6C0002_GetInputBit", status, 0);
            if (status != 0) return -1;
            return (value >> channelid) & 1;
        }

        public int GetOutputPort(int channid)
        {
            int status = 1;
            int value = 0;
            status = HZC6C0008_GetOutputBit(canid, id, channid, ref value);
           // Exception(DateTime.Now, "HZC6C0008_GetOutputBit", status, 0);
            if (status != 0) return -1;
            return value;
            //return (value >> channid) & 1;
        }
        public int SetOutputPort(int channid, bool setoutnot)
        {
            int status = -1;
            if (setoutnot)
            {
                status = HZC6C0008_SetOutputBit(canid, id, channid);
               // Exception(DateTime.Now, "HZC6C0008_SetOutputBit", status, 0);
            }
            else
            {
                status = HZC6C0008_ClearOutputBit(canid, id, channid);
                //Exception(DateTime.Now, "HZC6C0008_ClearOutputBit", status, 0);
            }
            return status;
        }
        public void CloseAllOutputProt()
        {

        }
        #endregion

        #region  IPWM

        public int SetPwmValue(int channid, int value)
        {
            int status = -1;
            status = HZC6C0008_SetPwmValue(canid, id, channid, value);
            //Exception(DateTime.Now, "HZC6C0008_SetPwmValue", status, 0);
            return status;
        }
        public int GetPwmValue(int channel)
        {
            return 0;
        }
        public int Pwm_Hardware_Set(int trID, int[] val)
        {
            return 0;
        }

        #endregion

        #region  adc
        public int GetAdcValue(int channel)
        {
            int status = -1;
            int value = 0;
            status = HZC6C0008_GetAdcValue(canid, id, channel, ref value);
           // Exception(DateTime.Now, "HZC6C0008_GetAdcValue", status, 0);
            return value;
        }

        #endregion

        #region IExPort
        public int GetAxisSensor(int snrno)
        {

            int axisid = snrno / 10;  //改  ；10
            int bit = snrno % 10;     //
            int value = 0;
            int status = -1;
            status = HZC6C0008_GetStatus(canid, id, axisid, ref value);
            //Exception(DateTime.Now, "HZC6C0008_GetStatus", status, 0);
            return (value >> (bit)) & 1;


        }
        #endregion

        #region Ihard_home

        public int SearchForhomepos(int axis, int snrsts, int dist, int pf)
        {
            int status = -1;
            status = HZC6C0008_SearchSns(canid, id, axis, snrsts, pf, dist);
            //Exception(DateTime.Now, "HZC6C0008_SearchSns", status, 0);
            return status;
        }

        #endregion
    }



}