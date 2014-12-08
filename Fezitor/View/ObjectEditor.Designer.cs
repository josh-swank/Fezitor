namespace Fezitor.View
{
    partial class ObjectEditor<T>
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.propertiesListView = new System.Windows.Forms.ListView();
            this.propertiesNameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.propertiesValueCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(388, 375);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(307, 375);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // propertiesListView
            // 
            this.propertiesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.propertiesNameCol,
            this.propertiesValueCol});
            this.propertiesListView.Location = new System.Drawing.Point(13, 13);
            this.propertiesListView.Name = "propertiesListView";
            this.propertiesListView.Size = new System.Drawing.Size(450, 356);
            this.propertiesListView.TabIndex = 2;
            this.propertiesListView.UseCompatibleStateImageBehavior = false;
            // 
            // propertiesNameCol
            // 
            this.propertiesNameCol.Text = "Name";
            // 
            // propertiesValueCol
            // 
            this.propertiesValueCol.Text = "Value";
            // 
            // ObjectEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 410);
            this.Controls.Add(this.propertiesListView);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Name = "ObjectEditor";
            this.Text = "Object Editor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.ListView propertiesListView;
        private System.Windows.Forms.ColumnHeader propertiesNameCol;
        private System.Windows.Forms.ColumnHeader propertiesValueCol;
    }
}