namespace TaliExpress.Server.Enums
{
    public enum ReturnCode
    {
        Success,
        General_Error,
        Incorrect_password,
        No_parameters_entered,
        No_user_found,
        No_cart_found,
        Parameter_is_null_or_empty,
        No_product_found,
        Item_successfully_added_to_the_cart,
        Item_successfully_removed_from_the_cart,
        User_is_null,
        User_exist,
        Invalid_parameters,
        Unmatched_passwords,
        Cannot_insert_to_DB,
    }
}
