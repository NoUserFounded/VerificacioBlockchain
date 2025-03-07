using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace SerialitzacioJSON
{
    public partial class MainForm : Form
    {
        private Blockchain blockchain;
        private string filePath;  // Ruta del archivo JSON cargado

        public MainForm()
        {
            InitializeComponent();
            blockchain = new Blockchain(2); // Dificultad inicial
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Abrir archivo JSON cuando el formulario se cargue
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "JSON Files|*.json",
                Title = "Seleccionar un archivo JSON"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Guardar la ruta del archivo
                filePath = openFileDialog.FileName;

                // Leer el archivo JSON
                string jsonData = File.ReadAllText(filePath);

                // Deserializar la blockchain
                blockchain = JsonConvert.DeserializeObject<Blockchain>(jsonData);

                if (blockchain == null || blockchain.Chain == null || blockchain.Chain.Count == 0)
                {
                    rtbActions.Text = String.Format("{1}\n{0}", rtbActions.Text, "Error al cargar la blockchain o la cadena está vacía.");
                    return;
                }

                // Mostrar la dificultad en el TextBox
                int difficult = blockchain.Difficulty;
                if (difficult > 0)
                {
                    txtDifficulty.Text = difficult.ToString();
                    txtDifficulty.Enabled = false;
                } else
                {
                    rtbActions.Text = String.Format("{1}\n{0}", rtbActions.Text, "Error al cargar la dificultat,a l'espera d'afegir-ne una.");

                    txtDifficulty.Enabled = true;
                }

                // Mostrar la cadena de bloques en el RichTextBox
                rtbBlockchain.Text = JsonConvert.SerializeObject(blockchain, Formatting.Indented);
                deserializar();

                rtbActions.Text = String.Format("{1}\n{0}", rtbActions.Text, "Arxiu JSON carregat correctament!");
            }
            else
            {
                rtbActions.Text = String.Format("{1}\n{0}", rtbActions.Text, "No se seleccionó ningún archivo.");
            }
        }

        // Evento para agregar un bloque
        private void btnAddBlock_Click(object sender, EventArgs e)
        {
            // Abrir archivo cuando el formulario se cargue
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "All Files|*.*",  // Permitir cualquier tipo de archivo
                Title = "Seleccionar un archivo"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Leer el contenido del archivo seleccionado
                string filePath = openFileDialog.FileName;
                string fileContent = File.ReadAllText(filePath);  // Leer el archivo como texto

                // Obtener el último bloque
                Block lastBlock = blockchain.Chain.Last();

                // Asegurarse de que el índice del nuevo bloque sea el índice del último bloque + 1
                int newIndex = lastBlock.Index + 1;

                Random random = new Random();
                int nonce = random.Next(0, 10001);  // Generar un valor aleatorio entre 0 y 10000

                
                // Crear un nuevo bloque con los parámetros necesarios
                Block newBlock = new Block(newIndex, DateTime.Now, fileContent, lastBlock.Hash, nonce);

                // Minar el bloque con la dificultad especificada
                newBlock.MineBlock(int.Parse(txtDifficulty.Text));

                // Agregar el nuevo bloque a la cadena
                blockchain.Chain.Add(newBlock);

                // Mostrar la blockchain actualizada en el RichTextBox
                rtbBlockchain.Text = JsonConvert.SerializeObject(blockchain, Formatting.Indented);

                rtbActions.Text = String.Format("{1}\n{0}", rtbActions.Text, "Bloque agregado con éxito.");
                serializar();
            }
        }

        // Evento para serializar el bloque
        private void serializar()
        {
            if (string.IsNullOrEmpty(filePath))
            {
                rtbActions.Text = String.Format("{1}\n{0}", rtbActions.Text, "No se ha cargado un archivo para serializar.");
                return;
            }

            // Serializar la blockchain completa, no solo un bloque individual
            string json = JsonConvert.SerializeObject(blockchain, Formatting.Indented);

            // Guardar el JSON en el archivo ya existente
            File.WriteAllText(filePath, json);

            deserializar();
        }

        // Evento para deserializar el bloque
        private void deserializar()
        {
            // Leer el contenido del archivo JSON
            string json = File.ReadAllText(filePath);

            // Deserializar el JSON en la Blockchain completa
            blockchain = JsonConvert.DeserializeObject<Blockchain>(json);

            if (blockchain != null && blockchain.Chain != null && blockchain.Chain.Count > 0)
            {
                // Limpiar cualquier fila existente en el DataGridView
                dataGridViewBlockchain.Rows.Clear();

                // Configurar las columnas si aún no están configuradas (esto solo se hace una vez)
                if (dataGridViewBlockchain.Columns.Count == 0)
                {
                    dataGridViewBlockchain.Columns.Add("Index", "Índice");
                    dataGridViewBlockchain.Columns.Add("Timestamp", "Timestamp");
                    dataGridViewBlockchain.Columns.Add("Data", "Data");
                    dataGridViewBlockchain.Columns.Add("PreviousHash", "PreviousHash");
                    dataGridViewBlockchain.Columns.Add("Hash", "Hash");
                    dataGridViewBlockchain.Columns.Add("Nonce", "Nonce");
                }

                // Agregar los bloques a las filas del DataGridView
                foreach (var block in blockchain.Chain)
                {
                    dataGridViewBlockchain.Rows.Add(
                        block.Index,
                        block.Timestamp.ToString(),
                        block.Data,
                        block.PreviousHash,
                        block.Hash,
                        block.Nonce
                    );
                }
            }
            else
            {
                rtbActions.Text = String.Format("{1}\n{0}", rtbActions.Text, "No se pudo deserializar la blockchain correctamente.");
            }
        }

        private void btnCheckFile_Click(object sender, EventArgs e)
        {
            // Abrir archivo JSON cuando el formulario se cargue
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "All Files| *",
                Title = "Seleccionar el archivo que quieras comparar"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Guardar la ruta del archivo
                string documentToCheck = openFileDialog.FileName;
                string documentContent = File.ReadAllText(documentToCheck);
                // Crear un nuevo bloque con los parámetros necesarios
                int index = int.Parse(txtIndex.Text);
                Block originalBlock = blockchain.Chain.ElementAt(index);
                Block newBlock = new Block(index, DateTime.Now, documentContent, originalBlock.PreviousHash, originalBlock.Nonce);

                lblResultIndex.Text = String.Format("{0}{1}", lblResultIndex.Text, index.ToString());
                lblResult.Visible = true;
                if (originalBlock == newBlock)
                {
                    pbResult.Image = Properties.Resources.OK;
                    lblResult.Text = "Succesfuly verified";
                } else
                {
                    pbResult.Image = Properties.Resources.NOK;
                    lblResult.Text = "Unsuccesfuly verified";
                }
            }
        }

        private void txtIndex_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
                // Verificar si el contenido del TextBox es un número
                if (string.IsNullOrWhiteSpace(txtIndex.Text) || !int.TryParse(txtIndex.Text, out _))
                {
                    e.Cancel = true; // Cancelar el evento de pérdida de foco
                }
                else
                {
                    // Si es un número, habilitar el botón
                    btnCheckFile.Enabled = true;
                }
        }
    }
}

