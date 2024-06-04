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
        List<Optic> BackgroundObjects;
        int mySpeed;
        Optic spr;
        Viewport gameView;

        enum Scroll : ushort { up = 0, down = 1, left = 2, right = 3};
        Scroll myScroll; 
        enum Status : ushort { staticB = 0, movingB = 1, loopingB = 2};
        Status myStatus;


        internal delegate void behaviorSwitch(int v);
        behaviorSwitch activeDelegate;

        public Background(Optic sprawl, Tuple<int, int, int> startingConfiguration, int offset = 0, int option = 0) 
        {
            spr = sprawl;
            changeStatus(startingConfiguration.Item1);
            changeScroll(startingConfiguration.Item2);
            changeSpeed(startingConfiguration.Item3);
        }

        public Background(Optic sprawl)
        {
            spr = sprawl;
            myStatus = Status.staticB;
        }

        internal void changeBehavior(int option)
        {
            switch(option)
            {
                case 0:
                    activeDelegate = changeScroll;
                    break;
                case 1:
                    activeDelegate = changeStatus;
                    break;
                case 2:
                    activeDelegate = changeSpeed;
                    break;
            }
        }

        public void changeScroll(int v)
        {
            try
            {
                myScroll = (Scroll)v;
            }
            catch (Exception e) { throw; }
        }

        public void changeStatus(int v) 
        {
            try
            {
                myStatus = (Status)v;
            }
            catch (Exception e) { throw; }
        }

        public void changeSpeed(int v) 
        {
            mySpeed = v;
        }

        public void nextBehavior()
        {

        }

        public void destinationPointReaced()
        {

        }

        public void Draw(GameTime _gameTime, SpriteBatch _spriteBatch)
        { 

            spr.Draw(_gameTime, _spriteBatch);
            
        }

        public void Update(GameTime _gameTime)
        {
           
        }
    }
}
