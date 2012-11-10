Description of the Format
=========================


Unity's scene format is implemented with the YAML data serialization language. While we can't cover YAML in depth here, it is an open format and its specification is available for free at the [YAML website](http://yaml.org/spec/1.2/spec.html.md). Each object in the scene is written to the file as a separate YAML document, which is introduced in the file by the --- sequence. Note that in this context, the term "object" refers to GameObjects, Components and other scene data collectively; each of these items requires its own YAML document in the scene file. The basic structure of a serialized object can be understood from an example:-

````
--- !u!1 &6
GameObject:
  m_ObjectHideFlags: 0
  m_PrefabParentObject: {fileID: 0}
  m_PrefabInternal: {fileID: 0}
  importerVersion: 3
  m_Component:
  - 4: {fileID: 8}
  - 33: {fileID: 12}
  - 65: {fileID: 13}
  - 23: {fileID: 11}
  m_Layer: 0
  m_Name: Cube
  m_TagString: Untagged
  m_Icon: {fileID: 0}
  m_NavMeshLayer: 0
  m_StaticEditorFlags: 0
  m_IsActive: 1
````

The first line contains the string "!u!1 &6" after the document marker. The first number after the "!u!" part indicates the class of the object (in this case, it is a GameObject). The number following the ampersand is an object ID number which is unique within the file, although the number is assigned to each object arbitrarily. Each of the object's serializable properties is denoted by a line like the following:-

````
m_Name: Cube
````

Properties are typically prefixed with "m_" but otherwise follow the name of the property as defined in the script reference. A second object, defined further down in the file, might look something like this:-

````
--- !u!4 &8
Transform:
  m_ObjectHideFlags: 0
  m_PrefabParentObject: {fileID: 0}
  m_PrefabInternal: {fileID: 0}
  m_GameObject: {fileID: 6}
  m_LocalRotation: {x: 0.000000, y: 0.000000, z: 0.000000, w: 1.000000}
  m_LocalPosition: {x: -2.618721, y: 1.028581, z: 1.131627}
  m_LocalScale: {x: 1.000000, y: 1.000000, z: 1.000000}
  m_Children: []
  m_Father: {fileID: 0}
````

This is a Transform component attached to the GameObject defined by the YAML document above. The attachment is denoted by the line:-

````
m_GameObject: {fileID: 6}
````

...since the GameObject's object ID within the file was 6.

Floating point numbers can be represented in a decimal representation or as a hexadecimal number in IEE 754 format (denoted by a 0x prefix). The IEE 754 representation is used for lossless encoding of values, and is used by Unity when writing floating point values which don't have a short decimal representation. When Unity writes numbers in hexadecimal, it will always also write the decimal format in parentheses for debugging purposes, but only the hex is actually parsed when loading the file. If you wish to edit such values manually, simply remove the hex and enter only a decimal number. Here are some valid representations of floating point values (all representing the number one):

````
myValue: 0x3F800000
myValue: 1
myValue: 1.000
myValue: 0x3f800000(1)
myValue: 0.1e1
````
