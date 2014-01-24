//
// code by namassa
// email: karol.ryt@gmail.com
//
Shader "namassaShaders/No Lightmap/Illumin Diffuse Pulsating" {
	Properties {	
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_PulseSpeed ("Pulse Speed", float) = 1
		_PulseMin ("Pulse min value", float) = 0
		_PulseMax ("Pulse max value", float) = 1
	}
	SubShader {
	Tags { "RenderType"="Opaque" }
		
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
			};	
			
			fixed4 _Color;
			fixed _PulseSpeed;
			fixed _PulseMin;
			fixed _PulseMax;
			sampler2D _MainTex;
			
			float4 _MainTex_ST;
	
			v2f vert(appdata_base v)
			{
				v2f o;
				o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
				o.uv.xy = TRANSFORM_TEX(v.texcoord,_MainTex);
			
				return o;
			}
			
			fixed4 frag(v2f i): COLOR0
			{
				fixed4 tex = tex2D (_MainTex, i.uv.xy);
				
				tex *= _Color;
				
				fixed pulse = tex.a * sin(_Time * _PulseSpeed);
							
				tex.rgb += (pulse, pulse, pulse, pulse);
										
				return tex;
	
			}
			ENDCG
		}
	} 
	FallBack "namassa_DiffuseColor"
}

