Shader "UI/TextureIrisWipe"
{
    Properties
    {
        _MainTex ("Mask Texture", 2D) = "white" {}
        _Color ("Wipe Color", Color) = (0,0,0,1)
        _Scale ("Scale", Range(0.001, 5)) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Overlay" }
        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _Color;
            float _Scale;

            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Центрируем UV и масштабируем их
                // UV_new = (UV - 0.5) / Scale + 0.5
                float2 centeredUV = i.uv - 0.5;
                
                // Коррекция аспекта (необязательно, если картинка маски уже под экран)
                centeredUV.x *= _ScreenParams.x / _ScreenParams.y;
                
                float2 scaledUV = centeredUV / _Scale + 0.5;

                fixed4 maskCol = fixed4(0,0,0,0);

                // Проверяем, не вышли ли мы за границы [0, 1] после масштабирования
                if (scaledUV.x >= 0 && scaledUV.x <= 1 && scaledUV.y >= 0 && scaledUV.y <= 1)
                {
                    maskCol = tex2D(_MainTex, scaledUV);
                }

                // Инвертируем маску: где в текстуре есть прозрачность (или белый), 
                // там мы показываем сцену. Где нет — заливаем _Color.
                // В данном примере считаем, что через маску (alpha=1) видно сцену.
                float finalAlpha = (1.0 - maskCol.a) * _Color.a;

                return fixed4(_Color.rgb, finalAlpha);
            }
            ENDCG
        }
    }
}