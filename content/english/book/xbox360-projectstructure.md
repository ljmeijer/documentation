Project Structure
=================


###Special directories
1. _PROJECT/Assets/StreamingAssets_ - for assets that Unity should not process. Files are copied to _OUTPUT\Media\Raw_.
    * Videos.
    * Asset bundles.
    * Custom assets.
1. _PROJECT/Assets/Plugins_ - for native plugins. *.def and *.xex files are copied to _OUTPUT\Media\Plugins_.

###Runtime paths:
1. Xbox mounts the game folder to _game:_.
1. Unity executable is located at _game:\Project.XEX_.
1. Unity data files are located at _game:\Media\_.
1. Unity compiled script assemblies are located at  _game:\Media\Managed\_.
1. Raw assets are located at _game:\Media\Raw\_.

