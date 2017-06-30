using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Tri_Tue_Nhan_Tao
{
    class Rules
    {
        String theory="";
        String conclude="";
        String express = "";
        String result = "";
        String Value = "";
        public void inputA(char c)
        {
            theory += c;
        }
        public void inputB(char c)
        {
            conclude += c;
        }
        public void inputC(char c)
        {
            express += c;
        }
        public void inputD(char c)
        {
            result += c;
        }
        public void inputE(char c)
        {
            Value += Value;
        }
        public String returnA()
        {
            return theory;
        }
        public String returnB()
        {
            return conclude;
        }
        public String returnC()
        {
            return express;
        }
        public String returnD()
        {
            return result;
        }
        public String returnE()
        {
            return Value;
        }
        public void setA(String a)
        {
            theory = a;
        }
        public void setB(String b)
        {
            conclude = b;
        }
        public void setC(String b)
        {
            express = b;
        }
        public void setD(String b)
        {
            result = b;
        }
        public void setE(String b)
        {
            Value = b;
        }
    }
}