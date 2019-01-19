namespace task_5_dop
{
    partial class MainForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.SegmentData = new System.Windows.Forms.DataGridView();
            this.X1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChartGraphic = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.CreateGraphic = new System.Windows.Forms.Button();
            this.ClearTable = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SegmentData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartGraphic)).BeginInit();
            this.SuspendLayout();
            // 
            // SegmentData
            // 
            this.SegmentData.AllowUserToResizeColumns = false;
            this.SegmentData.AllowUserToResizeRows = false;
            this.SegmentData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.SegmentData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SegmentData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.X1,
            this.Y1,
            this.X2,
            this.Y2});
            this.SegmentData.Location = new System.Drawing.Point(23, 24);
            this.SegmentData.Name = "SegmentData";
            this.SegmentData.Size = new System.Drawing.Size(250, 422);
            this.SegmentData.TabIndex = 0;
            this.SegmentData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SegmentData_CellClick);
            this.SegmentData.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.SegmentData_EditingControlShowing);
            // 
            // X1
            // 
            this.X1.HeaderText = "X1";
            this.X1.Name = "X1";
            this.X1.Width = 50;
            // 
            // Y1
            // 
            this.Y1.HeaderText = "Y1";
            this.Y1.Name = "Y1";
            this.Y1.Width = 50;
            // 
            // X2
            // 
            this.X2.HeaderText = "X2";
            this.X2.Name = "X2";
            this.X2.Width = 50;
            // 
            // Y2
            // 
            this.Y2.HeaderText = "Y2";
            this.Y2.Name = "Y2";
            this.Y2.Width = 50;
            // 
            // ChartGraphic
            // 
            this.ChartGraphic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea3.AxisX.MajorGrid.Enabled = false;
            chartArea3.AxisX2.MajorGrid.Enabled = false;
            chartArea3.AxisY.MajorGrid.Enabled = false;
            chartArea3.AxisY2.MajorGrid.Enabled = false;
            chartArea3.Name = "ChartArea1";
            this.ChartGraphic.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.ChartGraphic.Legends.Add(legend3);
            this.ChartGraphic.Location = new System.Drawing.Point(279, 24);
            this.ChartGraphic.Name = "ChartGraphic";
            this.ChartGraphic.Size = new System.Drawing.Size(559, 484);
            this.ChartGraphic.TabIndex = 1;
            this.ChartGraphic.Text = "chart1";
            // 
            // CreateGraphic
            // 
            this.CreateGraphic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CreateGraphic.Location = new System.Drawing.Point(23, 483);
            this.CreateGraphic.Name = "CreateGraphic";
            this.CreateGraphic.Size = new System.Drawing.Size(250, 25);
            this.CreateGraphic.TabIndex = 2;
            this.CreateGraphic.Text = "Построить график";
            this.CreateGraphic.UseVisualStyleBackColor = true;
            this.CreateGraphic.Click += new System.EventHandler(this.CreateGraphic_Click);
            // 
            // ClearTable
            // 
            this.ClearTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ClearTable.Location = new System.Drawing.Point(23, 452);
            this.ClearTable.Name = "ClearTable";
            this.ClearTable.Size = new System.Drawing.Size(250, 25);
            this.ClearTable.TabIndex = 3;
            this.ClearTable.Text = "Очистить данные отрезков";
            this.ClearTable.UseVisualStyleBackColor = true;
            this.ClearTable.Click += new System.EventHandler(this.ClearTable_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 538);
            this.Controls.Add(this.ClearTable);
            this.Controls.Add(this.CreateGraphic);
            this.Controls.Add(this.ChartGraphic);
            this.Controls.Add(this.SegmentData);
            this.Name = "MainForm";
            this.Text = "Задание 5. Поиск и отображение всех пересечений отрезков.";
            ((System.ComponentModel.ISupportInitialize)(this.SegmentData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartGraphic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView SegmentData;
        private System.Windows.Forms.DataGridViewTextBoxColumn X1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y1;
        private System.Windows.Forms.DataGridViewTextBoxColumn X2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y2;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartGraphic;
        private System.Windows.Forms.Button CreateGraphic;
        private System.Windows.Forms.Button ClearTable;
    }
}

