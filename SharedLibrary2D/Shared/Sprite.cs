using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary2D
{
    public class Sprite
    {
        public (int, int) myMove { get; set; }
        public bool remove { get; set; }
        public float scale { get; set; }
        public float rotation { get; set; }
        public float layerDepth { get; set; }
        protected Point myLocation;
        protected Point goingLocation { get; set; }
        protected int step { get; set; }
        public Texture2D myFace { get; set; }

        int pixelmoveCountX = 0;
        int pixelmoveCountY = 0;
        public Sprite(Texture2D visual, Point myLocation, float scale = 1f, float depth = 1f) 
        {
            this.layerDepth = depth;
            this.scale = scale;
            this.myFace = visual;
            this.myLocation = myLocation;
            step = 1;
        }

        public void Draw(GameTime _gameTime, SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(myFace,
                new Vector2(myLocation.X, myLocation.Y), //Location on Screen!
                new Rectangle(0, 0, myFace.Width, myFace.Height), //Source Rectangle!
                Color.White,
                rotation,
                new Vector2(myFace.Width/2,myFace.Height/2), //origin (Center?) !
                scale,
                SpriteEffects.None,
                layerDepth);
        }

        public void Draw(GameTime _gameTime, SpriteBatch _spriteBatch, Rectangle target)
        {
            _spriteBatch.Draw(myFace, target, new Rectangle(0, 0, myFace.Width, myFace.Height), Color.White, rotation, new Vector2(myFace.Width / 2, myFace.Height / 2), SpriteEffects.None, layerDepth);
        }

        public Point getPosition()
        {
            return myLocation;
        }

        public void setPosition(Point newLocation) 
        {
            myLocation = newLocation;
        }

        public void setToRemove()
        {
            remove = true;
        }

        
        

        public static Sprite operator +(Sprite mySpritePosition, (int, int) newPosition)
        {
            mySpritePosition.myLocation.X += newPosition.Item1;
            mySpritePosition.myLocation.Y += newPosition.Item2;

            return mySpritePosition;
        }

        public static Sprite operator +(Sprite mySpritePosition, Point newPosition)
        {
            mySpritePosition.myLocation.X += newPosition.X;
            mySpritePosition.myLocation.Y += newPosition.Y;

            return mySpritePosition;
        }

        public Action<Sprite, (int, int)> basicMove = (Sprite spr, (int, int) move) => { spr.pixelmoveCountX += Math.Abs(move.Item1); spr.pixelmoveCountY += Math.Abs(move.Item2);  _ = spr + move; };
        public Action<Sprite, Point> pointMove = (Sprite spr, Point move) => { spr.pixelmoveCountX += Math.Abs(move.X); spr.pixelmoveCountY += Math.Abs(move.Y); _ = spr + move; };
    }
}
