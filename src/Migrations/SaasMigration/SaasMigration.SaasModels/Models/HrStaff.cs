using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class HrStaff
    {
        public uint Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Số CMND
        /// </summary>
        public string IdentityCard { get; set; }
        public string Gender { get; set; }
        public string Avatar { get; set; }
        public int? ProvinceId { get; set; }
        public int? DistrictId { get; set; }
        public int? WardId { get; set; }
        public string Address { get; set; }
        /// <summary>
        /// ID Kho/Cá»­a hÃ ng
        /// </summary>
        public int? StoreId { get; set; }
        /// <summary>
        /// ID bộ phận
        /// </summary>
        public int? DepartmentId { get; set; }
        public string LoginStatus { get; set; }
        public string RecoverPasswordToken { get; set; }
        public string RememberToken { get; set; }
        public DateTime? RememberWhen { get; set; }
        public string ActiveToken { get; set; }
        public DateTime? ActiveTime { get; set; }
        public DateTime? ActiveTimeExpired { get; set; }
        /// <summary>
        /// Account ID
        /// </summary>
        public int? AccountId { get; set; }
        public string FacebookId { get; set; }
        public string GoogleId { get; set; }
        public string ZaloId { get; set; }
        public string Uid { get; set; }
        public int? Editor { get; set; }
        public int? Creator { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        /// <summary>
        /// TrÃƒÂ¡Ã‚ÂºÃ‚Â¡ng thÃƒÆ’Ã‚Â¡i hoÃƒÂ¡Ã‚ÂºÃ‚Â¡t Ãƒâ€žÃ¢â‚¬ËœÃƒÂ¡Ã‚Â»Ã¢â€žÂ¢ng
        /// </summary>
        public bool? IsActivated { get; set; }
        public bool? IsDeleted { get; set; }
        public string Uuid { get; set; }
    }
}
