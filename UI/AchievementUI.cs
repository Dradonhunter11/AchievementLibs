using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AchievementLibs.API;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.GameContent.UI.States;
using Terraria.GameInput;
using Terraria.UI;

namespace AchievementLibs.UI
{
    class AchievementUI : UIState
    {
        private UIPanel panel;
        private UIPanel title;
        public AchivementUIList list;
        private UIScrollbar Scrollbar;
        public static bool visible = false;


        public override void OnInitialize()
        {
            init();
        }

        public void init()
        {
            RemoveAllChildren();
            Width.Set(600, 0f);
            Height.Set(635, 0f);
            Top.Set(Main.screenHeight / 2 - 300, 0f);
            Left.Set(Main.screenWidth / 2 - 300, 0f);
            SetPadding(0);


            panel = new UIPanel();
            panel.Width.Set(600, 0f);
            panel.Height.Set(600, 0f);
            panel.Left.Set(5, 0f);
            panel.Top.Set(35f, 0f);
            


            List<AchievementSlot> achievementSlots = new List<AchievementSlot>();

            list = new AchivementUIList();
            list.Left.Set(-5f, 0f);
            list.Top.Set(35, 0f);
 

            Scrollbar = new UIScrollbar();
            Scrollbar.SetView(100f, 100f);
            Scrollbar.Height.Set(-35f, 1f);
            Scrollbar.Top.Set(35f, 0f);
            Scrollbar.HAlign = 1f;

            list.SetScrollbar(Scrollbar);
            panel.Append(Scrollbar);
            panel.Append(list);

            title = new UIPanel();
            title.Width.Set(200, 0f);
            title.Height.Set(50, 0f);
            title.Left.Set(200, 0f);
            title.BackgroundColor = Color.DarkBlue;

            UIText text = new UIText("Modded Achievements");
            
            text.Height.Set(25, 0);

            title.Append(text);

            Append(panel);
            Append(title);
        }

        public override void Update(GameTime gameTime)
        {
            if (PlayerInput.Triggers.Current.Inventory)
            {
                Main.playerInventory = true;
                visible = false;
            }
        }
    }
}
