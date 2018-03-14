using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Matrix3D parent = Matrix3D.Translate(5, 0, 5);

        Matrix3D przes = Matrix3D.Translate(5, 0, 0);

        //Debug.Log("Przes: \n" + przes);
       
        for(int a=0; a<360; a+=90)
        {
            Matrix3D rot = Matrix3D.RotateZ(a);
            Matrix3D x = rot * przes;
            Debug.Log("Dla a="+a+" x=\n" + x);
            Debug.Log("Rot*przes:\n" + (rot * przes));
            Debug.Log("Po parencie: \n" + parent  * rot * przes);
            Debug.Log("Inny pomysl: \n" +   przes * (rot * parent)  );
        }


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
	}

    public Matrix3D GetMatrix() //zwraca macierz transformacji
    {
        if (!center)
            return Matrix3D.Translate(transform.position.x, transform.position.y, transform.position.z);

        return center.GetMatrix() * Matrix3D.RotateZ(angle) * Matrix3D.Translate(r, 0, 0) * center.GetRotationMatrix();
    }

    public Matrix3D GetRotationMatrix()
    {
        return Matrix3D.RotateX(transform.rotation.x) * Matrix3D.RotateY(transform.rotation.y) * Matrix3D.RotateZ(transform.rotation.z);
    }


    public Rotation center = null;
    public float r;
    public float speed;
    public float scale;

    private float angle = 0;

    //public Matrix3D matrix = new Matrix3D();
}
