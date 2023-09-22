using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;


namespace SharedLibrary2D
{
    public class Optic : Sprite
    {
        public Animation myVisual { get; set; }


        protected Rectangle drawnRectangle;
  
        public Hitbox myAABB { get; set; }
        public AnimationLogic animator;
        public bool draw_me = true;
        public Optic(Animation visual, Point myLocation, int hitboxX, int hitboxY, float scale = 1f, float depth = 1f): base(visual.myAnimation, myLocation, scale, depth)
        {
            myVisual = visual;
            

            myAABB = new(myLocation.X,myLocation.Y, hitboxX, hitboxY, new(-hitboxX/2,-hitboxY/2));
            animator = new AnimationLogic();
            animator.animationPlay(myVisual);
            drawnRectangle = new((int)getPosition().X, (int)getPosition().Y, myVisual.myWidth, myVisual.myHeight);
        }

        public void resizeVisual( int width, int height)
        {
            drawnRectangle = new Rectangle(getPosition().X, (int)getPosition().Y, width, height);
        }

        public Optic(Texture2D visual, Point myLocation, int hitboxX, int hitboxY, float scale = 1f, float depth = 1f) : base(visual, myLocation)
        {
            myVisual = new Animation(visual, 0.0f, false, visual.Width, visual.Height);
            myAABB = new(myLocation.X, myLocation.Y, hitboxX, hitboxY, new(-hitboxX / 2, -hitboxY / 2));
            animator = new AnimationLogic();
            animator.animationPlay(myVisual);;
            drawnRectangle = new((int)getPosition().X, (int)getPosition().Y, myVisual.myHeight, myVisual.myWidth);
        }



        public new void Draw(GameTime _gameTime, SpriteBatch _spriteBatch)
        {

            if (myVisual.myAnimation != null)
            {
                animator.Draw(

                    _gameTime, 
                    
                    _spriteBatch, 
                    
                    new Vector2(getPosition().X, getPosition().Y), 
                    
                    drawnRectangle, 
                    
                    rotation, 
                    
                    new Vector2(myVisual.myWidth / 2, myVisual.myHeight / 2), 
                    
                    scale,
                    
                    SpriteEffects.None, 
                    
                    layerDepth);
            }
            else
            {
                throw new Exception("something is not right");
            }
        }


        public static Optic operator +(Optic myOpticPosition, (int, int) newPosition)
        {
            _ = (Sprite)myOpticPosition + newPosition;
            myOpticPosition.myAABB.getBounds().X += newPosition.Item1;
            myOpticPosition.myAABB.getBounds().Y += newPosition.Item2;

            return myOpticPosition;
        }

        public new void setPosition(Point newLocation)
        {
            base.setPosition(newLocation);
            myAABB.myBounds = new (newLocation.X, newLocation.Y, myAABB.myBounds.Width, myAABB.myBounds.Height);
        }








    }
}
