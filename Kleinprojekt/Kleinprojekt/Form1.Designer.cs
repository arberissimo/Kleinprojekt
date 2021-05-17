
namespace Kleinprojekt
{
    partial class Form1
    {

        private void InitializeComponent()
        {
            this.bttn_entschluessel = new System.Windows.Forms.Button();
            this.bttn_inp = new System.Windows.Forms.Button();
            this.bttn_privkey = new System.Windows.Forms.Button();
            this.brow_ver = new System.Windows.Forms.WebBrowser();
            this.bttn_verschluessel = new System.Windows.Forms.Button();
            this.bttn_asmkey = new System.Windows.Forms.Button();
            this.bttn_pubexp = new System.Windows.Forms.Button();
            this.brow_ent = new System.Windows.Forms.WebBrowser();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // bttn_entschluessel
            // 
            this.bttn_entschluessel.Location = new System.Drawing.Point(29, 130);
            this.bttn_entschluessel.Name = "bttn_entschluessel";
            this.bttn_entschluessel.Size = new System.Drawing.Size(153, 73);
            this.bttn_entschluessel.TabIndex = 1;
            this.bttn_entschluessel.Text = "Entschlüsseln";
            this.bttn_entschluessel.UseVisualStyleBackColor = true;
            this.bttn_entschluessel.Click += new System.EventHandler(this.bttn_entschluessel_Click);
            // 
            // bttn_inp
            // 
            this.bttn_inp.Location = new System.Drawing.Point(29, 261);
            this.bttn_inp.Name = "bttn_inp";
            this.bttn_inp.Size = new System.Drawing.Size(153, 36);
            this.bttn_inp.TabIndex = 3;
            this.bttn_inp.Text = "Key importieren";
            this.bttn_inp.UseVisualStyleBackColor = true;
            this.bttn_inp.Click += new System.EventHandler(this.bttn_inp_Click);
            // 
            // bttn_privkey
            // 
            this.bttn_privkey.Location = new System.Drawing.Point(29, 345);
            this.bttn_privkey.Name = "bttn_privkey";
            this.bttn_privkey.Size = new System.Drawing.Size(153, 36);
            this.bttn_privkey.TabIndex = 6;
            this.bttn_privkey.Text = "Key laden";
            this.bttn_privkey.UseVisualStyleBackColor = true;
            this.bttn_privkey.Click += new System.EventHandler(this.bttn_privkey_Click);
            // 
            // brow_ver
            // 
            this.brow_ver.Location = new System.Drawing.Point(479, 38);
            this.brow_ver.MinimumSize = new System.Drawing.Size(20, 20);
            this.brow_ver.Name = "brow_ver";
            this.brow_ver.ScrollBarsEnabled = false;
            this.brow_ver.Size = new System.Drawing.Size(249, 343);
            this.brow_ver.TabIndex = 7;
            this.brow_ver.Url = new System.Uri("c:\\AESDocs\\Encrypt\\", System.UriKind.Absolute);
            // 
            // bttn_verschluessel
            // 
            this.bttn_verschluessel.Location = new System.Drawing.Point(29, 38);
            this.bttn_verschluessel.Name = "bttn_verschluessel";
            this.bttn_verschluessel.Size = new System.Drawing.Size(153, 73);
            this.bttn_verschluessel.TabIndex = 8;
            this.bttn_verschluessel.Text = "Verschlüsseln";
            this.bttn_verschluessel.UseVisualStyleBackColor = true;
            this.bttn_verschluessel.Click += new System.EventHandler(this.bttn_verschluessel_Click);
            // 
            // bttn_asmkey
            // 
            this.bttn_asmkey.Location = new System.Drawing.Point(29, 219);
            this.bttn_asmkey.Name = "bttn_asmkey";
            this.bttn_asmkey.Size = new System.Drawing.Size(153, 36);
            this.bttn_asmkey.TabIndex = 9;
            this.bttn_asmkey.Text = "Key erstellen";
            this.bttn_asmkey.UseVisualStyleBackColor = true;
            this.bttn_asmkey.Click += new System.EventHandler(this.bttn_asmkey_Click);
            // 
            // bttn_pubexp
            // 
            this.bttn_pubexp.Location = new System.Drawing.Point(29, 303);
            this.bttn_pubexp.Name = "bttn_pubexp";
            this.bttn_pubexp.Size = new System.Drawing.Size(153, 36);
            this.bttn_pubexp.TabIndex = 10;
            this.bttn_pubexp.Text = "Key exportieren";
            this.bttn_pubexp.UseVisualStyleBackColor = true;
            this.bttn_pubexp.Click += new System.EventHandler(this.bttn_pubexp_Click);
            // 
            // brow_ent
            // 
            this.brow_ent.Location = new System.Drawing.Point(201, 38);
            this.brow_ent.MinimumSize = new System.Drawing.Size(20, 20);
            this.brow_ent.Name = "brow_ent";
            this.brow_ent.ScrollBarsEnabled = false;
            this.brow_ent.Size = new System.Drawing.Size(242, 343);
            this.brow_ent.TabIndex = 11;
            this.brow_ent.Url = new System.Uri("c:\\AESDocs\\Decrypt\\", System.UriKind.Absolute);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.brow_ent);
            this.Controls.Add(this.bttn_pubexp);
            this.Controls.Add(this.bttn_asmkey);
            this.Controls.Add(this.bttn_verschluessel);
            this.Controls.Add(this.brow_ver);
            this.Controls.Add(this.bttn_privkey);
            this.Controls.Add(this.bttn_inp);
            this.Controls.Add(this.bttn_entschluessel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.ResumeLayout(false);

        }

        
        private System.Windows.Forms.Button bttn_entschluessel;
        private System.Windows.Forms.Button bttn_inp;
        private System.Windows.Forms.Button bttn_privkey;
        private System.Windows.Forms.WebBrowser brow_ver;
        private System.Windows.Forms.Button bttn_verschluessel;
        private System.Windows.Forms.Button bttn_asmkey;
        private System.Windows.Forms.Button bttn_pubexp;
        private System.Windows.Forms.WebBrowser brow_ent;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
    }
}