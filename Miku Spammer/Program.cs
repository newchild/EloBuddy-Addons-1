//Hola mi nombre es hadriiw and I sell accounts - Royals™

using System.Security.Cryptography.X509Certificates;

namespace Spammer
{
    using System;
    using EloBuddy;
    using EloBuddy.SDK.Menu;
    using EloBuddy.SDK.Events;
    using EloBuddy.SDK.Menu.Values;

    internal class Program
    {
        private static string all = "";
        public static Menu Menu, Miku, Radi, Emote, Hotkeys;

        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Game_OnStart;



        }

        private static void Game_OnStart(EventArgs args)
        {

            Chat.Print("Miku's Spammer Loaded, Good luck!");
            Menu = MainMenu.AddMenu("Spammer", "Spammer");

            Menu.AddGroupLabel("Miku's Global Spammer");
            Menu.AddLabel("For all your spamming needs <3");
            Menu.AddSeparator();
            Menu.AddLabel("V1.0");
            Menu.AddSeparator();
            Menu.AddLabel("Love you Radi");


            Miku = Menu.AddSubMenu("MikuSpammer", "MikuSpammer");
            Miku.AddGroupLabel("SFW Spammer featuring a bunch of plebs");
            Miku.AddGroupLabel("What to Spam?");
            var MikuSpamList = Miku.Add("Miku Spamming", new Slider("Miku Spam list", 0, 0, 19));
            MikuSpamList.OnValueChange += delegate
            {
                MikuSpamList.DisplayName = "Spamming " + new[] { "Radi", "Miku", "Royals", "Killer", "Tim", "Sweden", "Taco", "Eldiath", "Dan", "Finn", "Oxide", "LostIt", "Broly", "Leva", "Pepe", "Akame", "Miro", "Porn", "Degrec", "Timmey" }
                //"Ian", "Nathan", "Tahm", "Alfie", "Rhys" }
                [MikuSpamList.CurrentValue];

            };

            Radi = Menu.AddSubMenu("RadiSpammer", "RadiSpammer");
            Radi.AddGroupLabel("NSFW Spammer with a huge amount of kanker");
            Radi.AddGroupLabel("What to Spam?");
            var RadiSpamList = Radi.Add("Radi Spamming", new Slider("Radi Spam list", 0, 0, 8));
            RadiSpamList.OnValueChange += delegate
            {
                RadiSpamList.DisplayName = "Spamming " + new[] {
                    "Jew", "Cancer", "kurwa = fuck", "Pizda = pussy", "Suka = bitch", "Suck my dick ", "Retarded?", "jerk Off", "Mid Or feed" }

                [RadiSpamList.CurrentValue];
            };




            Emote = Menu.AddSubMenu("EmoteSpammer", "EmoteSpammer");
            Emote.AddGroupLabel("Spam a secleted emote");
            Emote.AddLabel("Mastery spam requires level 4+ on the champion to use!");
            Emote.AddLabel("Spamming emotes will reduce orbwalker efficency!");
            var EmoteSpamList = Emote.Add("Emote Spamming", new Slider("EmoteList", 0, 0, 3));
            EmoteSpamList.OnValueChange += delegate
            {
                EmoteSpamList.DisplayName = "Spamming " + new[] { "Laugh", "Taunt", "Joke", "Mastery" }
                [EmoteSpamList.CurrentValue];
            };
            Emote.Add("EmotePressHotkey", new KeyBind("Press To Spam", false, KeyBind.BindTypes.HoldActive, 'T'));
            Emote.Add("EmoteToggleHotkey", new KeyBind("Toggle To Spam", false, KeyBind.BindTypes.PressToggle, 'L'));


            Hotkeys = Menu.AddSubMenu("Options", "Options");
            Hotkeys.AddGroupLabel("Enable Spammers");
            Hotkeys.Add("Enable MikuSpammer?", new CheckBox("Enable MikuSpammer?"));
            Hotkeys.Add("Enable RadiSpammer?", new CheckBox("Enable RadiSpammer?", false));
            Hotkeys.Add("Enable EmoteSpammer", new CheckBox("Enable Emotespammer?"));
            Hotkeys.AddSeparator();
            Hotkeys.AddGroupLabel("MikuSpammer");
            Hotkeys.Add("MikuPressHotkey", new KeyBind("Press To Spam", false, KeyBind.BindTypes.HoldActive, 'A'));
            Hotkeys.Add("MikuToggleHotkey", new KeyBind("Toggle To Spam", false, KeyBind.BindTypes.PressToggle, 'K'));
            Hotkeys.Add("All Chat On Miku", new CheckBox("Spam in all chat?"));
            Hotkeys.AddSeparator();
            Hotkeys.AddGroupLabel("RadiSpammer");
            Hotkeys.Add("RadiPressHotkey", new KeyBind("Press To Spam", false, KeyBind.BindTypes.HoldActive, 'A'));
            Hotkeys.Add("RadiToggleHotkey", new KeyBind("Toggle To Spam", false, KeyBind.BindTypes.PressToggle, 'K'));
            Hotkeys.Add("All Chat On Radi", new CheckBox("Spam in all chat?"));
            Hotkeys.AddSeparator();
            Hotkeys.AddGroupLabel("EmoteSpammer");
            Hotkeys.Add("EmotePressHotkey", new KeyBind("Press To Spam", false, KeyBind.BindTypes.HoldActive, 'T'));
            Hotkeys.Add("EmoteToggleHotkey", new KeyBind("Toggle To Spam", false, KeyBind.BindTypes.PressToggle, 'L'));

            Game.OnUpdate += OnUpdate;
        }

