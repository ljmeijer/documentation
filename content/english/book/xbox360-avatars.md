Avatars
=======


###Avatars
Unity provides a simple way to load Avatar resources - see Scripting API reference for [[ScriptRef:X360Avatars|@@UnityEngine.X360Avatars@
Displaying an avatar step by step:
1. Make sure a user is signed in: `UnityEngine.X360Core.RequestSignIn()` when requesting user avatars.
1. Issue an avatar load: `UnityEngine.X360Avatars.RequestLocalUserAvatar()` or any other Request* function.
1. Handle the `OnAvatarLoaded(UnityEngine.X360AvatarModel model, IntPtr avatarAssets)` callback.
    1. `X360AvatarModel` contains a `Mesh` with multiple subsets (`X360AvatarModel.batchCount`). It is a rough wrapper around `XAVATAR_ASSETS` (see _XAvatar Structures_ in Xbox 360 SDK Documentation). Hold on to it for as long as the Avatar is required.
    1. `avatarAssets` is a pointer to `XAVATAR_ASSETS` valid during the callback. It may be passed to a plugin.
1. `X360AvatarModel.Mesh` can be used in Unity as a normal Mesh.
1. Avatar vertex buffers contain extra UV channels (half2) in certain cases:
    1. Head: TEXCOORD2 through TEXCOORD5 for:
        1. Eyebrow texture.
        1. Eye texture.
        1. Mouth texture.
        1. Eye shadow texture.
    1. Non-shiny body parts: TEXCOORD2 for the decal texture.
    1. Data from these extra channels can not be accessed from scripts.

###Shaderlab extensions
In order to support Avatar rendering, shaderlab was extended to allow for more UV sets on Xbox 360.
In case of surface shaders, those UV sets are only accessible when _#pragma only_renderers xbox360_ is set.


###Example project:

See "Xbox 360 - Avatar Rendering Example" package.


