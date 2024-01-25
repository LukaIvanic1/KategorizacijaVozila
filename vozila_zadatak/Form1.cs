using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vozila_zadatak
{
    public partial class Form1 : Form
    {

        List<string> modeli = new List<string>();
        List<int> godineProizvodnje = new List<int>();
        List<int> brojeviKotaca = new List<int>();
        List<string> kategorije = new List<string>();



        public Form1()
        {
            InitializeComponent();
            pictureBox1.BackColor = Color.Transparent;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string model = textBox1.Text;
            int godinaProizvodnje, brojKotaca;

            if (!int.TryParse(textBox2.Text, out godinaProizvodnje) || !int.TryParse(textBox3.Text, out brojKotaca))
            {
                MessageBox.Show("Neispravan unos za godinu proizvodnje ili broj kotača.");
                return;
            }

            if (brojKotaca % 2 != 0)
            {
                MessageBox.Show("Neparni broj kotača nije dozvoljen.");
                return;
            }

            string kategorija = OdrediKategoriju(brojKotaca);
            AzurirajPodatke(model, godinaProizvodnje, brojKotaca, kategorija);

            string ispis = $"Model: {model}, Godina proizvodnje: {godinaProizvodnje}, Broj kotača: {brojKotaca}, Kategorija: {kategorija}\n";
            richTextBox1.AppendText(ispis);

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (modeli.Count == 0)
            {
                MessageBox.Show("Unesite podatke o vozilu prije obrade.");
                return;
            }

            
            for (int i = 0; i < modeli.Count; i++)
            {
                string kategorija = OdrediKategoriju(brojeviKotaca[i]);
                kategorije[i] = kategorija;
            }

            MessageBox.Show("Podaci su obrađeni.");
        }

        private string OdrediKategoriju(int brojKotaca)
        {
            if (brojKotaca == 2)
            {
                return "Motocikl";
            }
            else if (brojKotaca == 4)
            {
                return "Automobil";
            }
            else
            {
                return "Kamion";
            }
        }

        private void AzurirajPodatke(string model, int godinaProizvodnje, int brojKotaca, string kategorija)
        {
            modeli.Add(model);
            godineProizvodnje.Add(godinaProizvodnje);
            brojeviKotaca.Add(brojKotaca);
            kategorije.Add(kategorija);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < modeli.Count; i++)
            {
                string ispis = $"Model: {modeli[i]}, Godina proizvodnje: {godineProizvodnje[i]}, Broj kotača: {brojeviKotaca[i]}, Kategorija: {kategorije[i]}\n";
                richTextBox1.AppendText(ispis);
            }


            int motocikli = BrojVozilaUKategoriji("Motocikl");
            int automobili = BrojVozilaUKategoriji("Automobil");
            int kamioni = BrojVozilaUKategoriji("Kamion");

            richTextBox1.AppendText($"\nUkupan broj vozila:\nMotocikli: {motocikli}\nAutomobili: {automobili}\nKamioni: {kamioni}\n");
        }

        private int BrojVozilaUKategoriji(string kategorija)
        {
            int brojVozila = 0;
            for (int i = 0; i < kategorije.Count; i++)
            {
                if (kategorije[i] == kategorija)
                {
                    brojVozila++;
                }
            }
            return brojVozila;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }
    }
    }

