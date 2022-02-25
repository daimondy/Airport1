using System;
using System.Drawing;
using System.Windows.Forms;

namespace Airport
{
    partial class AppWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppWindow));
            this.panelAngAir = new System.Windows.Forms.Panel();
            this.labelHangar = new System.Windows.Forms.Label();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.labelInfo = new System.Windows.Forms.Label();
            this.labelInformacje = new System.Windows.Forms.Label();
            this.panelAirplaneInAir = new System.Windows.Forms.Panel();
            this.labelAirInAir = new System.Windows.Forms.Label();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.switchAssistant = new System.Windows.Forms.Label();
            this.btnSendAway = new System.Windows.Forms.Button();
            this.panelRunway1 = new System.Windows.Forms.Panel();
            this.panelRunway2 = new System.Windows.Forms.Panel();
            this.groupBoxNotification = new System.Windows.Forms.GroupBox();
            this.peopleCount = new System.Windows.Forms.TextBox();
            this.peoplePanel = new System.Windows.Forms.Panel();
            this.cargoPanel = new System.Windows.Forms.Panel();
            this.cargoCount = new System.Windows.Forms.TextBox();
            this.ammoPanel = new System.Windows.Forms.Panel();
            this.ammoCount = new System.Windows.Forms.TextBox();
            this.switchAcceptingIncomingPlanes = new System.Windows.Forms.Label();
            this.btnFuel = new System.Windows.Forms.Button();
            this.btnOnRunway = new System.Windows.Forms.Button();
            this.btnTechnicalInspection = new System.Windows.Forms.Button();
            this.btnCancelOperation = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnLand = new System.Windows.Forms.Button();
            this.btnUnload = new System.Windows.Forms.Button();
            this.panelPrzyciskow = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnToHangar = new System.Windows.Forms.Button();
            this.notificationListClear = new System.Windows.Forms.Label();
            this.switchOperationSingle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelAngAir.SuspendLayout();
            this.panelInfo.SuspendLayout();
            this.panelAirplaneInAir.SuspendLayout();
            this.peoplePanel.SuspendLayout();
            this.cargoPanel.SuspendLayout();
            this.ammoPanel.SuspendLayout();
            this.panelPrzyciskow.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelAngAir
            // 
            this.panelAngAir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(202)))), ((int)(((byte)(102)))));
            this.panelAngAir.Controls.Add(this.labelHangar);
            this.panelAngAir.Controls.Add(this.btnUp);
            this.panelAngAir.Controls.Add(this.btnDown);
            this.panelAngAir.Location = new System.Drawing.Point(17, 34);
            this.panelAngAir.Margin = new System.Windows.Forms.Padding(4);
            this.panelAngAir.Name = "panelAngAir";
            this.panelAngAir.Size = new System.Drawing.Size(369, 246);
            this.panelAngAir.TabIndex = 0;
            // 
            // labelHangar
            // 
            this.labelHangar.AutoSize = true;
            this.labelHangar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(202)))), ((int)(((byte)(102)))));
            this.labelHangar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelHangar.ForeColor = System.Drawing.Color.Black;
            this.labelHangar.Location = new System.Drawing.Point(89, 0);
            this.labelHangar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelHangar.Name = "labelHangar";
            this.labelHangar.Size = new System.Drawing.Size(184, 24);
            this.labelHangar.TabIndex = 0;
            this.labelHangar.Text = "Самолеты в ангаре";
            // 
            // btnUp
            // 
            this.btnUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(202)))), ((int)(((byte)(102)))));
            this.btnUp.ForeColor = System.Drawing.SystemColors.Control;
            this.btnUp.Image = global::Airport.Properties.Resources.btnUp;
            this.btnUp.Location = new System.Drawing.Point(329, 22);
            this.btnUp.Margin = new System.Windows.Forms.Padding(4);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(40, 37);
            this.btnUp.TabIndex = 1;
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.Click += new System.EventHandler(this.btnUp_click);
            // 
            // btnDown
            // 
            this.btnDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(202)))), ((int)(((byte)(102)))));
            this.btnDown.Image = global::Airport.Properties.Resources.btnDown;
            this.btnDown.Location = new System.Drawing.Point(329, 206);
            this.btnDown.Margin = new System.Windows.Forms.Padding(4);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(40, 37);
            this.btnDown.TabIndex = 2;
            this.btnDown.UseVisualStyleBackColor = false;
            this.btnDown.Click += new System.EventHandler(this.btnDown_click);
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(218)))), ((int)(((byte)(185)))));
            this.panelInfo.Controls.Add(this.labelInfo);
            this.panelInfo.Controls.Add(this.labelInformacje);
            this.panelInfo.Location = new System.Drawing.Point(481, 34);
            this.panelInfo.Margin = new System.Windows.Forms.Padding(4);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(401, 246);
            this.panelInfo.TabIndex = 0;
            this.panelInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.panelInformacji_Paint);
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(218)))), ((int)(((byte)(185)))));
            this.labelInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelInfo.ForeColor = System.Drawing.Color.Black;
            this.labelInfo.Location = new System.Drawing.Point(93, 0);
            this.labelInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(237, 24);
            this.labelInfo.TabIndex = 0;
            this.labelInfo.Text = "Информация о самолете:";
            // 
            // labelInformacje
            // 
            this.labelInformacje.AutoSize = true;
            this.labelInformacje.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelInformacje.ForeColor = System.Drawing.Color.Black;
            this.labelInformacje.Location = new System.Drawing.Point(10, 53);
            this.labelInformacje.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelInformacje.Name = "labelInformacje";
            this.labelInformacje.Size = new System.Drawing.Size(180, 24);
            this.labelInformacje.TabIndex = 0;
            this.labelInformacje.Text = "Выберите самолет";
            // 
            // panelAirplaneInAir
            // 
            this.panelAirplaneInAir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panelAirplaneInAir.Controls.Add(this.labelAirInAir);
            this.panelAirplaneInAir.Controls.Add(this.btnRight);
            this.panelAirplaneInAir.Controls.Add(this.btnLeft);
            this.panelAirplaneInAir.Location = new System.Drawing.Point(13, 295);
            this.panelAirplaneInAir.Margin = new System.Windows.Forms.Padding(4);
            this.panelAirplaneInAir.Name = "panelAirplaneInAir";
            this.panelAirplaneInAir.Size = new System.Drawing.Size(655, 134);
            this.panelAirplaneInAir.TabIndex = 0;
            // 
            // labelAirInAir
            // 
            this.labelAirInAir.AutoSize = true;
            this.labelAirInAir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.labelAirInAir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelAirInAir.ForeColor = System.Drawing.Color.Black;
            this.labelAirInAir.Location = new System.Drawing.Point(221, 0);
            this.labelAirInAir.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAirInAir.Name = "labelAirInAir";
            this.labelAirInAir.Size = new System.Drawing.Size(196, 24);
            this.labelAirInAir.TabIndex = 1;
            this.labelAirInAir.Text = "Самолеты в воздухе";
            // 
            // btnRight
            // 
            this.btnRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btnRight.Image = global::Airport.Properties.Resources.btnRight;
            this.btnRight.Location = new System.Drawing.Point(605, 94);
            this.btnRight.Margin = new System.Windows.Forms.Padding(4);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(40, 37);
            this.btnRight.TabIndex = 4;
            this.btnRight.UseVisualStyleBackColor = false;
            this.btnRight.Click += new System.EventHandler(this.btnRight_click);
            // 
            // btnLeft
            // 
            this.btnLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btnLeft.Image = global::Airport.Properties.Resources.btnLeft;
            this.btnLeft.Location = new System.Drawing.Point(4, 97);
            this.btnLeft.Margin = new System.Windows.Forms.Padding(4);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(40, 37);
            this.btnLeft.TabIndex = 3;
            this.btnLeft.UseVisualStyleBackColor = false;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_click);
            // 
            // switchAssistant
            // 
            this.switchAssistant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.switchAssistant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.switchAssistant.Location = new System.Drawing.Point(176, 6);
            this.switchAssistant.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.switchAssistant.Name = "switchAssistant";
            this.switchAssistant.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.switchAssistant.Size = new System.Drawing.Size(145, 54);
            this.switchAssistant.TabIndex = 17;
            this.switchAssistant.Text = "Автоматически";
            this.switchAssistant.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.switchAssistant.Click += new System.EventHandler(this.switchAssistant_click);
            // 
            // btnSendAway
            // 
            this.btnSendAway.BackColor = System.Drawing.Color.White;
            this.btnSendAway.Image = global::Airport.Properties.Resources.btnUp;
            this.btnSendAway.Location = new System.Drawing.Point(5, 73);
            this.btnSendAway.Margin = new System.Windows.Forms.Padding(4);
            this.btnSendAway.Name = "btnSendAway";
            this.btnSendAway.Size = new System.Drawing.Size(67, 62);
            this.btnSendAway.TabIndex = 15;
            this.btnSendAway.UseVisualStyleBackColor = false;
            this.btnSendAway.Click += new System.EventHandler(this.btnSendAway_click);
            // 
            // panelRunway1
            // 
            this.panelRunway1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(205)))), ((int)(((byte)(218)))));
            this.panelRunway1.Location = new System.Drawing.Point(13, 450);
            this.panelRunway1.Margin = new System.Windows.Forms.Padding(4);
            this.panelRunway1.Name = "panelRunway1";
            this.panelRunway1.Size = new System.Drawing.Size(655, 123);
            this.panelRunway1.TabIndex = 4;
            // 
            // panelRunway2
            // 
            this.panelRunway2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(205)))), ((int)(((byte)(218)))));
            this.panelRunway2.Location = new System.Drawing.Point(13, 591);
            this.panelRunway2.Margin = new System.Windows.Forms.Padding(4);
            this.panelRunway2.Name = "panelRunway2";
            this.panelRunway2.Size = new System.Drawing.Size(655, 123);
            this.panelRunway2.TabIndex = 5;
            // 
            // groupBoxNotification
            // 
            this.groupBoxNotification.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(218)))), ((int)(((byte)(185)))));
            this.groupBoxNotification.ForeColor = System.Drawing.SystemColors.WindowText;
            this.groupBoxNotification.Location = new System.Drawing.Point(696, 350);
            this.groupBoxNotification.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxNotification.Name = "groupBoxNotification";
            this.groupBoxNotification.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxNotification.Size = new System.Drawing.Size(327, 330);
            this.groupBoxNotification.TabIndex = 6;
            this.groupBoxNotification.TabStop = false;
            this.groupBoxNotification.Text = "Центр уведомлений";
            // 
            // peopleCount
            // 
            this.peopleCount.Enabled = false;
            this.peopleCount.Location = new System.Drawing.Point(19, 45);
            this.peopleCount.Margin = new System.Windows.Forms.Padding(4);
            this.peopleCount.Name = "peopleCount";
            this.peopleCount.ReadOnly = true;
            this.peopleCount.Size = new System.Drawing.Size(80, 22);
            this.peopleCount.TabIndex = 9;
            this.peopleCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // peoplePanel
            // 
            this.peoplePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.peoplePanel.BackgroundImage = global::Airport.Properties.Resources.people;
            this.peoplePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.peoplePanel.Controls.Add(this.peopleCount);
            this.peoplePanel.Location = new System.Drawing.Point(907, 38);
            this.peoplePanel.Margin = new System.Windows.Forms.Padding(4);
            this.peoplePanel.Name = "peoplePanel";
            this.peoplePanel.Size = new System.Drawing.Size(119, 73);
            this.peoplePanel.TabIndex = 10;
            this.peoplePanel.Click += new System.EventHandler(this.peoplePanel_Click);
            // 
            // cargoPanel
            // 
            this.cargoPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.cargoPanel.BackgroundImage = global::Airport.Properties.Resources.cargo;
            this.cargoPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cargoPanel.Controls.Add(this.cargoCount);
            this.cargoPanel.Location = new System.Drawing.Point(907, 122);
            this.cargoPanel.Margin = new System.Windows.Forms.Padding(4);
            this.cargoPanel.Name = "cargoPanel";
            this.cargoPanel.Size = new System.Drawing.Size(119, 73);
            this.cargoPanel.TabIndex = 11;
            this.cargoPanel.Click += new System.EventHandler(this.cargoPanel_Click);
            // 
            // cargoCount
            // 
            this.cargoCount.Enabled = false;
            this.cargoCount.Location = new System.Drawing.Point(19, 45);
            this.cargoCount.Margin = new System.Windows.Forms.Padding(4);
            this.cargoCount.Name = "cargoCount";
            this.cargoCount.ReadOnly = true;
            this.cargoCount.Size = new System.Drawing.Size(80, 22);
            this.cargoCount.TabIndex = 9;
            this.cargoCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ammoPanel
            // 
            this.ammoPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ammoPanel.BackgroundImage = global::Airport.Properties.Resources.ammo;
            this.ammoPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ammoPanel.Controls.Add(this.ammoCount);
            this.ammoPanel.Location = new System.Drawing.Point(907, 207);
            this.ammoPanel.Margin = new System.Windows.Forms.Padding(4);
            this.ammoPanel.Name = "ammoPanel";
            this.ammoPanel.Size = new System.Drawing.Size(119, 73);
            this.ammoPanel.TabIndex = 11;
            this.ammoPanel.Click += new System.EventHandler(this.ammoPanel_Click);
            // 
            // ammoCount
            // 
            this.ammoCount.Enabled = false;
            this.ammoCount.Location = new System.Drawing.Point(19, 45);
            this.ammoCount.Margin = new System.Windows.Forms.Padding(4);
            this.ammoCount.Name = "ammoCount";
            this.ammoCount.ReadOnly = true;
            this.ammoCount.Size = new System.Drawing.Size(80, 22);
            this.ammoCount.TabIndex = 9;
            this.ammoCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // switchAcceptingIncomingPlanes
            // 
            this.switchAcceptingIncomingPlanes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.switchAcceptingIncomingPlanes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.switchAcceptingIncomingPlanes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.switchAcceptingIncomingPlanes.Location = new System.Drawing.Point(4, 6);
            this.switchAcceptingIncomingPlanes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.switchAcceptingIncomingPlanes.Name = "switchAcceptingIncomingPlanes";
            this.switchAcceptingIncomingPlanes.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.switchAcceptingIncomingPlanes.Size = new System.Drawing.Size(164, 54);
            this.switchAcceptingIncomingPlanes.TabIndex = 14;
            this.switchAcceptingIncomingPlanes.Text = "Прием самолетов";
            this.switchAcceptingIncomingPlanes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.switchAcceptingIncomingPlanes.Click += new System.EventHandler(this.switchAcceptingIncomingPlanes_click);
            // 
            // btnFuel
            // 
            this.btnFuel.BackColor = System.Drawing.Color.White;
            this.btnFuel.Image = global::Airport.Properties.Resources.btnFuel;
            this.btnFuel.Location = new System.Drawing.Point(4, 4);
            this.btnFuel.Margin = new System.Windows.Forms.Padding(4);
            this.btnFuel.Name = "btnFuel";
            this.btnFuel.Size = new System.Drawing.Size(67, 62);
            this.btnFuel.TabIndex = 0;
            this.btnFuel.UseVisualStyleBackColor = false;
            this.btnFuel.Click += new System.EventHandler(this.btnFuel_click);
            // 
            // btnOnRunway
            // 
            this.btnOnRunway.BackColor = System.Drawing.Color.White;
            this.btnOnRunway.Image = ((System.Drawing.Image)(resources.GetObject("btnOnRunway.Image")));
            this.btnOnRunway.Location = new System.Drawing.Point(4, 142);
            this.btnOnRunway.Margin = new System.Windows.Forms.Padding(4);
            this.btnOnRunway.Name = "btnOnRunway";
            this.btnOnRunway.Size = new System.Drawing.Size(67, 62);
            this.btnOnRunway.TabIndex = 1;
            this.btnOnRunway.UseVisualStyleBackColor = false;
            this.btnOnRunway.Click += new System.EventHandler(this.btnOnRunway_click);
            // 
            // btnTechnicalInspection
            // 
            this.btnTechnicalInspection.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnTechnicalInspection.Image = global::Airport.Properties.Resources.techmanag;
            this.btnTechnicalInspection.Location = new System.Drawing.Point(5, 73);
            this.btnTechnicalInspection.Margin = new System.Windows.Forms.Padding(4);
            this.btnTechnicalInspection.Name = "btnTechnicalInspection";
            this.btnTechnicalInspection.Size = new System.Drawing.Size(67, 62);
            this.btnTechnicalInspection.TabIndex = 2;
            this.btnTechnicalInspection.UseVisualStyleBackColor = false;
            this.btnTechnicalInspection.Click += new System.EventHandler(this.btnTechnicalInspection_click);
            // 
            // btnCancelOperation
            // 
            this.btnCancelOperation.BackColor = System.Drawing.Color.Pink;
            this.btnCancelOperation.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelOperation.BackgroundImage")));
            this.btnCancelOperation.Location = new System.Drawing.Point(5, 4);
            this.btnCancelOperation.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelOperation.Name = "btnCancelOperation";
            this.btnCancelOperation.Size = new System.Drawing.Size(67, 62);
            this.btnCancelOperation.TabIndex = 3;
            this.btnCancelOperation.UseVisualStyleBackColor = false;
            this.btnCancelOperation.Click += new System.EventHandler(this.btnCancelOperation_click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.White;
            this.btnStart.Image = global::Airport.Properties.Resources.btnStart;
            this.btnStart.Location = new System.Drawing.Point(5, 142);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(67, 62);
            this.btnStart.TabIndex = 8;
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnTakeoff_click);
            // 
            // btnLand
            // 
            this.btnLand.BackColor = System.Drawing.Color.White;
            this.btnLand.Image = global::Airport.Properties.Resources.btnDown;
            this.btnLand.Location = new System.Drawing.Point(5, 4);
            this.btnLand.Margin = new System.Windows.Forms.Padding(4);
            this.btnLand.Name = "btnLand";
            this.btnLand.Size = new System.Drawing.Size(67, 62);
            this.btnLand.TabIndex = 14;
            this.btnLand.UseVisualStyleBackColor = false;
            this.btnLand.Click += new System.EventHandler(this.btnLand_click);
            // 
            // btnUnload
            // 
            this.btnUnload.BackColor = System.Drawing.Color.White;
            this.btnUnload.Image = global::Airport.Properties.Resources.btnDown;
            this.btnUnload.Location = new System.Drawing.Point(5, 4);
            this.btnUnload.Margin = new System.Windows.Forms.Padding(4);
            this.btnUnload.Name = "btnUnload";
            this.btnUnload.Size = new System.Drawing.Size(67, 62);
            this.btnUnload.TabIndex = 16;
            this.btnUnload.UseVisualStyleBackColor = false;
            this.btnUnload.Click += new System.EventHandler(this.btnUnload_Click);
            // 
            // panelPrzyciskow
            // 
            this.panelPrzyciskow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(112)))), ((int)(((byte)(83)))));
            this.panelPrzyciskow.Controls.Add(this.btnDelete);
            this.panelPrzyciskow.Controls.Add(this.btnUnload);
            this.panelPrzyciskow.Controls.Add(this.btnSendAway);
            this.panelPrzyciskow.Controls.Add(this.btnLand);
            this.panelPrzyciskow.Controls.Add(this.btnStart);
            this.panelPrzyciskow.Controls.Add(this.btnToHangar);
            this.panelPrzyciskow.Controls.Add(this.btnCancelOperation);
            this.panelPrzyciskow.Controls.Add(this.btnTechnicalInspection);
            this.panelPrzyciskow.Controls.Add(this.btnOnRunway);
            this.panelPrzyciskow.Controls.Add(this.btnFuel);
            this.panelPrzyciskow.Location = new System.Drawing.Point(394, 56);
            this.panelPrzyciskow.Margin = new System.Windows.Forms.Padding(4);
            this.panelPrzyciskow.Name = "panelPrzyciskow";
            this.panelPrzyciskow.Size = new System.Drawing.Size(79, 209);
            this.panelPrzyciskow.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.Image = global::Airport.Properties.Resources.destroyed;
            this.btnDelete.Location = new System.Drawing.Point(5, 4);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(67, 62);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnToHangar
            // 
            this.btnToHangar.BackColor = System.Drawing.Color.White;
            this.btnToHangar.Image = global::Airport.Properties.Resources.btnDoHangar;
            this.btnToHangar.Location = new System.Drawing.Point(5, 73);
            this.btnToHangar.Margin = new System.Windows.Forms.Padding(4);
            this.btnToHangar.Name = "btnToHangar";
            this.btnToHangar.Size = new System.Drawing.Size(67, 62);
            this.btnToHangar.TabIndex = 5;
            this.btnToHangar.UseVisualStyleBackColor = false;
            this.btnToHangar.Click += new System.EventHandler(this.btnToHangar_click);
            // 
            // notificationListClear
            // 
            this.notificationListClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(202)))), ((int)(((byte)(102)))));
            this.notificationListClear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.notificationListClear.Location = new System.Drawing.Point(696, 684);
            this.notificationListClear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.notificationListClear.Name = "notificationListClear";
            this.notificationListClear.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.notificationListClear.Size = new System.Drawing.Size(321, 30);
            this.notificationListClear.TabIndex = 15;
            this.notificationListClear.Text = "Очистить список";
            this.notificationListClear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.notificationListClear.Click += new System.EventHandler(this.notificationListClear_Click);
            // 
            // switchOperationSingle
            // 
            this.switchOperationSingle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(112)))), ((int)(((byte)(83)))));
            this.switchOperationSingle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.switchOperationSingle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(112)))), ((int)(((byte)(83)))));
            this.switchOperationSingle.Location = new System.Drawing.Point(399, 9);
            this.switchOperationSingle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.switchOperationSingle.Name = "switchOperationSingle";
            this.switchOperationSingle.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.switchOperationSingle.Size = new System.Drawing.Size(72, 33);
            this.switchOperationSingle.TabIndex = 16;
            this.switchOperationSingle.Text = "Операция";
            this.switchOperationSingle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.switchOperationSingle.Visible = false;
            this.switchOperationSingle.Click += new System.EventHandler(this.switchOperationSingle_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(112)))), ((int)(((byte)(83)))));
            this.panel1.Controls.Add(this.switchAcceptingIncomingPlanes);
            this.panel1.Controls.Add(this.switchAssistant);
            this.panel1.Location = new System.Drawing.Point(696, 286);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(327, 60);
            this.panel1.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(112)))), ((int)(((byte)(83)))));
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(-7, -12);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1239, 763);
            this.panel2.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.InitialImage = global::Airport.Properties.Resources.t2;
            this.pictureBox1.Location = new System.Drawing.Point(1096, 206);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 81);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // AppWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(205)))), ((int)(((byte)(218)))));
            this.ClientSize = new System.Drawing.Size(1226, 750);
            this.Controls.Add(this.panelRunway2);
            this.Controls.Add(this.panelRunway1);
            this.Controls.Add(this.switchOperationSingle);
            this.Controls.Add(this.panelAirplaneInAir);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.notificationListClear);
            this.Controls.Add(this.ammoPanel);
            this.Controls.Add(this.cargoPanel);
            this.Controls.Add(this.peoplePanel);
            this.Controls.Add(this.groupBoxNotification);
            this.Controls.Add(this.panelAngAir);
            this.Controls.Add(this.panelPrzyciskow);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AppWindow";
            this.Text = "Модель взлета и посадки самолетов в аэропорту";
            this.Load += new System.EventHandler(this.AppWindow_Load);
            this.panelAngAir.ResumeLayout(false);
            this.panelAngAir.PerformLayout();
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.panelAirplaneInAir.ResumeLayout(false);
            this.panelAirplaneInAir.PerformLayout();
            this.peoplePanel.ResumeLayout(false);
            this.peoplePanel.PerformLayout();
            this.cargoPanel.ResumeLayout(false);
            this.cargoPanel.PerformLayout();
            this.ammoPanel.ResumeLayout(false);
            this.ammoPanel.PerformLayout();
            this.panelPrzyciskow.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        // moj kod

        private System.Windows.Forms.Panel panelAngAir;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Label labelHangar;
        private System.Windows.Forms.Label labelInformacje;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Panel panelAirplaneInAir;
        private Panel panelRunway1;
        private Panel panelRunway2;
        private Label labelAirInAir;
        private Button btnDown;
        private Button btnUp;
        private Button btnRight;
        private Button btnLeft;
        private GroupBox groupBoxNotification;
        private Button btnSendAway;
        private TextBox peopleCount;
        private Panel peoplePanel;
        private Panel cargoPanel;
        private TextBox cargoCount;
        private Panel ammoPanel;
        private TextBox ammoCount;
        private Label switchAcceptingIncomingPlanes;
        private Button btnFuel;
        private Button btnOnRunway;
        private Button btnTechnicalInspection;
        private Button btnCancelOperation;
        private Button btnStart;
        private Button btnLand;
        private Button btnUnload;
        private Panel panelPrzyciskow;
        private Button btnToHangar;
        private Label notificationListClear;
        private Label switchOperationSingle;
        private Label switchAssistant;
        private Panel panel1;
        private Button btnDelete;
        private Panel panel2;
        private PictureBox pictureBox1;
    }
}

