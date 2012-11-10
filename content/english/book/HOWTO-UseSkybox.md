How do I Make a Skybox?
=======================


A <span class=keyword>Skybox</span> is a 6-sided cube that is drawn behind all graphics in the game. Here are the steps to create one:

1. Make 6 textures that correspond to each of the 6 sides of the skybox and put them into your project's <span class=keyword>Assets</span> folder.
1. For each texture you need to change the wrap mode from <span class=component>Repeat</span> to <span class=component>Clamp</span>. If you don't do this colors on the edges will not match up: [<<](<<.md) Attach:SkyboxWrapmode.png
1. Create a new <span class=keyword>Material</span> by choosing <span class=menu>Assets->Create->Material</span> from the menu bar.
1. Select the shader drop-down in the top of the <span class=keyword>Inspector</span>, choose <span class=menu>RenderFX->Skybox</span>.
1. Assign the 6 textures to each texture slot in the material. You can do this by dragging each texture from the <span class=keyword>Project View</span> onto the corresponding slots. [<<](<<.md) Attach:SkyboxMaterial.png

To Assign the skybox to the scene you're working on:
1. Choose <span class=menu>Edit->Render Settings</span> from the menu bar.
1. Drag the new Skybox Material to the <span class=component>Skybox Material</span> slot in the Inspector. [<<](<<.md) Attach:SkyboxRenderSettings.png

Note that [Standard Assets](HOWTO-InstallStandardAssets.md) package contains several ready-to-use skyboxes - this is the quickest way to get started!
