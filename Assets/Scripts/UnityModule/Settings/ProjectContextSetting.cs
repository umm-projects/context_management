using UnityEngine;
using UnityModule.ContextManagement;

namespace UnityModule.Settings
{
    public class ProjectContextSetting : Setting<ProjectContextSetting>, IProjectContext
    {
        [SerializeField] private string projectName;
        [SerializeField] private string sceneNamePrefix;
        [SerializeField] private string namespacePrefix;

        public string Name => projectName;

        public string SceneNamePrefix => sceneNamePrefix;

        public string NamespacePrefix => namespacePrefix;

        public string CreateSceneName<TEnum>(TEnum sceneName) where TEnum : struct
        {
            return $"{SceneNamePrefix.TrimEnd('_')}_{sceneName.ToString()}";
        }

#if UNITY_EDITOR
        [UnityEditor.MenuItem("Assets/Create/Settings/ProjectContext")]
        public static void CreateSettingAsset()
        {
            if (!SettingContainer.Instance.Exists<ProjectContextListSetting>())
            {
                ProjectContextListSetting.CreateSettingAsset();
            }
            SettingContainer.Instance.Get<ProjectContextListSetting>().Add(CreateAsset());
            UnityEditor.AssetDatabase.SaveAssets();
        }
#endif
    }
}