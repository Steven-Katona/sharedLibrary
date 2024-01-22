using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary2D
{
  
    public abstract class Token
    {

        public void curryBehavior(string s)
        {
            string[] a = s.Split(" ");
            for (int i = 0; i < a.Length; i++)
            {
                string token = a[i];
                string endToken = a[i + 1];
                int endingIndex = i + 1;
                for (int j = i + 1; !a[i].Equals(a[j]); j++)
                {
                    try
                    {
                        endToken = a[j];
                        endingIndex = j;
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        System.Console.WriteLine(e.ToString() + " j:" + j + "/// a.Length:" + a.Length);
                        throw;
                    }
                }

                decipherToken(a[i], a[(i + 1)..(endingIndex - 1)]);
                i = endingIndex;
            }
        }

        public void decipherToken(string s, string[] p)
        {

            Action<string[]> func = (p) =>
            {
                try
                {
                    MethodInfo m = this.GetType().GetMethod(s);
                    m.Invoke(this, p);
                }
                catch (Exception ex) 
                {
                    System.Console.WriteLine(ex.ToString() + " issue concerning method named " + s);
                    
                }
            };
        }

        
    }
}
