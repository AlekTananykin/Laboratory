using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace LabEditor
{
    public class LaboratoryMenu
    {
        [MenuItem("Laboratory/CreateWindow")]
        private static void CreateMenuWindow()
        {
            EditorWindow.GetWindow(typeof(GameLabWindow), false, "Laboratory");
        }
    }
}