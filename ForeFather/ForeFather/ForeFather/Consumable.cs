using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForeFather
{
    enum ConsumeType
    {
        CurHealth, MaxHealth, Luck, Offense, Defense, Mana
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
        make sure to update the character in whatever class you use this method in after you call it
        */
        override //replace character with ally eventually idk
        public Character Use(Character character)
        {
            if (Count > 0)
            {
                Count--;
                switch(itemType)
                {
                    case ConsumeType.CurHealth:
                        character.getCurHp += magnitude;
                        break;
                    case ConsumeType.MaxHealth:
                        character.getMaxHp += magnitude;
                        break;
                    case ConsumeType.Luck:
                        character.getLuck += magnitude;
                        break;
                    case ConsumeType.Offense:
                        character.getOffense += magnitude;
                        break;
                    case ConsumeType.Defense:
                        character.getDefense += magnitude;
                        break;
                    case ConsumeType.Mana:
                        character.getMana += magnitude;
                        break;
                    default:
                        break;
                }
            }
            return character;
        }
        
        public override bool Equals(Item item)
        {
            return item.Name == this.Name && item.GetType() == this.GetType();
        }
    }
}
