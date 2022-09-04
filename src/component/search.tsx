import React, {useState} from "react";
import {Select, Form} from "antd";
import {post} from "../util/http";
import {ACTIVITY_DETAIL, ActivityDetail, SEARCH, SearchResult} from "../network/api/search";
import {ApiParams} from "../network/apiParams";


export type SearchProps = {
    activityChange : (value: number) => void
}

const Search: React.FC<SearchProps> = (props) => {

    const {Option} = Select;

    // 演出搜索
    const fetchData = (value: string, callback: (data: any[]) => void) => {
        // 判断value 是否是纯数字，纯数字调用activity_detail接口，否则调用activity_search接口
        if (/^\d+$/.test(value)) {
            let apiParams = new ApiParams();
            apiParams.set("activityId", value);
            post(ACTIVITY_DETAIL, apiParams, (data: ActivityDetail) => {
                callback([data])
            })
        } else {
            let apiParams = new ApiParams();
            apiParams.set("keyword", value);
            apiParams.set("pageNo", 1);
            apiParams.set("pageSize", 20);
            post(SEARCH, apiParams, (data: SearchResult) => {
                callback(data.activityInfo)
            })
        }
    };

    const [data, setData] = useState<any[]>([]);
    const [value, setValue] = useState<number>();

    const handleSearch = (newValue: string) => {
        if (newValue) {
            fetchData(newValue, setData);
        }
    };

    const handleChange = (newValue: number) => {
        setValue(newValue);
        props.activityChange(newValue)
    };

    const options = data.map(d => <Option key={d.activityId}>{d.title}</Option>);

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