        public static void OnUpdate(EventArgs args)
        {
            double tick = 0;
            tick = TimeSpan.FromSeconds(Environment.TickCount).Minutes;

            if (ObjectManager.Player.HasBuff("Recall"))
            {
                return;
            }

            {

                if (Hotkeys["EmoteToggleHotkey"].Cast<KeyBind>().CurrentValue && tick == 59 && Hotkeys["Enable EmoteSpammer?"].Cast<CheckBox>().CurrentValue || Hotkeys["EmotePressHotkey"].Cast<KeyBind>().CurrentValue && tick == 59 && Hotkeys["Enable EmoteSpammer?"].Cast<CheckBox>().CurrentValue)
                {
                    EmoteSpam();
                }

                if (Hotkeys["MikuToggleHotkey"].Cast<KeyBind>().CurrentValue && Hotkeys["Enable MikuSpammer?"].Cast<CheckBox>().CurrentValue || Hotkeys["MikuPressHotkey"].Cast<KeyBind>().CurrentValue && Hotkeys["Enable MikuSpammer?"].Cast<CheckBox>().CurrentValue)
                {
                    MikuSpam();
                }

                if (Hotkeys["RadiToggleHotkey"].Cast<KeyBind>().CurrentValue && Hotkeys["Enable RadiSpammer?"].Cast<CheckBox>().CurrentValue || Hotkeys["RadiPressHotkey"].Cast<KeyBind>().CurrentValue && Hotkeys["Enable RadiSpammer?"].Cast<CheckBox>().CurrentValue)
                {
                    RadiSpam();
                }

            }
        }

        public static void EmoteSpam()
        {

            switch (Emote["Emote Spamming"].Cast<Slider>().CurrentValue)
            {
                case 0:
                    Chat.Say("/l");
                    break;
                case 1:
                    Chat.Say("/t");
                    break;
                case 2:
                    Chat.Say("/j");
                    break;
                case 3:
                    Chat.Say("/masterybadge");
                    break;
            }
        }

        private static void MikuSpam()
        {
            if (Hotkeys["All Chat On Miku"].Cast<CheckBox>().CurrentValue)
            {
                all = "/all ";
            }
            else all = "";

            switch (Miku["Miku Spamming"].Cast<Slider>().CurrentValue)
            {
                case 0:
                    Chat.Say(all + "kurwa Radi");
                    break;
                case 1:
                    Chat.Say(all + "Desu");
                    break;
                case 2:
                    Chat.Say(all + "suck my balls");
                    break;
                case 3:
                    Chat.Say(all + "I can only play with relax!");
                    break;
                case 4:
                    Chat.Say(all + "I'm the most HQ here");
                    break;
                case 5:
                    Chat.Say(all + "Nein!");
                    break;
                case 6:
                    Chat.Say(all + "Me encanta patatas fritas <3");
                    break;
                case 7:
                    Chat.Say(all + "wub");
                    break;
                case 8:
                    Chat.Say(all + "STFU no one cares");
                    break;
                case 9:
                    Chat.Say(all + "Hab Dich Lieb");
                    break;
                case 10:
                    Chat.Say(all + "Leeching pleb, kurwa!");
                    break;
                case 11:
                    Chat.Say(all + "Error - Spam Missing (I lost it)");
                    break;
                case 12:
                    Chat.Say(all + "Thugdoge");
                    break;
                case 13:
                    Chat.Say(all + "Fuck you");
                    break;
                case 14:
                    Chat.Say(all + "Sad Pepe");
                    break;
                case 15:
                    Chat.Say(all + "Kill La Kill > Akame Ga Kill");
                    break;
                case 16:
                    Chat.Say(all + "Change name!");
                    break;
                case 17:
                    Chat.Say(all + ">Comes on skype");
                    Chat.Say(all + ">Looks for Porn");
                    break;
                case 18:
                    Chat.Say(all + "Hola mi nombre es degrec");
                    break;
                case 19:
                    Chat.Say(all + "if (face not fat)");
                    Chat.Say(all + "Body not fat");
                    Chat.Say(all + " ");
                    break;
                default:
                    Chat.Say("");
                    break;
            }
        }







    


    private static void RadiSpam()
    {
        if (Hotkeys["All Chat On Radi"].Cast<CheckBox>().CurrentValue)
        {
            all = "/all ";
        }
        else all = "";

        switch (Radi["Radi Spamming"].Cast<Slider>().CurrentValue)
        {
            case 0:
                Chat.Say(all + "Fuck off you fucking jew");
                break;
            case 1:
                Chat.Say(all + "Fuck off and get cancer");
                break;
            case 2:
                Chat.Say(all + "Kurwa Kurwa Kurwa");
                break;
            case 3:
                Chat.Say(all + "I get more pizda than you, you fucking pizda");
                break;
            case 4:
                Chat.Say(all + "Suka");
                break;
            case 5:
                Chat.Say(all + "Suck my dick");
                break;
            case 6:
                Chat.Say(all + "Are you fucking retarded?");
                break;
            case 7:
                Chat.Say(all + "Jerk off kid!");
                break;
            case 8:
                Chat.Say(all + "Kurwa mid or feed ja perdole");
                break;

            default:
                Chat.Say("");
                break;
        }
    }



}
}