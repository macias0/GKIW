using UnityEngine;
using System.Collections;


public class Matrix3D {

    public override string ToString()
    {
        string toReturn = "";
        for (int y = 0; y < 4; y++)
        {
            for (int x = 0; x < 4; x++)
                toReturn += this[y * 4 + x] + " ";
            toReturn += "\n";
        }
        return toReturn;
    }


    public float this[int i]
	{
		get
		{
			if(i >= 0 && i < 16 )
				return m_matrix[i];
			return 0;
		}

		set
		{
			if (i >= 0 && i < 16)
				m_matrix [i] = value;
		}

	}

	static public Matrix3D operator*(Matrix3D a_one, Matrix3D a_two)
	{
		Matrix3D result = new Matrix3D();
		for(int i=0; i<4; ++i)
		{
			for(int j=0; j<4; ++j)
			{
				for (int k = 0; k < 4; ++k) 
				{
					result[4 * i + j] +=   a_one[ i * 4 + k  ]  * a_two[ k * 4 + j];
				}
			}
		}

		return result;
	}

	static public Vector4 operator*(Matrix3D a_matrix, Vector4 a_vector)
	{
		Vector4 result = new Vector4();

		for(int i=0; i<4; ++i)
			for(int j=0; j<4; ++j)
				result[i] += a_matrix[ i * 4 + j] * a_vector[j];

		return result;
	}

	static public Matrix3D Translate(float a_x, float a_y, float a_z)
	{
		Matrix3D result = new Matrix3D();
		result[0] = 1;
		result[3] = a_x;
		result[5] = 1;
		result[7] = a_y;
		result[10] = 1;
		result[11] = a_z;
		result[15] = 1;
		return result;
	}

	static public Matrix3D Scale(float a_scaleX, float a_scaleY, float a_scaleZ)
	{
		Matrix3D result = new Matrix3D();
		result [0] = a_scaleX;
		result [5] = a_scaleY;
		result [10] = a_scaleZ;
		result [15] = 1;
		return result;
	}

	static public Matrix3D RotateX(float a_angle)
	{
		a_angle *= Mathf.Deg2Rad;

        Matrix3D result = new Matrix3D();
        result[0] = Mathf.Cos(a_angle);
        result[1] = -Mathf.Sin(a_angle);
        result[4] = Mathf.Sin(a_angle);
        result[5] = Mathf.Cos(a_angle);
        result[10] = result[15] = 1;
        return result;
	}

	static public Matrix3D RotateY(float a_angle)
	{
        a_angle *= Mathf.Deg2Rad;

        Matrix3D result = new Matrix3D();
        result[0] = 1;
        result[5] = Mathf.Cos(a_angle);
        result[6] = -Mathf.Sin(a_angle);
        result[9] = Mathf.Sin(a_angle);
        result[10] = Mathf.Cos(a_angle);
        result[15] = 1;
        return result;

    }

	static public Matrix3D RotateZ(float a_angle)
	{
        //Debug.Log("Dla kata " + a_angle + "stopni");
        a_angle *= Mathf.Deg2Rad;

        //Debug.Log("Wyszlo radianow: " + a_angle);

        Matrix3D result = new Matrix3D();
        result[0] = Mathf.Cos(a_angle);
        //Debug.Log("Cosinus kata: " + Mathf.Cos(a_angle));
        result[2] = Mathf.Sin(a_angle);
        result[5] = 1;
        result[8] = -Mathf.Sin(a_angle);
        result[10] = Mathf.Cos(a_angle);
        result[15] = 1;
        return result;

    }


	//macierz przeksztalcen dla 3D
	private float[] m_matrix = {0, 0, 0, 0,
								0, 0, 0, 0,
								0, 0, 0, 0,
								0, 0, 0, 0};
}
