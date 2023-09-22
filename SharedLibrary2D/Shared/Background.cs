using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary2D
{
    public class Background
    {
        Rectangle targetView;
        List<Optic> BackgroundObjects;
        int mySpeed;
        Optic spr;
        Point Startingpoint;
        int endingP;
        float scaleUp;
        public Background(Optic back, int speed, int startingSlides, int screenHeight) 
        {
            spr = back;
            spr.layerDepth = 10f;
            scaleUp = screenHeight / back.myFace.Height;
            _ = back.getPosition().X;
            mySpeed = speed;
            BackgroundObjects = new List<Optic>();
            for(int i = 0; i <= startingSlides; i++)
            {
                BackgroundObjects.Add(new Optic(spr.myVisual, spr.getPosition(),0,0,scaleUp + 1f));
                spr.setPosition( new(spr.getPosition().X,spr.getPosition().Y - spr.myFace.Height * (int)scaleUp));

            }
            endingP = (BackgroundObjects.Count-1) * (screenHeight + (spr.myFace.Height * (int)scaleUp) / 2);
        }




        public void Draw(GameTime _gameTime, SpriteBatch _spriteBatch)
        {
            
            for(int i = 0; i < BackgroundObjects.Count; i++)
            {

                _ = BackgroundObjects[i] + (0, mySpeed);
                BackgroundObjects[i].Draw(_gameTime, _spriteBatch);

                if (BackgroundObjects[i].getPosition().Y > endingP)
                {
                    _ = BackgroundObjects[i]  + (0,-1800);
                }
            }
            
        }

        

        public void Update(GameTime _gameTime)
        {

        }
    }
}
