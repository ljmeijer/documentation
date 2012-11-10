Particle System (Shuriken)
==========================


Particle Systems in Unity are used to make clouds of smoke, steam, fire and other atmospheric effects. 


![](http://docwiki.hq.unity3d.com/uploads/Main/ShurikenFrontPageFlare.png)  

You can create a new particle system by creating a <span class=component>Particle System</span> GameObject (menu <span class=menu>GameObject</span> -> <span class=menu>Create Other</span> -> <span class=menu>Particle System</span>) or by creating an empty <span class=component>GameObject</span> and adding the <span class=component>ParticleSystem</span> component to it (in <span class=menu>Component</span>-><span class=menu>Effects</span>)

(:include ParticleSystemInspector:)

Scene View Editing
------------------

When creating and editing Particle Systems, you either work with the <span class=menu>Inspector</span> or the extended <span class=menu>Particle Editor</span>, and your changes are reflected in the <span class=menu>SceneView</span>. The scene view has a <span class=menu>Preview Panel</span>, where playback of the currently selected <span class=menu>Particle Effect</span> can be controlled in Edit Mode, with actions like <span class=menu>play</span>, <span class=menu>pause</span>, <span class=menu>stop</span> and <span class=menu>scrubbing playback time</span>


![](http://docwiki.hq.unity3d.com/uploads/Main/ShurikenPreviewPanel.png)  

Scrubbing play back time can be performed by dragging on the label _Playback Time_. All Playback controls have shortcut keys which can be customized in the [Preferences window](Preferences.md)

(:include ParticleSystemCurveEditor:) 
(:include ParticleSystemColorEditor:)
