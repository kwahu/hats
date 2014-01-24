//
// code by namassa
// email: karol.ryt@gmail.com
//
Shader "namassaShaders/Other/Fake Spherical AO" {
	Properties {
		_Color ("Main Color", Color) = (1,1,1,1)
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_EnvMap("Environemnt Map", Cube) = "white" {}
		_EnvMapPower("EnvMap Power", Range(0,1) ) = 0.5
		_GroundLevel("Ground Level posY", float) = 0
		_GroundAOPower("Ground AO Power", Range(0,1) ) = 0.5
	}

	SubShader {
		Tags { "RenderType"="Opaque" }

		LIGHTING OFF
		
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
				float3 sWorldNormal : TEXCOORD2;
				float3 worldPos : TEXCOORD3;
			};
				
					
			
			fixed4 _Color;
			sampler2D _MainTex;
			samplerCUBE _EnvMap;
			fixed _EnvMapPower;
			fixed _GroundLevel;
			fixed _GroundAOPower;
				
			float4 _MainTex_ST;
	
			v2f vert(appdata_base v)
			{
				v2f o;
				o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
				o.uv.xy = TRANSFORM_TEX(v.texcoord,_MainTex);
				o.sWorldNormal = mul((float3x3)_Object2World, SCALED_NORMAL);
				o.worldPos = mul (_Object2World, v.vertex).xyz;
				
				return o;
			}
			
			fixed4 frag(v2f i): COLOR0
			{
				fixed4 tex = tex2D (_MainTex, i.uv.xy);
				tex *= _Color;
				
				half4 envMaping = texCUBE(_EnvMap,float4( i.sWorldNormal.x, i.sWorldNormal.y,i.sWorldNormal.z,1.0 ));
				
				envMaping = lerp(1,envMaping,_EnvMapPower);	
				
				fixed groundAO = i.worldPos.y - _GroundLevel;
				
				groundAO = lerp(1,clamp(groundAO,0,1), _GroundAOPower);		
																														
				return tex*envMaping*groundAO;
			}
			ENDCG
		}
	} 
	FallBack OFF
}
