namespace CDPack
{
    partial class FormCD
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnKSeg1 = new System.Windows.Forms.Button();
            this.btnSPSSeg1 = new System.Windows.Forms.Button();
            this.lblKSeg1 = new System.Windows.Forms.Label();
            this.lblSPSSeg1 = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.progressBarCD = new System.Windows.Forms.ProgressBar();
            this.btnExecute = new System.Windows.Forms.Button();
            this.lblFolderKseg = new System.Windows.Forms.Label();
            this.btnSelectFolderKSeg = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnPackFolder = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnUnpack = new System.Windows.Forms.Button();
            this.lblUnpack = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnKSeg1
            // 
            this.btnKSeg1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnKSeg1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnKSeg1.Location = new System.Drawing.Point(13, 229);
            this.btnKSeg1.Name = "btnKSeg1";
            this.btnKSeg1.Size = new System.Drawing.Size(137, 35);
            this.btnKSeg1.TabIndex = 0;
            this.btnKSeg1.Text = "Файл KSeg1";
            this.btnKSeg1.UseVisualStyleBackColor = true;
            this.btnKSeg1.Click += new System.EventHandler(this.btnKSeg1_Click);
            // 
            // btnSPSSeg1
            // 
            this.btnSPSSeg1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSPSSeg1.Location = new System.Drawing.Point(13, 277);
            this.btnSPSSeg1.Name = "btnSPSSeg1";
            this.btnSPSSeg1.Size = new System.Drawing.Size(137, 35);
            this.btnSPSSeg1.TabIndex = 1;
            this.btnSPSSeg1.Text = "Файл SPSSeg1";
            this.btnSPSSeg1.UseVisualStyleBackColor = true;
            this.btnSPSSeg1.Click += new System.EventHandler(this.btnSPSSeg1_Click);
            // 
            // lblKSeg1
            // 
            this.lblKSeg1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKSeg1.BackColor = System.Drawing.SystemColors.Window;
            this.lblKSeg1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKSeg1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblKSeg1.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblKSeg1.Location = new System.Drawing.Point(156, 229);
            this.lblKSeg1.Name = "lblKSeg1";
            this.lblKSeg1.Size = new System.Drawing.Size(833, 35);
            this.lblKSeg1.TabIndex = 2;
            this.lblKSeg1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSPSSeg1
            // 
            this.lblSPSSeg1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSPSSeg1.BackColor = System.Drawing.SystemColors.Window;
            this.lblSPSSeg1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSPSSeg1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSPSSeg1.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSPSSeg1.Location = new System.Drawing.Point(156, 277);
            this.lblSPSSeg1.Name = "lblSPSSeg1";
            this.lblSPSSeg1.Size = new System.Drawing.Size(833, 35);
            this.lblSPSSeg1.TabIndex = 3;
            this.lblSPSSeg1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProgress
            // 
            this.lblProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblProgress.Location = new System.Drawing.Point(12, 399);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(175, 20);
            this.lblProgress.TabIndex = 8;
            this.lblProgress.Text = "00.00.00 час/мин/сек";
            // 
            // progressBarCD
            // 
            this.progressBarCD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarCD.Location = new System.Drawing.Point(16, 424);
            this.progressBarCD.Name = "progressBarCD";
            this.progressBarCD.Size = new System.Drawing.Size(973, 26);
            this.progressBarCD.TabIndex = 9;
            // 
            // btnExecute
            // 
            this.btnExecute.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecute.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnExecute.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExecute.Location = new System.Drawing.Point(10, 323);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(979, 40);
            this.btnExecute.TabIndex = 10;
            this.btnExecute.Text = "Упаковать файл";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // lblFolderKseg
            // 
            this.lblFolderKseg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFolderKseg.BackColor = System.Drawing.SystemColors.Window;
            this.lblFolderKseg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFolderKseg.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFolderKseg.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFolderKseg.Location = new System.Drawing.Point(266, 14);
            this.lblFolderKseg.Name = "lblFolderKseg";
            this.lblFolderKseg.Size = new System.Drawing.Size(722, 35);
            this.lblFolderKseg.TabIndex = 12;
            this.lblFolderKseg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSelectFolderKSeg
            // 
            this.btnSelectFolderKSeg.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSelectFolderKSeg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSelectFolderKSeg.Location = new System.Drawing.Point(12, 14);
            this.btnSelectFolderKSeg.Name = "btnSelectFolderKSeg";
            this.btnSelectFolderKSeg.Size = new System.Drawing.Size(248, 35);
            this.btnSelectFolderKSeg.TabIndex = 11;
            this.btnSelectFolderKSeg.Text = "Выберите папку KSeg";
            this.btnSelectFolderKSeg.UseVisualStyleBackColor = true;
            this.btnSelectFolderKSeg.Click += new System.EventHandler(this.btnSelectFolderKSeg_Click);
            // 
            // btnPackFolder
            // 
            this.btnPackFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPackFolder.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnPackFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPackFolder.Location = new System.Drawing.Point(12, 56);
            this.btnPackFolder.Name = "btnPackFolder";
            this.btnPackFolder.Size = new System.Drawing.Size(976, 40);
            this.btnPackFolder.TabIndex = 13;
            this.btnPackFolder.Text = "Архивировать файлы в папке";
            this.btnPackFolder.UseVisualStyleBackColor = true;
            this.btnPackFolder.Click += new System.EventHandler(this.btnPackFolder_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 369);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(201, 27);
            this.button1.TabIndex = 14;
            this.button1.Text = "Отладка";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnUnpack
            // 
            this.btnUnpack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnpack.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnUnpack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnUnpack.Location = new System.Drawing.Point(13, 157);
            this.btnUnpack.Name = "btnUnpack";
            this.btnUnpack.Size = new System.Drawing.Size(976, 40);
            this.btnUnpack.TabIndex = 17;
            this.btnUnpack.Text = "Разархивировать файл";
            this.btnUnpack.UseVisualStyleBackColor = true;
            this.btnUnpack.Click += new System.EventHandler(this.btnUnpack_Click);
            // 
            // lblUnpack
            // 
            this.lblUnpack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUnpack.BackColor = System.Drawing.SystemColors.Window;
            this.lblUnpack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblUnpack.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUnpack.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblUnpack.Location = new System.Drawing.Point(267, 116);
            this.lblUnpack.Name = "lblUnpack";
            this.lblUnpack.Size = new System.Drawing.Size(722, 35);
            this.lblUnpack.TabIndex = 16;
            this.lblUnpack.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(13, 116);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(248, 35);
            this.button3.TabIndex = 15;
            this.button3.Text = "Выберите файл *.dat";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // FormCD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 469);
            this.Controls.Add(this.btnUnpack);
            this.Controls.Add(this.lblUnpack);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnPackFolder);
            this.Controls.Add(this.lblFolderKseg);
            this.Controls.Add(this.btnSelectFolderKSeg);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.progressBarCD);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.lblSPSSeg1);
            this.Controls.Add(this.lblKSeg1);
            this.Controls.Add(this.btnSPSSeg1);
            this.Controls.Add(this.btnKSeg1);
            this.Name = "FormCD";
            this.Text = "CD (compressing)";
            this.Load += new System.EventHandler(this.FormCD_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnKSeg1;
        private System.Windows.Forms.Button btnSPSSeg1;
        private System.Windows.Forms.Label lblKSeg1;
        private System.Windows.Forms.Label lblSPSSeg1;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.ProgressBar progressBarCD;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Label lblFolderKseg;
        private System.Windows.Forms.Button btnSelectFolderKSeg;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnPackFolder;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnUnpack;
        private System.Windows.Forms.Label lblUnpack;
        private System.Windows.Forms.Button button3;
    }
}

