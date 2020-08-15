Shader "Hidden/Custom/CRT"
{
    HLSLINCLUDE

        #include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"

        TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);
        float4 _MainTex_TexelSize;
        float _Blend;
        float _BandHeightMultiplier;
        float _BandScrollSpeed;

        float4 Frag(VaryingsDefault i) : SV_Target
        {
            float4 color = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord);
            float y = i.texcoord.y*_MainTex_TexelSize.z;
            float time = _Time.y;
            float rgbMultiplier = sin(y*_BandHeightMultiplier+time*_BandScrollSpeed);
            color.rgb = lerp(color.rgb, rgbMultiplier.xxx, _Blend.xxx);
            return color;
        }

    ENDHLSL

    SubShader
    {
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            HLSLPROGRAM

                #pragma vertex VertDefault
                #pragma fragment Frag

            ENDHLSL
        }
    }
}