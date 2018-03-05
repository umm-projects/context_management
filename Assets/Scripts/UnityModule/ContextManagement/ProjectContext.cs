using System;
using UnityEngine;

#pragma warning disable 649

namespace UnityModule.ContextManagement {

    public interface IProjectContext {

        string Name { get; }

        // 本来であれば extension method にしたいところだが、 il2cpp の AOT 制約により enum な extension method は NG なのでこちらに定義する
        string CreateSceneName<TEnum>(TEnum sceneName) where TEnum : struct;

    }

    public class ProjectContext : IProjectContext {

        [SerializeField]
        private string name;

        public string Name {
            get {
                return this.name;
            }
        }

        [SerializeField]
        private string sceneNamePrefix;

        private string SceneNamePrefix {
            get {
                return this.sceneNamePrefix;
            }
        }

        public string CreateSceneName<TEnum>(TEnum sceneName) where TEnum : struct {
            return string.Format("{0}{1}", this.SceneNamePrefix, sceneName.ToString());
        }

    }

    public static class ProjectContextExtension {

        public static TProjectContext As<TProjectContext>(this IProjectContext projectContext) where TProjectContext : class, IProjectContext {
            return projectContext as TProjectContext;
        }

    }

}