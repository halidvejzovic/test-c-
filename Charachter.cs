using System;

public class Character
{
    // Karaktärens egenskaper: namn, HP nu och max, attackkraft, helningskraft
    public string Name;
    public int CurrentHp;
    public int MaxHp;
    public int AttackPower;
    public int HealPower;

    // Konstruktor
    public Character(string name, int maxHp, int attackPower, int healPower)
    {
        Name = name;
        MaxHp = maxHp;
        CurrentHp = maxHp;
        AttackPower = attackPower;
        HealPower = healPower;
    }

    // Metod för att attackera
    public void Attack(Character opponent)
    {
        int damage = AttackPower;

        // 20% chans för Critical Strike
        if (Random.Shared.Next(1, 101) <= 20)
        {
            damage = (int)Math.Round(AttackPower * 1.25);
            Console.WriteLine("CRITICAL STRIKE!");
        }

        opponent.TakeDamage(damage);

        Console.WriteLine($"{Name} attackerar {opponent.Name} och gör {damage} skada!");
    }

    // Metod för att hela
    public void Heal()
    {
        int healing = HealPower;

        CurrentHp = Math.Min(CurrentHp + healing, MaxHp);

        Console.WriteLine($"{Name} återhämtar {healing} HP!");
    }

    // Metod för att ta emot skada
    public void TakeDamage(int damage)
    {
        CurrentHp = Math.Max(CurrentHp - damage, 0);
    }
}