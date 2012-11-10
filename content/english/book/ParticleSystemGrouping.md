Particle Effects (Shuriken)
===========================


An important feature of Unity's Particle System is that individual Particle Systems can be grouped by being parented to the same root. We will use the term <span class=keyword>Paricle Effect</span> for such a group. Particle Systems belonging to the same Particle Effect, are played, stopped and paused together.

For managing complex particle effects, Unity provides a Particle Editor, which can be accessed from the [Inspector](ParticleSystemInspector.md), by pressing <span class=menu>Open Editor</span> 

![](http://docwiki.hq.unity3d.com/uploads/Main/ShurikenParticleEditor.png)  
_Overview of the <span class=keyword>Particle System Editor</span>_

You can toggle between <span class=menu>Show: All</span> and <span class=menu>Show: Selected</span> in this Editor. <span class=menu>Show: All</span> will render the entire particle effect. <span class=menu>Show: Selected</span> will only render the selected particle systems. What is selected will be highlighted with a blue frame in the Particle Editor and also shown in blue in the Hierarchy view. You can also change the selection both from the Hierarchy View and the Particle Editor, by clicking the icon in the top-left corner of the Particle System. To do a multiselect, use Ctrl+click on windows and Command+click on the Mac. 

You can explicitly control rendering order of grouped particles (or otherwise spatially close particle emitters) by tweaking <span class=component>Sorting Fudge</span> property in the [ParticleSystemModules#RendererModule|<span class=component>Renderer</span> module](ParticleSystemModules#RendererModule|<span class=component>Renderer</span>module.md). 



![](http://docwiki.hq.unity3d.com/uploads/Main/ShurikenOverviewHierarchy.png)  
_Particle Systems in the same hierarchy are considered as part of the same Particle Effect. This hierarchy shows the setup of the effect shown above. _

