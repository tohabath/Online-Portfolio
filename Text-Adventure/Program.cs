using System;

namespace Text_Adventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ATTR
            bool check;
            //CONST
            Choices story = new();
            RandResults dice = new();
            Resources resources = new();
            Settings settings = new();
            //NEW
            story.ResetStory();
            resources.ResetResources(settings.GetDifficulty());
            Console.Clear();

            for (int i = 0; i <= resources.GetTurns(); i++)
            {
                check = true;
                switch (i)
                {
                    case 3:
                    check = dice.SkillCheck(resources.GetMorale(), 15 + resources.GetDifMod());
                    break;
                    case 9:
                    check = dice.SkillCheck(resources.GetRepute(), 10 + resources.GetDifMod());
                    break;
                }
                story.Story(i, check);
                resources.Reward(story.GetDiary(), i);
                resources.StatusUpdate();
                if (resources.CheckStatus() == false)
                {
                    i = 100;
                }
            }
        }
    }
}