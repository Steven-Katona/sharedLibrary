using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary2D
{ 
    static public class AnimationConstruction
    {
        static string folder;
        static readonly string AnimationColor = "{R:217 G:87 B:99 A:255}";
        static readonly string HitboxColor = "{R:17 G:10 B:9 A:255}";
        static Dictionary<string, (int, int, Point)> getHitbox;
        static Dictionary<string, Animation> getTextureArray;

        public static void setFolder(string newFolder)
        {
            folder = newFolder;
        }
        static public void Initilize()
        {
            getHitbox = new Dictionary<string, (int, int,Point)> { };
            getTextureArray = new Dictionary<string, Animation> { };
        }

        static public Animation createAnimationTexture(string fileName, GraphicsDevice _graphicDevice, ContentManager content, float frameTime, bool isLooping)
        {
            Animation result;
            Texture2D file;

            try
            {
                if (!folder.Equals(""))
                {
                    file = content.Load<Texture2D>(folder + "/" + fileName);
                }
                else
                {
                    file = content.Load<Texture2D>(fileName);
                }
            }
            catch (Exception ex) 
            {
                file = null;
                string error = ex.ToString() + " \"bad file name, or bad file path!\"";
            }

            if(getTextureArray.TryGetValue(fileName, out result))
            {
                return result;
            }
            else
            {
                int newWidth = 0;
                Color[] color = new Color[file.Width * file.Height];
                file.GetData(color);
                for(int loop_x = 0; loop_x < file.Width; loop_x++)
                {
                    if (color[loop_x].ToString().Equals(AnimationColor))
                    {
                        newWidth = loop_x + 1;
                        color[loop_x] = new Color(0,0,0);
                        color[loop_x].A = 255; 
                    }
                }

                

                if (newWidth == 0)
                {
                    result = new Animation(file, frameTime, isLooping, file.Width ,file.Height);
                }
                else 
                {
                    Texture2D frame = new(_graphicDevice, file.Width, file.Height);
                    frame.SetData(color);
                    result = new Animation(frame, frameTime, isLooping, newWidth, file.Height);
                }

                return result;
            }

        }

        

        static public (int,int,Point) createHitbox(string fileName, ContentManager content)
        {
            (int, int, Point) value;
            
            if (getHitbox.TryGetValue(fileName, out value))
            {
                return value;
            }
            else
            {
                Texture2D mask = content.Load<Texture2D>("hitbox2d/" + fileName);
                bool firstPointFound = false;
                Point firstpoint = new(0, 0);
                Point lastpoint = new(0, 0);

                Color[] color = new Color[mask.Height * mask.Width];
                mask.GetData(color);
                for (int loop_y = 0; loop_y < mask.Height; loop_y++)
                {
                    for (int loop_x = 0; loop_x < mask.Width; loop_x++)
                    {
                        Color currentPixel = color[loop_x + (loop_y * mask.Width)];
                        string hexTest = currentPixel.ToString();
                        if (hexTest.Equals(HitboxColor))
                        {
                            if (firstPointFound)
                            {
                                lastpoint = new Point(loop_x, loop_y);
                            }
                            else
                            {
                                firstpoint = new Point(loop_x, loop_y);
                                firstPointFound = true;

                            }
                        }
                    }
                }
                value = new(lastpoint.X - firstpoint.X, lastpoint.Y - firstpoint.Y, firstpoint);
                getHitbox.Add(fileName, value);
                return value;
            }

            

        }
    }
}
