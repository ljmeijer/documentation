Example: Browser JavaScript Communication
=========================================


This example shows how AS3 code can communicate JavaScript in the browser. This example makes use of the [ExternalInterface](http://help.adobe.com/en_US/FlashPlatform/reference/actionscript/3/flash/external/ExternalInterface.html.md) ActionScript class.

When run, the BrowserCommunicator.TestCommunication() function will register a callback that the browser JavaScript can then call. The ActionScript will then call out to the browser JavaScript, causing an alert popup to be displayed. The exposed ActionScript function will then be invoked by the JavaScript, completing the two-way communication test.

  

Required JavaScript
-------------------

The following JavaScript needs to be added to the html page that serves the Unity published SWF. It creates the function which will be called from ActionScript: 

````

<script type="text/javascript">

function calledFromActionScript()
{
    alert("ActionScript called Javascript function")

    var obj = swfobject.getObjectById("unityPlayer");
    if (obj)
    {
        obj.callFromJavascript();
    }
}

</script> 

````

  

BrowserCommunicator.as (and matching C# class)
----------------------------------------------


````

package
{
    import flash.external.ExternalInterface;
    import flash.system.Security;
  
    public class BrowserCommunicator
    {
        //Exposed so that it can be called from the browser JavaScript.
        public static function callFromJavascript() : void
        {
            trace("Javascript successfully called ActionScript function.");
        }
    
        //Sets up an ExternalInterface callback and calls a Javascript function.
        public static function TestCommunication() : void
        {
            if (ExternalInterface.available)
            {
                try
                {
                    ExternalInterface.addCallback("callFromJavascript", callFromJavascript);
                }
                catch (error:SecurityError)
                {
                    trace("A SecurityError occurred: " + error.message);
                }
                catch (error:Error)
                {
                    trace("An Error occurred: " + error.message);
                }
        
                ExternalInterface.call('calledFromActionScript');
            }
            else
            {
                trace("External interface not available");
            }
        } 
    }
}

````


C# dummy implementation of the class:

````

[NotConverted]
[NotRenamed]
public class BrowserCommunicator
{
   [NotRenamed]
   public static void TestCommunication()
   {
   }
}

````

  

How to test
-----------


Simply call BrowserCommunicator.TestCommunication() and this will invoke the two-way communication test.

  


Potential Issues
----------------


###Security Sandbox Violation

_A SecurityError occurred: Error #2060: Security sandbox violation_

This happens when your published SWF does not have permission to access your html file. To fix this locally, you can either:
* Add the folder containing the SWF to the Flash Player's trusted locations in the [Global Security Settings Panel](http://www.macromedia.com/support/documentation/en/flashplayer/help/settings_manager04.html.md).
* Host the file on localhost.

For more information on the Flash Security Sandboxes, please refer to the Adobe [documentation](http://livedocs.adobe.com/flex/3/html/help.html?content=05B_Security_04.html.md).
