namespace All_for_Wakfu
{
    partial class FrmMain
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.web = new System.Windows.Forms.WebBrowser();
            this.BtnUpdateDatabase = new System.Windows.Forms.Button();
            this.DgvItems = new System.Windows.Forms.DataGridView();
            this.imageDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.levelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rarityNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.allForWakfuDBDataSet = new All_for_Wakfu.AllForWakfuDBDataSet();
            this.itemsTableAdapter = new All_for_Wakfu.AllForWakfuDBDataSetTableAdapters.ItemsTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.allForWakfuDBDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // web
            // 
            this.web.Location = new System.Drawing.Point(12, 3);
            this.web.MinimumSize = new System.Drawing.Size(20, 20);
            this.web.Name = "web";
            this.web.Size = new System.Drawing.Size(983, 648);
            this.web.TabIndex = 0;
            // 
            // BtnUpdateDatabase
            // 
            this.BtnUpdateDatabase.Location = new System.Drawing.Point(12, 12);
            this.BtnUpdateDatabase.Name = "BtnUpdateDatabase";
            this.BtnUpdateDatabase.Size = new System.Drawing.Size(183, 23);
            this.BtnUpdateDatabase.TabIndex = 2;
            this.BtnUpdateDatabase.Text = "Mettre à jour la base de données";
            this.BtnUpdateDatabase.UseVisualStyleBackColor = true;
            this.BtnUpdateDatabase.Click += new System.EventHandler(this.BtnUpdateDatabase_Click);
            // 
            // DgvItems
            // 
            this.DgvItems.AllowUserToAddRows = false;
            this.DgvItems.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DgvItems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvItems.AutoGenerateColumns = false;
            this.DgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgvItems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.imageDataGridViewImageColumn,
            this.nameDataGridViewTextBoxColumn,
            this.levelDataGridViewTextBoxColumn,
            this.rarityNameDataGridViewTextBoxColumn,
            this.typeNameDataGridViewTextBoxColumn});
            this.DgvItems.DataSource = this.itemsBindingSource;
            this.DgvItems.Location = new System.Drawing.Point(12, 41);
            this.DgvItems.Name = "DgvItems";
            this.DgvItems.ReadOnly = true;
            this.DgvItems.RowHeadersVisible = false;
            this.DgvItems.Size = new System.Drawing.Size(495, 293);
            this.DgvItems.TabIndex = 1;
            // 
            // imageDataGridViewImageColumn
            // 
            this.imageDataGridViewImageColumn.DataPropertyName = "image";
            this.imageDataGridViewImageColumn.HeaderText = "";
            this.imageDataGridViewImageColumn.Name = "imageDataGridViewImageColumn";
            this.imageDataGridViewImageColumn.ReadOnly = true;
            this.imageDataGridViewImageColumn.Width = 5;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Nom";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 54;
            // 
            // levelDataGridViewTextBoxColumn
            // 
            this.levelDataGridViewTextBoxColumn.DataPropertyName = "level";
            this.levelDataGridViewTextBoxColumn.HeaderText = "Niveau";
            this.levelDataGridViewTextBoxColumn.Name = "levelDataGridViewTextBoxColumn";
            this.levelDataGridViewTextBoxColumn.ReadOnly = true;
            this.levelDataGridViewTextBoxColumn.Width = 66;
            // 
            // rarityNameDataGridViewTextBoxColumn
            // 
            this.rarityNameDataGridViewTextBoxColumn.DataPropertyName = "rarityName";
            this.rarityNameDataGridViewTextBoxColumn.HeaderText = "Rareté";
            this.rarityNameDataGridViewTextBoxColumn.Name = "rarityNameDataGridViewTextBoxColumn";
            this.rarityNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.rarityNameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.rarityNameDataGridViewTextBoxColumn.Width = 45;
            // 
            // typeNameDataGridViewTextBoxColumn
            // 
            this.typeNameDataGridViewTextBoxColumn.DataPropertyName = "typeName";
            this.typeNameDataGridViewTextBoxColumn.HeaderText = "Type";
            this.typeNameDataGridViewTextBoxColumn.Name = "typeNameDataGridViewTextBoxColumn";
            this.typeNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.typeNameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.typeNameDataGridViewTextBoxColumn.Width = 37;
            // 
            // itemsBindingSource
            // 
            this.itemsBindingSource.DataMember = "Items";
            this.itemsBindingSource.DataSource = this.allForWakfuDBDataSet;
            // 
            // allForWakfuDBDataSet
            // 
            this.allForWakfuDBDataSet.DataSetName = "AllForWakfuDBDataSet";
            this.allForWakfuDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // itemsTableAdapter
            // 
            this.itemsTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(201, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(365, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "note : vous devez relancer l\'application pour voir les changements effectués";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 663);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnUpdateDatabase);
            this.Controls.Add(this.DgvItems);
            this.Controls.Add(this.web);
            this.Name = "FrmMain";
            this.Text = "All for Wakfu";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.allForWakfuDBDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser web;
        private System.Windows.Forms.Button BtnUpdateDatabase;
        private System.Windows.Forms.DataGridView DgvItems;
        private AllForWakfuDBDataSet allForWakfuDBDataSet;
        private System.Windows.Forms.BindingSource itemsBindingSource;
        private AllForWakfuDBDataSetTableAdapters.ItemsTableAdapter itemsTableAdapter;
        private System.Windows.Forms.DataGridViewImageColumn imageDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn levelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rarityNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label1;
    }
}

