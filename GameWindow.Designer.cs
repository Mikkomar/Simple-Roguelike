using System;
using System.Collections;
using System.Collections.Generic;



partial class GameWindow {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
        if (disposing && (components != null)) {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameWindow));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.richTextBox1.Location = new System.Drawing.Point(14, 44);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(697, 735);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.onClick);
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Cursor = System.Windows.Forms.Cursors.No;
            this.textBox2.Location = new System.Drawing.Point(14, 786);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(859, 13);
            this.textBox2.TabIndex = 45;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(718, 44);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(42, 14);
            this.label23.TabIndex = 46;
            this.label23.Text = "Name:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(718, 72);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(56, 14);
            this.label24.TabIndex = 47;
            this.label24.Text = "Health:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(775, 44);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(84, 14);
            this.label26.TabIndex = 49;
            this.label26.Text = "Player Name";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(775, 72);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(98, 14);
            this.label27.TabIndex = 50;
            this.label27.Text = "Player Health";
            // 
            // richTextBox3
            // 
            this.richTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox3.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.richTextBox3.Location = new System.Drawing.Point(720, 462);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.ReadOnly = true;
            this.richTextBox3.Size = new System.Drawing.Size(234, 188);
            this.richTextBox3.TabIndex = 51;
            this.richTextBox3.Text = resources.GetString("richTextBox3.Text");
            this.richTextBox3.TextChanged += new System.EventHandler(this.richTextBox3_TextChanged);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(800, 104);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(35, 14);
            this.label28.TabIndex = 55;
            this.label28.Text = "None";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(717, 104);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(56, 14);
            this.label29.TabIndex = 54;
            this.label29.Text = "Weapon:";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(800, 143);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(35, 14);
            this.label30.TabIndex = 57;
            this.label30.Text = "None";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(717, 143);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(56, 14);
            this.label31.TabIndex = 56;
            this.label31.Text = "Helmet:";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(800, 157);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(35, 14);
            this.label32.TabIndex = 59;
            this.label32.Text = "None";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(717, 157);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(63, 14);
            this.label33.TabIndex = 58;
            this.label33.Text = "Cuirass:";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(800, 171);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(35, 14);
            this.label34.TabIndex = 61;
            this.label34.Text = "None";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(717, 171);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(77, 14);
            this.label35.TabIndex = 60;
            this.label35.Text = "Gauntlets:";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(800, 185);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(35, 14);
            this.label36.TabIndex = 63;
            this.label36.Text = "None";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(717, 185);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(49, 14);
            this.label37.TabIndex = 62;
            this.label37.Text = "Boots:";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 14;
            this.listBox2.Location = new System.Drawing.Point(720, 228);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(163, 228);
            this.listBox2.TabIndex = 64;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(717, 211);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(77, 14);
            this.label25.TabIndex = 52;
            this.label25.Text = "Inventory:";
            this.label25.Click += new System.EventHandler(this.label25_Click);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(903, 86);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(49, 14);
            this.label38.TabIndex = 65;
            this.label38.Text = "Damage";
            this.label38.Click += new System.EventHandler(this.label38_Click);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(912, 104);
            this.label39.Name = "label39";
            this.label39.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label39.Size = new System.Drawing.Size(28, 14);
            this.label39.TabIndex = 66;
            this.label39.Text = "Dam";
            this.label39.Click += new System.EventHandler(this.label39_Click);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(928, 127);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(56, 14);
            this.label40.TabIndex = 67;
            this.label40.Text = "Defense";
            this.label40.Click += new System.EventHandler(this.label40_Click);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(937, 143);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(28, 14);
            this.label41.TabIndex = 68;
            this.label41.Text = "Hel";
            this.label41.Click += new System.EventHandler(this.label41_Click);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(937, 157);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(28, 14);
            this.label42.TabIndex = 69;
            this.label42.Text = "Cui";
            this.label42.Click += new System.EventHandler(this.label42_Click);
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(937, 171);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(28, 14);
            this.label43.TabIndex = 70;
            this.label43.Text = "Gau";
            this.label43.Click += new System.EventHandler(this.label43_Click);
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(937, 185);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(28, 14);
            this.label44.TabIndex = 71;
            this.label44.Text = "Boo";
            this.label44.Click += new System.EventHandler(this.label44_Click);
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(962, 86);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(84, 14);
            this.label45.TabIndex = 72;
            this.label45.Text = "Crit Chance";
            this.label45.Click += new System.EventHandler(this.label45_Click);
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(1052, 86);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(84, 14);
            this.label46.TabIndex = 73;
            this.label46.Text = "Miss Chance";
            this.label46.Click += new System.EventHandler(this.label46_Click);
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(986, 104);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(35, 14);
            this.label47.TabIndex = 74;
            this.label47.Text = "Crit";
            this.label47.Click += new System.EventHandler(this.label47_Click);
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(1075, 104);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(35, 14);
            this.label48.TabIndex = 75;
            this.label48.Text = "Miss";
            this.label48.Click += new System.EventHandler(this.label48_Click);
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.label48);
            this.Controls.Add(this.label47);
            this.Controls.Add(this.label46);
            this.Controls.Add(this.label45);
            this.Controls.Add(this.label44);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.richTextBox1);
            this.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "GameWindow";
            this.Text = "Mikko Marttila\'s Roguelike";
            this.Load += new System.EventHandler(this.GameWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    public System.Windows.Forms.RichTextBox richTextBox1;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.ListBox listBox1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.CheckBox checkBox1;
    private System.Windows.Forms.CheckBox checkBox2;
    private System.Windows.Forms.CheckBox checkBox3;
    private System.Windows.Forms.CheckBox checkBox4;
    private System.Windows.Forms.CheckBox checkBox5;
    private System.Windows.Forms.CheckBox checkBox6;
    private System.Windows.Forms.CheckBox checkBox7;
    private System.Windows.Forms.CheckBox checkBox8;
    private System.Windows.Forms.CheckBox checkBox9;
    private System.Windows.Forms.CheckBox checkBox10;
    private System.Windows.Forms.CheckBox checkBox11;
    private System.Windows.Forms.CheckBox checkBox12;
    private System.Windows.Forms.CheckBox checkBox13;
    private System.Windows.Forms.CheckBox checkBox14;
    private System.Windows.Forms.CheckBox checkBox15;
    private System.Windows.Forms.CheckBox checkBox16;
    private System.Windows.Forms.CheckBox checkBox17;
    private System.Windows.Forms.CheckBox checkBox18;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.Label label15;
    private System.Windows.Forms.Label label16;
    private System.Windows.Forms.Label label17;
    private System.Windows.Forms.Label label18;
    private System.Windows.Forms.Label label19;
    private System.Windows.Forms.Label label20;
    private System.Windows.Forms.Label label21;
    private System.Windows.Forms.Label label22;
    private System.Windows.Forms.RichTextBox richTextBox2;
    private System.Windows.Forms.Button button1;

    public List<System.Windows.Forms.CheckBox> skillBoxList;
    public List<System.Windows.Forms.Label> skillValueList;
    public System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.Label label23;
    private System.Windows.Forms.Label label24;
    private System.Windows.Forms.Label label26;
    private System.Windows.Forms.Label label27;
    private System.Windows.Forms.RichTextBox richTextBox3;
    private System.Windows.Forms.Label label28;
    private System.Windows.Forms.Label label29;
    private System.Windows.Forms.Label label30;
    private System.Windows.Forms.Label label31;
    private System.Windows.Forms.Label label32;
    private System.Windows.Forms.Label label33;
    private System.Windows.Forms.Label label34;
    private System.Windows.Forms.Label label35;
    private System.Windows.Forms.Label label36;
    private System.Windows.Forms.Label label37;
    private System.Windows.Forms.ListBox listBox2;
    private System.Windows.Forms.Label label25;
    private System.Windows.Forms.Label label38;
    private System.Windows.Forms.Label label39;
    private System.Windows.Forms.Label label40;
    private System.Windows.Forms.Label label41;
    private System.Windows.Forms.Label label42;
    private System.Windows.Forms.Label label43;
    private System.Windows.Forms.Label label44;
    private System.Windows.Forms.Label label45;
    private System.Windows.Forms.Label label46;
    private System.Windows.Forms.Label label47;
    private System.Windows.Forms.Label label48;
}