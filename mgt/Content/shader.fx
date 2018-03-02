sampler s0;

texture texMask;
SamplerState texSampler
{
	Texture = (texMask); 
};

float4 PixelShaderFunction(float2 coords: TEXCOORD0) : COLOR0
{
	float4 color = tex2D(s0, coords);
	float4 texColor = tex2D(texSampler, coords);
	if (color.a)
		return color * texColor;
	return color;
	//return color * texColor;
}


technique Technique1
{
	pass Pass1
	{
		PixelShader = compile ps_2_0 PixelShaderFunction();
	}
}