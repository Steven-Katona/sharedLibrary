using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SharedLibrary2D
{
    static public class CollisionContainer
    {
        static CollisionTree collisionTree;
        struct node
        {
            Hitbox hitbox;
            public int id;
            CollisionTree myTree;
        }


        

    }
}
