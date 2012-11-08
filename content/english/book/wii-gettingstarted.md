Wii: Getting Started
====================


###Developing for Wii
To develop for Wii you have to be a licensed Nintendo developer. Please visit http://www.warioworld.com for more information.

###Setup
Currently Unity Wii only works on Windows, it's possible to do development on Mac as well, but you won't be able to build a Wii player.
All install packages except cygwin can be found here - [Downloads](https://www.warioworld.com/wii/downloads/.md).
1. Install Cygwin, you can get it from http://www.cygwin.com/.
1. Install Revolution SDK.
1. Install WiiProfiler v3.0.
1. Install OpenSSL v0.9.8b-1 (needed for WiiWare).
1. Install NDEV Software and Device Drivers.
1. Install CodeWarrior for Wii.

Additional software
1. Install [[http://hp.vector.co.jp/authors/VA002416/ttermp23.zip|TeraTerm] (used for outputing the log), you can find additional information here https://www.warioworld.com/wii/techupdates/etc.asp.
1. Configure it:
    * Select 'Serial' connection
    * Setup->Terminal->Select 'CR+LF' for both Receive and Transmit.
    * Setup->SerialPort:
    * Select port COM1, COM2, COM3 or COM4 (To find out which, go to DeviceManager, find USB Serial Port, you should see the port there)
    * Set Baud Rate to 115200.
    * Data to 8 bit.
    * Parity to none.
    * Stop bits to 1.
    * Flow control to hardware.
    * Transmit delay to 0.
    * Don't forget to Setup->Save Setup.

And you should be ready to go.

It's also strongly recommended that you register to [Nintendo newsgroup](https://www.warioworld.com/information/news/.md), it's a great resource when finding answers to difficult questions.

###Build information
* SDK version: 3.3 + patch 2
* HomeButton version: 4.7.3
* Compiler version: 4.3 build 188

###Wii capabilities
* CPU - Broadway 729 MHz, Architecture - 32 Bit PowerPC.
    * 32 Kbyte 8-way set associative L1 instruction cache.
    * 32 Kbyte 8-way set associative L1 data cache (A data scratch pad of 16 Kbyte can be set).
    * 256 Kbyte 2-way set associative L2 cache.
* Graphics - Hollywood 3 MB of graphics memory (used for texture caching).
* Memory
    * MEM1 (internal memory) - 24 MB, the program executable is loaded here, so basically we have something like ~16 MB.
    * MEM2 (external memory, slower than MEM1) - 64 MB, about ~10 MB is used by system, so we have ~54 MB. On NDEV it can be expanded up to 128 Mb for debugging purposes.
* Controllers (supported by Unity Wii)
    * Up to four Wii remotes can be connected to Wii additionally various extensions can be plugged in:
        * Nunchuk
        * Classic Controller
        * Motion Plus
    * Wii Balance Board

###Pages
* [Latest builds](https://sites.google.com/a/unity3d.com/wii-group/.md)
* [Unity Wii group](http://groups.google.com/group/unity-wii-3x/.md)

###Further reading:
(:tocportion:)
