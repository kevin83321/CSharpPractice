namespace BankingPractice
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.CustomerInput = new System.Windows.Forms.TextBox();
            this.BankInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.CustomerNameLabel = new System.Windows.Forms.Label();
            this.CustomerDollarLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BankDollarLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.BankNameLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.BorrowButton = new System.Windows.Forms.Button();
            this.RePayButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CustomerInput
            // 
            this.CustomerInput.Location = new System.Drawing.Point(177, 13);
            this.CustomerInput.Name = "CustomerInput";
            this.CustomerInput.Size = new System.Drawing.Size(100, 22);
            this.CustomerInput.TabIndex = 0;
            // 
            // BankInput
            // 
            this.BankInput.Location = new System.Drawing.Point(177, 41);
            this.BankInput.Name = "BankInput";
            this.BankInput.Size = new System.Drawing.Size(100, 22);
            this.BankInput.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(47, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "請輸入客戶名字:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(47, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "請輸入借款銀行:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(313, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 50);
            this.button1.TabIndex = 4;
            this.button1.Text = "確認";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(34, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "客戶名字:";
            // 
            // CustomerNameLabel
            // 
            this.CustomerNameLabel.AutoSize = true;
            this.CustomerNameLabel.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CustomerNameLabel.Location = new System.Drawing.Point(116, 95);
            this.CustomerNameLabel.Name = "CustomerNameLabel";
            this.CustomerNameLabel.Size = new System.Drawing.Size(56, 16);
            this.CustomerNameLabel.TabIndex = 6;
            this.CustomerNameLabel.Text = "無名氏";
            // 
            // CustomerDollarLabel
            // 
            this.CustomerDollarLabel.AutoSize = true;
            this.CustomerDollarLabel.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CustomerDollarLabel.Location = new System.Drawing.Point(116, 124);
            this.CustomerDollarLabel.Name = "CustomerDollarLabel";
            this.CustomerDollarLabel.Size = new System.Drawing.Size(16, 16);
            this.CustomerDollarLabel.TabIndex = 8;
            this.CustomerDollarLabel.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(34, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "客戶的$$:";
            // 
            // BankDollarLabel
            // 
            this.BankDollarLabel.AutoSize = true;
            this.BankDollarLabel.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BankDollarLabel.Location = new System.Drawing.Point(283, 124);
            this.BankDollarLabel.Name = "BankDollarLabel";
            this.BankDollarLabel.Size = new System.Drawing.Size(56, 16);
            this.BankDollarLabel.TabIndex = 12;
            this.BankDollarLabel.Text = "200000";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(201, 124);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 16);
            this.label8.TabIndex = 11;
            this.label8.Text = "銀行的$$:";
            // 
            // BankNameLabel
            // 
            this.BankNameLabel.AutoSize = true;
            this.BankNameLabel.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BankNameLabel.Location = new System.Drawing.Point(283, 95);
            this.BankNameLabel.Name = "BankNameLabel";
            this.BankNameLabel.Size = new System.Drawing.Size(56, 16);
            this.BankNameLabel.TabIndex = 10;
            this.BankNameLabel.Text = "無名氏";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.Location = new System.Drawing.Point(201, 95);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 16);
            this.label10.TabIndex = 9;
            this.label10.Text = "銀行名稱:";
            // 
            // BorrowButton
            // 
            this.BorrowButton.Enabled = false;
            this.BorrowButton.Location = new System.Drawing.Point(37, 161);
            this.BorrowButton.Name = "BorrowButton";
            this.BorrowButton.Size = new System.Drawing.Size(351, 35);
            this.BorrowButton.TabIndex = 13;
            this.BorrowButton.Text = "xxx客戶向xxx銀行借1000元";
            this.BorrowButton.UseVisualStyleBackColor = true;
            this.BorrowButton.Click += new System.EventHandler(this.BorrowButton_Click);
            // 
            // RePayButton
            // 
            this.RePayButton.Enabled = false;
            this.RePayButton.Location = new System.Drawing.Point(37, 202);
            this.RePayButton.Name = "RePayButton";
            this.RePayButton.Size = new System.Drawing.Size(351, 35);
            this.RePayButton.TabIndex = 14;
            this.RePayButton.Text = "xxx客戶向xxx銀行還1000元";
            this.RePayButton.UseVisualStyleBackColor = true;
            this.RePayButton.Click += new System.EventHandler(this.RePayButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 254);
            this.Controls.Add(this.RePayButton);
            this.Controls.Add(this.BorrowButton);
            this.Controls.Add(this.BankDollarLabel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.BankNameLabel);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.CustomerDollarLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CustomerNameLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BankInput);
            this.Controls.Add(this.CustomerInput);
            this.Name = "Form1";
            this.Text = "借還錢程式";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CustomerInput;
        private System.Windows.Forms.TextBox BankInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label CustomerNameLabel;
        private System.Windows.Forms.Label CustomerDollarLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label BankDollarLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label BankNameLabel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button BorrowButton;
        private System.Windows.Forms.Button RePayButton;
    }
}

