using System;
using System.Text.RegularExpressions;

namespace Fezitor.Model
{
    abstract class ModelAttribute : Attribute
    {
        private readonly string name;
        public string Name { get { return name; } }

        public ModelAttribute(string name = null)
        {
            if (name != null)
                this.name = Regex.Replace(name, "[.]", "");
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    class ModelStructureAttribute : ModelAttribute
    {
        public ModelStructureAttribute(string name = null) : base(name) { }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    class ModelPropertyAttribute : ModelAttribute
    {
        public ModelPropertyAttribute(string name = null) : base(name) { }
    }

    class ModelCollectionAttribute : ModelPropertyAttribute
    {
        public ModelCollectionAttribute(string name = null) : base(name) { }
    }

    class AppSettingAttribute : ModelPropertyAttribute
    {
        private readonly string settingName;
        public string SettingName { get { return settingName; } }

        public AppSettingAttribute(string name, string settingName = null)
            : base(name)
        {
            this.settingName = settingName != null ? settingName : name;
        }
    }
}
