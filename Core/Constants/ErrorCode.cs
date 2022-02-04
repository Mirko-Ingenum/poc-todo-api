using System;
namespace Core.Constants
{
	public class ErrorCode
	{
        // Tokens
        public const string TOKEN_REFRESH_ERROR = "TOKEN_REFRESH_ERROR";

        // Customers - Suppliers
        public const string CONFIRMED_EMAIL = "CONFIRMED_EMAIL";

        public const string CONFIRMED_VAT = "CONFIRMED_VAT";

        // Users
        public const string USER_DOES_NOT_EXIST = "USER_DOES_NOT_EXIST";

        // Licenses
        public const string INVALID_LICENSE = "INVALID_LICENSE";

        // Invalid Contact Request
        public const string INVALID_CONTACT_REQUEST = "INVALID_CONTACT_REQUEST";

        public const string INVALID_APPOINTMENT_TOKEN = "INVALID_APPOINTMENT_TOKEN";

        // Invalid Date for Appointment
        public const string INVALID_APPOINTMENT_DATE = "INVALID_APPOINTMENT_DATE";

        public const string INVALID_APPOINTMENT_PROPOSAL_COUNT = "INVALID_APPOINTMENT_PROPOSAL_COUNT";

        // User To Add Errors
        public const string ADD_USER_ERROR = "ADD_USER_ERROR";

        // Item not found
        public const string ITEM_NOT_FOUND = "ITEM_NOT_FOUND";

        public const string ITEMS_NOT_FOUND = "ITEMS_NOT_FOUND";
    }
}

