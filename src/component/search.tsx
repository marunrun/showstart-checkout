import React, {useState} from "react";
import {Button, Card, Input, Select, Form} from "antd";
// import jsonp from 'reques';
import qs from 'qs';

const Search: React.FC = () => {

    const {Option} = Select;

    let timeout: ReturnType<typeof setTimeout> | null;
    let currentValue: string;

    const fetchData = (value: string, callback: (data: { value: string; text: string }[]) => void) => {
        if (timeout) {
            clearTimeout(timeout);
            timeout = null;
        }
        currentValue = value;

        const fake = () => {
            const str = qs.stringify({
                code: 'utf-8',
                q: value,
            });
            fetch(`https://suggest.taobao.com/sug?${str}`)
                .then((response: any) => response.json())
                .then((d: any) => {
                    if (currentValue === value) {
                        const {result} = d;
                        const data = result.map((item: any) => ({
                            value: item[0],
                            text: item[0],
                        }));
                        callback(data);
                    }
                });
        };

        timeout = setTimeout(fake, 300);
    };

    const [data, setData] = useState<any[]>([]);
    const [value, setValue] = useState<string>();

    const handleSearch = (newValue: string) => {
        if (newValue) {
            fetchData(newValue, setData);
        } else {
            setData([]);
        }
    };

    const handleChange = (newValue: string) => {
        setValue(newValue);
    };

    const options = data.map(d => <Option key={d.value}>{d.text}</Option>);

    return (
        <>
            <Form.Item
                label="演出搜索"
                rules={[{required: true, message: '请选择演出'}]}
            >
                <Select
                    showSearch
                    value={value}
                    placeholder="搜索"
                    // style={props.style}
                    defaultActiveFirstOption={false}
                    showArrow={false}
                    filterOption={false}
                    onSearch={handleSearch}
                    onChange={handleChange}
                    notFoundContent={null}
                >
                    {options}
                </Select>
            </Form.Item>

        </>
    );
}

export default Search
