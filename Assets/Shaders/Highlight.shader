Shader "Cg projector shader for adding color" {
   Properties {
      _EdgeColor ("Edge color", Color) = (1,1,0,1)
      _FillColor ("Fill color", Color) = (0,0,1,1)
      _Width ("Width", float) = 0.1
   }
   SubShader {
      Pass {      
         Blend SrcAlpha OneMinusSrcAlpha 
         ZWrite Off 
         Offset -1, -1 

         CGPROGRAM
 
         #pragma vertex vert  
         #pragma fragment frag 
 
         uniform float4 _EdgeColor; 
         uniform float _Width; 
         uniform float4 _FillColor;
 
         uniform float4x4 unity_Projector; 
 
          struct vertexInput {
            float4 vertex : POSITION;
            float3 normal : NORMAL;
         };
         struct vertexOutput {
            float4 pos : SV_POSITION;
            float4 posProj : TEXCOORD0;
         };
 
         vertexOutput vert(vertexInput input) 
         {
            vertexOutput output;
 
            output.posProj = mul(unity_Projector, input.vertex) + float4(-0.5,-0.5,0,0);
            output.posProj.x *= 2;
            output.posProj.y *= 2;
            output.pos = UnityObjectToClipPos(input.vertex);
            return output;
         }
 
 
         float4 frag(vertexOutput input) : COLOR
         {
            float r = length(input.posProj.xyz);
            float start = 1 - _Width / 2;
            float end = 1 + _Width / 2;
            float curve = clamp((start - r) * (end - r) / ((end - 1) * (start - 1)), 0, 1);
            float blendAmount = clamp((1 - r) / _Width, 0, 1);
            float overallAlpha = curve + clamp((1 - r) * 100, 0, 1);
            float4 color = _FillColor * blendAmount + _EdgeColor * (1 - blendAmount);
            return float4(color.rgb, color.a * overallAlpha);
         }
 
         ENDCG
      }
   }  
   Fallback "Projector/Light"
}