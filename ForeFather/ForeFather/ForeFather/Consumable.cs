using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForeFather
{
    enum Type
    {
        CurHealth, MaxHealth, Luck, Offense, Defense, Mana
    }
    class Consumable : Item
    {
        private Type itemType;
        public Type Type
        {
            get { return itemType; }
        }
        private int magnitude;

        public Consumable(string n, string d, Type type, int m) : base(n, d)
        {
            itemType = type;
            magnitude = m;
        }
        /*
        make sure to update the character in whatever class you use this method in after you call it
        */
        override //replace character with ally eventually idk
        public void Use(Ally character)
        {
            if (Count > 0)
            {
                Count--;
                switch(itemType)
                {
                    case Type.CurHealth:
                        character.getCurHp += magnitude;
                        break;
                    case Type.MaxHealth:
                        character.getMaxHp += magnitude;
                        break;
                    case Type.Luck:
                        character.getLuck += magnitude;
                        break;
                    case Type.Offense:
                        character.getOffense += magnitude;
                        break;
                    case Type.Defense:
                        character.getDefense += magnitude;
                        break;
                    case Type.Mana:
                        character.getMana += magnitude;
                        break;
                    default:
                        break;
                }
            }
        }
        
        public override bool Equals(Item item)
        {
            return item.Name == this.Name && item.GetType() == this.GetType();
        }
    }
}
