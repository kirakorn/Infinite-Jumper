using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ES2UserType_UnityEngineBoxCollider2D : ES2Type
{
	public override void Write(object obj, ES2Writer writer)
	{
		UnityEngine.BoxCollider2D data = (UnityEngine.BoxCollider2D)obj;
		// Add your writer.Write calls here.
writer.Write(data.size);
writer.Write(data.density);
writer.Write(data.isTrigger);
writer.Write(data.usedByEffector);
writer.Write(data.offset);
writer.Write(data.enabled);
writer.Write(data.hideFlags);

	}
	
	public override object Read(ES2Reader reader)
	{
		UnityEngine.BoxCollider2D data = GetOrCreate<UnityEngine.BoxCollider2D>();
		Read(reader, data);
		return data;
	}

	public override void Read(ES2Reader reader, object c)
	{
		UnityEngine.BoxCollider2D data = (UnityEngine.BoxCollider2D)c;
		// Add your reader.Read calls here to read the data into the object.
data.size = reader.Read<UnityEngine.Vector2>();
data.density = reader.Read<System.Single>();
data.isTrigger = reader.Read<System.Boolean>();
data.usedByEffector = reader.Read<System.Boolean>();
data.offset = reader.Read<UnityEngine.Vector2>();
data.enabled = reader.Read<System.Boolean>();
data.hideFlags = reader.Read<UnityEngine.HideFlags>();

	}
	
	/* ! Don't modify anything below this line ! */
	public ES2UserType_UnityEngineBoxCollider2D():base(typeof(UnityEngine.BoxCollider2D)){}
}