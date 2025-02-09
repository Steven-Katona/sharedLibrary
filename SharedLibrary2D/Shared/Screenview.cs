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
        int fullscreenHeight;
        int fullscreenWidth;
        Sprite subject;
        Point transition;
        Rectangle screen;
        bool inBounds;
        public Screenview(int maxWidth, int maxHeight, int screenWidth,int screenHeight, int worldWidth, int worldHeight)
        {
            //focus.getPosition().X  
            offset_x_axis = maxWidth / 2;
            offset_y_axis = maxHeight / 2;
            fullscreenHeight = screenHeight;
            fullscreenWidth = screenWidth;  
            screen = new Rectangle(0, 0, maxWidth, maxHeight);
            zoneWidth = worldWidth;
            zoneHeight = worldHeight;
            transition = screen.Center;
            inBounds = true;
        }
        public Point getScreenCenter()
        {
            return transition;
        }
        public Matrix getOffsetTransformation()
        {
            transition = subject.getPosition();
            //Debug.WriteLine(focus.ToString() + " compared to " + transition.ToString());
            if (inBounds)
            {
                if (transition.X < offset_x_axis)
                {
                    transition.X = offset_x_axis;
                }

                if (transition.Y < offset_y_axis)
                {
                    transition.Y = offset_y_axis;
                }

                if(transition.X > zoneWidth - offset_x_axis)
                {
                    transition.X = zoneWidth - offset_x_axis;
                }

                if (transition.Y > zoneHeight - offset_y_axis)
                {
                    transition.Y = zoneHeight - offset_y_axis;
                }
            }

            
            
            Matrix transform = Matrix.CreateTranslation(-(transition.X - offset_x_axis)*2, -(transition.Y - offset_y_axis)*2, 0);
            return transform;
        }

        public bool OnScreen(Point loc)
        {
            if (Math.Abs(loc.X - transition.X) <= offset_x_axis + offset_x_axis/2 && Math.Abs(loc.Y - transition.Y) <= offset_y_axis + offset_y_axis/2)
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
            transition.X = subject.getPosition().X - offset_x_axis;
            transition.Y = subject.getPosition().Y - offset_y_axis;
        }
    }
}
