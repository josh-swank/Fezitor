using Fezitor.Interface.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fezitor.Interface.View
{
    public delegate void ExitingEventHandler();
    public delegate void SettingsChangedHandler<S>(S newValue);
    public delegate void GameObjectChangedHandler(Type type, object oldId, object newId, object newValue);

    public interface IViewEvents<S>
    {
        event ExitingEventHandler Exiting;
        event SettingsChangedHandler<S> SettingsChanged;
        event GameObjectChangedHandler GameObjectChanged;
    }

    public interface IView<S>
    {
        IViewEvents<S> Events { get; }
        void Run(IModel<S> model);
    }
}
