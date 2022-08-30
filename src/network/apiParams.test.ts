import {ApiParams, RequestParams} from "./apiParams";
import {post} from "../util/http";
import {MAKE_TOKEN} from "./request";
import {Helpers} from "../util/helpers";

test("getPostParams", function () {


    let reqJson = "{\"action\":\"/app/user/login\",\"deviceName\":\"MI 10\",\"qtime\":1661867447738,\"ranstr\":\"Rnd0pCYO\",\"sysVersion\":\"10\",\"query\":{\"name\":\"13123938412\",\"password\":\"123123\"}}";


    let res = Helpers.aesEncrypt("uCvN7Jexfy8O9NY4", reqJson)
    expect(res).toEqual("54Yw8dT6rHgGP/Px29bpRA4wyxEnYDHo9eo2GiTceMOmSVD6MXgTUgBYuYhXZawQ7wQxNqW4XCcOG1b9eLhDg1\u002BLMwsaZAPSJ3ekSSjsVp\u002BTSGusloSQlInKsIxK0dy8mCFNbnhaJxnhsO2gagRnxbRjyeEzGPa7twDdpz1LyTTQvaaSkXP5J6Ul4V522Si8on/DybJJzqczOAfoeZoheTydNI4cTZBkhH7O9PFi35M=")

    res = Helpers.aesEncrypt("fGTKGj1VVAYaNIEu", "/app/user/login")
    expect(res).toEqual("qUD0vkRwtIaddWN5yDIHDQ==")

    res = Helpers.md5(reqJson);
    expect(res).toEqual("eab7e7d1095b23d577eca0c7d3470006")
})
