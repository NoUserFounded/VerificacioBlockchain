namespace SerialitzacioJSON
{
    partial class MainForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtDifficulty = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btnDeserialize = new System.Windows.Forms.Button();
            this.btnAddBlock = new System.Windows.Forms.Button();
            this.rtbBlockchain = new System.Windows.Forms.RichTextBox();
            this.dataGridViewBlockchain = new System.Windows.Forms.DataGridView();
            this.rtbActions = new System.Windows.Forms.RichTextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.gpFileVerification = new System.Windows.Forms.GroupBox();
            this.txtIndex = new System.Windows.Forms.TextBox();
            this.lblIndex = new System.Windows.Forms.Label();
            this.btnCheckFile = new System.Windows.Forms.Button();
            this.gpVerificationResult = new System.Windows.Forms.GroupBox();
            this.lblResultIndex = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblTitleResult = new System.Windows.Forms.Label();
            this.pbResult = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBlockchain)).BeginInit();
            this.gpFileVerification.SuspendLayout();
            this.gpVerificationResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbResult)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDifficulty
            // 
            this.txtDifficulty.Enabled = false;
            this.txtDifficulty.Location = new System.Drawing.Point(120, 249);
            this.txtDifficulty.Name = "txtDifficulty";
            this.txtDifficulty.Size = new System.Drawing.Size(34, 26);
            this.txtDifficulty.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 255);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Dificulty:";
            // 
            // btnDeserialize
            // 
            this.btnDeserialize.Location = new System.Drawing.Point(53, 180);
            this.btnDeserialize.Name = "btnDeserialize";
            this.btnDeserialize.Size = new System.Drawing.Size(118, 53);
            this.btnDeserialize.TabIndex = 2;
            this.btnDeserialize.Text = "Show BlockChain";
            this.btnDeserialize.UseVisualStyleBackColor = true;
            this.btnDeserialize.Click += new System.EventHandler(this.btnDeserialize_Click);
            // 
            // btnAddBlock
            // 
            this.btnAddBlock.Location = new System.Drawing.Point(53, 108);
            this.btnAddBlock.Name = "btnAddBlock";
            this.btnAddBlock.Size = new System.Drawing.Size(118, 50);
            this.btnAddBlock.TabIndex = 1;
            this.btnAddBlock.Text = "Add new Block";
            this.btnAddBlock.UseVisualStyleBackColor = true;
            this.btnAddBlock.Click += new System.EventHandler(this.btnAddBlock_Click);
            // 
            // rtbBlockchain
            // 
            this.rtbBlockchain.Location = new System.Drawing.Point(964, 57);
            this.rtbBlockchain.Name = "rtbBlockchain";
            this.rtbBlockchain.Size = new System.Drawing.Size(309, 521);
            this.rtbBlockchain.TabIndex = 7;
            this.rtbBlockchain.Text = "";
            // 
            // dataGridViewBlockchain
            // 
            this.dataGridViewBlockchain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBlockchain.Location = new System.Drawing.Point(44, 281);
            this.dataGridViewBlockchain.Name = "dataGridViewBlockchain";
            this.dataGridViewBlockchain.RowHeadersWidth = 62;
            this.dataGridViewBlockchain.RowTemplate.Height = 28;
            this.dataGridViewBlockchain.Size = new System.Drawing.Size(905, 297);
            this.dataGridViewBlockchain.TabIndex = 6;
            // 
            // rtbActions
            // 
            this.rtbActions.Location = new System.Drawing.Point(711, 58);
            this.rtbActions.Name = "rtbActions";
            this.rtbActions.Size = new System.Drawing.Size(238, 176);
            this.rtbActions.TabIndex = 4;
            this.rtbActions.Text = "";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(10, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(392, 32);
            this.lblTitle.TabIndex = 13;
            this.lblTitle.Text = "File Verification BlockChain";
            // 
            // gpFileVerification
            // 
            this.gpFileVerification.Controls.Add(this.txtIndex);
            this.gpFileVerification.Controls.Add(this.lblIndex);
            this.gpFileVerification.Controls.Add(this.btnCheckFile);
            this.gpFileVerification.Location = new System.Drawing.Point(192, 58);
            this.gpFileVerification.Name = "gpFileVerification";
            this.gpFileVerification.Size = new System.Drawing.Size(200, 175);
            this.gpFileVerification.TabIndex = 3;
            this.gpFileVerification.TabStop = false;
            this.gpFileVerification.Text = "File verification";
            // 
            // txtIndex
            // 
            this.txtIndex.Location = new System.Drawing.Point(70, 62);
            this.txtIndex.Name = "txtIndex";
            this.txtIndex.Size = new System.Drawing.Size(100, 26);
            this.txtIndex.TabIndex = 0;
            this.txtIndex.Validating += new System.ComponentModel.CancelEventHandler(this.txtIndex_Validating);
            // 
            // lblIndex
            // 
            this.lblIndex.AutoSize = true;
            this.lblIndex.Location = new System.Drawing.Point(12, 65);
            this.lblIndex.Name = "lblIndex";
            this.lblIndex.Size = new System.Drawing.Size(52, 20);
            this.lblIndex.TabIndex = 16;
            this.lblIndex.Text = "Index:";
            // 
            // btnCheckFile
            // 
            this.btnCheckFile.Enabled = false;
            this.btnCheckFile.Location = new System.Drawing.Point(16, 106);
            this.btnCheckFile.Name = "btnCheckFile";
            this.btnCheckFile.Size = new System.Drawing.Size(113, 52);
            this.btnCheckFile.TabIndex = 1;
            this.btnCheckFile.Text = "Check Document";
            this.btnCheckFile.UseVisualStyleBackColor = true;
            this.btnCheckFile.Click += new System.EventHandler(this.btnCheckFile_Click);
            // 
            // gpVerificationResult
            // 
            this.gpVerificationResult.Controls.Add(this.lblResultIndex);
            this.gpVerificationResult.Controls.Add(this.lblResult);
            this.gpVerificationResult.Controls.Add(this.lblTitleResult);
            this.gpVerificationResult.Controls.Add(this.pbResult);
            this.gpVerificationResult.Location = new System.Drawing.Point(411, 58);
            this.gpVerificationResult.Name = "gpVerificationResult";
            this.gpVerificationResult.Size = new System.Drawing.Size(294, 175);
            this.gpVerificationResult.TabIndex = 15;
            this.gpVerificationResult.TabStop = false;
            this.gpVerificationResult.Text = "Verification Result";
            // 
            // lblResultIndex
            // 
            this.lblResultIndex.AutoSize = true;
            this.lblResultIndex.Location = new System.Drawing.Point(96, 101);
            this.lblResultIndex.Name = "lblResultIndex";
            this.lblResultIndex.Size = new System.Drawing.Size(130, 20);
            this.lblResultIndex.TabIndex = 17;
            this.lblResultIndex.Text = "Document Index:";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(96, 133);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(158, 20);
            this.lblResult.TabIndex = 16;
            this.lblResult.Text = "Unsuccesfully verifed";
            this.lblResult.Visible = false;
            // 
            // lblTitleResult
            // 
            this.lblTitleResult.AutoSize = true;
            this.lblTitleResult.Location = new System.Drawing.Point(6, 50);
            this.lblTitleResult.Name = "lblTitleResult";
            this.lblTitleResult.Size = new System.Drawing.Size(273, 20);
            this.lblTitleResult.TabIndex = 1;
            this.lblTitleResult.Text = "Result for the last document checked";
            // 
            // pbResult
            // 
            this.pbResult.Location = new System.Drawing.Point(15, 101);
            this.pbResult.Name = "pbResult";
            this.pbResult.Size = new System.Drawing.Size(75, 52);
            this.pbResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbResult.TabIndex = 0;
            this.pbResult.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1308, 634);
            this.Controls.Add(this.gpVerificationResult);
            this.Controls.Add(this.gpFileVerification);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.rtbActions);
            this.Controls.Add(this.dataGridViewBlockchain);
            this.Controls.Add(this.rtbBlockchain);
            this.Controls.Add(this.btnAddBlock);
            this.Controls.Add(this.btnDeserialize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDifficulty);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBlockchain)).EndInit();
            this.gpFileVerification.ResumeLayout(false);
            this.gpFileVerification.PerformLayout();
            this.gpVerificationResult.ResumeLayout(false);
            this.gpVerificationResult.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDifficulty;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDeserialize;
        private System.Windows.Forms.Button btnAddBlock;
        private System.Windows.Forms.RichTextBox rtbBlockchain;
        private System.Windows.Forms.DataGridView dataGridViewBlockchain;
        private System.Windows.Forms.RichTextBox rtbActions;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox gpFileVerification;
        private System.Windows.Forms.TextBox txtIndex;
        private System.Windows.Forms.Label lblIndex;
        private System.Windows.Forms.Button btnCheckFile;
        private System.Windows.Forms.GroupBox gpVerificationResult;
        private System.Windows.Forms.PictureBox pbResult;
        private System.Windows.Forms.Label lblTitleResult;
        private System.Windows.Forms.Label lblResultIndex;
        private System.Windows.Forms.Label lblResult;
    }
}

