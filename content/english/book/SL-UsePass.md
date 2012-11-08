ShaderLab syntax: UsePass
=========================

The UsePass command uses named passes from another shader.

Syntax
------


__UsePass__ "_Shader/Name_"

Inserts all passes with a given name from a given shader. _Shader/Name_ contains the name of the shader and the name of the pass, separated by a slash character. Note that only first supported [subshader](SL-SubShader.md) is taken into account.


Details
-------


Some of the shaders could reuse existing passes from other shaders, reducing code duplication. For example, in most pixel lit shaders the ambient or vertex lighting passes are the same as in the corresponding VertexLit shaders. The UsePass command does just that - it includes a given pass from another shader. As an example the following command uses the pass with the name _"BASE"_ from the builtin _Specular_ shader:

    __UsePass__ "Specular/BASE"

In order for UsePass to work, a name must be given to the pass one wishes to use. The [Name](SL-Name.md) command inside the pass gives it a name:

    __Name__ "_MyPassName_"

Note that internally all pass names are uppercased, so UsePass must refer to the name __in uppercase__.
