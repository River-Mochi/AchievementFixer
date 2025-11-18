# Achievement Fixer  [AF]

Keep achievements working in **Cities: Skylines II** even when playing with mods.  
This keeps the game from disabling the achievements backend.

## What it does
- **Enables achievements** even if mods are loaded.
  - Active mods (not assets) will normally disqualify any achievement completion.
- **City switching:** this mod works even when switching saves.
- **Fixes the warning banner** “Achievements are disabled because of mods.”
  - by sending a message to localization.
- **Shows friendly achievement names** using the game’s own localization dictionary.
- **Language switching**: works even if you switch languages
  - re-reads the game's locale dictionary.

## How to use
1. Install the mod from Skyve or Paradox Mods.
   - No configuration needed; achievements enabled by default.
2. Do the tasks (e.g., build 10 parks to get *Groundskeeper*).  
3. Safe to remove anytime
4. Optional: use the Advanced tab to unlock/clear achievements manually for instant gratification or testing.
5. Remove all other Achievement mods to avoid conflicts.


## Notes
- If an achievement doesn’t pop right away, a game restart sometimes helps (CS2 quirk).

## 11 languages
* English, Français (French), Deutsch (German), Español (Spanish), Italiano (Italian), Polski (Polish)
* 日本語 (Japanese), 한국어 (Korean), 简体中文 (Simplified Chinese), 繁體中文 (Traditional Chinese)
* Português (Brasil) (Brazilian Portuguese)
* Drop-down achievement names come from the game, so they match whatever game language you use (VI which does not currently have an in-game dictionary).
* Future updates may add more languages. WIP: Tiếng Việt (Vietnamese)

## Advanced tab (optional)
- **Select achievement** →
  - `[Unlock Selected]` immediately marks it completed.
  - `[Clear Selected]`  resets a single achievement (back to not completed).
- `[DEBUG: Reset All]` wipes all achievement progress (useful for testing).  If you click this by accident, you can use the Unlock button to get them back.

## Compatibility
- Safe to remove anytime; does not touch saves.
- This mod does not use Reflection or Harmony, so it's safe/compatible, and less likely to break with every game update.
- Designed to be minimal and conflict-free: we only manage the platform flag and localization.
- Remove all other Achievement mods if you want the mod to work and to prevent conflicts 

## Interaction with I18N Everywhere (1I18L)

For players who also use **I18N Everywhere** to localize other mods. There is one current quirk:

- For most languages, Achievement Fixer’s banner override wins without issues. Banner "Achivements are diabled..." is overwritten by Achivmeent Fixer's localized banner.
- For **Korean**, I18N’s own localization can override the AF banner text.

If you are using **I18N Everywhere** and still see the vanilla Korean banner:
1. Open **I18N Everywhere’s settings**.
2. **Turn OFF “Enable overwrite”** (uncheck the box).
3. Restart the game or reload the city.

Achievement Fixer mod **still work** either way; this only affects the simple *text* shown in the warning banner but not achievements.  
The long-term fix might require a change on the I18N mod side; I’ll keep the README updated if that changes.


## Credits
- Inspired by **Wayzware's** early [Achievement Enabler](https://github.com/Wayzware/AchievementEnabler) (defunct).
- **rcav8tr** for code snippets to find localization keys.
- **StarQ** for technical support.
- **yenyang** for code review and technical advice.
- **Necko1996** for testing
- and the CS2 modding community for pointers and testing.

## Links
- 📘 [CS2 Achievements Wiki](https://cs2.paradoxwikis.com/Achievements)
- 🧩 [Paradox Mods](https://mods.paradoxplaza.com/games/cities_skylines_2?orderBy=desc&sortBy=updated&tags=Code%20Mod&time=quarter)
- 💻 [GitHub](https://github.com/River-Mochi/AchievementFixer)
