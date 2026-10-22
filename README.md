# Vagrant Story Archipelago Client

## Requirements
To play Vagrant Story on archipelago requires:

- A Windows or macOS machine
- [Archipelago](https://archipelago.gg) installed
- The latest copy of [the Vagrant Story client](https://github.com/riezahughes/VagrantStoryAPClient/releases)
- The latest copy of [the Vagrant Story AP World](https://github.com/riezahughes/VagrantStoryAPWorld/releases)
- A legal copy of the NTSC-U (US) Version of Vagrant Story (`SLUS-01040`)
- [Duckstation](https://www.duckstation.org)

# Setup

- Install the APWorld in Archipelago
- Generate the templates
- Copy and paste a copy of the Vagrant Story template into the `players` folder of your archipelago install. If it doesn't exist, make it.
- Edit the yaml however you like, but you might want to change the slot name
- Generate the game
- Host the game using the zip that's generated in your `output` folder of your archipelago install (either on your own server, locally or on [the archipelagos website](https://archipelago.gg/uploads) )
- Boot up the game in duckstation.
- Run the client (macOS users: see [Running on macOS](#running-on-macos) below)
- Fill in the blanks to connect to the server
- Start playing!

# Running on macOS

## Which download?

From the [releases page](https://github.com/riezahughes/VagrantStoryAPClient/releases), grab the zip for your Mac:

- `VagrantStoryArchipelago_<version>_osx-arm64.zip` for Apple Silicon Macs (M1, M2, M3, M4...)
- `VagrantStoryArchipelago_<version>_osx-x64.zip` for older Intel Macs

Not sure which you have? Click the Apple menu > **About This Mac** and look at "Chip" (Apple M-something = arm64) or "Processor" (Intel = x64).

## First launch

1. Unzip the download. Keep `VagrantStoryArchipelago` and `libcimgui.dylib` together in the same folder.
2. macOS blocks apps from unidentified developers the first time you open them. To get past this, **right-click** (or Control-click) `VagrantStoryArchipelago` and choose **Open**, then **Open** again on the warning.
   - If macOS only offers "Move to Bin" / "Done", go to **System Settings > Privacy & Security**, scroll down, and click **Open Anyway** next to the VagrantStoryArchipelago message.
   - Alternatively, run this once in Terminal from the unzipped folder: `xattr -d com.apple.quarantine VagrantStoryArchipelago`
3. After the first time, you can just double-click it.

## Running the client

1. Start DuckStation and boot Vagrant Story. If you open the client first, it will wait and keep checking until DuckStation is running.
2. Double-click `VagrantStoryArchipelago`. A Terminal window will open.
3. **Enter your Mac password** when asked. macOS only lets programs with administrator access read another app's memory, which the client needs to see what's happening in DuckStation. Nothing appears as you type, that's normal. Press Enter when done.
4. **Enter the DuckStation memory address.** On macOS the client can't find this by itself:
   1. In DuckStation, open **Tools > Memory Scanner**.
   2. In the bottom right, find the line `Address of RAM for HxD Usage: 0x000000011c400000` (your number will be different).
   3. Copy the `0x...` address (or the whole line) and paste it into the client, then press Enter.
5. Fill in the server, port, slot name and password as normal and start playing!

> The memory address can change when DuckStation is restarted, so grab it fresh each session.

## Troubleshooting

- **"zsh: killed" or the window closes instantly**: the download may have been damaged or blocked. Re-download the zip and follow the first launch steps again.
- **Sorry, try again**: the password was wrong. Use the password you log in to your Mac with.
- **Not an administrator**: your macOS user account must be an admin account to run the client.
- **"Could not find Duckstation open" keeps repeating**: make sure DuckStation is actually running. The client checks again every 5 seconds.

# Development
- Clone the repository
- Create an appsettings.Local.json in the root of the project
- Create an AP room on the archipelago website and fill the file with the following content:

```json
{
    "port": "portnumber",
    "slot": "slotname",
    "pass": "passifused"
}

```

- Running debug will now automatically connect you to the room on archipelago.gg without the need of you filling in the fields
