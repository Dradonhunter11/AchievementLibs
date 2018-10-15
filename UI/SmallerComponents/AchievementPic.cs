using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AchievementLibs.API;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace AchievementLibs.UI.SmallerComponents
{
    class AchievementPic : UIElement
    {
        private Texture2D picture;

        private Texture2D bound;

        

        

        public override void OnInitialize()
        {
            Width.Set(64, 0f);
            Height.Set(64, 0f);

            
        }

        public void setTexture(Texture2D picture)
        {
            this.picture = picture;
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            if (picture == null)
            {
                picture = ModLoader.GetMod("AchievementLibs").GetTexture("Texture/Default");
            }
            CalculatedStyle innerDim = base.GetInnerDimensions();
            Vector2 picturePos = new Vector2(innerDim.X + 64, innerDim.Y + 64);
            Rectangle r = picture.Bounds;


            spriteBatch.Draw(picture, picturePos, r, Color.White, 0f, r.Size(), 1f, SpriteEffects.None, 0f);
        }
    }
}
