# ProjectZ

This is the source code for ProjectZ, and *only* the source code -- assets (sprite sheets, sound effects etc.) must be provided by the user. The project builds with MonoGame 3.8.1.303, which is newer than the version ProjectZ 1.0.0 originally shipped with.

Unlike the 1.0.0 version of ProjectZ, this repo will *not* publish as a single executable file, which appears to be an unsupported build configuration in MonoGame 3.8.1.303. This means the .NET assemblies ProjectZ uses will be included in builds.

## Requirements

* .NET 6
* Visual Studio 2022
* MonoGame 3.8.1.303 (does not support versions of Visual Studio earlier than 2022)
* The original source archive, which includes all binary assets used by the game (sprite sheets, sound effects, music in Game Boy Sound format) and the English language script. `source.7z md5: 4871f9fce7ae06d14aedbb33a88b18a8`

## Build Instructions

* Clone repo somewhere.
* Extract the original source archive (`source.7z md5: 4871f9fce7ae06d14aedbb33a88b18a8`) to the Source folder. The folder should contain a ProjectZ folder.
* Building from Visual Studio 2022 will copy assets from the Source folder to the Content and Data folders automatically.