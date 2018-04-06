namespace GeoPlot
{
    partial class StdGrid
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.NodeNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Xcor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ycor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Zcor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NodeNo,
            this.Xcor,
            this.Ycor,
            this.Zcor});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(480, 324);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // NodeNo
            // 
            this.NodeNo.HeaderText = "NodeNo.";
            this.NodeNo.Name = "NodeNo";
            // 
            // Xcor
            // 
            this.Xcor.HeaderText = "X";
            this.Xcor.Name = "Xcor";
            // 
            // Ycor
            // 
            this.Ycor.HeaderText = "Y";
            this.Ycor.Name = "Ycor";
            // 
            // Zcor
            // 
            this.Zcor.HeaderText = "Z";
            this.Zcor.Name = "Zcor";
            // 
            // StdGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 324);
            this.Controls.Add(this.dataGridView1);
            this.Name = "StdGrid";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "StdGrid";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NodeNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Xcor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ycor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Zcor;

    }
}