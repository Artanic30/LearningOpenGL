#version 330 core
out vec4 FragColor;

in vec2 TexCoord;

uniform vec3 objectColor;
uniform vec3 lightColor;

void main()
{
	// linearly interpolate between both textures (80% container, 20% awesomeface)
	FragColor = vec4(lightColor * objectColor, 1.0);
}