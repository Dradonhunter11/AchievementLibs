using System;
using System.Collections.Generic;
using AchievementLibs.API;
using AchievementLibs.API.Template;
using AchievementLibs.UI;
using AchievementLibs.UI.Setting;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace AchievementLibs
{
	class AchievementLibs : Mod
	{
	    public static NewInGameSetting newSetting;
	    public static AchievementUI achievementUI;
	    public UserInterface achievementInterface;
	    public static ModHotKey openAchievementMenu;

        public AchievementLibs()
		{
		    Properties = new ModProperties()
		    {
		        Autoload = true,
		        AutoloadGores = true,
		        AutoloadSounds = true,
		        AutoloadBackgrounds = true

		    };
        }

	    public override void Load()
	    {
	        openAchievementMenu = RegisterHotKey("Open ModAchievement Menu", "V");
	        newSetting = new NewInGameSetting();
        }

	    public override void Unload()
	    {
	        AchievementManager.GetInstance().unload();
	        achievementUI = null;
	        achievementInterface = null;
	    }

	    public override void UpdateUI(GameTime gameTime)
	    {
	        if (achievementInterface != null && AchievementUI.visible)
	        {
	            achievementInterface.Update(gameTime);
	        }
	    }

	    public override void PostAddRecipes()
	    {
	        achievementUI = new AchievementUI();
	        achievementUI.Activate();
	        achievementInterface = new UserInterface();
	        achievementInterface.SetState(achievementUI);
        }

	    public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
	    {
	        int MouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            int Setting = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Ingame Options"));

            layers[Setting] = new LegacyGameInterfaceLayer(
                "Vanilla: Ingame Options",
	            delegate
	            {
	                if (Main.ingameOptionsWindow)
	                {
	                    newSetting.Draw(Main.spriteBatch);
	                }

	                return true;
	            },
	            InterfaceScaleType.UI);

	        layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(
	            "AchievementsLibs : Mod Achievement List",
	            delegate
	            {
	                if (AchievementUI.visible)
	                {
	                    Main.playerInventory = false;
	                    achievementUI.Draw(Main.spriteBatch);
	                }
	                return true;
	            },
	            InterfaceScaleType.UI)
	        );
        }


	    public override object Call(params object[] args)
        {
            try
            {
                string call = args[0] as string;
                if (call == "AddAchievementWithSpecialReward")
                {
                    ModCallAchievement achievement = new ModCallAchievement(args[1] as Mod);
                    achievement.name = args[2] as string;
                    achievement.description = args[3] as string;
                    achievement.TexturePath = args[4] as string;
                    achievement.itemReward = args[5] as int[];
                    achievement.itemQuantity = args[6] as int[];
                    achievement.rewards = args[7] as Action<Player>;
                    achievement.setRewardText();
                    achievement.rewardDesc += args[8] as string;
                    achievement.condition = args[9] as Func<bool>;
                    achievement.AutoLoad(args[1] as Mod);
                    AchievementManager.GetInstance().AddAchievement(achievement);
                }
                else if (call == "AddAchievementWithoutReward")
                {
                    ModCallAchievement achievement = new ModCallAchievement(args[1] as Mod);
                    achievement.name = args[2] as string;
                    achievement.description = args[3] as string;
                    achievement.TexturePath = args[4] as string;
                    achievement.condition = args[5] as Func<bool>;
                    achievement.itemReward = new int[0];
                    achievement.AutoLoad(args[1] as Mod);
                    AchievementManager.GetInstance().AddAchievement(achievement);
                }
                else if (call == "AddAchievementWithReward")
                {
                    ModCallAchievement achievement = new ModCallAchievement(args[1] as Mod);
                    achievement.name = args[2] as string;
                    achievement.description = args[3] as string;
                    achievement.TexturePath = args[4] as string;
                    achievement.itemReward = args[5] as int[];
                    achievement.itemQuantity = args[6] as int[];
                    achievement.setRewardText();
                    achievement.condition = args[7] as Func<bool>;
                    achievement.AutoLoad(args[1] as Mod);
                    AchievementManager.GetInstance().AddAchievement(achievement);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return base.Call(args);
        }
    }
}

