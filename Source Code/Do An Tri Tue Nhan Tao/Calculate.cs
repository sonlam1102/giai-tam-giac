using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Do_An_Tri_Tue_Nhan_Tao
{
    class Calculate
    {
        double[] c;
        int dem = 0;
        String s = "";
        Double Result = 0;
        public Calculate(String st)
        {
            s = st;
        }
        public static bool IsEmpty(Stack c)
        {
            if (c.Count == 0)
                return true;
            else
                return false;
        }
        public int prio(char a)
        {
            if ( a == 'v' || a=='^')
                return 4;
            if (a == 'i' || a == 'c' || a == 'r')
                return 3;
            if (a == '*' || a == '/')
                return 2;
            if (a == '+' || a == '-')
                return 1;
            return 0;
        }
        public void chuyenkyphap()
        {
            Stack a = new Stack();
            c = new double[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] >= '0' && s[i] <= '9')
                {
                    double temp = 0;
                    char ch = s[i];
                    while (ch >= '0' && ch <= '9')
                    {
                        temp = temp * 10 + ch - 48;
                        if (i >= s.Length -1)
                            break;
                        else
                        {
                            i++;
                            ch = s[i];
                        }
                    }
                    if (s[i] == '.')
                    {
                        i++;
                        ch = s[i];
                        double r = 1;
                        double t = 0;
                        while (ch >= '0' && ch <= '9')
                        {
                            r = r / 10;
                            t = t + ((s[i] - 48) * r);
                            if (i >= s.Length - 1)
                                break;
                            else
                            {
                                i++;
                                ch = s[i];
                            }
                        }
                        temp = temp + t;
                    }
                    c[dem] = temp;
                    dem++;
                }
                if (s[i] == '+' || s[i] == '-' || s[i] == '*' || s[i] == '/' ||s[i]=='v' || s[i]=='r'|| s[i]=='i' || s[i]=='c')
                {
                    if (IsEmpty(a) == true)
                        if(s[i]=='r')
                        {
                            if(s[i+2]=='s')
                                a.Push('w');
                            else
                                a.Push('z');
                            i = i + 4;
                        }
                        else
                            a.Push((char)(s[i]));
                    else
                        if (prio(s[i]) <= prio((char)(a.Peek())))
                        {
                            c[dem] = (char)(a.Pop());
                            dem++;
                            if (s[i] == 'r')
                            {                                
                                if (s[i + 2] == 's')
                                    a.Push('w');
                                else
                                    a.Push('z');
                                i = i + 4;
                            }
                            else
                                a.Push((char)(s[i]));
                        }
                        else
                            if (s[i] == 'r')
                            {
                                if (s[i + 2] == 's')
                                    a.Push('w');
                                else
                                    a.Push('z');
                                i = i + 4;
                            }
                            else
                                a.Push((char)(s[i]));
                }
                if (s[i] == '(')                 
                    a.Push((char)(s[i]));
                if (s[i] == ')')
                {
                    char ch;
                    do
                    {
                        ch = Convert.ToChar(a.Pop());
                        if (ch != '(')
                        {
                            c[dem] = ch;
                            dem++;
                        }
                    }
                    while (ch != '(');
                }
            }
            while (IsEmpty(a) != true)
            {
                c[dem] = Convert.ToChar(a.Pop());
                dem++;
            }
        }
        public void ketqua()
        {
            Stack b = new Stack();
            for (int i = 0; i < dem; i++)
            {
                switch ((int)c[i])
                {
                    case '+':
                        {
                            double a, k;
                            a = (double)(b.Pop());
                            k = (double)(b.Pop());
                            b.Push(a + k);
                            break;
                        }
                    case '-':
                        {
                            double a, k;
                            a = (double)(b.Pop());
                            k = (double)(b.Pop());
                            b.Push(k - a);
                            break;
                        }
                    case '*':
                        {
                            double a, k;
                            a = (double)(b.Pop());
                            k = (double)(b.Pop());
                            b.Push(a * k);
                            break;
                        }
                    case '/':
                        {
                            double a, k;
                            a = (double)(b.Pop());
                            k = (double)(b.Pop());
                            b.Push(k / a);
                            break;
                        }
                    case 'i':
                        {
                            double a;
                            a = (double)(b.Pop());
                            b.Push(Math.Sin((a / 180) * 3.14));
                            break;
                        }
                    case 'c':
                        {
                            double a;
                            a = (double)(b.Pop());
                            b.Push(Math.Cos((a / 180) * 3.14));
                            break;
                        }
                    case 'w':
                        {
                            double a;
                            a = (double)(b.Pop());
                            b.Push((Math.Asin(a)/3.14)*180);
                            break;
                        }
                    case 'z':
                        {
                            double a;
                            a = (double)(b.Pop());
                            b.Push((Math.Acos(a) / 3.14) * 180);
                            break;
                        }
                    case 'v':
                        {
                            double a;
                            a = (double)(b.Pop());
                            b.Push(Math.Sqrt(a));
                            break;
                        }
                    default:
                        {
                            b.Push((double)c[i]);
                            break;
                        }
                }
            }
            Result = Convert.ToDouble(b.Pop());  
        }
        public void Processing()
        {
            chuyenkyphap();
            ketqua();
        }
        public double returnKq()
        {
            return this.Result;
        }
    }   
}
