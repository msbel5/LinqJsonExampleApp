using linquygulama.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace linquygulama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Department> dList = new List<Department>();
        string[] dArray = new string[3];
        string[] eArray = new string[4];
        List<Employee> eList = new List<Employee>();

        private void Form1_Load(object sender, EventArgs e)
        {
            #region json

            string DepPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Texts\dep.txt");
            string EmpPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Texts\emp.txt");

            using (TextReader reader = File.OpenText(DepPath))
            {
                string line = null;
                int n = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    dArray[n] = line;
                    n++;
                }

            }

            using (TextReader reader = File.OpenText(EmpPath))
            {
                string line = null;
                int n = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    eArray[n] = line;
                    n++;
                }
            }

            foreach (string item in dArray)
            {
                Department d = JsonConvert.DeserializeObject<Department>(item);
                dList.Add(d);
            }
            foreach (string item in eArray)
            {
                Employee emp = JsonConvert.DeserializeObject<Employee>(item);
                eList.Add(emp);
            }

            #endregion

            var calısanliste = (from item in eList select item);

            var AdSoyadListe = (from item in eList select new { Ad = item.Adi, Soyad = item.Soyad });

            var SorumluRapor = (from calısan in eList join sorumlu in eList on calısan.SorumluId equals sorumlu.ID  join departman in dList on calısan.DepartmanId equals departman.Id  select new { CalısanAdSoyad = calısan.Adi+" "+calısan.Soyad,SorumluAdSoyad = sorumlu.Adi+" "+sorumlu.Soyad, Dep = departman.DepartmanAdi });

            var calısanYas = (from calısan in eList select new { CalısanAdSoyad = calısan.Adi + " " + calısan.Soyad, Yas = (DateTime.Now.Year-calısan.Dt.Year) });

            var DogumGunu = (from calısan in eList where calısan.Dt.Day == DateTime.Now.Day && calısan.Dt.Month == DateTime.Now.Month select calısan);

            var SehirGrup = (from calısan in eList group calısan by calısan.Sehir into grp select new { miktar = grp.Count(), sehir = grp.Key });

            var DepartmanGrup = (from calısan in eList join departman in dList on calısan.DepartmanId equals departman.Id group departman by departman.DepartmanAdi into grp select new { departmanAdı = grp.Key, miktar = grp.Count() });

            var DepartmanSorumlusu = (from departman in dList join calısan in eList on departman.Id equals calısan.DepartmanId join sorumlu in eList on calısan.SorumluId equals sorumlu.ID select new { departmanAdı = departman.DepartmanAdi, sorumluADıSoyadı = sorumlu.Adi + " " + sorumlu.Soyad });

            var y90dansonragiren = (from calısan in eList where calısan.GirisTarih.Year > 1990 select calısan);

            var y16dansonracıkan = (from calısan in eList where calısan.CikisTarih.Year > 2016 select calısan);
        }

    }
}
