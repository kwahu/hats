//
// code by namassa
// email: karol.ryt@gmail.com
//
Shader "namassaShaders/No Lightmap/Vertex Colored Transparent Diffuse" {
	Properties {
		_Color ("Main Color (RGB), Transparency (A)", Color) = (1,1,1,1)
		_MainTex ("Base (RGB)", 2D) = "white" {}
	}

	SubShader {
		Tags { "RenderType"="Transparent" "Queue"="Transparent" }

		LIGHTING OFF
		Blend SrcAlpha OneMinusSrcAlpha
		
		Pass{
			CGPROGRAM
			#include "UnityCG.cginc"
			#pragma vertex vert
			#pragma fragment frag
			#pragma fragmentoption ARB_precision_hint_fastest 
			
			struct v2f 
			{
				half4 pos : SV_POSITION;
				half4 uv : TEXCOORD0;
				half4 col : COLOR0;
			};
				
					
			
			fixed4 _Color;
			sampler2D _MainTex;
				
			float4 _MainTex_ST;
	
			v2f vert(appdata_full v)
			{
				v2f o;
				o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
				o.uv.xy = TRANSFORM_TEX(v.texcoord,_MainTex);		
				o.col = v.color;
				return o;
			}
			
			fixed4 frag(v2f i): COLOR0
			{
				fixed4 tex = tex2D (_MainTex, i.uv.xy);
				
				tex *= _Color * i.col;
	
				return tex;
			}
			ENDCG
		}
	} 
	FallBack OFF
}
