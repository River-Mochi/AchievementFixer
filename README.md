# Achievement Fixer

Keep achievements working in **Cities: Skylines II** even when you play with mods.  
We keep the game from disabling the backend.

## What it does
- **Enables achievements** even if mods are loaded.
  - Active mods (not assets) will normally disqualify any acheivement completion.
- **City switching:** this mod works even when switching saves.
- **Fixes the warning banner** “Achievements are disabled because of mods.”
  - by sending a message to localization.
- **Shows friendly achievement names** using the game’s own localization dictionary.
- **Language switching**: works even if you switch languages
  - re-reads the game's locale dictionary.


## How to use
1. Install the mod from Skyve or Paradox Mods.
   - No configuration needed; we enable achievements by default.
2. Do the tasks (e.g., build 10 parks to get *Groundskeeper*).  
3. Safe to remove anytime; this mod doesn’t touch your saves.

## Advanced tab (optional)
- **Select achievement** →
  - `[Unlock selected]` immediately marks it completed.
  - `[Clear selected]`  resets a single achievement (back to not completed).
- `[Debug: RESET ALL]` wipes all achievement progress (useful for testing).  
  If you click this by accident, you can unlock the ones you want again.

## Language support
- 9 languages: **EN, FR, DE, ES, IT, JA, KO, PT-BR, ZH-HANS  
- Drop-down Achievement names come from the game, so they match whatever language you use in the game (except for VI which does not currently have an ingame dictionary).
- Future plan to add locale support for all game languages. WIP: Tiếng Việt (Vietnamese)

## Notes
- Six additional achievements shown on Steam can not be acquired until Bridges & Ports DLC is released.
- If an achievement doesn’t pop right away, a game restart sometimes helps (CS2 quirk).

## Compatibility
- Designed to be minimal and conflict-free: we only manage the platform flag and localization.

- Safe to remove anytime; does not touch saves.
- Should work with other mods, but avoid using/installing any other achievement mods at the same time.

## Thanks
- Inspired by **Wayzware's** early [Achievement Enabler](https://github.com/Wayzware/AchievementEnabler) (defunct).
- **rcav8tr** for code snippets to find localization keys.
- **StarQ** for technical help.
- and the CS2 modding community for pointers and testing.

## Links
- 📘 [CS2 Achievements Wiki](https://cs2.paradoxwikis.com/Achievements)
- 🧩 [Paradox Mods](https://mods.paradoxplaza.com/games/cities_skylines_2?orderBy=desc&sortBy=updated&tags=Code%20Mod&time=quarter)
- 💻 [GitHub](https://github.com/River-Mochi/AchievementFixer)
