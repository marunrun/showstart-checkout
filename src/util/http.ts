import {http} from "@tauri-apps/api";
import {RequestQo} from "../network/request";

let baseUrl = 'https://pro2-api.showstart.com'



var client = await http.getClient();



export  function post(requestQo: RequestQo, data: object, callback : ((res :string) => void),sessionId? : string) {

}

