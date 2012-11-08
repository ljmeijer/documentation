ShaderLab syntax: other commands
================================


Category
--------


__Category__ is a logical grouping of any commands below it. This is mostly used to "inherit" rendering state. For example, your shader might have multiple [subshaders](SL-SubShader.md), and each of them requires [fog](SL-Fog.md) to be off, [blending](SL-Blend.md) set to additive, etc. You can use Category for that:
````

Shader "example" {
Category {
    Fog { Mode Off }
    Blend One One
    SubShader {
        // ...
    }
    SubShader {
        // ...
    }
    // ...
}
}

````

Category block only affects shader parsing, it's exactly the same as "pasting" any state set inside Category into all blocks below it. It does not affect shader execution speed at all.

