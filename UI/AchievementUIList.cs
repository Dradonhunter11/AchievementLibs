using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AchievementLibs.API;
using AchievementLibs.API.Template;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace AchievementLibs.UI
{

    class AchivementUIList : UIList
    {
        public override void OnInitialize()
        {
            Width.Set(555, 0f);
            Height.Set(-35, 1f);
            SetPadding(0);

            loadAchievement();
            ListPadding = 2;
        }

        internal void loadAchievement()
        {
            int index = 0;
            foreach (ModAchievement achivement in AchievementManager.GetInstance().getList())
            {
                AchievementSlot slot = new AchievementSlot();
                slot.setProperties(achivement, index);
                slot.Left.Set(0, 0f);

                Add(slot);
                index++;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            /*
            if (SteamID64Checker.getInstance().verifyID())
            {
                Texture2D bound2 = new Texture2D(Main.graphics.GraphicsDevice, 1, 1);
                bound2.SetData<Color>(new Color[] { Color.White });

                Rectangle rec2 = GetInnerDimensions().ToRectangle();
                spriteBatch.Draw(bound2, new Rectangle(rec2.X, rec2.Y, rec2.Width, rec2.Height), Color.Green);
                spriteBatch.Draw(bound2, new Rectangle(rec2.X, rec2.Y, 1, rec2.Height), Color.Green);
                spriteBatch.Draw(bound2, new Rectangle(rec2.X + rec2.Width - 1, rec2.Y, 1, rec2.Height), Color.Green);
                spriteBatch.Draw(bound2, new Rectangle(rec2.X, rec2.Y + rec2.Height - 1, rec2.Width, 1), Color.Green);
            }*/

        }
    }

}
