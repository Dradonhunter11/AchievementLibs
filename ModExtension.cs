using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace AchievementLibs
{
    internal static class ModExtension
    {
        public static Vector2 GetVector(this CalculatedStyle self)
        {
            return new Vector2(self.X, self.Y);
        } 

        public static List<UIElement> GetElements(this UIElement self)
        {
            FieldInfo elementFieldInfo =
                typeof(UIElement).GetField("Elements", BindingFlags.NonPublic | BindingFlags.Instance);
            return (List<UIElement>)elementFieldInfo.GetValue(self);
        }

        public static List<UIElement> GetElements(this UIPanel self)
        {
            FieldInfo elementFieldInfo =
                typeof(UIElement).GetField("Elements", BindingFlags.NonPublic | BindingFlags.Instance);
            return (List<UIElement>)elementFieldInfo.GetValue(self);
        }

    }
}
