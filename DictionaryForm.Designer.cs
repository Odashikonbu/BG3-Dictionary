namespace BG3_Dictionary
{
    partial class Top
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Top));
            this.Search_Box = new System.Windows.Forms.TextBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.SerchResult = new System.Windows.Forms.DataGridView();
            this.CreateDictionaryButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SerchResult)).BeginInit();
            this.SuspendLayout();
            // 
            // Search_Box
            // 
            this.Search_Box.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Search_Box.Font = new System.Drawing.Font("Yu Gothic UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Search_Box.Location = new System.Drawing.Point(42, 32);
            this.Search_Box.Name = "Search_Box";
            this.Search_Box.Size = new System.Drawing.Size(561, 39);
            this.Search_Box.TabIndex = 0;
            this.Search_Box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SearchBox_KeyPress);
            // 
            // SearchButton
            // 
            this.SearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchButton.Font = new System.Drawing.Font("Yu Gothic UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SearchButton.Location = new System.Drawing.Point(622, 32);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(140, 39);
            this.SearchButton.TabIndex = 1;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // SerchResult
            // 
            this.SerchResult.AllowUserToAddRows = false;
            this.SerchResult.AllowUserToDeleteRows = false;
            this.SerchResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SerchResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SerchResult.ImeMode = System.Windows.Forms.ImeMode.On;
            this.SerchResult.Location = new System.Drawing.Point(42, 113);
            this.SerchResult.Name = "SerchResult";
            this.SerchResult.ReadOnly = true;
            this.SerchResult.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.SerchResult.RowTemplate.Height = 21;
            this.SerchResult.Size = new System.Drawing.Size(720, 316);
            this.SerchResult.TabIndex = 2;
            this.SerchResult.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.SerchResult_ColumnHeaderMouseClick);
            // 
            // CreateDictionaryButton
            // 
            this.CreateDictionaryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CreateDictionaryButton.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CreateDictionaryButton.Location = new System.Drawing.Point(42, 454);
            this.CreateDictionaryButton.Name = "CreateDictionaryButton";
            this.CreateDictionaryButton.Size = new System.Drawing.Size(184, 39);
            this.CreateDictionaryButton.TabIndex = 1;
            this.CreateDictionaryButton.Text = "Create Dictionary";
            this.CreateDictionaryButton.UseVisualStyleBackColor = true;
            this.CreateDictionaryButton.Click += new System.EventHandler(this.CreateDictionaryButton_Click);
            // 
            // Top
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 505);
            this.Controls.Add(this.SerchResult);
            this.Controls.Add(this.CreateDictionaryButton);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.Search_Box);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(816, 544);
            this.Name = "Top";
            this.Text = "BG3 Language Dictionary";
            this.Load += new System.EventHandler(this.Top_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SerchResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Search_Box;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.DataGridView SerchResult;
        private System.Windows.Forms.Button CreateDictionaryButton;
    }
}

