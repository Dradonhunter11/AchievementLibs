using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AchievementLibs.API.Template;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace AchievementLibs.API
{
    sealed class AchievementManager
    {
        

        private static AchievementManager instance;
        private List<ModAchievement> achievementsList;

        public static AchievementManager GetInstance()
        {
            if (instance == null)
            {
                instance = new AchievementManager();
            }
            return instance;
        }


        public void unload()
        {
            achievementsList.Clear();
            instance = null;
        }

        private AchievementManager()
        {
            achievementsList = new List<ModAchievement>();
        }

        public void CheckAchievement(AchievementPlayer p)
        {
            foreach (ModAchievement achievement in achievementsList)
            {
                achievement.checkCondition(p);
            }
        }

        public void AddAchievement(ModAchievement achievement)
        {
            achievementsList.Add(achievement);
        }


        public void loadAchievement(TagCompound tag, AchievementPlayer player)
        {
            foreach (ModAchievement achievement in achievementsList)
            {
                if (tag.ContainsKey(achievement.name))
                {
                    player.addAchievementToList(achievement);
                }
            }
        }

        public List<ModAchievement> getList()
        {
            return achievementsList;
        }
    }
}
