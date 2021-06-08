using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomControls
{
    public class ButtonDesign : SimpleButton
    {
        public ButtonDesign()
        {
            this.BackgroundImage = global::CustomControls.Properties.Resources._6954027;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.ForeColor = System.Drawing.Color.Black;
            this.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AppearanceHovered.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppearanceHovered.Options.UseFont = true;
            this.ResumeLayout(false);
        }
    }
}
