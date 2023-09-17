using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace SharedLibrary2D
{

    public class Hitbox : IDisposable
    {
        
        public Rectangle myBounds;
        Rectangle source;
        Texture2D drawnBox;
        public Point my_offset { get; }
        public bool active { get; set; }
        
        public Hitbox(int x, int y, int width, int height, Point offset) 
        { 
            myBounds = new(x + offset.X, y + offset.Y, width, height);
            my_offset = offset;
            active = true;
            source = myBounds;
        }

        public ref Rectangle getBounds()
        {
            return ref myBounds;
        }

        public bool isDrawnBox()
        {
            if (drawnBox == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public void Draw(GameTime gameTime, SpriteBatch _spriteBatch, GraphicsDevice _graphics)
        {

            if (drawnBox == null && myBounds.Width > 0)
            {
                Color[] box = new Color[myBounds.Width * myBounds.Height];
                for (int loop_y = 0; loop_y < myBounds.Height; loop_y++)
                {
                    for (int loop_x = 0; loop_x < myBounds.Width; loop_x++)
                    {
                        if (loop_y == 0 || loop_x == 0)
                        {
                            box[loop_x + (loop_y * myBounds.Width)] = Color.Yellow;
                        }

                        if (loop_y == myBounds.Height - 1 || loop_x == myBounds.Width - 1)
                        {
                            box[loop_x + (loop_y * myBounds.Width)] = Color.Yellow;
                        }
                    }
                }
                drawnBox = new(_graphics, myBounds.Width, myBounds.Height);
                drawnBox.SetData(box);
            }


            if (drawnBox != null || active != false)
            {
                _spriteBatch.Draw(drawnBox, myBounds, Color.White);

                //Texture2D a = _graphics.GetRenderTargets();
                //_spriteBatch.Draw(drawnBox, new (myBounds.X,myBounds.Y), myBounds, new(0,0,0,255), 0.0f, new (0,0), 2.0f, SpriteEffects.None, 0.0f);
            }
        }




        public void Dispose()
        {
            myBounds = new(0, 0, 0, 0);
            active = false;
        }
    }
}
