using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

	// Use this for initialization
	void Start () {


		Debug.Log ("Przes * Obrot\n" + Matrix3D.Translate (-2, 0, 0) * Matrix3D.RotateX (90) * new Vector4(0, 0, 0, 1));
		Debug.Log("Obrot * Przes\n" + Matrix3D.RotateX(90) * Matrix3D.Translate(-2, 0, 0) * new Vector4(0, 0, 0, 1));
  //      Matrix3D parent = Matrix3D.Translate(5, 0, 5);

//        Matrix3D przes = Matrix3D.Translate(5, 0, 0);

        //Debug.Log("Przes: \n" + przes);
       
//        for(int a=0; a<360; a+=90)
//        {
//            Matrix3D rot = Matrix3D.RotateZ(a);
//            Matrix3D x = rot * przes;
//            Debug.Log("Dla a="+a+" x=\n" + x);
//            Debug.Log("Rot*przes:\n" + (rot * przes));
//            Debug.Log("Po parencie: \n" + parent  * rot * przes);
//            Debug.Log("Inny pomysl: \n" +   przes * (rot * parent)  );
//        }


    }
	
	// Update is called once per frame
	void Update () {

//        matrix = Matrix3D.Translate(transform.position.x, transform.position.y, transform.position.z);
	


        angle += speed * Time.deltaTime * 10;

        transform.position =
            (Vector3)(
            //Matrix3D.RotateZ(angle) *
            //Matrix3D.Translate(r, 0, 0) *
            GetMatrix() *
            new Vector4(0, 0, 0, 1));
//		if(center)
//			Debug.Log("Distance: " + Vector3.Distance(transform.position, center.transform.position));
	}

    public Matrix3D GetMatrix() //zwraca macierz transformacji
    {
        if (!center)
            return Matrix3D.Translate(transform.position.x, transform.position.y, transform.position.z);
		//Debug.Log ("GetRotationMatrix: \n" + center.GetRotationMatrix ());
		//return center.GetMatrix() * center.GetRotationMatrix() * Matrix3D.RotateZ(angle) * Matrix3D.Translate(r * scale, 0, r / scale) ;
		return center.GetMatrix() * center.GetRotationMatrix() * Matrix3D.Translate(r * Mathf.Cos(Mathf.Deg2Rad * angle) * scale, 0, r * Mathf.Sin(Mathf.Deg2Rad * angle) );
	}

    public Matrix3D GetRotationMatrix()
    {
		//Debug.Log ("xyz: " + transform.eulerAngles.x + ", " + transform.eulerAngles.y + ", " + transform.eulerAngles.z);
		return  Matrix3D.RotateZ(transform.eulerAngles.z) * Matrix3D.RotateY(transform.eulerAngles.y) * Matrix3D.RotateX(transform.eulerAngles.x) ;
    }


    public Rotation center = null;
    public float r = 4.0f;
    public float speed;
    public float scale = 1.0f;

    private float angle = 0;

    //public Matrix3D matrix = new Matrix3D();
}
