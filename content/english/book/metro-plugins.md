Metro : Plugins
===============


You cannot use Metro specific plugins if you use Metro API like this [http://msdn.microsoft.com/en-us/library/windows/apps/br211377.aspx](http://msdn.microsoft.com/en-us/library/windows/apps/br211377.aspx.md) in Unity Editor, so we changed a bit how Unity Editor handles them. So basically you make two versions of plugins:
* One for Unity Editor,
* The other one for Metro runtime.

Both of them must share the same name. For example, you should place Editor compatible plugin in Assets\Plugins\MyPlugin.dll, and Metro specific plugin in Assets\Plugins\Metro\MyPlugin.dll. When you're working in Editor Assets\Plugins\MyPlugin.dll, and when you're building to Metro Assets\Plugins\Metro\MyPlugin.dll will copied over.           


