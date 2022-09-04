import React from "react";
import {Button, Space} from "antd";

export type ButtonsProps = {
    buyNow: () => void
    buyPickup: () => void
    buyTicket: () => void
    pickEnable : boolean
    ticketEnable : boolean
}

const Buttons: React.FC<ButtonsProps> = (props) => {


    return (
        <>
            <Space>
                <Button type="primary" htmlType="submit" onClick={props.buyNow}>立即购票</Button>
                <Button type="primary" htmlType="submit" onClick={props.buyPickup}>{props.pickEnable? "取消捡漏" :"开始捡漏"}</Button>
                <Button type="primary" htmlType="submit" onClick={props.buyTicket}>{props.ticketEnable ? "取消定时" : "定时购票"}</Button>
            </Space>
        </>
    );
}

export default Buttons;
