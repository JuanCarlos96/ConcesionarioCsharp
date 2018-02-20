using Finisar.SQLite;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ConcesionarioCsharp
{
    public partial class TablaCoches : Form
    {
        private EditarCoche editarCoche = new EditarCoche();
        private ConectorSQLite conector;
        private DataTable dtRecord;
        private SQLiteDataAdapter DataAdap;

        public TablaCoches(ConectorSQLite con)
        {
            conector = con;
            InitializeComponent();
            string sql;
            sql = "SELECT * FROM Coche";
            iniciar_datagrid(sql);
        }

        public Interfaz Opener { get; set; }

        private void iniciar_datagrid(string sql)
        {
            SQLiteCommand consulta = conector.DameComando();
            consulta.CommandText = sql;

            //SQLiteDataAdapter 
            DataAdap = new SQLiteDataAdapter(consulta);//Hace de intermediario entre la base de datos y el DataGrid
            dtRecord = new DataTable();
            DataAdap.Fill(dtRecord);
            dataGridView1.DataSource = dtRecord;

            //Personalización de Columnas
            //Como las columnas solamente se conocen en tiempo de ejecución, le tengo que dar aquí los anchos
            dataGridView1.Columns[0].Width = 140;
            dataGridView1.Columns[0].HeaderText = "Bastidor";
            dataGridView1.Columns[1].Width = 100;//MARCA
            dataGridView1.Columns[2].Width = 90;//MODELO
            dataGridView1.Columns[3].Width = 80;//MOTOR
            dataGridView1.Columns[4].Width = 40;//CABALLOS
            dataGridView1.Columns[5].Width = 90;//TIPO
            dataGridView1.Columns[6].Width = 80;//COLOR
            dataGridView1.Columns[7].Width = 53;//PRECIO
            dataGridView1.Columns[8].Width = 100;//IMAGEN

            //Columna Tipo
            DataGridViewComboBoxColumn comboTipo = new DataGridViewComboBoxColumn();
            comboTipo.Name = "Tipo";
            comboTipo.DataPropertyName = "Tipo";
            comboTipo.Items.Add("TURISMO");
            comboTipo.Items.Add("SEDÁN");
            comboTipo.Items.Add("COMPACTO");
            comboTipo.Items.Add("DEPORTIVO");
            comboTipo.Items.Add("COMERCIAL");
            comboTipo.Items.Add("FAMILIAR");
            comboTipo.Items.Add("TODOTERRENO");
            dataGridView1.Columns.RemoveAt(5);
            dataGridView1.Columns.Insert(5, comboTipo);

            //Botón auxiliar para seleccionar imagen
            DataGridViewButtonColumn botonImg = new DataGridViewButtonColumn();
            botonImg.Name = "Imagen";
            botonImg.Text = "Seleccionar Imagen";
            botonImg.HeaderText = "";
            botonImg.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(botonImg);

            //COMANDO INSERT
            SQLiteCommand comando_ins = new SQLiteCommand("INSERT INTO Coche VALUES (@bastidor,@marca,@modelo,@motor,@cv,@tipo,@color,@precio,@imagen)", conector.DameConexion());
            comando_ins.Parameters.Add(new SQLiteParameter("@bastidor", DbType.String));
            comando_ins.Parameters.Add(new SQLiteParameter("@marca", DbType.String));
            comando_ins.Parameters.Add(new SQLiteParameter("@modelo", DbType.String));
            comando_ins.Parameters.Add(new SQLiteParameter("@motor", DbType.String));
            comando_ins.Parameters.Add(new SQLiteParameter("@cv", DbType.Int16));
            comando_ins.Parameters.Add(new SQLiteParameter("@tipo", DbType.String));
            comando_ins.Parameters.Add(new SQLiteParameter("@color", DbType.String));
            comando_ins.Parameters.Add(new SQLiteParameter("@precio", DbType.Decimal));
            comando_ins.Parameters.Add(new SQLiteParameter("@imagen", DbType.Binary));
            comando_ins.Parameters[0].SourceColumn = "N_Bastidor";
            comando_ins.Parameters[1].SourceColumn = "Marca";
            comando_ins.Parameters[2].SourceColumn = "Modelo";
            comando_ins.Parameters[3].SourceColumn = "Motor";
            comando_ins.Parameters[4].SourceColumn = "CV";
            comando_ins.Parameters[5].SourceColumn = "Tipo";
            comando_ins.Parameters[6].SourceColumn = "Color";
            comando_ins.Parameters[7].SourceColumn = "Precio";
            comando_ins.Parameters[8].SourceColumn = "Img";
            DataAdap.InsertCommand = comando_ins;
            DataAdap.InsertCommand.Connection = conector.DameConexion();

            //COMANDO UPDATE
            SQLiteCommand comando_act = new SQLiteCommand("UPDATE Coche SET Marca=@marca, Modelo=@modelo, Motor=@motor, CV=@cv, Tipo=@tipo, Color=@color, Precio=@precio, Img=@imagen WHERE N_Bastidor=@bastidor", conector.DameConexion()); 
            foreach (SQLiteParameter i in comando_ins.Parameters)
                comando_act.Parameters.Add(i);

            for (int i = 0; i < 9; i++)
                comando_act.Parameters[i].SourceColumn = comando_ins.Parameters[i].SourceColumn;

            DataAdap.UpdateCommand = comando_act;
            DataAdap.UpdateCommand.Connection = conector.DameConexion();

            //COMANDO DELETE
            SQLiteCommand comando_del = new SQLiteCommand("DELETE FROM Coche WHERE N_Bastidor = @bastidor", conector.DameConexion());
            comando_del.Parameters.Add(new SQLiteParameter("@bastidor", DbType.String));
            comando_del.Parameters[0].SourceColumn = "N_Bastidor";
            DataAdap.DeleteCommand = comando_del;
            DataAdap.DeleteCommand.Connection = conector.DameConexion();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Opener.pasadatos("coches");
            //editarCoche.ShowDialog();
        }

        public void nuevaFila()
        {
            DataRow fila = dtRecord.NewRow();
            dtRecord.Rows.Add(fila);
            dataGridView1.DataSource = dtRecord;
            dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1];
        }

        public void guardar()
        {
            bool correcto = true;

            for(int i=0; i<dataGridView1.RowCount; i++)
            {
                string bastidor = dataGridView1.Rows[i].Cells[1].Value.ToString();
                string marca = dataGridView1.Rows[i].Cells[2].Value.ToString();
                string modelo = dataGridView1.Rows[i].Cells[3].Value.ToString();
                string motor = dataGridView1.Rows[i].Cells[4].Value.ToString();
                string cv = dataGridView1.Rows[i].Cells[5].Value.ToString();
                string tipo = dataGridView1.Rows[i].Cells[6].Value.ToString();
                string color = dataGridView1.Rows[i].Cells[7].Value.ToString();
                string precio = dataGridView1.Rows[i].Cells[8].Value.ToString();

                if(bastidor == "")
                {
                    MessageBox.Show("Bastidor vacío en fila " + (i + 1));
                    dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[1];
                    correcto = false;
                    break;
                }else if(marca == "")
                {
                    MessageBox.Show("Marca vacía en fila " + (i + 1));
                    dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[2];
                    correcto = false;
                    break;
                }else if(modelo == "")
                {
                    MessageBox.Show("Modelo vacío en fila " + (i + 1));
                    dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[3];
                    correcto = false;
                    break;
                }else if(motor == "")
                {
                    MessageBox.Show("Motor vacío en fila " + (i + 1));
                    dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[4];
                    correcto = false;
                    break;
                }
                else if (cv == "")
                {
                    MessageBox.Show("CV incorrectos en fila " + (i + 1));
                    dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[5];
                    correcto = false;
                    break;
                }
                else if (tipo == "")
                {
                    MessageBox.Show("Tipo vacío en fila " + (i + 1));
                    dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[6];
                    correcto = false;
                    break;
                }
                else if(color == "")
                {
                    MessageBox.Show("Color vacío en fila " + (i + 1));
                    dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[7];
                    correcto = false;
                    break;
                }
                else if (precio == "")
                {
                    MessageBox.Show("Precio incorrecto en fila " + (i + 1));
                    dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[8];
                    correcto = false;
                    break;
                }
            }

            if (correcto)
            {
                dataGridView1.EndEdit();
                DataAdap.Update(dtRecord);
                MessageBox.Show("Datos guardados");

                SQLiteCommand consulta = conector.DameComando();
                consulta.CommandText = "SELECT * FROM Coche";
                dtRecord = new DataTable();
                DataAdap.Fill(dtRecord);
                dataGridView1.DataSource = dtRecord;
            }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            Opener.pasadatos("coches");
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Opener.pasadatos("coches2");
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 4:
                    MessageBox.Show("Error en los caballos, deben ser un entero");
                    break;
                case 7:
                    MessageBox.Show("Error en el precio, debe ser un número real");
                    break;
            }
        }

        private static Bitmap ResizeImage(Bitmap image, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(width, height);
            using (Graphics gfx = Graphics.FromImage(resizedImage))
            {
                gfx.DrawImage(image, new Rectangle(0, 0, width, height),
                    new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);
            }
            return resizedImage;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Imagen")
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "PNG Files(*.png)|*.png|JPG Files(*.jpg)|*.jpg|All Files(*.*)|*.*";
                dlg.Title = "Seleccionar Imagen";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Bitmap Imagen_orig = (Bitmap)Image.FromFile(dlg.FileName, true);
                    Bitmap imagen_reesc = ResizeImage(Imagen_orig, 180, 150);
                    ImageConverter converter = new ImageConverter();
                    byte[] bytes = (byte[])converter.ConvertTo(imagen_reesc, typeof(byte[]));

                    dataGridView1.Rows[e.RowIndex].Cells[9].Value = bytes;
                    Opener.pasadatos("coches");
                }
            }
        }
    }
}
