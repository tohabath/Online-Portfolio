using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

public class RandResults {
    //ATTR
    private Random random = new();
    //CONST
    //METH
    public bool SkillCheck(double modifier, double difficulty)
    {
        double number = random.Next(1, 20) + (modifier / 5);
        return number >= difficulty;
    }

}