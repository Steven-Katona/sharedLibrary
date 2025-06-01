using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary2D
{
    public class CollisionTree : IDisposable
    {
        bool isLeaf = false;
        private Point topLeft;
        private Point botRight;
        private Point center;
        int minX;
        int minY;
        CollisionTree parent;
        CollisionTree topLeftSq;
        CollisionTree topRightSq;
        CollisionTree botLeftSq;
        CollisionTree botRightSq;
        List<Hitbox> population;
        struct node
        {
            Hitbox aabb;
        }
        

        public void setParent(CollisionTree parent)
        {
            this.parent = parent;
        }
        public CollisionTree(Point tl, Point br, int x, int y)
        {
            topLeft = tl;
            botRight = br;


            topLeftSq = null;
            topRightSq = null;
            botLeftSq = null;
            botRightSq = null;
            
            minX = x;
            minY = y;

            int xL = topLeft.X - botRight.X;
            int yL = topLeft.Y - botRight.Y;
            center = new Point(xL / 2, yL / 2);

            if(xL <= minX || yL <= minY)
            {
                isLeaf = true;
                population = new List<Hitbox>();
            }
            
            
        }

        public CollisionTree createBranch(Point tl, Point br, int x, int y, CollisionTree p)
        {
            CollisionTree t = new CollisionTree(tl, br, x, y);
            t.setParent(p);
            return t;
        }

        public void insert(Hitbox aabb)
        {

            Point aabbCenter = new(aabb.myBounds.X, aabb.myBounds.Y);
            if(aabbCenter.X < center.X)
            {
                if(aabbCenter.Y < center.Y)
                {
                    if(topLeftSq == null)
                    {
                        topLeftSq = createBranch(topLeft, center, minX, minY, this);
                    }

                    if(topLeftSq.isLeaf == true)
                    {
                        topLeftSq.population.Add(aabb);
                    }
                    else
                    {
                        topLeftSq.insert(aabb);
                    }

                }
                else
                {
                    if (botLeftSq == null)
                    {
                        botLeftSq = createBranch( new Point(topLeft.X, botRight.Y), new Point(center.X,botRight.Y), minX, minY, this);
                    }

                    if (botLeftSq.isLeaf == true)
                    {
                        botLeftSq.population.Add(aabb);
                    }
                    else
                    {
                        botLeftSq.insert(aabb);
                    }
                }
            }
            else
            {
                if (aabbCenter.Y < center.Y)
                {
                    if (topRightSq == null)
                    {
                        topRightSq = createBranch(new Point(center.X, topLeft.Y), new Point(botRight.X, center.Y), minX, minY, this);
                    }

                    if (topRightSq.isLeaf == true)
                    {
                        topRightSq.population.Add(aabb);
                    }
                    else
                    {
                        topRightSq.insert(aabb);
                    }
                }
                else
                {
                    if (botRightSq == null)
                    {
                        botRightSq = createBranch(center, botRight, minX, minY, this);
                    }

                    if (botRightSq.isLeaf == true)
                    {
                        botRightSq.population.Add(aabb);
                    }
                    else
                    {
                        botRightSq.insert(aabb);
                    }
                }
            }
        }

        public void Dispose()
        {
            
            
        }
    }
}
