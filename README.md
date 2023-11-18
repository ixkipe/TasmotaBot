# TasmotaBot

> A Telegram Bot for managing Tasmota devices over MQTT

## Getting Started

TasmotaBot is intended to be deployed in Linux environments, since it uses `systemd` to run as a background service.

### Prerequisites

You will need:

* A Linux machine with [ASP.NET Core 6 runtime](https://learn.microsoft.com/en-us/dotnet/core/install/linux) installed
* A [Mosquitto](https://github.com/eclipse/mosquitto) server that allows anonymous connections.  
Authorization support may be added in later versions.
* At least one Wi-Fi relay flashed with [Tasmota](https://github.com/arendst/Tasmota)
* A Telegram bot with power toggle and power state commands for each device. [More info here](https://t.me/BotFather)

### Installation

1. Download the package that corresponds to the architecture of your Linux machine.
2. [Configure](#configuration) the application using `appsettings.yml`.
3. Create a `.service` file:  
``` bash
sudo vim /etc/systemd/system/tasmota-bot.service
```  
You can use [this gist](https://gist.github.com/ixkipe/1ff1083aa1968264e85cf43d1ada1c69) or make your own service file.  
[This article](https://swimburger.net/blog/dotnet/how-to-run-a-dotnet-core-console-app-as-a-service-using-systemd-on-linux) explains how to create a `systemd` file for a .NET application in great detail.  
Don't forget to set ownership for all application files in the directory to yourself:
``` bash
sudo chown $USER /path/to/application
```
4. Run the app:  
``` bash
sudo systemctl enable tasmota-bot.service && sudo systemctl start tasmota-bot.service
```

## Configuration

This section will walk you through the process of configuring your bot.  

1. Create an `appsettings.yml` file in the application directory.  
You can find the default suggested setup in [`appsettings_template.yml`](https://github.com/ixkipe/TasmotaBot/blob/main/appsettings_template.yml)
2. Provide a host name or an IP address for your Mosquitto server in `MqttInfo:Server`.
3. List the devices connected to your Mosquitto server that you wish to control in `MqttInfo:Devices`.  
The list must be in the object array format; each object bust have the following properties:
    * `Name` - The name of the device that will be used by the bot to refer to it in chat messages.
    * `Topic` - A unique topic for the device.
    * `TelegramCommands` - Commands sent through Telegram chats responsible for toggling the power of the device (`TogglePower`) and showing current power state of the device (`Status`).  
    For instance, if the device controls your kitchen light, you must have two respective commands for turning on/off the device (e.g. `/kitchenlight_toggle`) and requesting the status (e.g. `/kitchenlight_status`).  
    These commands should be declared using BotFather.
4. Provide the authentication token for your Telegram bot in `Telegram:BotToken`.
5. List the IDs of the users who are permitted to use the bot in `Telegram:AllowedIds`.