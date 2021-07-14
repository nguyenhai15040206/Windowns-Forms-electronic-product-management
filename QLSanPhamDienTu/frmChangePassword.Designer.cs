
namespace QLSanPhamDienTu
{
    partial class change_Password
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtOldPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtReNewsPass = new System.Windows.Forms.TextBox();
            this.btnDoi = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mật khẩu cũ";
            // 
            // txtOldPass
            // 
            this.txtOldPass.Location = new System.Drawing.Point(179, 19);
            this.txtOldPass.Name = "txtOldPass";
            this.txtOldPass.Size = new System.Drawing.Size(310, 32);
            this.txtOldPass.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mật khẩu mới";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtNewPass
            // 
            this.txtNewPass.Location = new System.Drawing.Point(179, 57);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.Size = new System.Drawing.Size(310, 32);
            this.txtNewPass.TabIndex = 1;
            this.txtNewPass.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Mật khẩu mới";
            this.label4.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtReNewsPass
            // 
            this.txtReNewsPass.Location = new System.Drawing.Point(179, 95);
            this.txtReNewsPass.Name = "txtReNewsPass";
            this.txtReNewsPass.Size = new System.Drawing.Size(310, 32);
            this.txtReNewsPass.TabIndex = 1;
            this.txtReNewsPass.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // btnDoi
            // 
            this.btnDoi.Location = new System.Drawing.Point(179, 147);
            this.btnDoi.Name = "btnDoi";
            this.btnDoi.Size = new System.Drawing.Size(125, 37);
            this.btnDoi.TabIndex = 2;
            this.btnDoi.Text = "Thực thi";
            this.btnDoi.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(342, 147);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(147, 37);
            this.button2.TabIndex = 3;
            this.button2.Text = "Thoát";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // change_Password
            // 
            this.Appearance.BackColor = System.Drawing.Color.SeaShell;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 200);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnDoi);
            this.Controls.Add(this.txtReNewsPass);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNewPass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtOldPass);
            this.Controls.Add(this.label2);
            this.Name = "change_Password";
            this.Text = "change_Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOldPass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtReNewsPass;
        private System.Windows.Forms.Button btnDoi;
        private System.Windows.Forms.Button button2;
    }
}