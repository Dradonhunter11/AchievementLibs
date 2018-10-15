using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AchievementLibs.API;
using AchievementLibs.API.Template;
using AchievementLibs.UI.SmallerComponents;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.Graphics;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.UI.Chat;

namespace AchievementLibs.UI
{
    class AchievementSlot : UIPanel
    {
        private ModAchievement achievement;
        private bool completed;
        private int index;
        private UIImage picture;

        public override void OnInitialize()
        {
            BackgroundColor = new Color(26, 40, 89) * 0.8f;
            BorderColor = new Color(13, 20, 44) * 0.8f;

            Width.Set(550, 0f);
            Height.Set(100, 0f);
            Left.Set(5, 0f);
            Top.Set(2, 0f);


            picture.Left.Set(15, 0f);
            picture.Top.Set(10, 0f);
            picture.Height.Set(64, 0f);
            picture.Width.Set(64, 0f);
            Append(picture);
        }


        internal void setProperties(ModAchievement achievement, int i)
        {
            this.achievement = achievement;
            picture = new UIImage(achievement.texture);


            index = i;
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            Color hoverColor1 = (IsMouseHovering) ? Color.White : Color.Gray;

            base.DrawSelf(spriteBatch);

            Texture2D texture = new Texture2D(Main.graphics.GraphicsDevice, 1, 1);
            texture.SetData<Color>(new Color[] { Color.White });


            picture.Left.Set(2, 0f);
            picture.Top.Set(5, 0f);

            Texture2D desc = TextureManager.Load("Images/UI/Achievement_InnerPanelBottom");

            float width = 460;

            DrawName(spriteBatch, hoverColor1, width);
            DrawDescription(spriteBatch, desc, hoverColor1, width);
            if (achievement.rewardDesc != "")
            {
                DrawReward(spriteBatch, hoverColor1, width);
            }
            DrawAtMouse(spriteBatch);
        }

        private void DrawDescription(SpriteBatch spriteBatch, Texture2D desc, Color hoverColor1, float width)
        {
            Vector2 descriptionPosition = new Vector2(GetInnerDimensions().X + 70, GetInnerDimensions().Y + 21);

            if (achievement.rewardDesc != "")
            {
                spriteBatch.Draw(desc, descriptionPosition, new Rectangle(0, 0, 6, desc.Height), hoverColor1, 0f, Vector2.Zero,
                    new Vector2(1f, 1f), SpriteEffects.None, 1f);
                spriteBatch.Draw(desc, new Vector2(descriptionPosition.X + 6f, descriptionPosition.Y),
                    new Rectangle?(new Rectangle(6, 0, 7, desc.Height)), hoverColor1, 0f, Vector2.Zero,
                    new Vector2((width - 12f) / 7f, 1f), SpriteEffects.None, 1f);
                spriteBatch.Draw(desc, new Vector2(descriptionPosition.X + width - 6f, descriptionPosition.Y),
                    new Rectangle?(new Rectangle(13, 0, 6, desc.Height)), hoverColor1, 0f, Vector2.Zero, new Vector2(1f, 1f),
                    SpriteEffects.None, 1f);


                ChatManager.DrawColorCodedStringWithShadow(spriteBatch, Main.fontMouseText, achievement.description,
                    new Vector2(descriptionPosition.X + 6f, descriptionPosition.Y + 6f), Color.White, 0f, Vector2.Zero, new Vector2(0.7f, 0.7f));
            }
            else
            {
                spriteBatch.Draw(desc, descriptionPosition, new Rectangle(0, 0, 6, desc.Height), hoverColor1, 0f, Vector2.Zero,
                    new Vector2(1f, 1.55f), SpriteEffects.None, 1f);
                spriteBatch.Draw(desc, new Vector2(descriptionPosition.X + 6f, descriptionPosition.Y),
                    new Rectangle?(new Rectangle(6, 0, 7, desc.Height)), hoverColor1, 0f, Vector2.Zero,
                    new Vector2((width - 12f) / 7f, 1.55f), SpriteEffects.None, 1f);
                spriteBatch.Draw(desc, new Vector2(descriptionPosition.X + width - 6f, descriptionPosition.Y),
                    new Rectangle?(new Rectangle(13, 0, 6, desc.Height)), hoverColor1, 0f, Vector2.Zero, new Vector2(1f, 1.55f),
                    SpriteEffects.None, 1f);
                ChatManager.DrawColorCodedStringWithShadow(spriteBatch, Main.fontMouseText, SpliceText(achievement.description),
                    new Vector2(descriptionPosition.X + 6f, descriptionPosition.Y + 6f), Color.White, 0f, Vector2.Zero, new Vector2(0.8f, 0.8f));
            }
        }

