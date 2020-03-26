using System.ComponentModel;

namespace HealthIR.API.Core.Enums {
    public enum IncidentType {
        CountyPropertyDamage = 0,
        OtherPropertyDamage = 1,
        InjuryToOthers = 2,
        IncidentAllegation = 3,
        other = 99
    }

    public enum EventType {
        [Description ("Medication Error")]
        MedicationError,
        LabError,
        MedicalAlert,
        BodyFluidContact,
        NeedleSharpsStick,
        FallTrip,
        Injury,
        PropertyDamage,
        TheftMissingProperty,
        ConfidentialityConcern,
        VerbalTreatAggression,
        PhysicalAggression,
        SuicideAttempt,
        Suicide,
        DeathNaturalCauses,
        DeathOtherCauses,
        MandatoryReport,
        Other = 99

    }

    public enum EventSite{
        BHC,
        ELHC,
        LHC,
        MHC,
        AHC,
        SHHC,
        SUNSET,
        
        Other = 99
    }

    public enum EventVictimType { 
        Employee,
        Visitor,
        ClientPatient,
        Other = 99
    }
}