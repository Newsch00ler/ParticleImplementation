
namespace ParticleImplementation
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.picDisplay = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.b_NewCount = new System.Windows.Forms.Button();
            this.lb_NewCount = new System.Windows.Forms.Label();
            this.lb_SpeedSpread = new System.Windows.Forms.Label();
            this.lb_CountParticles = new System.Windows.Forms.Label();
            this.tb_Spread = new System.Windows.Forms.TrackBar();
            this.tb_ParticlesPerTick = new System.Windows.Forms.TrackBar();
            this.lb_TextCount = new System.Windows.Forms.Label();
            this.lb_Count = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_Spread)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ParticlesPerTick)).BeginInit();
            this.SuspendLayout();
            // 
            // picDisplay
            // 
            this.picDisplay.Location = new System.Drawing.Point(12, 12);
            this.picDisplay.Name = "picDisplay";
            this.picDisplay.Size = new System.Drawing.Size(626, 603);
            this.picDisplay.TabIndex = 0;
            this.picDisplay.TabStop = false;
            this.picDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picDisplay_MouseMove);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // b_NewCount
            // 
            this.b_NewCount.Location = new System.Drawing.Point(780, 12);
            this.b_NewCount.Name = "b_NewCount";
            this.b_NewCount.Size = new System.Drawing.Size(131, 23);
            this.b_NewCount.TabIndex = 1;
            this.b_NewCount.Text = "Создать";
            this.b_NewCount.UseVisualStyleBackColor = true;
            this.b_NewCount.Click += new System.EventHandler(this.b_NewCount_Click);
            // 
            // lb_NewCount
            // 
            this.lb_NewCount.AutoSize = true;
            this.lb_NewCount.Location = new System.Drawing.Point(648, 17);
            this.lb_NewCount.Name = "lb_NewCount";
            this.lb_NewCount.Size = new System.Drawing.Size(129, 13);
            this.lb_NewCount.TabIndex = 2;
            this.lb_NewCount.Text = "Создать новый счётчик:";
            // 
            // lb_SpeedSpread
            // 
            this.lb_SpeedSpread.AutoSize = true;
            this.lb_SpeedSpread.Location = new System.Drawing.Point(648, 52);
            this.lb_SpeedSpread.Name = "lb_SpeedSpread";
            this.lb_SpeedSpread.Size = new System.Drawing.Size(90, 13);
            this.lb_SpeedSpread.TabIndex = 3;
            this.lb_SpeedSpread.Text = "Разброс частиц:";
            // 
            // lb_CountParticles
            // 
            this.lb_CountParticles.AutoSize = true;
            this.lb_CountParticles.Location = new System.Drawing.Point(648, 86);
            this.lb_CountParticles.Name = "lb_CountParticles";
            this.lb_CountParticles.Size = new System.Drawing.Size(81, 13);
            this.lb_CountParticles.TabIndex = 4;
            this.lb_CountParticles.Text = "Кол-во частиц:";
            // 
            // tb_Spread
            // 
            this.tb_Spread.Location = new System.Drawing.Point(744, 41);
            this.tb_Spread.Minimum = 1;
            this.tb_Spread.Name = "tb_Spread";
            this.tb_Spread.Size = new System.Drawing.Size(167, 45);
            this.tb_Spread.TabIndex = 5;
            this.tb_Spread.Value = 10;
            this.tb_Spread.Scroll += new System.EventHandler(this.tb_Spread_Scroll);
            // 
            // tb_ParticlesPerTick
            // 
            this.tb_ParticlesPerTick.Location = new System.Drawing.Point(744, 76);
            this.tb_ParticlesPerTick.Maximum = 150;
            this.tb_ParticlesPerTick.Minimum = 1;
            this.tb_ParticlesPerTick.Name = "tb_ParticlesPerTick";
            this.tb_ParticlesPerTick.Size = new System.Drawing.Size(167, 45);
            this.tb_ParticlesPerTick.TabIndex = 6;
            this.tb_ParticlesPerTick.Value = 150;
            this.tb_ParticlesPerTick.Scroll += new System.EventHandler(this.tb_ParticlesPerTick_Scroll);
            // 
            // lb_TextCount
            // 
            this.lb_TextCount.AutoSize = true;
            this.lb_TextCount.BackColor = System.Drawing.Color.Black;
            this.lb_TextCount.ForeColor = System.Drawing.Color.White;
            this.lb_TextCount.Location = new System.Drawing.Point(21, 22);
            this.lb_TextCount.Name = "lb_TextCount";
            this.lb_TextCount.Size = new System.Drawing.Size(81, 13);
            this.lb_TextCount.TabIndex = 7;
            this.lb_TextCount.Text = "Кол-во частиц:";
            // 
            // lb_Count
            // 
            this.lb_Count.AutoSize = true;
            this.lb_Count.BackColor = System.Drawing.Color.Black;
            this.lb_Count.ForeColor = System.Drawing.Color.White;
            this.lb_Count.Location = new System.Drawing.Point(109, 21);
            this.lb_Count.Name = "lb_Count";
            this.lb_Count.Size = new System.Drawing.Size(0, 13);
            this.lb_Count.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 627);
            this.Controls.Add(this.lb_Count);
            this.Controls.Add(this.lb_TextCount);
            this.Controls.Add(this.tb_ParticlesPerTick);
            this.Controls.Add(this.tb_Spread);
            this.Controls.Add(this.lb_CountParticles);
            this.Controls.Add(this.lb_SpeedSpread);
            this.Controls.Add(this.lb_NewCount);
            this.Controls.Add(this.b_NewCount);
            this.Controls.Add(this.picDisplay);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Система частиц";
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_Spread)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ParticlesPerTick)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picDisplay;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button b_NewCount;
        private System.Windows.Forms.Label lb_NewCount;
        private System.Windows.Forms.Label lb_SpeedSpread;
        private System.Windows.Forms.Label lb_CountParticles;
        private System.Windows.Forms.TrackBar tb_Spread;
        private System.Windows.Forms.TrackBar tb_ParticlesPerTick;
        private System.Windows.Forms.Label lb_TextCount;
        private System.Windows.Forms.Label lb_Count;
    }
}

