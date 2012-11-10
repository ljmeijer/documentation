How to view a log from Wii?
===========================


The information is also available here - [ https://www.warioworld.com/wii/techupdates/etc.asp. ](https://www.warioworld.com/wii/techupdates/etc.asp..md)

In short:
* Download TeraTermPro.
* Configure it:
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

__Note: You can also view the log if you're running with CWAutomation.exe, but only one must be active at the time, either TeraTermPro or CWAutomation.exe.__
