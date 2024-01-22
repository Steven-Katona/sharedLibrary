using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
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
        Point focus;
        Point transition;
        public Screenview(int maxWidth, int maxHeight, int worldWidth, int worldHeight)
        {
            //focus.getPosition().X  
            offset_x_axis = maxWidth / 2;
            offset_y_axis = maxHeight / 2;
            zoneWidth = worldWidth;
            zoneHeight = worldHeight;
            transition = new(0, 0);
            

        }

        public Matrix getOffsetTransformation()
        {
 
            if (transition != focus)
            {

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

        public void newFocus(Point newSubject)
        {
            focus = newSubject;
        }
    }
}
