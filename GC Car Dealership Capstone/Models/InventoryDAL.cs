using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GC_Car_Dealership_Capstone.Models;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GC_Car_Dealership_Capstone.Models
{
    public class InventoryDAL
    {
        public HttpClient GetClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44391/api/");
            return client;
        }

        public async Task<string> GetRawJSON(string input)
        {
            var client = GetClient();
            var response = await client.GetAsync($"{input}");
            var json = await response.Content.ReadAsStringAsync();
            return json;
        }

        public async Task<List<Cars>> GetCars(string make=null, string model=null, int year=0, string color=null)
        {
            var client = GetClient();
            string queryString = "?";
            if (make != null) queryString += "make=" + make;
            if (model != null) queryString += "model=" + model;
            if (year != 0) queryString += "year=" + year;
            if (color != null) queryString += "color=" + color;
            var response = await client.GetAsync("Cars"+ queryString);
            List<Cars> cars = await response.Content.ReadAsAsync<List<Cars>>();
            return cars;
        }

        public async Task<Cars> GetCar(int id)
        {
            var client = GetClient();
            var response = await client.GetAsync($"Cars/{id}");
            Cars car = await response.Content.ReadAsAsync<Cars>();
            return car;
        }

    }
}
