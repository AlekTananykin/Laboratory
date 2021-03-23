using Lab;
using System;
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace LabEditor
{
    public class GameLabWindow: EditorWindow
    {
        public GameObject _prefab;

        Vector2 _minaPosition;
        string _prefabPath;

        int _counter;

        private void OnGUI()
        {
            EditorGUILayout.LabelField(
                "Sow settings", EditorStyles.boldLabel);

            EditorGUILayout.Separator();
            _minaPosition = EditorGUILayout.Vector2Field("Mine Position", _minaPosition);
           
            EditorGUILayout.Separator();
            EditorGUILayout.LabelField("Prefab path");
            _prefabPath = EditorGUILayout.TextField(_prefabPath);

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
                EditorGUILayout.HelpBox(
                    "Prefab path is wrong. ", MessageType.Error);
                return;
            }

            GameObject go = Instantiate(_prefab);
            SetObjectDirty(go);

            go.transform.position = GetCoordinates(_minaPosition);

            CreateSO(string.Format(
                    "Assets/Resources/GameData/Mines/MineData{0}.asset", 
                    _counter++),
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

        private static void CreateSO(
            string soPath, string prefabPath, Vector3 position)
        {
            var asset = ScriptableObject.CreateInstance<BombData>();
            AssetDatabase.CreateAsset(asset, soPath);
            asset._position = position;
            asset._prefabPath = prefabPath;
            AssetDatabase.SaveAssets();

            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;
        }

        private void SetObjectDirty(GameObject obj)
        {
            if (!Application.isPlaying)
            {
                EditorUtility.SetDirty(obj);
                EditorSceneManager.MarkSceneDirty(obj.scene);
            }
        }
    }
}