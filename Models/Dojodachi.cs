using System.ComponentModel.DataAnnotations;
namespace Dojodachi.Models;
using System.Text.Json;
#pragma warning disable CS8618

public class DojodachiPet
{

    public int Happiness { get; set; }

    public int Fullness { get; set; }

    public int Energy { get; set; }

    public int Meals { get; set; }

    public DojodachiPet()
    {
        Happiness = 20;
        Fullness = 20;
        Energy = 50;
        Meals = 3;
    }

    public string Feed()
    {
        // if dojodachi doesn't have enough meals
        if (this.Meals < 1)
        {
            Console.WriteLine("Dojodachi doesn't have any meals to eat!");
            return "Dojodachi doesn't have any meals to eat!";
        }
        else
        {
            // remove meal cost
            this.Meals -= 1;
            // 25% chance Dojodachi doesn't like eating
            Random rand = new Random();
            int randNum = rand.Next(4);
            if (randNum == 0)
            {
                Console.WriteLine("Your DojodachiPet didn't like that...");
                return "Your DojodachiPet didn't like that...";
            }
            else
            {
                int fullness = rand.Next(5, 11);
                this.Fullness += fullness;
                Console.WriteLine($"Your Dojodachi used a meal and gained {fullness} fullness.");
                return $"Your Dojodachi used a meal and gained {fullness} fullness.";
            }
        }
    }

    public string Play()
    {
        if (this.Energy < 5)
        {
            System.Console.WriteLine("Not enough energy to play right now...");
            return "Not enough energy to play right now...";
        }
        else
        {
            // remove energy cost
            this.Energy -= 5; // 25% chance Dojodachi doesn't like playing
            Random rand = new Random();
            int randNum = rand.Next(4);
            if (randNum == 0) // console dislike
            {
                System.Console.WriteLine("Your Dojodachi didn't like that...");
                return "Your Dojodachi didn't like that...";
            }
            else // add random happiness
            {
                int happiness = rand.Next(5, 11);
                this.Happiness += happiness;
                System.Console.WriteLine($"Your Dojodachi used 5 Energy and gained {happiness} happiness.");
                return $"Your Dojodachi used 5 Energy and gained {happiness} happiness.";
            }
        }
    }

    public string Work()
    {
        if (this.Energy < 5) // console dislike
        {
            System.Console.WriteLine("Not enough energy to work right now...");
            return "Not enough energy to work right now...";
        }
        else
        {
            this.Energy -= 5; // remove energy cost
            Random rand = new Random();
            int meals = rand.Next(1,3);
            this.Meals += meals;
            System.Console.WriteLine($"Your Dojodachi used 5 Energy and gained {meals} meals");
            return $"Your Dojodachi used 5 Energy and gained {meals} meals";
        }
    }

    public string Sleep()
    {
        this.Energy += 15;
        this.Fullness -= 5;
        this.Happiness -= 5;
        return "Your Dojodachi lost 5 Fullness and 5 Happiness but gained 15 Energy.";
    }

    public bool CheckWin()
    {
        return this.Energy > 100 && this.Fullness > 100 && this.Happiness > 100;
    }

    public bool CheckLose() 
    {
        return this.Fullness < 1 || this.Happiness < 1;
    }

}