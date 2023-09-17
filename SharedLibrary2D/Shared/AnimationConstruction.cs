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
        static readonly string HitBoxColor = "{R:63 G:63 B:116 A:255}";
        static Dictionary<string, Animation> getTextureArray;
        

        public static void setFolder(string newFolder)
        {
            folder = newFolder;
        }
        static public void Initilize()
        {
            getTextureArray = new Dictionary<string, Animation> { };
        }

        static public Animation createAnimationTexture(string fileName, GraphicsDevice _graphicDevice, ContentManager content, float frameTime, bool isLooping)
        {
            Animation result;
            Texture2D file;
            Point start = new(0,0);
            Point end = new(0,0);

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
                        color[loop_x] = new Color(0,0,0,0);
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
                    result.hitBoxStart=start;
                    result.hitBoxEnd=end;

                }

                return result;
            }

        }
    }
}
