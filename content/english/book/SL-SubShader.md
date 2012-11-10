ShaderLab syntax: SubShader
===========================


Each shader in Unity consists of a list of subshaders. When Unity has to display a mesh, it will find the shader to use, and pick the first subshader that runs on the user's graphics card.

Syntax
------


:__Subshader__ __{__ [_Tags_] [_CommonState_] _Passdef_ [_Passdef ..._] __}__: Defines the subshader as optional tags, common state and a list of pass definitions.

Details
-------


A subshader defines a list of [rendering passes](SL-Pass.md) and optionally setup any state that is common to all passes. Additionally, subshader specific [Tags](SL-SubshaderTags.md) can be set up.

When Unity chooses which subshader to render with, it renders an object once for each Pass defined (and possibly more due to light interactions). As each render of the object is an expensive operation, you want to define the shader in minimum amount of passes possible. Of course, sometimes on some graphics hardware the needed effect can't be done in a single pass; then you have no choice but to use multiple passes.

Each pass definition can be a [regular Pass](SL-Pass.md), a [Use Pass](SL-UsePass.md) or a  [Grab Pass](SL-GrabPass.md).

Any statements that are allowed in a Pass definition can also appear in Subshader block. This will make all passes use this "shared" state.

Example
-------


````
// ...
SubShader {
    Pass {
        Lighting Off
        SetTexture [_MainTex] {}
    }
}
// ...
````

This subshader defines a single Pass that turns off any lighting and just displays a mesh with texture named <span class=component>_MainTex</span>.
