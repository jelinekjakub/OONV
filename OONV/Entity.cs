using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OONV
{
    [Serializable]
    public class Entity
    {
        public string Name = "";
        public bool Alive = true;
        public int MaxHp;
        public int Hp;
        public int Strength;
        public int Defence;
        public int Exp;

        public void Attack(Entity enemy)
        {
            int damage = Strength - enemy.Defence;
            if (Alive && enemy.GetAlive())
            {
                if (damage > 0)
                {
                    Console.WriteLine($"{Name} udělil {damage} bodů poškození {enemy.Name}({enemy.Hp}HP).");
                    bool dead = enemy.TakeDamage(damage);
                    if (dead)
                    {
                        if (this.GetType() == typeof(Player))
                        {
                            EarnXP(enemy);
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"{Name} nic neudělal {enemy.Name}.");
                }
                enemy.Attack(this);
            }
        }

        public void EarnXP(Entity enemy)
        {
            Exp += enemy.Exp;
            this.LevelUp();
        }

        public virtual void LevelUp() { }

        public void ShowStats()
        {
            Console.WriteLine(Name);
            Console.WriteLine(Alive);
            Console.WriteLine(Hp);
            Console.WriteLine(Strength);
            Console.WriteLine(Defence);
            Console.WriteLine(Exp);
        }

        public bool TakeDamage(int damage)
        {
            Hp -= damage;
            if (Hp <= 0)
            {
                UserInterface.ShowMessage($"{this.Name} zemřel.", false);
                Die();
                return true;
            }
            return false;
        }

        public void Heal()
        {
            Hp = MaxHp;
            Alive = true;
        }

        public void Die()
        {
            Hp = 0;
            Alive = false;
        }

        public bool GetAlive()
        {
            if (Hp <= 0)
            {
                Alive = false;
            }
            return Alive;
        }
    }
}
