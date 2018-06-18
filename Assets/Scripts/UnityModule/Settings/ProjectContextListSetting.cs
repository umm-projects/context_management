using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityModule.ContextManagement;

namespace UnityModule.Settings
{
    public class ProjectContextListSetting : Setting<ProjectContextListSetting>
    {
        [SerializeField] private List<ProjectContextSetting> list = new List<ProjectContextSetting>();

        private IEnumerable<ProjectContextSetting> List => list;

        private void OnEnable()
        {
            ContextManager.CurrentProject = List?.FirstOrDefault();
        }

        public void Add(ProjectContextSetting projectContextSetting)
        {
            list.Add(projectContextSetting);
        }

#if UNITY_EDITOR
        public static void CreateSettingAsset()
        {
            SettingContainer.Instance.Add(CreateAsset(true));
        }
#endif
    }
}
