﻿using System.Net;
using System.Text.Json;

namespace Currency
{
    public class Currency
    {
        public string? table { get; set; }
        public string? currency { get; set; }
        public string? code { get; set; }
        public IList<Rate> rates { get; set; }
    }
    public class Rate
    {
        public string? no { get; set; }
        public string? effectiveDate { get; set; }
        public double? bid { get; set; }
        public double? ask { get; set; }
    }
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
            DateTime dzis = DateTime.Now;
            dpData.MaximumDate = dzis;
        }

        private void btnGetDataClickedUSD(object sender, EventArgs e)
        {
            string data = dpData.Date.ToString("yyyy-MM-dd");
            string url = "https://api.nbp.pl/api/exchangerates/rates/c/usd/" + data + "/?format=json";
            //string url = "https://api.nbp.pl/api/exchangerates/rates/c/usd/2024-10-22/?format=json";
            string json;
            using (var webClient = new WebClient())
            {
                json = webClient.DownloadString(url);
            }
            //lblJSON.Text = json;  
            Currency c = JsonSerializer.Deserialize<Currency>(json);

            string s = $"nazwa waluty: {c.currency}\n";
            s += $"kod waluty {c.code}\n";
            s += $"Data: {c.rates[0].effectiveDate} \n";
            s += $"Cena skupu: {c.rates[0].bid} \n";
            s += $"Cena sprzedazy: {c.rates[0].ask} \n";
            lblNBP.Text = s;
        }

        private void btnGetDataClickedEUR(object sender, EventArgs e)
        {
            string data = dpData.Date.ToString("yyyy-MM-dd");
            string url = "https://api.nbp.pl/api/exchangerates/rates/c/eur/" + data + "/?format=json";
            //string url = "https://api.nbp.pl/api/exchangerates/rates/c/usd/2024-10-22/?format=json";
            string json;
            using (var webClient = new WebClient())
            {
                json = webClient.DownloadString(url);
            }
            //lblJSON.Text = json;  
            Currency c = JsonSerializer.Deserialize<Currency>(json);

            string s = $"nazwa waluty: {c.currency}\n";
            s += $"kod waluty {c.code}\n";
            s += $"Data: {c.rates[0].effectiveDate} \n";
            s += $"Cena skupu: {c.rates[0].bid} \n";
            s += $"Cena sprzedazy: {c.rates[0].ask} \n";
            lblNBP.Text = s;
        }


    }

}

