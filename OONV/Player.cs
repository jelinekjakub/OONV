using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OONV
{
    [Serializable]
    public class Player : Entity
    {
        public int NextExp = 20;
        public int Lvl = 1;
        public Player(string name, int maxHp, int strength, int defence)
        {
            this.Name = name;
            this.MaxHp = maxHp;
            this.Hp = maxHp;
            this.Strength = strength;
            this.Defence = defence;
        }

        public override void LevelUp()
        {
            if (Exp >= NextExp)
            {
                Exp -= NextExp;
                Lvl += 1;
                NextExp *= 4;
                Strength += 3;
                Defence += 2;
                Heal();
                UserInterface.ShowMessage("****LEVEL UP****");
            }
        }
    }

    public class PlayerFactory
    {
        public static Player CreatePlayer()
        {
            string? playerName = string.Empty;
            while (string.IsNullOrWhiteSpace(playerName))
            {
                Console.Clear();
                Console.Write("Zadejte jméno vašeho hrdiny: ");
                playerName = Console.ReadLine();
            }
            return new Player(playerName, 100, 1, 1);
        }
    }
}
