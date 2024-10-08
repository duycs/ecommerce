using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class CustomerOrder
    {
        public uint Id { get; set; }
        public string OrderType { get; set; }
        /// <summary>
        /// Chinh thuc, tra hang, doi hang
        /// </summary>
        public string OrderTransactionType { get; set; }
        public int? CustomerId { get; set; }
        public int? StoreId { get; set; }
        public string OrderCode { get; set; }
        public DateOnly? OrderDate { get; set; }
        public decimal? TotalQuantity { get; set; }
        /// <summary>
        /// Tổng doanh thu đơn hàng
        /// </summary>
        public decimal? GrossRevenue { get; set; }
        /// <summary>
        /// Tam tinh thanh tien tren cac items
        /// </summary>
        public decimal? SubTotal { get; set; }
        /// <summary>
        /// Thanh tien sau khi tinh toan thue, van chuyen, ...
        /// </summary>
        public decimal? GrandTotal { get; set; }
        /// <summary>
        /// Thanh tong tien sau khi tru di discount
        /// </summary>
        public decimal? Total { get; set; }
        /// <summary>
        /// Tổng giá vốn bán hàng
        /// </summary>
        public decimal? TotalCost { get; set; }
        public decimal? DiscountCash { get; set; }
        public decimal? DiscountPercent { get; set; }
        /// <summary>
        /// Tien thue
        /// </summary>
        public decimal? Tax { get; set; }
        /// <summary>
        /// So tien khach dua
        /// </summary>
        public decimal? CustomerGive { get; set; }
        /// <summary>
        /// CustomerPay = CustomerGive - CustomerGetBack
        /// </summary>
        public decimal? CustomerPay { get; set; }
        /// <summary>
        /// So tien thua khach nhan ve
        /// </summary>
        public decimal? CustomerGetBack { get; set; }
        public string Note { get; set; }
        public string NoteInternal { get; set; }
        public string StatusCode { get; set; }
        /// <summary>
        /// So thu tu bill
        /// </summary>
        public string RecordOrder { get; set; }
        public int? CreatorId { get; set; }
        public int? EditorId { get; set; }
        public decimal? Liabilities { get; set; }
        public ulong? IsLiabilitiesExceed { get; set; }
        public ulong? IsLiabilitiesExceedRequest { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsActivated { get; set; }
        public string Uuid { get; set; }
        public DateTime? CreatedTime { get; set; }
        /// <summary>
        /// ID tài khoản kế toán
        /// </summary>
        public int? AccountingAccountId { get; set; }
        /// <summary>
        /// Trạng thái đơn hàng cần [Giao ngay], phục vụ cho bộ phận kho nhặt hàng và chuyển hàng luôn.
        /// </summary>
        public bool? IsShippingNow { get; set; }
        public int? EditingId { get; set; }
        public int? CustomerOrderNumber { get; set; }
        /// <summary>
        /// Trạng thái xác định đã thông báo cho khách trong trường hợp đơn hàng vượt định mức công nợ.
        /// </summary>
        public int? IsDebtNotifyCustomer { get; set; }
        public int? Version { get; set; }
        /// <summary>
        /// Thời gian thanh toán
        /// </summary>
        public DateTime? PaymentTime { get; set; }
        /// <summary>
        /// Thời gian yêu cầu thanh toán
        /// </summary>
        public DateTime? RequestPaymentTime { get; set; }
    }
}
