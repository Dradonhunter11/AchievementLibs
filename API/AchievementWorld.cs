using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace AchievementLibs.API
{
    class AchievementWorld : ModWorld
    {
        public override void Load(TagCompound tag)
        {
            AchievementManager.GetInstance().loadAchievement(tag, Main.LocalPlayer.GetModPlayer<AchievementPlayer>());
        }
    }
}
