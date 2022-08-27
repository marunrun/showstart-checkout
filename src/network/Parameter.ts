

export interface Parameter {
    action : string;
    deviceName : string;
    qtime: number;
    ranstr : string;
    sysVersion : string
}

export interface ParameterBody  extends  Parameter{
    body : Object

}

export  interface ParameterQueryBody{
    query : Object
}

export  interface RealParameter {
    appid : string;
    aru : string;
    data : string;
    sign : string;
    terminal : string;
    version : string
}
