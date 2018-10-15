using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace AchievementLibs.API.Template
{
    class ModCallAchievement : ModAchievement
    {
        public Action<Player> rewards;
        public string TexturePath = "";
        public int[] itemReward;
        public int[] itemQuantity;

        public override bool AutoLoad(Mod mod, string classPath = "")
        {
            try
            {
                texture = mod.GetTexture(TexturePath);
            }
            catch (Exception e)
            {
                texture = ModLoader.GetMod("AchievementLibs").GetTexture("Texture/Default");
            }

            return true;
        }

        public ModCallAchievement(Mod mod) : base(mod)
        {

        }



        public void setRewardText()
        {
            rewardDesc = "";
            if (itemReward != null)
            {
                foreach (int i in itemReward)
                {
                    foreach (int j in itemQuantity)
                        rewardDesc += "[i:" + i + "] x" + j + ", ";
                }
            }
        }

        public override void reward(Player p)
        {
            if (itemReward != null)
            {
                foreach (int i in itemReward)
                {
                    foreach (int j in itemQuantity)
                        Item.NewItem(p.Center, i, j, true, 0, true, false);
                }
            }
            if (rewards != null)
            {
                rewards.Invoke(p);
            }

        }
    }
}
