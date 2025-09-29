# Achievement Fixer

## Research & Design Notes
- Goal: keep achievements working in **Cities: Skylines II** even when the game is started with mods.
- Normally, any **active mods** (not assets) make achievements ineligible for that session.

## What the mod does (Phase 1)
- **Re-enables the achievements backend** right after each city finishes loading, and keeps it on during a short assert window.
- **Removes the warning banner** (“Achievements are disabled because of mods.”) via a small localization override.
- **Uses the game’s own localization** to show friendly, spaced, punctuated achievement names in the dropdown:
  - Reads `Achievements.TITLE[<InternalName>]` from the active `LocalizationDictionary`.
  - No title-case heuristics, no regex splitting, and no hardcoded exception list.
- **Advanced tools** (Options → Advanced):
  - Unlock selected achievement
  - Clear (reset) selected achievement
  - Debug: Reset **All** (wipe) — for testing only

> DLC achievements remain controlled by the base game and DLC ownership.

---

## Methods (current)
- On city load complete → set `PlatformManager.instance.achievementsEnabled = true`.
- For a short window (**~5s = 300 frames**), re-assert once per frame if the flag flips off.
- Clear logging of actions.
- Localization for Options UI is provided via `IDictionarySource` per locale.
- Achievement display names are resolved via **O(1)** lookups in `LocalizationManager.activeDictionary`
  using keys like `Achievements.TITLE[MyFirstCity]`.

---

## Project Layout (files & classes)
- **Namespace:** `AchievementFixer`
- **Files:**
  - `Mod.cs` — entry point; logging, localization sources, system registration, banner override.
  - `Settings.cs` — Options UI (Main & Advanced), dropdown, unlock/reset actions.
  - `AchievementFixerSystem.cs` — keeps `achievementsEnabled` true for ~5s after load (inherits `GameSystemBase`).
  - `Locale/*.cs` — per-language Options UI strings (achievement titles come from the game).
  - `AchievementDisplay.cs` — resolves titles via `Achievements.TITLE[InternalName]` lookups.
  - `Utilities/DebugLocaleScan.cs` (**DEBUG builds only**) — scanner to find locale keys/values in the active dictionary.

---

## Key types & APIs (dnSpyEX research)

| Type / Member | Kind | Advantages |
|---|---|---|
| `GameSystemBase` | Base class | Lifecycle hooks and `OnUpdate()` integration. |
| `GameSystemBase.OnGameLoadingComplete(Purpose, GameMode)` | Method | Reliable moment to enable backend and start short assert window. |
| `GameSystemBase.OnUpdate()` | Method | Per-frame enforcement during the window. |
| `Colossal.PSI.Common.PlatformManager.instance` | Singleton | Central control for `achievementsEnabled`; achievement enumeration. |
| `PlatformManager.achievementsEnabled : bool` | Field/prop | Master switch the game ANDs with mod/option flags. |
| `PlatformManager.EnumerateAchievements()` / `IAchievement` | API | Access to IDs, `internalName`, progress. |
| `Colossal.Localization.LocalizationManager` | Service | Manages locales and exposes the active `LocalizationDictionary`. |
| `LocalizationDictionary.TryGetValue(key, out value)` | Method | Fast, allocation-light lookup for `Achievements.TITLE[...]`. |
| `IDictionarySource` | Interface | Minimal, safe layering of custom UI strings per locale. |
| `GameManager.instance.localizationManager.AddSource(locale, source)` | Method | Late-binding of small overrides without patching vanilla code. |
| `Game.UI.InGame.AchievementsUISystem` | UISystemBase | Vanilla achievements panel (icons and progress). |
| `_c.Menu.ACHIEVEMENTS_WARNING_*` keys | Localization keys | Targeted string override for the “mods disabled” banner. |
| `Media/Game/Achievements/*.png` | Assets | Consistent icon naming: `<internalName>.png`, plus `_locked` variant. |
| `CityConfigurationSystem.usedMods.Count` | Field | Drives vanilla “ModsDisabled” tab state. |
| `Achievements` (static IDs) | Data | Canonical achievement identifiers (e.g., `MyFirstCity`, `AllSmiles`). |
| `AchievementTriggerSystem` | System | Vanilla ANDs `achievementsEnabled` with option flags on load. |

> `AchievementsHelper` is useful for metadata but not required for titles when localization keys are available.

---

## UI / Localization Hooks (implemented)
- **Banner override**: add a tiny `IDictionarySource` redefining `Menu.ACHIEVEMENTS_WARNING_MODS` (and siblings if desired).
- **Achievement titles**:  
  `localizationManager.activeDictionary.TryGetValue($"Achievements.TITLE[{internalName}]", out value)`  
  and display `value` (already spaced, cased, and punctuated).

### Debug helper: `DebugLocaleScan.cs`
- is a tool used in DEBUG builds that can log useful info:
- Counts of `Achievements.TITLE[...]` and `Achievements.DESCRIPTION[...]` keys.
- Arbitrary value-substring matches to discover unknown keys for future mods.

---

## Performance
- ~1–2 property checks per frame for ~5s after city load; then zero cost.
- Title resolution is **O(1)** dictionary lookup; performed when building the dropdown.

## Compatibility & Risks
- Save data, achievement definitions, and DLC logic are untouched.
- Low conflict surface: a single engine flag plus minimal localization overlays.

---

## Algorithm (current)

- `kAssertFrames = 300` (≈5s @ 60 FPS)

OnGameLoadingComplete:
framesLeft = kAssertFrames
ForceEnableIfNeeded("OnGameLoadingComplete")

OnUpdate:
if framesLeft > 0:
ForceEnableIfNeeded("OnUpdate")
framesLeft--

`ForceEnableIfNeeded(source)`:

if PlatformManager.instance != null and !achievementsEnabled:
set achievementsEnabled = true
log("forced TRUE")


---

## APIs to remember (for future mods)
- `LocalizationManager.activeDictionary.entries` — enumerate all keys/values in the active locale.
- `LocalizationDictionary.TryGetValue(key, out value)` — fast lookup for `Achievements.TITLE[<InternalName>]`.
- `GameManager.instance.localizationManager.AddSource(localeId, IDictionarySource)` — layer small overrides safely.
- `PlatformManager.instance.EnumerateAchievements()` — access `IAchievement` items (IDs, `internalName`, progress).
- `PlatformManager.instance.achievementsEnabled` — single switch that enables/disables platform achievements.


