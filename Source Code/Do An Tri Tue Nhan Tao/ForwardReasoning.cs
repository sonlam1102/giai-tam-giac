using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Tri_Tue_Nhan_Tao
{
    class ForwardReasoning
    {
        String src;
        String dest;
        List<Rules>lRules=new List<Rules>();
        List<Rules> lResult = new List<Rules>();
        public ForwardReasoning(String src,String dest,List<Rules>lR)
        {
            this.src = src;
            this.dest = dest;
            this.lRules = lR;
        }
       public bool isInLeft(String s,List<Rules>lR)
        {
           for(int i=0;i<lR.Count;i++)
               if(isExist(s,lR[i].returnA())==true)
                   return true;
           return false;
        }
        public void OptimizeResult()
       {
           bool k = true;
           do
           {
               k = true;
               for (int i = 0; i < lResult.Count; i++)
               {
                   if (isInLeft(lResult[i].returnB(), lResult) == false)
                       if (lResult[i].returnB() != dest)
                       {
                           lResult.RemoveAt(i);
                           k = false;
                           break;
                       }
                   if(isExist(lResult[i].returnB(),src))
                   {
                       lResult.RemoveAt(i);
                       k = false;
                       break;
                   }
               }
               for (int i = 0; i < lResult.Count - 1; i++)
                   for (int j = i + 1; j < lResult.Count; j++)
                       if (lResult[i].returnB() == lResult[j].returnB())
                       {
                           lResult.RemoveAt(j);
                           k = false;
                           break;
                       }
           }
           while (k == false);
          
       }
        public bool isInString(char a,String b)
        {
            for (int i = 0; i < b.Length; i++)
                if (a == b[i])
                    return true;
            return false;
        }
        public bool isExist(String a,String b)
        {
            int count = 0;
            for (int i = 0; i < a.Length; i++)
                if (isInString(a[i], b) == true)
                        count++;
            if (count == a.Length)
                return true;
            else
                return false;           
        }
        public int findInString(char a, String b)
        {
            for (int i = 0; i < b.Length; i++)
                if (a == b[i])
                    return i;
            return -1;
        }
        public void normalizeResult()
        {
            for (int i = 0; i < lResult.Count; i++)
            {
                if (lResult[i].returnB() == "x")
                    lResult[i].setB("ha");
                if (lResult[i].returnB() == "y")
                    lResult[i].setB("hb");
                if (lResult[i].returnB() == "z")
                    lResult[i].setB("hc");
            }
            for (int i = 0; i < lResult.Count; i++)
            {
                 if (isInString('x',lResult[i].returnA()))
                 {
                     String tmp = lResult[i].returnA();
                     tmp = tmp.Insert(findInString('x', tmp), "ha");
                     tmp = tmp.Remove(findInString('x', tmp));                  
                     lResult[i].setA(tmp);
                 }
                 if (isInString('y', lResult[i].returnA()))
                 {
                     String tmp = lResult[i].returnA();
                     tmp = tmp.Insert(findInString('y', tmp), "hb");
                     tmp=tmp.Remove(findInString('y', tmp));                   
                     lResult[i].setA(tmp);
                 }
                 if (isInString('z', lResult[i].returnA()))
                 {
                     String tmp = lResult[i].returnA();
                     tmp = tmp.Insert(findInString('z', tmp), "hc");
                     tmp = tmp.Remove(findInString('z', tmp));                    
                     lResult[i].setA(tmp);
                 }
            }
        }
        public String AddtoTemp(String b, String s)
        {
            String tmp=b;
            for (int i = 0; i < s.Length; i++)
                if (isInString(s[i], tmp))
                    continue;
                else
                    tmp += s[i];
            return tmp;
        }
        public void Processing()
        {
            String temp = "";
            temp = temp + src;
            bool k = false;
            do
            {
                k = true;
                    for (int i = 0; i < lRules.Count; i++)
                        if (isExist(lRules[i].returnA(), temp) == true)
                        {
                            if (isExist(dest, temp) == true || lRules.Count <= 0)
                            {
                                k = true;
                                break;
                            }
                            temp = AddtoTemp(temp, lRules[i].returnB());
                            lResult.Add(lRules[i]);
                            lRules.RemoveAt(i);
                            k = false;
                        }
            }
            while (k == false);
            if (isExist(dest, temp) == false)
                lResult.Clear();
        }
        public List<Rules> returnResult()
        {
            OptimizeResult();
            normalizeResult();
            return this.lResult;
        }
    }
}