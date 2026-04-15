Shader "Custom/GridShader"
{
    Properties
    {
        _GridTex ("Grid Texture", 2D) = "white" {}
        _GridSize ("Grid Size", Vector) = (10,10,0,0)
        _CellColor ("Cell Color", Color) = (1,1,1,1)
        _SelectedColor ("Selected Color", Color) = (0,1,0,1)
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            sampler2D _GridTex;
            float4 _GridSize;
            float4 _CellColor;
            float4 _SelectedColor;

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

            fixed4 frag (v2f i) : SV_Target
            {
                float2 gridUV = i.uv;

                float value = tex2D(_GridTex, gridUV).r;

                return lerp(_CellColor, _SelectedColor, value);
            }
            ENDCG
        }
    }
}