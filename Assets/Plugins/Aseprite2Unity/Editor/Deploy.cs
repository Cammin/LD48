using System.IO;
using UnityEditor;
using UnityEngine;

namespace Plugins.Aseprite2Unity.Editor
{
    internal static class Deploy
    {
        private static void DeployAseprite2Unity()
        {
            var path = string.Format("{0}/../../deploy/Aseprite2Unity.{1}.unitypackage", Application.dataPath, AsepriteImporter.Version);

            Directory.CreateDirectory(Path.GetDirectoryName(path));
            AssetDatabase.ExportPackage("Assets/Aseprite2Unity", path, ExportPackageOptions.Recurse);
        }
    }
}
