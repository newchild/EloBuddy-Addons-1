using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Enumerations;

namespace DildoBuddy
{
    internal class Program
    {
        public static Menu Menu, Options;
        public static Spell.Chargeable Q;
        public static Spell.Skillshot W;
        public static Spell.Skillshot E;
        public static Spell.Skillshot R;
        public static Spell.Targeted Ignite;



        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Game_OnStart;
        }

        private static void Game_OnStart(EventArgs args)
        {
            Chat.Print("Moobuddy Loaded. Enjoy the game!");


            Q = new Spell.Chargeable(SpellSlot.Q, 750, 1500, 1, 250, null, 100);


            Menu = MainMenu.AddMenu("Moobuddy", "Moobuddy");

            Menu.AddGroupLabel("Moobuddy");
            Menu.AddLabel("~Moo");
            Menu.AddSeparator();
            Menu.AddLabel("V1.0");
            Menu.AddSeparator();
            Menu.AddLabel("Kurwa Radi");

            //Options = Options.AddSubMenu("Options");

            //Options.AddGroupLabel("Combo");
            //Options.Add("ComboUseQ", new CheckBox("Use Q"));
            //Options.Add("ComboUseW", new CheckBox("Use W"));
            //Options.Add("ComboUseE", new CheckBox("Use E"));
            //Options.Add("ComboUseR", new CheckBox("Use R"));
            //Options.Add("ComboUseAA", new CheckBox("Use AA"));
            //Options.Add("ComboMM", new Slider("Mana Manager", 0, 0, 100));

            //Fill In Options

            Game.OnUpdate += OnGameUpdate;
        }

        private static void OnGameUpdate(EventArgs args)
        {
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
            {
                Combo();
            }

            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass))
            {
                Harass();
            }

            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LastHit))
            {
                LastHit();
            }

            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear))
            {
                LaneClear();
            }
        }

        private static void Combo()
        {
            Chat.Say("Moo");
        }

        private static void Harass()
        {
            Chat.Say("Couch vopy couch vopy mum get the dildo!");
        }

        private static void LastHit()
        {
            Chat.Say("Couch vopy couch vopy mum get the dildo!");
        }

        private static void LaneClear()
        {
            Chat.Say("Couch vopy couch vopy mum get the dildo!");
        }
    }
}
