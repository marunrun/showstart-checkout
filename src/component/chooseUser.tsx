import React, {useEffect, useState} from 'react';
import {Button, Select, Space} from 'antd';
import {post} from "../util/http";
import {ADDRESS_LIST, AddressInfo, COMMON_PERFORMER, performerInfo} from "../network/api/userInfo";
import {ApiParams} from "../network/apiParams";


export type UserInfoProps = {
    onPerformerChange: (value: performerInfo[]) => void;
    onAddressChange: (value: AddressInfo) => void;
    isLogin : boolean
}



const ChooseUser: React.FC<UserInfoProps> = (props) => {

    // 观影人信息
    const [performerList, setPerformerList] = useState<PerformerOption[]>([]);
    const [defaultPerformerId, setDefaultPerformerId] = useState<number[]>([]);

    // 收货地址
    const [addressList, setAddressList] = useState<AddressOption[]>([]);
    const [defaultAddressId, setDefaultAddressId] = useState<number>();


    interface PerformerOption {
        label: string,
        value: number,
        performer : performerInfo
    }

    interface AddressOption {
        label: string,
        value: number,
        address : AddressInfo
    }


    // 初始化
    useEffect(() => {
        fetchInfo()
    }, [props.isLogin])


    // 观影人信息更新
    const handlePerformerChange = function (val: number[],options :PerformerOption[]) {
        props.onPerformerChange(options.map((option: any) => { return option.performer}));
        setDefaultPerformerId(val);
    }


    // 收货地址更新
    function handleAddressChange(val: any,option :AddressOption) {

        props.onAddressChange(option.address);
        setDefaultAddressId(val);
    }

    // 获取用户信息
    const fetchInfo = function () {
        post(COMMON_PERFORMER, new ApiParams(), (res) => {
            setPerformerList(res.map((item: performerInfo) => {
                    return {
                        label:item.name,
                        value: item.id,
                        performer : item
                    }
            }));
            props.onPerformerChange([res[0]]);
            setDefaultPerformerId([res.length > 0 && res[0].id])
        })

        post(ADDRESS_LIST, new ApiParams(), (res) => {
            setAddressList(res.map((item: AddressInfo) => {
                return {
                    label:item.address,
                    value: item.id,
                    address : item
                }
            }));
            setDefaultAddressId(res.length > 0 && res[0].id)
        })
    }


    return (
        <Space direction="vertical" size="small">

            <div>
                观影人&nbsp;&nbsp;&nbsp;&nbsp;：
                <Select
                    placeholder="请选择常用观影人"
                    // @ts-ignore
                    onChange={handlePerformerChange}
                    mode="multiple"
                    style={{width: '200px'}}
                    value={defaultPerformerId}
                    options={performerList}
                >
                </Select>
            </div>
            <div>
                收货地址：
                <Select
                    placeholder="请选择收货地址"
                    style={{width: '200px'}}
                    value={defaultAddressId}
                    // @ts-ignore
                    onChange={handleAddressChange}
                    options={addressList}
                >
                </Select>
            </div>

            <Button size="small" onClick={fetchInfo} type="primary"> 刷新用户信息 </Button>
        </Space>
    )

}

export default ChooseUser;
