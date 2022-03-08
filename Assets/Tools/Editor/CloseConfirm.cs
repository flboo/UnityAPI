using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


namespace GameWish.Game
{
    public class CloseConfirm : MonoBehaviour
    {
        [InitializeOnLoadMethod]
        static void InitializeOnLoadMethod()
        {
            EditorApplication.wantsToQuit -= Quit;
            EditorApplication.wantsToQuit += Quit;
        }

        static bool Quit()
        {
            return EditorUtility.DisplayDialog("退出确认", "确认要关闭Unity编辑器吗？", "确认", "取消");
        }
    }

}