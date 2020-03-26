
using Benton.EF.Core;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;

namespace Benton.HealthIR.Models
{
    public class Settings : Entity<Guid> {
        internal string document { get; set; } = null!;

        [NotMapped]
        public dynamic? Configuration {
            get { return document == null ? null : JsonConvert.DeserializeObject<dynamic>(document); }
            set { document = JsonConvert.SerializeObject(value); }
        }

        public Settings()
        {
            Type = "Settings";
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }
    }

    public class SettingConfiguration: EntityConfiguration<Settings, Guid> {
        public override void Configure(EntityTypeBuilder<Settings> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.document)
             .HasColumnName("JSONDocument")
             .IsRequired();

            builder.Property(p => p.Type).IsRequired()
                .HasDefaultValue("JSONSetting")
                .HasMaxLength(24);

            builder.Ignore(p => p.Configuration);

            builder.ToTable("Settings");

            builder.HasData(
                new Settings {
                    Id = Guid.NewGuid(),
                    Type = "HIRConfiguration",
                    Configuration = GetEmptySettingsConfiguration(),
                    CreatedBy = "SYSTEM",
                    CreatedDate = DateTimeOffset.Now 
                }
            );    
        }

        private dynamic GetEmptySettingsConfiguration() {
            var faker = new Faker("en");
            dynamic retval = new ExpandoObject() ;
            retval.ComplianceManager = faker.Internet.Email();
            retval.HIMManager = faker.Internet.Email();
            retval.SafetyCoordinator = faker.Internet.Email();
            retval.FinanceDirector = faker.Internet.Email();
            retval.CountyCouncil = faker.Internet.Email();
            return retval;
        }
    }

    

}
