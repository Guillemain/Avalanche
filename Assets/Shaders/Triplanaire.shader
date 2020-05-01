Shader "Sol/Triplanaire"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0

        _TexHaut ("Texture haut", 2D) = "white" {}
        _TexCote ("Texture bas", 2D) = "white" {}
        _Thres ("Detection Threshold", Range(0, 1)) = 0.1
        _EdgeExponent("Edge Power", float) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _TexHaut;
        sampler2D _TexCote;

        struct Input
        {
            float2 uv_MainTex;
            float3 worldNormal; INTERNAL_DATA
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        half _Thres;
        half _EdgeExponent;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;

            //Calculs pour savoir quelle texture prendre

            // Albedo comes from a texture tinted by color
            float upValue = length(cross(float3(0, 1, 0), IN.worldNormal)); //plus c'est proche de 0, plus on est vers le haut
            upValue = pow(saturate(upValue - 2 * (_Thres - 0.5)), _EdgeExponent);
            //upValue = step(_Thres, upValue);
            fixed4 c = lerp(tex2D (_TexHaut, IN.uv_MainTex), tex2D (_TexCote, IN.uv_MainTex), upValue)  * _Color;
            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
