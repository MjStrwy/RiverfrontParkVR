// Based on the Unity Unlit shader
// disables culling and reverses texture coordinates
Shader "DoubleSided" {
Properties{
_MainTex("Base (RGB)", 2D) = "white" {}
}
SubShader{
Tags{ "RenderType" = "Opaque" }
Cull Off // instead of cull back
LOD 100
Pass{
CGPROGRAM

#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"
struct appdata_t {
float4 vertex : POSITION;
float2 texcoord : TEXCOORD0;
};
struct v2f {
float4 vertex : SV_POSITION;
half2 texcoord : TEXCOORD0;
};
sampler2D _MainTex;
float4 _MainTex_ST;
v2f vert(appdata_t v)
{
v2f o;
o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
// flip the texture coordinates
v.texcoord.x = 1 - v.texcoord.x;
o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
return o;
}
fixed4 frag(v2f i) : SV_Target
{
fixed4 col = tex2D(_MainTex, i.texcoord);
return col;
}
ENDCG
}
}
}