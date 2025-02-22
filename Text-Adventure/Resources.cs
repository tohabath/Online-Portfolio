using System;
using System.Runtime.InteropServices;

public class Resources : Choices {
    //ATTR
    private int health = 10;
    private int repute = 10;
    private int gold = 10;
    private int morale = 10;
    private int difModifier = 0;
    private int turnsLeft = 15;
    //CONST
    //METH
    
    //Change resources based on choice and turn
    public void Reward(List<string> diary, int turn)
    {
        if (diary.Contains("boughtItemsFromWizard") && turn == 1)
        {
            SetGold(GetGold() - 5);
            SetMorale(GetMorale() + 3);
        }
        else if (diary.Contains("attackGoblinCampW") && turn == 3)
        {
            SetGold(GetGold() + 5);
        }
        else if (diary.Contains("attackGoblinCampL") && turn == 3)
        {
            SetMorale(GetMorale() - 3);
        }
        else if (diary.Contains("sneakGoblinCampW") && turn == 3)
        {
            SetMorale(GetMorale() + 2);
        }
        else if (diary.Contains("sneakGoblinCampL") && turn == 3)
        {
            SetHealth(GetHealth() - 3);
        }
        else if (diary.Contains("hadTheDrink") && turn == 4)
        {
            SetHealth(GetHealth() - 1);
            SetRepute(GetRepute() + 3);
        }
        else if (diary.Contains("joinedThief") && turn == 5)
        {
            SetGold(GetGold() + 5);
            SetRepute(GetRepute() - 4);
        }
        else if (diary.Contains("leftTownLater") && turn == 6)
        {
            SetGold(GetGold() - 5);
        }
        else if (diary.Contains("leftTownEarlier") && turn == 6)
        {
            SetMorale(GetMorale() - 5);
        }
        else if (diary.Contains("paidBandits") && turn == 7)
        {
            SetGold(GetGold() - 3);
        }
        else if (diary.Contains("slayedBandits") && turn == 7)
        {
            SetHealth(GetHealth() - 4);
        }
        else if (diary.Contains("teamUpW") && turn == 9)
        {
            SetMorale(GetMorale() + 4);
        }
        else if (diary.Contains("teamDownW") && turn == 9)
        {
            SetMorale(GetMorale() + 3);
        }
        else if (diary.Contains("teamUpL") && turn == 9)
        {
            SetMorale(GetMorale() - 4);
        }
        else if (diary.Contains("teamDownL") && turn == 9)
        {
            SetMorale(GetMorale() - 3);
            SetGold(GetGold() - 1);
        }
        else if (diary.Contains("wyrmDead") && turn == 13)
        {
            SetMorale(GetMorale() - 7);
            SetHealth(GetHealth() - 7);
            SetGold(GetGold() + 10);
            SetRepute(GetRepute() + 10);
        }
        else if (diary.Contains("wyrmAlive") && turn == 13)
        {
            SetGold(GetGold() + 5);
            SetRepute(GetRepute() + 3);
            SetHealth(GetHealth() - 2);
        }
    }
    
    //Reset resources for new game (unused)
    public void ResetResources(string difficulty)
    {
        switch (difficulty)
        {
            case "easy":
            health = 15;
            repute = 15;
            gold = 15;
            morale = 15;
            difModifier = 1;
            turnsLeft = 9;
            break;
            case "medium":
            health = 10;
            repute = 10;
            gold = 10;
            morale = 10;
            difModifier = 0;
            turnsLeft = 15;
            break;
            case "hard":
            health = 5;
            repute = 5;
            gold = 5;
            morale = 5;
            difModifier = -1;
            turnsLeft = 15;
            break;
        }
    }
    public void StatusUpdate()
    {
        Console.Clear();
        System.Console.WriteLine("STATUS UPDATE:\n");
        System.Console.WriteLine($"HEALTH: {GetHealth()}\nREPUTATION: {GetRepute()}\nGOLD: {GetGold()}\nMORALE: {GetMorale()}");
        PauseClear(3);
    }

    //Getters and setters
    public int GetHealth()
    {
        return health;
    }
    public int GetRepute()
    {
        return repute;
    }
    public int GetGold()
    {
        return gold;
    }
    public int GetMorale()
    {
        return morale;
    }
    public int GetDifMod()
    {
        return difModifier;
    }
    public int GetTurns()
    {
        return turnsLeft;
    }
    public void SetHealth(int number)
    {
        health = number;
    }
    public void SetRepute(int number)
    {
        repute = number;
    }
    public void SetGold(int number)
    {
        gold = number;
    }
    public void SetMorale(int number)
    {
        morale = number;
    }
    
    // Check if resources are depleted
    public bool CheckStatus()
    {
        if (health > 0 && repute > 0 && gold > 0 && morale > 0)
        {
            return true;
        }
        else
        {
            Console.Clear();
            if (health <= 0)
            {
                System.Console.WriteLine("[GAME OVER] You died!");
            }
            else if (repute <= 0)
            {
                System.Console.WriteLine("[GAME OVER] People hate you!");
            }
            else if (gold <= 0)
            {
                System.Console.WriteLine("[GAME OVER] You ran out of money!");
            }
            else if (morale <= 0)
            {
                System.Console.WriteLine("[GAME OVER] You’ve lost all hope!");
            }
            PauseClear(5);
        }
        return false;
    }
}