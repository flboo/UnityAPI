using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class FindReferences
{
    [MenuItem("Assets/一键替换DDS的贴图")]
    public static void ToChangeMaterialsDDS()
    {
        //获取选中目录下的所有Material类型文件对象
        UnityEngine.Object[] m_objects = Selection.GetFiltered(typeof(Material), SelectionMode.DeepAssets);//选择的所有对象
        //遍历所有材质
        foreach (UnityEngine.Object item in m_objects)
        {
            if (Path.GetExtension(AssetDatabase.GetAssetPath(item)) != "")//判断路径是否为空
            {
                string path = AssetDatabase.GetAssetPath(item);
                string oldTextruePath = AssetDatabase.GetAssetPath(((Material)item).mainTexture);
                //判断材质的mainTexture是否为.dds格式
                if (AssetDatabase.GetAssetPath(((Material)item).mainTexture).Contains(".dds"))
                {
                    //如果为.dds格式，获取其同名.png文件路径
                    string newTextruePath = AssetDatabase.GetAssetPath(((Material)item).mainTexture).Replace(".dds", ".png");
                    if (Path.GetExtension(newTextruePath) != "")//判断同目录下是否有同名.png文件
                    {
                        //则将材质的mainTexture改为转换好的同目录下的.png格式贴图，编辑器模式下使用AssetDatabase.LoadAssetAtPath读取资源
                        ((Material)item).mainTexture = AssetDatabase.LoadAssetAtPath<Texture>(newTextruePath);
                        //替换成功后删除.dds格式的贴图文件
                        AssetDatabase.DeleteAsset(oldTextruePath);
                        Debug.Log(AssetDatabase.GetAssetPath(item) + "TextureName=" + AssetDatabase.GetAssetPath(((Material)item).mainTexture));
                    }
                }
            }
        }
        //保存并刷新资源
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }


    [MenuItem("Assets/Find References", false, 10)]
    static private void Find()
    {
        EditorSettings.serializationMode = SerializationMode.ForceText;
        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        if (!string.IsNullOrEmpty(path))
        {
            string guid = AssetDatabase.AssetPathToGUID(path);
            List<string> withoutExtensions = new List<string>() { ".prefab", ".unity", ".mat", ".asset" };
            string[] files = Directory.GetFiles(Application.dataPath, "*.*", SearchOption.AllDirectories)
                .Where(s => withoutExtensions.Contains(Path.GetExtension(s).ToLower())).ToArray();
            int startIndex = 0;

            EditorApplication.update = delegate ()
            {
                string file = files[startIndex];

                bool isCancel = EditorUtility.DisplayCancelableProgressBar("匹配资源中", file, (float)startIndex / (float)files.Length);

                if (Regex.IsMatch(File.ReadAllText(file), guid))
                {
                    Debug.Log(file, AssetDatabase.LoadAssetAtPath<Object>(GetRelativeAssetsPath(file)));
                }

                startIndex++;
                if (isCancel || startIndex >= files.Length)
                {
                    EditorUtility.ClearProgressBar();
                    EditorApplication.update = null;
                    startIndex = 0;
                    Debug.Log("匹配结束");
                }

            };
        }
    }

    [MenuItem("Assets/Find References", true)]
    static private bool VFind()
    {
        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        return (!string.IsNullOrEmpty(path));
    }

    static private string GetRelativeAssetsPath(string path)
    {
        return "Assets" + Path.GetFullPath(path).Replace(Path.GetFullPath(Application.dataPath), "").Replace('\\', '/');
    }
}