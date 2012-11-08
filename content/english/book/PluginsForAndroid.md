Building Plugins for Android
============================


This page describes [Native Code Plugins](Plugins.md) for Android.

Building a Plugin for Android
-----------------------------


To build a plugin for Android, you should first obtain the [Android NDK](http://developer.android.com/sdk/ndk.md) and familiarize yourself with the steps involved in building a shared library.

If you are using C++ (.cpp) to implement the plugin you must ensure the functions are declared with C linkage to avoid [name mangling issues](http://en.wikipedia.org/wiki/Name_mangling.md).

````
extern "C" {
  float FooPluginFunction ();
} 
````

Using Your Plugin from C#
-------------------------


Once built, the shared library should be copied to the <span class=menu>Assets->Plugins->Android</span> folder. Unity will then find it by name when you define a function like the following in the C# script:-

````
[DllImport ("PluginName")]
private static extern float FooPluginFunction (); 
````

Please note that <span class=component>PluginName</span> should not include the prefix ('lib') nor the extension ('.so') of the filename.
It is advisable to wrap all native code methods with an additional C# code layer. This code should check [Application.platform](ScriptRef:Application-platform.html) and call native methods only when the app is running on the actual device; dummy values can be returned from the C# code when running in the Editor. You can also use [platform defines](http://docwiki.unity3d.com/index.php?n=Main.PlatformDependentCompilation.md) to control platform dependent code compilation.

Deployment
----------


For cross platform deployment, your project should include plugins for each supported platform (ie, libPlugin.so for Android, Plugin.bundle for Mac and Plugin.dll for Windows).
Unity automatically picks the right plugin for the target platform and includes it with the player.

Using Java Plugins
------------------


The Android plugin mechanism also allows Java to be used to enable interaction with the Android OS.

###Building a Java Plugin for Android
There are several ways to create a Java plugin but the result in each case is that you end up with a .jar file containing the .class files for your plugin.
One approach is to download the [JDK ](http://www.oracle.com/technetwork/java/javase/downloads/index.html.md), then compile your .java files from the command line with _javac_. This will create .class files which you can then package into a .jar with the _jar_ command line tool.
Another option is to use the [Eclipse ](http://www.eclipse.org.md) IDE together with the [ADT ](http://developer.android.com/sdk/eclipse-adt.html.md).

###Using Your Java Plugin from Native Code

Once you have built your Java plugin (.jar) you should copy it to the <span class=menu>Assets->Plugins->Android</span> folder in the Unity project. Unity will package your .class files together with the rest of the Java code and then access the code using the [Java Native Interface (JNI) ](http://en.wikipedia.org/wiki/Java_Native_Interface.md). JNI is used both when calling native code from Java and when interacting with Java (or the JavaVM) from native code.

To find your Java code from the native side you need access to the Java VM. Fortunately, that access can be obtained easily by adding a function like this to your C/C++ code:

````
jint JNI_OnLoad(JavaVM* vm, void* reserved) {
  JNIEnv* jni_env = 0;
  vm->AttachCurrentThread(&jni_env, 0);
} 
````

This is all that is needed to start using Java from C/C++. It is beyond the scope of this document to explain JNI completely. However, using it usually involves finding the class definition, resolving the constructor (<init>) method and creating a new object instance, as shown in this example:-

````
jobject createJavaObject(JNIEnv* jni_env) {
  jclass cls_JavaClass = jni_env->FindClass("com/your/java/Class");			// find class definition
  jmethodID mid_JavaClass = jni_env->GetMethodID (cls_JavaClass, "<init>",  "()V");		// find constructor method
  jobject obj_JavaClass = jni_env->NewObject(cls_JavaClass, mid_JavaClass);		// create object instance
  return jni_env->NewGlobalRef(obj_JavaClass);						// return object with a global reference
} 
````

###Using Your Java Plugin with helper classes
<span class=keyword>AndroidJNIHelper</span> and <span class=keyword>AndroidJNI</span> can be used to ease some of the pain with raw JNI. 

<span class=keyword>AndroidJavaObject</span> and <span class=keyword>AndroidJavaClass</span> automate a lot of tasks and also use cacheing to make calls to Java faster. The combination of <span class=keyword>AndroidJavaObject</span> and <span class=keyword>AndroidJavaClass</span> builds on top of <span class=keyword>AndroidJNI</span> and <span class=keyword>AndroidJNIHelper</span>, but also has a lot of logic in its own right (to handle the automation). These classes also come in a 'static' version to access static members of Java classes. 

You can choose whichever approach you prefer, be it raw JNI through <span class=keyword>AndroidJNI</span> class methods, or <span class=keyword>AndroidJNIHelper</span> together with <span class=keyword>AndroidJNI</span> and eventually <span class=keyword>AndroidJavaObject/AndroidJavaClass</span> for maximum automation and convenience.

[UnityEngine.AndroidJNI](ScriptRef:AndroidJNI.html) is a wrapper for the JNI calls available in C (as described above). All methods in this class are static and have a 1:1 mapping to the Java Native Interface. [UnityEngine.AndroidJNIHelper](ScriptRef:AndroidJNIHelper.html) provides helper functionality used by the next level, but is exposed as public methods because they may be useful for some special cases.

Instances of [UnityEngine.AndroidJavaObject](ScriptRef:AndroidJavaObject.html) and [UnityEngine.AndroidJavaClass](ScriptRef:AndroidJavaClass.html) have a 1:1 mapping to an instance of java.lang.Object and java.lang.Class (or subclasses thereof) on the Java side, respectively. They essentially provide 3 types of interaction with the Java side: 
    * Call a method
    * Get the value of a field
    * Set the value of a field

The <span class=keyword>Call</span> is separated into two categories: <span class=keyword>Call</span> to a 'void' method, and <span class=keyword>Call</span> to a method with non-void return type. A generic type is used to represent the return type of those methods which return a non-void type. The <span class=keyword>Get</span> and <span class=keyword>Set</span> always take a generic type representing the field type. 

###Example 1

````

//The comments describe what you would need to do if you were using raw JNI
 AndroidJavaObject jo = new AndroidJavaObject("java.lang.String", "some_string"); 
 // jni.FindClass("java.lang.String"); 
 // jni.GetMethodID(classID, "<init>", "(Ljava/lang/String;)V"); 
 // jni.NewStringUTF("some_string"); 
 // jni.NewObject(classID, methodID, javaString); 
 int hash = jo.Call<int>("hashCode"); 
 // jni.GetMethodID(classID, "hashCode", "()I"); 
 // jni.CallIntMethod(objectID, methodID);

````

Here, we're creating an instance of [java.lang.String](http://developer.android.com/reference/java/lang/String.html.md), initialized with a [string](http://developer.android.com/reference/java/lang/String.html#String(java.lang.StringBuilder).md) of our choice and retrieving the [hash value](http://developer.android.com/reference/java/lang/String.html#hashCode().md) for 
that string.

The <span class=keyword>AndroidJavaObject</span> constructor takes at least one parameter, the name of class for which we want to construct an instance. Any parameters after the class name are for the constructor call on the object, in this case the string "some_string". The subsequent <span class=keyword>Call</span> to hashCode() returns an 'int' which is why we use that as the generic type parameter to the <span class=keyword>Call</span> method.

__Note:__ You cannot instantiate a nested Java class using dotted notation. Inner classes must use the $ separator, and it should work in both dotted and slashed format. So <span class=keyword>android.view.ViewGroup$LayoutParams</span> or <span class=keyword>android/view/ViewGroup$LayoutParams</span> can be used, where a <span class=keyword>LayoutParams</span> class is nested in a <span class=keyword>ViewGroup</span> class.

###Example 2
One of the plugin samples above shows how to get the cache directory for the current application. This is how you would do the same thing from C# without any plugins:-

````

 AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer"); 
 // jni.FindClass("com.unity3d.player.UnityPlayer"); 
 AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity"); 
 // jni.GetStaticFieldID(classID, "Ljava/lang/Object;"); 
 // jni.GetStaticObjectField(classID, fieldID); 
 // jni.FindClass("java.lang.Object"); 

 Debug.Log(jo.Call<AndroidJavaObject>("getCacheDir").Call<string>("getCanonicalPath")); 
 // jni.GetMethodID(classID, "getCacheDir", "()Ljava/io/File;"); // or any baseclass thereof! 
 // jni.CallObjectMethod(objectID, methodID); 
 // jni.FindClass("java.io.File"); 
 // jni.GetMethodID(classID, "getCanonicalPath", "()Ljava/lang/String;"); 
 // jni.CallObjectMethod(objectID, methodID); 
 // jni.GetStringUTFChars(javaString);

````

In this case, we start with <span class=keyword>AndroidJavaClass</span> instead of <span class=keyword>AndroidJavaObject</span> because we want to access a static member of <span class=keyword>com.unity3d.player.UnityPlayer</span> rather than create a new object (an instance is created automatically by the <span class=keyword>Android UnityPlayer</span>). Then we access the static field "currentActivity" but this time we use <span class=keyword>AndroidJavaObject</span> as the generic parameter. This is because the actual field type ([android.app.Activity](http://developer.android.com/reference/android/app/Activity.html.md)) is a subclass of [java.lang.Object](http://developer.android.com/reference/java/lang/Object.html.md), and any [non-primitive type](http://developer.android.com/reference/java/lang/Class.html.md) must be accessed as <span class=keyword>AndroidJavaObject</span>. The exceptions to this rule are strings, which can be accessed directly even though they don't represent a primitive type in Java. 

After that it is just a matter of traversing the <span class=keyword>Activity</span> through [getCacheDir()](http://developer.android.com/reference/android/content/Context.html#getCacheDir().md) to get the File object representing the cache directory, and then calling [getCanonicalPath()](http://developer.android.com/reference/java/io/File.html#getCanonicalPath().md) to get a string representation. 

Of course, nowadays you don't need to do that to get the cache directory since Unity provides access to the application's cache and file directory with [Application.temporaryCachePath](ScriptRef:Application-temporaryCachePath.html) and [Application.persistentDataPath](ScriptRef:Application-persistentDataPath.html).

###Example 3
Finally, here is a trick for passing data from Java to script code using <span class=keyword>UnitySendMessage</span>.

````

using UnityEngine; 
public class NewBehaviourScript : MonoBehaviour { 

	void Start () { 
		JNIHelper.debug = true; 
		using (JavaClass jc = new JavaClass("com.unity3d.player.UnityPlayer")) { 
			jc.CallStatic("UnitySendMessage", "Main Camera", "JavaMessage", "whoowhoo"); 
		} 
	} 

	void JavaMessage(string message) { 
		Debug.Log("message from java: " + message); 
	}
} 

````

The Java class <span class=keyword>com.unity3d.player.UnityPlayer</span> now has a static method <span class=keyword>UnitySendMessage</span>, equivalent to the iOS [UnitySendMessage](Main.Plugins#iPhonePlugins.md) on 
the native side. It can be used in Java to pass data to script code. 

Here though, we call it directly from script code, which essentially relays the message on the Java side. This then calls back to the native/Unity code to deliver the message to the object named "Main Camera". This object has a script attached which contains a method called "JavaMessage". 

###Best practice when using Java plugins with Unity

As this section is mainly aimed at people who don't have comprehensive JNI, Java and Android experience, we assume that the <span class=keyword>AndroidJavaObject/AndroidJavaClass</span> approach has been used for interacting with Java code from Unity.

The first thing to note is that any operation you perform on an <span class=keyword>AndroidJavaObject</span> or <span class=keyword>AndroidJavaClass</span> is computationally expensive (as is the raw JNI approach). It is highly advisable to keep the number of transitions between managed and native/Java code to a minimum, for the sake of performance and also code clarity. 

You could have a Java method to do all the actual work and then use <span class=keyword>AndroidJavaObject / AndroidJavaClass</span> to communicate with that method and get the result. However, it is worth bearing in mind that the JNI helper classes try to cache as much data as possible to improve performance. 

````

//The first time you call a Java function like 
AndroidJavaObject jo = new AndroidJavaObject("java.lang.String", "some_string");  // somewhat expensive
int hash = jo.Call<int>("hashCode");  // first time - expensive
int hash = jo.Call<int>("hashCode");  // second time - not as expensive as we already know the java method and can call it directly

````

The Mono garbage collector should release all created instances of <span class=keyword>AndroidJavaObject</span> and <span class=keyword>AndroidJavaClass</span> after use, but it is advisable to keep them in a <span class=keyword>using(){}</span> statement to ensure they are deleted as soon as possible. Without this, you cannot be sure when they will be destroyed. If you set <span class=keyword>AndroidJNIHelper.debug</span> to true, you will see a record of the garbage collector's activity in the debug output.

````

//Getting the system language with the safe approach
void Start () { 
	using (AndroidJavaClass cls = new AndroidJavaClass("java.util.Locale")) { 
		using(AndroidJavaObject locale = cls.CallStatic<AndroidJavaObject>("getDefault")) { 
			Debug.Log("current lang = " + locale.Call<string>("getDisplayLanguage")); 

		} 
	} 
}

````

You can also call the <span class=keyword>.Dispose()</span> method directly to ensure there are no Java objects lingering. The actual C# object might live a bit longer, but will be garbage collected by mono eventually.


Extending the UnityPlayerActivity Java Code
-------------------------------------------

With Unity Android it is possible to extend the standard <span class=keyword>UnityPlayerActivity</span> class (the primary Java class for the Unity Player on Android, similar to AppController.mm on Unity iOS).

An application can override any and all of the basic interaction between Android OS and Unity Android. You can enable this by creating a new [Activity ](http://developer.android.com/reference/android/app/Activity.html.md) which derives from UnityPlayerActivity (UnityPlayerActivity.java can be found at <span class=menu>/Applications/Unity/Unity.app/Contents/PlaybackEngines/AndroidPlayer/src/com/unity3d/player</span> on Mac and usually at <span class=menu>C:\Program Files\Unity\Editor\Data\PlaybackEngines\AndroidPlayer\src\com\unity3d\player</span> on Windows). 

To do this, first locate the <span class=menu>classes.jar</span> shipped with Unity Android. It is found in the installation folder (usually <span class=menu>C:\Program Files\Unity\Editor\Data</span> (on Windows) or <span class=menu>/Applications/Unity</span> (on Mac)) in a sub-folder called <span class=menu>PlaybackEngines/AndroidPlayer/bin</span>. Then add  <span class=menu>classes.jar</span> to the classpath used to compile the new Activity. The resulting .class file(s) should be compressed into a .jar file and placed in the <span class=menu>Assets->Plugins->Android</span> folder.
Since the manifest dictates which activity to launch it is also necessary to create a new [AndroidManifest.xml ](http://developer.android.com/guide/topics/manifest/manifest-intro.html.md). The AndroidManifest.xml file should also be placed in the <span class=menu>Assets->Plugins->Android</span> folder.

The new activity could look like the following example, __OverrideExample.java__:
````
package com.company.product;

import com.unity3d.player.UnityPlayerActivity;

import android.os.Bundle;
import android.util.Log;

public class OverrideExample extends UnityPlayerActivity {

  protected void onCreate(Bundle savedInstanceState) {

    // call UnityPlayerActivity.onCreate()
    super.onCreate(savedInstanceState);

    // print debug message to logcat
    Log.d("OverrideActivity", "onCreate called!");
  }

  public void onBackPressed()
  {
    // instead of calling UnityPlayerActivity.onBackPressed() we just ignore the back button event
    // super.onBackPressed();
  }
} 
````

And this is what the corresponding __AndroidManifest.xml__ would look like:
````
<?xml version="1.0" encoding="utf-8"?>
<manifest xmlns:android="http://schemas.android.com/apk/res/android" package="com.company.product">
  <application android:icon="@drawable/app_icon" android:label="@string/app_name">
	<activity android:name=".OverrideExample"
			  android:label="@string/app_name"
			  android:configChanges="fontScale|keyboard|keyboardHidden|locale|mnc|mcc|navigation|orientation|screenLayout|screenSize|smallestScreenSize|uiMode|touchscreen">
        <intent-filter>
			<action android:name="android.intent.action.MAIN" />
			<category android:name="android.intent.category.LAUNCHER" />
		</intent-filter>
	</activity>
  </application>
</manifest> 
````

###UnityPlayerNativeActivity
It is also possible to create your own subclass of `UnityPlayerNativeActivity`. This will have much the same effect as subclassing UnityPlayerActivity but with improved input latency. Be aware, though, that NativeActivity was introduced in Gingerbread and does not work with older devices. Since touch/motion events are processed in native code, Java views would normally not see those events. There is, however, a forwarding mechanism in Unity which allows events to be propagated to the DalvikVM. To access this mechanism, you need to modify the manifest file as follows:-

````
<?xml version="1.0" encoding="utf-8"?>
<manifest xmlns:android="http://schemas.android.com/apk/res/android" package="com.company.product">
  <application android:icon="@drawable/app_icon" android:label="@string/app_name">
	<activity android:name=".OverrideExampleNative"
			  android:label="@string/app_name"
			  android:configChanges="fontScale|keyboard|keyboardHidden|locale|mnc|mcc|navigation|orientation|screenLayout|screenSize|smallestScreenSize|uiMode|touchscreen">
  <meta-data android:name="android.app.lib_name" android:value="unity" />
  <meta-data android:name="unityplayer.ForwardNativeEventsToDalvik" android:value="true" />
        <intent-filter>
			<action android:name="android.intent.action.MAIN" />
			<category android:name="android.intent.category.LAUNCHER" />
		</intent-filter>
	</activity>
  </application>
</manifest> 

````

Note the ".OverrideExampleNative" attribute in the activity element and the two additional meta-data elements. The first meta-data is an instruction to use the Unity library __libunity.so__. The second enables events to be passed on to your custom subclass of UnityPlayerNativeActivity.

Examples
--------



###Native Plugin Sample
A simple example of the use of a native code plugin can be found [here](Attach:AndroidNativePlugin.zip.md)

This sample demonstrates how C code can be invoked from a Unity Android application.
The package includes a scene which displays the sum of two values as calculated by the native plugin.
Please note that you will need the [Android NDK](http://developer.android.com/sdk/ndk/index.html.md) to compile the plugin.

###Java Plugin Sample
An example of the use of Java code can be found [here](Attach:AndroidJavaPlugin.zip.md)

This sample demonstrates how Java code can be used to interact with the Android OS and how C++ creates a bridge between C# and Java.
The scene in the package displays a button which when clicked fetches the application cache directory, as defined by the Android OS.
Please note that you will need both the JDK and the [Android NDK](http://developer.android.com/sdk/ndk/index.html.md) to compile the plugins.

[Here](Attach:AndroidJavaPluginProject.zip.md) is a similar example but based on a prebuilt JNI library to wrap the native code into C#.
