

namespace ECommerce.Shared.Exceptions
{
    public class ECommerceBusinessRule : BusinessRule
    {
        public static BusinessRule InvalidCustomer = RegisterRule(1, @"Invalid customer");
        public static BusinessRule AddressNotFound = RegisterRule(2, @"Address not found");
        public static BusinessRule AddressNotDefault = RegisterRule(3, @"Address not default");
        public static BusinessRule TableNameInvalid = RegisterRule(4, @"Table Name Invalid");

        // Identity
        public static BusinessRule NoUserFound = RegisterRule(101, @"No user found with this name or email address");
        public static BusinessRule UserNotActive = RegisterRule(102, @"User account is not active");
        public static BusinessRule WrongPassword = RegisterRule(103, @"Wrong password");
        public static BusinessRule UserNameExists = RegisterRule(104, @"UserName exists");
        public static BusinessRule PasswordInvalid = RegisterRule(105, @"Password is invalid");

        // Cart
        public static BusinessRule NoCartFound = RegisterRule(200, @"No cart found");
        public static BusinessRule QuantityNotEnough = RegisterRule(201, @"Quantity in stock is not enough");
        public static BusinessRule PriceChanged = RegisterRule(202, @"Price in stock is changed");
        public static BusinessRule ProductNotExistInCart = RegisterRule(203, @"Product does not exist in cart");
        public static BusinessRule NotItemsInCart = RegisterRule(204, @"Not items in cart");

        // Order
        public static BusinessRule NoOrderFound = RegisterRule(300, @"No order found");
        public static BusinessRule OrderApproved = RegisterRule(301, @"Order approved");

        // share
        public static BusinessRule InvalidInput = RegisterRule(400, @"Invalid Input");
        public static BusinessRule WardNotExists = RegisterRule(401, @"Ward does not exists");

        // Integration
        public static BusinessRule NoMappingFound = RegisterRule(500, @"No mapping found");
        public static BusinessRule QuantityUpdated = RegisterRule(501, @"Quantity was changed before updating, please try again!");
        public static BusinessRule NoProductMappingFound = RegisterRule(502, @"Not any product mapped");
        public static BusinessRule NoOrderMappingFound = RegisterRule(503, @"Not any order mapped");
        public static BusinessRule StatusIsNotAllowed = RegisterRule(504, @"Status is not allowed to update");
        public static BusinessRule AccountExists = RegisterRule(505, @"Account exists");
        public static BusinessRule NoCustomerMappingFound = RegisterRule(506, @"Not any customer mapped");

        // Notification
        public static BusinessRule NoNotificationFound = RegisterRule(600, @"No notification found");

        public ECommerceBusinessRule(int code, string message) : base(code, message)
        {
        }
    }
}
