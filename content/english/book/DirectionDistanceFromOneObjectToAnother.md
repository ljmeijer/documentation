Direction and Distance from One Object to Another
=================================================


If one point in space is subtracted from another then the result is a vector that "points" from one object to the other:



````
// Gets a vector that points from the player's position to the target's.
var heading = target.position - player.position;
````
	
As well as pointing in the direction of the target object, this vector's magnitude is equal to the distance between the two positions. It is common to need a normalized vector giving the direction to the target and also the distance to the target (say for directing a projectile). The distance between the objects is equal to the magnitude of the heading vector and this vector can be normalized by dividing it by its magnitude:-

````
var distance = heading.magnitude;
var direction = heading / distance;  // This is now the normalized direction.
````

This approach is preferable to using the both the magnitude and normalized properties separately, since they are both quite CPU-hungry (they both involve calculating a square root).

If you only need to use the distance for comparison (for a proximity check, say) then you can avoid the magnitude calculation altogether. The sqrMagnitude property gives the square of the magnitude value, and is calculated like the magnitude but without the time-consuming square root operation. Rather than compare the magnitude against a known distance, you can compare the squared magnitude against the squared distance:-

````
if (heading.sqrMagnitude < maxRange * maxRange) {
	// Target is within range.
}
````

This is much more efficient than using the true magnitude in the comparison.

Sometimes, the overground heading to a target is required. For example, imagine a player standing on the ground who needs to approach a target floating in the air. If you subtract the player's position from the target's then the resulting vector will point upwards towards the target. This is not suitable for orienting the player's transform since he will also point upwards; what is really needed is a vector from the player's position to the position on the ground directly below the target. This is easily obtained by taking the result of the subtraction and setting the Y coordinate to zero:-

````
var heading = target.position - player.position;
heading.y = 0;	// This is the overground heading.
````

