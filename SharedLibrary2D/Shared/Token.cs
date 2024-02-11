using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SharedLibrary2D
{
  
    public abstract class Token
    {

        public void curryBehavior(string s)
        {
            string[] a = s.Split(" ");
            for (int i = 0; i < a.Length -1 ; i++)
            {
                string token = a[i];
                int endingIndex = i + 1;

                do
                {
                    try
                    {
                        endingIndex++;
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        System.Console.WriteLine(e.ToString() + " endingIndex:" + endingIndex + "/// a.Length:" + a.Length);
                        throw;
                    }
                } while ((!a[i].Equals(a[endingIndex])));


                string[] buff = a[(i += 1)..(endingIndex)];
              
                decipherToken(token, buff);
                i = endingIndex;
            }
        }

        public void decipherToken(string s, string[] p)
        {
            try
            {
                //MethodInfo m = 
                GetType().GetMethod(s).Invoke(this, new object[] {p});
                //m.Invoke(this, p);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString() + " issue concerning method named " + s);
                throw;
            }
        }

        public abstract Animation getAnimation(string x);
        public abstract string getLevel(string s);

        
    }
}
