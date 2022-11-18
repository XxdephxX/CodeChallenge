using CodeChallenge.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallenge.Data
{
    public class CompensationDataSeeder
    {
        private CompensationContext _ctx;
        private const string COMPENSATION_SEED_DATA_FILE = "resources/CompensationSeedData.json";

        public CompensationDataSeeder(CompensationContext ctx)
        {
            _ctx= ctx;
        }

        public async Task Seed()
        {
            if (!_ctx.Compensation.Any())
            {
                List<Compensation> compensation = Load();
                _ctx.Compensation.AddRange(compensation);

                await _ctx.SaveChangesAsync();
            }
        }

        private List<Compensation> Load()
        {
            using (FileStream fs = new FileStream(COMPENSATION_SEED_DATA_FILE, FileMode.Open))
            using (StreamReader sr = new StreamReader(fs))
            using (JsonReader jr = new JsonTextReader(sr))
            {
                JsonSerializer serializer = new JsonSerializer();

                List<Compensation> c = serializer.Deserialize<List<Compensation>>(jr);

                return c;
            }
        }
    }
}

