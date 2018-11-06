using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTriangle : MonoBehaviour {

    //컴포넌트 변수
    //매쉬필터
    MeshFilter meshFilter;
    //매쉬
    Mesh mesh;
    //매쉬 렌더러가 없으면 화면에 렌더링되지 않음.
    MeshRenderer meshRenderer;
    Material mat;

    //시작할때 객체 생성함
    private void Awake()
    {
        //인스턴스를 붙여준다
        meshFilter = gameObject.AddComponent<MeshFilter>();
        meshRenderer = gameObject.AddComponent<MeshRenderer>();
    }

    // Use this for initialization
    void Start () {
        //버텍스 리스트를 만들어준다
        Vector3[] vert =
        {
            new Vector3(0.0f, 1.0f, 0.0f),
            new Vector3(1.0f,0.0f , 0.0f),
            new Vector3(-1.0f, 0.0f, 0.0f),
        };

        int[] triangles =
        {
            0, 1, 2
        };

        Color[] color =
        {
            Color.red,Color.blue,Color.green
        };

        //노멀 계산
        //삼각형 표면은 모두 같은 법선 백터를 가진다.
        //법선 계산
        Vector3 _u = vert[1] - vert[0];
        Vector3 _v = vert[2] - vert[0];
        Vector3 _normal = Vector3.Cross(_u, _v);
        //노멀라이즈한다.
        _normal.Normalize();

        Vector3[] nomals = new Vector3[vert.Length];
        
        for(int i = 0; i< nomals.Length; i++)
        {
            nomals[i] = _normal;
        }


        //매쉬 생성
        mesh = new Mesh();
        mesh.vertices = vert;
        mesh.triangles = triangles;
        mesh.colors = color;
        mesh.normals = nomals;

        //매쉬 필터에 적용
        meshFilter.mesh = mesh;
        
        foreach (var item in mesh.normals)
        {
            Debug.Log(item.ToString());
        }

        //머티리얼 적용
        mat = new Material(Shader.Find("Custom/BasicShader"));
        meshRenderer.material = mat;        
	}
}
