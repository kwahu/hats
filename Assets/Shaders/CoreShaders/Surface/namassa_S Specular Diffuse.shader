//
// code by namassa
// email: karol.ryt@gmail.com
//
Shader "namassaShaders/Surface/Specular Diffuse" {
	Properties {
		_Color ("Main Color (RGB)", Color) = (1,1,1,1)
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Specular( "Specular Color", Color) = (1,1,1,1)
		_Shininess ("Shinnes", Range(0.01,1)) = 0.1
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf SimpleSpecular halfasview noforwardadd
		#pragma debug

		fixed4 _Color;
		fixed4 _Specular;
		fixed _Shininess; 
		sampler2D _MainTex;
		
		half4 LightingSimpleSpecular (SurfaceOutput s, half3 lightDir, half3 viewDir, half atten) {
          half3 h = normalize (lightDir + viewDir);

          half diff = max (0, dot (s.Normal, lightDir));

          float nh = max (0, dot (s.Normal, h));
          float spec = pow (nh, 48.0);

          half4 c;
          c.rgb = (s.Albedo * _LightColor0.rgb * diff + _LightColor0.rgb * spec * _Shininess) * (atten * 2);
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
