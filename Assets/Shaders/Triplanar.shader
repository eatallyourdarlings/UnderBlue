Shader "Custom/Triplanar"
{
    Properties
    {
        [MainColor] _BaseColor("Base Color", Color) = (1, 1, 1, 1)
        _XColor("Base Color", Color) = (1, 1, 1, 1)
        _ZColor("Base Color", Color) = (1, 1, 1, 1)
        [MainTexture] _BaseMap("Base Map", 2D) = "white" {}
    }

    SubShader
    {
        Tags { "RenderType" = "Opaque" "RenderPipeline" = "UniversalPipeline" }

        Pass
        {
            HLSLPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : TEXCOORD1;
                float3 objectPosition : TEXCOORD2;
            };

            TEXTURE2D(_BaseMap);
            SAMPLER(sampler_BaseMap);

            CBUFFER_START(UnityPerMaterial)
                half4 _BaseColor;
                float4 _XColor;
                float4 _ZColor;
                float4 _BaseMap_ST;
            CBUFFER_END

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);
                OUT.uv = TRANSFORM_TEX(IN.uv, _BaseMap);
                OUT.normal = IN.normal;
                OUT.objectPosition = IN.positionOS.xyz;
                return OUT;
            }

            half4 frag(Varyings IN) : SV_Target
            {
                half4 color = 0;

                color = SAMPLE_TEXTURE2D(_BaseMap, sampler_BaseMap, IN.objectPosition.xz) * _BaseColor * pow(abs(dot(IN.normal,float3(0,1,0))),2);
                color += SAMPLE_TEXTURE2D(_BaseMap, sampler_BaseMap, IN.objectPosition.zy) * _XColor * pow(abs(dot(IN.normal,float3(1,0,0))),2);
                color += SAMPLE_TEXTURE2D(_BaseMap, sampler_BaseMap, IN.objectPosition.xy) * _ZColor * pow(abs(dot(IN.normal,float3(0,0,1))),2);

                return color;
            }
            ENDHLSL
        }
    }
}
