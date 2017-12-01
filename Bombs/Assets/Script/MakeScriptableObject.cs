using UnityEngine;
using System.Collections;
using UnityEditor;

//This class helps us make scriptable objects
public class MakeScriptableObject
{
    [MenuItem("Assets/Create/Database")]
    public static void CreateDatabaseAsset()
    {
        Database database = ScriptableObject.CreateInstance<Database>();
        AssetDatabase.CreateAsset(database, "Assets/Resources/Database.asset");
        AssetDatabase.SaveAssets();
    }
}