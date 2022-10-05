using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UIElements;

namespace Assets.Source.Core
{
    internal class ActorSaveObject
    {
        public char MapIcon;
        public int Positionx;
        public int Positiony;

        public ActorSaveObject(char mapIcon, int positionx, int positiony)
        {
            MapIcon = mapIcon;
            Positionx = positionx;
            Positiony = positiony;
        }
    }
}
