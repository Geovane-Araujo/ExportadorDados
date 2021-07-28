
namespace ExportarDados
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_db = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txt_pathOrigem = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(113, 167);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Gerar BK Sistema";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Banco Origem";
            // 
            // txt_db
            // 
            this.txt_db.Location = new System.Drawing.Point(13, 61);
            this.txt_db.Name = "txt_db";
            this.txt_db.Size = new System.Drawing.Size(358, 23);
            this.txt_db.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(342, 110);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(29, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txt_pathOrigem
            // 
            this.txt_pathOrigem.Location = new System.Drawing.Point(12, 111);
            this.txt_pathOrigem.Name = "txt_pathOrigem";
            this.txt_pathOrigem.Size = new System.Drawing.Size(324, 23);
            this.txt_pathOrigem.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Origem da Pasta";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 205);
            this.Controls.Add(this.txt_pathOrigem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txt_db);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exportador de Dados";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_db;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txt_pathOrigem;
        private System.Windows.Forms.Label label2;
    }
}

