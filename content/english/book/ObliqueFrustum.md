Using an Oblique Frustum
========================


By default, the view frustum is arranged symmetrically around the camera's centre line but it doesn't necessarily need to be. The frustum can be made "oblique", which means that one side is at a smaller angle to the centre line than the opposite side. The effect is rather like taking a printed photograph and cutting one edge off. This makes the perspective on one side of the image seem more condensed giving the impression that the viewer is very close to the object visible at that edge. An example of how this can be used is a car racing game where the frustum might be flattened at its bottom edge. This would make the viewer seem closer to the road, accentuating the feeling of speed.


![](http://docwiki.hq.unity3d.com/uploads/Main/ObliqueFrustum.png)  

While the camera class doesn't have functions to set the obliqueness of the frustum, it can be done quite easily by altering the projection matrix:-
 
````
function SetObliqueness(horizObl: float, vertObl: float;) {
	var mat: Matrix4x4 = camera.projectionMatrix;
	mat[0, 2] = horizObl;
	mat[1, 2] = vertObl;
	camera.projectionMatrix = mat;
}
````

Mercifully, it is not necessary to understand how the projection matrix works to make use of this. The horizObl and vertObl values set the amount of horizontal and vertical obliqueness, respectively. A value of zero indicates no obliqueness. A positive value shifts the frustum rightwards or upwards, thereby flattening the left or bottom side. A negative value shifts leftwards or downwards and consequently flattens the right or top side of the frustum. The effect can be seen directly if this script is added to a camera and the game is switched to the scene view while the game runs; the wireframe depiction of the camera's frustum will change as you vary the values of horizObl and vertObl in the inspector. A value of 1 or -1 in either variable indicates that one side of the frustum is completely flat against the centreline. It is possible although seldom necessary to use values outside this range.
