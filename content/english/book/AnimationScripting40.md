Animation Scripting (Legacy)
============================


Unity's Animation System allows you to create beautifully animated skinned characters. The Animation System supports animation blending, mixing, additive animations, walk cycle time synchronization, animation layers, control over all aspects of the animation playback (time, speed, blend-weights), mesh skinning with 1, 2 or 4 bones per vertex as well as supporting physically based rag-dolls and procedural animation. To obtain the best results, it is recommended that you read about the best practices and techniques for creating a rigged character with optimal performance in Unity on the [Modeling Optimized Characters](ModelingOptimizedCharacters.md) page.

Making an animated character involves two things; _moving_ it through the world and _animating_ it accordingly. If you want to learn more about moving characters around, take a look at the [Character Controller page](class-CharacterController.md). This page focuses on the animation. The actual animating of characters is done through Unity's scripting interface.

You can download [example demos](http://unity3d.com/support/resources/example-projects/.md) showing pre-setup animated characters. Once you have learned the basics on this page you can also see the [animation script interface](ScriptRef:Animation.html).

This page contains the following sections:-

* [Animation Blending](#AnimBlend)
* [Animation Layers](#AnimLayers)
* [Animation Mixing](#AnimMixing)
* [Additive Animation](#Additive)
* [Procedural Animation](#Procedural)
* [Animation Playback and Sampling](#Playback)


<a id="AnimBlend"></a>

Animation Blending
------------------


In today's games, animation blending is an essential feature to ensure that characters have smooth animations. Animators create separate animations, for example, a walk cycle, run cycle, idle animation or shoot animation. At any point in time during your game you need to be able to transition from the idle animation into the walk cycle and vice versa. Naturally, you want the transition to be smooth and avoid sudden jerks in the motion.

This is where animation blending comes in. In Unity you can have any number of animations playing on the same character. All animations are blended or added together to generate the final animation.

Our first step will be to make a character blend smoothly between the idle and walk animations.  In order to make the scripter's job easier, we will first set the <span class=component>Wrap Mode</span> of the animation to <span class=component>Loop</span>. Then we will turn off <span class=component>Play Automatically</span> to make sure our script is the only one playing animations.

Our first script for animating the character is quite simple; we only need some way to detect how fast our character is moving, and then fade between the walk and idle animations. For this simple test, we will use the standard input axes:-


````
function Update () {
   if (Input.GetAxis("Vertical") > 0.2)
       animation.CrossFade ("walk");
   else
      animation.CrossFade ("idle");
} 
````


To use this script in your project:-
1. Create a Javascript file using <span class=menu>Assets->Create Other->Javascript</span>.
1. Copy and paste the code into it
1. Drag the script onto the character (it needs to be attached to the <span class=keyword>GameObject</span> that has the animation)

When you hit the Play button, the character will start walking in place when you hold the up arrow key and return to the idle pose when you release it.


<a id="AnimLayers"></a>

Animation Layers
----------------


Layers are an incredibly useful concept that allow you to group animations and prioritize weighting.

Unity's animation system can blend between as many animation clips as you want. You can assign blend weights manually or simply use <span class=component>animation.CrossFade()</span>, which will animate the weight automatically.


###Blend weights are always normalized before being applied

Let's say you have a walk cycle and a run cycle, both having a weight of 1 (100%). When Unity generates the final animation, it will normalize the weights, which means the walk cycle will contribute 50% to the animation and the run cycle will also contribute 50%.

However, you will generally want to prioritize which animation receives most weight when there are two animations playing. It is certainly possible to ensure that the weight sums up to 100% manually, but it is easier just to use layers for this purpose.


<a id="LayerExample"></a>

###Layering Example

As an example, you might have a shoot animation, an idle and a walk cycle. The walk and idle animations would be blended based on the player's speed but when the player shoots, you would want to show only the shoot animation. Thus, the shoot animation essentially has a higher priority.

The easiest way to do this is to simply keep playing the walk and idle animations while shooting. To do this, we need to make sure that the shoot animation is in a higher layer than the idle and walk animations, which means the shoot animation will receive blend weights first. The walk and idle animations will receive weights only if the shoot animation doesn't use all 100% of the blend weighting. So, when CrossFading the shoot animation in, the weight will start out at zero and over a short period become 100%. In the beginning the walk and idle layer will still receive blend weights but when the shoot animation is completely faded in, they will receive no weights at all. This is exactly what we need!


````
function Start () {
   // Set all animations to loop
   animation.wrapMode = WrapMode.Loop;
   // except shooting
   animation["shoot"].wrapMode = WrapMode.Once;

   // Put idle and walk into lower layers (The default layer is always 0)
   // This will do two things
   // - Since shoot and idle/walk are in different layers they will not affect
   //   each other's playback when calling CrossFade.
   // - Since shoot is in a higher layer, the animation will replace idle/walk
   //   animations when faded in.
   animation["shoot"].layer = 1;

   // Stop animations that are already playing
   //(In case user forgot to disable play automatically)
   animation.Stop();
}

function Update () {
   // Based on the key that is pressed,
   // play the walk animation or the idle animation
   if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.1)
      animation.CrossFade("walk");
   else
      animation.CrossFade("idle");

   // Shoot
   if (Input.GetButtonDown ("Fire1"))
      animation.CrossFade("shoot");
} 
````


By default the <span class=component>animation.Play()</span> and <span class=component>animation.CrossFade()</span> will stop or fade out animations that are in the same layer. This is exactly what we want in most cases. In our shoot, idle, run example, playing idle and run will not affect the shoot animation and vice versa (you can change this behavior with an optional parameter to animation.CrossFade if you like).

<a id="AnimMixing"></a>

Animation Mixing
----------------


Animation mixing allow you to cut down on the number of animations you need to create for your game by having some animations apply to part of the body only. This means such animations can be used together with other animations in various combinations.

You add an animation mixing transform to an animation by calling <span class=component>AddMixingTransform()</span> on the given AnimationState.

<a id="MixingExample"></a>

###Mixing Example

An example of mixing might be something like a hand-waving animation. You might want to make the hand wave either when the character is idle or when it is walking. Without animation mixing you would have to create separate hand waving animations for the idle and walking states. However, if you add the shoulder transform as a mixing transform to the hand waving animation, the hand waving animation will have full control only from the shoulder joint to the hand. Since the rest of the body will not be affected by he hand-waving, it will continue playing the idle or walk animation. Consequently, only the one animation is needed to make the hand wave while the rest of the body is using the idle or walk animation.

````
/// Adds a mixing transform using a Transform variable
var shoulder : Transform;
animation["wave_hand"].AddMixingTransform(shoulder);
````

Another example using a path.
````
function Start () {
   // Adds a mixing transform using a path instead
   var mixTransform : Transform = transform.Find("root/upper_body/left_shoulder");
   animation["wave_hand"].AddMixingTransform(mixTransform);
}
````


<a id="Additive"></a>

Additive Animations
-------------------


Additive animations and animation mixing allow you to cut down on the number of animations you have to create for your game, and are important for creating facial animations.

Suppose you want to create a character that leans to the sides as it turns while walking and running. This leads to four combinations (walk-lean-left, walk-lean-right, run-lean-left, run-lean-right), each of which needs an animation. Creating a separate animation for each combination clearly leads to a lot of extra work even in this simple case but the number of combinations increases dramatically with each additional action. Fortunately additive animation and mixing avoids the need to produce separate animations for combinations of simple movements.

###Additive Animation Example

Additive animations allow you to overlay the effects of one animation on top of any others that may be playing. When generating additive animations, Unity will calculate the difference between the first frame in the animation clip and the current frame. Then it will apply this difference on top of all other playing animations.

Referring to the previous example, you could make animations to lean right and left and Unity would be able to superimpose these on the walk, idle or run cycle. This could be achieved with code like the following:-

````
private var leanLeft : AnimationState;
private var leanRight : AnimationState;

function Start () {
   leanLeft = animation["leanLeft"];
   leanRight = animation["leanRight"];

   // Put the leaning animation in a separate layer
   // So that other calls to CrossFade won't affect it.
   leanLeft.layer = 10;
   leanRight.layer = 10;

   // Set the lean animation to be additive
   leanLeft.blendMode = AnimationBlendMode.Additive;
   leanRight.blendMode = AnimationBlendMode.Additive;

   // Set the lean animation ClampForever
   // With ClampForever animations will not stop 
   // automatically when reaching the end of the clip
   leanLeft.wrapMode = WrapMode.ClampForever;
   leanRight.wrapMode = WrapMode.ClampForever;

   // Enable the animation and fade it in completely
   // We don't use animation.Play here because we manually adjust the time
   // in the Update function.
   // Instead we just enable the animation and set it to full weight
   leanRight.enabled = true;
   leanLeft.enabled = true;
   leanRight.weight = 1.0;
   leanLeft.weight = 1.0;

   // For testing just play "walk" animation and loop it
   animation["walk"].wrapMode = WrapMode.Loop;
   animation.Play("walk");
}

// Every frame just set the normalized time
// based on how much lean we want to apply
function Update () {
   var lean = Input.GetAxis("Horizontal");
   // normalizedTime is 0 at the first frame and 1 at the last frame in the clip
   leanLeft.normalizedTime = -lean;
   leanRight.normalizedTime = lean;
} 
````


__Tip:__ When using Additive animations, it is critical that you also play some other non-additive animation on every transform that is also used in the additive animation, otherwise the animations will add on top of the last frame's result. This is most certainly not what you want.

<a id="Procedural"></a>

Animating Characters Procedurally
---------------------------------


Sometimes you want to animate the bones of your character procedurally. For example, you might want the head of your character to look at a specific point in 3D space which is best handled by a script that tracks the target point. Fortunately, Unity makes this very easy, since bones are just Transforms which drive the skinned mesh. Thus, you can control the bones of a character from a script just like the Transforms of a GameObject.

One important thing to know is that the animation system updates Transforms after the <span class=component>Update()</span> function and before the <span class=component>LateUpdate()</span> function. Thus if you want to do a <span class=component>LookAt()</span> function you should do that in <span class=component>LateUpdate()</span> to make sure that you are really overriding the animation.

Ragdolls are created in the same way. You simply have to attach Rigidbodies, Character Joints and Capsule Colliders to the different bones. This will then physically animate your skinned character.


<a id="Playback"></a>

Animation Playback and Sampling
-------------------------------


This section explains how animations in Unity are sampled when they are played back by the engine.

AnimationClips are typically authored at a fixed frame rate. For example, you may create your animation in 3ds Max or Maya at a frame rate of 60 frames per second (fps). When importing the animation in Unity, this frame rate will be read by the importer, so the data of the imported animation is also sampled at 60 fps.

However, games typically run at a variable frame rate. The frame rate may be higher on some computers than on others, and it may also vary from one second to the next based on the complexity of the view the camera is looking at at any given moment. Basically this means that we can make no assumptions about the exact frame rate the game is running at. What this means is that even if an animation is authored at 60 fps, it may be played back at a different framerate, such as 56.72 fps, or 83.14 fps, or practically any other value.

As a result, Unity must sample an animation at variable framerates, and cannot guarantee the framerate for which it was originally designed. Fortunately, animations for 3D computer graphics do not consist of discrete frames, but rather of continuous curves. These curves can be sampled at any point in time, not just at those points in time that correspond to frames in the original animation. In fact, if the game runs at a higher frame rate than the animation was authored with, the animation will actually look smoother and more fluid in the game than it did in the animation software.

For most practical purposes, you can ignore the fact that Unity samples animations at variable framerates. However, if you have gameplay logic that relies on animations that animate transforms or properties into very specific configurations, then you need to be aware that the re-sampling takes place behind the scenes. For example, if you have an animation that rotates an object from 0 to 180 degrees over 30 frames, and you want to know from your code when it has reached half way there, you should not do it by having a conditional statement in your code that checks if the current rotation is 90 degrees. Because Unity samples the animation according to the variable frame rate of the game, it may sample it when the rotation is just below 90 degrees, and the next time right after it reached 90 degrees. If you need to be notified when a specific point in an animation is reached, you should use an [AnimationEvent](animeditor-AnimationEvents.md) instead.

Note also that as a consequence of the variable framerate sampling, an animation that is played back using <span class=component>WrapMode.Once</span> may not be sampled at the exact time of the last frame. In one frame of the game the animation may be sampled just before the end of the animation, and in the next frame the time can have exceeded the length of the animation, so it is disabled and not sampled further. If you absolutely need the last frame of the animation to be sampled exactly, you should use <span class=component>WrapMode.ClampForever</span> which will keep sampling the last frame indefinitely until you stop the animation yourself.
