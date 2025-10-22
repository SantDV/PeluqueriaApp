using PeluqueriaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PeluqueriaApp.Data
{
    public static class TurnoStorage
    {
        private static readonly string filePath = Path.Combine(
    AppDomain.CurrentDomain.BaseDirectory, "turnos.json");


        public static List<Turno> Cargar()
        {
            if (!File.Exists(filePath)) return new List<Turno>();
            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Turno>>(json) ?? new List<Turno>();
        }

        public static void Guardar(List<Turno> turnos)
        {
            var json = JsonSerializer.Serialize(turnos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
    }
}
