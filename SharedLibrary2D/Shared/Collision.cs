using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SharedLibrary2D.Shared
{
    static public class Collision
    {
        
        public static bool RectRect(Rectangle r1, Rectangle r2)
        {
            if (r1.Intersects(r2))
                return true;
            else
                return false;
        }

        

    }
}
