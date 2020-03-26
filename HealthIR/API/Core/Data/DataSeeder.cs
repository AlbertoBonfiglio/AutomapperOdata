using Bogus;
using Benton.HealthIR.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace HealthIR.Core.Data
{
    public class DataSeeder
    {
        private readonly HealthDbContext ctx;
        public DataSeeder(HealthDbContext ctx) {
            this.ctx = ctx;
        }

        public void Seed() {
            SeedFakeData();
        }

        private void SeedFakeData()
        {
            if (ctx.Incidents.Any()) return;

            var list = new List<string> {
              "S-1-5-21-2099920240-310905942-615583016-20866",
              "S-1-5-21-2099920240-310905942-615583016-10273",
              "S-1-5-21-2099920240-310905942-615583016-1676"
            };

            var faker = new Faker("en");
            foreach (var empId in list) {
                dynamic employee = new ExpandoObject();
                employee.Id = empId;
                employee.FirstName = faker.Name.FirstName();
                employee.LastName = faker.Name.LastName();
                employee.PhoneNumber = faker.Phone.PhoneNumber();
                GenerateFakeEmployeeReport(employee);
            }
        }

        private void GenerateFakeEmployeeReport(dynamic emp)
        {
            var faker = new Faker("en");
            var docs = new List<Report>();
            for (int i = 0; i < faker.Random.Int(10, 75); i++) {
                var document = new Report {
                    EmployeeId = emp.Id,
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    Content = faker.Lorem.Paragraphs(2),
                    Date = faker.Date.PastOffset(2, new DateTimeOffset(DateTime.UtcNow)),
                    MRN = faker.Hacker.Adjective(),
                    PhoneNumber = emp.PhoneNumber,
                    Deleted = faker.Random.Bool(0.01f),
                    Actions = GetActions(),
                    IncidentType = GetRandomIncidentType(),
                    PersonType = GetRandomPersonType(),
                    Location = GetRandomLocation()
                };
                docs.Add(document);
            }
            ctx.Incidents.AddRange(docs);
            ctx.SaveChanges();
        }

        private List<Benton.HealthIR.Models.Action> GetActions()
        {
            var faker = new Faker("en");
            var list = new List<Benton.HealthIR.Models.Action>();
            for (int i = 0; i < faker.Random.Int(0, 25); i++)
            {
                list.Add(new Benton.HealthIR.Models.Action {
                    EmployeeId = faker.Person.UserName,
                    FirstName = faker.Name.FirstName(),
                    LastName = faker.Name.LastName(),
                    Content = faker.Lorem.Paragraphs(2),
                    Date = faker.Date.PastOffset(2, new DateTimeOffset(DateTime.UtcNow)),
                    Complete = faker.Random.Bool(0.01f),
                    Deleted = faker.Random.Bool(0.01f)
                });
            }
            return list;
        }
        private IncidentType  GetRandomIncidentType(){
            return ctx.IncidentTypes.OrderBy(r => Guid.NewGuid()).First();
        }
        private PersonType GetRandomPersonType(){
            return ctx.PersonTypes.OrderBy(r => Guid.NewGuid()).First();
        }
        private Location GetRandomLocation(){
            return ctx.Locations.OrderBy(r => Guid.NewGuid()).First();
        }

    }
 
}