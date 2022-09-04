import React, {useEffect, useState} from "react";
import {Cascader, Form, FormInstance, InputNumber} from "antd";
import {post} from "../util/http";
import {TICKET_LIST, TicketInfo, TicketListResult} from "../network/api/ticket";
import {ApiParams} from "../network/apiParams";


export type TicketProps = {
    activityId: number | undefined
    ticketChange: (tickerInfo: TicketInfo) => void
    form: FormInstance
}

const Ticket: React.FC<TicketProps> = (props) => {
    const [options, setOptions] = useState<Option[]>([])

    useEffect(() => {

        if (!props.activityId) {
            return;
        }
        fetchTicket(props.activityId)
    }, [props.activityId])


    function fetchTicket(activityId: number) {
        let apiParams = new ApiParams();
        apiParams.set("activityId", activityId);
        post(TICKET_LIST, apiParams, (data: TicketListResult) => {
            const newOptions = data.sessions.map((session) => {
                return {
                    value: session.sessionName,
                    label: session.sessionName,
                    children: session.ticketList.map((ticket) => {
                        return {
                            value: ticket.ticketId,
                            ticketInfo: ticket,
                            label: ticket.ticketType + " 库存：" + ticket.remainTicket,
                        }
                    })
                }
            })

            // @ts-ignore
            setOptions(newOptions)
            let defaultTicket = [newOptions[0].value, newOptions[0].children![0].value]
            props.form.setFieldsValue({"ticket": defaultTicket})
            props.ticketChange(newOptions[0].children![0].ticketInfo!)
        })
    }

    interface Option {
        value: number;
        label: string;
        ticketInfo?: TicketInfo;
        children?: Option[];
    }


    const onChange = (value: any[], option: any) => {
        props.ticketChange(option.length > 0 && option[1].ticketInfo!)
    };


    return (
        <>
            <Form.Item>

                <Form.Item
                    style={{display: 'inline-flex'}}
                    label="选票"
                    rules={[{required: true, message: '请选择演出'}]}
                    required={true}
                    name="ticket"
                >
                    <Cascader
                        options={options}
                        onChange={onChange}
                        style={{width: 300}}
                        placeholder="请选票"/>
                </Form.Item>
                <Form.Item
                    label={"购票数量"}
                    style={{display: 'inline-flex',}}
                    name="buyCount"
                    required={true}
                    rules={[{required: true, message: '请选择购票数量'}]}
                >
                    <InputNumber min={1}/>

                </Form.Item>
            </Form.Item>

        </>
    );
}

export default Ticket;
