// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.35 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.35;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:32719,y:32712,varname:node_4013,prsc:2|diff-3447-OUT,spec-561-OUT,normal-155-RGB,emission-5652-OUT;n:type:ShaderForge.SFN_Color,id:1304,x:31545,y:32391,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_1304,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_NormalVector,id:4758,x:30083,y:32654,prsc:2,pt:True;n:type:ShaderForge.SFN_Multiply,id:6705,x:31770,y:32278,varname:node_6705,prsc:2|A-3278-RGB,B-1304-RGB;n:type:ShaderForge.SFN_Tex2d,id:3278,x:31545,y:32219,ptovrint:False,ptlb:Texture,ptin:_Texture,varname:node_3278,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Lerp,id:3447,x:32486,y:32307,varname:node_3447,prsc:2|A-6705-OUT,B-8360-OUT,T-4041-OUT;n:type:ShaderForge.SFN_Tex2d,id:155,x:32306,y:32843,ptovrint:False,ptlb:normalMap,ptin:_normalMap,varname:node_155,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Slider,id:4041,x:30449,y:33190,ptovrint:False,ptlb:RimOpacity,ptin:_RimOpacity,varname:node_4041,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:4;n:type:ShaderForge.SFN_Multiply,id:7283,x:31679,y:33294,varname:node_7283,prsc:2|A-7215-OUT,B-4041-OUT;n:type:ShaderForge.SFN_Tex2d,id:9529,x:32065,y:32711,ptovrint:False,ptlb:SpecMap,ptin:_SpecMap,varname:node_9529,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:561,x:32285,y:32687,varname:node_561,prsc:2|A-9529-RGB,B-6485-OUT;n:type:ShaderForge.SFN_Slider,id:6485,x:31908,y:32883,ptovrint:False,ptlb:SpecStrength,ptin:_SpecStrength,varname:node_6485,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_LightVector,id:1619,x:30083,y:32808,varname:node_1619,prsc:2;n:type:ShaderForge.SFN_Dot,id:4179,x:30320,y:32726,varname:node_4179,prsc:2,dt:3|A-4758-OUT,B-1619-OUT;n:type:ShaderForge.SFN_Fresnel,id:3059,x:30320,y:32890,varname:node_3059,prsc:2|EXP-1116-OUT;n:type:ShaderForge.SFN_Multiply,id:7215,x:30827,y:32770,varname:node_7215,prsc:2|A-4179-OUT,B-8212-OUT;n:type:ShaderForge.SFN_Slider,id:1116,x:29972,y:32983,ptovrint:False,ptlb:RimFalloff,ptin:_RimFalloff,varname:node_1116,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:10;n:type:ShaderForge.SFN_Add,id:8360,x:32165,y:32450,varname:node_8360,prsc:2|A-6705-OUT,B-7215-OUT;n:type:ShaderForge.SFN_Color,id:5482,x:30317,y:33042,ptovrint:False,ptlb:RimColor,ptin:_RimColor,varname:node_5482,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:8212,x:30530,y:32890,varname:node_8212,prsc:2|A-3059-OUT,B-5482-RGB;n:type:ShaderForge.SFN_Tex2d,id:1834,x:31396,y:32954,ptovrint:False,ptlb:EmissionMap (mask A),ptin:_EmissionMapmaskA,varname:node_1834,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Multiply,id:4185,x:32230,y:33132,varname:node_4185,prsc:2|A-320-OUT,B-8347-OUT;n:type:ShaderForge.SFN_Add,id:320,x:31948,y:33027,varname:node_320,prsc:2|A-6317-OUT,B-7283-OUT;n:type:ShaderForge.SFN_Multiply,id:6317,x:31679,y:33006,varname:node_6317,prsc:2|A-1834-RGB,B-1111-RGB;n:type:ShaderForge.SFN_Color,id:1111,x:31396,y:33130,ptovrint:False,ptlb:EmissionColor,ptin:_EmissionColor,varname:node_1111,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:8347,x:31679,y:33161,varname:node_8347,prsc:2|A-1834-A,B-1111-A;n:type:ShaderForge.SFN_Multiply,id:5652,x:32460,y:33028,varname:node_5652,prsc:2|A-3278-A,B-4185-OUT;proporder:3278-1304-9529-6485-155-5482-1116-4041-1834-1111;pass:END;sub:END;*/

