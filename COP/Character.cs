using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP
{
    [Serializable]
    public class Character
    {
        public string Name { get; set; }

        public string Covenant { get; set; }

        public int Level 
        { 
            get
            {
                return Vitality + Attunement + Endurance + Strength + Dexterity + Resistance + Intelligence + Faith;
            } 
        }

        public int Vitality { get; set; }

        public int Attunement { get; set; }

        public int Endurance { get; set; }

        public int Strength { get; set; }

        public int Dexterity { get; set; }

        public int Resistance { get; set; }

        public int Intelligence { get; set; }

        public int Faith { get; set; }
    }
}
