using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.GameInput;
using Terraria.Localization;
using Terraria.Social;
using Terraria.UI;
using Terraria.UI.Gamepad;

namespace AchievementLibs.UI.Setting
{
    class NewInGameSetting : UIState
    {
        public override void Draw(SpriteBatch sb)
        {
            Main mainInstance = Main.instance;

            FieldInfo _GUIHoverInfo =
                typeof(IngameOptions).GetField("_GUIHover", BindingFlags.Static | BindingFlags.NonPublic);


            if (Main.player[Main.myPlayer].dead && !Main.player[Main.myPlayer].ghost)
            {
                Main.setKey = -1;
                IngameOptions.Close();
                Main.playerInventory = false;
                return;
            }
            for (int i = 0; i < IngameOptions.skipRightSlot.Length; i++)
            {
                IngameOptions.skipRightSlot[i] = false;
            }
            bool flag = GameCulture.Russian.IsActive || GameCulture.Portuguese.IsActive || GameCulture.Polish.IsActive || GameCulture.French.IsActive;
            bool isActive = GameCulture.Polish.IsActive;
            bool isActive2 = GameCulture.German.IsActive;
            bool flag2 = GameCulture.Italian.IsActive || GameCulture.Spanish.IsActive;
            bool flag3 = false;
            int num = 70;
            float scale = 0.75f;
            float num2 = 60f;
            float maxWidth = 300f;
            if (flag)
            {
                flag3 = true;
            }
            if (isActive)
            {
                maxWidth = 200f;
            }
            new Vector2((float)Main.mouseX, (float)Main.mouseY);
            bool flag4 = Main.mouseLeft && Main.mouseLeftRelease;
            Vector2 value = new Vector2((float)Main.screenWidth, (float)Main.screenHeight);
            Vector2 value2 = new Vector2(670f, 600f);
            Vector2 value3 = value / 2f - value2 / 2f;
            int num3 = 20;
            _GUIHoverInfo.SetValue(null, new Rectangle((int)(value3.X - (float)num3), (int)(value3.Y - (float)num3), (int)(value2.X + (float)(num3 * 2)), (int)(value2.Y + (float)(num3 * 2))));
            Utils.DrawInvBG(sb, value3.X - (float)num3, value3.Y - (float)num3, value2.X + (float)(num3 * 2), value2.Y + (float)(num3 * 2), new Color(33, 15, 91, 255) * 0.685f);
            if (new Rectangle((int)value3.X - num3, (int)value3.Y - num3, (int)value2.X + num3 * 2, (int)value2.Y + num3 * 2).Contains(new Point(Main.mouseX, Main.mouseY)))
            {
                Main.player[Main.myPlayer].mouseInterface = true;
            }
            Utils.DrawBorderString(sb, Language.GetTextValue("GameUI.SettingsMenu"), value3 + value2 * new Vector2(0.5f, 0f), Color.White, 1f, 0.5f, 0f, -1);
            if (flag)
            {
                Utils.DrawInvBG(sb, value3.X + (float)(num3 / 2), value3.Y + (float)(num3 * 5 / 2), value2.X / 3f - (float)num3, value2.Y - (float)(num3 * 3), default(Color));
                Utils.DrawInvBG(sb, value3.X + value2.X / 3f + (float)num3, value3.Y + (float)(num3 * 5 / 2), value2.X * 2f / 3f - (float)(num3 * 3 / 2), value2.Y - (float)(num3 * 3), default(Color));
            }
            else
            {
                Utils.DrawInvBG(sb, value3.X + (float)(num3 / 2), value3.Y + (float)(num3 * 5 / 2), value2.X / 2f - (float)num3, value2.Y - (float)(num3 * 3), default(Color));
                Utils.DrawInvBG(sb, value3.X + value2.X / 2f + (float)num3, value3.Y + (float)(num3 * 5 / 2), value2.X / 2f - (float)(num3 * 3 / 2), value2.Y - (float)(num3 * 3), default(Color));
            }
            float num4 = 0.7f;
            float num5 = 0.8f;
            float num6 = 0.01f;
            if (flag)
            {
                num4 = 0.4f;
                num5 = 0.44f;
            }
            if (isActive2)
            {
                num4 = 0.55f;
                num5 = 0.6f;
            }
            if (IngameOptions.oldLeftHover != IngameOptions.leftHover && IngameOptions.leftHover != -1)
            {
                Main.PlaySound(12, -1, -1, 1, 1f, 0f);
            }
            if (IngameOptions.oldRightHover != IngameOptions.rightHover && IngameOptions.rightHover != -1)
            {
                Main.PlaySound(12, -1, -1, 1, 1f, 0f);
            }
            if (flag4 && IngameOptions.rightHover != -1 && !IngameOptions.noSound)
            {
                Main.PlaySound(12, -1, -1, 1, 1f, 0f);
            }
            IngameOptions.oldLeftHover = IngameOptions.leftHover;
            IngameOptions.oldRightHover = IngameOptions.rightHover;
            IngameOptions.noSound = false;
            bool flag5 = SocialAPI.Network != null && SocialAPI.Network.CanInvite();
            int num7 = flag5 ? 1 : 0;
            int num8 = 5 + num7 + 3; //Increase the number for more menu option
            Vector2 vector = new Vector2(value3.X + value2.X / 4f, value3.Y + (float)(num3 * 5 / 2));
            Vector2 vector2 = new Vector2(0f, value2.Y - (float)(num3 * 5)) / (float)(num8 + 1);
            if (flag)
            {
                vector.X -= 55f;
            }
            UILinkPointNavigator.Shortcuts.INGAMEOPTIONS_BUTTONS_LEFT = num8 + 1;
            for (int j = 0; j <= num8; j++)
            {
                if (IngameOptions.leftHover == j || j == IngameOptions.category)
                {
                    IngameOptions.leftScale[j] += num6;
                }
                else
                {
                    IngameOptions.leftScale[j] -= num6;
                }
                if (IngameOptions.leftScale[j] < num4)
                {
                    IngameOptions.leftScale[j] = num4;
                }
                if (IngameOptions.leftScale[j] > num5)
                {
                    IngameOptions.leftScale[j] = num5;
                }
            }
            IngameOptions.leftHover = -1;
            int num9 = IngameOptions.category;
            int num10 = 0;
            if (IngameOptions.DrawLeftSide(sb, Lang.menu[114].Value, num10, vector, vector2, IngameOptions.leftScale, 0.7f, 0.8f, 0.01f))
            {
                IngameOptions.leftHover = num10;
                if (flag4)
                {
                    IngameOptions.category = 0;
                    Main.PlaySound(10, -1, -1, 1, 1f, 0f);
                }
            }
            num10++;
            if (IngameOptions.DrawLeftSide(sb, Lang.menu[210].Value, num10, vector, vector2, IngameOptions.leftScale, 0.7f, 0.8f, 0.01f))
            {
                IngameOptions.leftHover = num10;
                if (flag4)
                {
                    IngameOptions.category = 1;
                    Main.PlaySound(10, -1, -1, 1, 1f, 0f);
                }
            }
            num10++;
            if (IngameOptions.DrawLeftSide(sb, Lang.menu[63].Value, num10, vector, vector2, IngameOptions.leftScale, 0.7f, 0.8f, 0.01f))
            {
                IngameOptions.leftHover = num10;
                if (flag4)
                {
                    IngameOptions.category = 2;
                    Main.PlaySound(10, -1, -1, 1, 1f, 0f);
                }
            }
            num10++;
            if (IngameOptions.DrawLeftSide(sb, Lang.menu[218].Value, num10, vector, vector2, IngameOptions.leftScale, 0.7f, 0.8f, 0.01f))
            {
                IngameOptions.leftHover = num10;
                if (flag4)
                {
                    IngameOptions.category = 3;
                    Main.PlaySound(10, -1, -1, 1, 1f, 0f);
                }
            }
            num10++;
            if (IngameOptions.DrawLeftSide(sb, Lang.menu[66].Value, num10, vector, vector2, IngameOptions.leftScale, 0.7f, 0.8f, 0.01f))
            {
                IngameOptions.leftHover = num10;
                if (flag4)
                {
                    IngameOptions.Close();
                    IngameFancyUI.OpenKeybinds();
                }
            }
            num10++;
            if (flag5 && IngameOptions.DrawLeftSide(sb, Lang.menu[147].Value, num10, vector, vector2, IngameOptions.leftScale, 0.7f, 0.8f, 0.01f))
            {
                IngameOptions.leftHover = num10;
                if (flag4)
                {
                    IngameOptions.Close();
                    SocialAPI.Network.OpenInviteInterface();
                }
            }
            if (flag5)
            {
                num10++;
            }
            if (IngameOptions.DrawLeftSide(sb, Lang.menu[131].Value, num10, vector, vector2, IngameOptions.leftScale, 0.7f, 0.8f, 0.01f))
            {
                IngameOptions.leftHover = num10;
                if (flag4)
                {
                    IngameOptions.Close();
                    IngameFancyUI.OpenAchievements();
                }
            }

            //Modded Achievements section
            num10++;
            if (IngameOptions.DrawLeftSide(sb, "Modded Achievements", num10, vector, vector2, IngameOptions.leftScale, 0.7f, 0.8f, 0.01f))
            {
                IngameOptions.leftHover = num10;
                if (flag4)
                {
                    IngameOptions.Close();
                    AchievementUI.visible = !AchievementUI.visible;
                }
            }
            num10++;
            if (IngameOptions.DrawLeftSide(sb, Lang.menu[118].Value, num10, vector, vector2, IngameOptions.leftScale, 0.7f, 0.8f, 0.01f))
            {
                IngameOptions.leftHover = num10;

                if (flag4)
                {
                    IngameOptions.Close();
                }
            }
            num10++;
            if (IngameOptions.DrawLeftSide(sb, Lang.inter[35].Value, num10, vector, vector2, IngameOptions.leftScale, 0.7f, 0.8f, 0.01f))
            {
                IngameOptions.leftHover = num10;
                if (flag4)
                {
                    IngameOptions.Close();
                    Main.menuMode = 10;
                    WorldGen.SaveAndQuit(null);
                }
            }
            num10++;
            if (num9 != IngameOptions.category)
            {
                for (int k = 0; k < IngameOptions.rightScale.Length; k++)
                {
                    IngameOptions.rightScale[k] = 0f;
                }
            }
            int num11 = 0;
            switch (IngameOptions.category)
            {
                case 0:
                    num11 = 15;
                    num4 = 1f;
                    num5 = 1.001f;
                    num6 = 0.001f;
                    break;
                case 1:
                    num11 = 6;
                    num4 = 1f;
                    num5 = 1.001f;
                    num6 = 0.001f;
                    break;
                case 2:
                    num11 = 12;
                    num4 = 1f;
                    num5 = 1.001f;
                    num6 = 0.001f;
                    break;
                case 3:
                    num11 = 15;
                    num4 = 1f;
                    num5 = 1.001f;
                    num6 = 0.001f;
                    break;
            }
            if (flag)
            {
                num4 -= 0.1f;
                num5 -= 0.1f;
            }
            if (isActive2 && IngameOptions.category == 3)
            {
                num4 -= 0.15f;
                num5 -= 0.15f;
            }
            if (flag2 && (IngameOptions.category == 0 || IngameOptions.category == 3))
            {
                num4 -= 0.2f;
                num5 -= 0.2f;
            }
            UILinkPointNavigator.Shortcuts.INGAMEOPTIONS_BUTTONS_RIGHT = num11;
            Vector2 vector3 = new Vector2(value3.X + value2.X * 3f / 4f, value3.Y + (float)(num3 * 5 / 2));
            if (flag)
            {
                vector3.X = value3.X + value2.X * 2f / 3f;
            }
            Vector2 vector4 = new Vector2(0f, value2.Y - (float)(num3 * 3)) / (float)(num11 + 1);
            if (IngameOptions.category == 2)
            {
                vector4.Y -= 2f;
            }
            for (int l = 0; l < 15; l++)
            {
                if (IngameOptions.rightLock == l || (IngameOptions.rightHover == l && IngameOptions.rightLock == -1))
                {
                    IngameOptions.rightScale[l] += num6;
                }
                else
                {
                    IngameOptions.rightScale[l] -= num6;
                }
                if (IngameOptions.rightScale[l] < num4)
                {
                    IngameOptions.rightScale[l] = num4;
                }
                if (IngameOptions.rightScale[l] > num5)
                {
                    IngameOptions.rightScale[l] = num5;
                }
            }
            IngameOptions.inBar = false;
            IngameOptions.rightHover = -1;
            if (!Main.mouseLeft)
            {
                IngameOptions.rightLock = -1;
            }
            if (IngameOptions.rightLock == -1)
            {
                IngameOptions.notBar = false;
            }
            if (IngameOptions.category == 0)
            {
                int num12 = 0;
                IngameOptions.DrawRightSide(sb, Lang.menu[65].Value, num12, vector3, vector4, IngameOptions.rightScale[num12], 1f, default(Color));
                IngameOptions.skipRightSlot[num12] = true;
                num12++;
                vector3.X -= (float)num;
                if (IngameOptions.DrawRightSide(sb, string.Concat(new object[]
                        {
                            Lang.menu[99].Value,
                            " ",
                            Math.Round((double)(Main.musicVolume * 100f)),
                            "%"
                        }), num12, vector3, vector4, IngameOptions.rightScale[num12], (IngameOptions.rightScale[num12] - num4) / (num5 - num4), default(Color)))
                {
                    if (IngameOptions.rightLock == -1)
                    {
                        IngameOptions.notBar = true;
                    }
                    IngameOptions.noSound = true;
                    IngameOptions.rightHover = num12;
                }
                IngameOptions.valuePosition.X = value3.X + value2.X - (float)(num3 / 2) - 20f;
                IngameOptions.valuePosition.Y = IngameOptions.valuePosition.Y - 3f;
                float musicVolume = IngameOptions.DrawValueBar(sb, scale, Main.musicVolume, 0, null);
                if ((IngameOptions.inBar || IngameOptions.rightLock == num12) && !IngameOptions.notBar)
                {
                    IngameOptions.rightHover = num12;
                    if (Main.mouseLeft && IngameOptions.rightLock == num12)
                    {
                        Main.musicVolume = musicVolume;
                    }
                }
                if ((float)Main.mouseX > value3.X + value2.X * 2f / 3f + (float)num3 && (float)Main.mouseX < IngameOptions.valuePosition.X + 3.75f && (float)Main.mouseY > IngameOptions.valuePosition.Y - 10f && (float)Main.mouseY <= IngameOptions.valuePosition.Y + 10f)
                {
                    if (IngameOptions.rightLock == -1)
                    {
                        IngameOptions.notBar = true;
                    }
                    IngameOptions.rightHover = num12;
                }
                if (IngameOptions.rightHover == num12)
                {
                    UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 2;
                }
                num12++;
                if (IngameOptions.DrawRightSide(sb, string.Concat(new object[]
                        {
                            Lang.menu[98].Value,
                            " ",
                            Math.Round((double)(Main.soundVolume * 100f)),
                            "%"
                        }), num12, vector3, vector4, IngameOptions.rightScale[num12], (IngameOptions.rightScale[num12] - num4) / (num5 - num4), default(Color)))
                {
                    if (IngameOptions.rightLock == -1)
                    {
                        IngameOptions.notBar = true;
                    }
                    IngameOptions.rightHover = num12;
                }
                IngameOptions.valuePosition.X = value3.X + value2.X - (float)(num3 / 2) - 20f;
                IngameOptions.valuePosition.Y = IngameOptions.valuePosition.Y - 3f;
                float soundVolume = IngameOptions.DrawValueBar(sb, scale, Main.soundVolume, 0, null);
                if ((IngameOptions.inBar || IngameOptions.rightLock == num12) && !IngameOptions.notBar)
                {
                    IngameOptions.rightHover = num12;
                    if (Main.mouseLeft && IngameOptions.rightLock == num12)
                    {
                        Main.soundVolume = soundVolume;
                        IngameOptions.noSound = true;
                    }
                }
                if ((float)Main.mouseX > value3.X + value2.X * 2f / 3f + (float)num3 && (float)Main.mouseX < IngameOptions.valuePosition.X + 3.75f && (float)Main.mouseY > IngameOptions.valuePosition.Y - 10f && (float)Main.mouseY <= IngameOptions.valuePosition.Y + 10f)
                {
                    if (IngameOptions.rightLock == -1)
                    {
                        IngameOptions.notBar = true;
                    }
                    IngameOptions.rightHover = num12;
                }
                if (IngameOptions.rightHover == num12)
                {
                    UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 3;
                }
                num12++;
                if (IngameOptions.DrawRightSide(sb, string.Concat(new object[]
                        {
                            Lang.menu[119].Value,
                            " ",
                            Math.Round((double)(Main.ambientVolume * 100f)),
                            "%"
                        }), num12, vector3, vector4, IngameOptions.rightScale[num12], (IngameOptions.rightScale[num12] - num4) / (num5 - num4), default(Color)))
                {
                    if (IngameOptions.rightLock == -1)
                    {
                        IngameOptions.notBar = true;
                    }
                    IngameOptions.rightHover = num12;
                }
                IngameOptions.valuePosition.X = value3.X + value2.X - (float)(num3 / 2) - 20f;
                IngameOptions.valuePosition.Y = IngameOptions.valuePosition.Y - 3f;
                float ambientVolume = IngameOptions.DrawValueBar(sb, scale, Main.ambientVolume, 0, null);
                if ((IngameOptions.inBar || IngameOptions.rightLock == num12) && !IngameOptions.notBar)
                {
                    IngameOptions.rightHover = num12;
                    if (Main.mouseLeft && IngameOptions.rightLock == num12)
                    {
                        Main.ambientVolume = ambientVolume;
                        IngameOptions.noSound = true;
                    }
                }
                if ((float)Main.mouseX > value3.X + value2.X * 2f / 3f + (float)num3 && (float)Main.mouseX < IngameOptions.valuePosition.X + 3.75f && (float)Main.mouseY > IngameOptions.valuePosition.Y - 10f && (float)Main.mouseY <= IngameOptions.valuePosition.Y + 10f)
                {
                    if (IngameOptions.rightLock == -1)
                    {
                        IngameOptions.notBar = true;
                    }
                    IngameOptions.rightHover = num12;
                }
                if (IngameOptions.rightHover == num12)
                {
                    UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 4;
                }
                num12++;
                vector3.X += (float)num;
                IngameOptions.DrawRightSide(sb, "", num12, vector3, vector4, IngameOptions.rightScale[num12], 1f, default(Color));
                IngameOptions.skipRightSlot[num12] = true;
                num12++;
                IngameOptions.DrawRightSide(sb, Language.GetTextValue("GameUI.ZoomCategory"), num12, vector3, vector4, IngameOptions.rightScale[num12], 1f, default(Color));
                IngameOptions.skipRightSlot[num12] = true;
                num12++;
                vector3.X -= (float)num;
                string text = Language.GetTextValue("GameUI.GameZoom", Math.Round((double)(Main.GameZoomTarget * 100f)), Math.Round((double)(Main.GameViewMatrix.Zoom.X * 100f)));
                if (flag3)
                {
                    text = Main.fontItemStack.CreateWrappedText(text, maxWidth, Language.ActiveCulture.CultureInfo);
                }
                if (IngameOptions.DrawRightSide(sb, text, num12, vector3, vector4, IngameOptions.rightScale[num12] * 0.85f, (IngameOptions.rightScale[num12] - num4) / (num5 - num4), default(Color)))
                {
                    if (IngameOptions.rightLock == -1)
                    {
                        IngameOptions.notBar = true;
                    }
                    IngameOptions.rightHover = num12;
                }
                IngameOptions.valuePosition.X = value3.X + value2.X - (float)(num3 / 2) - 20f;
                IngameOptions.valuePosition.Y = IngameOptions.valuePosition.Y - 3f;
                float num13 = IngameOptions.DrawValueBar(sb, scale, Main.GameZoomTarget - 1f, 0, null);
                if ((IngameOptions.inBar || IngameOptions.rightLock == num12) && !IngameOptions.notBar)
                {
                    IngameOptions.rightHover = num12;
                    if (Main.mouseLeft && IngameOptions.rightLock == num12)
                    {
                        Main.GameZoomTarget = num13 + 1f;
                    }
                }
                if ((float)Main.mouseX > value3.X + value2.X * 2f / 3f + (float)num3 && (float)Main.mouseX < IngameOptions.valuePosition.X + 3.75f && (float)Main.mouseY > IngameOptions.valuePosition.Y - 10f && (float)Main.mouseY <= IngameOptions.valuePosition.Y + 10f)
                {
                    if (IngameOptions.rightLock == -1)
                    {
                        IngameOptions.notBar = true;
                    }
                    IngameOptions.rightHover = num12;
                }
                if (IngameOptions.rightHover == num12)
                {
                    UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 10;
                }
                num12++;
                bool flag6 = false;
                if (Main.temporaryGUIScaleSlider == -1f)
                {
                    Main.temporaryGUIScaleSlider = Main.UIScaleWanted;
                }
                string text2 = Language.GetTextValue("GameUI.UIScale", Math.Round((double)(Main.temporaryGUIScaleSlider * 100f)), Math.Round((double)(Main.UIScale * 100f)));
                if (flag3)
                {
                    text2 = Main.fontItemStack.CreateWrappedText(text2, maxWidth, Language.ActiveCulture.CultureInfo);
                }
                if (IngameOptions.DrawRightSide(sb, text2, num12, vector3, vector4, IngameOptions.rightScale[num12] * 0.75f, (IngameOptions.rightScale[num12] - num4) / (num5 - num4), default(Color)))
                {
                    if (IngameOptions.rightLock == -1)
                    {
                        IngameOptions.notBar = true;
                    }
                    IngameOptions.rightHover = num12;
                }
                IngameOptions.valuePosition.X = value3.X + value2.X - (float)(num3 / 2) - 20f;
                IngameOptions.valuePosition.Y = IngameOptions.valuePosition.Y - 3f;
                float num14 = IngameOptions.DrawValueBar(sb, scale, Main.temporaryGUIScaleSlider - 1f, 0, null);
                if ((IngameOptions.inBar || IngameOptions.rightLock == num12) && !IngameOptions.notBar)
                {
                    IngameOptions.rightHover = num12;
                    if (Main.mouseLeft && IngameOptions.rightLock == num12)
                    {
                        Main.temporaryGUIScaleSlider = num14 + 1f;
                        Main.temporaryGUIScaleSliderUpdate = true;
                        flag6 = true;
                    }
                }
                if (!flag6 && Main.temporaryGUIScaleSliderUpdate && Main.temporaryGUIScaleSlider != -1f)
                {
                    Main.UIScale = Main.temporaryGUIScaleSlider;
                    Main.temporaryGUIScaleSliderUpdate = false;
                }
                if ((float)Main.mouseX > value3.X + value2.X * 2f / 3f + (float)num3 && (float)Main.mouseX < IngameOptions.valuePosition.X + 3.75f && (float)Main.mouseY > IngameOptions.valuePosition.Y - 10f && (float)Main.mouseY <= IngameOptions.valuePosition.Y + 10f)
                {
                    if (IngameOptions.rightLock == -1)
                    {
                        IngameOptions.notBar = true;
                    }
                    IngameOptions.rightHover = num12;
                }
                if (IngameOptions.rightHover == num12)
                {
                    UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 11;
                }
                num12++;
                vector3.X += (float)num;
                IngameOptions.DrawRightSide(sb, "", num12, vector3, vector4, IngameOptions.rightScale[num12], 1f, default(Color));
                IngameOptions.skipRightSlot[num12] = true;
                num12++;
                IngameOptions.DrawRightSide(sb, Language.GetTextValue("GameUI.Gameplay"), num12, vector3, vector4, IngameOptions.rightScale[num12], 1f, default(Color));
                IngameOptions.skipRightSlot[num12] = true;
                num12++;
                if (IngameOptions.DrawRightSide(sb, Main.autoSave ? Lang.menu[67].Value : Lang.menu[68].Value, num12, vector3, vector4, IngameOptions.rightScale[num12], (IngameOptions.rightScale[num12] - num4) / (num5 - num4), default(Color)))
                {
                    IngameOptions.rightHover = num12;
                    if (flag4)
                    {
                        Main.autoSave = !Main.autoSave;
                    }
                }
                num12++;
                if (IngameOptions.DrawRightSide(sb, Main.autoPause ? Lang.menu[69].Value : Lang.menu[70].Value, num12, vector3, vector4, IngameOptions.rightScale[num12], (IngameOptions.rightScale[num12] - num4) / (num5 - num4), default(Color)))
                {
                    IngameOptions.rightHover = num12;
                    if (flag4)
                    {
                        Main.autoPause = !Main.autoPause;
                    }
                }
                num12++;
                if (IngameOptions.DrawRightSide(sb, Player.SmartCursorSettings.SmartWallReplacement ? Lang.menu[226].Value : Lang.menu[225].Value, num12, vector3, vector4, IngameOptions.rightScale[num12], (IngameOptions.rightScale[num12] - num4) / (num5 - num4), default(Color)))
                {
                    IngameOptions.rightHover = num12;
                    if (flag4)
                    {
                        Player.SmartCursorSettings.SmartWallReplacement = !Player.SmartCursorSettings.SmartWallReplacement;
                    }
                }
                num12++;
                if (IngameOptions.DrawRightSide(sb, Main.ReversedUpDownArmorSetBonuses ? Lang.menu[220].Value : Lang.menu[221].Value, num12, vector3, vector4, IngameOptions.rightScale[num12], (IngameOptions.rightScale[num12] - num4) / (num5 - num4), default(Color)))
                {
                    IngameOptions.rightHover = num12;
                    if (flag4)
                    {
                        Main.ReversedUpDownArmorSetBonuses = !Main.ReversedUpDownArmorSetBonuses;
                    }
                }
                num12++;
                IngameOptions.DrawRightSide(sb, "", num12, vector3, vector4, IngameOptions.rightScale[num12], 1f, default(Color));
                IngameOptions.skipRightSlot[num12] = true;
                num12++;
            }
            if (IngameOptions.category == 1)
            {
                int num15 = 0;
                if (IngameOptions.DrawRightSide(sb, Main.showItemText ? Lang.menu[71].Value : Lang.menu[72].Value, num15, vector3, vector4, IngameOptions.rightScale[num15], (IngameOptions.rightScale[num15] - num4) / (num5 - num4), default(Color)))
                {
                    IngameOptions.rightHover = num15;
                    if (flag4)
                    {
                        Main.showItemText = !Main.showItemText;
                    }
                }
                num15++;
                if (IngameOptions.DrawRightSide(sb, Lang.menu[123].Value + " " + Lang.menu[124 + Main.invasionProgressMode], num15, vector3, vector4, IngameOptions.rightScale[num15], (IngameOptions.rightScale[num15] - num4) / (num5 - num4), default(Color)))
                {
                    IngameOptions.rightHover = num15;
                    if (flag4)
                    {
                        Main.invasionProgressMode++;
                        if (Main.invasionProgressMode >= 3)
                        {
                            Main.invasionProgressMode = 0;
                        }
                    }
                }
                num15++;
                if (IngameOptions.DrawRightSide(sb, Main.placementPreview ? Lang.menu[128].Value : Lang.menu[129].Value, num15, vector3, vector4, IngameOptions.rightScale[num15], (IngameOptions.rightScale[num15] - num4) / (num5 - num4), default(Color)))
                {
                    IngameOptions.rightHover = num15;
                    if (flag4)
                    {
                        Main.placementPreview = !Main.placementPreview;
                    }
                }
                num15++;
                if (IngameOptions.DrawRightSide(sb, ItemSlot.Options.HighlightNewItems ? Lang.inter[117].Value : Lang.inter[116].Value, num15, vector3, vector4, IngameOptions.rightScale[num15], (IngameOptions.rightScale[num15] - num4) / (num5 - num4), default(Color)))
                {
                    IngameOptions.rightHover = num15;
                    if (flag4)
                    {
                        ItemSlot.Options.HighlightNewItems = !ItemSlot.Options.HighlightNewItems;
                    }
                }
                num15++;
                if (IngameOptions.DrawRightSide(sb, Main.MouseShowBuildingGrid ? Lang.menu[229].Value : Lang.menu[230].Value, num15, vector3, vector4, IngameOptions.rightScale[num15], (IngameOptions.rightScale[num15] - num4) / (num5 - num4), default(Color)))
                {
                    IngameOptions.rightHover = num15;
                    if (flag4)
                    {
                        Main.MouseShowBuildingGrid = !Main.MouseShowBuildingGrid;
                    }
                }
                num15++;
                if (IngameOptions.DrawRightSide(sb, Main.GamepadDisableInstructionsDisplay ? Lang.menu[241].Value : Lang.menu[242].Value, num15, vector3, vector4, IngameOptions.rightScale[num15], (IngameOptions.rightScale[num15] - num4) / (num5 - num4), default(Color)))
                {
                    IngameOptions.rightHover = num15;
                    if (flag4)
                    {
                        Main.GamepadDisableInstructionsDisplay = !Main.GamepadDisableInstructionsDisplay;
                    }
                }
                num15++;
            }
            if (IngameOptions.category == 2)
            {
                int num16 = 0;
                if (IngameOptions.DrawRightSide(sb, Main.graphics.IsFullScreen ? Lang.menu[49].Value : Lang.menu[50].Value, num16, vector3, vector4, IngameOptions.rightScale[num16], (IngameOptions.rightScale[num16] - num4) / (num5 - num4), default(Color)))
                {
                    IngameOptions.rightHover = num16;
                    if (flag4)
                    {
                        Main.ToggleFullScreen();
                    }
                }
                num16++;
                if (IngameOptions.DrawRightSide(sb, string.Concat(new object[]
                        {
                            Lang.menu[51].Value,
                            ": ",
                            Main.PendingResolutionWidth,
                            "x",
                            Main.PendingResolutionHeight
                        }), num16, vector3, vector4, IngameOptions.rightScale[num16], (IngameOptions.rightScale[num16] - num4) / (num5 - num4), default(Color)))
                {
                    IngameOptions.rightHover = num16;
                    if (flag4)
                    {
                        int num17 = 0;
                        for (int m = 0; m < Main.numDisplayModes; m++)
                        {
                            if (Main.displayWidth[m] == Main.PendingResolutionWidth && Main.displayHeight[m] == Main.PendingResolutionHeight)
                            {
                                num17 = m;
                                break;
                            }
                        }
                        num17++;
                        if (num17 >= Main.numDisplayModes)
                        {
                            num17 = 0;
                        }
                        Main.PendingResolutionWidth = Main.displayWidth[num17];
                        Main.PendingResolutionHeight = Main.displayHeight[num17];
                    }
                }
                num16++;
                vector3.X -= (float)num;
                if (IngameOptions.DrawRightSide(sb, string.Concat(new object[]
                        {
                            Lang.menu[52].Value,
                            ": ",
                            Main.bgScroll,
                            "%"
                        }), num16, vector3, vector4, IngameOptions.rightScale[num16], (IngameOptions.rightScale[num16] - num4) / (num5 - num4), default(Color)))
                {
                    if (IngameOptions.rightLock == -1)
                    {
                        IngameOptions.notBar = true;
                    }
                    IngameOptions.noSound = true;
                    IngameOptions.rightHover = num16;
                }
                IngameOptions.valuePosition.X = value3.X + value2.X - (float)(num3 / 2) - 20f;
                IngameOptions.valuePosition.Y = IngameOptions.valuePosition.Y - 3f;
                float num18 = IngameOptions.DrawValueBar(sb, scale, (float)Main.bgScroll / 100f, 0, null);
                if ((IngameOptions.inBar || IngameOptions.rightLock == num16) && !IngameOptions.notBar)
                {
                    IngameOptions.rightHover = num16;
                    if (Main.mouseLeft && IngameOptions.rightLock == num16)
                    {
                        Main.bgScroll = (int)(num18 * 100f);
                        Main.caveParallax = 1f - (float)Main.bgScroll / 500f;
                    }
                }
                if ((float)Main.mouseX > value3.X + value2.X * 2f / 3f + (float)num3 && (float)Main.mouseX < IngameOptions.valuePosition.X + 3.75f && (float)Main.mouseY > IngameOptions.valuePosition.Y - 10f && (float)Main.mouseY <= IngameOptions.valuePosition.Y + 10f)
                {
                    if (IngameOptions.rightLock == -1)
                    {
                        IngameOptions.notBar = true;
                    }
                    IngameOptions.rightHover = num16;
                }
                if (IngameOptions.rightHover == num16)
                {
                    UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 1;
                }
                num16++;
                vector3.X += (float)num;
                if (IngameOptions.DrawRightSide(sb, Lang.menu[247 + Main.FrameSkipMode].Value, num16, vector3, vector4, IngameOptions.rightScale[num16], (IngameOptions.rightScale[num16] - num4) / (num5 - num4), default(Color)))
                {
                    IngameOptions.rightHover = num16;
                    if (flag4)
                    {
                        Main.FrameSkipMode++;
                        if (Main.FrameSkipMode < 0 || Main.FrameSkipMode > 2)
                        {
                            Main.FrameSkipMode = 0;
                        }
                    }
                }
                num16++;
                if (IngameOptions.DrawRightSide(sb, Lang.menu[55 + Lighting.lightMode].Value, num16, vector3, vector4, IngameOptions.rightScale[num16], (IngameOptions.rightScale[num16] - num4) / (num5 - num4), default(Color)))
                {
                    IngameOptions.rightHover = num16;
                    if (flag4)
                    {
                        Lighting.NextLightMode();
                    }
                }
                num16++;
                if (IngameOptions.DrawRightSide(sb, Lang.menu[116].Value + " " + ((Lighting.LightingThreads > 0) ? string.Concat(Lighting.LightingThreads + 1) : Lang.menu[117].Value), num16, vector3, vector4, IngameOptions.rightScale[num16], (IngameOptions.rightScale[num16] - num4) / (num5 - num4), default(Color)))
                {
                    IngameOptions.rightHover = num16;
                    if (flag4)
                    {
                        Lighting.LightingThreads++;
                        if (Lighting.LightingThreads > Environment.ProcessorCount - 1)
                        {
                            Lighting.LightingThreads = 0;
                        }
                    }
                }
                num16++;
                if (IngameOptions.DrawRightSide(sb, Lang.menu[59 + Main.qaStyle].Value, num16, vector3, vector4, IngameOptions.rightScale[num16], (IngameOptions.rightScale[num16] - num4) / (num5 - num4), default(Color)))
                {
                    IngameOptions.rightHover = num16;
                    if (flag4)
                    {
                        Main.qaStyle++;
                        if (Main.qaStyle > 3)
                        {
                            Main.qaStyle = 0;
                        }
                    }
                }
                num16++;
                if (IngameOptions.DrawRightSide(sb, Main.BackgroundEnabled ? Lang.menu[100].Value : Lang.menu[101].Value, num16, vector3, vector4, IngameOptions.rightScale[num16], (IngameOptions.rightScale[num16] - num4) / (num5 - num4), default(Color)))
                {
                    IngameOptions.rightHover = num16;
                    if (flag4)
                    {
                        Main.BackgroundEnabled = !Main.BackgroundEnabled;
                    }
                }
                num16++;
                if (IngameOptions.DrawRightSide(sb, ChildSafety.Disabled ? Lang.menu[132].Value : Lang.menu[133].Value, num16, vector3, vector4, IngameOptions.rightScale[num16], (IngameOptions.rightScale[num16] - num4) / (num5 - num4), default(Color)))
                {
                    IngameOptions.rightHover = num16;
                    if (flag4)
                    {
                        ChildSafety.Disabled = !ChildSafety.Disabled;
                    }
                }
                num16++;
                if (IngameOptions.DrawRightSide(sb, Language.GetTextValue("GameUI.HeatDistortion", Main.UseHeatDistortion ? Language.GetTextValue("GameUI.Enabled") : Language.GetTextValue("GameUI.Disabled")), num16, vector3, vector4, IngameOptions.rightScale[num16], (IngameOptions.rightScale[num16] - num4) / (num5 - num4), default(Color)))
                {
                    IngameOptions.rightHover = num16;
                    if (flag4)
                    {
                        Main.UseHeatDistortion = !Main.UseHeatDistortion;
                    }
                }
                num16++;
                if (IngameOptions.DrawRightSide(sb, Language.GetTextValue("GameUI.StormEffects", Main.UseStormEffects ? Language.GetTextValue("GameUI.Enabled") : Language.GetTextValue("GameUI.Disabled")), num16, vector3, vector4, IngameOptions.rightScale[num16], (IngameOptions.rightScale[num16] - num4) / (num5 - num4), default(Color)))
                {
                    IngameOptions.rightHover = num16;
                    if (flag4)
                    {
                        Main.UseStormEffects = !Main.UseStormEffects;
                    }
                }
                num16++;
                string textValue;
                switch (Main.WaveQuality)
                {
                    case 1:
                        textValue = Language.GetTextValue("GameUI.QualityLow");
                        break;
                    case 2:
                        textValue = Language.GetTextValue("GameUI.QualityMedium");
                        break;
                    case 3:
                        textValue = Language.GetTextValue("GameUI.QualityHigh");
                        break;
                    default:
                        textValue = Language.GetTextValue("GameUI.QualityOff");
                        break;
                }
                if (IngameOptions.DrawRightSide(sb, Language.GetTextValue("GameUI.WaveQuality", textValue), num16, vector3, vector4, IngameOptions.rightScale[num16], (IngameOptions.rightScale[num16] - num4) / (num5 - num4), default(Color)))
                {
                    IngameOptions.rightHover = num16;
                    if (flag4)
                    {
                        Main.WaveQuality = (Main.WaveQuality + 1) % 4;
                    }
                }
                num16++;
            }
            if (IngameOptions.category == 3)
            {
                int num19 = 0;
                float num20 = (float)num;
                if (flag)
                {
                    num2 = 126f;
                }
                Vector3 hSLVector = Main.mouseColorSlider.GetHSLVector();
                Main.mouseColorSlider.ApplyToMainLegacyBars();
                IngameOptions.DrawRightSide(sb, Lang.menu[64].Value, num19, vector3, vector4, IngameOptions.rightScale[num19], 1f, default(Color));
                IngameOptions.skipRightSlot[num19] = true;
                num19++;
                vector3.X -= num20;
                if (IngameOptions.DrawRightSide(sb, "", num19, vector3, vector4, IngameOptions.rightScale[num19], (IngameOptions.rightScale[num19] - num4) / (num5 - num4), default(Color)))
                {
                    if (IngameOptions.rightLock == -1)
                    {
                        IngameOptions.notBar = true;
                    }
                    IngameOptions.rightHover = num19;
                }
                IngameOptions.valuePosition.X = value3.X + value2.X - (float)(num3 / 2) - 20f;
                IngameOptions.valuePosition.Y = IngameOptions.valuePosition.Y - 3f;
                IngameOptions.valuePosition.X = IngameOptions.valuePosition.X - num2;
                DelegateMethods.v3_1 = hSLVector;
                float num21 = IngameOptions.DrawValueBar(sb, scale, hSLVector.X, 0, new Utils.ColorLerpMethod(DelegateMethods.ColorLerp_HSL_H));
                if ((IngameOptions.inBar || IngameOptions.rightLock == num19) && !IngameOptions.notBar)
                {
                    IngameOptions.rightHover = num19;
                    if (Main.mouseLeft && IngameOptions.rightLock == num19)
                    {
                        hSLVector.X = num21;
                        IngameOptions.noSound = true;
                    }
                }
                if ((float)Main.mouseX > value3.X + value2.X * 2f / 3f + (float)num3 && (float)Main.mouseX < IngameOptions.valuePosition.X + 3.75f && (float)Main.mouseY > IngameOptions.valuePosition.Y - 10f && (float)Main.mouseY <= IngameOptions.valuePosition.Y + 10f)
                {
                    if (IngameOptions.rightLock == -1)
                    {
                        IngameOptions.notBar = true;
                    }
                    IngameOptions.rightHover = num19;
                }
                if (IngameOptions.rightHover == num19)
                {
                    UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 5;
                    Main.menuMode = 25;
                }
                num19++;
                if (IngameOptions.DrawRightSide(sb, "", num19, vector3, vector4, IngameOptions.rightScale[num19], (IngameOptions.rightScale[num19] - num4) / (num5 - num4), default(Color)))
                {
                    if (IngameOptions.rightLock == -1)
                    {
                        IngameOptions.notBar = true;
                    }
                    IngameOptions.rightHover = num19;
                }
                IngameOptions.valuePosition.X = value3.X + value2.X - (float)(num3 / 2) - 20f;
                IngameOptions.valuePosition.Y = IngameOptions.valuePosition.Y - 3f;
                IngameOptions.valuePosition.X = IngameOptions.valuePosition.X - num2;
                DelegateMethods.v3_1 = hSLVector;
                num21 = IngameOptions.DrawValueBar(sb, scale, hSLVector.Y, 0, new Utils.ColorLerpMethod(DelegateMethods.ColorLerp_HSL_S));
                if ((IngameOptions.inBar || IngameOptions.rightLock == num19) && !IngameOptions.notBar)
                {
                    IngameOptions.rightHover = num19;
                    if (Main.mouseLeft && IngameOptions.rightLock == num19)
                    {
                        hSLVector.Y = num21;
                        IngameOptions.noSound = true;
                    }
                }
                if ((float)Main.mouseX > value3.X + value2.X * 2f / 3f + (float)num3 && (float)Main.mouseX < IngameOptions.valuePosition.X + 3.75f && (float)Main.mouseY > IngameOptions.valuePosition.Y - 10f && (float)Main.mouseY <= IngameOptions.valuePosition.Y + 10f)
                {
                    if (IngameOptions.rightLock == -1)
                    {
                        IngameOptions.notBar = true;
                    }
                    IngameOptions.rightHover = num19;
                }
                if (IngameOptions.rightHover == num19)
                {
                    UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 6;
                    Main.menuMode = 25;
                }
                num19++;
                if (IngameOptions.DrawRightSide(sb, "", num19, vector3, vector4, IngameOptions.rightScale[num19], (IngameOptions.rightScale[num19] - num4) / (num5 - num4), default(Color)))
                {
                    if (IngameOptions.rightLock == -1)
                    {
                        IngameOptions.notBar = true;
                    }
                    IngameOptions.rightHover = num19;
                }
                IngameOptions.valuePosition.X = value3.X + value2.X - (float)(num3 / 2) - 20f;
                IngameOptions.valuePosition.Y = IngameOptions.valuePosition.Y - 3f;
                IngameOptions.valuePosition.X = IngameOptions.valuePosition.X - num2;
                DelegateMethods.v3_1 = hSLVector;
                DelegateMethods.v3_1.Z = Utils.InverseLerp(0.15f, 1f, DelegateMethods.v3_1.Z, true);
                num21 = IngameOptions.DrawValueBar(sb, scale, DelegateMethods.v3_1.Z, 0, new Utils.ColorLerpMethod(DelegateMethods.ColorLerp_HSL_L));
                if ((IngameOptions.inBar || IngameOptions.rightLock == num19) && !IngameOptions.notBar)
                {
                    IngameOptions.rightHover = num19;
                    if (Main.mouseLeft && IngameOptions.rightLock == num19)
                    {
                        hSLVector.Z = num21 * 0.85f + 0.15f;
                        IngameOptions.noSound = true;
                    }
                }
                if ((float)Main.mouseX > value3.X + value2.X * 2f / 3f + (float)num3 && (float)Main.mouseX < IngameOptions.valuePosition.X + 3.75f && (float)Main.mouseY > IngameOptions.valuePosition.Y - 10f && (float)Main.mouseY <= IngameOptions.valuePosition.Y + 10f)
                {
                    if (IngameOptions.rightLock == -1)
                    {
                        IngameOptions.notBar = true;
                    }
                    IngameOptions.rightHover = num19;
                }
                if (IngameOptions.rightHover == num19)
                {
                    UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 7;
                    Main.menuMode = 25;
                }
                num19++;
                if (hSLVector.Z < 0.15f)
                {
                    hSLVector.Z = 0.15f;
                }
                Main.mouseColorSlider.SetHSL(hSLVector);
                Main.mouseColor = Main.mouseColorSlider.GetColor();
                vector3.X += num20;
                IngameOptions.DrawRightSide(sb, "", num19, vector3, vector4, IngameOptions.rightScale[num19], 1f, default(Color));
                IngameOptions.skipRightSlot[num19] = true;
                num19++;
                hSLVector = Main.mouseBorderColorSlider.GetHSLVector();
                if (PlayerInput.UsingGamepad && IngameOptions.rightHover == -1)
                {
                    Main.mouseBorderColorSlider.ApplyToMainLegacyBars();
                }
                IngameOptions.DrawRightSide(sb, Lang.menu[217].Value, num19, vector3, vector4, IngameOptions.rightScale[num19], 1f, default(Color));
                IngameOptions.skipRightSlot[num19] = true;
                num19++;
                vector3.X -= num20;
                if (IngameOptions.DrawRightSide(sb, "", num19, vector3, vector4, IngameOptions.rightScale[num19], (IngameOptions.rightScale[num19] - num4) / (num5 - num4), default(Color)))
                {
                    if (IngameOptions.rightLock == -1)
                    {
                        IngameOptions.notBar = true;
                    }
                    IngameOptions.rightHover = num19;
                }
                IngameOptions.valuePosition.X = value3.X + value2.X - (float)(num3 / 2) - 20f;
                IngameOptions.valuePosition.Y = IngameOptions.valuePosition.Y - 3f;
                IngameOptions.valuePosition.X = IngameOptions.valuePosition.X - num2;
                DelegateMethods.v3_1 = hSLVector;
                num21 = IngameOptions.DrawValueBar(sb, scale, hSLVector.X, 0, new Utils.ColorLerpMethod(DelegateMethods.ColorLerp_HSL_H));
                if ((IngameOptions.inBar || IngameOptions.rightLock == num19) && !IngameOptions.notBar)
                {
                    IngameOptions.rightHover = num19;
                    if (Main.mouseLeft && IngameOptions.rightLock == num19)
                    {
                        hSLVector.X = num21;
                        IngameOptions.noSound = true;
                    }
                }
                if ((float)Main.mouseX > value3.X + value2.X * 2f / 3f + (float)num3 && (float)Main.mouseX < IngameOptions.valuePosition.X + 3.75f && (float)Main.mouseY > IngameOptions.valuePosition.Y - 10f && (float)Main.mouseY <= IngameOptions.valuePosition.Y + 10f)
                {
                    if (IngameOptions.rightLock == -1)
                    {
                        IngameOptions.notBar = true;
                    }
                    IngameOptions.rightHover = num19;
                }
                if (IngameOptions.rightHover == num19)
                {
                    UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 5;
                    Main.menuMode = 252;
                }
                num19++;
                if (IngameOptions.DrawRightSide(sb, "", num19, vector3, vector4, IngameOptions.rightScale[num19], (IngameOptions.rightScale[num19] - num4) / (num5 - num4), default(Color)))
                {
                    if (IngameOptions.rightLock == -1)
                    {
                        IngameOptions.notBar = true;
                    }
                    IngameOptions.rightHover = num19;
                }
                IngameOptions.valuePosition.X = value3.X + value2.X - (float)(num3 / 2) - 20f;
                IngameOptions.valuePosition.Y = IngameOptions.valuePosition.Y - 3f;
                IngameOptions.valuePosition.X = IngameOptions.valuePosition.X - num2;
                DelegateMethods.v3_1 = hSLVector;
                num21 = IngameOptions.DrawValueBar(sb, scale, hSLVector.Y, 0, new Utils.ColorLerpMethod(DelegateMethods.ColorLerp_HSL_S));
                if ((IngameOptions.inBar || IngameOptions.rightLock == num19) && !IngameOptions.notBar)
                {
                    IngameOptions.rightHover = num19;
                    if (Main.mouseLeft && IngameOptions.rightLock == num19)
                    {
                        hSLVector.Y = num21;
                        IngameOptions.noSound = true;
                    }
                }
                if ((float)Main.mouseX > value3.X + value2.X * 2f / 3f + (float)num3 && (float)Main.mouseX < IngameOptions.valuePosition.X + 3.75f && (float)Main.mouseY > IngameOptions.valuePosition.Y - 10f && (float)Main.mouseY <= IngameOptions.valuePosition.Y + 10f)
                {
                    if (IngameOptions.rightLock == -1)
                    {
                        IngameOptions.notBar = true;
                    }
                    IngameOptions.rightHover = num19;
                }
                if (IngameOptions.rightHover == num19)
                {
                    UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 6;
                    Main.menuMode = 252;
                }
                num19++;
                if (IngameOptions.DrawRightSide(sb, "", num19, vector3, vector4, IngameOptions.rightScale[num19], (IngameOptions.rightScale[num19] - num4) / (num5 - num4), default(Color)))
                {
                    if (IngameOptions.rightLock == -1)
                    {
                        IngameOptions.notBar = true;
                    }
                    IngameOptions.rightHover = num19;
                }
                IngameOptions.valuePosition.X = value3.X + value2.X - (float)(num3 / 2) - 20f;
                IngameOptions.valuePosition.Y = IngameOptions.valuePosition.Y - 3f;
                IngameOptions.valuePosition.X = IngameOptions.valuePosition.X - num2;
                DelegateMethods.v3_1 = hSLVector;
                num21 = IngameOptions.DrawValueBar(sb, scale, hSLVector.Z, 0, new Utils.ColorLerpMethod(DelegateMethods.ColorLerp_HSL_L));
                if ((IngameOptions.inBar || IngameOptions.rightLock == num19) && !IngameOptions.notBar)
                {
                    IngameOptions.rightHover = num19;
                    if (Main.mouseLeft && IngameOptions.rightLock == num19)
                    {
                        hSLVector.Z = num21;
                        IngameOptions.noSound = true;
                    }
                }
                if ((float)Main.mouseX > value3.X + value2.X * 2f / 3f + (float)num3 && (float)Main.mouseX < IngameOptions.valuePosition.X + 3.75f && (float)Main.mouseY > IngameOptions.valuePosition.Y - 10f && (float)Main.mouseY <= IngameOptions.valuePosition.Y + 10f)
                {
                    if (IngameOptions.rightLock == -1)
                    {
                        IngameOptions.notBar = true;
                    }
                    IngameOptions.rightHover = num19;
                }
                if (IngameOptions.rightHover == num19)
                {
                    UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 7;
                    Main.menuMode = 252;
                }
                num19++;
                if (IngameOptions.DrawRightSide(sb, "", num19, vector3, vector4, IngameOptions.rightScale[num19], (IngameOptions.rightScale[num19] - num4) / (num5 - num4), default(Color)))
                {
                    if (IngameOptions.rightLock == -1)
                    {
                        IngameOptions.notBar = true;
                    }
                    IngameOptions.rightHover = num19;
                }
                IngameOptions.valuePosition.X = value3.X + value2.X - (float)(num3 / 2) - 20f;
                IngameOptions.valuePosition.Y = IngameOptions.valuePosition.Y - 3f;
                IngameOptions.valuePosition.X = IngameOptions.valuePosition.X - num2;
                DelegateMethods.v3_1 = hSLVector;
                float num22 = Main.mouseBorderColorSlider.Alpha;
                num21 = IngameOptions.DrawValueBar(sb, scale, num22, 0, new Utils.ColorLerpMethod(DelegateMethods.ColorLerp_HSL_O));
                if ((IngameOptions.inBar || IngameOptions.rightLock == num19) && !IngameOptions.notBar)
                {
                    IngameOptions.rightHover = num19;
                    if (Main.mouseLeft && IngameOptions.rightLock == num19)
                    {
                        num22 = num21;
                        IngameOptions.noSound = true;
                    }
                }
                if ((float)Main.mouseX > value3.X + value2.X * 2f / 3f + (float)num3 && (float)Main.mouseX < IngameOptions.valuePosition.X + 3.75f && (float)Main.mouseY > IngameOptions.valuePosition.Y - 10f && (float)Main.mouseY <= IngameOptions.valuePosition.Y + 10f)
                {
                    if (IngameOptions.rightLock == -1)
                    {
                        IngameOptions.notBar = true;
                    }
                    IngameOptions.rightHover = num19;
                }
                if (IngameOptions.rightHover == num19)
                {
                    UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 8;
                    Main.menuMode = 252;
                }
                num19++;
                Main.mouseBorderColorSlider.SetHSL(hSLVector);
                Main.mouseBorderColorSlider.Alpha = num22;
                Main.MouseBorderColor = Main.mouseBorderColorSlider.GetColor();
                vector3.X += num20;
                IngameOptions.DrawRightSide(sb, "", num19, vector3, vector4, IngameOptions.rightScale[num19], 1f, default(Color));
                IngameOptions.skipRightSlot[num19] = true;
                num19++;
                string txt = "";
                switch (LockOnHelper.UseMode)
                {
                    case LockOnHelper.LockOnMode.FocusTarget:
                        txt = Lang.menu[232].Value;
                        break;
                    case LockOnHelper.LockOnMode.TargetClosest:
                        txt = Lang.menu[233].Value;
                        break;
                    case LockOnHelper.LockOnMode.ThreeDS:
                        txt = Lang.menu[234].Value;
                        break;
                }
                if (IngameOptions.DrawRightSide(sb, txt, num19, vector3, vector4, IngameOptions.rightScale[num19] * 0.9f, (IngameOptions.rightScale[num19] - num4) / (num5 - num4), default(Color)))
                {
                    IngameOptions.rightHover = num19;
                    if (flag4)
                    {
                        LockOnHelper.CycleUseModes();
                    }
                }
                num19++;
                if (IngameOptions.DrawRightSide(sb, Player.SmartCursorSettings.SmartBlocksEnabled ? Lang.menu[215].Value : Lang.menu[216].Value, num19, vector3, vector4, IngameOptions.rightScale[num19] * 0.9f, (IngameOptions.rightScale[num19] - num4) / (num5 - num4), default(Color)))
                {
                    IngameOptions.rightHover = num19;
                    if (flag4)
                    {
                        Player.SmartCursorSettings.SmartBlocksEnabled = !Player.SmartCursorSettings.SmartBlocksEnabled;
                    }
                }
                num19++;
                if (IngameOptions.DrawRightSide(sb, Main.cSmartCursorToggle ? Lang.menu[121].Value : Lang.menu[122].Value, num19, vector3, vector4, IngameOptions.rightScale[num19], (IngameOptions.rightScale[num19] - num4) / (num5 - num4), default(Color)))
                {
                    IngameOptions.rightHover = num19;
                    if (flag4)
                    {
                        Main.cSmartCursorToggle = !Main.cSmartCursorToggle;
                    }
                }
                num19++;
                if (IngameOptions.DrawRightSide(sb, Player.SmartCursorSettings.SmartAxeAfterPickaxe ? Lang.menu[214].Value : Lang.menu[213].Value, num19, vector3, vector4, IngameOptions.rightScale[num19] * 0.9f, (IngameOptions.rightScale[num19] - num4) / (num5 - num4), default(Color)))
                {
                    IngameOptions.rightHover = num19;
                    if (flag4)
                    {
                        Player.SmartCursorSettings.SmartAxeAfterPickaxe = !Player.SmartCursorSettings.SmartAxeAfterPickaxe;
                    }
                }
                num19++;
            }
            if (IngameOptions.rightHover != -1 && IngameOptions.rightLock == -1)
            {
                IngameOptions.rightLock = IngameOptions.rightHover;
            }
            for (int n = 0; n < num8 + 1; n++)
            {
                UILinkPointNavigator.SetPosition(2900 + n, vector + vector2 * (float)(n + 1));
            }
            int num23 = 0;
            Vector2 zero = Vector2.Zero;
            if (flag)
            {
                zero.X = -40f;
            }
            for (int num24 = 0; num24 < num11; num24++)
            {
                if (!IngameOptions.skipRightSlot[num24])
                {
                    UILinkPointNavigator.SetPosition(2930 + num23, vector3 + zero + vector4 * (float)(num24 + 1));
                    num23++;
                }
            }
            UILinkPointNavigator.Shortcuts.INGAMEOPTIONS_BUTTONS_RIGHT = num23;
            Main.DrawGamepadInstructions();
            Main.mouseText = false;
            Main.instance.GUIBarsDraw();
            Main.instance.DrawMouseOver();
            Vector2 bonus = Main.DrawThickCursor(false);
            Main.DrawCursor(bonus, false);
        }
    }
}
