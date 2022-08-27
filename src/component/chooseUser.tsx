import React, {useEffect, useState} from 'react';
import {Button, Card, List, Select, Space} from 'antd';
import internal from "stream";

const {Option} = Select;


export type UserInfo = {
    id: string;
    name: string;
    address: string;
}

export type UserInfoProps = {
    onChange: (value: string) => void;
}

const ChooseUser: React.FC<UserInfoProps> = (props) => {

    const [userInfoList, setUserInfoList] = useState<UserInfo[]>([]);
    const [selectKey, setSelectKey] = useState<number>(-1)

    useEffect(() => {
        setUserInfoList([
            {
                id: "1",
                name: "marun",
                address: "杭州"
            },
            {
                id: "2",
                name: "marin",
                address: "江苏"
            },
        ])    }, [])


    const handleOnChange = function (val: string, option: any) {
        props.onChange(val);
        setSelectKey(option.key)
    }

    const fetchInfo = function () {
        setUserInfoList([
            {
                id: "3",
                name: "marun3",
                address: "杭州3"
            },
            {
                id: "4",
                name: "marin4",
                address: "江苏4"
            },
        ])
    }

    return (
            <Space direction="vertical" size="small">

            <Select
                placeholder="请选择常用观影人"
                onChange={handleOnChange}
                style={{width: 200}}
            >
                {userInfoList.map((info, key) => {
                    return <Option value={info.id} key={key}>{info.name}</Option>
                })}
            </Select>

            <Select
                placeholder="请选择收货地址"

            >
            </Select>
            <Button size="small" onClick={fetchInfo} type="primary" > 刷新用户信息 </Button>
            </Space>
)

}

export default ChooseUser;
