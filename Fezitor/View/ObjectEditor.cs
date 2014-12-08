using Fezitor.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fezitor.View
{
    partial class ObjectEditor<T> : Form where T : class
    {
        public class TypeBehaviors
        {
            public enum Behavior { EditString, Expand, Disable, Ignore }

            public delegate string ObjectToString(object obj);
            public delegate object ObjectFromString(string str);
            public delegate bool IsValidObjectString(string str);

            private readonly Dictionary<Type, Behavior> behaviors = new Dictionary<Type, Behavior>();

            public Behavior GetBehavior(Type type)
            {
                throw new NotImplementedException();
            }

            public string GetString(object obj)
            {
                throw new NotImplementedException();
            }

            public object GetObject(string str)
            {
                throw new NotImplementedException();
            }
        }

        private class Property
        {
            public readonly string Name, VariableName;
            public readonly Type Type;
            public readonly bool IsCollection;
            public readonly ModelPropertyAttribute Attribute;
            public readonly Property Parent;

            public Property(string name, string variableName, Type type, bool isCollection, ModelPropertyAttribute attribute, Property parent)
            {
                Name = name; VariableName = variableName;
                this.Type = type;
                IsCollection = isCollection;
                Attribute = attribute;
                Parent = parent;
            }
        }

        private static readonly SortedDictionary<string, Property> properties = new SortedDictionary<string, Property>();
        private readonly Dictionary<string, object> startValue = new Dictionary<string, object>();

        private TypeBehaviors defaultTypeBehaviors;
        public TypeBehaviors DefaultTypeBehaviors
        {
            get { return defaultTypeBehaviors; }
            set
            {
                defaultTypeBehaviors = value != null ? value : new TypeBehaviors();
                Redraw();
            }
        }

        public T Result { get; private set; }

        static ObjectEditor()
        {
            ForEachProperty(typeof(T), (p) => SetProperty(p));
        }

        public ObjectEditor(T startValue = null, TypeBehaviors defaultTypeBehaviors = null)
        {
            this.defaultTypeBehaviors = defaultTypeBehaviors != null ? defaultTypeBehaviors : new TypeBehaviors();

            InitializeComponent();
            SetStartValue(startValue);
        }

        public void SetStartValue(T startValue)
        {
            this.startValue.Clear();
            if (startValue != null)
            {
                // TODO
                throw new NotImplementedException();
            }
            Reset();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            this.startValue.Clear();
            Redraw();
        }

        private void SetStartValueProperty(MemberInfo property)
        {
            throw new NotImplementedException();
        }

        private void Redraw()
        {
            throw new NotImplementedException();
        }

        private static void ForEachProperty(Type type, Action<MemberInfo> action)
        {
            foreach (MemberInfo prop in type.GetFields())
                action(prop);
            foreach (MemberInfo prop in type.GetProperties())
                action(prop);
        }

        private static void SetProperty(MemberInfo property, HashSet<Type> ancestorTypes = null, Property parent = null)
        {
            var propType = property.GetType();
            if (ancestorTypes != null && ancestorTypes.Contains(propType))
                return;

            ModelPropertyAttribute attribute = null;
            foreach (var attr in property.GetCustomAttributes(false))
                if (attr is ModelPropertyAttribute)
                    attribute = (ModelPropertyAttribute)attr;

            StringBuilder nameBuilder = new StringBuilder();
            for (Property p = parent; p != null; p = p.Parent)
                nameBuilder.AppendFormat("{0}.", p.Name);
            nameBuilder.Append(attribute.Name != null ? attribute.Name : property.Name);
            string name = nameBuilder.ToString();
            if (properties.ContainsKey(name))
            {
                for (int i = 1; properties.ContainsKey(name + i); ++i) ;
                name = nameBuilder.ToString();
            }

            bool isCollection = propType.IsArray || typeof(IEnumerable<T>).IsAssignableFrom(propType);

            Property newProperty = new Property(
                name: name,
                variableName: property.Name,
                type: propType,
                isCollection: isCollection,
                attribute: attribute,
                parent: parent
                );

            // If the type is complex, expand it until it becomes cyclic
            if (!propType.IsValueType && !isCollection && !propType.Equals(typeof(string)))
            {
                HashSet<Type> nextAncestoryTypes = ancestorTypes == null ? ancestorTypes : new HashSet<Type>();
                nextAncestoryTypes.Add(propType);
                ForEachProperty(propType, (p) => SetProperty(p, nextAncestoryTypes, newProperty));
            }

            properties.Add(newProperty.Name, newProperty);
        }
    }
}
