using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class MoneyAccount
    {
        public uint Id { get; set; }
        public int? ParentId { get; set; }
        public string ParentCode { get; set; }
        public int? StoreId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string AccountType { get; set; }
        public string Description { get; set; }
        public string CurrencyCode { get; set; }
        /// <summary>
        /// So du co
        /// </summary>
        public decimal? CreditBalance { get; set; }
        /// <summary>
        /// So du no
        /// </summary>
        public decimal? DebitBalance { get; set; }
        public int? BankId { get; set; }
        public string BankName { get; set; }
        public string BankBranch { get; set; }
        public string BankAccountName { get; set; }
        public string BankAccountNumber { get; set; }
        public int? CreatorId { get; set; }
        public int? EditorId { get; set; }
        public string Uid { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool? IsSystemInit { get; set; }
        public bool IsShowed { get; set; }
        public bool IsActivated { get; set; }
        public bool IsDeleted { get; set; }
        public string Uuid { get; set; }
    }
}
