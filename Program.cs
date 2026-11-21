using System;

// Skapar spelaren och fienden
Character player = new Character("Spelaren", 100, 20, 25);
Character enemy = new Character("Fienden", 100, 20, 25);

// Rage Mode används för att hålla koll på om läget redan aktiverats
bool rageMode = false;

// Spelets huvudloop, sålänge både spelare och fiende har över 0 i HP
while (player.CurrentHp > 0 && enemy.CurrentHp > 0)
{
    Console.WriteLine("\n========================");
    Console.WriteLine("       MINI BATTLE");
    Console.WriteLine("========================");

    // Visar bådas HP
    Console.WriteLine($"{player.Name}: {player.CurrentHp}/{player.MaxHp} HP");
    Console.WriteLine($"{enemy.Name}: {enemy.CurrentHp}/{enemy.MaxHp} HP");

    // Spelarens tur
    Console.WriteLine("\nDin tur!");
    Console.WriteLine("A = Attackera");
    Console.WriteLine("H = Heala");

    // Läser spelarens val
    Console.Write("Välj handling: ");
    string choice = Console.ReadLine()?.ToLower() ?? "";

    // Utför spelarens val
    if (choice == "a")
    {
        player.Attack(enemy);
    }
    else if (choice == "h")
    {
        player.Heal();
    }
    else
    {
        Console.WriteLine("Ogiltigt val! Du förlorar din tur.");
    }

    // Kontrollerar om fienden har förlorat
    if (enemy.CurrentHp <= 0)
    {
        break;
    }

    // Kontrollerar om Rage Mode ska aktiveras
    if (!rageMode && enemy.CurrentHp < enemy.MaxHp * 0.5)
    {
        rageMode = true;
        Console.WriteLine("\nFIENDEN AKTIVERAR RAGE MODE!");
    }

    // Fiendens tur
    Console.WriteLine("\nFiendens tur!");

    // Fienden väljer slumpmässigt mellan att attackera eller hela
    int enemyChoice = Random.Shared.Next(1, 3);

    if (enemyChoice == 1)
    {   
        int damage = enemy.AttackPower;
 
        // Om Rage Mode är aktiverat, öka fiendens skada med 50%
        if (rageMode)
        {
            damage = (int)Math.Round(damage * 1.5);
        }

        // 20% chans för Critical Strike
        if (Random.Shared.Next(1, 101) <= 20)
        {
            damage = (int)Math.Round(damage * 1.25);
            Console.WriteLine("FIENDEN FÅR CRITICAL STRIKE!");
        }

        // Fienden attackerar spelaren
        player.TakeDamage(damage);

        Console.WriteLine($"Fienden attackerar och gör {damage} skada!");
    }
    // Fienden helar sig själv
    else
    {
        enemy.Heal();
    }
    
    // Kontrollera om spelaren har förlorat
    if (player.CurrentHp <= 0)
    {
        break;
    }

    // Väntar på att spelaren ska trycka Enter innan nästa runda börjar
    Console.WriteLine("\nTryck Enter för nästa runda.");
    Console.ReadLine();
}

// Spelets skriver ut slut-fras
Console.WriteLine("\n========================");
Console.WriteLine("       SPELET ÄR SLUT");
Console.WriteLine("========================");

// Skriver ut resultatet
if (player.CurrentHp <= 0)
{
    Console.WriteLine("Fienden vann!");
}
else
{
    Console.WriteLine("Du vann!");
}

// Skriver ut hejdå-fras
Console.WriteLine("\nTack för att du spelade!");
