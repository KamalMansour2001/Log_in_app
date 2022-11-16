using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;
using DataTable = System.Data.DataTable;
using ExcelDataReader;
using System.Threading.Tasks;
using System.Web;
using DocumentFormat.OpenXml.Office2010.Excel;
using Application = System.Windows.Forms.Application;
using Microsoft.Graph;
using DocumentFormat.OpenXml.Wordprocessing;

namespace DemoInloggning
{
    public partial class Inlggoning : Form
    {
        MySqlConnection conn = new MySqlConnection("server = 127.0.0.1; userid = root; port = 3308; password = ; database = test; Convert Zero Datetime = True;");
        MySqlCommand? cmd;
        List<Elev> elevlistainlog = new List<Elev>();
        DateTime datenu = DateTime.Now;


        bool b = false;
        public Inlggoning()
        {
            InitializeComponent();
            DateTime NollarDatum = new DateTime(datenu.Year, datenu.Month, datenu.Day);
            //G�r att programmet uppdaterar direkt n�r ny info �r inskriven i databasen.
            conn.Open();
            MySqlCommand alldata = new MySqlCommand("select * from kunskapcompaniet_elev_info", conn);
            NollarDatum.ToString("yyyy-MM-dd HH:mm:ss");
            MySqlDataReader dataReader = alldata.ExecuteReader();
            while (dataReader.Read())
            {
                int ID = (int)dataReader["ID"];
                string namn = (string)dataReader["namn"];
                int l�ssen = (int)dataReader["password"];
                DateTime inloggning = NollarDatum;
                DateTime utloggning = NollarDatum;
                elevlistainlog.Add(new Elev(namn, ID, l�ssen, inloggning, utloggning, b));
            }
            dataReader.Close();
            conn.Close();
        }
        public void visalistorna()
        {
            frmAdminPass frm = new frmAdminPass();

            frm.listBox2.Items.Add("INLOGGADE ELEVER:");
            frm.listBox1.Items.Add("UTLOGGADE ELEVER:");

            foreach (Elev elev in elevlistainlog)
            {
                if (elev.Finns == true)
                {
                    frm.listBox2.Items.Add(elev.Namn);
                }
            }
            foreach (Elev elev in elevlistainlog)
            {
                if (elev.Finns == false)
                {
                    frm.listBox1.Items.Add(elev.Namn);
                }
            }
            frm.Show();
        }


        private void btnlogin_Click(object sender, EventArgs e)
        {
            foreach (Elev elev in elevlistainlog)
            {
                if (elev.L�ssenord == int.Parse(txtl�ssenord.Text) && elev.ID == 10000)
                {
                    visalistorna();
                    txtl�ssenord.Clear();
                }
                else
                {
                    if (elev.L�ssenord == int.Parse(txtl�ssenord.Text) && elev.Finns == false)
                    {
                        MessageBox.Show("V�lkomna " + elev.Namn + " du �r nu inloggad ");
                        txtl�ssenord.Clear();
                        DateTime date = DateTime.Now;
                        elev.inlogning = date;
                        elev.Finns = true;


                        return;
                    }
                    else if (elev.L�ssenord == int.Parse(txtl�ssenord.Text) && elev.Finns == true)
                    {
                        MessageBox.Show("Du �r redan inloggad!");
                    }
                }
            }

        }

        private void btnloggaut_Click(object sender, EventArgs e)
        {
            //H�r ska det sparas n�r eleven loggade ut.
            foreach (Elev elev in elevlistainlog)
            {
                if (elev.L�ssenord == int.Parse(txtl�ssenord.Text) && elev.ID == 10000) // G�r att enbart Admin kan st�nga programmet.
                {
                    Inlggoning.ActiveForm.Close();
                    DateTime NollarDatum = new DateTime(datenu.Year, datenu.Month, datenu.Day);
                    // H�r skickas all data som finns i listan till databasen.
                    foreach (Elev eleven in elevlistainlog) //loopar igenom listan.
                    {
                        var temp = conn.State.ToString();
                        if (temp == "Open" && eleven.Utlogning == NollarDatum) //Kollar ifall finns uppkoppling med databasen.
                        {                                                    //Kollar ocks� ifall eleven inte har loggat ut f�r dagen d� skrivs dem i
                                                                             //databasen men dessa som har loggat in skrivs redan n�r dem loggar ut
                                                                             //d� kan anv�ndare logga ut och sedan in flera g�nger om dagen. Allt �r reggad.
                            try
                            {
                                string insertQury = "INSERT INTO kunskapscompaniet_elever VALUES(@ID, @namn, @password, @inloggning, @utloggning)";
                                cmd = new MySqlCommand(insertQury, conn);
                                cmd.Parameters.AddWithValue("@ID", eleven.ID);
                                cmd.Parameters.AddWithValue("@namn", eleven.Namn);
                                cmd.Parameters.AddWithValue("@password", eleven.L�ssenord);
                                cmd.Parameters.AddWithValue("@inloggning", eleven.inlogning);
                                cmd.Parameters.AddWithValue("@utloggning", eleven.Utlogning);
                                // insertar datan till databasen.

                                int a = cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex) // Om n�got fel uppst�r visas det i en messageBox. (l�ttare fel hantering).
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                conn.Close();
                            }
                        }
                        else if (eleven.Utlogning == NollarDatum)
                        {
                            try
                            {
                                conn.Open();
                                string insertQury = "INSERT INTO kunskapscompaniet_elever VALUES(@ID, @namn, @password, @inloggning, @utloggning)";
                                cmd = new MySqlCommand(insertQury, conn);
                                cmd.Parameters.AddWithValue("@ID", eleven.ID);
                                cmd.Parameters.AddWithValue("@namn", eleven.Namn);
                                cmd.Parameters.AddWithValue("@password", eleven.L�ssenord);
                                cmd.Parameters.AddWithValue("@inloggning", eleven.inlogning);
                                cmd.Parameters.AddWithValue("@utloggning", eleven.Utlogning);


                                int a = cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                conn.Close();
                            }
                        }
                    }
                }
                else if (elev.L�ssenord == int.Parse(txtl�ssenord.Text) && elev.Finns == true)
                {
                    int elevid = elev.ID;
                    frmAdminPass frm = new frmAdminPass();

                    frm.listBox1.Items.Clear();
                    frm.listBox2.Items.Clear();

                    MessageBox.Show("Tack f�r idag " + elev.Namn + " Du �r nu utloggad ");

                    txtl�ssenord.Clear();
                    DateTime datumutlog = DateTime.Now;
                    elev.Utlogning = datumutlog;
                    elev.Finns = false;
                    conn.Open();
                    string insertQury = "INSERT INTO kunskapscompaniet_elever VALUES(@ID, @namn, @password, @inloggning, @utloggning)";
                    cmd = new MySqlCommand(insertQury, conn);
                    cmd.Parameters.AddWithValue("@ID", elev.ID);
                    cmd.Parameters.AddWithValue("@namn", elev.Namn);
                    cmd.Parameters.AddWithValue("@password", elev.L�ssenord);
                    cmd.Parameters.AddWithValue("@inloggning", elev.inlogning);
                    cmd.Parameters.AddWithValue("@utloggning", elev.Utlogning);
                    int a = cmd.ExecuteNonQuery();
                    conn.Close();
                    return;
                }
                else if (elev.L�ssenord == int.Parse(txtl�ssenord.Text) && elev.Finns == false)
                {
                    MessageBox.Show("Du �r inte inloggad �n!. Har du gl�mt logga in idag? (Kontakta ansvariga).");
                }

            }
                conn.Close();
        }
  
    }
}