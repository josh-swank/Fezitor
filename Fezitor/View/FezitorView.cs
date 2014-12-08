using Fezitor.Interface.Model;
using Fezitor.Interface.View;
using Fezitor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fezitor.View
{
    class ViewEventRaiser : IViewEvents<FezitorSettings>
    {
        public event ExitingEventHandler Exiting;
        public event SettingsChangedHandler<FezitorSettings> SettingsChanged;
        public event GameObjectChangedHandler GameObjectChanged;

        public void Exit()
        {
            Exiting();
        }

        public void ChangeSettings(FezitorSettings newValue)
        {
            SettingsChanged(newValue);
        }

        public void ChangeGameObject(Type type, object oldId, object newId, object newValue)
        {
            GameObjectChanged(type, oldId, newId, newValue);
        }
    }

    class FezitorView : IView<FezitorSettings>
    {
        private readonly ViewEventRaiser eventRaiser = new ViewEventRaiser();
        public IViewEvents<FezitorSettings> Events { get { return eventRaiser; } }

        private FezitorWindow Window { get; set; }

        private IModel<FezitorSettings> Model { get; set; }

        public void Run(IModel<FezitorSettings> model)
        {
            Model = model;
            Window = new FezitorWindow(model, eventRaiser);
            Application.Run(Window);
            eventRaiser.Exit();
        }
    }
}
