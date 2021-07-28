using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExportarDados
{
    class Conections
    {
        public SqlConnection NewInstance(String db)
        {
            SqlConnection cnn = new SqlConnection("Data Source=" + Environment.MachineName + "\\SQLEXPRESS2019;Initial Catalog=atmusinf_Control-" + db + ";User=sa;Password=Atmus@#4080");

            try
            {
                cnn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return cnn;
        }
    }
}
