using Lab;
using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace LabEditor
{
    public class GameLabWindow: EditorWindow
    {
        public GameObject _prefab;

        Vector2 _minaPosition;
        string _prefabPath;


        private void OnGUI()
        {
            EditorGUILayout.LabelField(
                "Sow settings", EditorStyles.boldLabel);

            EditorGUILayout.Separator();
            _minaPosition = EditorGUILayout.Vector2Field("Mine Position", _minaPosition);
           
            EditorGUILayout.Separator();

            //_prefab = EditorGUILayout.ObjectField("Object",
            //    _prefab, typeof(GameObject), true) as GameObject;

            EditorGUILayout.Separator();
            EditorGUILayout.LabelField("Prefab path");
            _prefabPath = EditorGUILayout.TextField(_prefabPath);

            //if (null == _prefab)
            //{
            //    EditorGUILayout.HelpBox("Mine prefab is abnsent. ", MessageType.Error);
            //    return;
            //}

            if (string.IsNullOrEmpty(_prefabPath))
            {
                EditorGUILayout.HelpBox("Prefab path is absent", MessageType.Error);
                return;
            }

            if (GUILayout.Button("SetMine"))
            {
                try
                {
                    CreateBameObject(_minaPosition, _prefabPath);
                }
                catch (Exception e)
                {
                    EditorGUILayout.HelpBox(e.Message, MessageType.Error);
                }
            }        
        }

        private void CreateBameObject(Vector3 position, string prefabPath)
        {
            if (null == _prefab)
            {
                string path = Path.Combine(
                    Path.GetDirectoryName(prefabPath),
                    Path.GetFileNameWithoutExtension(prefabPath));

                _prefab = (GameObject)Resources.Load(path);
            }

            if (null == _prefab)
            {
                EditorGUILayout.HelpBox("Prefab path is wrong. ", MessageType.Error);
                return;
            }

            GameObject go = Instantiate(_prefab);
            

            go.transform.position = GetCoordinates(_minaPosition);

            CreateSO("Assets/Resources/GameData/Mines/MineData.asset",
                prefabPath,
                go.transform.position);
        }

        private Vector3 GetCoordinates(Vector2 minaPosition)
        {

            Ray ray = new Ray(new Vector3(minaPosition.x, 100f, minaPosition.y),
                new Vector3(0, -1f, 0));


            if (Physics.Raycast(ray, out RaycastHit hit))
                return hit.point;

            throw new Exception("Point can't be achived. ");
        }

        private static void CreateSO(string soPath, string prefabPath, Vector3 position)
        {
            var asset = ScriptableObject.CreateInstance<BombData>();
            AssetDatabase.CreateAsset(asset, soPath);
            asset._position = position;
            asset._prefabPath = prefabPath;
            AssetDatabase.SaveAssets();

            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;
        }
    }
}