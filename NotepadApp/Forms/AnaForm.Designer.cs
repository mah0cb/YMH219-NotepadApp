namespace NotepadApp.Forms;

partial class AnaForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        mnuAna = new MenuStrip();
        mnuDosya = new ToolStripMenuItem();
        mnuYeniNot = new ToolStripMenuItem();
        mnuKaydet = new ToolStripMenuItem();
        mnuYenidenYukle = new ToolStripMenuItem();
        mnuDisaAktar = new ToolStripMenuItem();
        mnuAyrac = new ToolStripSeparator();
        mnuCikis = new ToolStripMenuItem();
        stsDurum = new StatusStrip();
        tslNotSayisi = new ToolStripStatusLabel();
        tslDosyaYolu = new ToolStripStatusLabel();
        tslDurum = new ToolStripStatusLabel();
        tslSonKayit = new ToolStripStatusLabel();
        splAna = new SplitContainer();
        lstNotlar = new ListBox();
        tlpListe = new TableLayoutPanel();
        lblArama = new Label();
        txtArama = new TextBox();
        lblKategoriFiltre = new Label();
        cmbKategoriFiltre = new ComboBox();
        lblKategori = new Label();
        cmbKategori = new ComboBox();
        tlpEditor = new TableLayoutPanel();
        lblBaslik = new Label();
        txtBaslik = new TextBox();
        lblIcerik = new Label();
        rtbIcerik = new RichTextBox();
        flpTarihler = new FlowLayoutPanel();
        lblOlusturma = new Label();
        lblDuzenleme = new Label();
        flpButonlar = new FlowLayoutPanel();
        btnYeni = new Button();
        btnKaydet = new Button();
        btnSil = new Button();
        btnDisaAktar = new Button();
        mnuAna.SuspendLayout();
        stsDurum.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splAna).BeginInit();
        splAna.Panel1.SuspendLayout();
        splAna.Panel2.SuspendLayout();
        splAna.SuspendLayout();
        tlpListe.SuspendLayout();
        tlpEditor.SuspendLayout();
        flpTarihler.SuspendLayout();
        flpButonlar.SuspendLayout();
        SuspendLayout();
        //
        // mnuAna
        //
        mnuAna.Items.AddRange(new ToolStripItem[] { mnuDosya });
        mnuAna.Location = new Point(0, 0);
        mnuAna.Name = "mnuAna";
        mnuAna.Size = new Size(984, 24);
        mnuAna.TabIndex = 0;
        //
        // mnuDosya
        //
        mnuDosya.DropDownItems.AddRange(new ToolStripItem[] { mnuYeniNot, mnuKaydet, mnuYenidenYukle, mnuDisaAktar, mnuAyrac, mnuCikis });
        mnuDosya.Name = "mnuDosya";
        mnuDosya.Size = new Size(51, 20);
        mnuDosya.Text = "&Dosya";
        //
        // mnuYeniNot
        //
        mnuYeniNot.Name = "mnuYeniNot";
        mnuYeniNot.ShortcutKeys = Keys.Control | Keys.N;
        mnuYeniNot.Size = new Size(180, 22);
        mnuYeniNot.Text = "&Yeni Not";
        mnuYeniNot.Click += btnYeni_Click;
        //
        // mnuKaydet
        //
        mnuKaydet.Name = "mnuKaydet";
        mnuKaydet.ShortcutKeys = Keys.Control | Keys.S;
        mnuKaydet.Size = new Size(180, 22);
        mnuKaydet.Text = "&Kaydet";
        mnuKaydet.Click += btnKaydet_Click;
        //
        // mnuYenidenYukle
        //
        mnuYenidenYukle.Name = "mnuYenidenYukle";
        mnuYenidenYukle.Size = new Size(180, 22);
        mnuYenidenYukle.Text = "Yeniden Y&ükle";
        mnuYenidenYukle.Click += mnuYenidenYukle_Click;
        //
        // mnuDisaAktar
        //
        mnuDisaAktar.Name = "mnuDisaAktar";
        mnuDisaAktar.Size = new Size(180, 22);
        mnuDisaAktar.Text = "Dışa &Aktar (.txt)...";
        mnuDisaAktar.Click += btnDisaAktar_Click;
        //
        // mnuAyrac
        //
        mnuAyrac.Name = "mnuAyrac";
        mnuAyrac.Size = new Size(177, 6);
        //
        // mnuCikis
        //
        mnuCikis.Name = "mnuCikis";
        mnuCikis.Size = new Size(180, 22);
        mnuCikis.Text = "&Çıkış";
        mnuCikis.Click += mnuCikis_Click;
        //
        // stsDurum
        //
        stsDurum.Items.AddRange(new ToolStripItem[] { tslNotSayisi, tslDosyaYolu, tslDurum, tslSonKayit });
        stsDurum.Location = new Point(0, 587);
        stsDurum.Name = "stsDurum";
        stsDurum.Size = new Size(984, 24);
        stsDurum.TabIndex = 2;
        //
        // tslNotSayisi
        //
        tslNotSayisi.Name = "tslNotSayisi";
        tslNotSayisi.Size = new Size(74, 19);
        tslNotSayisi.Text = "Not sayısı: 0";
        //
        // tslDosyaYolu
        //
        tslDosyaYolu.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Right;
        tslDosyaYolu.Name = "tslDosyaYolu";
        tslDosyaYolu.Size = new Size(600, 19);
        tslDosyaYolu.Spring = true;
        tslDosyaYolu.Text = "Dosya yolu";
        tslDosyaYolu.TextAlign = ContentAlignment.MiddleLeft;
        //
        // tslDurum
        //
        tslDurum.Name = "tslDurum";
        tslDurum.Size = new Size(36, 19);
        tslDurum.Text = "Hazır";
        //
        // tslSonKayit
        //
        tslSonKayit.BorderSides = ToolStripStatusLabelBorderSides.Left;
        tslSonKayit.Name = "tslSonKayit";
        tslSonKayit.Size = new Size(70, 19);
        tslSonKayit.Text = "Son kayıt: -";
        //
        // splAna
        //
        splAna.Dock = DockStyle.Fill;
        splAna.FixedPanel = FixedPanel.Panel1;
        splAna.Location = new Point(0, 24);
        splAna.Name = "splAna";
        //
        // splAna.Panel1
        //
        splAna.Panel1.Controls.Add(tlpListe);
        splAna.Panel1.Padding = new Padding(8);
        //
        // splAna.Panel2
        //
        splAna.Panel2.Controls.Add(tlpEditor);
        splAna.Panel2.Padding = new Padding(8);
        splAna.Size = new Size(984, 563);
        splAna.SplitterDistance = 300;
        splAna.TabIndex = 1;
        //
        // tlpListe
        //
        tlpListe.ColumnCount = 1;
        tlpListe.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tlpListe.Controls.Add(lblArama, 0, 0);
        tlpListe.Controls.Add(txtArama, 0, 1);
        tlpListe.Controls.Add(lblKategoriFiltre, 0, 2);
        tlpListe.Controls.Add(cmbKategoriFiltre, 0, 3);
        tlpListe.Controls.Add(lstNotlar, 0, 4);
        tlpListe.Dock = DockStyle.Fill;
        tlpListe.Location = new Point(8, 8);
        tlpListe.Name = "tlpListe";
        tlpListe.RowCount = 5;
        tlpListe.RowStyles.Add(new RowStyle());
        tlpListe.RowStyles.Add(new RowStyle());
        tlpListe.RowStyles.Add(new RowStyle());
        tlpListe.RowStyles.Add(new RowStyle());
        tlpListe.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tlpListe.Size = new Size(284, 547);
        tlpListe.TabIndex = 0;
        //
        // lblArama
        //
        lblArama.AutoSize = true;
        lblArama.Location = new Point(3, 0);
        lblArama.Name = "lblArama";
        lblArama.Size = new Size(123, 15);
        lblArama.TabIndex = 0;
        lblArama.Text = "Ara (başlık veya içerik)";
        //
        // txtArama
        //
        txtArama.Dock = DockStyle.Fill;
        txtArama.Location = new Point(3, 18);
        txtArama.Name = "txtArama";
        txtArama.Size = new Size(278, 23);
        txtArama.TabIndex = 1;
        txtArama.TextChanged += Filtre_Degisti;
        //
        // lblKategoriFiltre
        //
        lblKategoriFiltre.AutoSize = true;
        lblKategoriFiltre.Location = new Point(3, 44);
        lblKategoriFiltre.Name = "lblKategoriFiltre";
        lblKategoriFiltre.Size = new Size(84, 15);
        lblKategoriFiltre.TabIndex = 2;
        lblKategoriFiltre.Text = "Kategori filtresi";
        //
        // cmbKategoriFiltre
        //
        cmbKategoriFiltre.Dock = DockStyle.Fill;
        cmbKategoriFiltre.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbKategoriFiltre.FormattingEnabled = true;
        cmbKategoriFiltre.Location = new Point(3, 62);
        cmbKategoriFiltre.Name = "cmbKategoriFiltre";
        cmbKategoriFiltre.Size = new Size(278, 23);
        cmbKategoriFiltre.TabIndex = 3;
        cmbKategoriFiltre.SelectedIndexChanged += Filtre_Degisti;
        //
        // lstNotlar
        //
        lstNotlar.Dock = DockStyle.Fill;
        lstNotlar.FormattingEnabled = true;
        lstNotlar.HorizontalScrollbar = true;
        lstNotlar.IntegralHeight = false;
        lstNotlar.Location = new Point(3, 91);
        lstNotlar.Name = "lstNotlar";
        lstNotlar.Size = new Size(278, 453);
        lstNotlar.TabIndex = 4;
        lstNotlar.SelectedIndexChanged += lstNotlar_SelectedIndexChanged;
        //
        // tlpEditor
        //
        tlpEditor.ColumnCount = 1;
        tlpEditor.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tlpEditor.Controls.Add(lblBaslik, 0, 0);
        tlpEditor.Controls.Add(txtBaslik, 0, 1);
        tlpEditor.Controls.Add(lblKategori, 0, 2);
        tlpEditor.Controls.Add(cmbKategori, 0, 3);
        tlpEditor.Controls.Add(lblIcerik, 0, 4);
        tlpEditor.Controls.Add(rtbIcerik, 0, 5);
        tlpEditor.Controls.Add(flpTarihler, 0, 6);
        tlpEditor.Controls.Add(flpButonlar, 0, 7);
        tlpEditor.Dock = DockStyle.Fill;
        tlpEditor.Location = new Point(8, 8);
        tlpEditor.Name = "tlpEditor";
        tlpEditor.RowCount = 8;
        tlpEditor.RowStyles.Add(new RowStyle());
        tlpEditor.RowStyles.Add(new RowStyle());
        tlpEditor.RowStyles.Add(new RowStyle());
        tlpEditor.RowStyles.Add(new RowStyle());
        tlpEditor.RowStyles.Add(new RowStyle());
        tlpEditor.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tlpEditor.RowStyles.Add(new RowStyle());
        tlpEditor.RowStyles.Add(new RowStyle());
        tlpEditor.Size = new Size(664, 547);
        tlpEditor.TabIndex = 0;
        //
        // lblBaslik
        //
        lblBaslik.AutoSize = true;
        lblBaslik.Location = new Point(3, 0);
        lblBaslik.Name = "lblBaslik";
        lblBaslik.Size = new Size(38, 15);
        lblBaslik.TabIndex = 0;
        lblBaslik.Text = "Başlık";
        //
        // txtBaslik
        //
        txtBaslik.Dock = DockStyle.Fill;
        txtBaslik.Location = new Point(3, 18);
        txtBaslik.MaxLength = 200;
        txtBaslik.Name = "txtBaslik";
        txtBaslik.Size = new Size(658, 23);
        txtBaslik.TabIndex = 1;
        txtBaslik.TextChanged += Editor_Degisti;
        //
        // lblKategori
        //
        lblKategori.AutoSize = true;
        lblKategori.Location = new Point(3, 44);
        lblKategori.Name = "lblKategori";
        lblKategori.Size = new Size(51, 15);
        lblKategori.TabIndex = 2;
        lblKategori.Text = "Kategori";
        //
        // cmbKategori
        //
        cmbKategori.Location = new Point(3, 62);
        cmbKategori.FormattingEnabled = true;
        cmbKategori.MaxLength = 50;
        cmbKategori.Name = "cmbKategori";
        cmbKategori.Size = new Size(220, 23);
        cmbKategori.TabIndex = 3;
        cmbKategori.TextChanged += Editor_Degisti;
        //
        // lblIcerik
        //
        lblIcerik.AutoSize = true;
        lblIcerik.Location = new Point(3, 88);
        lblIcerik.Name = "lblIcerik";
        lblIcerik.Size = new Size(36, 15);
        lblIcerik.TabIndex = 4;
        lblIcerik.Text = "İçerik";
        //
        // rtbIcerik
        //
        rtbIcerik.AcceptsTab = true;
        rtbIcerik.Dock = DockStyle.Fill;
        rtbIcerik.Location = new Point(3, 106);
        rtbIcerik.Name = "rtbIcerik";
        rtbIcerik.Size = new Size(658, 376);
        rtbIcerik.TabIndex = 5;
        rtbIcerik.Text = "";
        rtbIcerik.TextChanged += Editor_Degisti;
        //
        // flpTarihler
        //
        flpTarihler.AutoSize = true;
        flpTarihler.Controls.Add(lblOlusturma);
        flpTarihler.Controls.Add(lblDuzenleme);
        flpTarihler.Dock = DockStyle.Fill;
        flpTarihler.Location = new Point(3, 488);
        flpTarihler.Name = "flpTarihler";
        flpTarihler.Size = new Size(658, 15);
        flpTarihler.TabIndex = 6;
        //
        // lblOlusturma
        //
        lblOlusturma.AutoSize = true;
        lblOlusturma.Location = new Point(0, 0);
        lblOlusturma.Margin = new Padding(0, 0, 24, 0);
        lblOlusturma.Name = "lblOlusturma";
        lblOlusturma.Size = new Size(73, 15);
        lblOlusturma.TabIndex = 0;
        lblOlusturma.Text = "Oluşturma: -";
        //
        // lblDuzenleme
        //
        lblDuzenleme.AutoSize = true;
        lblDuzenleme.Location = new Point(97, 0);
        lblDuzenleme.Margin = new Padding(0);
        lblDuzenleme.Name = "lblDuzenleme";
        lblDuzenleme.Size = new Size(77, 15);
        lblDuzenleme.TabIndex = 1;
        lblDuzenleme.Text = "Düzenleme: -";
        //
        // flpButonlar
        //
        flpButonlar.AutoSize = true;
        flpButonlar.Controls.Add(btnYeni);
        flpButonlar.Controls.Add(btnKaydet);
        flpButonlar.Controls.Add(btnSil);
        flpButonlar.Controls.Add(btnDisaAktar);
        flpButonlar.Dock = DockStyle.Fill;
        flpButonlar.Location = new Point(0, 506);
        flpButonlar.Margin = new Padding(0);
        flpButonlar.Name = "flpButonlar";
        flpButonlar.Size = new Size(664, 41);
        flpButonlar.TabIndex = 7;
        //
        // btnYeni
        //
        btnYeni.Location = new Point(3, 3);
        btnYeni.Name = "btnYeni";
        btnYeni.Size = new Size(100, 32);
        btnYeni.TabIndex = 0;
        btnYeni.Text = "Yeni";
        btnYeni.UseVisualStyleBackColor = true;
        btnYeni.Click += btnYeni_Click;
        //
        // btnKaydet
        //
        btnKaydet.Location = new Point(109, 3);
        btnKaydet.Name = "btnKaydet";
        btnKaydet.Size = new Size(100, 32);
        btnKaydet.TabIndex = 1;
        btnKaydet.Text = "Kaydet";
        btnKaydet.UseVisualStyleBackColor = true;
        btnKaydet.Click += btnKaydet_Click;
        //
        // btnSil
        //
        btnSil.Location = new Point(215, 3);
        btnSil.Name = "btnSil";
        btnSil.Size = new Size(100, 32);
        btnSil.TabIndex = 2;
        btnSil.Text = "Sil";
        btnSil.UseVisualStyleBackColor = true;
        btnSil.Click += btnSil_Click;
        //
        // btnDisaAktar
        //
        btnDisaAktar.Location = new Point(321, 3);
        btnDisaAktar.Name = "btnDisaAktar";
        btnDisaAktar.Size = new Size(140, 32);
        btnDisaAktar.TabIndex = 3;
        btnDisaAktar.Text = "Dışa Aktar (.txt)";
        btnDisaAktar.UseVisualStyleBackColor = true;
        btnDisaAktar.Click += btnDisaAktar_Click;
        //
        // AnaForm
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(984, 611);
        Controls.Add(splAna);
        Controls.Add(stsDurum);
        Controls.Add(mnuAna);
        MainMenuStrip = mnuAna;
        MinimumSize = new Size(760, 450);
        Name = "AnaForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Not Defteri";
        FormClosing += AnaForm_FormClosing;
        Shown += AnaForm_Shown;
        mnuAna.ResumeLayout(false);
        mnuAna.PerformLayout();
        stsDurum.ResumeLayout(false);
        stsDurum.PerformLayout();
        splAna.Panel1.ResumeLayout(false);
        splAna.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splAna).EndInit();
        splAna.ResumeLayout(false);
        tlpListe.ResumeLayout(false);
        tlpListe.PerformLayout();
        tlpEditor.ResumeLayout(false);
        tlpEditor.PerformLayout();
        flpTarihler.ResumeLayout(false);
        flpTarihler.PerformLayout();
        flpButonlar.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private MenuStrip mnuAna;
    private ToolStripMenuItem mnuDosya;
    private ToolStripMenuItem mnuYeniNot;
    private ToolStripMenuItem mnuKaydet;
    private ToolStripMenuItem mnuYenidenYukle;
    private ToolStripMenuItem mnuDisaAktar;
    private ToolStripSeparator mnuAyrac;
    private ToolStripMenuItem mnuCikis;
    private StatusStrip stsDurum;
    private ToolStripStatusLabel tslNotSayisi;
    private ToolStripStatusLabel tslDosyaYolu;
    private ToolStripStatusLabel tslDurum;
    private ToolStripStatusLabel tslSonKayit;
    private SplitContainer splAna;
    private ListBox lstNotlar;
    private TableLayoutPanel tlpListe;
    private Label lblArama;
    private TextBox txtArama;
    private Label lblKategoriFiltre;
    private ComboBox cmbKategoriFiltre;
    private Label lblKategori;
    private ComboBox cmbKategori;
    private TableLayoutPanel tlpEditor;
    private Label lblBaslik;
    private TextBox txtBaslik;
    private Label lblIcerik;
    private RichTextBox rtbIcerik;
    private FlowLayoutPanel flpTarihler;
    private Label lblOlusturma;
    private Label lblDuzenleme;
    private FlowLayoutPanel flpButonlar;
    private Button btnYeni;
    private Button btnKaydet;
    private Button btnSil;
    private Button btnDisaAktar;
}
