using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OONV
{
    public class Arena
    {
        public Player? Player;
        private Player? PlayerSave;
        readonly List<Creature> Creatures = new();

        public Arena(List<Creature> creatures)
        {
            Creatures = creatures;
        }

        public Player? StartGame()
        {

            if (Player == null)
            {
                Player = PlayerFactory.CreatePlayer();
            }
            else
            {
                Player.Heal();
            }
            PlayerSave = Player.DeepCopy();
            while (Creatures.Count > 0)
            {
                int pickCreature = SelectCreature();
                Player.Attack(Creatures[pickCreature]);
                Console.Clear();
                ClearCorpses();
                if (!Player.GetAlive())
                {
                    UserInterface.ShowMessage("Tvůj hrdina zemřel, opakuj arénu.", false);
                    PlayerSave.Die();
                    return PlayerSave;
                }
            }
            UserInterface.ShowMessage("Pročistil jsi tuto arenu.");
            return Player;
        }

        public List<Creature> GetCreatures()
        {
            return this.Creatures;
        }

        public int SelectCreature()
        {
            Console.WriteLine($"{Player.Lvl}LVL. {Player.Name} [{Player.Hp}HP,{Player.Strength}STR, {Player.Defence}DEF, {Player.Exp}/{Player.NextExp}XP]");
            Console.WriteLine("Vyber nepřítele");
            for (int i = 0; i < Creatures.Count; i++)
            {
                Console.WriteLine($"{i}. {Creatures[i].Name} [{Creatures[i].Hp}HP,{Creatures[i].Strength}STR, {Creatures[i].Defence}DEF, {Creatures[i].Exp}XP]");
            }
            int pick = -1;
            do
            {
                try
                {
                    string? input = Console.ReadLine();
                    if (input != null)
                    {
                        pick = int.Parse(input);
                    }
                    else
                    {
                        continue;
                    }
                }
                catch (Exception)
                {

                    continue;
                }
                
            } while (pick < 0 || pick >= Creatures.Count);
            Console.Clear();
            return pick;
        }

        public void AttackCreature(int creatureId)
        {
            Player.Attack(Creatures[creatureId]);
        }

        public void ClearCorpses()
        {
            List<Creature> corpsesToRemove = new();

            foreach (Creature creature in Creatures)
            {
                if (!creature.GetAlive())
                {
                    corpsesToRemove.Add(creature);
                }
            }

            foreach (Creature creatureToRemove in corpsesToRemove)
            {
                Creatures.Remove(creatureToRemove);
            }
        }
    }

    public class ArenaFactory
    {
        public static Arena CreateArena1()
        {
            List<Creature> creatures = new()
            {
                CreatureFactory.CreateWildDog(),
                CreatureFactory.CreateWildDog(),
                CreatureFactory.CreateWildDog(),
                CreatureFactory.CreateWildDog(),
                CreatureFactory.CreateWolf(),
                CreatureFactory.CreateWolf(),
                CreatureFactory.CreateWolf(),
                CreatureFactory.CreateWolf(),
                CreatureFactory.CreateWolf(),
                CreatureFactory.CreateWolf(),
                CreatureFactory.CreateAngryWolf(),
                CreatureFactory.CreateAngryWolf(),
                CreatureFactory.CreateAngryWolf(),
                CreatureFactory.CreateAngryWolf(),
                CreatureFactory.CreateAngryWolf(),
            };
            return new Arena(creatures);
        }
        public static Arena CreateArena2()
        {
            List<Creature> creatures = new()
            {
                CreatureFactory.CreateTeddy(),
                CreatureFactory.CreateTeddy(),
                CreatureFactory.CreateTeddy(),
                CreatureFactory.CreateTeddy(),
                CreatureFactory.CreateTeddy(),
                CreatureFactory.CreateTeddy(),
                CreatureFactory.CreateAngryBear(),
                CreatureFactory.CreateAngryBear(),
                CreatureFactory.CreateAngryBear(),
                CreatureFactory.CreateAngryBear(),
                CreatureFactory.CreateAngryBear(),
                CreatureFactory.CreateTiger(),
                CreatureFactory.CreateTiger(),
                CreatureFactory.CreateTiger(),
                CreatureFactory.CreateTiger(),

            };
            return new Arena(creatures);
        }

        public static Arena CreateArena3()
        {
            List<Creature> creatures = new()
            {
                CreatureFactory.CreateWildDog(),
                CreatureFactory.CreateWildDog(),
                CreatureFactory.CreateTiger(),
                CreatureFactory.CreateTiger(),
                CreatureFactory.CreateTiger(),
                CreatureFactory.CreateTiger(),
                CreatureFactory.CreateWhiteTiger(),
                CreatureFactory.CreateWhiteTiger(),
                CreatureFactory.CreateWhiteTiger(),
                CreatureFactory.CreateWhiteTiger(),
                CreatureFactory.CreateWolf(),
                CreatureFactory.CreateWolf(),
                CreatureFactory.CreateWolf(),
                CreatureFactory.CreateWhiteTiger(),
                CreatureFactory.CreateWhiteTiger(),
                CreatureFactory.CreateWhiteTiger(),
                CreatureFactory.CreateAngryWhiteTiger(),
                CreatureFactory.CreateAngryWhiteTiger(),
                CreatureFactory.CreateAngryWhiteTiger(),
                CreatureFactory.CreateAngryWhiteTiger(),
                CreatureFactory.CreateAngryWhiteTiger(),
                CreatureFactory.CreateAngryWhiteTiger(),
                CreatureFactory.CreateAngryWhiteTiger(),
                CreatureFactory.CreateAngryBossLittleLion(),
            };
            return new Arena(creatures);
        }
    }
}
