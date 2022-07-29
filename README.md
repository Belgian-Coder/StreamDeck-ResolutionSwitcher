# StreamDeck-ResolutionSwitcher
Plugin for Stream Deck to change resolution on the fly

## Why this plugin?
Teamwork often means sharing ideas and knowledge. Now that remote work is growing in popularity, sharing my screen has become one of my new daily routines. Ofcourse all popular streaming programs struggle to stream my screen at the native resolution of 5120x2160 pixels. Some people work at much smaller resolutions what complicates the matter of sharing text/code/... After using the Windows magnifier for a while, I started changing the of my primary screen before sharing. People loved this change and communication became a lot easier this way. Unfortunately, the process of going to my screen settings, selecting my screen, changing my resolution and acknowledging the change was too slow in my opinion.
Everybody pointed out that you could use an existing application to change this, and it worked great! This was of course on my personal computer, to use it on my business computer, a license of 499 USD was required. I do not shy away from buying software to support their hard work, but the price was just too high for a quick resolution change.
I was already looking for a reason to create a plugin for my newly acquired Stream Deck, so an excuse at last! After a few hours of research, I collected enough resources and knowledge to create my custom plugin.

## Technologies
A lot of my background is related to the Microsoft ecosystem. I developed in a lot of different languages, but C# still is my favorite language. The official development documentation of Elgato, the company behind the Stream Deck, only mentioned JavaScript and Objective-C support. From past experiences, I already knew I didn’t like Objective-C and the JavaScript option left me with a lot of questions what the supported features were. 
[BarRaider streamdeck-tools](https://github.com/BarRaider/streamdeck-tools) to the rescue! Someone already did the hard work on setting up the communication protocols and had written a framework around it. It’s not the new and shiny .NET (Core) but it gets the job done.

## Project setup
You will find a few different things in this repository:
-	ResolutionSwitcher.Shared => .NET Standard 2.0 shared library that will abstract the most important calls as well as the SetDpi and Windows native User32 dll’s.
-	ResolutionSwitcher.StreamDeck => .NET 4.7.2 console application that contains the template created by BarRaider for easily creating your custom actions.
-	ResolutionSwitcherApplication => .NET 6.0 console application used to create an executable and use this functionality stand-alone without a Stream Deck.
-	SetDpi => C++ library that interfaces with the badly documented windows scale functionality. You can find the GitHub project in this readme under resources.
-	DistributionTool.exe => application from Elgato to package your code into their own installable container.
-	Create-Package.ps1 => PowerShell script to use the DistributionTool and package the output of ResolutionSwitcher.StreamDeck. The output is saved in the `Release` folder with filename `be.belgiancoder.resolutionswitcher.streamDeckPlugin`. You can install the plugin by double clicking on it.
*Important!*
If you are getting `BadImage Exception` check that all projects are set to build only a x86 version. 

## Resources
- [BarRaider streamdeck-tools](https://github.com/BarRaider/streamdeck-tools) - Stream Deck plugin template
- [SetDpi](https://github.com/imniko/SetDPI) - Code for Windows scaling
- [Codeproject - Changing Display Settings Programmatically](https://www.codeproject.com/Articles/36664/Changing-Display-Settings-Programmatically) - Code for switching resolution
- [SVG Repo](https://www.svgrepo.com/) - Icon resource
