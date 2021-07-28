using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExportarDados
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            if (txt_pathOrigem.Text.Equals(""))
            {
                MessageBox.Show("OOOO cabaço como vou saber onde tenho que salvar os arquivos, selecione a poha do caminho dos arquivos");
                return;
            }
            if (txt_db.Text.Equals(""))
            {
                MessageBox.Show("MDS HOME mas não aprende, então agora tenho que adivinhar de qual banco vc quer os dados? coloca o numero do banco ai pra nois por favor");
                return;
            }


            MessageBox.Show("Vlw, Agora relaxa toma um café quando terminar te aviso");
            Thread t = new Thread(genereteArquivo);
            t.Start();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();


            if(folder.ShowDialog() == DialogResult.OK)
            {
                txt_pathOrigem.Text = folder.SelectedPath;
            }

        }

        private void genereteArquivo()
        {
            Conections conexao = new();
            Hashtable tables = new();
            Sqls sl = new();
            sl.PovoaSql(tables);
            SqlConnection cnn = new();
            try
            {
                cnn = conexao.NewInstance(txt_db.Text);

                foreach (DictionaryEntry e in tables)
                {
                    String arquivo = txt_pathOrigem.Text + "//" + e.Key.ToString() + ".csv";
                    System.IO.StreamWriter ex = new System.IO.StreamWriter(new FileStream(arquivo, FileMode.Create,FileAccess.Write,FileShare.Read));

                    string sql = e.Value.ToString();
                    SqlCommand command = new SqlCommand(sql, cnn);
                    SqlDataReader dr = command.ExecuteReader();
                    Byte pri = 0;
                    while (dr.Read())
                    {
                        SQLToExcellDr(dr, e.Key.ToString(), pri, ex);
                        pri = 1;
                    }
                    dr.Close();
                    command.Dispose();
                    ex.Dispose();
                    ex.Close();

                }
                cnn.Close();
            } catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            

            MessageBox.Show("Processo Terminado pia, só verificar as pastasa");
        }


        public static void SQLToExcellDr(SqlDataReader dr, string Filename, byte pHeader, System.IO.StreamWriter pFile)
        {
            
            if (pHeader == 0)
            {
                // Loop through the fields and add headers
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    string name = dr.GetName(i);
                    
                    if (name.Contains(";"))
                        name = "\"" + name + "\"";

                    pFile.Write(name + ";");
                    
                }
                pFile.WriteLine();
            }

            // Loop through the rows and output the data
            //while (dr.Read())
            //{
            for (int i = 0; i < dr.FieldCount; i++)
            {

                string value = dr[i].ToString();
                var a = dr[i].GetType();
                    
                if (value.Contains(";"))
                    value = "\"" + value + "\"";
                pFile.Write(value + ";");
                    
            }
            pFile.WriteLine();
        }
    }
}
