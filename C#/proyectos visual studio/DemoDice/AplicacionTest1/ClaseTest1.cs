using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Class1
{
    private static void Main(string[] args)
    {
        decimal price = 123.45m;
        int discount = 50;
        Console.WriteLine($"Price: {price:C} (Save {discount:C})");
    }
    public void diceRoll()
    {
        Random dice = new Random();
        int roll1 = dice.Next(1, 7);
        int roll2 = dice.Next(1, 7);
        int roll3 = dice.Next(1, 7);
        int total = roll1 + roll2 + roll3;
        Console.WriteLine($"Dice roll: {roll1} {roll2} {roll3}");
        if ((roll1 == roll2) || (roll2 == roll3) || (roll1 == roll3))
        {
            Console.WriteLine("You rolled doubles! +2 bonus to total!");
            total += 2;
        }
        if ((roll1 == roll2) && (roll2 == roll3))
        {
            Console.WriteLine("Yout rolled triples! +6 bonus to total!");
            total += 6;
        }
        if (total >= 15)
        {
            Console.WriteLine($"{total} points. You win");
        }
        if (total < 15)
        {
            Console.WriteLine($"{total} points. Sorry, you lose");
        }
    }
}
