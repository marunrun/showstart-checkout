
import React from "react";
import {Button, Form, Select, Space} from "antd";

const Buttons: React.FC = () => {


    return (
        <>
            <Space>

            <Button type="primary">立即购票</Button>
            <Button type="primary">开始捡漏</Button>
            <Button type="primary">定时购票</Button>
            </Space>

        </>
    );
}

export default Buttons;
