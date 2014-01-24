//
// code by namassa
// email: karol.ryt@gmail.com
//
Shader "namassaShaders/Lightmapped/Transparent/Diffuse" {
	Properties {
		_Color ("Main Color", Color) = (1,1,1,1)
		_MainTex ("Base (RGB)", 2D) = "white" {}
	}
	
	SubShader {
		Tags { "RenderType"="Transparent" "Queue"="Transparent" }

		Blend SrcAlpha OneMinusSrcAlpha
		
		Pass{
			CGPROGRAM
			#include "UnityCG.cginc"	
			#pragma vertex vert
			#pragma fragment frag
			#pragma fragmentoption ARB_precision_hint_fastest 
			#pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
	
			struct v2f 
			{
				half4 pos : SV_POSITION;
				half4 uv : TEXCOORD0;
			};	
			
			fixed4 _Color;
			sampler2D _MainTex;
			
			float4 unity_LightmapST;
			sampler2D unity_Lightmap;	
			float4 _MainTex_ST;
	
			v2f vert(appdata_full v)
			{
				v2f o;
				o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
				o.uv.xy = TRANSFORM_TEX(v.texcoord,_MainTex);
			
				#ifdef LIGHTMAP_ON
				o.uv.zw = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
				#else
				o.uv.zw = half2(0,0);
				#endif 
			
				return o;
			}
			
			fixed4 frag(v2f i): COLOR0
			{
				fixed4 tex = tex2D (_MainTex, i.uv.xy);
				
				#ifdef LIGHTMAP_ON
				fixed3 lm =  DecodeLightmap (tex2D(unity_Lightmap, i.uv.zw));
				tex.rgb *= lm;
				#else
				tex.rgb *= 0.75;
				#endif
				
				tex *= _Color;
										
				return tex;
	
			}
			ENDCG
		}
	} 
	FallBack OFF
}
