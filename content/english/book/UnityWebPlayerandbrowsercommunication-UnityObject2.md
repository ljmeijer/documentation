Unity Web Player and browser communication with UnityObject2
============================================================


For the most part, browser communication is done the same way as [UnityObject](UnityWebPlayerandbrowsercommunication.md). However, calling Unity web player content functions from a webpage, is done in the following way:

````

<script type="text/javascript" language="javascript">
<!--
//initializing the WebPlayer
var u = new UnityObject2();
u.initPlugin(jQuery("#unityPlayer")[0], "Example.unity3d");

function SaySomethingToUnity()
{
	u.getUnity().SendMessage("MyObject", "MyFunction", "Hello from a web page!");
}
-->
</script>

````

