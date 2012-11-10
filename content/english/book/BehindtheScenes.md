Behind the Scenes
=================


Unity automatically imports assets and manages various kinds of additional data about them for you. Below is a description of how this process works.

When you place an Asset such as a texture in the Assets folder, Unity will first detect that a new file has been added (the editor frequently checks the contents of the Assets folder against the list of assets it already knows about). Once a unique ID value has been assigned to the asset to enable it to be accessed internally, it will be imported and processed. The asset that you actually see in the Project panel is the result of that processing and its data contents will typically be different to those of the original asset. For example, a texture may be present in the Assets folder as a PNG file but will be converted to an internal format after import and processing.

Using an internal format for assets allows Unity to keep additional data known as _metadata_ which enables the asset data to be handled in a much more flexible way. For example, the Photoshop file format is convenient to work with, but you wouldn't expect it to support game engine features such as mip maps. Unity's internal format, however, can add extra functionality like this to any asset type. All metadata for assets is stored in the <span class=keyword>Library</span> folder.  As as user, you should never have to alter the Library folder manually and attempting to do so may corrupt the project.

Unity allows you to create folders in the Project view to help you organize assets, and those folders will be mirrored in the actual filesystem. However, you __must__ move the files within Unity by dragging and dropping in the Project view. If you attempt to use the filesystem/desktop to move the files then Unity will misinterpret the change (it will appear that the old asset has been deleted and a new one created in its place). This will lose information, such as links between assets and scripts in the project.

When backing up a project, you should __always__ back up the main Unity project folder, containing both the <span class=keyword>Assets</span> and <span class=keyword>Library</span> folders. All the information in the subfolders is crucial to the way Unity works.
