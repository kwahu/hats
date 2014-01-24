//
// code by namassa
// email: karol.ryt@gmail.com
//
Shader "namassaShaders/Surface/Diffuse" {
	Properties {
		_Color ("Main Color (RGB)", Color) = (1,1,1,1)
		_MainTex ("Base (RGB)", 2D) = "white" {}
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Simple
		#pragma debug

		fixed4 _Color;
		sampler2D _MainTex;
		
		half4 LightingSimple (SurfaceOutput s, half3 lightDir, half atten) {
		
          half diff = max (0, dot (s.Normal, lightDir));

          half4 c;
          c.rgb = (s.Albedo * _LightColor0.rgb * diff) * (atten * 2);
          c.a = s.Alpha;
          return c;
      }

		struct Input {
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			half4 c = tex2D (_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb * _Color;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
