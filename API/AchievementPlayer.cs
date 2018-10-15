using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AchievementLibs.API.Template;
using AchievementLibs.UI;
using Terraria;
using Terraria.GameInput;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace AchievementLibs.API
{
    class AchievementPlayer : ModPlayer
    {
        public List<string> doneAchievementList = new List<string>();

        public override TagCompound Save()
        {
            TagCompound tag = new TagCompound();
            foreach (string achievmentName in doneAchievementList)
            {
                tag.Add(achievmentName, true);
            }
            return tag;
        }

        public void addAchievementToList(ModAchievement achievement)
        {
            foreach (string s in doneAchievementList)
            {
                if (s == achievement.name)
                {
                    return;
                }
            }
            doneAchievementList.Add(achievement.name);
        }

        public bool checkAchievement(String name)
        {
            foreach (string s in doneAchievementList)
            {
                if (s == name)
                {
                    return true;
                }
            }
            return false;
        }

        public override void PreUpdate()
        {
            AchievementManager.GetInstance().CheckAchievement(this);
        }

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (AchievementLibs.openAchievementMenu.JustReleased)
            {
                AchievementUI.visible = !AchievementUI.visible;
            }
        }
    }
}
