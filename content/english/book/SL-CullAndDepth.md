ShaderLab syntax: Culling & Depth Testing
=========================================



![](http://docwiki.hq.unity3d.com/uploads/Main/SL./PipelineCullDepth.png)  

Culling is an optimization that does not render polygons facing away from the viewer. All polygons have a front and a back side. Culling makes use of the fact that most objects are closed; if you have a cube, you will never see the sides facing away from you (there is always a side facing you in front of it) so we don't need to draw the sides facing away. Hence the term: Backface culling.

The other feature that makes rendering looks correct is Depth testing. Depth testing makes sure that only the closest surfaces objects are drawn in a scene.

Syntax
------

:__Cull__ Back | Front | Off: Controls which sides of polygons should be culled (not drawn)
-->__Back__ Don't render polygons facing away from the viewer _(default)_.
-->__Front__ Don't render polygons facing towards the viewer. Used for turning objects inside-out.
-->__Off__ Disables culling - all faces are drawn. Used for special effects.
:__ZWrite__ On | Off: Controls whether pixels from this object are written to the depth buffer (default is _On_). If you're drawng solid objects, leave this on. If you're drawing semitransparent effects, switch to _ZWrite Off_. For more details read below.
:__ZTest__ Less | Greater | LEqual | GEqual | Equal | NotEqual | Always: How should depth testing be performed. Default is _LEqual_ (draw objects in from or at the distance as existing objects; hide objects behind them).
:__Offset__ _Factor_ __,__ _Units_: Allows you specify a depth offset with two parameters. _factor_ and _units_. _Factor_ scales the maximum Z slope, with respect to X or Y of the polygon, and _units_ scale the minimum resolvable depth buffer value. This allows you to force one polygon to be drawn on top of another although they are actually in the same position. For example _Offset 0, -1_ pulls the polygon closer to the camera ignoring the polygon's slope, whereas _Offset -1, -1_ will pull the polygon even closer when looking at a grazing angle.


Examples
--------


This object will render only the backfaces of an object:

````
Shader "Show Insides" {
    SubShader {
        Pass {
            Material {
                Diffuse (1,1,1,1)
            }
            Lighting On
            Cull Front
        }
    }
} 
````

Try to apply it to a cube, and notice how the geometry feels all wrong when you orbit around it. This is because you're only seeing the inside parts of the cube.


###Transparent shader with depth writes

Usually [semitransparent shaders](shader-TransparentFamily.md) do not write into the depth buffer. However, this can create draw order problems, especially with complex non-convex meshes. If you want to fade in & out meshes like that, then using a shader that fills in the depth buffer before rendering transparency might be useful.


![](http://docwiki.hq.unity3d.com/uploads/Main/TransparentDiffuseZWrite.png)  
_Semitransparent object; left: standard Transparent/Diffuse shader; right: shader that writes to depth buffer._

````

Shader "Transparent/Diffuse ZWrite" {
Properties {
    _Color ("Main Color", Color) = (1,1,1,1)
    _MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
}
SubShader {
    Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
    LOD 200

    // extra pass that renders to depth buffer only
    Pass {
        ZWrite On
        ColorMask 0
    }

    // paste in forward rendering passes from Transparent/Diffuse
    UsePass "Transparent/Diffuse/FORWARD"
}
Fallback "Transparent/VertexLit"
}

````


###Debugging Normals
The next one is more interesting; first we render the object with normal vertex lighting, then we render the backfaces in bright pink. This has the effects of highlighting anywhere your normals need to be flipped. If you see physically-controlled objects getting 'sucked in' by any meshes, try to assign this shader to them. If any pink parts are visible, these parts will pull in anything unfortunate enough to touch it.

Here we go:

````
Shader "Reveal Backfaces" {
    Properties {
        _MainTex ("Base (RGB)", 2D) = "white" { }
    }
    SubShader {
        // Render the front-facing parts of the object.
        // We use a simple white material, and apply the main texture.
        Pass {
            Material {
                Diffuse (1,1,1,1)
            }
            Lighting On
            SetTexture [_MainTex] {
                Combine Primary * Texture
            }
        }

        // Now we render the back-facing triangles in the most
        // irritating color in the world: BRIGHT PINK!
        Pass {
            Color (1,0,1,1)
            Cull Front
        }
    }
} 
````


###Glass Culling
Controlling Culling is useful for more than debugging backfaces. If you have transparent objects, you quite often want to show the backfacing side of an object. If you render without any culling (__Cull Off__), you'll most likely have some rear faces overlapping some of the front faces.

Here is a simple shader that will work for convex objects (spheres, cubes, car windscreens).

````
Shader "Simple Glass" {
    Properties {
        _Color ("Main Color", Color) = (1,1,1,0)
        _SpecColor ("Spec Color", Color) = (1,1,1,1)
        _Emission ("Emmisive Color", Color) = (0,0,0,0)
        _Shininess ("Shininess", Range (0.01, 1)) = 0.7
        _MainTex ("Base (RGB)", 2D) = "white" { }
    }

    SubShader {
        // We use the material in many passes by defining them in the subshader.
        // Anything defined here becomes default values for all contained passes.
        Material {
            Diffuse [_Color]
            Ambient [_Color]
            Shininess [_Shininess]
            Specular [_SpecColor]
            Emission [_Emission]
        }
        Lighting On
        SeparateSpecular On

        // Set up alpha blending
        Blend SrcAlpha OneMinusSrcAlpha

        // Render the back facing parts of the object.
        // If the object is convex, these will always be further away
        // than the front-faces.
        Pass {
            Cull Front
            SetTexture [_MainTex] {
                Combine Primary * Texture
            }
        }
        // Render the parts of the object facing us.
        // If the object is convex, these will be closer than the
        // back-faces.
        Pass {
            Cull Back
            SetTexture [_MainTex] {
                Combine Primary * Texture
            }
        }
    }
} 
````
