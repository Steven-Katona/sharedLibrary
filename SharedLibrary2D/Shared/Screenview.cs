using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
namespace SharedLibrary2D
{
    public class Screenview
    {
        private Vector2 startingPosition;
        private int offset_x_axis;
        private int offset_y_axis;
        private int zoneWidth;
        private int zoneHeight;
        Sprite subject;
        Point transition;
        public Screenview(int maxWidth, int maxHeight, int worldWidth, int worldHeight)
        {
            //focus.getPosition().X  
            offset_x_axis = maxWidth / 2;
            offset_y_axis = maxHeight / 2;
            Rectangle screen = new Rectangle(0, 0, maxWidth, maxHeight);
            zoneWidth = worldWidth;
            zoneHeight = worldHeight;
            transition = new(0, 0);
        }

        public Matrix getOffsetTransformation()
        {
            Point focus = subject.getPosition();
            if (transition != focus)
            {
                //Debug.WriteLine(focus.ToString() + " compared to " + transition.ToString());
                if (focus.X > offset_x_axis && focus.X < (zoneWidth - offset_x_axis))
                {
                    transition.X = focus.X;
                }
                else
                {
                    if (focus.X > offset_x_axis)
                    {
                        transition.X = zoneWidth - offset_x_axis;
                    }
                    else
                    {
                        transition.X = offset_x_axis;
                    }
                }

                if (focus.Y > offset_y_axis - 32 && focus.Y < (zoneHeight - offset_y_axis))
                {
                    transition.Y = focus.Y + 32;
                }
                else
                {
                    if (focus.Y > offset_y_axis)
                    {
                        transition.Y = zoneHeight - offset_y_axis + 32;
                    }
                    else
                    {
                        transition.Y = offset_y_axis;
                    }
                }
            }
       
            Matrix transform = Matrix.CreateTranslation(-(transition.X - offset_x_axis), -(transition.Y - offset_y_axis), 0);
            return transform;
        }

        public bool OnScreen(Point loc)
        {
            if (Math.Abs(loc.X - subject.getPosition().X) < 500 && Math.Abs(loc.Y - subject.getPosition().Y) < 500)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void newFocus(Sprite newSubject)
        {
            subject = newSubject;
        }
    }
}
