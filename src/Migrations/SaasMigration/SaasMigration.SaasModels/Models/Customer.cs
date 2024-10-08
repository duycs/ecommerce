using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class Customer
    {
        public uint Id { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public string Phone4 { get; set; }
        public string Address { get; set; }
        public int? ProvinceId { get; set; }
        public int? DistrictId { get; set; }
        public int? WardId { get; set; }
        public string Gender { get; set; }
        public string IndentityCard { get; set; }
        public string MetaData { get; set; }
        public string Avatar { get; set; }
        /// <summary>
        /// Cong no hien tai
        /// </summary>
        public decimal? Liabilities { get; set; }
        /// <summary>
        /// Gioi han cong no cho phep
        /// </summary>
        public decimal? MaxLiabilities { get; set; }
        public int? Creator { get; set; }
        public int? Editor { get; set; }
        public string RecoverPasswordToken { get; set; }
        /// <summary>
        /// Kiểu (nhóm) khách hàng: Khách bán buôn, bán lẻ,...
        /// </summary>
        public string CustomerType { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool? IsActivated { get; set; }
        public bool? IsDeleted { get; set; }
        public string ActiveToken { get; set; }
        public DateTime? ActiveTime { get; set; }
        public DateTime? ActiveTimeExpired { get; set; }
        public string MembershipClass { get; set; }
        public string Password { get; set; }
        public string Uid { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string Uuid { get; set; }
        /// <summary>
        /// Số thứ tự đơn hàng dành riêng cho từng khách hàng.
        /// </summary>
        public int? CustomerOrderNumber { get; set; }
    }
}
