using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ES2UserType_UnityEngineMeshRenderer : ES2Type
{
	public override void Write(object obj, ES2Writer writer)
	{
		UnityEngine.MeshRenderer data = (UnityEngine.MeshRenderer)obj;
		// Add your writer.Write calls here.
writer.Write(data.enabled);
writer.Write(data.shadowCastingMode);
writer.Write(data.receiveShadows);
writer.Write(data.lightmapIndex);
writer.Write(data.realtimeLightmapIndex);
writer.Write(data.lightmapScaleOffset);
writer.Write(data.motionVectorGenerationMode);
writer.Write(data.realtimeLightmapScaleOffset);
writer.Write(data.lightProbeUsage);
writer.Write(data.reflectionProbeUsage);
writer.Write(data.sortingLayerID);
writer.Write(data.sortingOrder);
writer.Write(data.hideFlags);

	}
	
	public override object Read(ES2Reader reader)
	{
		UnityEngine.MeshRenderer data = GetOrCreate<UnityEngine.MeshRenderer>();
		Read(reader, data);
		return data;
	}

	public override void Read(ES2Reader reader, object c)
	{
		UnityEngine.MeshRenderer data = (UnityEngine.MeshRenderer)c;
		// Add your reader.Read calls here to read the data into the object.
data.enabled = reader.Read<System.Boolean>();
data.shadowCastingMode = reader.Read<UnityEngine.Rendering.ShadowCastingMode>();
data.receiveShadows = reader.Read<System.Boolean>();
data.lightmapIndex = reader.Read<System.Int32>();
data.realtimeLightmapIndex = reader.Read<System.Int32>();
data.lightmapScaleOffset = reader.Read<UnityEngine.Vector4>();
data.motionVectorGenerationMode = reader.Read<UnityEngine.MotionVectorGenerationMode>();
data.realtimeLightmapScaleOffset = reader.Read<UnityEngine.Vector4>();
data.lightProbeUsage = reader.Read<UnityEngine.Rendering.LightProbeUsage>();
data.reflectionProbeUsage = reader.Read<UnityEngine.Rendering.ReflectionProbeUsage>();
data.sortingLayerID = reader.Read<System.Int32>();
data.sortingOrder = reader.Read<System.Int32>();
data.hideFlags = reader.Read<UnityEngine.HideFlags>();

	}
	
	/* ! Don't modify anything below this line ! */
	public ES2UserType_UnityEngineMeshRenderer():base(typeof(UnityEngine.MeshRenderer)){}
}