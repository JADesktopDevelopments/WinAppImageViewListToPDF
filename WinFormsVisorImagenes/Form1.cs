using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.IO.Image;

namespace WinFormsVisorImagenes
{
    public partial class Form1 : Form
    {
        private List<string> rutasImagenes = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCargarImagenes_Click(object sender, EventArgs e)
        {
            GC.Collect();
            // Limpiar el ListView e ImageList antes de cargar nuevas imágenes
            listView1.Items.Clear();
            imageList1.Images.Clear();

            OpenFileDialog openFileDialog1 = new()
            {
                Multiselect = true,
                Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Todos los archivos|*.*"
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (string filePath in openFileDialog1.FileNames)
                {
                    try
                    {
                        // Cargar la imagen en el ImageList
                        System.Drawing.Image image = System.Drawing.Image.FromFile(filePath);
                        imageList1.Images.Add(filePath, image);

                        // Crear un nuevo ListViewItem
                        ListViewItem item = new()
                        {
                            Text = Path.GetFileName(filePath), // Nombre del archivo como texto
                            ImageKey = filePath // Usar la ruta completa como clave para la imagen
                        };

                        // Añadir el ítem al ListView
                        listView1.Items.Add(item);
                        GC.Collect();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cargar la imagen {filePath}: {ex.Message}");
                    }
                }
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                MessageBox.Show($"Se han seleccionado {listView1.SelectedItems.Count} imágenes.");

                foreach (ListViewItem selectedItem in listView1.SelectedItems)
                {
                    // La propiedad ImageKey contiene la ruta del archivo que usamos al cargarlo
                    string filePath = selectedItem.ImageKey;
                    MessageBox.Show($"Imagen seleccionada: {filePath}");

                    // Aquí puede agregar la lógica para procesar cada imagen seleccionada
                    // Por ejemplo, guardar en otra ubicación, mostrar en un PictureBox, etc.
                }
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ninguna imagen.");
            }
        }

        private void buttonGuardarPDF_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                MessageBox.Show($"Se han seleccionado {listView1.SelectedItems.Count} imágenes.");

                string[] selectedItems = new string[listView1.SelectedItems.Count];

                int index = 0;
                foreach (ListViewItem selectedItem in listView1.SelectedItems)
                {
                    // La propiedad ImageKey contiene la ruta del archivo que usamos al cargarlo
                    string filePath = selectedItem.ImageKey;
                    selectedItems[index] = filePath;
                    index++;
                    //MessageBox.Show($"Imagen seleccionada: {filePath}");

                    // Aquí puede agregar la lógica para procesar cada imagen seleccionada
                    // Por ejemplo, guardar en otra ubicación, mostrar en un PictureBox, etc.
                }

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Archivos PDF|*.pdf";
                    saveFileDialog.Title = "Guardar archivo PDF";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            // Inicializa el escritor PDF
                            using (PdfWriter writer = new PdfWriter(saveFileDialog.FileName))
                            {
                                // Inicializa el documento PDF
                                using (PdfDocument pdf = new PdfDocument(writer))
                                {
                                    // Inicializa el diseño del documento
                                    Document document = new Document(pdf);

                                    foreach (string rutaImagen in selectedItems)
                                    {
                                        // Carga la imagen
                                        ImageData imageData = ImageDataFactory.Create(rutaImagen);
                                        iText.Layout.Element.Image image = new iText.Layout.Element.Image(imageData);

                                        // Ajusta la imagen al tamaño de la página
                                        image.ScaleToFit(pdf.GetDefaultPageSize().GetWidth(), pdf.GetDefaultPageSize().GetHeight());
                                        image.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);

                                        // Añade un salto de página para cada imagen, si se desea
                                        document.Add(image);
                                        if (rutasImagenes.IndexOf(rutaImagen) < rutasImagenes.Count - 1)
                                        {
                                            document.Add(new AreaBreak());
                                        }
                                    }
                                }
                            }
                            MessageBox.Show("El PDF se ha creado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ocurrió un error al crear el PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ninguna imagen.");
                return;
            }
        }



       
    }
}
