﻿namespace Modal
{
    partial class frmMain
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
            this.btnModal = new System.Windows.Forms.Button();
            this.btnModaless = new System.Windows.Forms.Button();
            this.btnMessage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnModal
            // 
            this.btnModal.Location = new System.Drawing.Point(103, 177);
            this.btnModal.Name = "btnModal";
            this.btnModal.Size = new System.Drawing.Size(75, 23);
            this.btnModal.TabIndex = 0;
            this.btnModal.Text = "Modal";
            this.btnModal.UseVisualStyleBackColor = true;
            this.btnModal.Click += new System.EventHandler(this.btnModal_Click);
            // 
            // btnModaless
            // 
            this.btnModaless.Location = new System.Drawing.Point(382, 198);
            this.btnModaless.Name = "btnModaless";
            this.btnModaless.Size = new System.Drawing.Size(75, 23);
            this.btnModaless.TabIndex = 1;
            this.btnModaless.Text = "Modaless";
            this.btnModaless.UseVisualStyleBackColor = true;
            this.btnModaless.Click += new System.EventHandler(this.btnModaless_Click);
            // 
            // btnMessage
            // 
            this.btnMessage.Location = new System.Drawing.Point(582, 179);
            this.btnMessage.Name = "btnMessage";
            this.btnMessage.Size = new System.Drawing.Size(75, 23);
            this.btnMessage.TabIndex = 2;
            this.btnMessage.Text = "MessageBox";
            this.btnMessage.UseVisualStyleBackColor = true;
            this.btnMessage.Click += new System.EventHandler(this.btnMessage_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnMessage);
            this.Controls.Add(this.btnModaless);
            this.Controls.Add(this.btnModal);
            this.Name = "frmMain";
            this.Text = "모달테스트";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnModal;
        private System.Windows.Forms.Button btnModaless;
        private System.Windows.Forms.Button btnMessage;
    }
}

