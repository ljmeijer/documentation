3D Textures
===========


Unity supports 3D Texture use and creation from shader and script. While use cases of 3D Textures might not seem as straightforward at first, they can be an integral part of implementing specific kinds of effects such as [3D Color Correction](script-ColorCorrectionLut.md).

Currently, 3D Textures can only be created from script. The following snippet creates a "neutral" 3D texture where, if used as a lookup texture in [3D Color Correction](script-ColorCorrectionLut.md), the performed correction will be the identity.

````
function CreateIdentityLut (dim : int, tex3D : Texture3D) 
{
  var newC : Color[] = new Color[dim * dim * dim];
  var oneOverDim : float = 1.0f / (1.0f * dim - 1.0f);
  for(var i : int = 0; i < dim; i++) {
    for(var j : int = 0; j < dim; j++) {
      for(var k : int = 0; k < dim; k++) {
        newC[i + (j*dim) + (k*dim*dim)] = new Color((i*1.0f)*oneOverDim, (j*1.0f)*oneOverDim, (k*1.0f)*oneOverDim, 1.0f);
      }
    }
  }
  tex3D.SetPixels (newC);
  tex3D.Apply ();
}
````
