using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
// using Qarth;
using System.IO;
using UnityEditor.SceneManagement;

public class MeshCombine
{
    [MenuItem("Tools/CombineMesh")]
    static void CombineMesh()
    {
        Transform tSelect = Selection.activeTransform;
        if (!tSelect)
        {
            // Log.e("{0} is null! please check!", Selection.activeTransform.name);
            return;
        }

        if (tSelect.childCount < 1)
        {
            return;
        }

        if (!tSelect.GetComponent<MeshFilter>())
        {
            tSelect.gameObject.AddComponent<MeshFilter>();
        }

        if (!tSelect.GetComponent<MeshRenderer>())
        {
            tSelect.gameObject.AddComponent<MeshRenderer>();
        }

        MeshFilter[] tFilters = tSelect.GetComponentsInChildren<MeshFilter>();

        //根据所有MeshFilter组件的个数申请一个用于Mesh联合的类存储信息
        CombineInstance[] tCombiners = new CombineInstance[tFilters.Length];

        //遍历所有子物体的网格信息进行存储
        for (int i = 0; i < tFilters.Length; i++)
        {
            //记录网格
            tCombiners[i].mesh = tFilters[i].sharedMesh;
            //记录位置
            tCombiners[i].transform = tFilters[i].transform.localToWorldMatrix;
        }
        //新申请一个网格用于显示组合后的游戏物体
        Mesh tFinalMesh = new Mesh();
        //重命名Mesh
        tFinalMesh.name = "AutoCombineMesh";
        //调用Unity内置方法组合新Mesh网格
        tFinalMesh.CombineMeshes(tCombiners);
        //赋值组合后的Mesh网格给选中的物体
        tSelect.GetComponent<MeshFilter>().sharedMesh = tFinalMesh;
        //赋值新的材质
        tSelect.GetComponent<MeshRenderer>().material = AssetDatabase.LoadAssetAtPath("Assets/Res/FolderMode/Materials/CutMat.mat", typeof(Material)) as Material;
        tSelect.GetChild(0).gameObject.SetActive(false);

        //保存mesh
        string fullPath = "Assets/Res/FolderMode/Models/CombineMesh/HairMesh/";
        if (!Directory.Exists(fullPath))
        {
            Directory.CreateDirectory(fullPath);
        }

        Mesh mesh = Selection.activeTransform.GetComponent<MeshFilter>().sharedMesh;

        string path = Path.Combine(fullPath, Selection.activeTransform.name + ".asset");
        AssetDatabase.CreateAsset(mesh, path);
        AssetDatabase.Refresh();
        EditorSceneManager.MarkAllScenesDirty();
    }
}
