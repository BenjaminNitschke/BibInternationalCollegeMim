Shader "Hidden/GrayScalePost"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;

			fixed4 frag(v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex,
					//i.uv - _SinTime.z * float2(i.vertex.x/1280 * _SinTime.x, _SinTime.y) / 10);
					i.uv + float2(sin(_Time.x + i.vertex.x/500)/15, cos(_Time.y + i.vertex.y / 400) / 20));
				//col = col.r * 0.3 + col.g * 0.6 + col.b * 0.1;
				return col;
			}
			ENDCG
		}
	}
}
