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

                deserializar();
                rtbActions.Text = String.Format("{1}\n{0}", rtbActions.Text, "Arxiu JSON carregat correctament!");
            }
            else
            {
                rtbActions.Text = String.Format("{1}\n{0}", rtbActions.Text, "No se seleccionó ningún archivo.");
            }
        }


        private void btnAddBlock_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "All Files|*.*",
                Title = "Seleccionar un archivo"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string fileContent = File.ReadAllText(filePath);

                Block newBlock = new Block(blockchain.Chain.Count, DateTime.Now, fileContent, "", 0);
                blockchain.AddBlock(newBlock);

                rtbActions.Text = String.Format("{1}\n{0}", rtbActions.Text, "Bloque agregado con éxito.");
                serializar();
            }
        }

        private void serializar()
        {
            if (string.IsNullOrEmpty(filePath))
            {
                rtbActions.Text = String.Format("{1}\n{0}", rtbActions.Text, "No se ha cargado un archivo para serializar.");
                return;
            }

            string json = JsonConvert.SerializeObject(blockchain, Formatting.Indented);
            File.WriteAllText(filePath, json);

            deserializar();
        }

        private void deserializar()
        {
            string json = File.ReadAllText(filePath);
            blockchain = JsonConvert.DeserializeObject<Blockchain>(json);

            if (blockchain != null && blockchain.Chain != null && blockchain.Chain.Count > 0)
            {
                dataGridViewBlockchain.Rows.Clear();

                if (dataGridViewBlockchain.Columns.Count == 0)
                {
                    dataGridViewBlockchain.Columns.Add("Index", "Índice");
                    dataGridViewBlockchain.Columns.Add("Timestamp", "Timestamp");
                    dataGridViewBlockchain.Columns.Add("Data", "Data");
                    dataGridViewBlockchain.Columns.Add("PreviousHash", "PreviousHash");
                    dataGridViewBlockchain.Columns.Add("Hash", "Hash");
                    dataGridViewBlockchain.Columns.Add("Nonce", "Nonce");
                }

                foreach (Block block in blockchain.Chain)
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
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "All Files| *",
                Title = "Seleccionar el archivo que quieras comparar"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                int index = int.Parse(txtIndex.Text);
                Block originalBlock = blockchain.Chain.ElementAt(index);

                string documentToCheck = openFileDialog.FileName;
                string documentContent = File.ReadAllText(documentToCheck);
                string hashNewBlock = Block.CalculateHash(index, originalBlock.Timestamp, documentContent, originalBlock.PreviousHash, originalBlock.Nonce);

                lblResultIndex.Text = String.Format("Document Index: {0}", index.ToString());
                lblResult.Visible = true;

                if (originalBlock.Hash == hashNewBlock)
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
                if (string.IsNullOrWhiteSpace(txtIndex.Text) || !int.TryParse(txtIndex.Text, out _))
                {
                    e.Cancel = true;
                }
                else
                {
                    btnCheckFile.Enabled = true;
                }
        }

        private void btnDeserialize_Click(object sender, EventArgs e)
        {
            rtbBlockchain.Text = JsonConvert.SerializeObject(blockchain, Formatting.Indented);
        }
    }
}