        private void DrawName(SpriteBatch spriteBatch, Color hoverColor1, float width)
        {
            Vector2 vector2 = GetInnerDimensions().GetVector();
            Texture2D top = TextureManager.Load("Images/UI/Achievement_InnerPanelTop");
            Vector2 titlePosition = GetInnerDimensions().GetVector();
            titlePosition.X += 70;
            titlePosition.Y -= 5;

            spriteBatch.Draw(top, titlePosition, new Rectangle(0, 0, 2, top.Height), hoverColor1);
            spriteBatch.Draw(top, new Vector2(titlePosition.X + 2f, titlePosition.Y),
                new Rectangle?(new Rectangle(2, 0, 2, top.Height)), hoverColor1, 0f, Vector2.Zero,
                new Vector2((width - 4f) / 2f, 1f), SpriteEffects.None, 1f);
            spriteBatch.Draw(top, new Vector2(titlePosition.X + width - 2f, titlePosition.Y),
                new Rectangle?(new Rectangle(4, 0, 2, top.Height)), hoverColor1);

            if (achievement.mod != null && achievement.mod.FileExists("icon.png"))
            {
                vector2.X += 74;
                Texture2D icon = Texture2D.FromStream(Main.graphics.GraphicsDevice,
                    new MemoryStream(achievement.mod.GetFileBytes("icon.png")));
                Vector2 newScale = new Vector2(0.20f, 0.20f);
                spriteBatch.Draw(icon, vector2, icon.Bounds, Color.White, 0, Vector2.Zero, newScale, SpriteEffects.None, 1f);
                ChatManager.DrawColorCodedStringWithShadow(spriteBatch, Main.fontMouseText, achievement.name,
                    new Vector2(titlePosition.X + 22f, titlePosition.Y + 4f), Color.Yellow, 0f, Vector2.Zero, new Vector2(0.8f, 0.8f));
            }
            else
            {
                ChatManager.DrawColorCodedStringWithShadow(spriteBatch, Main.fontMouseText, achievement.name,
                    new Vector2(titlePosition.X + 6f, titlePosition.Y + 4f), Color.Yellow, 0f, Vector2.Zero, new Vector2(0.8f, 0.8f));
            }
        }

        private void DrawReward(SpriteBatch spriteBatch, Color hoverColor1, float width)
        {
            Vector2 vector2 = GetInnerDimensions().GetVector();
            Texture2D top = TextureManager.Load("Images/UI/Achievement_InnerPanelTop");
            Vector2 rewardPosition = GetInnerDimensions().GetVector();
            rewardPosition.X += 70;
            rewardPosition.Y += 62;

            spriteBatch.Draw(top, rewardPosition, new Rectangle(0, 0, 2, top.Height), hoverColor1);
            spriteBatch.Draw(top, new Vector2(rewardPosition.X + 2f, rewardPosition.Y),
                new Rectangle?(new Rectangle(2, 0, 2, top.Height)), hoverColor1, 0f, Vector2.Zero,
                new Vector2((width - 4f) / 2f, 1f), SpriteEffects.None, 1f);
            spriteBatch.Draw(top, new Vector2(rewardPosition.X + width - 2f, rewardPosition.Y),
                new Rectangle?(new Rectangle(4, 0, 2, top.Height)), hoverColor1);
            vector2.X += 74;
            Vector2 newScale = new Vector2(0.20f, 0.20f);
            ChatManager.DrawColorCodedStringWithShadow(spriteBatch, Main.fontMouseText, "Rewards : " +  achievement.rewardDesc,
                new Vector2(rewardPosition.X + 6f, rewardPosition.Y + 2f), Color.Yellow, 0f, Vector2.Zero, new Vector2(0.8f, 0.8f));
        }

        private void DrawAtMouse(SpriteBatch spriteBatch)
        {
            AchievementPlayer player = Main.LocalPlayer.GetModPlayer<AchievementPlayer>();
            if (IsMouseHovering)
            {
                bool state = player.checkAchievement(achievement.name);
                string stringState = (state) ? "[c/00FF00:Completed]" : "[c/FF0000:Not Completed]";
                Main.hoverItemName = "State: " + stringState + "\nMod: " + achievement.mod.DisplayName;
                /*ChatManager.DrawColorCodedStringWithShadow(spriteBatch, Main.fontMouseText,
                    "State: " + stringState + "\nMod: " + achievement.mod.DisplayName,
                    new Vector2(Main.mouseX + 20, Main.mouseY + 20), Color.White, 0f, Vector2.Zero, Vector2.One);*/
            }
        }

        public string SpliceText(string text)
        {
            return Regex.Replace(text, "(.{" + 50 + "})" + ' ', "$1" + Environment.NewLine);
        }

    }
}
