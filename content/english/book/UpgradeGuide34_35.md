Unity 3.5 upgrade guide
=======================


If you have an FBX file with a root node marked up as a skeleton, it will be imported with an additional root node in 3.5, compared to 3.4 


![](http://docwiki.hq.unity3d.com/uploads/Main/upgrade35hierarchy.png)  

Unity 3.5 does this because when importing animated characters, the most common setup is to have one root node with all bones below and a skeleton next to it in the hierarchy.  
When creating additional animations, it is common to remove the skinned mesh from the fbx file. In that case the new import method ensures that the additional root node always exists and thus animations and the skinned mesh actually match. 

If the connection between the instance and the FBX file's prefab has been broken in 3.4 the animation will not match in 3.5, and as a result your animation might not play.

In that case it is recommended that you recreate the prefabs or Game Object hierarchies by dragging your FBX file into your scene and recreating it.


