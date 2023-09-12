using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;


namespace SharedLibrary2D
{

    public class Hitbox : IDisposable
    {

        public Rectangle myBounds;
        Texture2D drawnBox;
        public Point my_offset { get; }
        
        public Hitbox(int x, int y, int width, int height, Point offset) 
        { 
            myBounds = new(x + offset.X, y + offset.Y, width, height);
            my_offset = offset;
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

            if (drawnBox == null)
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



            _spriteBatch.Draw(drawnBox, myBounds, Color.White);
            //_spriteBatch.Draw(drawnBox, new Vector2 (myBounds.X,myBounds.Y), myBounds, Color.White, 0.0f, myCenter, 1.0f, SpriteEffects.None, 0.9f);
        }


        public void Dispose()
        {
            
        }
    }
}
