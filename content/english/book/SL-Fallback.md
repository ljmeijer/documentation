ShaderLab syntax: Fallback
==========================


After all Subshaders a Fallback can be defined. It basically says "if none of subshaders can run on this hardware, try using the ones from another shader".

Syntax
------

:__Fallback__ "name": Fallback to shader with a given _name_.
:__Fallback Off__: Explicitly state that there is no fallback and no warning should be printed, even if no subshaders can run on this hardware.

Details
-------


A fallback statement has the same effect as if all subshaders from the other shader would be inserted into its place.

Example
-------


````
Shader "example" {
    // properties and subshaders here...
    Fallback "otherexample"
} 
````

