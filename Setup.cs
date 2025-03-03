using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
using static System.IO.Directory;

namespace LorenzTools {
    public static class Setup {
        [MenuItem("Tools/Setup/Create Default Folders")]
        public static void CreateDefaultFolders() {
            Folders.CreateDefault("_Project", "Animations",
                "Art",
                "Materials",
                "ScriptableObjects",
                "_Scripts",
                "Settings",
                "Prefabs",
                "Scenes"
            );
            Folders.CreateDefault("External");
            Folders.CreateDefault("Plugins");
        }

        [MenuItem("Tools/Setup/Install My Favorite Open Source")]
        public static void InstallOpenSource() {
            Packages.InstallPackages(new[] {
                "git+https://github.com/KyleBanks/scene-ref-attribute",
                "git+https://github.com/UnityCommunity/UnitySingleton.git"
                // Add more
            });
        }

        private static class Folders {
            public static void CreateDefault(string root, params string[] folders) {
                var fullPath = Path.Combine(Application.dataPath, root);
                foreach (string folder in folders) {
                    var path = Path.Combine(fullPath, folder);
                    if (!Exists(path)) {
                        CreateDirectory(path);
                    }
                }
            }
        }

        private static class Packages {
            static AddRequest Request;
            static Queue<string> PackagesToInstall = new();

            public static void InstallPackages(string[] packages) {
                foreach (var package in packages) {
                    PackagesToInstall.Enqueue(package);
                }

                // Start the installation of the first package
                if (PackagesToInstall.Count > 0) {
                    Request = Client.Add(PackagesToInstall.Dequeue());
                    EditorApplication.update += Progress;
                }
            }

            static async void Progress() {
                if (Request.IsCompleted) {
                    if (Request.Status == StatusCode.Success)
                        Debug.Log("Installed: " + Request.Result.packageId);
                    else if (Request.Status >= StatusCode.Failure)
                        Debug.Log(Request.Error.message);

                    EditorApplication.update -= Progress;

                    // If there are more packages to install, start the next one
                    if (PackagesToInstall.Count > 0) {
                        // Add delay before next package install
                        await Task.Delay(1000);
                        Request = Client.Add(PackagesToInstall.Dequeue());
                        EditorApplication.update += Progress;
                    }
                }
            }
        }
    }
}