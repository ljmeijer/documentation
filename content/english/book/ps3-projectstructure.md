Playstation3: Project Structure
===============================


Special directories
-------------------

* _/path/to/project/Assets/StreamingAssets_ : for assets that Unity should not process. Will be packaged as _Media/Raw/*_.
    * Videos.
    * Asset bundles.
    * Custom assets.
* _/path/to/project/Assets/Plugins/PS3/_ : for native plugins. *.sprx and *_stub.a. Will be packaged as _Media/Plugins/*_.


Runtime paths:
--------------


The PS3 will mount the game folder depending on the Build Type:

_'PC Hosted_'
* Game folder mounted at _/app_home/PS3_GAME/_.

_'BlueRay_'
* Game folder mounted at _/dev_bdvd/PS3_GAME/_.

_'HDD_'
* Game folder mounted at _/dev_hdd0/game/_.
