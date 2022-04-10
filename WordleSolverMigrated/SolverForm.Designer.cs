using global::System;
using global::System.Collections.Generic;
using global::System.Drawing;
using global::System.IO;
using global::System.Linq;
using global::System.Net.Http;
using global::System.Threading;
using global::System.Threading.Tasks;
using global::System.Windows.Forms;

namespace WordleSolver
{
    partial class SolverForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SolverForm));
            this.ltrA = new System.Windows.Forms.Label();
            this.ltrB = new System.Windows.Forms.Label();
            this.ltrC = new System.Windows.Forms.Label();
            this.ltrD = new System.Windows.Forms.Label();
            this.ltrE = new System.Windows.Forms.Label();
            this.ltrF = new System.Windows.Forms.Label();
            this.ltrG = new System.Windows.Forms.Label();
            this.ltrH = new System.Windows.Forms.Label();
            this.ltrI = new System.Windows.Forms.Label();
            this.ltrJ = new System.Windows.Forms.Label();
            this.ltrK = new System.Windows.Forms.Label();
            this.ltrL = new System.Windows.Forms.Label();
            this.ltrM = new System.Windows.Forms.Label();
            this.ltrZ = new System.Windows.Forms.Label();
            this.ltrY = new System.Windows.Forms.Label();
            this.ltrX = new System.Windows.Forms.Label();
            this.ltrW = new System.Windows.Forms.Label();
            this.ltrV = new System.Windows.Forms.Label();
            this.ltrU = new System.Windows.Forms.Label();
            this.ltrT = new System.Windows.Forms.Label();
            this.ltrS = new System.Windows.Forms.Label();
            this.ltrR = new System.Windows.Forms.Label();
            this.ltrQ = new System.Windows.Forms.Label();
            this.ltrP = new System.Windows.Forms.Label();
            this.ltrO = new System.Windows.Forms.Label();
            this.ltrN = new System.Windows.Forms.Label();
            this.ltr0 = new System.Windows.Forms.Label();
            this.ltr1 = new System.Windows.Forms.Label();
            this.ltr2 = new System.Windows.Forms.Label();
            this.ltr3 = new System.Windows.Forms.Label();
            this.ltr4 = new System.Windows.Forms.Label();
            this.lsbTargetPopularity = new System.Windows.Forms.ListBox();
            this.lblRemain = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnHelp = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDeduct = new System.Windows.Forms.Label();
            this.btnResetSolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ltrA
            // 
            this.ltrA.AllowDrop = true;
            this.ltrA.BackColor = System.Drawing.Color.LightCyan;
            this.ltrA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ltrA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ltrA.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.ltrA.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ltrA.Location = new System.Drawing.Point(16, 28);
            this.ltrA.Name = "ltrA";
            this.ltrA.Size = new System.Drawing.Size(27, 35);
            this.ltrA.TabIndex = 0;
            this.ltrA.Tag = "Alpha";
            this.ltrA.Text = "A";
            this.ltrA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ltrA.MouseClick += new System.Windows.Forms.MouseEventHandler(this.letterClickEvent);
            this.ltrA.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ltr_MouseMove);
            // 
            // ltrB
            // 
            this.ltrB.AllowDrop = true;
            this.ltrB.BackColor = System.Drawing.Color.LightCyan;
            this.ltrB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ltrB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ltrB.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.ltrB.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ltrB.Location = new System.Drawing.Point(58, 28);
            this.ltrB.Name = "ltrB";
            this.ltrB.Size = new System.Drawing.Size(27, 35);
            this.ltrB.TabIndex = 1;
            this.ltrB.Tag = "Alpha";
            this.ltrB.Text = "B";
            this.ltrB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ltrB.MouseClick += new System.Windows.Forms.MouseEventHandler(this.letterClickEvent);
            this.ltrB.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ltr_MouseMove);
            // 
            // ltrC
            // 
            this.ltrC.AllowDrop = true;
            this.ltrC.BackColor = System.Drawing.Color.LightCyan;
            this.ltrC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ltrC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ltrC.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.ltrC.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ltrC.Location = new System.Drawing.Point(100, 28);
            this.ltrC.Name = "ltrC";
            this.ltrC.Size = new System.Drawing.Size(27, 35);
            this.ltrC.TabIndex = 2;
            this.ltrC.Tag = "Alpha";
            this.ltrC.Text = "C";
            this.ltrC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ltrC.MouseClick += new System.Windows.Forms.MouseEventHandler(this.letterClickEvent);
            this.ltrC.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ltr_MouseMove);
            // 
            // ltrD
            // 
            this.ltrD.AllowDrop = true;
            this.ltrD.BackColor = System.Drawing.Color.LightCyan;
            this.ltrD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ltrD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ltrD.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.ltrD.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ltrD.Location = new System.Drawing.Point(143, 28);
            this.ltrD.Name = "ltrD";
            this.ltrD.Size = new System.Drawing.Size(27, 35);
            this.ltrD.TabIndex = 3;
            this.ltrD.Tag = "Alpha";
            this.ltrD.Text = "D";
            this.ltrD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ltrD.MouseClick += new System.Windows.Forms.MouseEventHandler(this.letterClickEvent);
            this.ltrD.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ltr_MouseMove);
            // 
            // ltrE
            // 
            this.ltrE.AllowDrop = true;
            this.ltrE.BackColor = System.Drawing.Color.LightCyan;
            this.ltrE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ltrE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ltrE.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.ltrE.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ltrE.Location = new System.Drawing.Point(184, 28);
            this.ltrE.Name = "ltrE";
            this.ltrE.Size = new System.Drawing.Size(27, 35);
            this.ltrE.TabIndex = 4;
            this.ltrE.Tag = "Alpha";
            this.ltrE.Text = "E";
            this.ltrE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ltrE.MouseClick += new System.Windows.Forms.MouseEventHandler(this.letterClickEvent);
            this.ltrE.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ltr_MouseMove);
            // 
            // ltrF
            // 
            this.ltrF.AllowDrop = true;
            this.ltrF.BackColor = System.Drawing.Color.LightCyan;
            this.ltrF.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ltrF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ltrF.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.ltrF.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ltrF.Location = new System.Drawing.Point(226, 28);
            this.ltrF.Name = "ltrF";
            this.ltrF.Size = new System.Drawing.Size(27, 35);
            this.ltrF.TabIndex = 5;
            this.ltrF.Tag = "Alpha";
            this.ltrF.Text = "F";
            this.ltrF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ltrF.MouseClick += new System.Windows.Forms.MouseEventHandler(this.letterClickEvent);
            this.ltrF.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ltr_MouseMove);
            // 
            // ltrG
            // 
            this.ltrG.AllowDrop = true;
            this.ltrG.BackColor = System.Drawing.Color.LightCyan;
            this.ltrG.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ltrG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ltrG.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.ltrG.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ltrG.Location = new System.Drawing.Point(268, 28);
            this.ltrG.Name = "ltrG";
            this.ltrG.Size = new System.Drawing.Size(27, 35);
            this.ltrG.TabIndex = 6;
            this.ltrG.Tag = "Alpha";
            this.ltrG.Text = "G";
            this.ltrG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ltrG.MouseClick += new System.Windows.Forms.MouseEventHandler(this.letterClickEvent);
            this.ltrG.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ltr_MouseMove);
            // 
            // ltrH
            // 
            this.ltrH.AllowDrop = true;
            this.ltrH.BackColor = System.Drawing.Color.LightCyan;
            this.ltrH.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ltrH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ltrH.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.ltrH.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ltrH.Location = new System.Drawing.Point(310, 28);
            this.ltrH.Name = "ltrH";
            this.ltrH.Size = new System.Drawing.Size(27, 35);
            this.ltrH.TabIndex = 7;
            this.ltrH.Tag = "Alpha";
            this.ltrH.Text = "H";
            this.ltrH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ltrH.MouseClick += new System.Windows.Forms.MouseEventHandler(this.letterClickEvent);
            this.ltrH.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ltr_MouseMove);
            // 
            // ltrI
            // 
            this.ltrI.AllowDrop = true;
            this.ltrI.BackColor = System.Drawing.Color.LightCyan;
            this.ltrI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ltrI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ltrI.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.ltrI.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ltrI.Location = new System.Drawing.Point(352, 28);
            this.ltrI.Name = "ltrI";
            this.ltrI.Size = new System.Drawing.Size(27, 35);
            this.ltrI.TabIndex = 8;
            this.ltrI.Tag = "Alpha";
            this.ltrI.Text = "I";
            this.ltrI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ltrI.MouseClick += new System.Windows.Forms.MouseEventHandler(this.letterClickEvent);
            this.ltrI.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ltr_MouseMove);
            // 
            // ltrJ
            // 
            this.ltrJ.AllowDrop = true;
            this.ltrJ.BackColor = System.Drawing.Color.LightCyan;
            this.ltrJ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ltrJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ltrJ.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.ltrJ.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ltrJ.Location = new System.Drawing.Point(394, 28);
            this.ltrJ.Name = "ltrJ";
            this.ltrJ.Size = new System.Drawing.Size(27, 35);
            this.ltrJ.TabIndex = 9;
            this.ltrJ.Tag = "Alpha";
            this.ltrJ.Text = "J";
            this.ltrJ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ltrJ.MouseClick += new System.Windows.Forms.MouseEventHandler(this.letterClickEvent);
            this.ltrJ.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ltr_MouseMove);
            // 
            // ltrK
            // 
            this.ltrK.AllowDrop = true;
            this.ltrK.BackColor = System.Drawing.Color.LightCyan;
            this.ltrK.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ltrK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ltrK.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.ltrK.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ltrK.Location = new System.Drawing.Point(436, 28);
            this.ltrK.Name = "ltrK";
            this.ltrK.Size = new System.Drawing.Size(27, 35);
            this.ltrK.TabIndex = 10;
            this.ltrK.Tag = "Alpha";
            this.ltrK.Text = "K";
            this.ltrK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ltrK.MouseClick += new System.Windows.Forms.MouseEventHandler(this.letterClickEvent);
            this.ltrK.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ltr_MouseMove);
            // 
            // ltrL
            // 
            this.ltrL.AllowDrop = true;
            this.ltrL.BackColor = System.Drawing.Color.LightCyan;
            this.ltrL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ltrL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ltrL.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.ltrL.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ltrL.Location = new System.Drawing.Point(478, 28);
            this.ltrL.Name = "ltrL";
            this.ltrL.Size = new System.Drawing.Size(27, 35);
            this.ltrL.TabIndex = 11;
            this.ltrL.Tag = "Alpha";
            this.ltrL.Text = "L";
            this.ltrL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ltrL.MouseClick += new System.Windows.Forms.MouseEventHandler(this.letterClickEvent);
            this.ltrL.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ltr_MouseMove);
            // 
            // ltrM
            // 
            this.ltrM.AllowDrop = true;
            this.ltrM.BackColor = System.Drawing.Color.LightCyan;
            this.ltrM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ltrM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ltrM.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.ltrM.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ltrM.Location = new System.Drawing.Point(520, 28);
            this.ltrM.Name = "ltrM";
            this.ltrM.Size = new System.Drawing.Size(27, 35);
            this.ltrM.TabIndex = 12;
            this.ltrM.Tag = "Alpha";
            this.ltrM.Text = "M";
            this.ltrM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ltrM.MouseClick += new System.Windows.Forms.MouseEventHandler(this.letterClickEvent);
            this.ltrM.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ltr_MouseMove);
            // 
            // ltrZ
            // 
            this.ltrZ.AllowDrop = true;
            this.ltrZ.BackColor = System.Drawing.Color.LightCyan;
            this.ltrZ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ltrZ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ltrZ.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.ltrZ.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ltrZ.Location = new System.Drawing.Point(520, 77);
            this.ltrZ.Name = "ltrZ";
            this.ltrZ.Size = new System.Drawing.Size(27, 35);
            this.ltrZ.TabIndex = 25;
            this.ltrZ.Tag = "Alpha";
            this.ltrZ.Text = "Z";
            this.ltrZ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ltrZ.MouseClick += new System.Windows.Forms.MouseEventHandler(this.letterClickEvent);
            this.ltrZ.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ltr_MouseMove);
            // 
            // ltrY
            // 
            this.ltrY.AllowDrop = true;
            this.ltrY.BackColor = System.Drawing.Color.LightCyan;
            this.ltrY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ltrY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ltrY.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.ltrY.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ltrY.Location = new System.Drawing.Point(478, 77);
            this.ltrY.Name = "ltrY";
            this.ltrY.Size = new System.Drawing.Size(27, 35);
            this.ltrY.TabIndex = 24;
            this.ltrY.Tag = "Alpha";
            this.ltrY.Text = "Y";
            this.ltrY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ltrY.MouseClick += new System.Windows.Forms.MouseEventHandler(this.letterClickEvent);
            this.ltrY.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ltr_MouseMove);
            // 
            // ltrX
            // 
            this.ltrX.AllowDrop = true;
            this.ltrX.BackColor = System.Drawing.Color.LightCyan;
            this.ltrX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ltrX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ltrX.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.ltrX.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ltrX.Location = new System.Drawing.Point(436, 77);
            this.ltrX.Name = "ltrX";
            this.ltrX.Size = new System.Drawing.Size(27, 35);
            this.ltrX.TabIndex = 23;
            this.ltrX.Tag = "Alpha";
            this.ltrX.Text = "X";
            this.ltrX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ltrX.MouseClick += new System.Windows.Forms.MouseEventHandler(this.letterClickEvent);
            this.ltrX.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ltr_MouseMove);
            // 
            // ltrW
            // 
            this.ltrW.AllowDrop = true;
            this.ltrW.BackColor = System.Drawing.Color.LightCyan;
            this.ltrW.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ltrW.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ltrW.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.ltrW.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ltrW.Location = new System.Drawing.Point(394, 77);
            this.ltrW.Name = "ltrW";
            this.ltrW.Size = new System.Drawing.Size(27, 35);
            this.ltrW.TabIndex = 22;
            this.ltrW.Tag = "Alpha";
            this.ltrW.Text = "W";
            this.ltrW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ltrW.MouseClick += new System.Windows.Forms.MouseEventHandler(this.letterClickEvent);
            this.ltrW.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ltr_MouseMove);
            // 
            // ltrV
            // 
            this.ltrV.AllowDrop = true;
            this.ltrV.BackColor = System.Drawing.Color.LightCyan;
            this.ltrV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ltrV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ltrV.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.ltrV.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ltrV.Location = new System.Drawing.Point(352, 77);
            this.ltrV.Name = "ltrV";
            this.ltrV.Size = new System.Drawing.Size(27, 35);
            this.ltrV.TabIndex = 21;
            this.ltrV.Tag = "Alpha";
            this.ltrV.Text = "V";
            this.ltrV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ltrV.MouseClick += new System.Windows.Forms.MouseEventHandler(this.letterClickEvent);
            this.ltrV.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ltr_MouseMove);
            // 
            // ltrU
            // 
            this.ltrU.AllowDrop = true;
            this.ltrU.BackColor = System.Drawing.Color.LightCyan;
            this.ltrU.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ltrU.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ltrU.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.ltrU.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ltrU.Location = new System.Drawing.Point(310, 77);
            this.ltrU.Name = "ltrU";
            this.ltrU.Size = new System.Drawing.Size(27, 35);
            this.ltrU.TabIndex = 20;
            this.ltrU.Tag = "Alpha";
            this.ltrU.Text = "U";
            this.ltrU.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ltrU.MouseClick += new System.Windows.Forms.MouseEventHandler(this.letterClickEvent);
            this.ltrU.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ltr_MouseMove);
            // 
            // ltrT
            // 
            this.ltrT.AllowDrop = true;
            this.ltrT.BackColor = System.Drawing.Color.LightCyan;
            this.ltrT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ltrT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ltrT.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.ltrT.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ltrT.Location = new System.Drawing.Point(268, 77);
            this.ltrT.Name = "ltrT";
            this.ltrT.Size = new System.Drawing.Size(27, 35);
            this.ltrT.TabIndex = 19;
            this.ltrT.Tag = "Alpha";
            this.ltrT.Text = "T";
            this.ltrT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ltrT.MouseClick += new System.Windows.Forms.MouseEventHandler(this.letterClickEvent);
            this.ltrT.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ltr_MouseMove);
            // 
            // ltrS
            // 
            this.ltrS.AllowDrop = true;
            this.ltrS.BackColor = System.Drawing.Color.LightCyan;
            this.ltrS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ltrS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ltrS.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.ltrS.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ltrS.Location = new System.Drawing.Point(226, 77);
            this.ltrS.Name = "ltrS";
            this.ltrS.Size = new System.Drawing.Size(27, 35);
            this.ltrS.TabIndex = 18;
            this.ltrS.Tag = "Alpha";
            this.ltrS.Text = "S";
            this.ltrS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ltrS.MouseClick += new System.Windows.Forms.MouseEventHandler(this.letterClickEvent);
            this.ltrS.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ltr_MouseMove);
            // 
            // ltrR
            // 
            this.ltrR.AllowDrop = true;
            this.ltrR.BackColor = System.Drawing.Color.LightCyan;
            this.ltrR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ltrR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ltrR.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.ltrR.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ltrR.Location = new System.Drawing.Point(184, 77);
            this.ltrR.Name = "ltrR";
            this.ltrR.Size = new System.Drawing.Size(27, 35);
            this.ltrR.TabIndex = 17;
            this.ltrR.Tag = "Alpha";
            this.ltrR.Text = "R";
            this.ltrR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ltrR.MouseClick += new System.Windows.Forms.MouseEventHandler(this.letterClickEvent);
            this.ltrR.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ltr_MouseMove);
            // 
            // ltrQ
            // 
            this.ltrQ.AllowDrop = true;
            this.ltrQ.BackColor = System.Drawing.Color.LightCyan;
            this.ltrQ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ltrQ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ltrQ.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.ltrQ.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ltrQ.Location = new System.Drawing.Point(142, 77);
            this.ltrQ.Name = "ltrQ";
            this.ltrQ.Size = new System.Drawing.Size(27, 35);
            this.ltrQ.TabIndex = 16;
            this.ltrQ.Tag = "Alpha";
            this.ltrQ.Text = "Q";
            this.ltrQ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ltrQ.MouseClick += new System.Windows.Forms.MouseEventHandler(this.letterClickEvent);
            this.ltrQ.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ltr_MouseMove);
            // 
            // ltrP
            // 
            this.ltrP.AllowDrop = true;
            this.ltrP.BackColor = System.Drawing.Color.LightCyan;
            this.ltrP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ltrP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ltrP.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.ltrP.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ltrP.Location = new System.Drawing.Point(100, 77);
            this.ltrP.Name = "ltrP";
            this.ltrP.Size = new System.Drawing.Size(27, 35);
            this.ltrP.TabIndex = 15;
            this.ltrP.Tag = "Alpha";
            this.ltrP.Text = "P";
            this.ltrP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ltrP.MouseClick += new System.Windows.Forms.MouseEventHandler(this.letterClickEvent);
            this.ltrP.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ltr_MouseMove);
            // 
            // ltrO
            // 
            this.ltrO.AllowDrop = true;
            this.ltrO.BackColor = System.Drawing.Color.LightCyan;
            this.ltrO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ltrO.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ltrO.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.ltrO.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ltrO.Location = new System.Drawing.Point(58, 77);
            this.ltrO.Name = "ltrO";
            this.ltrO.Size = new System.Drawing.Size(27, 35);
            this.ltrO.TabIndex = 14;
            this.ltrO.Tag = "Alpha";
            this.ltrO.Text = "O";
            this.ltrO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ltrO.MouseClick += new System.Windows.Forms.MouseEventHandler(this.letterClickEvent);
            this.ltrO.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ltr_MouseMove);
            // 
            // ltrN
            // 
            this.ltrN.AllowDrop = true;
            this.ltrN.BackColor = System.Drawing.Color.LightCyan;
            this.ltrN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ltrN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ltrN.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.ltrN.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ltrN.Location = new System.Drawing.Point(16, 77);
            this.ltrN.Name = "ltrN";
            this.ltrN.Size = new System.Drawing.Size(27, 35);
            this.ltrN.TabIndex = 13;
            this.ltrN.Tag = "Alpha";
            this.ltrN.Text = "N";
            this.ltrN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ltrN.MouseClick += new System.Windows.Forms.MouseEventHandler(this.letterClickEvent);
            this.ltrN.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ltr_MouseMove);
            // 
            // ltr0
            // 
            this.ltr0.AllowDrop = true;
            this.ltr0.BackColor = System.Drawing.Color.Gray;
            this.ltr0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ltr0.Font = new System.Drawing.Font("Times New Roman", 30F);
            this.ltr0.Location = new System.Drawing.Point(16, 138);
            this.ltr0.Name = "ltr0";
            this.ltr0.Size = new System.Drawing.Size(86, 87);
            this.ltr0.TabIndex = 26;
            this.ltr0.Tag = "TargetLetter";
            this.ltr0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ltr0.DragDrop += new System.Windows.Forms.DragEventHandler(this.lbl_DragDrop);
            this.ltr0.DragOver += new System.Windows.Forms.DragEventHandler(this.lbl_DragOver);
            // 
            // ltr1
            // 
            this.ltr1.AllowDrop = true;
            this.ltr1.BackColor = System.Drawing.Color.Gray;
            this.ltr1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ltr1.Font = new System.Drawing.Font("Times New Roman", 30F);
            this.ltr1.Location = new System.Drawing.Point(139, 138);
            this.ltr1.Name = "ltr1";
            this.ltr1.Size = new System.Drawing.Size(86, 87);
            this.ltr1.TabIndex = 27;
            this.ltr1.Tag = "TargetLetter";
            this.ltr1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ltr1.DragDrop += new System.Windows.Forms.DragEventHandler(this.lbl_DragDrop);
            this.ltr1.DragOver += new System.Windows.Forms.DragEventHandler(this.lbl_DragOver);
            // 
            // ltr2
            // 
            this.ltr2.AllowDrop = true;
            this.ltr2.BackColor = System.Drawing.Color.Gray;
            this.ltr2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ltr2.Font = new System.Drawing.Font("Times New Roman", 30F);
            this.ltr2.Location = new System.Drawing.Point(261, 138);
            this.ltr2.Name = "ltr2";
            this.ltr2.Size = new System.Drawing.Size(86, 87);
            this.ltr2.TabIndex = 28;
            this.ltr2.Tag = "TargetLetter";
            this.ltr2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ltr2.DragDrop += new System.Windows.Forms.DragEventHandler(this.lbl_DragDrop);
            this.ltr2.DragOver += new System.Windows.Forms.DragEventHandler(this.lbl_DragOver);
            // 
            // ltr3
            // 
            this.ltr3.AllowDrop = true;
            this.ltr3.BackColor = System.Drawing.Color.Gray;
            this.ltr3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ltr3.Font = new System.Drawing.Font("Times New Roman", 30F);
            this.ltr3.Location = new System.Drawing.Point(384, 138);
            this.ltr3.Name = "ltr3";
            this.ltr3.Size = new System.Drawing.Size(86, 87);
            this.ltr3.TabIndex = 29;
            this.ltr3.Tag = "TargetLetter";
            this.ltr3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ltr3.DragDrop += new System.Windows.Forms.DragEventHandler(this.lbl_DragDrop);
            this.ltr3.DragOver += new System.Windows.Forms.DragEventHandler(this.lbl_DragOver);
            // 
            // ltr4
            // 
            this.ltr4.AllowDrop = true;
            this.ltr4.BackColor = System.Drawing.Color.Gray;
            this.ltr4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ltr4.Font = new System.Drawing.Font("Times New Roman", 30F);
            this.ltr4.Location = new System.Drawing.Point(507, 138);
            this.ltr4.Name = "ltr4";
            this.ltr4.Size = new System.Drawing.Size(86, 87);
            this.ltr4.TabIndex = 30;
            this.ltr4.Tag = "TargetLetter";
            this.ltr4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ltr4.DragDrop += new System.Windows.Forms.DragEventHandler(this.lbl_DragDrop);
            this.ltr4.DragOver += new System.Windows.Forms.DragEventHandler(this.lbl_DragOver);
            // 
            // lsbTargetPopularity
            // 
            this.lsbTargetPopularity.FormattingEnabled = true;
            this.lsbTargetPopularity.HorizontalScrollbar = true;
            this.lsbTargetPopularity.Location = new System.Drawing.Point(20, 257);
            this.lsbTargetPopularity.MultiColumn = true;
            this.lsbTargetPopularity.Name = "lsbTargetPopularity";
            this.lsbTargetPopularity.Size = new System.Drawing.Size(573, 225);
            this.lsbTargetPopularity.TabIndex = 31;
            // 
            // lblRemain
            // 
            this.lblRemain.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblRemain.Location = new System.Drawing.Point(495, 228);
            this.lblRemain.Name = "lblRemain";
            this.lblRemain.Size = new System.Drawing.Size(98, 29);
            this.lblRemain.TabIndex = 33;
            this.lblRemain.Text = "0";
            this.lblRemain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(566, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Help";
            // 
            // btnHelp
            // 
            this.btnHelp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHelp.Font = new System.Drawing.Font("Segoe UI", 27.75F);
            this.btnHelp.Location = new System.Drawing.Point(561, 39);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(39, 65);
            this.btnHelp.TabIndex = 39;
            this.btnHelp.Text = "?";
            this.btnHelp.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 485);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(332, 31);
            this.label4.TabIndex = 42;
            this.label4.Text = "Most Deductive Guess Word:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(20, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(421, 19);
            this.label3.TabIndex = 43;
            this.label3.Text = "All Remaining Possible Target Words By Universal Popularity";
            // 
            // lblDeduct
            // 
            this.lblDeduct.AutoSize = true;
            this.lblDeduct.Font = new System.Drawing.Font("Times New Roman", 21.75F);
            this.lblDeduct.Location = new System.Drawing.Point(361, 482);
            this.lblDeduct.Name = "lblDeduct";
            this.lblDeduct.Size = new System.Drawing.Size(90, 33);
            this.lblDeduct.TabIndex = 44;
            this.lblDeduct.Text = "deduct";
            this.lblDeduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnResetSolver
            // 
            this.btnResetSolver.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnResetSolver.Location = new System.Drawing.Point(480, 489);
            this.btnResetSolver.Name = "btnResetSolver";
            this.btnResetSolver.Size = new System.Drawing.Size(108, 25);
            this.btnResetSolver.TabIndex = 45;
            this.btnResetSolver.Text = "Reset Solver";
            this.btnResetSolver.UseVisualStyleBackColor = true;
            this.btnResetSolver.Click += new System.EventHandler(this.btnResetSolver_Click);
            // 
            // SolverForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 519);
            this.Controls.Add(this.btnResetSolver);
            this.Controls.Add(this.lblDeduct);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblRemain);
            this.Controls.Add(this.lsbTargetPopularity);
            this.Controls.Add(this.ltr4);
            this.Controls.Add(this.ltr3);
            this.Controls.Add(this.ltr2);
            this.Controls.Add(this.ltr1);
            this.Controls.Add(this.ltr0);
            this.Controls.Add(this.ltrZ);
            this.Controls.Add(this.ltrY);
            this.Controls.Add(this.ltrX);
            this.Controls.Add(this.ltrW);
            this.Controls.Add(this.ltrV);
            this.Controls.Add(this.ltrU);
            this.Controls.Add(this.ltrT);
            this.Controls.Add(this.ltrS);
            this.Controls.Add(this.ltrR);
            this.Controls.Add(this.ltrQ);
            this.Controls.Add(this.ltrP);
            this.Controls.Add(this.ltrO);
            this.Controls.Add(this.ltrN);
            this.Controls.Add(this.ltrM);
            this.Controls.Add(this.ltrL);
            this.Controls.Add(this.ltrK);
            this.Controls.Add(this.ltrJ);
            this.Controls.Add(this.ltrI);
            this.Controls.Add(this.ltrH);
            this.Controls.Add(this.ltrG);
            this.Controls.Add(this.ltrF);
            this.Controls.Add(this.ltrE);
            this.Controls.Add(this.ltrD);
            this.Controls.Add(this.ltrC);
            this.Controls.Add(this.ltrB);
            this.Controls.Add(this.ltrA);
            this.Controls.Add(this.btnHelp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SolverForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Wordle Solver";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.Form1_DragOver);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label ltrA;
        private Label ltrB;
        private Label ltrC;
        private Label ltrD;
        private Label ltrE;
        private Label ltrF;
        private Label ltrG;
        private Label ltrH;
        private Label ltrI;
        private Label ltrJ;
        private Label ltrK;
        private Label ltrL;
        private Label ltrM;
        private Label ltrZ;
        private Label ltrY;
        private Label ltrX;
        private Label ltrW;
        private Label ltrV;
        private Label ltrU;
        private Label ltrT;
        private Label ltrS;
        private Label ltrR;
        private Label ltrQ;
        private Label ltrP;
        private Label ltrO;
        private Label ltrN;
        private Label ltr0;
        private Label ltr1;
        private Label ltr2;
        private Label ltr3;
        private Label ltr4;
        private ListBox lsbTargetPopularity;
        private Label lblRemain;
        private Label label1;
        private Label btnHelp;
        private Label label4;
        private Label label3;
        private Label lblDeduct;
        private Button btnResetSolver;
    }
}