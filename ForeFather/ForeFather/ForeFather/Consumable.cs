using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForeFather
{
    enum ConsumeType
    {
        Health
    }
    class Consumable : Item
    {
        private ConsumeType itemType;
        public ConsumeType Type
        {
            get { return itemType; }
        }
        private int magnitude;

        public Consumable(string n, string d, ConsumeType type, int m) : base(n, d)
        {
            itemType = type;
            magnitude = m;
        }
        /*
        Change this later on to make it so that the Use method takes Player as a parameter and put a switch statement to check the type and increment the stats in the method.
        Set player = method return in whatever class calls Use method.
        */
        override
        public int Use()
        {
            if (Count > 0)
            {
                Count--;
                return magnitude;
            }
            else
            {
                return 0;
            }
        }
        
        public override bool Equals(Item item)
        {
            return item.GetType() == this.GetType();
        }
    }
}
