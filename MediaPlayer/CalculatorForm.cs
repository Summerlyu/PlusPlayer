using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MediaPlayer
{
    public partial class CalculatorForm : Form
    {
        //***往下为自已定义的变量***
        //定义存放运算符(包括:'+','-',...,'sin',...,'arcsin',...,'(',...等)及其特性的数据结构
        public struct opTable   //定义存放运算符及其优先级和单双目的结构
        {
            public string op;   //用于存放运算符 op为oprater的简写 
            public int code;    //用存放运算符的优先级
            public char grade;  //用于判断存放的运算符是单目还是双目
        }
        public opTable[] opchTbl = new opTable[19];  //用于存放制定好的运算符及其特性(优先级和单双目)的运算符表,其初始化在方法Initialize()中
        public opTable[] operateStack = new opTable[30];	//用于存放从键盘扫描的运算符的栈	

        //定义优先级列表 1,2,3,4,5,6,7,8,9,
        public int[] osp = new int[19] { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 5, 3, 3, 2, 2, 7, 0, 1 };  //数组中元素依次为: "sin","cos","tan","cot","arcsin","arccos","arctan","sec","csc","ln","^","*","/","+","-","(",")",""   的栈外(因为有的运算符是从右向左计算,有的是从左往右计算,用内外优先级可以限制其执行顺序)优先级
        public int[] isp = new int[18] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 4, 3, 3, 2, 2, 1, 1 };      //数组中元素依次为: "sin","cos","tan","cot","arcsin","arccos","arctan","sec","csc","ln","^","*","/","+","-","(" ,"end" 的栈内(因为有的运算符是从右向左计算,有的是从左往右计算,用内外优先级可以限制其执行顺序)优先级

        //定义存放从键盘扫描的数据的栈
        public double[] dataStack = new double[30] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        //定义表态指针
        public int opTop = -1;  //指向存放(从键盘扫描的)运算符栈的指针
        public int dataTop = -1;//指向存放(从键盘扫描的)数据栈指针

        //定义存放从键盘输入的起始字符串
        public string startString;
        public int startTop = 0;

        public double variableX = 0;
        public double variableY = 0;

        const double PI = 3.1415926;

        int number = 1;
        public int startTopMoveCount = 0;
        //*******
        //int x=0;
        public CalculatorForm()
        {
            InitializeComponent();
        }
        public void InitializeOpchTblStack()  //制定运算符及其特性(优先级和单双目)的运算符表
        {
            opchTbl[0].op = "sin"; opchTbl[0].code = 1; opchTbl[0].grade = 's';
            opchTbl[1].op = "cos"; opchTbl[1].code = 2; opchTbl[1].grade = 's';
            opchTbl[2].op = "tan"; opchTbl[2].code = 3; opchTbl[2].grade = 's';
            opchTbl[3].op = "cot"; opchTbl[3].code = 4; opchTbl[3].grade = 's';
            opchTbl[4].op = "arcsin"; opchTbl[4].code = 5; opchTbl[4].grade = 's';
            opchTbl[5].op = "arccos"; opchTbl[5].code = 6; opchTbl[5].grade = 's';
            opchTbl[6].op = "arctan"; opchTbl[6].code = 7; opchTbl[6].grade = 's';
            opchTbl[7].op = "arccot"; opchTbl[7].code = 8; opchTbl[7].grade = 's';
            opchTbl[8].op = "sec"; opchTbl[8].code = 9; opchTbl[8].grade = 's';
            opchTbl[9].op = "csc"; opchTbl[9].code = 10; opchTbl[9].grade = 's';
            opchTbl[10].op = "ln"; opchTbl[10].code = 11; opchTbl[10].grade = 's';
            opchTbl[11].op = "^"; opchTbl[11].code = 12; opchTbl[11].grade = 'd';
            opchTbl[12].op = "*"; opchTbl[12].code = 13; opchTbl[12].grade = 'd';
            opchTbl[13].op = "/"; opchTbl[13].code = 14; opchTbl[13].grade = 'd';
            opchTbl[14].op = "+"; opchTbl[14].code = 15; opchTbl[14].grade = 'd';
            opchTbl[15].op = "-"; opchTbl[15].code = 16; opchTbl[15].grade = 'd';
            opchTbl[16].op = "("; opchTbl[16].code = 17; opchTbl[16].grade = 'd';
            opchTbl[17].op = ")"; opchTbl[17].code = 18; opchTbl[17].grade = 'd';
            opchTbl[18].op = " "; opchTbl[18].code = 19; opchTbl[18].grade = 'd';
            startString = expressBox.Text;
        }
        #region---------------------------CreterionFaction------------------------------------
        public void CreterionFaction()
        {
            //以下为消去待扫描字符串中的所有空格字符
            for (int i = 0; i < startString.Length; i++)
                if (startString[i].Equals(' '))
                {
                    startString = startString.Remove(i, 1);
                    i--;
                }
            //以下代码使待扫描字符串的单目('+'和'-')变为双目
            if (startString.Length != 0)
                if (startString[0] == '+' || startString[0] == '-')
                {
                    startString = startString.Insert(0, "0");
                }
            for (int i = 0; i < startString.Length - 1; i++)
            {
                if ((startString[i] == '(') && (startString[i + 1] == '-'))
                    startString = startString.Insert(i + 1, "0");
            }
            startString = startString.Insert(startString.Length, ")");
            //将待扫描字符串字号字母转化为小写字母
            startString = startString.ToLower();

        }
        #endregion

        #region---------------------------检查括号是否匹配------------------------------------
        public bool CheckParentthese() //检查括号是否匹配
        {
            int number = 0;
            for (int i = 0; i < startString.Length - 1; i++)
            {
                if (i == '(') number++;
                if (i == ')') number--;
                if (number < 0) return false;
            }
            if (number != 0)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region-------------------------------给运算表达式分块--------------------------------
        public int CheckFollowCorrect()    //给运算表达式分块(三角函数...算术运算符等),再根据其返回值来检验其属于哪类错误
        {
            string str, oldString = "", newString = "";
            int dataCount = 0, characterCount = 0;
            if (startString.Equals(")"))
                return 0;         //输入字符串为空返回值
            if ((startString[0] == '*') || (startString[0] == '/') || (startString[0] == '^') || (startString[0] == ')'))
                return 11;        //首字符输入错误返回值
            for (int i = 0; i < startString.Length; i++)
            {
                if ((oldString.Equals("三角函数")) && (newString.Equals("右括号")))
                    return 2;     //三角函数直接接右括号错误返回值
                if ((oldString.Equals("左括号")) && (newString.Equals("算术运算符")))
                    return 3;     //左括号直接接算术运算符错误返回值
                if ((oldString.Equals("数字序列")) && (newString.Equals("三角函数")))
                    return 4;     //数字序列后直接接三角函数错误返回值
                if ((oldString.Equals("数字序列")) && (newString.Equals("左括号")))
                    return 5;     //数字序列后直接接左括号错误返回值
                if ((oldString.Equals("算术运算符")) && (newString.Equals("右括号")))
                    return 6;     //算术运算符后直接接右括号错误返回值
                if ((oldString.Equals("右括号")) && (newString.Equals("左括号")))
                    return 7;     //右括号直接接左括号错误返回值
                if ((oldString.Equals("右括号")) && (newString.Equals("三角函数")))
                    return 8;     //右括号直接接三角函数错误返回值
                if ((oldString.Equals("数字序列")) && (newString.Equals("数字序列")))
                    return 9;     //数字序列后直接接'pi'/'e'或'pi'/'e'直接接数字序列错误返回值
                if ((oldString.Equals("算术运算符")) && (newString.Equals("算术运算符")))
                    return 10;     //算术运算符后直接接算术运算符错误返回值
                oldString = newString;
                if (i < startString.Length - 5 && startString.Length >= 6)
                {
                    str = startString.Substring(i, 6);
                    if ((str.CompareTo("arcsin") == 0) || (str.CompareTo("arccos") == 0) || (str.CompareTo("arctan") == 0) || (str.CompareTo("arccot") == 0))
                    {
                        newString = "三角函数";
                        i += 5; characterCount++;
                        continue;
                    }
                }
                if (i < startString.Length - 2 && startString.Length >= 3)
                {
                    str = startString.Substring(i, 3);
                    if ((str.CompareTo("sin") == 0) || (str.CompareTo("cos") == 0) || (str.CompareTo("tan") == 0) || (str.CompareTo("cot") == 0) || (str.CompareTo("sec") == 0) || (str.CompareTo("csc") == 0))
                    {
                        newString = "三角函数";
                        i += 2; characterCount++;
                        continue;
                    }
                }
                if (i < (startString.Length - 1) && (startString.Length) >= 2)
                {
                    str = startString.Substring(i, 2);
                    if (str.CompareTo("ln") == 0)
                    {
                        newString = "三角函数";
                        i += 1; characterCount++;
                        continue;
                    }
                    if (str.CompareTo("pi") == 0)
                    {
                        newString = "数字序列";
                        i += 1; dataCount++;
                        continue;
                    }
                }
                str = startString.Substring(i, 1);
                if (str.Equals("^") || str.Equals("*") || str.Equals("/") || str.Equals("+") || str.Equals("-"))
                {
                    newString = "算术运算符";
                    characterCount++;
                    continue;
                }
                if (str.Equals("e"))
                {
                    newString = "数字序列";
                    dataCount++;
                    continue;
                }
                if (str.Equals("("))
                {
                    newString = "左括号";
                    characterCount++;
                    continue;
                }
                if (str.Equals(")"))
                {
                    newString = "右括号";
                    characterCount++;
                    continue;
                }
                if (Char.IsDigit(startString[i]))
                {
                    while (Char.IsDigit(startString[i]))
                    {
                        i++;
                    }
                    if (startString[i] == '.' && (!Char.IsDigit(startString[i + 1])) && (i + 1) != startString.Length)
                        return 13;
                    if (startString[i] == '.')
                    {
                        i++;
                    }
                    while (Char.IsDigit(startString[i]))
                    {
                        i++;
                    }
                    newString = "数字序列";
                    i--; dataCount++;
                    continue;
                }
                return 1;         //非法字符
            }
            if ((dataCount == 0 && characterCount != 0) || (startString[0] == '0' && dataCount == 1 && characterCount > 1 && startString.Length != 2))
                return 12;
            return 100;
        }
        #endregion

        #region-----------------------------判断是运算符还是数字------------------------------
        public int IsCharacterOrData(ref double num)
        {
            string str = "";
            startTop += startTopMoveCount; startTopMoveCount = 0;
            int i = startTop;
            if (i < startString.Length - 5 && startString.Length >= 6)
            {
                str = startString.Substring(i, 6);
                for (int j = 4; j <= 7; j++)
                    if (str.Equals(opchTbl[j].op))
                    {
                        startTopMoveCount = 6;
                        return opchTbl[j].code;
                    }
            }
            if (i < startString.Length - 2 && startString.Length >= 3)
            {
                str = startString.Substring(i, 3);
                for (int j = 0; j < 10; j++)
                    if (str.CompareTo(opchTbl[j].op) == 0)
                    {
                        startTopMoveCount = 3;
                        return opchTbl[j].code;
                    }
            }
            if (i < (startString.Length - 1) && (startString.Length) >= 2)
            {
                str = startString.Substring(i, 2);
                if (str.CompareTo("ln") == 0)
                {
                    startTopMoveCount = 2;
                    return 11;
                }
                if (str.CompareTo("pi") == 0)
                {
                    startTopMoveCount = 2;
                    num = Math.PI;
                    return 100;
                }
            }
            //以下开始确认一个字符是属于什么值类型
            if (i < startString.Length)
            {
                str = startString.Substring(i, 1);
                for (int j = 11; j < 19; j++)
                {
                    if (str.Equals(opchTbl[j].op))
                    { startTopMoveCount = 1; return opchTbl[j].code; }
                }
                if (str.CompareTo("e") == 0)
                {
                    startTopMoveCount = 1; num = Math.E;
                    return 100;
                }
                if (Char.IsDigit(startString[i]))
                {
                    double temp = 0, M = 10; int j = i;
                    while (Char.IsDigit(startString[j]))
                    {
                        temp = M * temp + Char.GetNumericValue(startString[j]);
                        startTop++;
                        j++;
                    }
                    if (startString[j] == '.')
                    {
                        j++; startTop++;
                    }
                    while (Char.IsDigit(startString[j]))
                    {
                        temp += 1.0 / M * Char.GetNumericValue(startString[j]);
                        M /= 10; j++;
                        startTop++;
                    }
                    startTopMoveCount = 0;
                    num = temp;
                    return 100;
                }
            }
            return -1;
        }
        #endregion

        #region---------------------------------双目运算--------------------------------------
        public double DoubleCount(string opString, double data1, double data2)
        {    
            if (opString.CompareTo("+") == 0) return (data1 + data2);
            if (opString.CompareTo("-") == 0) return (data1 - data2);
            if (opString.CompareTo("*") == 0) return (data1 * data2);
            if (opString.CompareTo("/") == 0) return (data1 / data2);
            if (opString.CompareTo("^") == 0)
            {
                double end = data1;
                for (int i = 0; i < data2 - 1; i++)
                    end *= data1;
                return (end);
            }
            return Double.MaxValue;    //定义域不对，返回
        }
        #endregion

        #region----------------------------------单目运算-------------------------------------
        public double DoubleCount(string opString, double data1)
        {  
            if (opString.CompareTo("sin") == 0) return Math.Sin(data1);
            if (opString.CompareTo("cos") == 0) return Math.Cos(data1);
            if (opString.CompareTo("tan") == 0) return Math.Tan(data1);
            if (opString.CompareTo("cot") == 0) return (1 / (Math.Tan(data1)));
            if (opString.CompareTo("arcsin") == 0)
                if (-1 <= data1 && data1 <= 1) return Math.Asin(data1);

            if (opString.CompareTo("arccos") == 0)
                if (-1 <= data1 && data1 <= 1) return Math.Acos(data1);

            if (opString.CompareTo("arctan") == 0)
                if (-Math.PI / 2 <= data1 && data1 <= Math.PI / 2) return Math.Atan(data1);
            if (opString.CompareTo("arccot") == 0)
                if (-Math.PI / 2 <= data1 && data1 <= Math.PI / 2) return (-Math.Atan(data1));
            if (opString.CompareTo("sec") == 0) return (1 / (Math.Cos(data1)));
            if (opString.CompareTo("csc") == 0) return (1 / (Math.Sin(data1)));
            if (data1 > 0) if (opString.CompareTo("ln") == 0) return Math.Log(data1);
            return Double.MaxValue;   //定义域不对
        
        }   
        #endregion

        #region----------------------------------求解表达式-----------------------------------
        public bool CountValueY(ref double tempY)  //方法功能为求得解
        {
            int type = -1;                  //存放正在扫描的字符串是为数字类型还是(单双目运算符)
            double num = 0;                   //如果是数据,则返回数据的值
            //进栈底结束符"end"
            opTop++;
            operateStack[opTop].op = "end"; operateStack[opTop].code = 18; operateStack[opTop].grade = ' ';
            while (startTop <= startString.Length - 1)
            {
            start:
                type = IsCharacterOrData(ref num);  //调用判断返回值类型函数 
             
                if (type == -1) { return false; }
                if (type == 100)
                {
                    dataTop = dataTop + 1;
                    dataStack[dataTop] = num;
                }
                else
                {
                    if (osp[type - 1] > isp[operateStack[opTop].code - 1])   //操作符进栈
                    {
                        opTop++;
                        operateStack[opTop].op = opchTbl[type - 1].op; operateStack[opTop].code = opchTbl[type - 1].code; operateStack[opTop].grade = opchTbl[type - 1].grade;
                    }
                    else
                    {
                        while (osp[type - 1] <= isp[operateStack[opTop].code - 1])  //弹出操作符跟数据计算,并存入数据
                        {
                            if (operateStack[opTop].op.CompareTo("end") == 0)//当遇到"end"结束符表示已经获得结果
                            {
                                if (dataTop == 0)
                                {
                                    tempY = dataStack[dataTop]; startTop = 0; startTopMoveCount = 0; opTop = -1; dataTop = -1;
                                    return true;
                                }
                                else return false;       //运算符和数据的个数不匹配造成的错误
                            }
                            if (operateStack[opTop].op.CompareTo("(") == 0)  //如果要弹出操作数为'( ',则消去左括号
                            {
                                opTop--; goto start;
                            }
                            //弹出操作码和一个或两个数据计算,并将计算结果存入数据栈
                            double data1, data2; opTable operate;
                            if (dataTop >= 0) data2 = dataStack[dataTop];
                            else return false;
                            operate.op = operateStack[opTop].op; operate.code = operateStack[opTop].code; operate.grade = operateStack[opTop].grade;
                            opTop--;                        //处理一次,指针必须仅且只能下移一个单位
                            if (operate.grade == 'd')
                            {
                                if (dataTop - 1 >= 0) data1 = dataStack[dataTop - 1];
                                else return false;
                                double tempValue = DoubleCount(operate.op, data1, data2);
                                if (tempValue != Double.MaxValue) dataStack[--dataTop] = tempValue;
                                else return false;
                            }
                            if (operate.grade == 's')
                            {
                                double tempValue = DoubleCount(operate.op, data2);
                                if (tempValue != Double.MaxValue)
                                    dataStack[dataTop] = tempValue;
                                else return false;
                            }
                        }
                        //如果当前栈外操作符比栈顶的操作符优先级别高,则栈外操作符进栈
                        opTop++;
                        operateStack[opTop].op = opchTbl[type - 1].op; operateStack[opTop].code = opchTbl[type - 1].code; operateStack[opTop].grade = opchTbl[type - 1].grade;
                    }
                }
            }
            return false;
        }
        #endregion

        #region----------------------------------开始执行-------------------------------------
        public void StartExcute()
        {
            InitializeOpchTblStack();
            CreterionFaction();
            if (CheckParentthese() == false)
            {
                MessageBox.Show("括号不匹配,请重新输入!!!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            switch (CheckFollowCorrect())
            {
                case 0: MessageBox.Show("表达式为空,请先输入表达式!!!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
                case 1: MessageBox.Show("表达式中有非法字符!!!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                case 2: MessageBox.Show("三角函数运算符与 ) 之间应输入数据或其它表达式!!!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                case 3: MessageBox.Show("' (  ' 与算术运算符之间应输入数据或其它表达式!!!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                case 4: MessageBox.Show("数字数列与三角函数之间应输入算术运算符或其它表达式!!!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                case 5: MessageBox.Show("数字数列与  ' (  '  之间应输入算术运算符或其它表达式!!!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                case 6: MessageBox.Show("算术运算符与右括号之间应输入数据或其它表达式!!!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                case 7: MessageBox.Show("'  )  ' 与 '  (  ' 之间应输入算术运算符或其它表达式!!!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                case 8: MessageBox.Show("'   )   ' 与三角函数之间应输入算术运算符或其它表达式!!!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                case 9: MessageBox.Show("常量 '  PI  '  或  '  E  '  或  '  X  '  与数字数据之间应输入算术运算符或其它表达式!!!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                case 10: MessageBox.Show("算术运算符与算术运算符之间应输入数据或其它表达式!!!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                case 11: MessageBox.Show("表达式头部不能为'  +   ', '  -  ' , '  *  ' , '  /  ' , '  ^  ' ,'  )  '!!!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                case 12: MessageBox.Show("仅有运算符号没有数字数据或数据缺少而无法计算,请输入数字数据!!!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                case 13: MessageBox.Show("小数点后面缺少小数部分,请输入小数部分!!!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            double tempY = 0;
            switch (CountValueY(ref tempY))
            {
                case false: MessageBox.Show("输入的表达式不正确或反三角函数定义域在其定义域范围之外!!!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }

            endbox.Text = tempY.ToString();//依次存档计算结果
            endList.Text += "(";
            endList.Text += number;
            endList.Text += "). ";
            number++;
            endList.Text += endbox.Text;
            endList.Text += "   ";
        }
        #endregion

        #region-------------------------------各种按钮监听------------------------------------
        private void btn_Equal_Click(object sender, EventArgs e)
        {
            StartExcute();
        }
        private void btn_minus_Click(object sender, EventArgs e)
        {
            expressBox.SelectedText = null;
            expressBox.Text = expressBox.Text.Insert(expressBox.SelectionStart, btn_minus.Text);
            expressBox.SelectionStart = expressBox.TextLength;
        }
       

        private void btnClear_Click(object sender, EventArgs e)
        {
            endList.Text = "";
            number = 1;
        }

        private void btnBackSpace_Click(object sender, EventArgs e)
        {
            if (expressBox.Text.Length > 0)
                expressBox.Text = expressBox.Text.Remove(expressBox.Text.Length - 1, 1);
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            expressBox.Text = "";
            endbox.Text = "0.000000";
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            expressBox.SelectedText = null;
            expressBox.Text = expressBox.Text.Insert(expressBox.SelectionStart, btn_7.Text);
            expressBox.SelectionStart = expressBox.TextLength;
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            expressBox.SelectedText = null;
            expressBox.Text = expressBox.Text.Insert(expressBox.SelectionStart, btn_8.Text);
            expressBox.SelectionStart = expressBox.TextLength;
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            expressBox.SelectedText = null;
            expressBox.Text = expressBox.Text.Insert(expressBox.SelectionStart, btn_9.Text);
            expressBox.SelectionStart = expressBox.TextLength;
        }

        private void btnLbracket_Click(object sender, EventArgs e)
        {
            expressBox.SelectedText = null;
            expressBox.Text = expressBox.Text.Insert(expressBox.SelectionStart, btnLbracket.Text);
            expressBox.SelectionStart = expressBox.TextLength;
        }

        private void btnRbracket_Click(object sender, EventArgs e)
        {  
            expressBox.SelectedText = null;
            expressBox.Text = expressBox.Text.Insert(expressBox.SelectionStart, btnRbracket.Text);
            expressBox.SelectionStart = expressBox.TextLength;
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            expressBox.SelectedText = null;
            expressBox.Text = expressBox.Text.Insert(expressBox.SelectionStart, btn_4.Text);
            expressBox.SelectionStart = expressBox.TextLength;
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            expressBox.SelectedText = null;
            expressBox.Text = expressBox.Text.Insert(expressBox.SelectionStart, btn_5.Text);
            expressBox.SelectionStart = expressBox.TextLength;
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            expressBox.SelectedText = null;
            expressBox.Text = expressBox.Text.Insert(expressBox.SelectionStart, btn_6.Text);
            expressBox.SelectionStart = expressBox.TextLength;
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            expressBox.SelectedText = null;
            expressBox.Text = expressBox.Text.Insert(expressBox.SelectionStart, btn_1.Text);
            expressBox.SelectionStart = expressBox.TextLength;
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            expressBox.SelectedText = null;
            expressBox.Text = expressBox.Text.Insert(expressBox.SelectionStart, btn_2.Text);
            expressBox.SelectionStart = expressBox.TextLength;
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            expressBox.SelectedText = null;
            expressBox.Text = expressBox.Text.Insert(expressBox.SelectionStart, btn_3.Text);
            expressBox.SelectionStart = expressBox.TextLength;
        }

        private void btn_0_Click(object sender, EventArgs e)
        {
            expressBox.SelectedText = null;
            expressBox.Text = expressBox.Text.Insert(expressBox.SelectionStart, btn_0.Text);
            expressBox.SelectionStart = expressBox.TextLength;

        }

        private void btn_DEL_Click(object sender, EventArgs e)
        {
            expressBox.SelectedText = null;
            expressBox.Text = expressBox.Text.Insert(expressBox.SelectionStart, ".");
            expressBox.SelectionStart = expressBox.TextLength;
        }

        private void btn_divide_Click(object sender, EventArgs e)
        {
            expressBox.SelectedText = null;
            expressBox.Text = expressBox.Text.Insert(expressBox.SelectionStart, btn_divide.Text);
            expressBox.SelectionStart = expressBox.TextLength;   
        }

        private void btnMulti_Click(object sender, EventArgs e)
        {
            expressBox.SelectedText = null;
            expressBox.Text = expressBox.Text.Insert(expressBox.SelectionStart, btnMulti.Text);
            expressBox.SelectionStart = expressBox.TextLength;
        }

        private void btnRewrite_Click(object sender, EventArgs e)
        {
            expressBox.Text = "";
        }
       

        private void btn_plus_Click(object sender, EventArgs e)
        {
            expressBox.SelectedText = null;
            expressBox.Text = expressBox.Text.Insert(expressBox.SelectionStart, btn_plus.Text);
            expressBox.SelectionStart = expressBox.TextLength;
        }
        #endregion

        //移动窗体
        const int WM_NCLBUTTONDOWN = 0xA1;
        const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        //窗体上鼠标按下时
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left & this.WindowState == FormWindowState.Normal)
            {
                // 移动窗体
                this.Capture = false;
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnmin_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.ShowInTaskbar = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
