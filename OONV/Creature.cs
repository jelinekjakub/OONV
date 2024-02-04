using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OONV
{
    public class Creature : Entity
    {
        internal Creature(string name, int maxHp, int strength, int defence, int exp)
        {
            this.Name = name;
            this.MaxHp = maxHp;
            this.Hp = maxHp;
            this.Strength = strength;
            this.Defence = defence;
            this.Exp = exp;
        }
    }

    public class CreatureFactory
    {
        public static Creature CreateWildDog()
        {
            return new Creature("Wild dog", 15, 2, 0, 5);
        }

        public static Creature CreateWolf()
        {
            return new Creature("Wolf", 25, 4, 2, 15);
        }

        public static Creature CreateAngryWolf()
        {
            return new Creature("Angry Wolf", 35, 7, 3, 40);
        }

        public static Creature CreateTeddy()
        {
            return new Creature("Teddy", 40, 7, 4, 60);
        }

        public static Creature CreateAngryBear()
        {
            return new Creature("Angry Bear", 40, 8, 5, 120);
        }
        public static Creature CreateTiger()
        {
            return new Creature("Tiger", 50, 9, 5, 180);
        }

        public static Creature CreateWhiteTiger()
        {
            return new Creature("White Tiger", 55, 10, 6, 250);
        }

        public static Creature CreateAngryWhiteTiger()
        {
            return new Creature("Angry White Tiger", 55, 11, 6,600);
        }

        public static Creature CreateAngryBossLittleLion()
        {
            return new Creature("Angry BOSS Little Lion", 100, 18, 8, 15000);
        }


        public static Creature CreateBoss()
        {
            return new Creature("Boss", 150, 12, 12, 50);
        }
    }
}
