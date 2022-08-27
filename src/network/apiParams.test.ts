import {ApiParams, RequestParams} from "./apiParams";
import {post} from "../util/requestUtil";

test("getPostParams",function (){
    let apiParams = new ApiParams();
    let request  : RequestParams = {
        action : "/common/user/maketoken",
        z : true,
        type : "REQUEST_QUERY"
    }

    var postParams = apiParams.getPostParams(request);

    var data = post("app/00000000lcvj",postParams);

    data.then(function (res){
        console.log(res);
    })

    // console.log();
})
