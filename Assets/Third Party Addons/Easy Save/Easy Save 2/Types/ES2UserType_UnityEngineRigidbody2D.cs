using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ES2UserType_UnityEngineRigidbody2D : ES2Type
{
	public override void Write(object obj, ES2Writer writer)
	{
		UnityEngine.Rigidbody2D data = (UnityEngine.Rigidbody2D)obj;
		// Add your writer.Write calls here.
writer.Write(data.position);
writer.Write(data.rotation);
writer.Write(data.velocity);
writer.Write(data.angularVelocity);
writer.Write(data.useAutoMass);
writer.Write(data.mass);
writer.Write(data.centerOfMass);
writer.Write(data.inertia);
writer.Write(data.drag);
writer.Write(data.angularDrag);
writer.Write(data.gravityScale);
writer.Write(data.bodyType);
writer.Write(data.useFullKinematicContacts);
writer.Write(data.isKinematic);
writer.Write(data.freezeRotation);
writer.Write(data.constraints);
writer.Write(data.simulated);
writer.Write(data.interpolation);
writer.Write(data.sleepMode);
writer.Write(data.collisionDetectionMode);
writer.Write(data.hideFlags);

	}
	
	public override object Read(ES2Reader reader)
	{
		UnityEngine.Rigidbody2D data = GetOrCreate<UnityEngine.Rigidbody2D>();
		Read(reader, data);
		return data;
	}

	public override void Read(ES2Reader reader, object c)
	{
		UnityEngine.Rigidbody2D data = (UnityEngine.Rigidbody2D)c;
		// Add your reader.Read calls here to read the data into the object.
data.position = reader.Read<UnityEngine.Vector2>();
data.rotation = reader.Read<System.Single>();
data.velocity = reader.Read<UnityEngine.Vector2>();
data.angularVelocity = reader.Read<System.Single>();
data.useAutoMass = reader.Read<System.Boolean>();
data.mass = reader.Read<System.Single>();
data.centerOfMass = reader.Read<UnityEngine.Vector2>();
data.inertia = reader.Read<System.Single>();
data.drag = reader.Read<System.Single>();
data.angularDrag = reader.Read<System.Single>();
data.gravityScale = reader.Read<System.Single>();
data.bodyType = reader.Read<UnityEngine.RigidbodyType2D>();
data.useFullKinematicContacts = reader.Read<System.Boolean>();
data.isKinematic = reader.Read<System.Boolean>();
data.freezeRotation = reader.Read<System.Boolean>();
data.constraints = reader.Read<UnityEngine.RigidbodyConstraints2D>();
data.simulated = reader.Read<System.Boolean>();
data.interpolation = reader.Read<UnityEngine.RigidbodyInterpolation2D>();
data.sleepMode = reader.Read<UnityEngine.RigidbodySleepMode2D>();
data.collisionDetectionMode = reader.Read<UnityEngine.CollisionDetectionMode2D>();
data.hideFlags = reader.Read<UnityEngine.HideFlags>();

	}
	
	/* ! Don't modify anything below this line ! */
	public ES2UserType_UnityEngineRigidbody2D():base(typeof(UnityEngine.Rigidbody2D)){}
}