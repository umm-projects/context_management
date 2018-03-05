using System.Collections.Generic;

namespace UnityModule.ContextManagement {

    public static class ContextManager {

        private static Dictionary<string, ProjectContext> ProjectContextMap { get; set; } = new Dictionary<string, ProjectContext>();

        public static IProjectContext CurrentProject { get; set; }

        public static void RegisterProjectContextMap(Dictionary<string, ProjectContext> projectContextMap) {
            ProjectContextMap = projectContextMap;
        }

        public static void RegisterProjectContext(ProjectContext projectContext) {
            ProjectContextMap[projectContext.Name] = projectContext;
        }

    }

}