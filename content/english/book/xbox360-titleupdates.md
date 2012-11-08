Title Updates
=============


###How to build a title update
To create a title update follow the "Title Updates on Xbox 360" page in the Xbox 360 SDK Documentation.

1. Store the output of your original game build after release.
1. Use the same Unity version for the update (or an updated one that has been approved).
1. If updating scripts:
    1. Include the updated *.def and *.mono files.
    1. If using the same Unity version for the update, only the _Assembly-*_ files need to be updated.
    1. If code stripping was enabled in the original game build, all assemblies will most likely need to be updated (with the exception of tiny bigfixes).
    1. If title update contains a lot of new code and forces the in-memory size of any assembly to decrease/increase below/above the next multiple of 64KB, the relocation address of multiple assemblies will change and all assemblies will need to be updated.
1. If updating assets:
    1. Build them with _UncompressedAssetBundle_ flag.
    1. Add custom code to call _AssetBundle.CreateFromFile_.
    1. Load asset bundles from the _UPDATE:_ mount that will become available when the title update is applied.

