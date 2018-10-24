namespace ListViewControlWinForm
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.sb = new System.Windows.Forms.ToolStripStatusLabel();
            this.lv = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.year = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusStrip
            // 
            this.StatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sb});
            this.StatusStrip.Location = new System.Drawing.Point(0, 228);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(332, 25);
            this.StatusStrip.TabIndex = 0;
            // 
            // sb
            // 
            this.sb.Name = "sb";
            this.sb.Size = new System.Drawing.Size(152, 20);
            this.sb.Text = "Status";
            // 
            // lv
            // 
            this.lv.AllowColumnReorder = true;
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.year});
            this.lv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv.FullRowSelect = true;
            this.lv.GridLines = true;
            this.lv.Location = new System.Drawing.Point(0, 0);
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(332, 228);
            this.lv.TabIndex = 1;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            this.lv.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ColumnClick);
            this.lv.Click += new System.EventHandler(this.OnChanged);
            // 
            // name
            // 
            this.name.Text = "Name";
            this.name.Width = -1;
            // 
            // year
            // 
            this.year.Text = "Year";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 253);
            this.Controls.Add(this.lv);
            this.Controls.Add(this.StatusStrip);
            this.Name = "Form1";
            this.Text = "ListView";
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel sb;
        private System.Windows.Forms.ListView lv;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader year;
    }
}

