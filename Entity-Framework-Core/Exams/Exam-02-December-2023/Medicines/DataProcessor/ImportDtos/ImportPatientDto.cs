namespace Medicines.DataProcessor.ImportDtos
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstraints;

    public class ImportPatientDto
    {
        [Required]
        [MinLength(PatientNameMinLength)]
        [MaxLength(PatientNameMaxLength)]
        public string FullName { get; set; } = null!;

        [Required]
        [Range(PatientAgeGroupMinValue, PatientAgeGroupMaxValue)]
        public int AgeGroup { get; set; }

        [Required]
        [Range(PatientGenderMinValue, PatientGenderMaxValue)]
        public int Gender { get; set; }

        [Required]
        public int[] Medicines { get; set; } 
    }
}
