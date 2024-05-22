Shader "Custom/Fisheye"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
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

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            float2 _ScreenSize;
            float _FisheyeStrength;

            fixed4 frag(v2f i) : SV_Target
            {
                float2 center = float2(0.5, 0.5);
                float2 uv = i.uv - center;
                float dist = length(uv);
                float angle = atan2(uv.y, uv.x);
                float r = dist * _FisheyeStrength;
                float2 fisheyeUV = center + float2(cos(angle) * r, sin(angle) * r);
                return tex2D(_MainTex, fisheyeUV);
            }
            ENDCG
        }
    }
}
