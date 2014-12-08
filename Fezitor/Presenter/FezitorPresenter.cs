using Fezitor.Interface.Model;
using Fezitor.Interface.Presenter;
using Fezitor.Interface.View;
using Fezitor.Model;
using Fezitor.View;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fezitor.Presenter
{
    class FezitorPresenter : IPresenter<FezitorSettings>
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        private IModel<FezitorSettings> Model { get; set; }
        private IView<FezitorSettings> View { get; set; }

        public void Run(IModel<FezitorSettings> model, IView<FezitorSettings> view)
        {
            Model = model;  View = view;
            RegisterEventHandlers();
            View.Run(model);
        }

        private void RegisterEventHandlers()
        {
            View.Events.Exiting += View_Exiting;
            View.Events.SettingsChanged += View_SettingsChanged;
            View.Events.GameObjectChanged += View_GameObjectChanged;
        }

        private void View_Exiting()
        {
        }

        private void View_SettingsChanged(FezitorSettings newValue)
        {
            Model.AppSettings = newValue;
        }

        private void View_GameObjectChanged(Type type, object oldId, object newId, object newValue)
        {
            switch(type.GetHashCode())
            {
                default:
                    throw new ArgumentException("");
            }
        }

        private FezitorSettings ReadAppSettings()
        {
            FezitorSettings settings = new FezitorSettings();

            settings.GameDirectory = Properties.Settings.Default.GameDirectory;

            return settings;
        }

        private void WriteAppSettings(FezitorSettings newValue)
        {
            var settingsType = typeof(FezitorSettings);
            foreach (var prop in settingsType.GetProperties())
                foreach (var attr in prop.GetCustomAttributes(false))
                    if (attr is AppSettingAttribute)
                        Properties.Settings.Default[((AppSettingAttribute)attr).SettingName] = prop.GetValue(newValue);

            Properties.Settings.Default.Save();
        }
    }
}
