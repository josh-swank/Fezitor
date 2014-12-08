using Fezitor.Model;
using Fezitor.Presenter;
using Fezitor.View;
using NLog;
using System;
using System.Windows.Forms;

namespace Fezitor
{
    static class Program
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var model = new FezitorModel<FezitorSettings>();
            var view = new FezitorView();
            var presenter = new FezitorPresenter();

            presenter.Run(model, view);
        }
    }
}
