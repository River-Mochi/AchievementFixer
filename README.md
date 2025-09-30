# Achievement Fixer (AF)

Keep achievements working in **Cities: Skylines II** even when you play with mods.  
We keep the game from disabling the backend.

## What it does
- **Enables achievements** even if mods are loaded.
- Active mods (not assets) will normally disqualify any acheivement completion.
- City switching: this mod works even when switching saves.
- **Fixes the warning banner** (“Achievements are disabled because of mods.”) by sending a message to localization.
- **Shows friendly achievement names** using the game’s own localization dictionary.
- **Language switching**: works even if you switch languages (by reading the game's locale dictionary).


## How to use
1. Install mod from Skyve or Paradox Mods.
   - No configuration needed; we enable achievements by default.
2. Do the tasks (e.g., build 10 parks to get *Groundskeeper*).  
3. Safe to remove anytime; this mod doesn’t touch your saves.

## Advanced tab (optional)
- **Select achievement** → **Unlock selected**: immediately marks it completed.
- **Clear selected**: resets a single achievement (back to not completed).
- **Debug: RESET ALL**: wipes all achievement progress (useful for testing).  
  If you click this by accident, you can unlock the ones you want again.

## Languages
- UI supports 10 languages: **EN, FR, DE, ES, IT, JA, KO, PT-BR, ZH-HANS, VI**.  
- Drop-down Achievement names come from the game, so they match whatever language you use in the game (except for VI which does not have an ingame dictionary).
- Future plan is to add locale support for all the game languages.

## Notes
- Six additional achievements shown on Steam can not be acquired until Bridges & Ports DLC is released.
- If an achievement doesn’t pop right away, a game restart sometimes helps (CS2 quirk).
- CS2 WiKi page all about **[achievements](https://cs2.paradoxwikis.com/Achievements)**.

## Compatibility
- Designed to be minimal and conflict-free: does not use Reflection or Harmony (more stable on game updates). 
- AF only manage the platform flag and localization.
- Safe to remove anytime; does not touch saves.
- Should work with other mods, avoid using other "achievement" mods at the same time.

## Thanks
- Inspired by Wayzware's early [Achievement Enabler](https://github.com/Wayzware/AchievementEnabler) (no longer works).
- Thanks to **StarQ** and the CS2 modding community for pointers and testing.

## Links
- 📘 [Achievements Wiki](https://cs2.paradoxwikis.com/Achievements)
- 🧩 [Paradox Mods](https://mods.paradoxplaza.com/games/cities_skylines_2?orderBy=desc&sortBy=updated&tags=Code%20Mod&time=quarter)
- 💻 [GitHub](https://github.com/River-Mochi/AchievementFixer)
