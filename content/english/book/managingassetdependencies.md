Managing asset dependencies
===========================


Any given asset in a bundle may depend on other assets. For example, a model may incorporate materials which in turn make use of textures and shaders. It is possible to include all an asset's dependencies along with it in its bundle. However, several assets from different bundles may all depend on a common set of other assets (eg, several different models of buildings may use the same brick texture). If a separate copy of a shared dependency is included in each bundle that has objects using it, then redundant instances of the assets will be created when the bundles are loaded. This will result in wasted memory.

To avoid such wastage, it is possible to separate shared dependencies out into a separate bundle and simply reference them from any bundles with assets that need them. First, the referencing feature needs to be enabled with a call to [BuildPipeline.PushAssetDependencies](ScriptRef:BuildPipeline.PushAssetDependencies.html). Then, the bundle containing the referenced dependencies needs to be built. Next, another call to PushAssetDependencies should be made before building the bundles that reference the assets from the first bundle. Additional levels of dependency can be introduced using further calls to PushAssetDependencies. The levels of reference are stored on a stack, so it is possible to go back a level using the corresponding [BuildPipeline.PopAssetDependencies](ScriptRef:BuildPipeline.PopAssetDependencies.html) function. The push and pop calls need to be balanced including the initial push that happens before building.

At runtime, you need to load a bundle containing dependencies before any other bundle that references them. For example, you would need to load a bundle of shared textures before loading a separate bundle of materials that reference those textures.

Note that if you anticipate needing to rebuild asset bundles that are part of a dependency chain then you should build them with the [BuildAssetBundleOptions.DeterministicAssetBundle](ScriptRef:BuildAssetBundleOptions.DeterministicAssetBundle.html) option enabled. This guarantees that the internal ID values used to identify assets will be the same each time the bundle is rebuilt.


[back to AssetBundles Intro](AssetBundlesIntro.md)
