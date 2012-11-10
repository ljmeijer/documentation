Built-in state variables in shader programs
===========================================


Often in [shader programs](SL-ShaderPrograms.md) you need to access some global state, for example, the current model*view*projection matrix, the current ambient color, and so on. There's no need to declare these variables for the built-in state, you can just use them in shader programs.

Built-in matrices
-----------------


Matrices (float4x4) supported:

: <span class=component>UNITY_MATRIX_MVP</span> : Current model*view*projection matrix
: <span class=component>UNITY_MATRIX_MV</span> : Current model*view matrix
: <span class=component>UNITY_MATRIX_P</span> : Current projection matrix
: <span class=component>UNITY_MATRIX_T_MV</span> : Transpose of model*view matrix
: <span class=component>UNITY_MATRIX_IT_MV</span> : Inverse transpose of model*view matrix
: <span class=component>UNITY_MATRIX_TEXTURE0</span> to <span class=component>UNITY_MATRIX_TEXTURE3</span> : Texture transformation matrices

Built-in vectors
----------------


Vectors (float4) supported:

: <span class=component>UNITY_LIGHTMODEL_AMBIENT</span> : Current ambient color.

