Occlusion Area (Pro Only)
=========================


To apply occlusion culling to moving objects you have to create an <span class=keyword>Occlusion Area</span> and then modify its size to fit the space where the moving objects will be located (of course the moving objects cannot be marked as static). You can create Occlusion Areas is by adding the <span class=component>Occlusion Area</span> component to an empty game object (<span class=menu>Component->Rendering->Occlusion Area</span> in the menus)

After creating the <span class=keyword>Occlusion Area</span>, just check the _Is Target Volume_ checkbox to occlude moving objects. 


![](http://docwiki.hq.unity3d.com/uploads/Main/OcclusionCullingOcclusionArea.png)  
_Occlusion Area properties for moving objects._


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Size</span> |Defines the size of the Occlusion Area.|
|<span class=component>Center</span> |Sets the center of the Occlusion Area. By default this is 0,0,0 and is located in the center of the box.|
|<span class=component>Is View Volume</span> |Defines where the camera can be. Check this in order to occlude static objects that are inside this _Occlusion Area_.|
|<span class=component>Is Target Volume</span> |__Select this when you want to occlude moving objects.__|
|<span class=component>Target Resolution</span> |Determines how accurate the occlusion culling inside the area will be. This affects the size of the cells in an Occlusion Area. __NOTE: This only affects Target Areas.__ |
|>>><span class=component>Low</span> |This takes less time to calculate but is less accurate.|
|>>><span class=component>Medium</span> |This gives a balance between accuracy and time taken to process the occlusion culling data.|
|>>><span class=component>High</span> |This takes longer to calculate but has better accuracy.|
|>>><span class=component>Very High</span> |Use this value when you want to have more accuracy than high resolutions, be aware it takes more time.|
|>>><span class=component>Extremely High</span> |Use this value when you want to have almost exact occlusion culling on your moveable objects. Note: This setting takes a lot of time to calculate.|


After you have added the Occlusion Area, you need to see how it divides the box into cells. To see how the occlusion area will be calculated, Select <span class=menu>Edit</span> and toggle the <span class=menu>View</span> button 
in the <span class=keyword>Occlusion Culling Preview Panel</span>. 


![](http://docwiki.hq.unity3d.com/uploads/Main/OcclusionCullingEditView.png)  

Testing the generated occlusion
-------------------------------


After your occlusion is set up, you can test it by enabling the _Occlusion Culling_ (in the <span class=keyword>Occlusion Culling Preview Panel</span> in Visualize mode) and moving the <span class=keyword>Main Camera</span> around in the scene view.


![](http://docwiki.hq.unity3d.com/uploads/Main/OcclusionCullingVisualize.png)  
_The Occlusion View mode in Scene View_

As you move the Main Camera around (whether or not you are in Play mode), you'll see various objects disable themselves.  The thing you are looking for here is any error in the occlusion data.  You'll recognize an error if you see objects suddenly popping into view as you move around.  If this happens, your options for fixing the error are either to change the resolution (if you are playing with target volumes) or to move objects around to cover up the error.  To debug problems with occlusion, you can move the Main Camera to the problematic position for spot-checking.


When the processing is done, you should see some colorful cubes in the View Area. The blue cubes represent the cell divisions for <span class=keyword>Target Volumes</span>. The white cubes represent cell divisions for <span class=keyword>View Volumes</span>. If the parameters were set correctly you should see some objects not being rendered. This will be because they are either outside of the view frustum of the camera or else occluded from view by other objects.

After occlusion is completed, if you don't see anything being occluded in your scene then try breaking your objects into smaller pieces so they can be completely contained inside the cells.
