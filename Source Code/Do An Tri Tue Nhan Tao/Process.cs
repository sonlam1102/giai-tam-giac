using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Do_An_Tri_Tue_Nhan_Tao
{
    class Process
    {
        String src="";
        String dest="";
        List<Rules> lRules;
        List<Rules> lResult;
        ForwardReasoning f_Reason;
        
        public Process(String s,String d)
        {
            this.src = s;
            this.dest = d;
        }
        public void ReadRulesFromFile()
        {
            lRules = new List<Rules>();
           try
           {
               StreamReader inRule = File.OpenText("TriangleKnowldge.txt");
                while(!inRule.EndOfStream)
                {
                    String buffer="";
                    Rules r = new Rules();
                    buffer=inRule.ReadLine();
                    r = GetRules(buffer);
                    lRules.Add(GetRules(buffer));
                }
           }
           catch(FileNotFoundException e)
           {
               MessageBox.Show("File Not Found!");
           }
        }
        public Rules GetRules(String s)
        {
            Rules r=new Rules();
            for (int i = 0; i < s.Length; i++) 
            {               
                while(s[i]!='-')
                {
                    if (s[i] == '^')
                        i++;
                    else
                        if(s[i]=='h')
                        {
                            String tmp = "h" + s[i + 1];
                            if(tmp=="ha")
                                r.inputA('x');
                            if (tmp == "hb")
                                r.inputA('y');
                            if (tmp == "hc")
                                r.inputA('z');
                            i += 2;
                        }
                    else
                    {
                        r.inputA(s[i]);
                        i++;
                    }
                }
                i+=2;
                while(s[i]!='=')
                {
                    if (s[i] == '^')
                        i++;
                    else
                        if (s[i] == 'h')
                        {
                            String tmp = "h" + s[i + 1];
                            if (tmp == "ha")
                                r.inputB('x');
                            if (tmp == "hb")
                                r.inputB('y');
                            if (tmp == "hc")
                                r.inputB('z');
                            i += 2;
                        }
                    else
                    {
                        r.inputB(s[i]);
                        i++;
                    }
                } 
                i++;
                while(i<s.Length)
                {
                    r.inputC(s[i]);
                    i++;
                }
            }
            return r;
        }

        public String ReplaceNumber(String tmp,String a, String b, String c, String A, String B, String C, String ha, String hb,String hc, String p ,String S)
        {
            String bt = "";
            for (int j = 0; j < tmp.Length; j++)
            {
                if ((tmp[j] >= '0' && tmp[j] <= '9'))
                    bt += tmp[j];
                else
                    if (tmp[j] == '+' || tmp[j] == '-' || tmp[j] == '*' || tmp[j] == '/' || tmp[j] == '(' || tmp[j] == ')')
                        bt += tmp[j];
                    else
                    {
                        if (tmp[j] == 'v')
                            bt += "v";
                        if (tmp[j] == 'h')
                        {
                            if (tmp[j + 1] == 'a')
                            {
                                bt += ha;
                                j += 1;
                            }
                            if (tmp[j + 1] == 'b')
                            {
                                bt += hb;
                                j += 1;
                            }
                            if (tmp[j + 1] == 'c')
                            {
                                bt += hc;
                                j += 1;
                            }

                        }
                        else
                        {
                            if (tmp[j] == 'a')
                                if (j < tmp.Length - 1)
                                    if (tmp[j + 1] == 'r')
                                    {
                                        bt += "arc";
                                        j += 3;
                                    }
                                    else
                                        bt += a;
                                else
                                    bt += a;
                            if (tmp[j] == 'b')
                                bt += b;
                            if (tmp[j] == 'c')
                                if (j < tmp.Length - 1)
                                    if (tmp[j + 1] == 'o')
                                    {
                                        bt += "cos";
                                        j += 2;
                                    }
                                    else
                                        bt += c;
                                else
                                    bt += c;
                            if (tmp[j] == 'A')
                                bt += A;
                            if (tmp[j] == 'B')
                                bt += B;
                            if (tmp[j] == 'C')
                                bt += C;
                            if (tmp[j] == 's')
                            {
                                if (tmp[j + 1] == 'i')
                                {
                                    bt += "sin";
                                    j += 2;
                                }
                            }
                            if (tmp[j] == 'p')
                                bt += p;
                            if (tmp[j] == 'S')
                                bt += S;
                        }
                    }
            }
            return bt;
        }
        public void Processing()
        {
            ReadRulesFromFile();
            f_Reason = new ForwardReasoning(src, dest, lRules);
            f_Reason.Processing();
            lResult = f_Reason.returnResult();
        }
        public void Computing(String va,String vb,String vc,String vA,String vB,String vC,String vha,String vhb,String vhc)
        {
            String a, b, c, A, B, C, ha, hb, hc, p, S;
            a = va; b = vb; c = vc;
            A = vA; B = vB; C = vC;
            if (A == "")
                A = "0";
            if (B == "")
                B = "0";
            if (C == "")
                C = "0";
            p = "0";
            S = "0";
            ha = vha; hb = vhb; hc = vhc;
            Processing();
            if (Convert.ToInt32(A) + Convert.ToInt32(B) + Convert.ToInt32(C) <= 180)
            {
                
                for (int i = 0; i < lResult.Count; i++)
                {
                    String tmp = lResult[i].returnC();
                    String bt = "";
                    bt = ReplaceNumber(tmp, a, b, c, A, B, C, ha, hb, hc, p,S);
                    lResult[i].setD(bt);

                    Calculate cal = new Calculate(bt);

                    cal.Processing();
                    lResult[i].setE(Convert.ToString(cal.returnKq()));
                    if (lResult[i].returnB() == "a")
                        a = Convert.ToString(cal.returnKq());
                    if (lResult[i].returnB() == "b")
                        b = Convert.ToString(cal.returnKq());
                    if (lResult[i].returnB() == "c")
                        c = Convert.ToString(cal.returnKq());
                    if (lResult[i].returnB() == "A")
                        A = Convert.ToString(cal.returnKq());
                    if (lResult[i].returnB() == "B")
                        B = Convert.ToString(cal.returnKq());
                    if (lResult[i].returnB() == "C")
                        C = Convert.ToString(cal.returnKq());
                    if (lResult[i].returnB() == "ha")
                        ha = Convert.ToString(cal.returnKq());
                    if (lResult[i].returnB() == "hb")
                        hb = Convert.ToString(cal.returnKq());
                    if (lResult[i].returnB() == "hc")
                        hc = Convert.ToString(cal.returnKq());
                    if (lResult[i].returnB() == "p")
                        p = Convert.ToString(cal.returnKq());
                    if (lResult[i].returnB() == "S")
                        S = Convert.ToString(cal.returnKq());
                }
            }
            else
            {
                MessageBox.Show("Nhập sai! Tổng 3 góc của tam giác lớn hơn 180");
                lResult.Clear();
            }
        }
        public String getResult()
        {
            String temp = "";
            if (lResult.Count > 0)
            {
                for (int i = 0; i < lResult.Count; i++)
                    temp += lResult[i].returnB() + "=" + lResult[i].returnC() + "=" + lResult[i].returnD() +"\n"+ "=" + lResult[i].returnE() + "\n\n";
            }
            return temp;
        }
        public void Destroy()
        {
            if (lResult.Count >= 0) 
                lResult.Clear();
            if (lRules.Count >= 0) 
                 lRules.Clear();
            
        }
    }
}
