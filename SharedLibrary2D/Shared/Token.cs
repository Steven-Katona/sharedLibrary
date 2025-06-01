using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace SharedLibrary2D
{
   
    public abstract class Token
    {
        List<Optic> returnme;
        public void curryBehavior(string s/*, out List<Optic> returnme */)
        {
            string[] a = s.Split(" ");
            for(int x = 0; x < a.Length; x++)
            {
                a[x] = a[x].Replace("\r\n", string.Empty);
            }
            for (int i = 0; i < a.Length -1 ; i++)
            {
                string token = a[i];
                int endingIndex = i + 1;

                do
                {
                    try
                    {
                        string zero = a[i];
                        string thirteen = a[endingIndex];
                        endingIndex++;
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        Debug.WriteLine(e.ToString() + " endingIndex:" + endingIndex + "/// a.Length:" + a.Length);
                        throw;
                    }
                } while ( !a[i].Equals(a[endingIndex]) );


                string[] buff = a[(i += 1)..(endingIndex)];
              
                decipherToken(token, buff);
                i = endingIndex;
            }
        }

        public void decipherToken(string s, string[] p)
        {
            try
            {
                GetType().GetMethod(s).Invoke(this, new object[] {p});
            }
            catch (NullReferenceException ex)
            {
                Debug.WriteLine(ex.ToString() + " issue concerning method named " + s);
                throw;
            }
        }

        public abstract Animation getAnimation(string x);
        public abstract void Update(GameTime gameTime);

        
    }
}
