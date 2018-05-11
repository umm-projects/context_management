using System.Collections.Generic;
using JetBrains.Annotations;

namespace UnityModule.ContextManagement
{
    [PublicAPI]
    public static class ContextManager
    {
        private static Dictionary<string, ProjectContext> projectContextMap;

        private static Dictionary<string, ProjectContext> ProjectContextMap
        {
            get
            {
                if (projectContextMap == default(Dictionary<string, ProjectContext>))
                {
                    projectContextMap = new Dictionary<string, ProjectContext>();
                }

                return projectContextMap;
            }
            set { projectContextMap = value; }
        }

        public static IProjectContext CurrentProject { get; set; }

        // ReSharper disable once ParameterHidesMember
        public static void RegisterProjectContextMap(Dictionary<string, ProjectContext> projectContextMap)
        {
            ProjectContextMap = projectContextMap;
        }

        public static void RegisterProjectContext(ProjectContext projectContext)
        {
            ProjectContextMap[projectContext.Name] = projectContext;
        }
    }
}