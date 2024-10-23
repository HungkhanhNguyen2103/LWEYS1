namespace LWEYS.Common
{
    public class PathUrl
    {
        //Account
        public static string ACCOUNT_REGISTER = "api/Account/Register";
        public static string ACCOUNT_LOGIN = "api/Account/Login";
        public static string ACCOUNT_GETALL = "api/Account/GetAll";
        public static string ACCOUNT_GET_INFO = "api/Account/Information";
        public static string ACCOUNT_UPDATE_INFO = "api/Account/UpdateInformation";
        public static string ACCOUNT_CONFIRMEMAIL = "api/Account/ConfirmEmail";
        public static string ACCOUNT_TOGGLE_LOCK_USER = "api/Account/ToggleLockUser";
        public static string ACCOUNT_ACCESS_ROLE = "api/Account/GrantAccessRole";
        public static string ACCOUNT_FORGOT_PASSWORD = "api/Account/ForgotPassword";
        public static string ACCOUNT_CHANGE_PASSWORD = "api/Account/ChangePassword";
        public static string ACCOUNT_RE_CONFIRM_EMAIL = "api/Account/ReConfirmEmail";

        //Post Category
        public static string POSTCATEGORY_GETALL = "api/PostCategory/GetAll";
        public static string POSTCATEGORY_UPDATE = "api/PostCategory/Update";
        public static string POSTCATEGORY_DELETE = "api/PostCategory/Delete";

        //Post
        public static string POST_GETALL = "api/Post/GetAll";
        public static string POST_GETDETAIL = "api/Post/Get";
        public static string POST_UPDATE = "api/Post/Update";
        public static string POST_DELETE = "api/Post/Delete";

        //AboutUs
        public static string ABOUT_US = "api/AboutUs/Update";
        public static string ABOUT_US_GET = "api/AboutUs/Get";

        //Order
        public static string SERVICE_GETALL = "api/Order/GetAllService";
        public static string SERVICE_GETDETAIL = "api/Order/GetService";
        public static string SERVICE_UPDATE = "api/Order/UpdateService";
        public static string SERVICE_DELETE = "api/Order/DeleteService";
        public static string SERVICE_BOOKING = "api/Order/Booking";
        public static string SERVICE_GETLISTSERVICE_ORDER = "api/Order/GetListServiceOrder";
        public static string SERVICE_CANCEL_BOOKING = "api/Order/CancelBooking";
        public static string SERVICE_CHANGE_ORDERTYPE = "api/Order/ChangeServiceOrderType";
        public static string SERVICE_SHOW_PAYMENT = "api/Order/ShowPayment";
        public static string SERVICE_PAYMENT_ORDER = "api/Order/PaymentOrder";

        public static string SERVICE_PAYMENT_WITH_MOMO = "api/Order/PaymentWithMomo";

        public static string SERVICE_RATING = "api/Order/Rating";
        public static string SERVICE_GET_RATING = "api/Order/GetRating";

        
        //User Question
        public static string USER_QUESTION_SEND = "api/UserQuestion/SendQuestion";
        public static string USER_QUESTION_FEEDBACK = "api/UserQuestion/FeedbackUserQuestion";
        public static string USER_QUESTION_GETALL = "api/UserQuestion/GetQuestions";
        public static string USER_QUESTION_GET_BY_USER = "api/UserQuestion/GetQuestionsByUser";

        //Report
        public static string REPORT_APP = "api/Order/Report";
    }

}
