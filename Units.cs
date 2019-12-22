using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightForFunWF
{
    abstract class Units : IUnicue
    {
        public void UnicueAbility()
        {
            Console.WriteLine("AbstractUnic");
        }

        int maxStep;
        int currentMove;
        int attack;
        int defence;
        int maxHealthPoint;
        int currentHealthPoint;
        string name;

        public int CurrentMove { get => currentMove; set => currentMove = value; }
        public int MaxStep { get => maxStep; set => maxStep = value; }

        public void Hit() { }
        public void Move() { }
        public void Die() { }
        public void Attack() { }

    }
}
