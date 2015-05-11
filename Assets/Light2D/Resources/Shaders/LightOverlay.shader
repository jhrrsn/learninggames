/*

That shader is used to merge light sources, abmient light and game textures into one.

*/


Shader "Light2D/Light Overlay" {
Properties {
	_GameTex ("Game", 2D) = "white" {}
	_AmbientLightTex ("Ambient Light", 2D) = "black" {}
	_LightSourcesTex ("Light Sources", 2D) = "black" {}
	_LightSourcesMul ("Light Sources Multiplier", Float) = 1
	_LightMul ("Resulting Light Multiplier", Float) = 2
	_AdditiveLightPow ("Additive Light Pow. Bigger pow -> less bloom.", Float) = 10
	_AdditiveLightAdd ("Additive Light Add", Float) = 0.2
}

SubShader {
	Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
	LOD 100
	
	ZWrite Off

	Pass {  
		CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile DUMMY HDR
			
			#include "UnityCG.cginc"

			struct appdata_t {
				float4 vertex : POSITION;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f {
				float4 vertex : SV_POSITION;
				half2 texcoordGame : TEXCOORD0;
				half2 texcoordLight : TEXCOORD1;
			};
			
			uniform sampler2D _MainTex;
			uniform sampler2D _GameTex;
		 	uniform half4 _GameTex_TexelSize;
			uniform sampler2D _AmbientLightTex;
			uniform sampler2D _LightSourcesTex;
			uniform float2 _Scale;
			uniform float2 _Offest;
			uniform half _LightMul;
			uniform half _LightSourcesMul;
			uniform half _AdditiveLightPow;
			uniform half _AdditiveLightAdd;
			
			v2f vert (appdata_t v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.texcoordGame = v.texcoord;
				o.texcoordLight = (o.texcoordGame - 0.5)*_Scale + 0.5 + _Offest;

				#if UNITY_UV_STARTS_AT_TOP
				if (_GameTex_TexelSize.y < 0)
					o.texcoordGame = half2(o.texcoordGame.x, 1 - o.texcoordGame.y);
				#endif

				return o;
			}

			half4 frag (v2f i) : COLOR
			{
				half4 game = tex2D(_GameTex, i.texcoordGame);
				half4 ambientLight = tex2D(_AmbientLightTex, i.texcoordLight);
				half4 lightSources = tex2D(_LightSourcesTex, i.texcoordLight)*_LightSourcesMul;
				half4 light = ambientLight + lightSources;

				return half4(game.rgb*light.rgb*_LightMul + (game.rgb + _AdditiveLightAdd)*pow(light.rgb, _AdditiveLightPow), game.a);
			}
		ENDCG
	}
}

}