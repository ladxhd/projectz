using System.Collections.Generic;
using Microsoft.Xna.Framework;
using ProjectZ.InGame.Controls;
using ProjectZ.InGame.Interface;
using ProjectZ.InGame.Things;

namespace ProjectZ.InGame.Pages
{
    class ModifierSettingsPage : InterfacePage
    {
        private readonly InterfaceListLayout _bottomBar;

        public ModifierSettingsPage(int width, int height)
        {
            // modifier settings layout
            var modifierSettingsList = new InterfaceListLayout { Size = new Point(width, height), Selectable = true };
            var buttonWidth = 240;

            modifierSettingsList.AddElement(new InterfaceLabel(Resources.GameHeaderFont, "settings_modifier_header",
                new Point(buttonWidth, (int)(height * Values.MenuHeaderSize)), new Point(0, 0)));

            var contentLayout = new InterfaceListLayout { Size = new Point(width, (int)(height * Values.MenuContentSize)), Selectable = true, ContentAlignment = InterfaceElement.Gravities.Top };

            contentLayout.AddElement(new InterfaceSlider(Resources.GameFont, "settings_modifier_damage",
            buttonWidth, new Point(1, 2), 0, 4, 1, GameSettings.DamageMultiplier,
            number => { GameSettings.DamageMultiplier = number; })
            { SetString = number => " " + GameSettings.DamageMultiplier + " x" });

            var toggleNoHearts = InterfaceToggle.GetToggleButton(new Point(buttonWidth, 18), new Point(5, 2),
                "settings_modifier_no_hearts", GameSettings.NoHeartDrops, newState => { GameSettings.NoHeartDrops = newState; });
            contentLayout.AddElement(toggleNoHearts);

            modifierSettingsList.AddElement(contentLayout);

            _bottomBar = new InterfaceListLayout() { Size = new Point(width, (int)(height * Values.MenuFooterSize)), Selectable = true, HorizontalMode = true };
            // back button
            _bottomBar.AddElement(new InterfaceButton(new Point(60, 20), new Point(2, 4), "settings_menu_back", element =>
            {
                Game1.UiPageManager.PopPage();
            }));

            modifierSettingsList.AddElement(_bottomBar);

            PageLayout = modifierSettingsList;
        }

        public override void Update(CButtons pressedButtons, GameTime gameTime)
        {
            base.Update(pressedButtons, gameTime);

            // close the page
            if (ControlHandler.ButtonPressed(CButtons.B))
                Game1.UiPageManager.PopPage();
        }

        public override void OnLoad(Dictionary<string, object> intent)
        {
            // the left button is always the first one selected
            _bottomBar.Deselect(false);
            _bottomBar.Select(InterfaceElement.Directions.Left, false);
            _bottomBar.Deselect(false);

            PageLayout.Deselect(false);
            PageLayout.Select(InterfaceElement.Directions.Top, false);
        }
    }
}
