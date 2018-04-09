using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		a += speed * Time.deltaTime * 10;

		transform.position =
			(Vector3)(
				//Matrix3D.RotateZ(angle) *
				//Matrix3D.Translate(r, 0, 0) *
				GetMatrix() *
				new Vector4(0, 0, 0, 1));
	}


	public Matrix4x4 GetMatrix() //zwraca macierz transformacji
	{
		if (!center)
			return Matrix4x4.Translate(new Vector3(transform.position.x, transform.position.y, transform.position.z));
		//Debug.Log ("GetRotationMatrix: \n" + center.GetRotationMatrix ());
		//return center.GetMatrix() * center.GetRotationMatrix() * Matrix3D.RotateZ(angle) * Matrix3D.Translate(r * scale, 0, r / scale) ;
		return center.GetMatrix() * Matrix4x4.Rotate(Quaternion.AngleAxis(angle, Vector3.forward)) * center.GetRotationMatrix()  * Matrix4x4.Translate(new Vector3(r * Mathf.Cos(Mathf.Deg2Rad * a) * scale, 0, r * Mathf.Sin(Mathf.Deg2Rad * a) ));
	}


	public Matrix4x4 GetRotationMatrix()
	{
		//Debug.Log ("xyz: " + transform.eulerAngles.x + ", " + transform.eulerAngles.y + ", " + transform.eulerAngles.z);
		return Matrix4x4.Rotate(transform.rotation);//Matrix4x4.RotateX(transform.eulerAngles.x) * Matrix4x4.RotateY(transform.eulerAngles.y) * Matrix4x4.RotateZ(transform.eulerAngles.z);
	}


	public Rotation2 center = null;
	public float r = 4.0f;
	public float speed;
	public float scale = 1.0f;
	public float angle = 0.0f;

	private float a = 0;
}
