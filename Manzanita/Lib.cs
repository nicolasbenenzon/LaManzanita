using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;

namespace Manzanita
{
    public static class Lib
    {
        public const string path = "Resources/";

        public static void PlaySound(string soundName)
        {
            SoundPlayer sound = new SoundPlayer(Lib.path + "Sounds/" + soundName);
            sound.Play();
        }
    }
}
