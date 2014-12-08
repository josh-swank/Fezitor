using Fezitor.Interface.Model;
using Fezitor.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fezitor.View
{
    partial class FezitorWindow : Form
    {
        private readonly IModel<FezitorSettings> model;
        private readonly ViewEventRaiser eventRaiser;

        public FezitorWindow(IModel<FezitorSettings> model, ViewEventRaiser eventRaiser)
        {
            this.model = model; this.eventRaiser = eventRaiser;

            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ObjectEditor<FezitorSettings> settingsEditor = new ObjectEditor<FezitorSettings>();
            settingsEditor.ShowDialog();
            if (settingsEditor.Result != null)
                eventRaiser.ChangeSettings(settingsEditor.Result);
        }
    }
}
