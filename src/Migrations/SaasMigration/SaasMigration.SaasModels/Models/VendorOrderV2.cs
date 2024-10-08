using System;
using System.Collections.Generic;

namespace SaasMigration.SaasModels.Models
{
    public partial class VendorOrderV2
    {
        public uint Id { get; set; }
        /// <summary>
        /// Id nhà cung cấp
        /// </summary>
        public int? VendorId { get; set; }
        /// <summary>
        /// ID nhà vận chuyển
        /// </summary>
        public int? TransporterId { get; set; }
        /// <summary>
        /// id cửa hàng
        /// </summary>
        public int? StoreId { get; set; }
        /// <summary>
        /// Mã đơn hang
        /// </summary>
        public string OrderCode { get; set; }
        /// <summary>
        /// Trạng thái đơn đặt.:
        /// 1. Chờ nhập : waiting_import
        /// 2. Thiếu hàng: quantity_missing
        /// 3. Đủ hàng: quantity_completed
        /// 4. Thừa hàng: quantity_more
        /// 5. Hoàn thành: completed
        /// </summary>
        public string StatusCode { get; set; }
        /// <summary>
        /// &quot;- Tình trạng đơn hàng:
        /// 1. Chưa nhập: waiting_import
        /// 2. Thiếu hàng: quantity_missing
        /// 3. Đủ hàng: quantity_completed
        /// 4. Thừa hàng: quantity_more&quot;
        /// </summary>
        public string StateCode { get; set; }
        /// <summary>
        /// - Tạm tính tiền đơn đặt.
        /// </summary>
        public decimal? SubTotal { get; set; }
        /// <summary>
        /// &quot;- Tạm tính tiền đơn đặt khi tạo đơn đặt
        /// </summary>
        public decimal? SubTotalInit { get; set; }
        /// <summary>
        /// - Tạm tính tiền đơn đặt đã nhập
        /// </summary>
        public decimal? SubTotalImported { get; set; }
        /// <summary>
        /// Giảm giá %
        /// </summary>
        public decimal? DiscountPercent { get; set; }
        /// <summary>
        /// Giảm giá theo tiền mặt
        /// </summary>
        public decimal? DiscountCash { get; set; }
        /// <summary>
        /// - Tổng tiền sau chiết khấu: 
        /// </summary>
        public decimal? Total { get; set; }
        /// <summary>
        /// - Thành tiền sau tất cả chi phí đơn hàng. 
        /// </summary>
        public decimal? GrandTotal { get; set; }
        /// <summary>
        /// - Thành tiền sau tất cả chi phí đơn hàng. 
        /// </summary>
        public decimal? GrandTotalImported { get; set; }
        /// <summary>
        /// - Công thức: TotalImported= (SubTotalImported - DiscountCash) - ( SubTotalImported *DiscountPercent / 100)
        /// </summary>
        public decimal? TotalImported { get; set; }
        /// <summary>
        /// Thời gian đặt ghi nhận đặt hàng
        /// </summary>
        public DateTime? OrderDate { get; set; }
        /// <summary>
        /// Ghi chú đơn đặt
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// Ghi chú đơn nhập cho nội bộ
        /// </summary>
        public string NoteInternal { get; set; }
        /// <summary>
        /// Tiền tệ.  Mã tiền tệ theo quốc gia
        /// </summary>
        public string CurrencyCode { get; set; }
        /// <summary>
        /// giá đón quy đổi ra VND
        /// </summary>
        public decimal? ExchangeRate { get; set; }
        /// <summary>
        /// Tổng số lượng đặt
        /// </summary>
        public decimal? TotalQuantity { get; set; }
        /// <summary>
        /// Tổng số lượng khi tạo đơn ( không cập nhật khi sửa đơn )
        /// </summary>
        public decimal? TotalQuantityInit { get; set; }
        /// <summary>
        /// Tổng số lượng đã nhập của đơn đặt
        /// </summary>
        public decimal? TotalQuantityImported { get; set; }
        /// <summary>
        /// Tổng số tiền đã
        /// </summary>
        public decimal? TotalAmountPaid { get; set; }
        /// <summary>
        /// So thu tu bill
        /// </summary>
        public string RecordOrder { get; set; }
        /// <summary>
        /// thời gian quyết toán đơn hàng
        /// </summary>
        public DateTime? TimeFinalAccounts { get; set; }
        /// <summary>
        /// Version bản ghi
        /// </summary>
        public int? Version { get; set; }
        public int? CreatorId { get; set; }
        public int? EditorId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool? IsDeleted { get; set; }
        public string Uuid { get; set; }
    }
}
