namespace WinFormsVisorImagenes
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            buttonCargarImagenes = new Button();
            imageList1 = new ImageList(components);
            listView1 = new ListView();
            button1 = new Button();
            buttonGuardarPDF = new Button();
            SuspendLayout();
            // 
            // buttonCargarImagenes
            // 
            buttonCargarImagenes.Location = new Point(12, 12);
            buttonCargarImagenes.Name = "buttonCargarImagenes";
            buttonCargarImagenes.Size = new Size(75, 23);
            buttonCargarImagenes.TabIndex = 0;
            buttonCargarImagenes.Text = "Cargar Imagenes";
            buttonCargarImagenes.UseVisualStyleBackColor = true;
            buttonCargarImagenes.Click += buttonCargarImagenes_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth16Bit;
            imageList1.ImageSize = new Size(80, 140);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // listView1
            // 
            listView1.LargeImageList = imageList1;
            listView1.Location = new Point(12, 41);
            listView1.Name = "listView1";
            listView1.Size = new Size(389, 567);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // button1
            // 
            button1.Location = new Point(107, 12);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Seleccionar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnSeleccionar_Click;
            // 
            // buttonGuardarPDF
            // 
            buttonGuardarPDF.Location = new Point(203, 12);
            buttonGuardarPDF.Name = "buttonGuardarPDF";
            buttonGuardarPDF.Size = new Size(75, 23);
            buttonGuardarPDF.TabIndex = 3;
            buttonGuardarPDF.Text = "PDF";
            buttonGuardarPDF.UseVisualStyleBackColor = true;
            buttonGuardarPDF.Click += buttonGuardarPDF_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(865, 620);
            Controls.Add(buttonGuardarPDF);
            Controls.Add(button1);
            Controls.Add(listView1);
            Controls.Add(buttonCargarImagenes);
            Name = "Form1";
            Text = "Visor Imagenes";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
        }

        #endregion

        private Button buttonCargarImagenes;
        private ImageList imageList1;
        private ListView listView1;
        private Button button1;
        private Button buttonGuardarPDF;
    }
}
