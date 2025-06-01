using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace SharedLibrary2D.Shared
{
    internal abstract class Bag
    {
        Token my_token;
        public Screenview gameplayScreen;
        List<Optic> backgroundTiles;

        public void Draw(GameTime _gameTime, SpriteBatch _spriteBatch)
        {
            foreach (Optic e in backgroundTiles)
            {
                if (gameplayScreen.OnScreen(e.getPosition()))
                {
                    e.Draw(_gameTime, _spriteBatch);
                }
            }

        }

        public void makeLevel(string filename)
        {
            StreamReader sr = new StreamReader("Content/Levels/" + filename + ".txt");
            string x = sr.ReadToEnd();
            my_token.curryBehavior(x);
        }

        public void Update(GameTime _gameTime)
        {
            my_token.Update(_gameTime);
        }
        

    }
}
