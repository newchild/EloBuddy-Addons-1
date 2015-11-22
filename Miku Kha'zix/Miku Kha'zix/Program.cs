using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace Miku_Kha_zix
{
    public static class Program
    {
        public static Menu Menu, Options;
        public const string ChampName = "Kha'zix";

        public static Spell.Targeted Q;
        public static Spell.Skillshot W;
        public static Spell.Skillshot E;
        public static Spell.Active R;

        private static bool EvoQ, EvoW, EvoE, EvoR;

        public static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Game_OnStart;
            
            //Unevolved Spells
            Q = new Spell.Targeted(SpellSlot.Q, 325);
            W = new Spell.Skillshot(SpellSlot.W, 1000, SkillShotType.Linear);
            E = new Spell.Skillshot(SpellSlot.E, 600, SkillShotType.Circular);
            R = new Spell.Active(SpellSlot.R);
            //Evolved Spells
            Q2 = new Spell.Targeted(SpellSlot.Q, 375);
        }


        private static void Game_OnStart(EventArgs args)
        {
            if (Player.Instance.ChampionName != ChampName)
            {
                return;
            }
            Chat.Print("Miku Kha'zix Loaded. Enjoy the game!");


           


            Menu = MainMenu.AddMenu("Kha'zix", "Kha'zix");

            Menu.AddGroupLabel("Miku's Shitty Kha'zix");
            Menu.AddLabel("My First Champion Script");
            Menu.AddSeparator();
            Menu.AddLabel("V1.0");
            Menu.AddSeparator();
            Menu.AddLabel("Kurwa Radi");

            Options = Options.AddSubMenu("Options");

            Options.AddGroupLabel("Combo");
            Options.Add("ComboUseQ", new CheckBox("Use Q"));
            Options.Add("ComboUseW", new CheckBox("Use W"));
            Options.Add("ComboUseE", new CheckBox("Use E"));
            Options.Add("ComboUseR", new CheckBox("Use R"));
            Options.Add("ComboMM", new Slider("Mana Manager", 0, 0, 100));

            //Fill In Options

            Game.OnUpdate += OnGameUpdate;

        }

        private static void OnGameUpdate(EventArgs args)
        {
            if(Orbwalker.ActiveModesFlags.Equals(Orbwalker.ActiveModes.Combo))
            {
                Combo();
            }
        }

        private static void Combo()
        {
            var target = TargetSelector.GetTarget(E.Range, DamageType.Physical);
        }
    }
}