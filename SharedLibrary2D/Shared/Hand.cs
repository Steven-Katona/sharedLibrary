using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary2D.Shared
{
    
    internal abstract class Hand 
    {
        string mySaveFile;
        Bag bag;
        bool inMenu;
        public abstract void loadGame(string saveFile);
        public abstract void saveGame();
        public abstract void newGame();
        

        public Matrix getlevelcameraOffset()
        {
            return bag.gameplayScreen.getOffsetTransformation();
        }

        public void Update(GameTime gameTime)
        {
            bag.Update(gameTime);
        }

        public void Draw(GameTime _gameTime, SpriteBatch _spriteBatch)
        {
            if (inMenu)
            {

            }
            else
            {
                bag.Draw(_gameTime, _spriteBatch);
            }
        }


    }
}
