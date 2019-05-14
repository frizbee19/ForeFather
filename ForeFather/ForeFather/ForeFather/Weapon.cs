//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace ForeFather
//{
//    class Weapon : Item
//    {
//        private int damage;
//        public int Damage
//        {
//            get { return damage; }
//            set { damage = value; }
//        }

//        public Weapon(string n, string d, int magnitude) : base(n, d + "\r\nDeals " + magnitude + " damage")
//        {
//            damage = magnitude;
//        }

//        override
//        public void Use(Ally c)
//        {
//            c.getWeapon = this;
//        }

//        override
//        public bool Equals(Item item)
//        {
//            return item.Name == this.Name && ((Weapon)item).Damage == this.Damage && item.Description == this.Description;
//        }
//    }
//}
