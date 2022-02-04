using System;
namespace Core.Constants
{
	public class ErrorDescription
    {
        // Tokens
        public const string TOKEN_REFRESH_ERROR = "Something went wrong while refreshing your token";

        // Customers - Suppliers
        public const string CONFIRMED_EMAIL = "This email address is already in use";

        public const string CONFIRMED_VAT = "This Vat Number is already is uses";

        // Users
        public const string USER_DOES_NOT_EXIST = "The user doesn't exist";

        // License
        public const string INVALID_LICENSE = "This salesman doesn't have an active license";

        // Invalid Contact Request
        public const string INVALID_CONTACT_REQUEST = "This contact request has already been taken by another salesman";

        // Appointments
        public const string INVALID_APPOINTMENT_TOKEN = "Your appointment token is invalid";

        // Invalid Date for Appointment
        public const string INVALID_APPOINTMENT_DATE = "One or more of your appointment proposals are invalid";

        public const string INVALID_APPOINTMENT_PROPOSAL_COUNT = "An appointment proposal should always have 3 timeslots";

        // User To Add Errors
        public const string ADD_USER_ERROR = "An error has occured, see details for more information";

        // Item not found
        public const string ITEM_NOT_FOUND = "The request is valid, but no results were found";

        public const string ITEMS_NOT_FOUND = "The request is valid, but no results were found";
    }
}

