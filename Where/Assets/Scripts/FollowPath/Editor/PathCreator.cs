using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PathCreator : EditorWindow {

    public bool checkDestroy;
    public bool showButtons = true;
    public bool makingFromCurrent;

    public Vector3 lastPos;

    [SerializeField]
    PathFollow pathFollowRef;

    [SerializeField]
    GameObject unMadeFollow;

    [MenuItem("Path/Path Creator")]
    public static void ShowWindow()
    {
        GetWindow<PathCreator>("Path Creator");
    }


    void OnGUI()
    {
        EditorGUILayout.HelpBox("Please don't destroy nodes without pressing the button as it breaks the following system", MessageType.Error);
        if (!makingFromCurrent)
        {
            pathFollowRef = EditorGUILayout.ObjectField(pathFollowRef, typeof(PathFollow), true) as PathFollow;
        }
        if(pathFollowRef != null)
        {
            if(pathFollowRef.gameObject.GetComponent<RenderLines>() == null)
            {
                pathFollowRef.gameObject.AddComponent<RenderLines>();
            }
        }
        if (pathFollowRef == null && !makingFromCurrent)
        {
            EditorGUILayout.HelpBox("Please Insert The Object With The PathFollow Script Attached To It. Otherwise This Will Not Work", MessageType.Warning);
            if(GUILayout.Button("Create Ready Object"))
            {
                GameObject newObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                newObj.AddComponent<PathFollow>();
                newObj.name = "PathFollower";
                newObj.transform.position = Vector3.zero;
                pathFollowRef = newObj.transform.GetComponent<PathFollow>();
                Selection.activeGameObject = newObj;
            }
            if(GUILayout.Button("Create From Current Object"))
            {
                makingFromCurrent = true;
            }
        }
        if (makingFromCurrent)
        {
            unMadeFollow = EditorGUILayout.ObjectField(unMadeFollow, typeof(GameObject), true) as GameObject;
            if (unMadeFollow == null)
            {
                EditorGUILayout.HelpBox("Please Insert An Existing Object", MessageType.Info);
                if (GUILayout.Button("Go Back"))
                {
                    makingFromCurrent = false;
                }
            }
            if (unMadeFollow != null)
            {
                EditorGUILayout.HelpBox("Make Sure You Can See Your Object.", MessageType.Warning);
                if (GUILayout.Button("Create"))
                {
                    unMadeFollow.AddComponent<PathFollow>();
                    pathFollowRef = unMadeFollow.GetComponent<PathFollow>();
                    makingFromCurrent = false;
                }
                if (GUILayout.Button("Go Back"))
                {
                    makingFromCurrent = false;
                }
            }
        }
        else if (showButtons && pathFollowRef.gameObject.GetComponent<CharacterController>() != null)
        {
            if (GUILayout.Button("Create Node"))
            {
                if (pathFollowRef.oldNode == null)
                {
                    GameObject newNode = new GameObject();
                    newNode.name = "StartNode";
                    Selection.activeGameObject = newNode;
                    newNode.transform.position = pathFollowRef.gameObject.transform.position;
                    pathFollowRef.oldNode = newNode;
                    pathFollowRef.targetTrans.Add(newNode);

                }
                else if (pathFollowRef.oldNode != null)
                {
                    GameObject newNode = new GameObject();
                    if (newNode.GetComponent<Transform>() != null)
                    {
                        newNode.name = "PathNode";
                        Selection.activeGameObject = newNode;
                        newNode.transform.position = pathFollowRef.oldNode.transform.position;
                        pathFollowRef.oldNode = newNode;
                        pathFollowRef.targetTrans.Add(newNode);
                    }
                }
            }
            if (GUILayout.Button("Remove Nodes"))
            {
                checkDestroy = true;
                showButtons = false;
            }
            if (pathFollowRef.loop)
            {
                GUI.color = Color.green;
                if (GUILayout.Button("Loop"))
                {
                    pathFollowRef.loop = false;
                }
            }
            else
            {
                GUI.color = Color.red;
                if (GUILayout.Button("Loop"))
                {
                    pathFollowRef.loop = true;
                }
            }
            if (pathFollowRef.allowUpwardsMotion)
            {
                GUI.color = Color.green;
                if (GUILayout.Button("Allow Upwards Motion"))
                {
                    pathFollowRef.allowUpwardsMotion = false;
                }
            }
            else
            {
                GUI.color = Color.red;
                if (GUILayout.Button("Allow Upwards Motion"))
                {
                    pathFollowRef.allowUpwardsMotion = true;
                }
            }
            GUI.color = Color.white;
            GUILayout.BeginHorizontal();
            GUILayout.TextField("Detection Distance:");
            GUILayout.TextField(pathFollowRef.detectionRange.ToString());
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("-"))
            {
                pathFollowRef.detectionRange -= 0.1f;
            }
            if (GUILayout.Button("+"))
            {
                pathFollowRef.detectionRange += 0.1f;
            }
            pathFollowRef.detectionRange = Mathf.Clamp(pathFollowRef.detectionRange, 0.5f, 5.0f);
            GUILayout.EndHorizontal();
            if (pathFollowRef.detectionRange > 3.0f)
            {
                EditorGUILayout.HelpBox("That Is A High detection Range And May Give Wierd Results", MessageType.Warning);
            }
            GUILayout.BeginHorizontal();
            GUILayout.TextField("Speed:");
            GUILayout.TextField(pathFollowRef.speed.ToString());
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("-"))
            {
                pathFollowRef.speed -= 0.005f;
            }
            if (GUILayout.Button("+"))
            {
                pathFollowRef.speed += 0.005f;
            }
            GUILayout.EndHorizontal();
            if (pathFollowRef.speed > 1f)
            {
                EditorGUILayout.HelpBox("That Is A High Speed", MessageType.Warning);
                if (pathFollowRef.turnDamping < 7f)
                {
                    EditorGUILayout.HelpBox("You Have A High Speed And Damping Is Low, Meaning That the Follower Might Miss It's Target And Have to Turn Around", MessageType.Error);
                    GUILayout.Label("Recommended Speed: .04");
                    GUILayout.Label("Recommended Damping: 1");
                }
            }
            GUILayout.BeginHorizontal();
            GUILayout.TextField("Damping:");
            GUILayout.TextField(pathFollowRef.turnDamping.ToString());
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("-"))
            {
                pathFollowRef.turnDamping -= 0.05f;
            }
            if (GUILayout.Button("+"))
            {
                pathFollowRef.turnDamping += 0.05f;
            }
            GUILayout.EndHorizontal();
            if (GUILayout.Button("Reset Values"))
            {
                pathFollowRef.turnDamping = 1f;
                pathFollowRef.speed = 0.04f;
                pathFollowRef.detectionRange = 0.5f;
            }
            if (GUILayout.Button("Go Back"))
            {
                pathFollowRef = null;
            }
            if (Selection.activeGameObject != null)
            {
                if (Selection.activeGameObject.name == "PathNode")
                {
                    if (GUILayout.Button("Delete Selected Node"))
                    {
                        pathFollowRef.targetTrans.Remove(Selection.activeGameObject);
                        if (pathFollowRef.oldNode == Selection.activeGameObject)
                        {
                            pathFollowRef = null;
                        }
                        DestroyImmediate(Selection.activeGameObject);
                    }
                }
            }
        }
        else if (pathFollowRef.gameObject.GetComponent<CharacterController>() == null)
        {
            pathFollowRef.gameObject.AddComponent<CharacterController>();
        }
        if (checkDestroy)
        {
            GUILayout.Label("Are You Sure?", EditorStyles.boldLabel);
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Yes") && pathFollowRef.targetTrans.Count != 0)
            {
                foreach (GameObject currentTrans in pathFollowRef.targetTrans)
                {
                    DestroyImmediate(currentTrans);
                }
                pathFollowRef.targetTrans.Clear();
                pathFollowRef.oldNode = null;
                checkDestroy = false;
                showButtons = true;
            }
            if (GUILayout.Button("No"))
            {
                checkDestroy = false;
                showButtons = true;
            }
            GUILayout.EndHorizontal();
        }
    }
}
