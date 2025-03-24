using UnityEditor;
using UnityEngine;

namespace MyTools {
    /// <summary>
    /// Provides utility methods for managing version numbers in Unity projects.
    /// This class contains editor menu items for updating different version components
    /// and managing bundle version codes.
    /// </summary>
    public static class UpdateVersion {
        /// <summary>
        /// Increments the major version number and resets minor and patch to zero.
        /// Example: 1.2.3 -> 2.0.0
        /// </summary>
        [MenuItem("Tools/Update Version/Update Major Version")]
        public static void UpdateMajorVersion() {
            var currentVersion = Application.version;
            var versionParts = currentVersion.Split('.');
            var major = int.Parse(versionParts[0]);
            major += 1;
            PlayerSettings.bundleVersion = $"{major}.0.0";
        }

        /// <summary>
        /// Increments the minor version number and resets patch to zero.
        /// Example: 1.2.3 -> 1.3.0
        /// </summary>
        [MenuItem("Tools/Update Version/Update Minor Version")]
        public static void UpdateMinorVersion() {
            var currentVersion = Application.version;
            var versionParts = currentVersion.Split('.');
            var minor = int.Parse(versionParts[1]);
            minor += 1;
            PlayerSettings.bundleVersion = $"{versionParts[0]}.{minor}.0";
        }

        /// <summary>
        /// Increments the patch version number.
        /// Example: 1.2.3 -> 1.2.4
        /// </summary>
        [MenuItem("Tools/Update Version/Update Patch Version")]
        public static void UpdatePatchVersion() {
            var currentVersion = Application.version;
            var versionParts = currentVersion.Split('.');
            var patch = int.Parse(versionParts[2]);
            patch += 1;
            PlayerSettings.bundleVersion = $"{versionParts[0]}.{versionParts[1]}.{patch}";
        }

        /// <summary>
        /// Resets the version number to 0.0.1.
        /// Useful when starting a new project or major version reset is needed.
        /// </summary>
        [MenuItem("Tools/Update Version/Reset Version")]
        public static void ResetVersion() {
            PlayerSettings.bundleVersion = "0.0.1";
        }

        /// <summary>
        /// Increments the Android bundle version code.
        /// This is required for uploading new versions to the Google Play Store.
        /// </summary>
        [MenuItem("Tools/Update Version/Update Android Bundle Version Code")]
        public static void UpdateAndroidBundleVersionCode() {
            PlayerSettings.Android.bundleVersionCode++;
        }
    }
}