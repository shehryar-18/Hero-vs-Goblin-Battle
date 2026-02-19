using System;

class Character
{
    public string Name;
    public int HP;
    public int Attack;

    public Character(string name, int hp, int attack)
    {
        Name = name;
        HP = hp;
        Attack = attack;
    }

    public virtual void PerformAttack(Character target)
    {
        target.HP -= Attack;
        Console.WriteLine(Name + " hits " + target.Name + " for " + Attack + " damage!");
    }

    public bool IsAlive()
    {
        return HP > 0;
    }
}

class Hero : Character
{
    public Hero(string name) : base(name, 120, 20) { }

    public override void PerformAttack(Character target)
    {
        int critChance = new Random().Next(1, 101);
        int damage = Attack;

        if (critChance <= 20)
        {
            damage *= 2;
            Console.WriteLine("CRITICAL HIT!");
        }

        target.HP -= damage;
        Console.WriteLine(Name + " deals " + damage + " damage!");
    }
}

class Program
{
    static void Main()
    {
        Hero hero = new Hero("Warrior");
        Character enemy = new Character("Goblin", 100, 15);

        while (hero.IsAlive() && enemy.IsAlive())
        {
            hero.PerformAttack(enemy);
            if (enemy.IsAlive())
                enemy.PerformAttack(hero);

            Console.WriteLine("Hero HP: " + hero.HP);
            Console.WriteLine("Enemy HP: " + enemy.HP);
            Console.WriteLine();
        }

        Console.WriteLine(hero.IsAlive() ? "Hero Wins!" : "Enemy Wins!");
    }
}
