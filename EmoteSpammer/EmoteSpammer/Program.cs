namespace MikuSpammer
{
    using System;
    using EloBuddy;
    using EloBuddy.SDK.Menu;
    using EloBuddy.SDK.Events;
    using EloBuddy.SDK.Menu.Values;

    internal class Program
    {

        public static Menu Menu, Emote;

        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Game_OnStart;


        }

        private static void Game_OnStart(EventArgs args)
        {

            Menu = MainMenu.AddMenu("Spammer", "Spammer");

            Menu.AddGroupLabel("Miku's Global Spammer");
            Menu.AddLabel("For all your spamming needs <3");
            Menu.AddSeparator();
            Menu.AddLabel("V1.0");
            Menu.AddSeparator();
            Menu.AddLabel("Love you Radi");
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

            if (Emote["EmoteToggleHotkey"].Cast<KeyBind>().CurrentValue && tick == 59 || Emote["EmotePressHotkey"].Cast<KeyBind>().CurrentValue && tick == 59)
            {
                EmoteSpam();
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
    }
}