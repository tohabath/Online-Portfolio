using System;
using System.Collections;
using System.ComponentModel;

public class Choices {
    //RULES
    #nullable disable
    //ATTR
    private int phase;
    private string choice = "";
    private List<string> diary = new();
    //CONST
    //METH
    public void PauseClear(int time)
    {
        PlayAnimation(time);
        Console.Clear();
    }
    public void MakeChoice()
    {
        System.Console.Write("> "); 
        choice = Console.ReadLine();
        Console.Clear();
    }
    public void PlayAnimation(double timer)
    {
        bool animating = true;
        double timePassed = 0;
        int phase = 0;
        System.Console.WriteLine("");
        while (animating)
        {
            switch(phase)
            {
                case 0:
                System.Console.Write(@"\");
                phase += 1;
                break;
                case 1:
                System.Console.Write("|");
                phase += 1;
                break;
                case 2:
                System.Console.Write("/");
                phase += 1;
                break;
                case 3:
                System.Console.Write("—");
                phase += 1;
                break;
                case 4:
                System.Console.Write(@"\");
                phase += 1;
                break;
                case 5:
                System.Console.Write("|");
                phase += 1;
                break;
                case 6:
                System.Console.Write("/");
                phase += 1;
                break;
                case 7:
                System.Console.Write("—");
                phase = 0;
                break;
            }
            
            if (timePassed == timer)
            {
                animating = false;
            }
            else
            {
                timePassed += 0.5;
            }
            
            Thread.Sleep(500);
            System.Console.Write("\b \b");
        }
    }
    public void ResetStory()
    {
        phase = 1;
        choice = "";
        diary.Clear();
    }
    public List<string> GetDiary()
    {
        return diary;
    }
    public int GetPhase()
    {
        return phase;
    }
    public void SetPhase(int number)
    {
        phase = number;
    }
    public void Story(int number, bool result)
    {
        phase = number;
        switch(phase)
        {
            case 1:
            System.Console.WriteLine("A wizard approaches you.\n“I have seen that look on many youths”, he says,\npeering into your soul with piercing blue eyes,\n“you are itching for adventure!\nI can supply you with all the essentials,\nwith small compensation so I can resupply later.\nInterested?”");
            PauseClear(15);
            System.Console.WriteLine("Buy supplies from the wizard (y/n)? [+3 Morale | -5 Gold]");
            MakeChoice();
            switch(choice)
            {
                case "y":
                diary.Add("boughtItemsFromWizard");
                System.Console.WriteLine("“Wisely done!” Says the wizard, and soon you are fully stocked.");
                break;
                case "n":
                diary.Add("didNotBuyFromWizard");
                System.Console.WriteLine("“As you like,” says the wizard, “good luck out there!”\n\nThe two of you part ways.");
                break;
            }
            PauseClear(5);
            break;

            case 2:
            System.Console.WriteLine("You follow the road leading into the dark woods.\nThere’s a camp of goblins a few miles in,\nbodies of humans piled in a heap for easy looting.\nThey’re occupied with revelry; you might take them by surprise,\nor you may have an easier time sneaking past.");
            PauseClear(15);
            System.Console.WriteLine("Attack the goblin camp (a), or sneak past (s)?");
            MakeChoice();
            switch(choice)
            {
                case "a":
                diary.Add("attackGoblinCamp");
                System.Console.WriteLine("You decide on a direct confrontation, complete with a battlecry!");
                if (diary.Contains("boughtItemsFromWizard"))
                {
                    System.Console.WriteLine("It's a good thing you came prepared!");
                }
                break;
                case "s":
                diary.Add("sneakGoblinCamp");
                System.Console.WriteLine("You decide to use the moment to sneak past.\nRemember to breathe easily; holding it in will make you noisier!");
                break;
            }
            PauseClear(5);
            break;
            case 3:
                if (diary.Contains("attackGoblinCamp"))
                {
                    switch (result)
                    {
                        case true:
                        diary.Add("attackGoblinCampW");
                        System.Console.WriteLine("[SUCCESS] By the time the goblins hear you,\nYou’ve already taken down their nightwatch.\nThey fight back, but unprepared they quickly fall.\nThe last of them surrender their loot!\n\n[+5 Gold]");
                        break;
                        case false:
                        diary.Add("attackGoblinCampL");
                        System.Console.WriteLine("[FAILURE] The goblins, having kept their weapons\nby their sides while they celebrated,\nimmediately arm themselves and knock you down.\nYou scramble away, as the goblins are\nconsumed with laughter over your folly.\n\n[-3 Morale]");
                        break;
                    }
                }
                else
                {
                    switch (result)
                    {
                        case true:
                        diary.Add("sneakGoblinCampW");
                        System.Console.WriteLine("[SUCCESS] You quietly move past the goblin camp.\nThe nightwatch is too distracted by sounds of celebration to notice!\n\n[+2 Morale]");
                        break;
                        case false:
                        diary.Add("sneakGoblinCampL");
                        System.Console.WriteLine("[FAILURE] A few unfortunate footfalls land on crunchy leaves\nand traitorous twigs.\nThe goblin nightwatch notices, but you are obscured by darkness.\nThey fire some arrows in your direction,\nand one of them scratches your side as it zips past!\nYou’ll live, but it was a close call.\n\n[-3 Health]");
                        break;
                    }
                }
                PauseClear(10);
            break;
            case 4:
            System.Console.WriteLine("You reach a clearing, and soon find the inn of a small town.\nThe sassy barmaid offers you a “house specialty, on the house!”\nThe other patrons look at you knowingly;\nit’s likely this is some form of cultural hazing.\nBut if it’s a free drink, how can you refuse?");
            PauseClear(15);
            System.Console.WriteLine("Will you have the drink (y/n)? [+3 Reputation | -1 Health]");
            MakeChoice();
            switch(choice)
            {
                case "y":
                diary.Add("hadTheDrink");
                System.Console.WriteLine("The bitterness hits your nose before the liquid touches your tongue.\nImpressively, you down the whole pint in four long gulps.\nYou think the taste is supposed to be sweet with cinnamon,\nbut the sweet is downplayed by the extra helping of spice stirred into spoiled milk.\nYou find the nearest bucket, to spew.\nThe others are amused, but also regard you with respect.");
                PauseClear(15);
                break;
                case "n":
                diary.Add("declinedDrink");
                System.Console.WriteLine("You politely decline the drink.\nThe barmaid insists at first,\nbut concedes when you firmly protest.\nThe others are disappointed, but not offended.");
                PauseClear(5);
                break;
            }
            break;
            case 5:
            System.Console.WriteLine("A man wearing blacksmithing gloves joins your table.\n“There’s a caravan bringing a wealthy baron through this town tomorrow.\nInterested in helping me relieve him of some coin?”");
            PauseClear(10);
            System.Console.WriteLine("Will you join the thief (y/n)? [-4 Reputation | +5 Gold]");
            MakeChoice();
            switch (choice)
            {
                case "y":
                diary.Add("joinedThief");
                System.Console.WriteLine("The town doesn’t approve of thievery,\nbut the baron passing through has been known to oppress his workforce,\nso they don’t run you out for your misdeed.\nThe thief treats you to a good meal, for a job well done.");
                break;
                case "n":
                diary.Add("refusedThief");
                System.Console.WriteLine("“Suit yourself,” says the thief,\n“I don’t trust anyone around town to help, anyway.”\nYou mention to local law enforcement about the thief’s interest in the baron,\nbut no attempt is made on the baron when he passes through.");
                break;
            }
            PauseClear(10);
            break;
            case 6:
            if (diary.Contains("joinedThief"))
            {
                System.Console.WriteLine("Your thievery has earned you a few easy nights at the inn,");
            }
            else
            {
                System.Console.WriteLine("You’ve done some odd jobs around town for coin,");
            }
            System.Console.WriteLine("but the innkeeper charges five gold a night.\nThe plan was to rest the night and head out tomorrow morning.\nPerhaps you’ll need to cut your stay short?");
            PauseClear(10);
            System.Console.WriteLine("Will you stay another night (y/n)? [-5 Gold] OR [-5 Morale]");
            MakeChoice();
            switch(choice)
            {
                case "y":
                diary.Add("leftTownLater");
                System.Console.WriteLine("You decide to pay a final fee, buying you time to rest and prepare.");
                break;
                case "n":
                diary.Add("leftTownEarlier");
                System.Console.WriteLine("You make your final preparations, and leave town in the night.");
                break;
            }
            PauseClear(5);
            break;
            case 7:
            System.Console.WriteLine("On your way, you find yourself at a roadblock.\nBandits have set up a toll collection,\nthreatening your life if you don’t pay the fine.");
            PauseClear(10);
            System.Console.WriteLine("Will you pay the toll (y/n)? [-3 Gold] OR [-4 Health]");
            MakeChoice();
            switch(choice)
            {
                case "y":
                diary.Add("paidBandits");
                System.Console.WriteLine("You offer the fee, and the bandits let you pass.");
                PauseClear(5);
                break;
                case "n":
                diary.Add("slayedBandits");
                System.Console.WriteLine("You offer a different kind of metal for passage;\nthe steel of your blade! You fight your way through the roadblock,\nshowing impressively brutish strength as you\nsmite your enemies!\nYou walk away with some bad wounds,\nbut you’ve also likely prevented them from harrassing other travelers.");
                PauseClear(15);
                break;
            }
            break;
            case 8:
            System.Console.WriteLine("At last, you arrive at clay valley,\nwhere a wyrm has been rumored to destroy settlers and consume their bodies.\nAnother adventurer has arrived with similar intentions-\nto defeat the monster, and raid its nest.\nShe considers you a rival,\nbut you might convince her to join forces.");
            PauseClear(15);
            System.Console.WriteLine("Will you persuade the adventurer to help you (y/n)?");
            MakeChoice();
            switch(choice)
            {
                case "y":
                diary.Add("teamUp");
                System.Console.WriteLine("In order to convince her,\nyou will have to lean on your reputation.\nHopefully, she’ll trust you’re a good team player.");
                break;
                case "n":
                diary.Add("teamDown");
                System.Console.WriteLine("While not keen to fight her later,\nyou doubt the two of you would\nwork well together.\nThe two of you part ways... for now.");
                break;
            }
            PauseClear(10);
            break;
            case 9:
            if (diary.Contains("teamUp"))
            {
                switch(result)
                {
                    case true:
                    diary.Add("teamUpW");
                    System.Console.WriteLine("[SUCCESS] “Fine,” she concedes,\n“but we’re splitting its horde 60/40!”\nYou agree, as your main interest lies\nin the glory of the hunt,\nand the two of you journey together. [+4 Morale]");
                    break;
                    case false:
                    diary.Add("teamUpL");
                    System.Console.WriteLine("[FAILURE] She remains unconvinced,\nsuspecting you’ll find some way to cheat her out of the reward.\nShe threatens that if you get in her way,\nshe’ll see to it that you suffer.\nYou leave, dreading your future confrontation. [-4 Morale]");
                    break;
                }
            }
            else
            {
                switch(result)
                {
                    case true:
                    diary.Add("teamDownW");
                    System.Console.WriteLine("The following night, you sleep in your tent.\nA company finds you as they’re passing through,\nand camp nearby for safety.\nYou rest peacefully. [+3 Morale]");
                    break;
                    case false:
                    diary.Add("teamDownL");
                    System.Console.WriteLine("The following night, you sleep in your tent.\nThe next morning, you search your belongings,\nand find some things missing!\nYou’ll have to travel with a lighter pack,\nand a lighter coinpurse. [-1 Gold | -3 Morale]");
                    break;
                }
            }
            PauseClear(10);
            break;
            case 10:
            System.Console.WriteLine("You make your way down to the wyrm’s den, where its nest must lie.\nThe monster isn’t there, doubtlessly out on a hunt.\nThe cavern is deep, tunneling and winding several miles in.\nIf the wyrm returns, you’ll have to fight it in its own home.\nOn the other hand, you may have time\nto set some trap and get the upper hand.");
            PauseClear(15);
            System.Console.WriteLine("Will you fight it outside (o), or inside (i) the cave?");
            MakeChoice();
            switch(choice)
            {
                case "o":
                diary.Add("wyrmOutside");
                System.Console.WriteLine("You decide to confront the wyrm out in the open,\nHoping the larger space and ease of navigation\nwill be to your advantage.");
                break;
                case "i":
                diary.Add("wyrmInside");
                System.Console.WriteLine("You decide to venture into the wyrm’s den,\nthinking to set up a trap to immobilize the monster.");
                break;
            }
            PauseClear(10);
            break;
            case 11:
            if (diary.Contains("wyrmOutside"))
            {
                if (diary.Contains("teamUpW"))
                {
                    System.Console.WriteLine("In a joint effort with your companion,");
                }
                else
                {
                    System.Console.WriteLine("By the performance of an impressive feat,");
                }
                System.Console.WriteLine("you manage to topple the large stones above the entrance,\ncutting the wyrm off from where it nests.\nYou spend the remaining time practicing,\nwaiting for the target to come to you.");
            }
            else
            {
                System.Console.WriteLine("You make your way inside, careful to light as many torches as you can find.\nThe interior is littered with fallen adventurers,\nbodies of women holding skeletons of babes for the last time.\nOne adventurer had the foresight to map out the tunnel as he went,\nwhich you rely on in order to set the trap for the monster’s return.");
            }
            PauseClear(15);
            break;
            case 12:
            System.Console.WriteLine("At last, the wyrm approaches!");
            if (diary.Contains("wyrmInside"))
            {
                System.Console.WriteLine("The several ropes you’ve hooked across\nthe sides of the tunnel snap as it enters,\ntriggering a complex demolition system that leaves the wyrm\nburied in a man-made cave-in.\nNow is your chance!");
            }
            else if (diary.Contains("teamUpW"))
            {
                System.Console.WriteLine("Your companion launches throwable potions at the wyrm’s wings,\nthe pitch just right for them to land and explode against the beast.\nIt crashes down, and you move in to wound its legs!\nThe monster is immobile; now is your chance!");
            }
            else
            {
                System.Console.WriteLine("You brace yourself, waiting for it to dive down and swipe at you.\nAs it nears, you swipe your sword,\ncutting through its wing in an expert stroke.\nThe monster struggles to fly up, only for the pain to overwhelm it as it falls.\nNow is your chance!");
            }
            PauseClear(15);
            System.Console.WriteLine("Will you slay the wyrm (y/n)? [-7 Health -7 Morale | +10 Gold +10 Reputation] OR [-2 Health | +5 Gold +3 Reputation]");
            MakeChoice();
            switch (choice)
            {
                case "y":
                diary.Add("wyrmDead");
                System.Console.WriteLine("This is the moment you have prepared for.\nOnward, for glory! For VICTORY!");
                PauseClear(5);
                break;
                case "n":
                diary.Add("wyrmAlive");
                System.Console.WriteLine("No... your work here is done.\nWithout healing, the wyrm won’t be able to leave the valley.\nThe locals will be disappointed the wyrm still lives,\nbut you have done your part to ensure it will not harm them further.");
                PauseClear(10);
                break;
            }
            System.Console.WriteLine("Your reward will come later...\nIf you survive.");
            PauseClear(5);
            break;
            case 13:
            if (diary.Contains("wyrmAlive") && diary.Contains("teamUpL"))
            {
                System.Console.WriteLine("On your way back, you are accosted by a familiar face.\n“I told you not to get in my way!\nThe wyrm is defeated, but none will know it was you!”\nShe throws bottled potions that explode when they fall near you!\nThe force throws you back, shins bleeding,\nbut you rush at her with your sword and knock her down.\nShe throws a final potion, the force of its explosion almost breaking your back!\nYou both are on the ground, scrambling to recover...\nBut who will be the victor?");
                PauseClear(15);
            }
            else if (diary.Contains("wyrmDead"))
            {
                System.Console.WriteLine("You engage the monster, sword clashing against nail, tooth, and scale!\nThe wyrm bites deeply into your leg, and your sword cuts through its tongue!\nThe fight drives you to exhaustion, and the wyrm’s breath is shallow...\nWho will be the victor?");
                PauseClear(10);
            }
            else
            {
                System.Console.WriteLine("Your journey home is a slow one at first,\nbut soon you are overtaken by a goblin mercenary!\n“I saw it was you at camp,” he sneers,\n“and I’ll see to it you regret crossing paths with me!”\nThe two of you share blows. The goblin is well-armored, but you are well-skilled.\nHe cuts into your shins lightly, but with a vicious kick you knock him over.\nBut will you escape his reach?");
                PauseClear(15);
            }
            break;
            case 14:
            System.Console.WriteLine("You have survived, victorious!\nUltimately, you overcome your foes and return home,\nfrom humble traveler to legendary hero!\n\nTHE END");
            break;
        }
    }
}