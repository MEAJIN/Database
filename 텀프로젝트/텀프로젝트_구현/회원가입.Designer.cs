namespace hyejin_DB
{
    partial class 회원가입
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(회원가입));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.Confirm_ch = new System.Windows.Forms.Button();
            this.phone = new System.Windows.Forms.TextBox();
            this.email1 = new System.Windows.Forms.TextBox();
            this.passwd = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.TextBox();
            this.id = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox1.Location = new System.Drawing.Point(6, 59);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(269, 56);
            this.textBox1.TabIndex = 21;
            this.textBox1.Text = "입력하신 정보는 회원 유무 확인용으로 수집/이용 되며, 가입 회원에 한해 입력하신 모든 정보가 저장되는데 동의합니다.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(204, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "(필수)";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(6, 30);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(208, 24);
            this.checkBox1.TabIndex = 17;
            this.checkBox1.Text = "개인정보 수집 및 이용안내";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(80)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button3.Location = new System.Drawing.Point(191, 440);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(91, 29);
            this.button3.TabIndex = 22;
            this.button3.Text = "회원가입";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // cancel
            // 
            this.cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(80)))));
            this.cancel.FlatAppearance.BorderSize = 0;
            this.cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cancel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.cancel.Location = new System.Drawing.Point(94, 440);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(91, 29);
            this.cancel.TabIndex = 23;
            this.cancel.Text = "취소";
            this.cancel.UseVisualStyleBackColor = false;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.cancel);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Location = new System.Drawing.Point(1, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(288, 475);
            this.panel1.TabIndex = 17;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(4, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 126);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "약관 동의";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.Confirm_ch);
            this.panel3.Controls.Add(this.phone);
            this.panel3.Controls.Add(this.email1);
            this.panel3.Controls.Add(this.passwd);
            this.panel3.Controls.Add(this.name);
            this.panel3.Controls.Add(this.id);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Location = new System.Drawing.Point(4, 138);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(278, 298);
            this.panel3.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(-3, 370);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(325, 2);
            this.label5.TabIndex = 15;
            // 
            // Confirm_ch
            // 
            this.Confirm_ch.BackColor = System.Drawing.Color.Green;
            this.Confirm_ch.FlatAppearance.BorderSize = 0;
            this.Confirm_ch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Confirm_ch.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Confirm_ch.ForeColor = System.Drawing.Color.White;
            this.Confirm_ch.Location = new System.Drawing.Point(190, 85);
            this.Confirm_ch.Name = "Confirm_ch";
            this.Confirm_ch.Size = new System.Drawing.Size(88, 27);
            this.Confirm_ch.TabIndex = 14;
            this.Confirm_ch.Text = "중복확인";
            this.Confirm_ch.UseVisualStyleBackColor = false;
            this.Confirm_ch.Click += new System.EventHandler(this.Confirm_ch_Click);
            // 
            // phone
            // 
            this.phone.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.phone.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.phone.Location = new System.Drawing.Point(0, 263);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(278, 27);
            this.phone.TabIndex = 10;
            this.phone.UseWaitCursor = true;
            // 
            // email1
            // 
            this.email1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.email1.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.email1.Location = new System.Drawing.Point(0, 206);
            this.email1.Name = "email1";
            this.email1.Size = new System.Drawing.Size(278, 27);
            this.email1.TabIndex = 10;
            this.email1.UseWaitCursor = true;
            // 
            // passwd
            // 
            this.passwd.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.passwd.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.passwd.Location = new System.Drawing.Point(0, 148);
            this.passwd.Name = "passwd";
            this.passwd.PasswordChar = '●';
            this.passwd.Size = new System.Drawing.Size(278, 27);
            this.passwd.TabIndex = 13;
            this.passwd.UseWaitCursor = true;
            this.passwd.TextChanged += new System.EventHandler(this.passwd_TextChanged);
            // 
            // name
            // 
            this.name.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.name.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.name.Location = new System.Drawing.Point(0, 25);
            this.name.Margin = new System.Windows.Forms.Padding(3, 80, 3, 3);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(278, 27);
            this.name.TabIndex = 5;
            this.name.UseWaitCursor = true;
            // 
            // id
            // 
            this.id.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.id.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.id.Location = new System.Drawing.Point(0, 85);
            this.id.Margin = new System.Windows.Forms.Padding(3, 80, 3, 3);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(184, 27);
            this.id.TabIndex = 10;
            this.id.UseWaitCursor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.Location = new System.Drawing.Point(-3, 4);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 20);
            this.label10.TabIndex = 0;
            this.label10.Text = "이름";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label11.Location = new System.Drawing.Point(-3, 65);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "아이디";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label12.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label12.Location = new System.Drawing.Point(-3, 244);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 20);
            this.label12.TabIndex = 0;
            this.label12.Text = "전화번호";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label13.Location = new System.Drawing.Point(-3, 187);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 20);
            this.label13.TabIndex = 0;
            this.label13.Text = "이메일";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label17.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label17.Location = new System.Drawing.Point(-3, 127);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(57, 20);
            this.label17.TabIndex = 0;
            this.label17.Text = "비밀번호";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(16, -1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(253, 52);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;
            // 
            // 회원가입
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(293, 528);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "회원가입";
            this.Text = "회원가입";
            this.Load += new System.EventHandler(this.회원가입_Load);
            this.Leave += new System.EventHandler(this.회원가입_Leave);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Confirm_ch;
        private System.Windows.Forms.TextBox phone;
        private System.Windows.Forms.TextBox email1;
        private System.Windows.Forms.TextBox passwd;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label17;
    }
}