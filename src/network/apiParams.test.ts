import {ApiParams, RequestParams} from "./apiParams";
import {post} from "../util/http";
import {MAKE_TOKEN} from "./request";

test("getPostParams",function (){



    post(MAKE_TOKEN,{},function (res){
        console.log(res)
    });



})
