
namespace FrmPrincipal
{
    partial class FrmPrincipal
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
            this.lstBoxInduDisponible = new System.Windows.Forms.ListBox();
            this.lstBoxInduManufacturada = new System.Windows.Forms.ListBox();
            this.lblInduDisponible = new System.Windows.Forms.Label();
            this.lblInduProduccion = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblPeso = new System.Windows.Forms.Label();
            this.lblPorcent = new System.Windows.Forms.Label();
            this.lblCosto = new System.Windows.Forms.Label();
            this.lblCostoTanda = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtPeso = new System.Windows.Forms.TextBox();
            this.txtPorcent = new System.Windows.Forms.TextBox();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.txtCostoTanda = new System.Windows.Forms.TextBox();
            this.btnAgregarNuevaIndu = new System.Windows.Forms.Button();
            this.btnAgregarAManufactura = new System.Windows.Forms.Button();
            this.btnGenerarDocumento = new System.Windows.Forms.Button();
            this.txtCostoDisp = new System.Windows.Forms.TextBox();
            this.txtPorcentDisp = new System.Windows.Forms.TextBox();
            this.txtPesoDisp = new System.Windows.Forms.TextBox();
            this.txtCodigoDisp = new System.Windows.Forms.TextBox();
            this.lblCostoDisp = new System.Windows.Forms.Label();
            this.lblPorcentDisp = new System.Windows.Forms.Label();
            this.lblPesoDisp = new System.Windows.Forms.Label();
            this.lblCodigoDisp = new System.Windows.Forms.Label();
            this.lblTandaProducida = new System.Windows.Forms.Label();
            this.lblDetalleInduDisponible = new System.Windows.Forms.Label();
            this.numCantFabricada = new System.Windows.Forms.NumericUpDown();
            this.lblCantidadManufacturada = new System.Windows.Forms.Label();
            this.btnBorrarProducida = new System.Windows.Forms.Button();
            this.lblModeloDisp = new System.Windows.Forms.Label();
            this.lblTipoDisp = new System.Windows.Forms.Label();
            this.txtTipoDisp = new System.Windows.Forms.TextBox();
            this.txtModeloDisp = new System.Windows.Forms.TextBox();
            this.btnBorrarDisp = new System.Windows.Forms.Button();
            this.menuStripManufactura = new System.Windows.Forms.MenuStrip();
            this.documentosModelosDisponiblesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentosDisponiblesSoloCAMISETASToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentosDisponiblesSoloZAPATILLASToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarIndumentariaDisponibleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarDocManufacturaSoloCAMISTESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarDocManufacturaSoloZAPATILLASToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarXMLManufacturaIndumentariaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblModelo = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.indumentariaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numCantFabricada)).BeginInit();
            this.menuStripManufactura.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.indumentariaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lstBoxInduDisponible
            // 
            this.lstBoxInduDisponible.FormattingEnabled = true;
            this.lstBoxInduDisponible.Location = new System.Drawing.Point(266, 47);
            this.lstBoxInduDisponible.Name = "lstBoxInduDisponible";
            this.lstBoxInduDisponible.Size = new System.Drawing.Size(264, 407);
            this.lstBoxInduDisponible.TabIndex = 0;
            this.lstBoxInduDisponible.SelectedValueChanged += new System.EventHandler(this.lstBoxInduDisponible_SelectedValueChanged);
            // 
            // lstBoxInduManufacturada
            // 
            this.lstBoxInduManufacturada.FormattingEnabled = true;
            this.lstBoxInduManufacturada.Location = new System.Drawing.Point(561, 47);
            this.lstBoxInduManufacturada.Name = "lstBoxInduManufacturada";
            this.lstBoxInduManufacturada.Size = new System.Drawing.Size(295, 407);
            this.lstBoxInduManufacturada.TabIndex = 1;
            this.lstBoxInduManufacturada.SelectedValueChanged += new System.EventHandler(this.lstBoxInduManufacturada_SelectedValueChanged);
            // 
            // lblInduDisponible
            // 
            this.lblInduDisponible.AutoSize = true;
            this.lblInduDisponible.Location = new System.Drawing.Point(308, 31);
            this.lblInduDisponible.Name = "lblInduDisponible";
            this.lblInduDisponible.Size = new System.Drawing.Size(180, 13);
            this.lblInduDisponible.TabIndex = 2;
            this.lblInduDisponible.Text = "Indumentaria disponible para fabricar";
            // 
            // lblInduProduccion
            // 
            this.lblInduProduccion.AutoSize = true;
            this.lblInduProduccion.Location = new System.Drawing.Point(621, 31);
            this.lblInduProduccion.Name = "lblInduProduccion";
            this.lblInduProduccion.Size = new System.Drawing.Size(195, 13);
            this.lblInduProduccion.TabIndex = 3;
            this.lblInduProduccion.Text = "Indumentaria producida en tanda actual";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(862, 58);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(71, 13);
            this.lblCodigo.TabIndex = 4;
            this.lblCodigo.Text = "Codigo Unico";
            // 
            // lblPeso
            // 
            this.lblPeso.AutoSize = true;
            this.lblPeso.Location = new System.Drawing.Point(882, 136);
            this.lblPeso.Name = "lblPeso";
            this.lblPeso.Size = new System.Drawing.Size(31, 13);
            this.lblPeso.TabIndex = 5;
            this.lblPeso.Text = "Peso";
            // 
            // lblPorcent
            // 
            this.lblPorcent.AutoSize = true;
            this.lblPorcent.Location = new System.Drawing.Point(862, 165);
            this.lblPorcent.Name = "lblPorcent";
            this.lblPorcent.Size = new System.Drawing.Size(72, 13);
            this.lblPorcent.TabIndex = 6;
            this.lblPorcent.Text = "% de Algodon";
            // 
            // lblCosto
            // 
            this.lblCosto.AutoSize = true;
            this.lblCosto.Location = new System.Drawing.Point(862, 190);
            this.lblCosto.Name = "lblCosto";
            this.lblCosto.Size = new System.Drawing.Size(97, 13);
            this.lblCosto.TabIndex = 7;
            this.lblCosto.Text = "Costo Manufactura";
            // 
            // lblCostoTanda
            // 
            this.lblCostoTanda.AutoSize = true;
            this.lblCostoTanda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCostoTanda.Location = new System.Drawing.Point(869, 441);
            this.lblCostoTanda.Name = "lblCostoTanda";
            this.lblCostoTanda.Size = new System.Drawing.Size(90, 13);
            this.lblCostoTanda.TabIndex = 8;
            this.lblCostoTanda.Text = "Costo de la tanda";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(956, 55);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(162, 20);
            this.txtCodigo.TabIndex = 9;
            // 
            // txtPeso
            // 
            this.txtPeso.Enabled = false;
            this.txtPeso.Location = new System.Drawing.Point(956, 133);
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Size = new System.Drawing.Size(162, 20);
            this.txtPeso.TabIndex = 10;
            // 
            // txtPorcent
            // 
            this.txtPorcent.Enabled = false;
            this.txtPorcent.Location = new System.Drawing.Point(956, 162);
            this.txtPorcent.Name = "txtPorcent";
            this.txtPorcent.Size = new System.Drawing.Size(162, 20);
            this.txtPorcent.TabIndex = 11;
            // 
            // txtCosto
            // 
            this.txtCosto.Enabled = false;
            this.txtCosto.Location = new System.Drawing.Point(956, 187);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(162, 20);
            this.txtCosto.TabIndex = 12;
            // 
            // txtCostoTanda
            // 
            this.txtCostoTanda.Enabled = false;
            this.txtCostoTanda.Location = new System.Drawing.Point(956, 438);
            this.txtCostoTanda.Name = "txtCostoTanda";
            this.txtCostoTanda.Size = new System.Drawing.Size(162, 20);
            this.txtCostoTanda.TabIndex = 13;
            // 
            // btnAgregarNuevaIndu
            // 
            this.btnAgregarNuevaIndu.Location = new System.Drawing.Point(321, 458);
            this.btnAgregarNuevaIndu.Name = "btnAgregarNuevaIndu";
            this.btnAgregarNuevaIndu.Size = new System.Drawing.Size(122, 54);
            this.btnAgregarNuevaIndu.TabIndex = 14;
            this.btnAgregarNuevaIndu.Text = "Agregar Indumentaria Nueva";
            this.btnAgregarNuevaIndu.UseVisualStyleBackColor = true;
            this.btnAgregarNuevaIndu.Click += new System.EventHandler(this.btnAgregarNuevaIndu_Click);
            // 
            // btnAgregarAManufactura
            // 
            this.btnAgregarAManufactura.Location = new System.Drawing.Point(481, 460);
            this.btnAgregarAManufactura.Name = "btnAgregarAManufactura";
            this.btnAgregarAManufactura.Size = new System.Drawing.Size(121, 50);
            this.btnAgregarAManufactura.TabIndex = 15;
            this.btnAgregarAManufactura.Text = "Manufacturar Indumentaria Seleccionada ";
            this.btnAgregarAManufactura.UseVisualStyleBackColor = true;
            this.btnAgregarAManufactura.Click += new System.EventHandler(this.btnAgregarAManufactura_Click);
            // 
            // btnGenerarDocumento
            // 
            this.btnGenerarDocumento.Location = new System.Drawing.Point(749, 460);
            this.btnGenerarDocumento.Name = "btnGenerarDocumento";
            this.btnGenerarDocumento.Size = new System.Drawing.Size(107, 52);
            this.btnGenerarDocumento.TabIndex = 16;
            this.btnGenerarDocumento.Text = "Generar Documento de Manufactura";
            this.btnGenerarDocumento.UseVisualStyleBackColor = true;
            this.btnGenerarDocumento.Click += new System.EventHandler(this.btnGenerarDocumento_Click);
            // 
            // txtCostoDisp
            // 
            this.txtCostoDisp.Enabled = false;
            this.txtCostoDisp.Location = new System.Drawing.Point(98, 186);
            this.txtCostoDisp.Name = "txtCostoDisp";
            this.txtCostoDisp.Size = new System.Drawing.Size(162, 20);
            this.txtCostoDisp.TabIndex = 26;
            // 
            // txtPorcentDisp
            // 
            this.txtPorcentDisp.Enabled = false;
            this.txtPorcentDisp.Location = new System.Drawing.Point(98, 161);
            this.txtPorcentDisp.Name = "txtPorcentDisp";
            this.txtPorcentDisp.Size = new System.Drawing.Size(162, 20);
            this.txtPorcentDisp.TabIndex = 25;
            // 
            // txtPesoDisp
            // 
            this.txtPesoDisp.Enabled = false;
            this.txtPesoDisp.Location = new System.Drawing.Point(98, 136);
            this.txtPesoDisp.Name = "txtPesoDisp";
            this.txtPesoDisp.Size = new System.Drawing.Size(162, 20);
            this.txtPesoDisp.TabIndex = 24;
            // 
            // txtCodigoDisp
            // 
            this.txtCodigoDisp.Enabled = false;
            this.txtCodigoDisp.Location = new System.Drawing.Point(98, 58);
            this.txtCodigoDisp.Name = "txtCodigoDisp";
            this.txtCodigoDisp.Size = new System.Drawing.Size(162, 20);
            this.txtCodigoDisp.TabIndex = 23;
            // 
            // lblCostoDisp
            // 
            this.lblCostoDisp.AutoSize = true;
            this.lblCostoDisp.Location = new System.Drawing.Point(4, 189);
            this.lblCostoDisp.Name = "lblCostoDisp";
            this.lblCostoDisp.Size = new System.Drawing.Size(97, 13);
            this.lblCostoDisp.TabIndex = 22;
            this.lblCostoDisp.Text = "Costo Manufactura";
            // 
            // lblPorcentDisp
            // 
            this.lblPorcentDisp.AutoSize = true;
            this.lblPorcentDisp.Location = new System.Drawing.Point(4, 164);
            this.lblPorcentDisp.Name = "lblPorcentDisp";
            this.lblPorcentDisp.Size = new System.Drawing.Size(72, 13);
            this.lblPorcentDisp.TabIndex = 21;
            this.lblPorcentDisp.Text = "% de Algodon";
            // 
            // lblPesoDisp
            // 
            this.lblPesoDisp.AutoSize = true;
            this.lblPesoDisp.Location = new System.Drawing.Point(24, 135);
            this.lblPesoDisp.Name = "lblPesoDisp";
            this.lblPesoDisp.Size = new System.Drawing.Size(31, 13);
            this.lblPesoDisp.TabIndex = 20;
            this.lblPesoDisp.Text = "Peso";
            // 
            // lblCodigoDisp
            // 
            this.lblCodigoDisp.AutoSize = true;
            this.lblCodigoDisp.Location = new System.Drawing.Point(4, 61);
            this.lblCodigoDisp.Name = "lblCodigoDisp";
            this.lblCodigoDisp.Size = new System.Drawing.Size(71, 13);
            this.lblCodigoDisp.TabIndex = 19;
            this.lblCodigoDisp.Text = "Codigo Unico";
            // 
            // lblTandaProducida
            // 
            this.lblTandaProducida.AutoSize = true;
            this.lblTandaProducida.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTandaProducida.Location = new System.Drawing.Point(904, 32);
            this.lblTandaProducida.Name = "lblTandaProducida";
            this.lblTandaProducida.Size = new System.Drawing.Size(183, 13);
            this.lblTandaProducida.TabIndex = 27;
            this.lblTandaProducida.Text = "Detalle indumentaria producida";
            // 
            // lblDetalleInduDisponible
            // 
            this.lblDetalleInduDisponible.AutoSize = true;
            this.lblDetalleInduDisponible.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalleInduDisponible.Location = new System.Drawing.Point(64, 32);
            this.lblDetalleInduDisponible.Name = "lblDetalleInduDisponible";
            this.lblDetalleInduDisponible.Size = new System.Drawing.Size(186, 13);
            this.lblDetalleInduDisponible.TabIndex = 28;
            this.lblDetalleInduDisponible.Text = "Detalle indumentaria Disponible";
            // 
            // numCantFabricada
            // 
            this.numCantFabricada.Enabled = false;
            this.numCantFabricada.Location = new System.Drawing.Point(965, 213);
            this.numCantFabricada.Name = "numCantFabricada";
            this.numCantFabricada.Size = new System.Drawing.Size(120, 20);
            this.numCantFabricada.TabIndex = 29;
            this.numCantFabricada.TabStop = false;
            // 
            // lblCantidadManufacturada
            // 
            this.lblCantidadManufacturada.AutoSize = true;
            this.lblCantidadManufacturada.Location = new System.Drawing.Point(860, 220);
            this.lblCantidadManufacturada.Name = "lblCantidadManufacturada";
            this.lblCantidadManufacturada.Size = new System.Drawing.Size(99, 13);
            this.lblCantidadManufacturada.TabIndex = 30;
            this.lblCantidadManufacturada.Text = "Cantidad Fabricada";
            // 
            // btnBorrarProducida
            // 
            this.btnBorrarProducida.Location = new System.Drawing.Point(872, 311);
            this.btnBorrarProducida.Name = "btnBorrarProducida";
            this.btnBorrarProducida.Size = new System.Drawing.Size(140, 50);
            this.btnBorrarProducida.TabIndex = 31;
            this.btnBorrarProducida.Text = "Borrar indumentaria de produccion";
            this.btnBorrarProducida.UseVisualStyleBackColor = true;
            this.btnBorrarProducida.Click += new System.EventHandler(this.btnBorrarProducida_Click);
            // 
            // lblModeloDisp
            // 
            this.lblModeloDisp.AutoSize = true;
            this.lblModeloDisp.Location = new System.Drawing.Point(24, 110);
            this.lblModeloDisp.Name = "lblModeloDisp";
            this.lblModeloDisp.Size = new System.Drawing.Size(42, 13);
            this.lblModeloDisp.TabIndex = 32;
            this.lblModeloDisp.Text = "Modelo";
            // 
            // lblTipoDisp
            // 
            this.lblTipoDisp.AutoSize = true;
            this.lblTipoDisp.Location = new System.Drawing.Point(24, 84);
            this.lblTipoDisp.Name = "lblTipoDisp";
            this.lblTipoDisp.Size = new System.Drawing.Size(28, 13);
            this.lblTipoDisp.TabIndex = 33;
            this.lblTipoDisp.Text = "Tipo";
            // 
            // txtTipoDisp
            // 
            this.txtTipoDisp.Enabled = false;
            this.txtTipoDisp.Location = new System.Drawing.Point(98, 84);
            this.txtTipoDisp.Name = "txtTipoDisp";
            this.txtTipoDisp.Size = new System.Drawing.Size(162, 20);
            this.txtTipoDisp.TabIndex = 34;
            // 
            // txtModeloDisp
            // 
            this.txtModeloDisp.Enabled = false;
            this.txtModeloDisp.Location = new System.Drawing.Point(98, 110);
            this.txtModeloDisp.Name = "txtModeloDisp";
            this.txtModeloDisp.Size = new System.Drawing.Size(162, 20);
            this.txtModeloDisp.TabIndex = 35;
            // 
            // btnBorrarDisp
            // 
            this.btnBorrarDisp.Location = new System.Drawing.Point(120, 311);
            this.btnBorrarDisp.Name = "btnBorrarDisp";
            this.btnBorrarDisp.Size = new System.Drawing.Size(140, 50);
            this.btnBorrarDisp.TabIndex = 36;
            this.btnBorrarDisp.Text = "Borrar indumentaria disponible";
            this.btnBorrarDisp.UseVisualStyleBackColor = true;
            this.btnBorrarDisp.Click += new System.EventHandler(this.btnBorrarDisp_Click);
            // 
            // menuStripManufactura
            // 
            this.menuStripManufactura.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStripManufactura.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.documentosModelosDisponiblesToolStripMenuItem,
            this.documentosToolStripMenuItem});
            this.menuStripManufactura.Location = new System.Drawing.Point(0, 0);
            this.menuStripManufactura.Name = "menuStripManufactura";
            this.menuStripManufactura.Size = new System.Drawing.Size(1129, 24);
            this.menuStripManufactura.TabIndex = 37;
            this.menuStripManufactura.Text = "Documentos Manufactura";
            // 
            // documentosModelosDisponiblesToolStripMenuItem
            // 
            this.documentosModelosDisponiblesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.documentosDisponiblesSoloCAMISETASToolStripMenuItem,
            this.documentosDisponiblesSoloZAPATILLASToolStripMenuItem,
            this.exportarIndumentariaDisponibleToolStripMenuItem});
            this.documentosModelosDisponiblesToolStripMenuItem.Name = "documentosModelosDisponiblesToolStripMenuItem";
            this.documentosModelosDisponiblesToolStripMenuItem.Size = new System.Drawing.Size(200, 20);
            this.documentosModelosDisponiblesToolStripMenuItem.Text = "Documentos Modelos Disponibles";
            // 
            // documentosDisponiblesSoloCAMISETASToolStripMenuItem
            // 
            this.documentosDisponiblesSoloCAMISETASToolStripMenuItem.Name = "documentosDisponiblesSoloCAMISETASToolStripMenuItem";
            this.documentosDisponiblesSoloCAMISETASToolStripMenuItem.Size = new System.Drawing.Size(283, 22);
            this.documentosDisponiblesSoloCAMISETASToolStripMenuItem.Text = "Exportar XML Camisetas Disponibles";
            this.documentosDisponiblesSoloCAMISETASToolStripMenuItem.Click += new System.EventHandler(this.documentosDisponiblesSoloCAMISETASToolStripMenuItem_Click);
            // 
            // documentosDisponiblesSoloZAPATILLASToolStripMenuItem
            // 
            this.documentosDisponiblesSoloZAPATILLASToolStripMenuItem.Name = "documentosDisponiblesSoloZAPATILLASToolStripMenuItem";
            this.documentosDisponiblesSoloZAPATILLASToolStripMenuItem.Size = new System.Drawing.Size(283, 22);
            this.documentosDisponiblesSoloZAPATILLASToolStripMenuItem.Text = "Exportar XML Zapatillas Disponibles";
            this.documentosDisponiblesSoloZAPATILLASToolStripMenuItem.Click += new System.EventHandler(this.documentosDisponiblesSoloZAPATILLASToolStripMenuItem_Click);
            // 
            // exportarIndumentariaDisponibleToolStripMenuItem
            // 
            this.exportarIndumentariaDisponibleToolStripMenuItem.Name = "exportarIndumentariaDisponibleToolStripMenuItem";
            this.exportarIndumentariaDisponibleToolStripMenuItem.Size = new System.Drawing.Size(283, 22);
            this.exportarIndumentariaDisponibleToolStripMenuItem.Text = "Exportar XML Indumentarias Disponible";
            this.exportarIndumentariaDisponibleToolStripMenuItem.Click += new System.EventHandler(this.exportarIndumentariaDisponibleToolStripMenuItem_Click);
            // 
            // documentosToolStripMenuItem
            // 
            this.documentosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generarDocManufacturaSoloCAMISTESToolStripMenuItem,
            this.generarDocManufacturaSoloZAPATILLASToolStripMenuItem,
            this.exportarXMLManufacturaIndumentariaToolStripMenuItem});
            this.documentosToolStripMenuItem.Name = "documentosToolStripMenuItem";
            this.documentosToolStripMenuItem.Size = new System.Drawing.Size(158, 20);
            this.documentosToolStripMenuItem.Text = "Documentos Manufactura";
            // 
            // generarDocManufacturaSoloCAMISTESToolStripMenuItem
            // 
            this.generarDocManufacturaSoloCAMISTESToolStripMenuItem.Name = "generarDocManufacturaSoloCAMISTESToolStripMenuItem";
            this.generarDocManufacturaSoloCAMISTESToolStripMenuItem.Size = new System.Drawing.Size(307, 22);
            this.generarDocManufacturaSoloCAMISTESToolStripMenuItem.Text = "Exportar XML Manufactura solo CAMISETAS";
            this.generarDocManufacturaSoloCAMISTESToolStripMenuItem.Click += new System.EventHandler(this.generarDocumentoDeManufacturaSoloCAMISTESToolStripMenuItem_Click);
            // 
            // generarDocManufacturaSoloZAPATILLASToolStripMenuItem
            // 
            this.generarDocManufacturaSoloZAPATILLASToolStripMenuItem.Name = "generarDocManufacturaSoloZAPATILLASToolStripMenuItem";
            this.generarDocManufacturaSoloZAPATILLASToolStripMenuItem.Size = new System.Drawing.Size(307, 22);
            this.generarDocManufacturaSoloZAPATILLASToolStripMenuItem.Text = "Exportar XML Manufactura solo ZAPATILLAS";
            this.generarDocManufacturaSoloZAPATILLASToolStripMenuItem.Click += new System.EventHandler(this.generarDocManufacturaSoloZAPATILLASToolStripMenuItem_Click);
            // 
            // exportarXMLManufacturaIndumentariaToolStripMenuItem
            // 
            this.exportarXMLManufacturaIndumentariaToolStripMenuItem.Name = "exportarXMLManufacturaIndumentariaToolStripMenuItem";
            this.exportarXMLManufacturaIndumentariaToolStripMenuItem.Size = new System.Drawing.Size(307, 22);
            this.exportarXMLManufacturaIndumentariaToolStripMenuItem.Text = "Exportar XML Manufactura Indumentaria";
            this.exportarXMLManufacturaIndumentariaToolStripMenuItem.Click += new System.EventHandler(this.exportarXMLManufacturaIndumentariaToolStripMenuItem_Click);
            // 
            // lblModelo
            // 
            this.lblModelo.AutoSize = true;
            this.lblModelo.Location = new System.Drawing.Point(881, 107);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(42, 13);
            this.lblModelo.TabIndex = 32;
            this.lblModelo.Text = "Modelo";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(881, 81);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(28, 13);
            this.lblTipo.TabIndex = 33;
            this.lblTipo.Text = "Tipo";
            // 
            // txtModelo
            // 
            this.txtModelo.Enabled = false;
            this.txtModelo.Location = new System.Drawing.Point(955, 104);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(162, 20);
            this.txtModelo.TabIndex = 34;
            // 
            // txtTipo
            // 
            this.txtTipo.Enabled = false;
            this.txtTipo.Location = new System.Drawing.Point(955, 81);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Size = new System.Drawing.Size(162, 20);
            this.txtTipo.TabIndex = 35;
            // 
            // indumentariaBindingSource
            // 
            this.indumentariaBindingSource.DataSource = typeof(Logica.Objetos.Indumentaria);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 523);
            this.Controls.Add(this.btnBorrarDisp);
            this.Controls.Add(this.txtTipo);
            this.Controls.Add(this.txtModeloDisp);
            this.Controls.Add(this.txtModelo);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.txtTipoDisp);
            this.Controls.Add(this.lblModelo);
            this.Controls.Add(this.lblTipoDisp);
            this.Controls.Add(this.lblModeloDisp);
            this.Controls.Add(this.btnBorrarProducida);
            this.Controls.Add(this.lblCantidadManufacturada);
            this.Controls.Add(this.numCantFabricada);
            this.Controls.Add(this.lblDetalleInduDisponible);
            this.Controls.Add(this.lblTandaProducida);
            this.Controls.Add(this.txtCostoDisp);
            this.Controls.Add(this.txtPorcentDisp);
            this.Controls.Add(this.txtPesoDisp);
            this.Controls.Add(this.txtCodigoDisp);
            this.Controls.Add(this.lblCostoDisp);
            this.Controls.Add(this.lblPorcentDisp);
            this.Controls.Add(this.lblPesoDisp);
            this.Controls.Add(this.lblCodigoDisp);
            this.Controls.Add(this.btnGenerarDocumento);
            this.Controls.Add(this.btnAgregarAManufactura);
            this.Controls.Add(this.btnAgregarNuevaIndu);
            this.Controls.Add(this.txtCostoTanda);
            this.Controls.Add(this.txtCosto);
            this.Controls.Add(this.txtPorcent);
            this.Controls.Add(this.txtPeso);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblCostoTanda);
            this.Controls.Add(this.lblCosto);
            this.Controls.Add(this.lblPorcent);
            this.Controls.Add(this.lblPeso);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.lblInduProduccion);
            this.Controls.Add(this.lblInduDisponible);
            this.Controls.Add(this.lstBoxInduManufacturada);
            this.Controls.Add(this.lstBoxInduDisponible);
            this.Controls.Add(this.menuStripManufactura);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStripManufactura;
            this.MaximizeBox = false;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal Laredo.Agustin.2C";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmPrincipal_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.numCantFabricada)).EndInit();
            this.menuStripManufactura.ResumeLayout(false);
            this.menuStripManufactura.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.indumentariaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource indumentariaBindingSource;
        private System.Windows.Forms.Label lblInduDisponible;
        private System.Windows.Forms.Label lblInduProduccion;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblPeso;
        private System.Windows.Forms.Label lblPorcent;
        private System.Windows.Forms.Label lblCosto;
        private System.Windows.Forms.Label lblCostoTanda;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtPeso;
        private System.Windows.Forms.TextBox txtPorcent;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.TextBox txtCostoTanda;
        private System.Windows.Forms.Button btnAgregarNuevaIndu;
        private System.Windows.Forms.Button btnAgregarAManufactura;
        private System.Windows.Forms.Button btnGenerarDocumento;
        private System.Windows.Forms.TextBox txtCostoDisp;
        private System.Windows.Forms.TextBox txtPorcentDisp;
        private System.Windows.Forms.TextBox txtPesoDisp;
        private System.Windows.Forms.TextBox txtCodigoDisp;
        private System.Windows.Forms.Label lblCostoDisp;
        private System.Windows.Forms.Label lblPorcentDisp;
        private System.Windows.Forms.Label lblPesoDisp;
        private System.Windows.Forms.Label lblCodigoDisp;
        private System.Windows.Forms.Label lblTandaProducida;
        private System.Windows.Forms.Label lblDetalleInduDisponible;
        private System.Windows.Forms.NumericUpDown numCantFabricada;
        private System.Windows.Forms.Label lblCantidadManufacturada;
        private System.Windows.Forms.Button btnBorrarProducida;
        private System.Windows.Forms.Label lblModeloDisp;
        private System.Windows.Forms.Label lblTipoDisp;
        private System.Windows.Forms.TextBox txtTipoDisp;
        private System.Windows.Forms.TextBox txtModeloDisp;
        private System.Windows.Forms.Button btnBorrarDisp;
        private System.Windows.Forms.MenuStrip menuStripManufactura;
        private System.Windows.Forms.ToolStripMenuItem documentosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generarDocManufacturaSoloCAMISTESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generarDocManufacturaSoloZAPATILLASToolStripMenuItem;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.TextBox txtTipo;
        private System.Windows.Forms.ToolStripMenuItem documentosModelosDisponiblesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentosDisponiblesSoloZAPATILLASToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentosDisponiblesSoloCAMISETASToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarIndumentariaDisponibleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarXMLManufacturaIndumentariaToolStripMenuItem;
        public System.Windows.Forms.ListBox lstBoxInduDisponible;
        public System.Windows.Forms.ListBox lstBoxInduManufacturada;
    }
}

