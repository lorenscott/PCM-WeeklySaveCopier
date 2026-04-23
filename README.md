# PCM Weekly Save Copier v3.0

A Windows utility for restoring weekly saves in **Pro Cycling Manager** (Steam edition).

---

## The Problem

PCM saves your career progress as an active game database (`.cdb` file) and also creates periodic **Weekly Saves** — snapshots taken at the start of each in-game week. If your career gets corrupted or you want to roll back to an earlier point, restoring a weekly save requires several manual steps:

1. Navigate to the Weekly Saves folder
2. Copy the desired `.cdb` file
3. Paste it into the active game database folder
4. Launch PCM and choose **Load Saved Game**, pointing it at the copied file

**PCM Weekly Save Copier** automates this into a single click.

---

## Features

- **Auto-detects** installed PCM versions by scanning `%APPDATA%` for `Pro Cycling Manager 20*` folders
- **Version selector** dropdown — switch between multiple installed PCM versions instantly
- **Auto-populates** source (Weekly Saves) and destination (Cloud/active DB) folder paths, including the Steam user ID subfolder
- **Persistent settings** — folder paths, selected version, and window size/position are saved and restored between sessions
- **Live file list** — auto-refreshes when new weekly saves appear (FileSystemWatcher)
- **Overwrite protection** — prompts for confirmation only if the destination file already exists
- **Folder browse** buttons — click the icon button beside either folder field to open a folder picker and set the path manually
- **Sortable columns** — click any column header to sort by file name, date, or size
- **Tooltips** on all controls

---

## Requirements

- Windows 10 or 11
- [.NET 10 Runtime](https://dotnet.microsoft.com/download/dotnet/10.0) (Desktop Runtime — Windows x64)
- Pro Cycling Manager (Steam), any version from 2023 onward

---

## How to Use

### 1. Launch the app

On first run, the app scans `%APPDATA%` and auto-fills:

| Field | Auto-detected path |
|-------|--------------------|
| **Source Folder** | `%APPDATA%\Pro Cycling Manager 20XX\WeeklySaves\<SteamID>` |
| **Destination Folder** | `%APPDATA%\Pro Cycling Manager 20XX\Cloud\<SteamID>` |

If multiple PCM versions are installed, use the **PCM Version** dropdown to switch between them.

If the auto-detected paths are wrong (e.g. non-standard install location), click the **folder icon button** at the right end of the Source or Destination field to open a folder picker and choose the correct folder manually. The file list refreshes immediately after a new source folder is selected.

### 2. Select a save to restore

The list shows all `.cdb` weekly save files in the source folder, sorted newest-first. Click any row to select it — the **New File Name** field will be pre-filled with a suggested filename.

### 3. Adjust the filename if needed

The **New File Name** field is editable. The file must end with `.cdb`. The COPY button activates once a valid name is entered.

### 4. Click COPY

The selected save is copied to the destination folder. If a file with that name already exists there, you will be prompted to confirm the overwrite.

### 5. Load in PCM

Launch Pro Cycling Manager and select **Load Saved Game** from the main menu. Navigate to the destination folder and select the file you just copied.

---

## Folder Paths Reference

| PCM Version | Weekly Saves | Active Database |
|-------------|-------------|-----------------|
| PCM 2025 | `%APPDATA%\Pro Cycling Manager 2025\WeeklySaves\<SteamID>` | `%APPDATA%\Pro Cycling Manager 2025\Cloud\<SteamID>` |
| PCM 2024 | `%APPDATA%\Pro Cycling Manager 2024\WeeklySaves\<SteamID>` | `%APPDATA%\Pro Cycling Manager 2024\Cloud\<SteamID>` |

`<SteamID>` is your 17-digit Steam user ID. The app discovers this automatically by scanning the subfolder structure.

---

## Settings

User preferences are saved automatically on exit to:

```
%APPDATA%\PCM-WeeklySaveCopier\settings.json
```

This file stores the last-used source folder, destination folder, selected PCM version, and window size/position. Delete it to reset all settings to auto-detected defaults.

---

## Building from Source

Requires the [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0).

```bash
git clone <repo-url>
cd PCM-WeeklySaveCopier
dotnet build
dotnet run
```

---

## Version History

| Version | Changes |
|---------|---------|
| **3.0** | Auto PCM version detection; version selector dropdown; FileSystemWatcher auto-refresh; open-in-Explorer buttons; persistent settings (paths + window state); Segoe MDL2 icon buttons; tooltips; overwrite confirmation; .NET 10 upgrade; modern Fluent-inspired UI |
| **2.x** | Basic copy utility with hardcoded paths |
