# NoteTimer
C# console app to add chapters to a mkv video using MKVToolnix.

# Important
To finish writing chapter names write `0` and hit enter


### Use scenario
1. Open app
2. Start recording lecture
3. Hit enter on subject of your choice from the menu
4. At any time write what lecturer is talking about and hit enter
5. Finish recording
6. Write `0` in the console
7. Your recording should be copied and enhanced with chapters and their names.
8. Exit console app

# Requirements
There are a few things that need to be done before launching the app.

## NET Core 3.1
To build you need to download and install [NET Core 3.1 SDK](https://dotnet.microsoft.com/download)

## Subject list
Create `subjcets.txt` with and fill it with subjects names each in new line

## MKVToolnix
This Program requires and works with [mkvmerge](https://mkvtoolnix.download/downloads.html). For windows you can use [Chocolatey package manager](https://chocolatey.org). It is required that mkvmerge is installed in: `C:\\Program Files\\MKVToolNix\\mkvmerge.exe`

## File location and naming
It is recommended to build app as single `.exe` file i.e. `dotnet publish -r win-x64 -c Release /p:PublishSingleFile=true` as it can be easily copied to directory with video files.
The video file that you want to enchance with chapters must be in `.mkv` format and its name must be in a `yyyy-mm-dd hh` date format i.e.
> 2020-10-02 16.mkv

