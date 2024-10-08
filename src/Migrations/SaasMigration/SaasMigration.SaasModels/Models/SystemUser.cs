using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class SystemUser
    {
        public uint Id { get; set; }
        /// <summary>
        /// Id cửa hàng/gian hàng/công ty/đơn vị,...
        /// </summary>
        public int ShopId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Avatar { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int? Creator { get; set; }
        public int? Editor { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool IsActive { get; set; }
        public byte IsDeleted { get; set; }
        public int? GroupId { get; set; }
        /// <summary>
        /// Player ID trên OneSignal sử dụng để push notification.
        /// </summary>
        public string OneSignalPlayerId { get; set; }
        public string Uuid { get; set; }
    }
}