Shader "Shader Forge/RimShader" {
    Properties {
        _Texture ("Texture", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        _SpecMap ("SpecMap", 2D) = "white" {}
        _SpecStrength ("SpecStrength", Range(0, 1)) = 0
        _normalMap ("normalMap", 2D) = "bump" {}
        _RimColor ("RimColor", Color) = (0.5,0.5,0.5,1)
        _RimFalloff ("RimFalloff", Range(0, 10)) = 0
        _RimOpacity ("RimOpacity", Range(0, 4)) = 0
        _EmissionMapmaskA ("EmissionMap (mask A)", 2D) = "black" {}
        _EmissionColor ("EmissionColor", Color) = (0.5,0.5,0.5,1)
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            Cull off

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _Color;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform sampler2D _normalMap; uniform float4 _normalMap_ST;
            uniform float _RimOpacity;
            uniform sampler2D _SpecMap; uniform float4 _SpecMap_ST;
            uniform float _SpecStrength;
            uniform float _RimFalloff;
            uniform float4 _RimColor;
            uniform sampler2D _EmissionMapmaskA; uniform float4 _EmissionMapmaskA_ST;
            uniform float4 _EmissionColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _normalMap_var = UnpackNormal(tex2D(_normalMap,TRANSFORM_TEX(i.uv0, _normalMap)));
                float3 normalLocal = _normalMap_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float4 _SpecMap_var = tex2D(_SpecMap,TRANSFORM_TEX(i.uv0, _SpecMap));
                float3 specularColor = (_SpecMap_var.rgb*_SpecStrength);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(i.uv0, _Texture));
                float3 node_6705 = (_Texture_var.rgb*_Color.rgb);
                float3 node_7215 = (abs(dot(normalDirection,lightDirection))*(pow(1.0-max(0,dot(normalDirection, viewDirection)),_RimFalloff)*_RimColor.rgb));
                float3 diffuseColor = lerp(node_6705,(node_6705+node_7215),_RimOpacity);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float4 _EmissionMapmaskA_var = tex2D(_EmissionMapmaskA,TRANSFORM_TEX(i.uv0, _EmissionMapmaskA));
                float3 emissive = (_Texture_var.a*(((_EmissionMapmaskA_var.rgb*_EmissionColor.rgb)+(node_7215*_RimOpacity))*(_EmissionMapmaskA_var.a*_EmissionColor.a)));
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _Color;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform sampler2D _normalMap; uniform float4 _normalMap_ST;
            uniform float _RimOpacity;
            uniform sampler2D _SpecMap; uniform float4 _SpecMap_ST;
            uniform float _SpecStrength;
            uniform float _RimFalloff;
            uniform float4 _RimColor;
            uniform sampler2D _EmissionMapmaskA; uniform float4 _EmissionMapmaskA_ST;
            uniform float4 _EmissionColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _normalMap_var = UnpackNormal(tex2D(_normalMap,TRANSFORM_TEX(i.uv0, _normalMap)));
                float3 normalLocal = _normalMap_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float4 _SpecMap_var = tex2D(_SpecMap,TRANSFORM_TEX(i.uv0, _SpecMap));
                float3 specularColor = (_SpecMap_var.rgb*_SpecStrength);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(i.uv0, _Texture));
                float3 node_6705 = (_Texture_var.rgb*_Color.rgb);
                float3 node_7215 = (abs(dot(normalDirection,lightDirection))*(pow(1.0-max(0,dot(normalDirection, viewDirection)),_RimFalloff)*_RimColor.rgb));
                float3 diffuseColor = lerp(node_6705,(node_6705+node_7215),_RimOpacity);
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
