export interface response {
    invalidParams: string;
    isHasResult: string;
    msg: string;
    result: string;
    state: string;
    status: number;
}

export enum state {
    access_to_many = "access too many",
    third_register_alert = "third.register.alert",
    user_not_login = "USER_NOT_LOGIN_DEFAULT",
    user_other_login = "login.other.terminal",
    user_login_again = "access.expire",
    user_ref_login_again = "user.ref.empty",
    user_token_login_again = "token.empty",
    ServiceErr = "90009",
    faceErr = "face_limit_error"
}
