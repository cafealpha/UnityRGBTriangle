Shader "Custom/BasicShader" {
	Properties {
	}
	SubShader {
		Tags { "RenderType"="Opaque" }

		CGPROGRAM
		#pragma surface surf Standard

		struct Input {
			float4 color : COLOR;
		};

		void surf (Input IN, inout SurfaceOutputStandard o) {
			//o.Emission = IN.color.rgb;
			o.Albedo = IN.color.rgb;
			//o.Alpha = 1;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
