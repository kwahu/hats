Shader "namassaShaders/Other/Planar Reflection" {
Properties {
	_Color ("Main Color (RGB), Reflection Power (A)", Color) = (1,1,1,1)
    _MainTex ("Base (RGB)", 2D) = "white" {}
    _ReflectionTex ("Reflection", 2D) = "white" { TexGen ObjectLinear }
}

// two texture cards: full thing
Subshader { 
	GrabPass{}
    Pass {
    Lighting Off
    ZWrite Off
    Blend One One
    	Color [_Color]
        SetTexture [_GrabPass] { combine texture * previous }
        SetTexture[_ReflectionTex] { matrix [_ProjMatrix] combine texture * previous }
    }
}



}