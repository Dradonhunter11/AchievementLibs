using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace AchievementLibs.UI.SmallerComponents
{
    class AchievementReward : UIElement
    {

        private string reward = "";

        private UIText rewardText;
        public override void OnInitialize()
        {
            Width.Set(480, 0f);
            Height.Set(20f, 0f);
            Append(rewardText);
        }

        public void setText(String text)
        {
            reward = text;

            rewardText = new UIText(text);
            rewardText.Width.Set(420, 0f);
            rewardText.Height.Set(20f, 0f);
            rewardText.Left.Set(85, 0f);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            CalculatedStyle innerDim = base.GetInnerDimensions();
            Vector2 textPos = new Vector2(innerDim.X + 695, innerDim.Y + 20);

            spriteBatch.DrawString(Main.fontItemStack, "Reward : ", textPos, Color.White, 0f, innerDim.ToRectangle().Size(), 1.05f, SpriteEffects.None, 0);
        }
    }
}
