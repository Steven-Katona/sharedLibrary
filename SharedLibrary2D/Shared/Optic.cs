using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace SharedLibrary2D
{
    public class Optic
    {
        Animation myVisual;
        bool remove { get; set; }
        bool suprise { get; set; }
        bool is_dead { get; set; }
        float rotate { get; set; }
  
        Rectangle drawnRectangle;
        Point myLocation;
        public Hitbox myAABB { get; set; }
        AnimationLogic animator;
        public bool draw_me = true;
        public Optic(Animation visual, Hitbox aabb, Point myLocation)
        {
            myVisual = visual;
            this.myLocation = myLocation;
            myAABB = aabb;
            animator = new AnimationLogic();
            animator.animationPlay(myVisual);
            this.is_dead = false;
            drawnRectangle = new ((int)getPosition().X, (int)getPosition().Y, 32, 32);   
        }

        public Point getPosition()
        {
            return myLocation;
        }

        public void setToRemove()
        {
            remove = true;
        }

        public void Draw(GameTime _gameTime, SpriteBatch _spriteBatch)
        {

            if (myVisual.myAnimation != null) 
            {
                animator.Draw(_gameTime, _spriteBatch, new(getPosition().X,getPosition().Y), drawnRectangle, new Vector2(myVisual.myHeight/2, myVisual.myHeight/2), rotate, SpriteEffects.None);
            }
            else
            {
                throw new Exception("something is not right");
            }
        }

        public void setAnimationPosition(int newX, int newY)
        {
            myLocation.X = newX;
            myLocation.Y = newY;
        }

        public Point getVector()
        { 
            return myLocation; 
        }


        static public double CalculateDiagonalMovement(double the_move)
        {
            double amount = the_move / 2;
            amount = Math.Sqrt(amount);
            return amount;
        }

        
    }
}
