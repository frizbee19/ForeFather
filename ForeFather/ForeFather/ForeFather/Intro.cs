using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.IO;
namespace ForeFather
{
    class Intro
    {
        // start in wilderness
        public void start()
        {
            Textbox t = new Textbox();
            t.Textbox(new Rectangle(0,0,100,800), 400, "Jacos has grown in power... 3 of the 6 kidney stones have been found... half the population is going to be lost... this is the end... evil's power has grown and we are all about to lose everything that matters...this is humanities last stand... it is up to YOU to stop him", false, ContentManager, "beginning");
            t.displayBox = true;
            t.Draw();
        }
    }
}
