Tips and Tricks
===============


Sounds
------

* For short sounds always use ADPCM format, this is a compressed Wii audio format which can be played by hardware.
>__Note__: all audio clips with ADPCM format will be converted to mono sounds.
>For streaming sounds (for ex., music) it's okay to use any format.

Graphics
--------

* Always use Wii CMPR format for textures, it can compress texture up to 8x times comparing to Wii RGBA8 format.
>__Note__: Wii CMPR only supports 1 bit alpha - only pixels which have 0 alpha will be transparent, all others will be full opaque.
* When scaling game objects which have Mesh Renderers, use only uniform scales, for ex., (1.2, 1.2, 1.2), (3.0, 3.0, 3.0), etc.
>If you use non-uniform scale, for ex., (2.0, 1.0, 1.0), (3.0, 2.0, 1.0), Unity will create a new mesh instance for every Mesh Renderer which has a non-uniform scale.

