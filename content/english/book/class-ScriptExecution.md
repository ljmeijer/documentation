Script Execution Order Settings
===============================


By default, the Awake, OnEnable and Update functions of different scripts are called in the order the scripts are loaded (which is arbitrary). However, it is possible to modify this order using the <span class=keyword>Script Execution Order</span> settings.


![](http://docwiki.hq.unity3d.com/uploads/Main/ScriptExecSet.png)  

Scripts can be added to the inspector using the Plus "+" button and dragged to change their relative order. Note that it is possible to drag a script either above or below the <span class=component>Default Time</span> bar; those above will execute ahead of the default time while those below will execute after. The ordering of scripts in the dialog from top to bottom determines their execution order. All scripts not in the dialog execute in the default time slot in arbitrary order.
