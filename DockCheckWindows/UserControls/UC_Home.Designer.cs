namespace DockCheckWindows.UserControls
{
    partial class UC_Home
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Home));
            this.labelABordo = new System.Windows.Forms.Label();
            this.labelTotalABordo = new System.Windows.Forms.Label();
            this.labelPortalo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.portaloData1 = new System.Windows.Forms.Label();
            this.labelProaUltimaAtualizacao = new System.Windows.Forms.Label();
            this.labelProaRfid1 = new System.Windows.Forms.Label();
            this.labelPortaloTitulo1 = new System.Windows.Forms.Label();
            this.statusPortalo1 = new Guna.UI2.WinForms.Guna2Shapes();
            this.panel3 = new System.Windows.Forms.Panel();
            this.portaloData2 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelPortaloTitulo2 = new System.Windows.Forms.Label();
            this.statusPortalo2 = new Guna.UI2.WinForms.Guna2Shapes();
            this.panel4 = new System.Windows.Forms.Panel();
            this.portaloData3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.labelPortaloTitulo3 = new System.Windows.Forms.Label();
            this.statusPortalo3 = new Guna.UI2.WinForms.Guna2Shapes();
            this.panel5 = new System.Windows.Forms.Panel();
            this.portaloData4 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.labelPortaloTitulo4 = new System.Windows.Forms.Label();
            this.statusPortalo4 = new Guna.UI2.WinForms.Guna2Shapes();
            this.buttonSincronizar = new Guna.UI2.WinForms.Guna2Button();
            this.listViewABordo = new System.Windows.Forms.ListView();
            this.listViewBloqueados = new System.Windows.Forms.ListView();
            this.labelBloqueados = new System.Windows.Forms.Label();
            this.labelTotalBloqueados = new System.Windows.Forms.Label();
            this.listViewEventos = new System.Windows.Forms.ListView();
            this.labelEventos = new System.Windows.Forms.Label();
            this.statusAcao1 = new System.Windows.Forms.Label();
            this.statusAcao2 = new System.Windows.Forms.Label();
            this.statusAcao3 = new System.Windows.Forms.Label();
            this.statusAcao4 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelABordo
            // 
            this.labelABordo.AutoSize = true;
            this.labelABordo.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelABordo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelABordo.Location = new System.Drawing.Point(47, 29);
            this.labelABordo.Name = "labelABordo";
            this.labelABordo.Size = new System.Drawing.Size(173, 38);
            this.labelABordo.TabIndex = 1;
            this.labelABordo.Text = "À BORDO:";
            // 
            // labelTotalABordo
            // 
            this.labelTotalABordo.AutoSize = true;
            this.labelTotalABordo.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalABordo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelTotalABordo.Location = new System.Drawing.Point(311, 355);
            this.labelTotalABordo.Name = "labelTotalABordo";
            this.labelTotalABordo.Size = new System.Drawing.Size(180, 38);
            this.labelTotalABordo.TabIndex = 4;
            this.labelTotalABordo.Text = "TOTAL: 341";
            // 
            // labelPortalo
            // 
            this.labelPortalo.AutoSize = true;
            this.labelPortalo.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPortalo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelPortalo.Location = new System.Drawing.Point(544, 29);
            this.labelPortalo.Name = "labelPortalo";
            this.labelPortalo.Size = new System.Drawing.Size(192, 38);
            this.labelPortalo.TabIndex = 5;
            this.labelPortalo.Text = "PORTALÓ\'S:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Controls.Add(this.statusAcao1);
            this.panel2.Controls.Add(this.portaloData1);
            this.panel2.Controls.Add(this.labelProaUltimaAtualizacao);
            this.panel2.Controls.Add(this.labelProaRfid1);
            this.panel2.Controls.Add(this.labelPortaloTitulo1);
            this.panel2.Controls.Add(this.statusPortalo1);
            this.panel2.Location = new System.Drawing.Point(551, 86);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1337, 62);
            this.panel2.TabIndex = 4;
            // 
            // portaloData1
            // 
            this.portaloData1.AutoSize = true;
            this.portaloData1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portaloData1.Location = new System.Drawing.Point(1065, 21);
            this.portaloData1.Name = "portaloData1";
            this.portaloData1.Size = new System.Drawing.Size(228, 22);
            this.portaloData1.TabIndex = 7;
            this.portaloData1.Text = "08/05/2006 03:05:15 PM";
            // 
            // labelProaUltimaAtualizacao
            // 
            this.labelProaUltimaAtualizacao.AutoSize = true;
            this.labelProaUltimaAtualizacao.Location = new System.Drawing.Point(854, 21);
            this.labelProaUltimaAtualizacao.Name = "labelProaUltimaAtualizacao";
            this.labelProaUltimaAtualizacao.Size = new System.Drawing.Size(192, 23);
            this.labelProaUltimaAtualizacao.TabIndex = 6;
            this.labelProaUltimaAtualizacao.Text = "Última atualização:";
            // 
            // labelProaRfid1
            // 
            this.labelProaRfid1.AutoSize = true;
            this.labelProaRfid1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelProaRfid1.Location = new System.Drawing.Point(119, 20);
            this.labelProaRfid1.Name = "labelProaRfid1";
            this.labelProaRfid1.Size = new System.Drawing.Size(66, 23);
            this.labelProaRfid1.TabIndex = 2;
            this.labelProaRfid1.Text = "Ação:";
            // 
            // labelPortaloTitulo1
            // 
            this.labelPortaloTitulo1.AutoSize = true;
            this.labelPortaloTitulo1.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPortaloTitulo1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelPortaloTitulo1.Location = new System.Drawing.Point(34, 13);
            this.labelPortaloTitulo1.Name = "labelPortaloTitulo1";
            this.labelPortaloTitulo1.Size = new System.Drawing.Size(29, 32);
            this.labelPortaloTitulo1.TabIndex = 1;
            this.labelPortaloTitulo1.Text = "1";
            // 
            // statusPortalo1
            // 
            this.statusPortalo1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.statusPortalo1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.statusPortalo1.Location = new System.Drawing.Point(4, 4);
            this.statusPortalo1.Name = "statusPortalo1";
            this.statusPortalo1.PolygonSkip = 1;
            this.statusPortalo1.Rotate = 0F;
            this.statusPortalo1.Shape = Guna.UI2.WinForms.Enums.ShapeType.Rectangle;
            this.statusPortalo1.Size = new System.Drawing.Size(24, 55);
            this.statusPortalo1.TabIndex = 0;
            this.statusPortalo1.Text = "guna2Shapes1";
            this.statusPortalo1.Zoom = 80;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel3.Controls.Add(this.statusAcao2);
            this.panel3.Controls.Add(this.portaloData2);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.labelPortaloTitulo2);
            this.panel3.Controls.Add(this.statusPortalo2);
            this.panel3.Location = new System.Drawing.Point(551, 154);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1337, 62);
            this.panel3.TabIndex = 4;
            // 
            // portaloData2
            // 
            this.portaloData2.AutoSize = true;
            this.portaloData2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portaloData2.Location = new System.Drawing.Point(1065, 21);
            this.portaloData2.Name = "portaloData2";
            this.portaloData2.Size = new System.Drawing.Size(16, 22);
            this.portaloData2.TabIndex = 7;
            this.portaloData2.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(854, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Última atualização:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(119, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 23);
            this.label5.TabIndex = 2;
            this.label5.Text = "Ação:";
            // 
            // labelPortaloTitulo2
            // 
            this.labelPortaloTitulo2.AutoSize = true;
            this.labelPortaloTitulo2.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPortaloTitulo2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelPortaloTitulo2.Location = new System.Drawing.Point(34, 13);
            this.labelPortaloTitulo2.Name = "labelPortaloTitulo2";
            this.labelPortaloTitulo2.Size = new System.Drawing.Size(29, 32);
            this.labelPortaloTitulo2.TabIndex = 1;
            this.labelPortaloTitulo2.Text = "2";
            // 
            // statusPortalo2
            // 
            this.statusPortalo2.BorderColor = System.Drawing.Color.Yellow;
            this.statusPortalo2.FillColor = System.Drawing.Color.Yellow;
            this.statusPortalo2.Location = new System.Drawing.Point(4, 4);
            this.statusPortalo2.Name = "statusPortalo2";
            this.statusPortalo2.PolygonSkip = 1;
            this.statusPortalo2.Rotate = 0F;
            this.statusPortalo2.Shape = Guna.UI2.WinForms.Enums.ShapeType.Rectangle;
            this.statusPortalo2.Size = new System.Drawing.Size(24, 55);
            this.statusPortalo2.TabIndex = 0;
            this.statusPortalo2.Text = "guna2Shapes1";
            this.statusPortalo2.Zoom = 80;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel4.Controls.Add(this.statusAcao3);
            this.panel4.Controls.Add(this.portaloData3);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.labelPortaloTitulo3);
            this.panel4.Controls.Add(this.statusPortalo3);
            this.panel4.Location = new System.Drawing.Point(551, 222);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1337, 62);
            this.panel4.TabIndex = 4;
            // 
            // portaloData3
            // 
            this.portaloData3.AutoSize = true;
            this.portaloData3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portaloData3.Location = new System.Drawing.Point(1065, 21);
            this.portaloData3.Name = "portaloData3";
            this.portaloData3.Size = new System.Drawing.Size(16, 22);
            this.portaloData3.TabIndex = 7;
            this.portaloData3.Text = "-";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(854, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(192, 23);
            this.label8.TabIndex = 6;
            this.label8.Text = "Última atualização:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label11.Location = new System.Drawing.Point(119, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 23);
            this.label11.TabIndex = 2;
            this.label11.Text = "Ação:";
            // 
            // labelPortaloTitulo3
            // 
            this.labelPortaloTitulo3.AutoSize = true;
            this.labelPortaloTitulo3.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPortaloTitulo3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelPortaloTitulo3.Location = new System.Drawing.Point(34, 13);
            this.labelPortaloTitulo3.Name = "labelPortaloTitulo3";
            this.labelPortaloTitulo3.Size = new System.Drawing.Size(29, 32);
            this.labelPortaloTitulo3.TabIndex = 1;
            this.labelPortaloTitulo3.Text = "3";
            // 
            // statusPortalo3
            // 
            this.statusPortalo3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.statusPortalo3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.statusPortalo3.Location = new System.Drawing.Point(4, 4);
            this.statusPortalo3.Name = "statusPortalo3";
            this.statusPortalo3.PolygonSkip = 1;
            this.statusPortalo3.Rotate = 0F;
            this.statusPortalo3.Shape = Guna.UI2.WinForms.Enums.ShapeType.Rectangle;
            this.statusPortalo3.Size = new System.Drawing.Size(24, 55);
            this.statusPortalo3.TabIndex = 0;
            this.statusPortalo3.Text = "guna2Shapes1";
            this.statusPortalo3.Zoom = 80;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel5.Controls.Add(this.statusAcao4);
            this.panel5.Controls.Add(this.portaloData4);
            this.panel5.Controls.Add(this.label14);
            this.panel5.Controls.Add(this.label17);
            this.panel5.Controls.Add(this.labelPortaloTitulo4);
            this.panel5.Controls.Add(this.statusPortalo4);
            this.panel5.Location = new System.Drawing.Point(551, 290);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1337, 62);
            this.panel5.TabIndex = 4;
            // 
            // portaloData4
            // 
            this.portaloData4.AutoSize = true;
            this.portaloData4.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portaloData4.Location = new System.Drawing.Point(1065, 21);
            this.portaloData4.Name = "portaloData4";
            this.portaloData4.Size = new System.Drawing.Size(16, 22);
            this.portaloData4.TabIndex = 7;
            this.portaloData4.Text = "-";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(854, 21);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(192, 23);
            this.label14.TabIndex = 6;
            this.label14.Text = "Última atualização:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label17.Location = new System.Drawing.Point(119, 20);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(66, 23);
            this.label17.TabIndex = 2;
            this.label17.Text = "Ação:";
            // 
            // labelPortaloTitulo4
            // 
            this.labelPortaloTitulo4.AutoSize = true;
            this.labelPortaloTitulo4.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPortaloTitulo4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelPortaloTitulo4.Location = new System.Drawing.Point(34, 13);
            this.labelPortaloTitulo4.Name = "labelPortaloTitulo4";
            this.labelPortaloTitulo4.Size = new System.Drawing.Size(29, 32);
            this.labelPortaloTitulo4.TabIndex = 1;
            this.labelPortaloTitulo4.Text = "4";
            // 
            // statusPortalo4
            // 
            this.statusPortalo4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.statusPortalo4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.statusPortalo4.Location = new System.Drawing.Point(4, 4);
            this.statusPortalo4.Name = "statusPortalo4";
            this.statusPortalo4.PolygonSkip = 1;
            this.statusPortalo4.Rotate = 0F;
            this.statusPortalo4.Shape = Guna.UI2.WinForms.Enums.ShapeType.Rectangle;
            this.statusPortalo4.Size = new System.Drawing.Size(24, 55);
            this.statusPortalo4.TabIndex = 0;
            this.statusPortalo4.Text = "guna2Shapes1";
            this.statusPortalo4.Zoom = 80;
            // 
            // buttonSincronizar
            // 
            this.buttonSincronizar.BorderRadius = 3;
            this.buttonSincronizar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonSincronizar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.buttonSincronizar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.buttonSincronizar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.buttonSincronizar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(27)))), ((int)(((byte)(41)))));
            this.buttonSincronizar.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSincronizar.ForeColor = System.Drawing.Color.White;
            this.buttonSincronizar.Image = ((System.Drawing.Image)(resources.GetObject("buttonSincronizar.Image")));
            this.buttonSincronizar.ImageSize = new System.Drawing.Size(30, 30);
            this.buttonSincronizar.Location = new System.Drawing.Point(1584, 852);
            this.buttonSincronizar.Name = "buttonSincronizar";
            this.buttonSincronizar.Size = new System.Drawing.Size(304, 71);
            this.buttonSincronizar.TabIndex = 6;
            this.buttonSincronizar.Text = "Sincronizar";
            this.buttonSincronizar.Click += new System.EventHandler(this.buttonSincronizar_Click);
            // 
            // listViewABordo
            // 
            this.listViewABordo.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewABordo.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewABordo.FullRowSelect = true;
            this.listViewABordo.HideSelection = false;
            this.listViewABordo.LabelWrap = false;
            this.listViewABordo.Location = new System.Drawing.Point(54, 70);
            this.listViewABordo.Name = "listViewABordo";
            this.listViewABordo.Size = new System.Drawing.Size(424, 282);
            this.listViewABordo.TabIndex = 7;
            this.listViewABordo.UseCompatibleStateImageBehavior = false;
            this.listViewABordo.View = System.Windows.Forms.View.List;
            // 
            // listViewBloqueados
            // 
            this.listViewBloqueados.FullRowSelect = true;
            this.listViewBloqueados.HideSelection = false;
            this.listViewBloqueados.LabelWrap = false;
            this.listViewBloqueados.Location = new System.Drawing.Point(54, 440);
            this.listViewBloqueados.Name = "listViewBloqueados";
            this.listViewBloqueados.Size = new System.Drawing.Size(424, 389);
            this.listViewBloqueados.TabIndex = 9;
            this.listViewBloqueados.UseCompatibleStateImageBehavior = false;
            this.listViewBloqueados.View = System.Windows.Forms.View.List;
            // 
            // labelBloqueados
            // 
            this.labelBloqueados.AutoSize = true;
            this.labelBloqueados.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBloqueados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelBloqueados.Location = new System.Drawing.Point(47, 399);
            this.labelBloqueados.Name = "labelBloqueados";
            this.labelBloqueados.Size = new System.Drawing.Size(240, 38);
            this.labelBloqueados.TabIndex = 8;
            this.labelBloqueados.Text = "BLOQUEADOS:";
            // 
            // labelTotalBloqueados
            // 
            this.labelTotalBloqueados.AutoSize = true;
            this.labelTotalBloqueados.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalBloqueados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelTotalBloqueados.Location = new System.Drawing.Point(298, 852);
            this.labelTotalBloqueados.Name = "labelTotalBloqueados";
            this.labelTotalBloqueados.Size = new System.Drawing.Size(180, 38);
            this.labelTotalBloqueados.TabIndex = 10;
            this.labelTotalBloqueados.Text = "TOTAL: 341";
            // 
            // listViewEventos
            // 
            this.listViewEventos.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewEventos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewEventos.FullRowSelect = true;
            this.listViewEventos.HideSelection = false;
            this.listViewEventos.LabelWrap = false;
            this.listViewEventos.Location = new System.Drawing.Point(551, 440);
            this.listViewEventos.Name = "listViewEventos";
            this.listViewEventos.Size = new System.Drawing.Size(1337, 389);
            this.listViewEventos.TabIndex = 12;
            this.listViewEventos.UseCompatibleStateImageBehavior = false;
            this.listViewEventos.View = System.Windows.Forms.View.List;
            // 
            // labelEventos
            // 
            this.labelEventos.AutoSize = true;
            this.labelEventos.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEventos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelEventos.Location = new System.Drawing.Point(544, 399);
            this.labelEventos.Name = "labelEventos";
            this.labelEventos.Size = new System.Drawing.Size(321, 38);
            this.labelEventos.TabIndex = 11;
            this.labelEventos.Text = "EVENTOS RECENTES:";
            // 
            // statusAcao1
            // 
            this.statusAcao1.AutoSize = true;
            this.statusAcao1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.statusAcao1.Location = new System.Drawing.Point(191, 20);
            this.statusAcao1.Name = "statusAcao1";
            this.statusAcao1.Size = new System.Drawing.Size(18, 23);
            this.statusAcao1.TabIndex = 8;
            this.statusAcao1.Text = "-";
            // 
            // statusAcao2
            // 
            this.statusAcao2.AutoSize = true;
            this.statusAcao2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.statusAcao2.Location = new System.Drawing.Point(191, 20);
            this.statusAcao2.Name = "statusAcao2";
            this.statusAcao2.Size = new System.Drawing.Size(18, 23);
            this.statusAcao2.TabIndex = 9;
            this.statusAcao2.Text = "-";
            // 
            // statusAcao3
            // 
            this.statusAcao3.AutoSize = true;
            this.statusAcao3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.statusAcao3.Location = new System.Drawing.Point(191, 20);
            this.statusAcao3.Name = "statusAcao3";
            this.statusAcao3.Size = new System.Drawing.Size(18, 23);
            this.statusAcao3.TabIndex = 10;
            this.statusAcao3.Text = "-";
            // 
            // statusAcao4
            // 
            this.statusAcao4.AutoSize = true;
            this.statusAcao4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.statusAcao4.Location = new System.Drawing.Point(191, 20);
            this.statusAcao4.Name = "statusAcao4";
            this.statusAcao4.Size = new System.Drawing.Size(18, 23);
            this.statusAcao4.TabIndex = 11;
            this.statusAcao4.Text = "-";
            // 
            // UC_Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.listViewEventos);
            this.Controls.Add(this.labelEventos);
            this.Controls.Add(this.labelTotalBloqueados);
            this.Controls.Add(this.listViewBloqueados);
            this.Controls.Add(this.labelBloqueados);
            this.Controls.Add(this.listViewABordo);
            this.Controls.Add(this.buttonSincronizar);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.labelPortalo);
            this.Controls.Add(this.labelTotalABordo);
            this.Controls.Add(this.labelABordo);
            this.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "UC_Home";
            this.Size = new System.Drawing.Size(1904, 906);
            this.Load += new System.EventHandler(this.UC_Home_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelABordo;
        private System.Windows.Forms.Label labelTotalABordo;
        private System.Windows.Forms.Label labelPortalo;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Shapes statusPortalo1;
        private System.Windows.Forms.Label labelProaRfid1;
        private System.Windows.Forms.Label labelPortaloTitulo1;
        private System.Windows.Forms.Label labelProaUltimaAtualizacao;
        private System.Windows.Forms.Label portaloData1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label portaloData2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelPortaloTitulo2;
        private Guna.UI2.WinForms.Guna2Shapes statusPortalo2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label portaloData3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labelPortaloTitulo3;
        private Guna.UI2.WinForms.Guna2Shapes statusPortalo3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label portaloData4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label labelPortaloTitulo4;
        private Guna.UI2.WinForms.Guna2Shapes statusPortalo4;
        private Guna.UI2.WinForms.Guna2Button buttonSincronizar;
        private System.Windows.Forms.ListView listViewABordo;
        private System.Windows.Forms.ListView listViewBloqueados;
        private System.Windows.Forms.Label labelBloqueados;
        private System.Windows.Forms.Label labelTotalBloqueados;
        private System.Windows.Forms.ListView listViewEventos;
        private System.Windows.Forms.Label labelEventos;
        private System.Windows.Forms.Label statusAcao1;
        private System.Windows.Forms.Label statusAcao2;
        private System.Windows.Forms.Label statusAcao3;
        private System.Windows.Forms.Label statusAcao4;
    }
}
